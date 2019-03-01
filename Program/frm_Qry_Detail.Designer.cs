namespace YTB
{
    partial class frm_Qry_Detail
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
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRst = new System.Windows.Forms.DataGridView();
            this.radioButton_Other = new System.Windows.Forms.RadioButton();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.button_Qry = new System.Windows.Forms.Button();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Prod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Firm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_POS = new System.Windows.Forms.ComboBox();
            this.radioButton_SysId = new System.Windows.Forms.RadioButton();
            this.textBox_SysId = new System.Windows.Forms.TextBox();
            this.comboBox_User = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_temp = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1001, 38);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(92, 40);
            this.button_Exit.TabIndex = 30;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRst);
            this.groupBox2.Location = new System.Drawing.Point(13, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1031, 363);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果：";
            // 
            // dataGridViewRst
            // 
            this.dataGridViewRst.AllowUserToOrderColumns = true;
            this.dataGridViewRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRst.Location = new System.Drawing.Point(10, 20);
            this.dataGridViewRst.Name = "dataGridViewRst";
            this.dataGridViewRst.ReadOnly = true;
            this.dataGridViewRst.RowTemplate.Height = 23;
            this.dataGridViewRst.Size = new System.Drawing.Size(1015, 334);
            this.dataGridViewRst.TabIndex = 35;
            // 
            // radioButton_Other
            // 
            this.radioButton_Other.AutoSize = true;
            this.radioButton_Other.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButton_Other.Location = new System.Drawing.Point(239, 42);
            this.radioButton_Other.Name = "radioButton_Other";
            this.radioButton_Other.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Other.TabIndex = 58;
            this.radioButton_Other.TabStop = true;
            this.radioButton_Other.Text = "其它";
            this.radioButton_Other.UseVisualStyleBackColor = true;
            this.radioButton_Other.CheckedChanged += new System.EventHandler(this.radioButton_Other_CheckedChanged);
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(889, 38);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 56;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(772, 15);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 57;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 9F);
            this.dateTimePicker_End.Location = new System.Drawing.Point(534, 13);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker_End.TabIndex = 70;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 9F);
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(356, 15);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker_Bgn.TabIndex = 71;
            // 
            // comboBox_Prod
            // 
            this.comboBox_Prod.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBox_Prod.FormattingEnabled = true;
            this.comboBox_Prod.Location = new System.Drawing.Point(568, 64);
            this.comboBox_Prod.Name = "comboBox_Prod";
            this.comboBox_Prod.Size = new System.Drawing.Size(111, 20);
            this.comboBox_Prod.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(515, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "－";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(536, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 65;
            this.label3.Text = "商品：";
            // 
            // comboBox_Firm
            // 
            this.comboBox_Firm.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBox_Firm.FormattingEnabled = true;
            this.comboBox_Firm.Location = new System.Drawing.Point(328, 40);
            this.comboBox_Firm.Name = "comboBox_Firm";
            this.comboBox_Firm.Size = new System.Drawing.Size(154, 20);
            this.comboBox_Firm.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(292, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "交易日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(292, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 67;
            this.label1.Text = "卖方：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_POS);
            this.groupBox1.Controls.Add(this.radioButton_SysId);
            this.groupBox1.Controls.Add(this.textBox_SysId);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBox1.Controls.Add(this.comboBox_User);
            this.groupBox1.Controls.Add(this.comboBox_Prod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Firm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton_Other);
            this.groupBox1.Location = new System.Drawing.Point(19, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 93);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请设置查询条件";
            // 
            // comboBox_POS
            // 
            this.comboBox_POS.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBox_POS.FormattingEnabled = true;
            this.comboBox_POS.Location = new System.Drawing.Point(354, 64);
            this.comboBox_POS.Name = "comboBox_POS";
            this.comboBox_POS.Size = new System.Drawing.Size(172, 20);
            this.comboBox_POS.TabIndex = 78;
            // 
            // radioButton_SysId
            // 
            this.radioButton_SysId.AutoSize = true;
            this.radioButton_SysId.Font = new System.Drawing.Font("宋体", 9F);
            this.radioButton_SysId.Location = new System.Drawing.Point(24, 30);
            this.radioButton_SysId.Name = "radioButton_SysId";
            this.radioButton_SysId.Size = new System.Drawing.Size(71, 16);
            this.radioButton_SysId.TabIndex = 73;
            this.radioButton_SysId.TabStop = true;
            this.radioButton_SysId.Text = "交易单号";
            this.radioButton_SysId.UseVisualStyleBackColor = true;
            this.radioButton_SysId.CheckedChanged += new System.EventHandler(this.radioButton_SysId_CheckedChanged);
            // 
            // textBox_SysId
            // 
            this.textBox_SysId.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_SysId.Location = new System.Drawing.Point(41, 53);
            this.textBox_SysId.Name = "textBox_SysId";
            this.textBox_SysId.Size = new System.Drawing.Size(152, 21);
            this.textBox_SysId.TabIndex = 72;
            // 
            // comboBox_User
            // 
            this.comboBox_User.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBox_User.FormattingEnabled = true;
            this.comboBox_User.Location = new System.Drawing.Point(530, 42);
            this.comboBox_User.Name = "comboBox_User";
            this.comboBox_User.Size = new System.Drawing.Size(178, 20);
            this.comboBox_User.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(498, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "买方：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(292, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 67;
            this.label5.Text = "收银终端：";
            // 
            // button_temp
            // 
            this.button_temp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_temp.Location = new System.Drawing.Point(772, 61);
            this.button_temp.Name = "button_temp";
            this.button_temp.Size = new System.Drawing.Size(92, 40);
            this.button_temp.TabIndex = 57;
            this.button_temp.Text = "查询旧卡交易(&Q)";
            this.button_temp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_temp.UseVisualStyleBackColor = true;
            this.button_temp.Click += new System.EventHandler(this.button_temp_Click);
            // 
            // frm_Qry_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1131, 479);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_temp);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.button_Rpt);
            this.Name = "frm_Qry_Detail";
            this.Text = "销售明细查询";
            this.Load += new System.EventHandler(this.frm_Qry_Detail_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewRst;
        private System.Windows.Forms.RadioButton radioButton_Other;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
        private System.Windows.Forms.ComboBox comboBox_Prod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Firm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_SysId;
        private System.Windows.Forms.TextBox textBox_SysId;
        private System.Windows.Forms.ComboBox comboBox_POS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_User;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_temp;
    }
}