using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DAC_Demoa.Class
{

    public class Mapping
    {
        public Dictionary<string, string> OpcKeypair { get; set; } = new Dictionary<string, string>();

        private static Mapping instance;
        private const string fileName = "Mapping.json";

        private Mapping() { }

        public static Mapping Instance
        {
            get
            {
                if (instance != null) return instance;

                if (File.Exists(fileName))
                {
                    instance = JsonConvert.DeserializeObject<Mapping>(File.ReadAllText(fileName));
                }

                return instance ?? (instance = new Mapping());
            }
        }

        private void Save()
        {
            using (var file = File.CreateText(fileName))
            {
                var converter = new JsonSerializer { Formatting = Formatting.Indented };
                converter.Serialize(file, Instance);
                file.Close();
            }
        }

        public void Add(string opcName, string assetId)
        {
            OpcKeypair[opcName] = assetId;
            Save();
        }

        public void Remove(string opcName)
        {
            if (OpcKeypair.ContainsKey(opcName))
            {
                OpcKeypair.Remove(opcName);
                Save();
            }
        }

        public string GetAssetByOpc(string opcName)
        {
            //if (OpcKeypair.ContainsKey(opcName))
            //{
            //    return OpcKeypair[opcName];
            //}
            //else
            //{
            //    return null;
            //}
            return OpcKeypair.ContainsKey(opcName) ? OpcKeypair[opcName] : null;
        }

        public string GetOpcByAsset(string assetId)
        {
            return OpcKeypair.ContainsValue(assetId) ? OpcKeypair.First(o => o.Value.Equals(assetId)).Key : null;
        }

    }

}
