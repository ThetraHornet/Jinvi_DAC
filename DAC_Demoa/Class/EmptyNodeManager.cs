using System;
using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.Server;
using System.Data.SqlClient;
using Quickstarts.EmptyServer;
using AAS.Core.DB;

namespace DAC_Demoa.Class
{

    public class EmptyNodeManager : CustomNodeManager2
    {

        #region Global Variable
        public List<string[]> excelInfors = new List<string[]>();
        public string conString = @"Data Source=10.123.41.103;Initial Catalog=Advantech WISE_4220;User ID=Advantech WISE-4220;Password=22222222";

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public EmptyNodeManager(IServerInternal server, ApplicationConfiguration configuration)
        :
            base(server, configuration, Quickstarts.EmptyServer.Namespaces.Empty)
        {
            SystemContext.NodeIdFactory = this;

            // get the configuration for the node manager.
            m_configuration = configuration.ParseExtension<Quickstarts.EmptyServer.EmptyServerConfiguration>();

            // use suitable defaults if no configuration exists.
            if (m_configuration == null)
            {
                m_configuration = new Quickstarts.EmptyServer.EmptyServerConfiguration();
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
        }
        #endregion

        #region INodeIdFactory Members
        /// <summary>
        /// Creates the NodeId for the specified node.
        /// </summary>
        public override NodeId New(ISystemContext context, NodeState node)
        {
            return node.NodeId;
        }
        #endregion

        #region INodeManager Members
        /// <summary>
        /// Does any initialization required before the address space can be used.
        /// </summary>
        /// <remarks>
        /// The externalReferences is an out parameter that allows the node manager to link to nodes
        /// in other node managers. For example, the 'Objects' node is managed by the CoreNodeManager and
        /// should have a reference to the root folder node(s) exposed by this node manager.  
        /// </remarks>
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                //    BaseObjectState trigger = new BaseObjectState(null);

                //    trigger.NodeId = new NodeId(1, NamespaceIndex);
                //    trigger.BrowseName = new QualifiedName("Trigger", NamespaceIndex);
                //    trigger.DisplayName = trigger.BrowseName.Name;
                //    trigger.TypeDefinitionId = ObjectTypeIds.FileDirectoryType;

                //    // ensure trigger can be found via the server object. 
                //    IList<IReference> references = null;

                //    if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                //    {
                //        externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                //    }

                //    trigger.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                //    references.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, trigger.NodeId));

                //    PropertyState property = new PropertyState(trigger);

                //    property.NodeId = new NodeId(2, NamespaceIndex);
                //    property.BrowseName = new QualifiedName("Matrix", NamespaceIndex);
                //    property.DisplayName = property.BrowseName.Name;
                //    property.TypeDefinitionId = VariableTypeIds.PropertyType;
                //    property.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                //    property.DataType = DataTypeIds.Int32;
                //    property.ValueRank = ValueRanks.TwoDimensions;
                //    property.ArrayDimensions = new ReadOnlyList<uint>(new uint[] { 2, 2 });
                //    property.Value = 0;

                //    trigger.AddChild(property);

                //    // save in dictionary. 
                //    AddPredefinedNode(SystemContext, trigger);

                //--------------------------------------------------------------------------------------------

                Quickstarts.EmptyServer.ExcelFunction excelIRAI = new Quickstarts.EmptyServer.ExcelFunction("C:\\Users\\Administrator\\Desktop\\ServerConfig.xlsx", 1);
                List<string> IRAIs = new List<string>();



                for (int i = 1; i < excelIRAI.range.Rows.Count; i++)
                {
                    string IRAI = excelIRAI.ReadCell(i, 7);
                    if (!IRAIs.Exists(x => x.Equals(IRAI)) && IRAI != null && IRAI != "")
                    {
                        IRAIs.Add(IRAI);
                    }
                }

                List<BaseObjectState> AllIrai = new List<BaseObjectState>();
                foreach (string Irai in IRAIs)
                {
                    AllIrai.Add(new BaseObjectState(null)
                    {
                        NodeId = new NodeId(Irai, NamespaceIndex),
                        BrowseName = new QualifiedName(Irai, NamespaceIndex),
                        DisplayName = Irai,
                        TypeDefinitionId = ObjectTypeIds.FileDirectoryType
                    });
                }

                foreach (BaseObjectState baseObjectState in AllIrai)
                {
                    baseObjectState.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                    IList<IReference> references3 = null;
                    if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references3))
                    {
                        externalReferences[ObjectIds.ObjectsFolder] = references3 = new List<IReference>();
                    }
                    references3.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, baseObjectState.NodeId));
                }

                Quickstarts.EmptyServer.ExcelFunction excelFunction = new ExcelFunction("C:\\Users\\Administrator\\Desktop\\ServerConfig.xlsx", 1);

                for (int i = 1; i < excelFunction.range.Rows.Count; i++)
                {
                    if (excelFunction.ReadCell(i, 0) == null || excelFunction.ReadCell(i, 0) == "")
                    {
                        continue;
                    }
                    string Irai = excelFunction.ReadCell(i, 7);
                    string sensorIrai = excelFunction.ReadCell(i, 8);
                    BaseObjectState parent = AllIrai.Find(x => x.NodeId.Identifier.Equals(Irai));
                    List<string> IraiGroup = new List<string>();
                    if (sensorIrai != null && sensorIrai != "")
                    {
                        if (sensorIrai.Contains(","))
                        {
                            string[] sensorIrais = sensorIrai.Split(',');
                            foreach (string tempSensorIrai in sensorIrais)
                            {
                                if (!IraiGroup.Contains(tempSensorIrai))
                                    IraiGroup.Add(tempSensorIrai);
                                BaseObjectState tempParent = AllIrai.Find(x => x.NodeId.Identifier.Equals(Irai));
                                if (!(tempParent.FindChild(SystemContext, new QualifiedName(tempSensorIrai, NamespaceIndex)) != null))
                                {
                                    BaseObjectState propertyState = new BaseObjectState(parent)
                                    {
                                        NodeId = new NodeId(tempSensorIrai, NamespaceIndex),
                                        BrowseName = new QualifiedName(tempSensorIrai, NamespaceIndex),
                                        DisplayName = tempSensorIrai,
                                        TypeDefinitionId = ObjectTypeIds.BaseObjectType
                                    };
                                    parent.AddChild(propertyState);
                                }
                            }
                        }
                        else
                        {
                            BaseObjectState tempParent = AllIrai.Find(x => x.NodeId.Identifier.Equals(Irai));
                            if (!IraiGroup.Contains(sensorIrai))
                                IraiGroup.Add(sensorIrai);
                            if (!(tempParent.FindChild(SystemContext, new QualifiedName(sensorIrai, NamespaceIndex)) != null))
                            {

                                BaseObjectState propertyState = new BaseObjectState(parent)
                                {
                                    NodeId = new NodeId(sensorIrai, NamespaceIndex),
                                    BrowseName = new QualifiedName(sensorIrai, NamespaceIndex),
                                    DisplayName = sensorIrai,
                                    TypeDefinitionId = ObjectTypeIds.BaseObjectType
                                };
                                parent.AddChild(propertyState);
                            }
                        }
                    }
                    else
                    {
                        IraiGroup.Add(Irai);
                    }
                    foreach (string SensorIrai in IraiGroup)
                    {
                        parent = AllIrai.Find(x => x.NodeId.Identifier.Equals(Irai));
                        parent = (BaseObjectState)parent.FindChild(SystemContext, new QualifiedName(SensorIrai, NamespaceIndex));
                        PropertyState property3 = new PropertyState(parent);

                        string name = excelFunction.ReadCell(i, 0);
                        if (name == "")
                            continue;
                        property3.NodeId = new NodeId(name, NamespaceIndex);
                        property3.Description = excelFunction.ReadCell(i, 1);
                        property3.BrowseName = new QualifiedName(name, NamespaceIndex);
                        property3.DisplayName = property3.BrowseName.Name;
                        property3.TypeDefinitionId = VariableTypeIds.DataItemType;
                        property3.ReferenceTypeId = ReferenceTypeIds.HasProperty;

                        string dataType = excelFunction.ReadCell(i, 2);

                        if (dataType == "Float")
                            property3.DataType = DataTypeIds.Float;
                        else if (dataType == "Int16")
                            property3.DataType = DataTypeIds.Int16;
                        else if (dataType == "Int32")
                            property3.DataType = DataTypeIds.Int32;
                        else if (dataType == "Int64")
                            property3.DataType = DataTypeIds.Int64;
                        else if (dataType == "Double")
                            property3.DataType = DataTypeIds.Double;
                        else if (dataType == "Boolean")
                            property3.DataType = DataTypeIds.Boolean;
                        else if (dataType == "Byte")
                            property3.DataType = DataTypeIds.Byte;
                        else if (dataType == "Decimal")
                            property3.DataType = DataTypeIds.Decimal;

                        property3.ValueRank = ValueRanks.Any;
                        property3.ArrayDimensions = new ReadOnlyList<uint>(new uint[] { 2, 2 });
                        property3.Value = 0;

                        excelInfors.Add(new string[] { excelFunction.ReadCell(i, 0), excelFunction.ReadCell(i, 3), excelFunction.ReadCell(i, 4), excelFunction.ReadCell(i, 5).Trim(), excelFunction.ReadCell(i, 6), excelFunction.ReadCell(i, 7), excelFunction.ReadCell(i, 8) });

                        parent.AddChild(property3);
                    }
                }

                excelFunction.Dispose();

                foreach (BaseObjectState baseObjectState in AllIrai)
                {
                    AddPredefinedNode(SystemContext, baseObjectState);
                }

                //BaseObjectState weldingMachine = new BaseObjectState(null);

                //weldingMachine.NodeId = new NodeId(5, NamespaceIndex);
                //weldingMachine.BrowseName = new QualifiedName("Welding Machine", NamespaceIndex);
                //weldingMachine.DisplayName = weldingMachine.BrowseName.Name;
                //weldingMachine.TypeDefinitionId = ObjectTypeIds.BaseObjectType;

                //IList<IReference> references3 = null;

                //if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references3))
                //{
                //    externalReferences[ObjectIds.ObjectsFolder] = references3 = new List<IReference>();
                //}

                //weldingMachine.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                //references3.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, weldingMachine.NodeId));

                //ExcelFunction excelFunction = new ExcelFunction("C:\\Users\\jinvi\\Desktop\\WebAccesTag.xlsx", 1);
                //ExcelFunction excelFunction = new ExcelFunction("C:\\Users\\Administrator\\Desktop", 1);

                //for (int i = 1; i < excelFunction.range.Rows.Count; i++)
                //{

                //    PropertyState property3 = new PropertyState(weldingMachine);
                //    string name = excelFunction.ReadCell(i, 0);
                //    if (name == "")
                //        continue;
                //    property3.NodeId = new NodeId(name, NamespaceIndex);
                //    property3.Description = excelFunction.ReadCell(i, 1);
                //    property3.BrowseName = new QualifiedName(name, NamespaceIndex);
                //    property3.DisplayName = property3.BrowseName.Name;
                //    property3.TypeDefinitionId = VariableTypeIds.DataItemType;
                //    property3.ReferenceTypeId = ReferenceTypeIds.HasProperty;

                //    string dataType = excelFunction.ReadCell(i, 2);

                //if (dataType == "Float")
                //    property3.DataType = DataTypeIds.Float;
                //else if (dataType == "Int16")
                //    property3.DataType = DataTypeIds.Int16;
                //else if (dataType == "Int32")
                //    property3.DataType = DataTypeIds.Int32;
                //else if (dataType == "Int64")
                //    property3.DataType = DataTypeIds.Int64;
                //else if (dataType == "Double")
                //    property3.DataType = DataTypeIds.Double;
                //else if (dataType == "Boolean")
                //    property3.DataType = DataTypeIds.Boolean;
                //else if (dataType == "Byte")
                //    property3.DataType = DataTypeIds.Byte;

                //    property3.ValueRank = ValueRanks.Any;
                //    property3.ArrayDimensions = new ReadOnlyList<uint>(new uint[] { 2, 2 });
                //    property3.Value = 0;

                //    excelInfors.Add(new string[] { excelFunction.ReadCell(i, 0), excelFunction.ReadCell(i, 4), excelFunction.ReadCell(i, 5).Trim(), excelFunction.ReadCell(i, 3) });

                //    if (!plcModelAndIp.Contains(new string[] { excelFunction.ReadCell(i, 3), excelFunction.ReadCell(i, 4) }))
                //        plcModelAndIp.Add(new string[] { excelFunction.ReadCell(i, 3), excelFunction.ReadCell(i, 4) });

                //    weldingMachine.AddChild(property3);
                //}

                //excelFunction.Dispose();
                //AddPredefinedNode(SystemContext, weldingMachine);
                //-----------------------------------------------------------trial trgger 2------------------------------------------
                //BaseObjectState trigger2 = new BaseObjectState(null);

                //trigger2.NodeId = new NodeId("abcx", NamespaceIndex);
                //trigger2.BrowseName = new QualifiedName("Trigger2", NamespaceIndex);
                //trigger2.DisplayName = trigger2.BrowseName.Name;
                //trigger2.TypeDefinitionId = ObjectTypeIds.BaseObjectType;

                //// ensure trigger can be found via the server object. 
                //IList<IReference> references2 = null;

                //if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references2))
                //{
                //    externalReferences[ObjectIds.ObjectsFolder] = references2 = new List<IReference>();
                //}

                //trigger2.AddReference(ReferenceTypeIds.Organizes, true, ObjectIds.ObjectsFolder);
                //references2.Add(new NodeStateReference(ReferenceTypeIds.Organizes, false, trigger2.NodeId));

                //PropertyState property2 = new PropertyState(trigger2);

                //property2.NodeId = new NodeId("aaaxx", NamespaceIndex);
                //property2.BrowseName = new QualifiedName("Matrix2", NamespaceIndex);
                //property2.DisplayName = property.BrowseName.Name;
                //property2.TypeDefinitionId = VariableTypeIds.PropertyType;
                //property2.ReferenceTypeId = ReferenceTypeIds.HasProperty;
                //property2.DataType = DataTypeIds.Int32;
                //property2.ValueRank = ValueRanks.TwoDimensions;
                //property2.ArrayDimensions = new ReadOnlyList<uint>(new uint[] { 2, 2 });
                //property2.Value = 0;

                //trigger2.AddChild(property2);

                //AddPredefinedNode(SystemContext, trigger2);

                //ReferenceTypeState referenceType = new ReferenceTypeState();

                //referenceType.NodeId = new NodeId(3, NamespaceIndex);
                //referenceType.BrowseName = new QualifiedName("IsTriggerSource", NamespaceIndex);
                //referenceType.DisplayName = referenceType.BrowseName.Name;
                //referenceType.InverseName = new LocalizedText("IsSourceOfTrigger");
                //referenceType.SuperTypeId = ReferenceTypeIds.NonHierarchicalReferences;

                //if (!externalReferences.TryGetValue(ObjectIds.Server, out references))
                //{
                //    externalReferences[ObjectIds.Server] = references = new List<IReference>();
                //}

                //trigger.AddReference(referenceType.NodeId, false, ObjectIds.Server);
                //references.Add(new NodeStateReference(referenceType.NodeId, true, trigger.NodeId));

                //// save in dictionary. 
                //AddPredefinedNode(SystemConte
                m_simulationTimer = new System.Threading.Timer(ConnectPLC, null, 1000, 1000);
            }
        }
        /// <summary>
        /// Frees any resources allocated for the address space.
        /// </summary>
        public override void DeleteAddressSpace()
        {
            lock (Lock)
            {
                // TBD
            }
        }

        /// <summary>
        /// Returns a unique handle for the node.
        /// </summary>
        protected override NodeHandle GetManagerHandle(ServerSystemContext context, NodeId nodeId, IDictionary<NodeId, NodeState> cache)
        {
            lock (Lock)
            {
                // quickly exclude nodes that are not in the namespace. 
                if (!IsNodeIdInNamespace(nodeId))
                {
                    return null;
                }

                NodeState node = null;

                if (!PredefinedNodes.TryGetValue(nodeId, out node))
                {
                    return null;
                }

                NodeHandle handle = new NodeHandle();

                handle.NodeId = nodeId;
                handle.Node = node;
                handle.Validated = true;

                return handle;
            }
        }

        /// <summary>
        /// Verifies that the specified node exists.
        /// </summary>
        protected override NodeState ValidateNode(
            ServerSystemContext context,
            NodeHandle handle,
            IDictionary<NodeId, NodeState> cache)
        {
            // not valid if no root.
            if (handle == null)
            {
                return null;
            }

            // check if previously validated.
            if (handle.Validated)
            {
                return handle.Node;
            }

            // TBD

            return null;
        }
        #endregion

        #region Overridden Methods
        private void ConnectPLC(object item)
        {
            try
            {
                List<string[]> informations = excelInfors.FindAll(x => x[1] != "" && x[2] != "" && x[3] != "");

                float Temperature = 0;
                float Humidity = 0;

                foreach (string[] infor in informations)
                {
                    float value = 0;
                    var tagName = infor[0];
                    var ip = (string)infor[1];
                    var port = Int32.Parse(infor[2]);
                    EasyModbus.ModbusClient modbusClient = new EasyModbus.ModbusClient(ip, port);
                    try
                    {

                        ////Increase the Connection Timeout to 5 seconds
                        modbusClient.ConnectionTimeout = 5000;
                        modbusClient.Connect();


                        var address = Int32.Parse(infor[3]);
                        var length = Int32.Parse(infor[4]);
                        int[] holdingRegister = modbusClient.ReadHoldingRegisters(address - 1, length);
                       

                        var rawValue = holdingRegister[0];
                        value = Convert.ToSingle(Decimal.Divide(rawValue, 10));

                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(conString))
                        using (SqlCommand command = new SqlCommand("Insert into [ADVANTECH WISE-4220] (Time, TagName, Value, MachineIRAI, SensorIRAI) values(@date,@tagName,@value,@irai,@sensorIrai)", connection))
                        {
                            command.Parameters.AddWithValue("date", System.DateTime.Now);
                            command.Parameters.AddWithValue("tagName", tagName);
                            command.Parameters.AddWithValue("value", value);
                            command.Parameters.AddWithValue("irai", infor[5]);
                            command.Parameters.AddWithValue("sensorIrai", infor[6]);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();


                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    if (tagName == "Temperature")
                    {
                        Temperature = value;
                    }
                    if (tagName == "Humidity")
                    {
                        Humidity = value;
                    }

                    PropertyState matrix = (PropertyState)FindPredefinedNode(new NodeId(infor[0], NamespaceIndex), typeof(PropertyState));


                    matrix.Value = value;
                    matrix.ClearChangeMasks(SystemContext, true);

                    modbusClient.Disconnect();


                }


                var data = new Record();
                data.Temperature = Temperature;
                data.Humidity = Humidity;

                MongoHelper.Asset.UpdatePrimaryValue("0990-MY.0027101.0000000001-#TS-00058200.0000000005.0002", data);


            }
            catch (Exception e)
            {
                Utils.Trace(e, "Unexpected error during simulation.");
            }
        }

        public class Record
        {

            public Record()
            {
                dateTime = System.DateTime.Now;
            }
            public System.DateTime dateTime { get; set; }
            public float Temperature { get; set; } = 0;
            public float Humidity { get; set; } = 0;
        }
        #endregion


        #region Private Fields
        private EmptyServerConfiguration m_configuration;
        private System.Threading.Timer m_simulationTimer;
        #endregion
    }
}
