namespace DAC_Demoa
{
    partial class ProfiNet_page
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
            this.delete_Tag = new System.Windows.Forms.Button();
            this.btn_mapIRAI = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_match = new System.Windows.Forms.Button();
            this.Tag_tips = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dblock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connect2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.cb_mongo = new System.Windows.Forms.CheckedListBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.txt_irai = new System.Windows.Forms.TextBox();
            this.cb_irai = new System.Windows.Forms.CheckedListBox();
            this.cb_data = new System.Windows.Forms.CheckedListBox();
            this.txt_para = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_dtype = new System.Windows.Forms.ComboBox();
            this.dataBlock_tips = new System.Windows.Forms.ToolTip(this.components);
            this.dataType_tips = new System.Windows.Forms.ToolTip(this.components);
            this.Tag_tips4 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delete_Tag
            // 
            this.delete_Tag.Location = new System.Drawing.Point(120, 118);
            this.delete_Tag.Name = "delete_Tag";
            this.delete_Tag.Size = new System.Drawing.Size(91, 37);
            this.delete_Tag.TabIndex = 35;
            this.delete_Tag.Text = "DELETE";
            this.delete_Tag.UseVisualStyleBackColor = true;
            // 
            // btn_mapIRAI
            // 
            this.btn_mapIRAI.Location = new System.Drawing.Point(232, 379);
            this.btn_mapIRAI.Name = "btn_mapIRAI";
            this.btn_mapIRAI.Size = new System.Drawing.Size(91, 37);
            this.btn_mapIRAI.TabIndex = 34;
            this.btn_mapIRAI.Text = "Map IRAI";
            this.btn_mapIRAI.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(646, 118);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 37);
            this.btn_save.TabIndex = 33;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(329, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 29;
            this.label5.Text = "IRAI :";
            // 
            // btn_match
            // 
            this.btn_match.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_match.Location = new System.Drawing.Point(884, 118);
            this.btn_match.Name = "btn_match";
            this.btn_match.Size = new System.Drawing.Size(80, 37);
            this.btn_match.TabIndex = 28;
            this.btn_match.Text = "Display";
            this.btn_match.UseVisualStyleBackColor = true;
            // 
            // Tag_tips
            // 
            this.Tag_tips.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tag_tips.Location = new System.Drawing.Point(129, 79);
            this.Tag_tips.Name = "Tag_tips";
            this.Tag_tips.Size = new System.Drawing.Size(317, 24);
            this.Tag_tips.TabIndex = 27;
            this.Tag_tips4.SetToolTip(this.Tag_tips, "Tag name is given by user to the data retrieve from\r\ndevice. Example of  tag name" +
        "s are \"Temperature\",\r\n\"Pressure01\", etc,.\r\n");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tag Name :";
            // 
            // txt_dblock
            // 
            this.txt_dblock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dblock.Location = new System.Drawing.Point(130, 35);
            this.txt_dblock.Name = "txt_dblock";
            this.txt_dblock.Size = new System.Drawing.Size(91, 26);
            this.txt_dblock.TabIndex = 23;
            this.dataBlock_tips.SetToolTip(this.txt_dblock, "Data block is a location that store recorded data before transmit to\r\nthe PROFINE" +
        "T interface of the IO controller. E.g: DB1");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Data Block : ";
            // 
            // btn_connect2
            // 
            this.btn_connect2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect2.Location = new System.Drawing.Point(477, 73);
            this.btn_connect2.Name = "btn_connect2";
            this.btn_connect2.Size = new System.Drawing.Size(91, 37);
            this.btn_connect2.TabIndex = 21;
            this.btn_connect2.Text = "Map Tag";
            this.btn_connect2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.propertyGrid2);
            this.groupBox1.Controls.Add(this.cb_mongo);
            this.groupBox1.Location = new System.Drawing.Point(23, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 256);
            this.groupBox1.TabIndex = 37;
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
            // cb_mongo
            // 
            this.cb_mongo.FormattingEnabled = true;
            this.cb_mongo.Location = new System.Drawing.Point(11, 19);
            this.cb_mongo.Name = "cb_mongo";
            this.cb_mongo.Size = new System.Drawing.Size(240, 214);
            this.cb_mongo.TabIndex = 16;
            this.cb_mongo.SelectedIndexChanged += new System.EventHandler(this.cb_mongo_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(232, 151);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(508, 222);
            this.propertyGrid1.TabIndex = 41;
            // 
            // txt_irai
            // 
            this.txt_irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_irai.Location = new System.Drawing.Point(372, 387);
            this.txt_irai.Name = "txt_irai";
            this.txt_irai.Size = new System.Drawing.Size(593, 24);
            this.txt_irai.TabIndex = 40;
            // 
            // cb_irai
            // 
            this.cb_irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_irai.FormattingEnabled = true;
            this.cb_irai.Location = new System.Drawing.Point(760, 165);
            this.cb_irai.Name = "cb_irai";
            this.cb_irai.Size = new System.Drawing.Size(204, 208);
            this.cb_irai.TabIndex = 39;
            // 
            // cb_data
            // 
            this.cb_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_data.FormattingEnabled = true;
            this.cb_data.Location = new System.Drawing.Point(20, 161);
            this.cb_data.Name = "cb_data";
            this.cb_data.Size = new System.Drawing.Size(191, 242);
            this.cb_data.TabIndex = 38;
            // 
            // txt_para
            // 
            this.txt_para.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_para.Location = new System.Drawing.Point(449, 32);
            this.txt_para.Name = "txt_para";
            this.txt_para.Size = new System.Drawing.Size(91, 26);
            this.txt_para.TabIndex = 43;
            this.dataType_tips.SetToolTip(this.txt_para, "Location of the data. E.g: 3.0");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "Data Type : ";
            // 
            // cb_dtype
            // 
            this.cb_dtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dtype.FormattingEnabled = true;
            this.cb_dtype.Items.AddRange(new object[] {
            "DBX",
            "DBB",
            "DBW",
            "DBD"});
            this.cb_dtype.Location = new System.Drawing.Point(328, 30);
            this.cb_dtype.Name = "cb_dtype";
            this.cb_dtype.Size = new System.Drawing.Size(101, 28);
            this.cb_dtype.TabIndex = 44;
            this.dataType_tips.SetToolTip(this.cb_dtype, "Data Type is the size (in bits) of the variable, bit is \"DBX\", \r\nbyte \"DBB\", word" +
        " \"DBW\", doubleword \"DBD\". ");
            // 
            // Tag_tips4
            // 
            this.Tag_tips4.Popup += new System.Windows.Forms.PopupEventHandler(this.tag_tips4_Popup);
            // 
            // ProfiNet_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 689);
            this.Controls.Add(this.cb_dtype);
            this.Controls.Add(this.txt_para);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.txt_irai);
            this.Controls.Add(this.cb_irai);
            this.Controls.Add(this.cb_data);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.delete_Tag);
            this.Controls.Add(this.btn_mapIRAI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_match);
            this.Controls.Add(this.Tag_tips);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_dblock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_connect2);
            this.Name = "ProfiNet_page";
            this.Text = "ProfiNet";
            this.Controls.SetChildIndex(this.btn_connect2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt_dblock, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.Tag_tips, 0);
            this.Controls.SetChildIndex(this.btn_match, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btn_mapIRAI, 0);
            this.Controls.SetChildIndex(this.delete_Tag, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.cb_data, 0);
            this.Controls.SetChildIndex(this.cb_irai, 0);
            this.Controls.SetChildIndex(this.txt_irai, 0);
            this.Controls.SetChildIndex(this.propertyGrid1, 0);
            this.Controls.SetChildIndex(this.btn_save, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt_para, 0);
            this.Controls.SetChildIndex(this.cb_dtype, 0);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delete_Tag;
        private System.Windows.Forms.Button btn_mapIRAI;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_match;
        private System.Windows.Forms.TextBox Tag_tips;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_dblock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.CheckedListBox cb_mongo;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TextBox txt_irai;
        private System.Windows.Forms.CheckedListBox cb_irai;
        private System.Windows.Forms.CheckedListBox cb_data;
        private System.Windows.Forms.TextBox txt_para;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_dtype;
        private System.Windows.Forms.ToolTip dataBlock_tips;
        private System.Windows.Forms.ToolTip Tag_tips4;
        private System.Windows.Forms.ToolTip dataType_tips;
    }
}