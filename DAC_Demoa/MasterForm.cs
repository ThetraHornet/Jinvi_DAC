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

namespace DAC_Demoa
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllForm();
            Global.Form1 = new LoginPage();
            Global.Form1.Show();
        }
        
        private void closeAllForm()
        {
            if (Global.Form1 != null)
            {
                Global.Form1.Hide();
            }

            if (Global.Form2 != null)
            {
                Global.Form2.Hide();
                Global.modbusClient.Disconnect();
            }
            if (Global.Form3 != null)
            {
                Global.Form3.Hide();
                Global.OpcConnector.Disconnect();
            }

            if (Global.Form4 != null)
            {
                Global.Form4.Hide();
                Global.plc.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
