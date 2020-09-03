using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_Demoa.Class
{
    public class Records_OPCUA
    {
        public int Index { get; set; }
        public string Irai { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string NodeId { get; set; }


        public Records_OPCUA(string Name, string NodeId,string Value, int Index,string Irai)
        {
            this.Index = Index;
            this.Irai = Irai;
            this.Value = Value;
            this.Name = Name;
            this.NodeId = NodeId;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
