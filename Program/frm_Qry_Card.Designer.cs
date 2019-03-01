namespace YTB
{
    partial class frm_Qry_Card
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Card = new System.Windows.Forms.TextBox();
            this.button_Card = new System.Windows.Forms.Button();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewRst = new System.Windows.Forms.DataGridView();
            this.button_Qry = new System.Windows.Forms.Button();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Card);
            this.groupBox1.Controls.Add(this.button_Card);
            this.groupBox1.Controls.Add(this.dateTimePicker_End);
            this.groupBox1.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 74);
            this.groupBox1.TabIndex = 96;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请设置查询条件";
            // 
            // textBox_Card
            // 
            this.textBox_Card.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Card.Location = new System.Drawing.Point(581, 27);
            this.textBox_Card.MaxLength = 16;
            this.textBox_Card.Name = "textBox_Card";
            this.textBox_Card.Size = new System.Drawing.Size(136, 21);
            this.textBox_Card.TabIndex = 81;
            this.textBox_Card.Text = "6688668866886688";
            // 
            // button_Card
            // 
            this.button_Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Card.Location = new System.Drawing.Point(723, 22);
            this.button_Card.Name = "button_Card";
            this.button_Card.Size = new System.Drawing.Size(43, 26);
            this.button_Card.TabIndex = 80;
            this.button_Card.Text = "读卡";
            this.button_Card.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Card.UseVisualStyleBackColor = true;
            this.button_Card.Click += new System.EventHandler(this.button_Card_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 9F);
            this.dateTimePicker_End.Location = new System.Drawing.Point(303, 29);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker_End.TabIndex = 74;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 9F);
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(110, 29);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker_Bgn.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(281, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "至";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(522, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 73;
            this.label1.Text = "请刷卡：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 73;
            this.label2.Text = "交易日期：从";
            // 
            // dataGridViewRst
            // 
            this.dataGridViewRst.AllowUserToOrderColumns = true;
            this.dataGridViewRst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRst.Location = new System.Drawing.Point(10, 17);
            this.dataGridViewRst.Name = "dataGridViewRst";
            this.dataGridViewRst.ReadOnly = true;
            this.dataGridViewRst.RowTemplate.Height = 23;
            this.dataGridViewRst.Size = new System.Drawing.Size(1190, 333);
            this.dataGridViewRst.TabIndex = 35;
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(870, 34);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 95;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(989, 34);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 94;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1108, 34);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(92, 40);
            this.button_Exit.TabIndex = 93;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRst);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1206, 357);
            this.groupBox2.TabIndex = 92;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询结果：";
            // 
            // frm_Qry_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1232, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.button_Rpt);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox2);
            this.Name = "frm_Qry_Card";
            this.Text = "刷卡查询销售明细";
            this.Load += new System.EventHandler(this.frm_Qry_Card_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRst)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Card;
        private System.Windows.Forms.Button button_Card;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewRst;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}