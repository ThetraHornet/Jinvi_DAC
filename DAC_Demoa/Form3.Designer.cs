namespace DAC_Demoa
{
    partial class OPCUA_page
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
            this.btn_match = new System.Windows.Forms.Button();
            this.txt_irai = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btn_mapIRAI = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.list_Nodes = new System.Windows.Forms.CheckedListBox();
            this.cb_Irai = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_match
            // 
            this.btn_match.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_match.Location = new System.Drawing.Point(762, 33);
            this.btn_match.Name = "btn_match";
            this.btn_match.Size = new System.Drawing.Size(70, 38);
            this.btn_match.TabIndex = 11;
            this.btn_match.Text = "Display";
            this.btn_match.UseVisualStyleBackColor = true;
            this.btn_match.Click += new System.EventHandler(this.btn_match_Click);
            // 
            // txt_irai
            // 
            this.txt_irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_irai.Location = new System.Drawing.Point(379, 335);
            this.txt_irai.Name = "txt_irai";
            this.txt_irai.Size = new System.Drawing.Size(593, 24);
            this.txt_irai.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(331, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "IRAI :";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(234, 68);
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
            // btn_mapIRAI
            // 
            this.btn_mapIRAI.Location = new System.Drawing.Point(234, 327);
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
            this.groupBox1.Location = new System.Drawing.Point(22, 378);
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
            // list_Nodes
            // 
            this.list_Nodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Nodes.FormattingEnabled = true;
            this.list_Nodes.Location = new System.Drawing.Point(12, 68);
            this.list_Nodes.Name = "list_Nodes";
            this.list_Nodes.Size = new System.Drawing.Size(191, 242);
            this.list_Nodes.TabIndex = 7;
            this.list_Nodes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_Nodes_ItemCheck);
            this.list_Nodes.SelectedIndexChanged += new System.EventHandler(this.list_data_SelectedIndexChanged);
            // 
            // cb_Irai
            // 
            this.cb_Irai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Irai.FormattingEnabled = true;
            this.cb_Irai.Location = new System.Drawing.Point(762, 77);
            this.cb_Irai.Name = "cb_Irai";
            this.cb_Irai.Size = new System.Drawing.Size(204, 208);
            this.cb_Irai.TabIndex = 20;
            // 
            // OPCUA_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 635);
            this.Controls.Add(this.cb_Irai);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_mapIRAI);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.txt_irai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_match);
            this.Controls.Add(this.list_Nodes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OPCUA_page";
            this.Text = "OPCUA";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += MyForm_FormClosing;
        }

        #endregion
        private System.Windows.Forms.Button btn_match;
        private System.Windows.Forms.TextBox txt_irai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btn_mapIRAI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.CheckedListBox list_Nodes;
        private System.Windows.Forms.CheckedListBox cb_Irai;
    }
}