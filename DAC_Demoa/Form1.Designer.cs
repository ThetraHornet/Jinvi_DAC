namespace DAC_Demoa
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_protocol = new System.Windows.Forms.ComboBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.cb_s7model = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.protocol_tips = new System.Windows.Forms.ToolTip(this.components);
            this.ip_tips = new System.Windows.Forms.ToolTip(this.components);
            this.port_tip = new System.Windows.Forms.ToolTip(this.components);
            this.model_tips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_connect
            // 
            this.btn_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(179, 191);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(122, 49);
            this.btn_connect.TabIndex = 0;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.Location = new System.Drawing.Point(235, 80);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(250, 29);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "10.171.73.71";
            this.ip_tips.SetToolTip(this.txt_ip, "Internet Protocol address (IP address) is a numerical label assigned \r\nto each de" +
        "vice connected to a computer network that uses the\r\nInternet Protocol for commun" +
        "ication. E.g: 192.168.245.201");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Protocol :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP Address :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port ";
            // 
            // cb_protocol
            // 
            this.cb_protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_protocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_protocol.FormattingEnabled = true;
            this.cb_protocol.Items.AddRange(new object[] {
            "Modbus TCP",
            "OPC UA",
            "ProfiNet"});
            this.cb_protocol.Location = new System.Drawing.Point(235, 35);
            this.cb_protocol.Name = "cb_protocol";
            this.cb_protocol.Size = new System.Drawing.Size(250, 28);
            this.cb_protocol.TabIndex = 6;
            this.protocol_tips.SetToolTip(this.cb_protocol, "Communication protocol that use to connect DAC\r\nwith targeted Devices. E.g: choos" +
        "e \"ProfiNet\" to \r\nconnect DAC to Siemens device. ");
            this.cb_protocol.SelectedIndexChanged += new System.EventHandler(this.cb_protocol_SelectedIndexChanged);
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_port.Location = new System.Drawing.Point(235, 128);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(250, 29);
            this.txt_port.TabIndex = 2;
            this.txt_port.Text = "502";
            this.port_tip.SetToolTip(this.txt_port, "Port number is a way to identify a specific process to which an Internet\r\nor othe" +
        "r network message is to be forwarded when it arrives at a server. \r\nE.g: Port nu" +
        "mber for Modbus TCP usually is \"502\".\r\n");
            // 
            // cb_s7model
            // 
            this.cb_s7model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_s7model.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_s7model.FormattingEnabled = true;
            this.cb_s7model.Items.AddRange(new object[] {
            "S71200",
            "S71500",
            "S7200",
            "S7300",
            "S7400"});
            this.cb_s7model.Location = new System.Drawing.Point(235, 129);
            this.cb_s7model.Name = "cb_s7model";
            this.cb_s7model.Size = new System.Drawing.Size(250, 28);
            this.cb_s7model.TabIndex = 8;
            this.model_tips.SetToolTip(this.cb_s7model, "Model of the device that will be connected. ");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "TARUC DAC";
            this.notifyIcon1.Visible = true;
            // 
            // protocol_tips
            // 
            this.protocol_tips.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 270);
            this.Controls.Add(this.cb_s7model);
            this.Controls.Add(this.cb_protocol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.btn_connect);
            this.Name = "LoginPage";
            this.Text = "Login";
            this.Controls.SetChildIndex(this.btn_connect, 0);
            this.Controls.SetChildIndex(this.txt_ip, 0);
            this.Controls.SetChildIndex(this.txt_port, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cb_protocol, 0);
            this.Controls.SetChildIndex(this.cb_s7model, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_protocol;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.ComboBox cb_s7model;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolTip protocol_tips;
        private System.Windows.Forms.ToolTip ip_tips;
        private System.Windows.Forms.ToolTip port_tip;
        private System.Windows.Forms.ToolTip model_tips;
    }
}

