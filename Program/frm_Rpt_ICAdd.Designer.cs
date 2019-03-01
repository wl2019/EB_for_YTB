namespace YTB
{
    partial class frm_Rpt_ICAdd
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
            this.comboBox_POS = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_buyer = new System.Windows.Forms.RadioButton();
            this.radioButton_seller = new System.Windows.Forms.RadioButton();
            this.textBox_buyer = new System.Windows.Forms.TextBox();
            this.comboBox_Buyer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_dpt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Qry = new System.Windows.Forms.Button();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.dataGridViewRst = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.radioButton_all = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_POS
            // 
            this.comboBox_POS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_POS.FormattingEnabled = true;
            this.comboBox_POS.Location = new System.Drawing.Point(444, 57);
            this.comboBox_POS.Name = "comboBox_POS";
            this.comboBox_POS.Size = new System.Drawing.Size(156, 24);
            this.comboBox_POS.TabIndex = 78;
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_End.Location = new System.Drawing.Point(129, 59);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_End.TabIndex = 70;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(129, 24);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_Bgn.TabIndex = 71;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(99, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "至";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_all);
            this.groupBox1.Controls.Add(this.radioButton_buyer);
            this.groupBox1.Controls.Add(this.radioButton_seller);
            this.groupBox1.Controls.Add(this.textBox_buyer);
            this.groupBox1.Controls.Add(this.comboBox_Buyer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox_dpt);
            this.groupBox1.Controls.Add(this.comboBox_POS);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(22, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 102);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请设置查询条件";
            // 
            // radioButton_buyer
            // 
            this.radioButton_buyer.AutoSize = true;
            this.radioButton_buyer.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton_buyer.Location = new System.Drawing.Point(799, 29);
            this.radioButton_buyer.Name = "radioButton_buyer";
            this.radioButton_buyer.Size = new System.Drawing.Size(90, 20);
            this.radioButton_buyer.TabIndex = 97;
            this.radioButton_buyer.Text = "指定买方";
            this.radioButton_buyer.UseVisualStyleBackColor = true;
            this.radioButton_buyer.CheckedChanged += new System.EventHandler(this.radioButton_buyer_CheckedChanged);
            this.radioButton_buyer.Click += new System.EventHandler(this.radioButton_buyer_Click);
            // 
            // radioButton_seller
            // 
            this.radioButton_seller.AutoSize = true;
            this.radioButton_seller.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton_seller.Location = new System.Drawing.Point(705, 29);
            this.radioButton_seller.Name = "radioButton_seller";
            this.radioButton_seller.Size = new System.Drawing.Size(90, 20);
            this.radioButton_seller.TabIndex = 96;
            this.radioButton_seller.Text = "指定卖方";
            this.radioButton_seller.UseVisualStyleBackColor = true;
            this.radioButton_seller.CheckedChanged += new System.EventHandler(this.radioButton_seller_CheckedChanged);
            this.radioButton_seller.Click += new System.EventHandler(this.radioButton_seller_Click);
            // 
            // textBox_buyer
            // 
            this.textBox_buyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_buyer.Location = new System.Drawing.Point(892, 26);
            this.textBox_buyer.MaxLength = 16;
            this.textBox_buyer.Name = "textBox_buyer";
            this.textBox_buyer.Size = new System.Drawing.Size(94, 26);
            this.textBox_buyer.TabIndex = 95;
            this.textBox_buyer.Text = "6688668866886688";
            this.textBox_buyer.TextChanged += new System.EventHandler(this.textBox_buyer_TextChanged);
            // 
            // comboBox_Buyer
            // 
            this.comboBox_Buyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Buyer.FormattingEnabled = true;
            this.comboBox_Buyer.Location = new System.Drawing.Point(705, 57);
            this.comboBox_Buyer.Name = "comboBox_Buyer";
            this.comboBox_Buyer.Size = new System.Drawing.Size(281, 24);
            this.comboBox_Buyer.TabIndex = 94;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(367, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 91;
            this.label7.Text = "部  门：";
            // 
            // comboBox_dpt
            // 
            this.comboBox_dpt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_dpt.FormattingEnabled = true;
            this.comboBox_dpt.Location = new System.Drawing.Point(444, 26);
            this.comboBox_dpt.Name = "comboBox_dpt";
            this.comboBox_dpt.Size = new System.Drawing.Size(156, 24);
            this.comboBox_dpt.TabIndex = 90;
            this.comboBox_dpt.SelectedIndexChanged += new System.EventHandler(this.comboBox_dpt_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 66;
            this.label2.Text = "操作日期：从";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(366, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "收银员：";
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(1063, 52);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 77;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(1186, 52);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 75;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // dataGridViewRst
            // 
            this.dataGridViewRst.AllowUserToOrderColumns = true;
            this.dataGridViewRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRst.Location = new System.Drawing.Point(14, 20);
            this.dataGridViewRst.Name = "dataGridViewRst";
            this.dataGridViewRst.ReadOnly = true;
            this.dataGridViewRst.RowTemplate.Height = 23;
            this.dataGridViewRst.Size = new System.Drawing.Size(1424, 403);
            this.dataGridViewRst.TabIndex = 35;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRst);
            this.groupBox2.Location = new System.Drawing.Point(22, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1444, 441);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果：";
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1309, 52);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(92, 40);
            this.button_Exit.TabIndex = 73;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // radioButton_all
            // 
            this.radioButton_all.AutoSize = true;
            this.radioButton_all.Checked = true;
            this.radioButton_all.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton_all.Location = new System.Drawing.Point(625, 29);
            this.radioButton_all.Name = "radioButton_all";
            this.radioButton_all.Size = new System.Drawing.Size(74, 20);
            this.radioButton_all.TabIndex = 98;
            this.radioButton_all.Text = "所有卡";
            this.radioButton_all.UseVisualStyleBackColor = true;
            this.radioButton_all.CheckedChanged += new System.EventHandler(this.radioButton_all_CheckedChanged);
            // 
            // frm_Rpt_ICAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1495, 605);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.button_Rpt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Rpt_ICAdd";
            this.Text = "开卡统计";
            this.Load += new System.EventHandler(this.frm_Rpt_IC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_POS;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.DataGridView dataGridViewRst;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_dpt;
        private System.Windows.Forms.RadioButton radioButton_buyer;
        private System.Windows.Forms.RadioButton radioButton_seller;
        private System.Windows.Forms.TextBox textBox_buyer;
        private System.Windows.Forms.ComboBox comboBox_Buyer;
        private System.Windows.Forms.RadioButton radioButton_all;
    }
}