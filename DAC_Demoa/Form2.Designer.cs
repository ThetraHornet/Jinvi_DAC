namespace DAC_Demoa
{
    partial class ModbusTCP_page
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
            this.btn_connect2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_length = new System.Windows.Forms.TextBox();
            this.Base_tip = new System.Windows.Forms.TextBox();
            this.cb_data = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.list_data = new System.Windows.Forms.CheckedListBox();
            this.cb_irai = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tag = new System.Windows.Forms.TextBox();
            this.btn_match = new System.Windows.Forms.Button();
            this.txt_irai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_mapIRAI = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.delete_Tag = new System.Windows.Forms.Button();
            this.DataAddress_tips = new System.Windows.Forms.ToolTip(this.components);
            this.Base_tips = new System.Windows.Forms.ToolTip(this.components);
            this.point_tips = new System.Windows.Forms.ToolTip(this.components);
            this.Tag_tips = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connect2
            // 
            this.btn_connect2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect2.Location = new System.Drawing.Point(463, 44);
            this.btn_connect2.Name = "btn_connect2";
            this.btn_connect2.Size = new System.Drawing.Size(91, 32);
            this.btn_connect2.TabIndex = 0;
            this.btn_connect2.Text = "Map Tag";
            this.btn_connect2.UseVisualStyleBackColor = true;
            this.btn_connect2.Click += new System.EventHandler(this.btn_connect2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Point :";
            // 
            // txt_length
            // 
            this.txt_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_length.Location = new System.Drawing.Point(639, 13);
            this.txt_length.Name = "txt_length";
            this.txt_length.Size = new System.Drawing.Size(100, 24);
            this.txt_length.TabIndex = 3;
            this.point_tips.SetToolTip(this.txt_length, "Number of point is the amount of data to be retrieved\r\nfrom device.");
            // 
            // Base_tip
            // 
            this.Base_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Base_tip.Location = new System.Drawing.Point(395, 13);
            this.Base_tip.Name = "Base_tip";
            this.Base_tip.Size = new System.Drawing.Size(100, 24);
            this.Base_tip.TabIndex = 4;
            this.DataAddress_tips.SetToolTip(this.Base_tip, "Data Address is the memory location of the device.");
            // 
            // cb_data
            // 
            this.cb_data.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_data.FormattingEnabled = true;
            this.cb_data.Items.AddRange(new object[] {
            "Coil Status (0X)",
            "Holding Register (4X)"});
            this.cb_data.Location = new System.Drawing.Point(119, 14);
            this.cb_data.Name = "cb_data";
            this.cb_data.Size = new System.Drawing.Size(146, 21);
            this.cb_data.TabIndex = 5;
            this.DataAddress_tips.SetToolTip(this.cb_data, "\"Coil Status\" is a boolean (bit) variable and \"Holding Register\"\r\nis an integer (" +
        "16 bits) variable.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Address :";
            // 
            // list_data
            // 
            this.list_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_data.FormattingEnabled = true;
            this.list_data.Location = new System.Drawing.Point(19, 132);
            this.list_data.Name = "list_data";
            this.list_data.Size = new System.Drawing.Size(191, 242);
            this.list_data.TabIndex = 7;
            this.list_data.SelectedIndexChanged += new System.EventHandler(this.list_data_SelectedIndexChanged);
            // 
            // cb_irai
            // 
            this.cb_irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_irai.FormattingEnabled = true;
            this.cb_irai.Location = new System.Drawing.Point(762, 136);
            this.cb_irai.Name = "cb_irai";
            this.cb_irai.Size = new System.Drawing.Size(204, 208);
            this.cb_irai.TabIndex = 8;
            this.cb_irai.SelectedIndexChanged += new System.EventHandler(this.cb_irai_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tag Name :";
            // 
            // txt_tag
            // 
            this.txt_tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tag.Location = new System.Drawing.Point(119, 48);
            this.txt_tag.Name = "txt_tag";
            this.txt_tag.Size = new System.Drawing.Size(317, 24);
            this.txt_tag.TabIndex = 10;
            this.Tag_tips.SetToolTip(this.txt_tag, "Tag name is given by user to the data retrieve from\r\ndevice. Example of  tag name" +
        "s are \"Temperature\",\r\n\"Pressure01\", etc,.");
            // 
            // btn_match
            // 
            this.btn_match.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_match.Location = new System.Drawing.Point(886, 90);
            this.btn_match.Name = "btn_match";
            this.btn_match.Size = new System.Drawing.Size(80, 34);
            this.btn_match.TabIndex = 11;
            this.btn_match.Text = "Display";
            this.btn_match.UseVisualStyleBackColor = true;
            this.btn_match.Click += new System.EventHandler(this.btn_match_Click);
            // 
            // txt_irai
            // 
            this.txt_irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_irai.Location = new System.Drawing.Point(379, 350);
            this.txt_irai.Name = "txt_irai";
            this.txt_irai.Size = new System.Drawing.Size(593, 24);
            this.txt_irai.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "IRAI :";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(234, 120);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(508, 214);
            this.propertyGrid1.TabIndex = 15;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(240, 214);
            this.checkedListBox1.TabIndex = 16;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(641, 90);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 37);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_mapIRAI
            // 
            this.btn_mapIRAI.Location = new System.Drawing.Point(234, 345);
            this.btn_mapIRAI.Name = "btn_mapIRAI";
            this.btn_mapIRAI.Size = new System.Drawing.Size(91, 37);
            this.btn_mapIRAI.TabIndex = 18;
            this.btn_mapIRAI.Text = "Map IRAI";
            this.btn_mapIRAI.UseVisualStyleBackColor = true;
            this.btn_mapIRAI.Click += new System.EventHandler(this.btn_mapIRAI_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGrid2);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(22, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 256);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IRAI Browser";
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(262, 19);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(682, 214);
            this.propertyGrid2.TabIndex = 20;
            // 
            // delete_Tag
            // 
            this.delete_Tag.Location = new System.Drawing.Point(119, 87);
            this.delete_Tag.Name = "delete_Tag";
            this.delete_Tag.Size = new System.Drawing.Size(91, 37);
            this.delete_Tag.TabIndex = 20;
            this.delete_Tag.Text = "DELETE";
            this.delete_Tag.UseVisualStyleBackColor = true;
            this.delete_Tag.Click += new System.EventHandler(this.delete_Tag_Click);
            // 
            // ModbusTCP_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.delete_Tag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_mapIRAI);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.txt_irai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_match);
            this.Controls.Add(this.txt_tag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_irai);
            this.Controls.Add(this.list_data);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_data);
            this.Controls.Add(this.Base_tip);
            this.Controls.Add(this.txt_length);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ModbusTCP_page";
            this.Text = "ModbusTCP";
            this.Controls.SetChildIndex(this.btn_connect2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_length, 0);
            this.Controls.SetChildIndex(this.Base_tip, 0);
            this.Controls.SetChildIndex(this.cb_data, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.list_data, 0);
            this.Controls.SetChildIndex(this.cb_irai, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txt_tag, 0);
            this.Controls.SetChildIndex(this.btn_match, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txt_irai, 0);
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.btn_save, 0);
            this.Controls.SetChildIndex(this.btn_mapIRAI, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.delete_Tag, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connect2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_length;
        private System.Windows.Forms.TextBox Base_tip;
        private System.Windows.Forms.ComboBox cb_data;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox list_data;
        private System.Windows.Forms.CheckedListBox cb_irai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tag;
        private System.Windows.Forms.Button btn_match;
        private System.Windows.Forms.TextBox txt_irai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_mapIRAI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.Button delete_Tag;
        private System.Windows.Forms.ToolTip DataAddress_tips;
        private System.Windows.Forms.ToolTip Base_tips;
        private System.Windows.Forms.ToolTip point_tips;
        private System.Windows.Forms.ToolTip Tag_tips;
    }
}