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
using AAS.Core.DB;
using AAS.Core.Model.Assets;
using AAS.Core.Config;

namespace DAC_Demoa
{
    

    public partial class ModbusTCP_page : MasterForm
    {
        private System.Timers.Timer timer = new System.Timers.Timer();
        private List<Class.Records_ModbusTCP> records = new List<Class.Records_ModbusTCP>(); //Tag Name,index,data address,base address, length, IRAI
        private List<Class.Records_ModbusTCP> selectedRecords = new List<Class.Records_ModbusTCP>(); //Tag Name,index,data address,base address, length, IRAI


        public ModbusTCP_page()
        {
            InitializeComponent();
            LoadRecord();
            ConfigManager.SetConfigPath(@"~\Resource\AAS.config");
            //this code set data into checkboxlist
            //var iraiData = FakeServer.GetIraiList();

            var asset = MongoHelper.Asset.GetAllCollectionAssets();
            checkedListBox1.Items.AddRange(asset.ToArray());
            checkedListBox1.DisplayMember = "Irai";
        }

        private void dataRefresh(object sender, ElapsedEventArgs e)
        {
            //0 Tag Name, 1 index, 2 data address,3 base address, 4 length, 5 IRAI
            foreach (var record in selectedRecords)
            {
                if (record.DataAddress.ToString() == "Coil Status (0X)")
                {
                    bool[] coils = Global.modbusClient.ReadCoils(record.BaseAdress - 1, record.Length);
                    bool bvalue = Convert.ToBoolean(coils[0]);
                    var data = new
                    {
                        DateTime = DateTime.Now,
                        TagName = record.TagName,
                        Value = bvalue
                    };
                    //cb_irai.Invoke(new MethodInvoker(delegate () { cb_irai.Items[record.Index] = record.Index.ToString() + ":" + bvalue; }));
                    cb_irai.Invoke(new MethodInvoker(delegate () { cb_irai.Items[record.Index] = $"{record.TagName} : {bvalue}"; }));
                    MongoHelper.Asset.UpdatePrimaryValue(record.Irai, data);


                }
                else if (record.DataAddress.ToString() == "Holding Register (4X)")
                {
                    int[] holdingRegister = Global.modbusClient.ReadHoldingRegisters(record.BaseAdress - 1, record.Length);
                    var rawValue = holdingRegister[0];
                    float fvalue = Convert.ToSingle(Decimal.Divide(rawValue, 10));
                    var data = new
                    {
                        DateTime = DateTime.Now,
                        TagName = record.TagName,
                        Value = fvalue
                    };
                    //cb_irai.Invoke(new MethodInvoker(delegate () { cb_irai.Items[record.Index] = record.Index.ToString() + ":" + fvalue; }));
                    cb_irai.Invoke(new MethodInvoker(delegate () { cb_irai.Items[record.Index] = $"{record.TagName} : {fvalue}"; }));
                    MongoHelper.Asset.UpdatePrimaryValue(record.Irai, data);
                }

            }
        }

        private void btn_connect2_Click(object sender, EventArgs e)
        {
            var base_address = Int32.Parse(Base_tip.Text);
            var length = Int32.Parse(txt_length.Text);

            var record = new Class.Records_ModbusTCP(txt_tag.Text, records.Count, cb_data.SelectedItem.ToString(), base_address, length);

            records.Add(record);
            //list_data.Items.Add((records.Count).ToString() + ":" + textBox1.Text + "(" + base_address + ":" + length + ")", false);
            list_data.Items.Add(record);
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


            foreach(var item in list_data.CheckedItems)
            {
                selectedRecords.Add((Class.Records_ModbusTCP)item);
                selectedRecords.Find(x => x == (Class.Records_ModbusTCP)item).Index = selectedRecords.Count - 1;
                cb_irai.Items.Add(0, false);
            }
            timer.Start();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this code display item in property grid
            //propertyGrid2.SelectedObject = (FakeIrai)checkedListBox1.SelectedItem;
            //txt_irai.Text = ((FakeIrai)checkedListBox1.SelectedItem).IRAI;

            //getting asset from gui
            var asset = (PrimaryAsset)checkedListBox1.SelectedItem;
            propertyGrid2.SelectedObject = (PrimaryAsset)checkedListBox1.SelectedItem;
            txt_irai.Text = ((PrimaryAsset)checkedListBox1.SelectedItem).Irai;

            ////display to listbox2
            //checkedListBox1.DataSource = asset.Properties.Values.ToList();
            //checkedListBox1.DisplayMember = "Name";
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this code will only allow 1 item checked
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
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
                records = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class.Records_ModbusTCP>>(json);
            }

            foreach(var record in records)
            {
                //list_data.Items.Add($"{records.Count}:{record.TagName}({record.BaseAdress}:{record.Length })", false);
                list_data.Items.Add(record);
                
            }

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += dataRefresh;
        }

        private void list_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = (Class.Records_ModbusTCP)list_data.SelectedItem;
        }

        private void btn_mapIRAI_Click(object sender, EventArgs e)
        {
            var record = (Class.Records_ModbusTCP)list_data.SelectedItem;
            record.Irai = txt_irai.Text;
            propertyGrid1.SelectedObject = (Class.Records_ModbusTCP)list_data.SelectedItem;
            Save();
        }



        private void delete_Tag_Click(object sender, EventArgs e)
        {
            var Records = list_data.Items;
        
            Records.Remove(list_data.SelectedItem);
            records.Remove((Class.Records_ModbusTCP)list_data.SelectedItem);
            
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            var cb_record = cb_irai.Items;

            cb_record.Remove(cb_irai.SelectedItem);
            cb_record.Remove((Class.Records_ModbusTCP)cb_irai.SelectedItem);
        }

        private void cb_irai_SelectedIndexChanged(object sender, EventArgs e)
        {

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
