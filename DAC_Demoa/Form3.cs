using DAC_Demoa.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Equin.ApplicationFramework;
using AAS.Core.DB;
using AAS.Core.Model.Assets;
using AAS.Core.Config;

namespace DAC_Demoa
{


    public partial class OPCUA_page : MasterForm
    {
        private System.Timers.Timer timer = new System.Timers.Timer();

        public OPCUA_page()
        {
            InitializeComponent();
            LoadRecord();
            //var iraiData = FakeServer.GetIraiList();
            //checkedListBox1.Items.AddRange(iraiData.ToArray());
            ConfigManager.SetConfigPath(@"C:\Users\Jinvi\source\repos\DAC_Demoa\DAC_Demoa\bin\Debug\Resource\AAS.config");

            var asset = MongoHelper.Asset.GetAllCollectionAssets();
            checkedListBox1.Items.AddRange(asset.ToArray());
            checkedListBox1.DisplayMember = "Irai";

            Dictionary<string, string> nodes = Global.OpcConnector.ScanForNodes();
            foreach (var item in nodes)
            {
                var sensorData = new Class.Records_OPCUA(item.Key, item.Value, "", 0, "");
                var globalData = Global.OPCUA.Find(x => x.Name == sensorData.Name && x.NodeId == sensorData.NodeId);



                if (globalData == null)
                {
                    list_Nodes.Items.Add(sensorData);
                }


            }
        }

        private void list_Nodes_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void dataRefresh(object sender, ElapsedEventArgs e)
        {
            foreach (var item in Global.OPCUA)
            {
                if (item.Value != null)
                {
                    cb_Irai.Invoke(new MethodInvoker(delegate () { cb_Irai.Items[item.Index] = item.Name + ":" + item.Value; }));
                    var data = new
                    {
                        DateTime = DateTime.Now,
                        TagName = item.Name,
                        Value = item.Value
                    };
                    MongoHelper.Asset.UpdatePrimaryValue(item.Irai, data);
                }
                else
                    cb_Irai.Invoke(new MethodInvoker(delegate () { cb_Irai.Items[item.Index] = item.Name + ":" + 0; }));



            }
        }


        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void btn_match_Click(object sender, EventArgs e)
        {
            timer.Elapsed += dataRefresh;
            timer.Interval = 1000;
            timer.Stop();
            Global.OPCUA.Clear();
            cb_Irai.Items.Clear();
            //for (int x = 0; x < list_Nodes.CheckedItems.Count; x++)
            //{
            //    string text = list_Nodes.CheckedItems[x].ToString();
            //    int index = text.IndexOf(',');
            //    string tagName = text.Substring(1, index - 1);
            //    Global.SensorData.Add(new SensorData { Name = tagName, Index = x, NodeId = text.Substring(index + 2, (text.Length - index - 3)) });
            //    cb_Irai.Items.Add(Global.SensorData[x], false);
            //}

            int x = 0;
            foreach (var item in list_Nodes.CheckedItems)
            {
                Class.Records_OPCUA data = (Class.Records_OPCUA)item;
                data.Index = x;
                Global.OPCUA.Add(data);
                cb_Irai.Items.Add(Global.OPCUA[x], false);
                x++;
            }

            Global.OpcConnector.Subscribe(Global.OPCUA);
            timer.Start();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this code display item in property grid

            var asset = (PrimaryAsset)checkedListBox1.SelectedItem;
            propertyGrid2.SelectedObject = (PrimaryAsset)checkedListBox1.SelectedItem;
            txt_irai.Text = ((PrimaryAsset)checkedListBox1.SelectedItem).Irai;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this code will only allow 1 item checked
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
        }

        //private void Save()
        //{
        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(records);

        //    System.IO.File.WriteAllText("SaveData.json", json);
        //}

        private void list_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = (Class.Records_OPCUA)list_Nodes.SelectedItem;
        }

        private void btn_mapIRAI_Click(object sender, EventArgs e)
        {
            var record = (Class.Records_OPCUA)list_Nodes.SelectedItem;
            Global.OPCUA.Find(x => x.Name == record.Name).Irai = txt_irai.Text;
            propertyGrid1.SelectedObject = (Class.Records_OPCUA)list_Nodes.SelectedItem;
            Save();
        }

        private void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Global.OPCUA);

            System.IO.File.WriteAllText("SaveDataOPCUA.json", json);
        }

        private void LoadRecord()
        {
            if (System.IO.File.Exists("SaveDataOPCUA.json"))
            {
                var json = System.IO.File.ReadAllText("SaveDataOPCUA.json");
                Global.OPCUA = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.Records_OPCUA>>(json);
            }

            foreach (var record in Global.OPCUA)
            {
                //list_data.Items.Add($"{records.Count}:{record.TagName}({record.BaseAdress}:{record.Length })", false);
                list_Nodes.Items.Add(record);
            }

        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
