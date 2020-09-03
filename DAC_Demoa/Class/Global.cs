using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using S7.Net.Types;

namespace DAC_Demoa.Class
{
    public class Global
    {
        public static LoginPage Form1;
        public static ModbusTCP_page Form2;
        public static OPCUA_page Form3;
        public static ProfiNet_page Form4;
        public static OpcConnector OpcConnector = new OpcConnector();
        
        public static EasyModbus.ModbusClient modbusClient;
        public static List<Records_OPCUA> OPCUA { get; set; } = new List<Records_OPCUA>();
        public static Plc plc;
    }
}
