using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_Demoa.Class
{
    public class Records_ProfiNet
    {
        public string S7Model { get; set; }
        public string TagName { get; set; }
        public int Index { get; set; }
        public string DataBlock { get; set; }
        public string DataType { get; set; }
        public string DataParameter { get; set; }
        public string Irai { get; set; }
        public Records_ProfiNet(string tag, int index, string dblock, string dtype, string dpara)
        {
            TagName = tag;
            Index = index;
            DataBlock = dblock;
            DataType = dtype;
            DataParameter = dpara;
        }


        public override string ToString()
        {
            return $"{TagName}:{DataBlock}{DataType}{DataParameter}";
        }
    }
}
