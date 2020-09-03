using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;

namespace DAC_Demoa.Class
{
    class BufferSender
    {
        private const string EdgeUrl = "tcp://localhost:5001";
        private TimeSpan TimeoutSpan = new TimeSpan(0, 0, 0, 5);
        private BufferSender()
        {
            Task.Run(() => TransmitDataToEdge());
        }

        public static BufferSender Instance { get; } = new BufferSender();

        private ConcurrentQueue<TransportData> QueueData { get; set; } = new ConcurrentQueue<TransportData>();

        public void Add(string assetId, object value, DateTime dt)
        {
            QueueData.Enqueue(new TransportData
            {
                AssetId = assetId,
                DateTime = dt,
                Value = value
            });
        }

        public int Count()
        {
            return QueueData.Count;
        }

        private void TransmitDataToEdge()
        {
            //this service is forever running
            while (true)
            {
                if (QueueData.Count > 0)
                {
                    //data is sent whenever the queue is not empty
                    try
                    {
                        QueueData.TryDequeue(out var value);
                        SendData(value);
                    }
                    catch (Exception e)
                    {
                        //log crash 
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    //check queue count again after sleep
                    Thread.Sleep(100);
                }

            }
        }

        private void SendData(TransportData data)
        {
            //convert object to json string 
            var jsonData = JsonConvert.SerializeObject(data);

            //this while loop will keep trying to send the same data until success
            while (true)
            {
                using (var client = new RequestSocket())
                {
                    //connect to edge server via TCP url
                    client.Connect(EdgeUrl);

                    //try send and receive confirmation from edge
                    var sendSuccess = client.TrySendFrame(TimeoutSpan, jsonData);
                    var receiveSuccess = client.TryReceiveFrameString(TimeoutSpan, out var message);

                    //break while if the message is sent successfully
                    if (sendSuccess && receiveSuccess) return;
                }
            }

        }

    }
}
