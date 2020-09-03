using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_Demoa.Class
{
    public class FakeIrai
    {
        public string IRAI { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class FakeServer
    {

        public static List<FakeIrai> GetIraiList()
        {
            return new List<FakeIrai>
            {
                new FakeIrai
                {
                    IRAI= "0990-MY.0027101.0000000001-#TS-00058200.0000000005.0001",
                    Name = "Temperature Sensor",
                    Description = "This is for XX Sensor",
                },
                 new FakeIrai
                {

                    IRAI= "0990-MY.0027101.0000000001-#TS-00058200.0000000005.0002",
                    Name = "Humidity Sensor",
                    Description = "This is for XX Sensor",
                },
                  new FakeIrai
                {

                    IRAI= "0990-MY.0027101.0000000001-#TS-00058200.0000000005.0003",
                    Name = "Water Level",
                    Description = "This is for XX Sensor",
                },
                   new FakeIrai
                {

                    IRAI= "0990-MY.0027101.0000000001-#TS-00058200.0000000005.0004",
                    Name = "Wind Speed",
                    Description = "This is for XX Sensor",
                },

            };
        }

    }



}
