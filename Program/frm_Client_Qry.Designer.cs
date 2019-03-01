namespace YTB
{
    partial class frm_Client_Qry
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
            this.radioButton_date = new System.Windows.Forms.RadioButton();
            this.radioButton_name = new System.Windows.Forms.RadioButton();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.radioButton_cell = new System.Windows.Forms.RadioButton();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.radioButton_card = new System.Windows.Forms.RadioButton();
            this.textBox_Card = new System.Windows.Forms.TextBox();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button_Rpt = new System.Windows.Forms.Button();
            this.button_Qry = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_date);
            this.groupBox1.Controls.Add(this.radioButton_name);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.radioButton_cell);
            this.groupBox1.Controls.Add(this.textBox_Cell);
            this.groupBox1.Controls.Add(this.radioButton_card);
            this.groupBox1.Controls.Add(this.textBox_Card);
            this.groupBox1.Controls.Add(this.checkBox_All);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button_Rpt);
            this.groupBox1.Controls.Add(this.button_Qry);
            this.groupBox1.Location = new System.Drawing.Point(20, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 115);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择：";
            // 
            // radioButton_date
            // 
            this.radioButton_date.AutoSize = true;
            this.radioButton_date.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_date.Location = new System.Drawing.Point(313, 69);
            this.radioButton_date.Name = "radioButton_date";
            this.radioButton_date.Size = new System.Drawing.Size(106, 20);
            this.radioButton_date.TabIndex = 90;
            this.radioButton_date.TabStop = true;
            this.radioButton_date.Text = "开卡日期：";
            this.radioButton_date.UseVisualStyleBackColor = true;
            this.radioButton_date.CheckedChanged += new System.EventHandler(this.radioButton_date_CheckedChanged);
            // 
            // radioButton_name
            // 
            this.radioButton_name.AutoSize = true;
            this.radioButton_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_name.Location = new System.Drawing.Point(21, 69);
            this.radioButton_name.Name = "radioButton_name";
            this.radioButton_name.Size = new System.Drawing.Size(74, 20);
            this.radioButton_name.TabIndex = 90;
            this.radioButton_name.TabStop = true;
            this.radioButton_name.Text = "姓名：";
            this.radioButton_name.UseVisualStyleBackColor = true;
            this.radioButton_name.CheckedChanged += new System.EventHandler(this.radioButton_name_CheckedChanged);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(96, 66);
            this.textBox_name.MaxLength = 18;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(191, 26);
            this.textBox_name.TabIndex = 87;
            this.textBox_name.Text = "513001199012010229";
            // 
            // radioButton_cell
            // 
            this.radioButton_cell.AutoSize = true;
            this.radioButton_cell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_cell.Location = new System.Drawing.Point(313, 36);
            this.radioButton_cell.Name = "radioButton_cell";
            this.radioButton_cell.Size = new System.Drawing.Size(106, 20);
            this.radioButton_cell.TabIndex = 91;
            this.radioButton_cell.TabStop = true;
            this.radioButton_cell.Text = "手 机 号：";
            this.radioButton_cell.UseVisualStyleBackColor = true;
            this.radioButton_cell.CheckedChanged += new System.EventHandler(this.radioButton_cell_CheckedChanged);
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cell.Location = new System.Drawing.Point(429, 33);
            this.textBox_Cell.MaxLength = 15;
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.Size = new System.Drawing.Size(191, 26);
            this.textBox_Cell.TabIndex = 88;
            this.textBox_Cell.Text = "6688668866886688";
            // 
            // radioButton_card
            // 
            this.radioButton_card.AutoSize = true;
            this.radioButton_card.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_card.Location = new System.Drawing.Point(21, 33);
            this.radioButton_card.Name = "radioButton_card";
            this.radioButton_card.Size = new System.Drawing.Size(74, 20);
            this.radioButton_card.TabIndex = 92;
            this.radioButton_card.TabStop = true;
            this.radioButton_card.Text = "卡号：";
            this.radioButton_card.UseVisualStyleBackColor = true;
            this.radioButton_card.CheckedChanged += new System.EventHandler(this.radioButton_card_CheckedChanged);
            // 
            // textBox_Card
            // 
            this.textBox_Card.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Card.Location = new System.Drawing.Point(96, 30);
            this.textBox_Card.MaxLength = 16;
            this.textBox_Card.Name = "textBox_Card";
            this.textBox_Card.Size = new System.Drawing.Size(191, 26);
            this.textBox_Card.TabIndex = 89;
            this.textBox_Card.Text = "6688668866886688";
            // 
            // checkBox_All
            // 
            this.checkBox_All.AutoSize = true;
            this.checkBox_All.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox_All.Location = new System.Drawing.Point(656, 52);
            this.checkBox_All.Name = "checkBox_All";
            this.checkBox_All.Size = new System.Drawing.Size(75, 20);
            this.checkBox_All.TabIndex = 50;
            this.checkBox_All.Text = "所有卡";
            this.checkBox_All.UseVisualStyleBackColor = true;
            this.checkBox_All.CheckedChanged += new System.EventHandler(this.checkBox_All_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 12F);
            this.dateTimePicker1.Location = new System.Drawing.Point(429, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(191, 26);
            this.dateTimePicker1.TabIndex = 49;
            // 
            // button_Rpt
            // 
            this.button_Rpt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rpt.Enabled = false;
            this.button_Rpt.Location = new System.Drawing.Point(749, 65);
            this.button_Rpt.Name = "button_Rpt";
            this.button_Rpt.Size = new System.Drawing.Size(92, 40);
            this.button_Rpt.TabIndex = 30;
            this.button_Rpt.Text = "生成报表(&R)";
            this.button_Rpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Rpt.UseVisualStyleBackColor = true;
            this.button_Rpt.Click += new System.EventHandler(this.button_Rpt_Click);
            // 
            // button_Qry
            // 
            this.button_Qry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Qry.Location = new System.Drawing.Point(749, 19);
            this.button_Qry.Name = "button_Qry";
            this.button_Qry.Size = new System.Drawing.Size(92, 40);
            this.button_Qry.TabIndex = 30;
            this.button_Qry.Text = "查询(&Q)";
            this.button_Qry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Qry.UseVisualStyleBackColor = true;
            this.button_Qry.Click += new System.EventHandler(this.button_Qry_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(912, 68);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 33;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(20, 144);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(986, 409);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发卡明细：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(952, 371);
            this.dataGridView1.TabIndex = 36;
            // 
            // frm_Client_Qry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1021, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox3);
            this.Name = "frm_Client_Qry";
            this.Text = "买方开卡查询";
            this.Load += new System.EventHandler(this.frm_Client_Qry_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Rpt;
        private System.Windows.Forms.Button button_Qry;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox_All;
        private System.Windows.Forms.RadioButton radioButton_date;
        private System.Windows.Forms.RadioButton radioButton_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.RadioButton radioButton_cell;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.RadioButton radioButton_card;
        private System.Windows.Forms.TextBox textBox_Card;
    }
}