using System;
using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;


namespace DAC_Demoa.Class
{
    public class OpcConnector
    {
        private ApplicationConfiguration config;
        private ApplicationInstance application;
        private EndpointDescription selectedEndpoint;
        private Session session;
        private Subscription subscription;
        private readonly Mapping mapping = Mapping.Instance;

        public void Connect(string url)
        {
            // no idea what OPC foundation is thinking with these code
            config = CreateApplicationConfiguration();
            config.Validate(ApplicationType.Client).GetAwaiter().GetResult();

            if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = e.Error.StatusCode == StatusCodes.BadCertificateUntrusted; };
            }
            
            application = CreateApplicationInstance();
            application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();
            selectedEndpoint = CoreClientUtils.SelectEndpoint(url, false, int.MaxValue);
            session = Session.Create(config, new ConfiguredEndpoint(null, selectedEndpoint, EndpointConfiguration.Create(config)), false, "", 6000, null, null).GetAwaiter().GetResult();
            session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out _, out var refs);
            subscription = CreateSubscription();
        }

        public Dictionary<string, string> ScanForNodes()
        {
            //Scan for incoming nodes from server 
            var scanList = new Dictionary<string, string>();
            session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out _, out var refs);
            scanList = GetDataNodes(refs, null);
            return scanList;
        }

        public Dictionary<string, string> GetDataNodes(ReferenceDescriptionCollection references, ReferenceDescription upperRd)
        {
            var Nodes = new Dictionary<string, string>();
            foreach (var rd in references)
            {
                if (rd.DisplayName == "Server") continue;
                if (rd.NodeClass == NodeClass.Object)
                {
                    session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out _, out var nextRefs);
                    var TempNodes = new Dictionary<string, string>();

                    TempNodes = GetDataNodes(nextRefs, rd);
                    foreach (var item in TempNodes)
                    {
                        Nodes[item.Key] = item.Value;
                    }
                    TempNodes = null;
                }
                else if (rd.NodeClass == NodeClass.Variable)
                {
                    mapping.Add(rd.DisplayName.ToString(), upperRd.DisplayName.ToString());
                    Nodes[rd.DisplayName.ToString()] = rd.NodeId.ToString();
                }
            }

            return Nodes;
        }

        private Subscription CreateSubscription()
        {
            return new Subscription(session.DefaultSubscription)
            {
                PublishingInterval = 1000,
                PublishingEnabled = true
            };
        }
        private SecurityConfiguration CreateSecurityConfiguration()
        {
            return new SecurityConfiguration
            {
                ApplicationCertificate = new CertificateIdentifier { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault", SubjectName = Utils.Format(@"CN={0}, DC={1}", "Jinvi OPCUA Client", System.Net.Dns.GetHostName()) },
                TrustedIssuerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities" },
                TrustedPeerCertificates = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications" },
                RejectedCertificateStore = new CertificateTrustList { StoreType = @"Directory", StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates" },
                AutoAcceptUntrustedCertificates = true,
                AddAppCertToTrustedStore = true
            };
        }
        private ApplicationInstance CreateApplicationInstance()
        {
            return new ApplicationInstance
            {
                ApplicationName = "Jinvi OPCUA Client",
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = config
            };
        }
        private ApplicationConfiguration CreateApplicationConfiguration()
        {
            return new ApplicationConfiguration()
            {
                ApplicationName = "Jinvi OPCUA Client",
                ApplicationUri = Utils.Format($"urn:{System.Net.Dns.GetHostName()}:Jinvi OPCUA Client"),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = CreateSecurityConfiguration(),
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                TraceConfiguration = new TraceConfiguration()
            };
        }

        public void Subscribe(List<Records_OPCUA> itemsToSubscribe)
        {
            session.RemoveSubscription(subscription);
            subscription = CreateSubscription();

            foreach (var item in itemsToSubscribe)
            {
                var monitoredItem = new MonitoredItem
                {
                    DisplayName = item.Name,
                    StartNodeId = item.NodeId
                };
                monitoredItem.Notification += OnSensorData;
                subscription.AddItem(monitoredItem);
            }

            session.AddSubscription(subscription);
            subscription.Create();
        }



        private static void OnSensorData(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            Mapping mapping = Mapping.Instance;

            foreach (var data in item.DequeueValues())
            {
                var key = item.DisplayName;
                var assetId = Mapping.Instance.GetAssetByOpc(key);
                var value = data.Value;
                var dateTime = DateTime.Now;

                if (!Global.OPCUA.Exists(x => x.Name == key))
                {
                    Global.OPCUA.Add(new Records_OPCUA(key, "", "", 0, ""));
                }

                Global.OPCUA.Find(x => x.Name == key).Value = value.ToString();
                BufferSender.Instance.Add(assetId, value, dateTime);
            }
        }

        public void Disconnect()
        {
            application.Stop();
            session.Close();
        }
    }

}
