using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_Demoa.Class
{
    public class Records_ModbusTCP
    {
        public string TagName { get; set; }
        public int Index { get; set; }
        public int BaseAdress { get; set; }
        public string DataAddress { get; set; }
        public int Length { get; set; }
        public string Irai { get; set; }
        public Records_ModbusTCP(string tag, int index, string data, int baseadd, int length)
        {
            TagName = tag;
            Index = index;
            DataAddress = data;
            BaseAdress = baseadd;
            Length = length;
        }


        public override string ToString()
        {
            return $"{TagName}[{BaseAdress}:{Index}]";
        }


    }

}
