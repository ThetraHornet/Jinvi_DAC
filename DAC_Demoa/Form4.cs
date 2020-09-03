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
using AAS.Core.Model.Assets;
using AAS.Core.DB;
using AAS.Core.Config;
using S7.Net;

namespace DAC_Demoa
{
    public partial class ProfiNet_page : MasterForm
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private List<Class.Records_ProfiNet> records = new List<Class.Records_ProfiNet>(); //s7model, tag, index, dblock, dtype, dpara, irai
        private List<Class.Records_ProfiNet> selectedRecords = new List<Class.Records_ProfiNet>(); //s7model, tag, index, dblock, dtype, dpara, irai

        public ProfiNet_page()
        {
            InitializeComponent();
            LoadRecord();
            ConfigManager.SetConfigPath(@"C:\Users\Jinvi\source\repos\DAC_Demoa\DAC_Demoa\bin\Debug\Resource\AAS.config");

            var asset = MongoHelper.Asset.GetAllCollectionAssets();
            cb_mongo.Items.AddRange(asset.ToArray());
            cb_mongo.DisplayMember = "Irai";
        }


        private void dataRefresh(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (Global.plc)
                {
                    Global.plc.Open();
                    foreach (var record in selectedRecords)
                    {
                        var value = new object();
                        switch (record.DataType)
                        {
                            case "DBW":
                                var db1WordVariable = ((ushort)Global.plc.Read(record.DataBlock + "." + record.DataType + record.DataParameter)).ConvertToShort();
                                value = db1WordVariable;
                                break;
                            case "DBD":
                                float db1Bool1 = ((uint)Global.plc.Read(record.DataBlock + "." + record.DataType + record.DataParameter)).ConvertToFloat();
                                value = db1Bool1;
                                break;

                            case "DBB":

                                break;

                            case "DBX":
                                bool db1Bool2 = (bool)Global.plc.Read(record.DataBlock + "." + record.DataType + record.DataParameter);
                                value = db1Bool2;
                                break;
                        }
                        var data = new
                        {
                            DateTime = DateTime.Now,
                            TagName = record.TagName,
                            Value = value
                        };
                        cb_irai.Invoke(new MethodInvoker(delegate () { cb_irai.Items[record.Index] = $"{record.TagName} : {value}"; }));
                        MongoHelper.Asset.UpdatePrimaryValue(record.Irai, data);
                    }
                    Global.plc.Close();
                }
            }
            catch
            {

            }
        }



        private void btn_connect2_Click(object sender, EventArgs e)
        {
            var DataBlock = txt_dblock.Text;
            var DataType = cb_dtype.Text;
            var DataParameter = txt_para.Text;

            var record = new Class.Records_ProfiNet(Tag_tips.Text, records.Count, txt_dblock.Text, cb_dtype.Text, txt_para.Text);
            record.S7Model = Global.plc.CPU.ToString();
            records.Add(record);
            //list_data.Items.Add((records.Count).ToString() + ":" + textBox1.Text + "(" + base_address + ":" + length + ")", false);
            cb_data.Items.Add(record);
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += dataRefresh;
        }

        private void btn_match_Click(object sender, EventArgs e)
        {
            timer.Stop();
            selectedRecords.Clear();
            cb_irai.Items.Clear();
            //for (int x = 0; x < list_data.CheckedItems.Count; x++)
            //{
            //    string text = list_data.CheckedItems[x].ToString();
            //    int index = text.IndexOf(':');
            //    string number = text.Substring(0, index);
            //    selectedRecords.Add(records.Find(y => y.Index == (Int32.Parse(number) - 1)));
            //    selectedRecords[x].Index = x;
            //    cb_irai.Items.Add(0, false);
            //}


            foreach (var item in cb_data.CheckedItems)
            {
                selectedRecords.Add((Class.Records_ProfiNet)item);
                selectedRecords.Find(x => x == (Class.Records_ProfiNet)item).Index = selectedRecords.Count - 1;
                cb_irai.Items.Add(0, false);
            }
            timer.Start();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getting asset from gui
            var asset = (PrimaryAsset)cb_mongo.SelectedItem;
            propertyGrid2.SelectedObject = (PrimaryAsset)cb_mongo.SelectedItem;
            txt_irai.Text = ((PrimaryAsset)cb_mongo.SelectedItem).Irai;

        }

        private void cb_mongo_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this code will only allow 1 item checked
            for (int ix = 0; ix < cb_mongo.Items.Count; ++ix)
                if (ix != e.Index) cb_mongo.SetItemChecked(ix, false);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(records);

            System.IO.File.WriteAllText("SaveData.json", json);
        }

        private void LoadRecord()
        {
            if (System.IO.File.Exists("SaveData.json"))
            {
                var json = System.IO.File.ReadAllText("SaveData.json");
                records = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.Records_ProfiNet>>(json);
            }

            foreach (var record in records)
            {
                //list_data.Items.Add($"{records.Count}:{record.TagName}({record.BaseAdress}:{record.Length })", false);
                cb_data.Items.Add(record);

            }

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += dataRefresh;
        }

        private void btn_mapIRAI_Click(object sender, EventArgs e)
        {
            var record = (Class.Records_ProfiNet)cb_data.SelectedItem;
            record.Irai = txt_irai.Text;
            propertyGrid1.SelectedObject = (Class.Records_ProfiNet)cb_data.SelectedItem;
            Save();
        }



        private void delete_Tag_Click(object sender, EventArgs e)
        {
            var Records = cb_data.Items;

            var datas = cb_data.CheckedItems;

            List<int> indexs = new List<int>();

            foreach (var data in datas)
            {
              indexs.Add(Records.IndexOf(data));
            }

            indexs = indexs.OrderByDescending(x=>x).ToList();

            foreach(var index in indexs)
            {
                Records.RemoveAt(index);
                records.RemoveAt(index);
            }

           
        }

        private void cb_mongo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var asset = (PrimaryAsset)cb_mongo.SelectedItem;
            propertyGrid2.SelectedObject = (PrimaryAsset)cb_mongo.SelectedItem;
            txt_irai.Text = ((PrimaryAsset)cb_mongo.SelectedItem).Irai;
        }

        private void cb_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = (Class.Records_ProfiNet)cb_data.SelectedItem;
        }

        private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void tag_tips4_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
