using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGUI1.Class
{
    class MachineProperties
    {
        public string IRAI { get; set; }
        public Dictionary<string, string> OpcKeypair { get; set; } = new Dictionary<string, string>();
        public void AddProperties(string key, string value)
        {
            OpcKeypair.Add(key, value);
        }
        public string GenerateFullIrai()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IRAI);
            sb.Append("?");
            int i = 0;
            foreach (KeyValuePair<string, string> entry in OpcKeypair)
            {
                i++;
                sb.Append("[");
                sb.Append(entry.Key);
                sb.Append(":");
                sb.Append(entry.Value);
                sb.Append("]");
                if (i != OpcKeypair.Count())
                {
                    sb.Append("&");
                }
            }
            sb.Append(";");
            return sb.ToString();
        }


    }
}
