namespace YTB
{
    partial class frm_Rpt_Oper
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
            this.radioButton_cash = new System.Windows.Forms.RadioButton();
            this.radioButton_trade = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_dpt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Firm = new System.Windows.Forms.ComboBox();
            this.button_Qry = new System.Windows.Forms.Button();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRst = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_cash
            // 
            this.radioButton_cash.AutoSize = true;
            this.radioButton_cash.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_cash.Location = new System.Drawing.Point(472, 37);
            this.radioButton_cash.Name = "radioButton_cash";
            this.radioButton_cash.Size = new System.Drawing.Size(90, 20);
            this.radioButton_cash.TabIndex = 80;
            this.radioButton_cash.TabStop = true;
            this.radioButton_cash.Text = "财务收银";
            this.radioButton_cash.UseVisualStyleBackColor = true;
            // 
            // radioButton_trade
            // 
            this.radioButton_trade.AutoSize = true;
            this.radioButton_trade.Location = new System.Drawing.Point(472, 63);
            this.radioButton_trade.Name = "radioButton_trade";
            this.radioButton_trade.Size = new System.Drawing.Size(71, 16);
            this.radioButton_trade.TabIndex = 80;
            this.radioButton_trade.TabStop = true;
            this.radioButton_trade.Text = "磅房交易";
            this.radioButton_trade.UseVisualStyleBackColor = true;
            this.radioButton_trade.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(391, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "查询类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(609, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 78;
            this.label5.Text = "部  门：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(609, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 78;
            this.label1.Text = "收银员：";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_End.Location = new System.Drawing.Point(140, 59);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_End.TabIndex = 74;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(140, 29);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_Bgn.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(110, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "至";
            // 
            // comboBox_dpt
            // 
            this.comboBox_dpt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_dpt.FormattingEnabled = true;
            this.comboBox_dpt.Location = new System.Drawing.Point(686, 28);
            this.comboBox_dpt.Name = "comboBox_dpt";
            this.comboBox_dpt.Size = new System.Drawing.Size(134, 24);
            this.comboBox_dpt.TabIndex = 68;
            this.comboBox_dpt.SelectedIndexChanged += new System.EventHandler(this.comboBox_dpt_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 73;
            this.label2.Text = "交易日期：从";
            // 
            // comboBox_Firm
            // 
            this.comboBox_Firm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Firm.FormattingEnabled = true;
            this.comboBox_Firm.Location = new System.Drawing.Point(686, 58);
            this.comboBox_Firm.Name = "comboBox_Firm";
            this.comboBox_Firm.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Firm.TabIndex = 68;
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(902, 45);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 99;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(1028, 45);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 98;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1154, 45);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(92, 40);
            this.button_Exit.TabIndex = 97;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_cash);
            this.groupBox1.Controls.Add(this.radioButton_trade);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_dpt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_Firm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 92);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请设置查询条件";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRst);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1094, 370);
            this.groupBox2.TabIndex = 96;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果：";
            // 
            // dataGridViewRst
            // 
            this.dataGridViewRst.AllowUserToOrderColumns = true;
            this.dataGridViewRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRst.Location = new System.Drawing.Point(15, 20);
            this.dataGridViewRst.Name = "dataGridViewRst";
            this.dataGridViewRst.ReadOnly = true;
            this.dataGridViewRst.RowTemplate.Height = 23;
            this.dataGridViewRst.Size = new System.Drawing.Size(1062, 335);
            this.dataGridViewRst.TabIndex = 35;
            // 
            // frm_Rpt_Oper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1335, 498);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.button_Rpt);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frm_Rpt_Oper";
            this.Text = "收银汇总查询";
            this.Load += new System.EventHandler(this.frm_Rpt_Oper_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_cash;
        private System.Windows.Forms.RadioButton radioButton_trade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_dpt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Firm;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewRst;
    }
}