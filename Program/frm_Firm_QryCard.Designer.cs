namespace YTB
{
    partial class frm_Firm_QryCard
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
            this.button_Qry = new System.Windows.Forms.Button();
            this.textBox_Card = new System.Windows.Forms.TextBox();
            this.textBox_CertID = new System.Windows.Forms.TextBox();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_stat = new System.Windows.Forms.TextBox();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Card = new System.Windows.Forms.Button();
            this.textBox_Person = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Firm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxOper = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxInf.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Enabled = false;
            this.button_Qry.Location = new System.Drawing.Point(503, 24);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(77, 40);
            this.button_Qry.TabIndex = 73;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // textBox_Card
            // 
            this.textBox_Card.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Card.Location = new System.Drawing.Point(153, 21);
            this.textBox_Card.MaxLength = 16;
            this.textBox_Card.Name = "textBox_Card";
            this.textBox_Card.Size = new System.Drawing.Size(152, 26);
            this.textBox_Card.TabIndex = 45;
            this.textBox_Card.Text = "6688668866886688";
            this.textBox_Card.TextChanged += new System.EventHandler(this.textBox_Card_TextChanged);
            // 
            // textBox_CertID
            // 
            this.textBox_CertID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CertID.Location = new System.Drawing.Point(85, 230);
            this.textBox_CertID.MaxLength = 18;
            this.textBox_CertID.Name = "textBox_CertID";
            this.textBox_CertID.ReadOnly = true;
            this.textBox_CertID.Size = new System.Drawing.Size(168, 26);
            this.textBox_CertID.TabIndex = 37;
            this.textBox_CertID.Text = "440103123456780123";
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cell.Location = new System.Drawing.Point(85, 195);
            this.textBox_Cell.MaxLength = 11;
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.ReadOnly = true;
            this.textBox_Cell.Size = new System.Drawing.Size(168, 26);
            this.textBox_Cell.TabIndex = 37;
            this.textBox_Cell.Text = "12345678901";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "身份证：";
            // 
            // textBox_stat
            // 
            this.textBox_stat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_stat.Location = new System.Drawing.Point(83, 94);
            this.textBox_stat.MaxLength = 6;
            this.textBox_stat.Name = "textBox_stat";
            this.textBox_stat.ReadOnly = true;
            this.textBox_stat.Size = new System.Drawing.Size(168, 26);
            this.textBox_stat.TabIndex = 37;
            // 
            // textBox_time
            // 
            this.textBox_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_time.Location = new System.Drawing.Point(83, 24);
            this.textBox_time.MaxLength = 6;
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.ReadOnly = true;
            this.textBox_time.Size = new System.Drawing.Size(168, 26);
            this.textBox_time.TabIndex = 37;
            this.textBox_time.Text = "2018/12/31 08:59:59";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "卡片状态：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "卡号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_Card);
            this.groupBox1.Controls.Add(this.button_Card);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 58);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请刷卡：";
            // 
            // button_Card
            // 
            this.button_Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Card.Location = new System.Drawing.Point(317, 12);
            this.button_Card.Name = "button_Card";
            this.button_Card.Size = new System.Drawing.Size(77, 40);
            this.button_Card.TabIndex = 44;
            this.button_Card.Text = "读卡(&R)";
            this.button_Card.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Card.UseVisualStyleBackColor = true;
            this.button_Card.Click += new System.EventHandler(this.button_Card_Click);
            // 
            // textBox_Person
            // 
            this.textBox_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Person.Location = new System.Drawing.Point(85, 160);
            this.textBox_Person.Name = "textBox_Person";
            this.textBox_Person.ReadOnly = true;
            this.textBox_Person.Size = new System.Drawing.Size(168, 26);
            this.textBox_Person.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "发卡时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "联系人：";
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.textBoxOper);
            this.groupBoxInf.Controls.Add(this.textBox_CertID);
            this.groupBoxInf.Controls.Add(this.label9);
            this.groupBoxInf.Controls.Add(this.textBox_Cell);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.textBox_Type);
            this.groupBoxInf.Controls.Add(this.textBox_stat);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.textBox_time);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.textBox_Firm);
            this.groupBoxInf.Controls.Add(this.textBox_Person);
            this.groupBoxInf.Controls.Add(this.label1);
            this.groupBoxInf.Controls.Add(this.label8);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label5);
            this.groupBoxInf.Location = new System.Drawing.Point(12, 82);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(258, 311);
            this.groupBoxInf.TabIndex = 71;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "卖方卡详情：";
            // 
            // textBox_Type
            // 
            this.textBox_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Type.Location = new System.Drawing.Point(83, 59);
            this.textBox_Type.MaxLength = 6;
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(168, 26);
            this.textBox_Type.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "卡片类型：";
            // 
            // textBox_Firm
            // 
            this.textBox_Firm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Firm.Location = new System.Drawing.Point(83, 128);
            this.textBox_Firm.Name = "textBox_Firm";
            this.textBox_Firm.ReadOnly = true;
            this.textBox_Firm.Size = new System.Drawing.Size(168, 26);
            this.textBox_Firm.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "卖方：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "联系电话：";
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(610, 24);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 70;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(275, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 311);
            this.groupBox2.TabIndex = 74;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其它卖方卡：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(726, 284);
            this.dataGridView1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "开卡人：";
            // 
            // textBoxOper
            // 
            this.textBoxOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOper.Location = new System.Drawing.Point(83, 263);
            this.textBoxOper.MaxLength = 18;
            this.textBoxOper.Name = "textBoxOper";
            this.textBoxOper.ReadOnly = true;
            this.textBoxOper.Size = new System.Drawing.Size(168, 26);
            this.textBoxOper.TabIndex = 37;
            // 
            // frm_Firm_QryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1038, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_Qry);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Firm_QryCard";
            this.Text = "卖方卡查询";
            this.Load += new System.EventHandler(this.frm_Firm_QryCard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.TextBox textBox_Card;
        private System.Windows.Forms.TextBox textBox_CertID;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_stat;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Card;
        private System.Windows.Forms.TextBox textBox_Person;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Firm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxOper;
        private System.Windows.Forms.Label label9;
    }
}