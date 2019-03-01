namespace YTB
{
    partial class frm_Rpt_Add
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
            this.dataGridViewRst = new System.Windows.Forms.DataGridView();
            this.button_Qry = new System.Windows.Forms.Button();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_buyer = new System.Windows.Forms.TextBox();
            this.comboBox_Buyer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.comboBox_POS = new System.Windows.Forms.ComboBox();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1280, 65);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(92, 40);
            this.button_Exit.TabIndex = 79;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRst
            // 
            this.dataGridViewRst.AllowUserToOrderColumns = true;
            this.dataGridViewRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRst.Location = new System.Drawing.Point(10, 20);
            this.dataGridViewRst.Name = "dataGridViewRst";
            this.dataGridViewRst.ReadOnly = true;
            this.dataGridViewRst.RowTemplate.Height = 23;
            this.dataGridViewRst.Size = new System.Drawing.Size(1374, 403);
            this.dataGridViewRst.TabIndex = 35;
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(1057, 65);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 82;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(1168, 65);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 81;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRst);
            this.groupBox2.Location = new System.Drawing.Point(23, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1390, 441);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果：";
            // 
            // textBox_buyer
            // 
            this.textBox_buyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_buyer.Location = new System.Drawing.Point(764, 28);
            this.textBox_buyer.MaxLength = 16;
            this.textBox_buyer.Name = "textBox_buyer";
            this.textBox_buyer.Size = new System.Drawing.Size(94, 26);
            this.textBox_buyer.TabIndex = 89;
            this.textBox_buyer.Text = "6688668866886688";
            this.textBox_buyer.TextChanged += new System.EventHandler(this.textBox_buyer_TextChanged);
            // 
            // comboBox_Buyer
            // 
            this.comboBox_Buyer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Buyer.FormattingEnabled = true;
            this.comboBox_Buyer.Location = new System.Drawing.Point(720, 58);
            this.comboBox_Buyer.Name = "comboBox_Buyer";
            this.comboBox_Buyer.Size = new System.Drawing.Size(276, 24);
            this.comboBox_Buyer.TabIndex = 68;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(717, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 65;
            this.label6.Text = "买方：";
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
            this.label5.Location = new System.Drawing.Point(508, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 67;
            this.label5.Text = "收银员：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBox1.Controls.Add(this.textBox_buyer);
            this.groupBox1.Controls.Add(this.comboBox_POS);
            this.groupBox1.Controls.Add(this.comboBox_Buyer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_Type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 102);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请设置查询条件";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_End.Location = new System.Drawing.Point(129, 59);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_End.TabIndex = 90;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(129, 24);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(208, 26);
            this.dateTimePicker_Bgn.TabIndex = 91;
            // 
            // comboBox_POS
            // 
            this.comboBox_POS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_POS.FormattingEnabled = true;
            this.comboBox_POS.Location = new System.Drawing.Point(511, 59);
            this.comboBox_POS.Name = "comboBox_POS";
            this.comboBox_POS.Size = new System.Drawing.Size(180, 24);
            this.comboBox_POS.TabIndex = 78;
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(363, 59);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(117, 24);
            this.comboBox_Type.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(361, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 67;
            this.label1.Text = "充值类型：";
            // 
            // frm_Rpt_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1446, 641);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.button_Rpt);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_Rpt_Add";
            this.Text = "充值报表";
            this.Load += new System.EventHandler(this.frm_Rpt_Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.DataGridView dataGridViewRst;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_buyer;
        private System.Windows.Forms.ComboBox comboBox_Buyer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_POS;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
    }
}