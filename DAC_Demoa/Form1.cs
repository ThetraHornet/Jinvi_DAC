using DAC_Demoa.Class;
using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAC_Demoa
{
    public partial class LoginPage : MasterForm
    {
        public LoginPage()
        {
            InitializeComponent();
            notifyIcon1.Click += NotifyIcon1_Click; ;
            notifyIcon1.Icon = SystemIcons.Application;
            Global.Form1 = this;
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (cb_protocol.SelectedIndex == 0)
            {
                var ip = txt_ip.Text;
                var port = Int32.Parse(txt_port.Text);

                Global.modbusClient = new EasyModbus.ModbusClient(ip, port);

                Global.modbusClient.ConnectionTimeout = 5000;
                try
                {
                    Global.modbusClient.Connect();
                    Global.Form2 = new ModbusTCP_page();
                    Global.Form2.Show();
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            else if (cb_protocol.SelectedIndex == 1)
            {
                try
                {
                    var url = txt_ip.Text;

                    Global.OpcConnector.Connect(url);
                    Global.Form3 = new OPCUA_page();
                    Global.Form3.Show();
                    Hide();

                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            else if (cb_protocol.SelectedIndex == 2)
            {
                try
                {
                    var ip = txt_ip.Text;

                    CpuType cpuType = (CpuType)Enum.Parse(typeof(CpuType), cb_s7model.Text);
                    using (var plc = new Plc(cpuType, ip, 0, 1))
                    {
                        plc.Open();
                        if (plc.IsAvailable)
                        {
                            Global.plc = plc;
                            plc.Close();
                            Global.Form4 = new ProfiNet_page();
                            Global.Form4.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("PLC is not available.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void cb_protocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_protocol.SelectedIndex == 0)
            {               
                label2.Text = "IP Address:";
                label3.Text = "Port";
                label1.Visible = true;
                txt_ip.Visible = true;
                txt_port.Visible = true;
                cb_s7model.Visible = false;
                label3.Visible = true;

            }
            else if (cb_protocol.SelectedIndex == 1)
            {
                label2.Text = "OPC UA URL:";
                label1.Visible = true;
                txt_ip.Visible = true;
                label3.Visible = false;
                txt_port.Visible = false;
                cb_s7model.Visible = false;
            }
            else if (cb_protocol.SelectedIndex == 2)
            {
                label2.Text = "IP Address:";
                label3.Text = "Model";
                label1.Visible = true;
                txt_ip.Visible = true;
                cb_s7model.Visible = true;
                txt_port.Visible = false;
                label3.Visible = true;
            }
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
