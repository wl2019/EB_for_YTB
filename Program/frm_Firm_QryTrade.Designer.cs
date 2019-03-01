namespace YTB
{
    partial class frm_Firm_QryTrade
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
            System.Windows.Forms.Label label_CardID;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox_1 = new System.Windows.Forms.GroupBox();
            this.textBox_CardID = new System.Windows.Forms.TextBox();
            this.button_CheckCard = new System.Windows.Forms.Button();
            this.groupBox_2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button_Find = new System.Windows.Forms.Button();
            this.groupBox_3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AfterBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Retry = new System.Windows.Forms.Button();
            this.button_Print = new System.Windows.Forms.Button();
            label_CardID = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox_1.SuspendLayout();
            this.groupBox_2.SuspendLayout();
            this.groupBox_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_CardID
            // 
            label_CardID.AutoSize = true;
            label_CardID.Location = new System.Drawing.Point(108, 33);
            label_CardID.Name = "label_CardID";
            label_CardID.Size = new System.Drawing.Size(53, 12);
            label_CardID.TabIndex = 0;
            label_CardID.Text = "卡片号码";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(108, 33);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 12);
            label3.TabIndex = 0;
            label3.Text = "时间范围";
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(720, 558);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(104, 28);
            this.button_Exit.TabIndex = 5;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // groupBox_1
            // 
            this.groupBox_1.Controls.Add(this.textBox_CardID);
            this.groupBox_1.Controls.Add(this.button_CheckCard);
            this.groupBox_1.Controls.Add(label_CardID);
            this.groupBox_1.Location = new System.Drawing.Point(26, 22);
            this.groupBox_1.Name = "groupBox_1";
            this.groupBox_1.Size = new System.Drawing.Size(799, 68);
            this.groupBox_1.TabIndex = 0;
            this.groupBox_1.TabStop = false;
            this.groupBox_1.Text = "第一步：验证卡片：请把卡片放到读写器上，然后按“验卡”按钮。";
            // 
            // textBox_CardID
            // 
            this.textBox_CardID.Location = new System.Drawing.Point(177, 29);
            this.textBox_CardID.MaxLength = 20;
            this.textBox_CardID.Name = "textBox_CardID";
            this.textBox_CardID.Size = new System.Drawing.Size(360, 21);
            this.textBox_CardID.TabIndex = 1;
            // 
            // button_CheckCard
            // 
            this.button_CheckCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CheckCard.Location = new System.Drawing.Point(642, 24);
            this.button_CheckCard.Name = "button_CheckCard";
            this.button_CheckCard.Size = new System.Drawing.Size(104, 28);
            this.button_CheckCard.TabIndex = 2;
            this.button_CheckCard.Text = "验卡(&C)";
            this.button_CheckCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_CheckCard.UseVisualStyleBackColor = true;
            this.button_CheckCard.Click += new System.EventHandler(this.button_CheckCard_Click);
            // 
            // groupBox_2
            // 
            this.groupBox_2.Controls.Add(this.label2);
            this.groupBox_2.Controls.Add(this.dateTimePicker2);
            this.groupBox_2.Controls.Add(this.dateTimePicker1);
            this.groupBox_2.Controls.Add(this.button_Find);
            this.groupBox_2.Controls.Add(label3);
            this.groupBox_2.Location = new System.Drawing.Point(26, 105);
            this.groupBox_2.Name = "groupBox_2";
            this.groupBox_2.Size = new System.Drawing.Size(799, 68);
            this.groupBox_2.TabIndex = 1;
            this.groupBox_2.TabStop = false;
            this.groupBox_2.Text = "第二步：选择查询的时间范围";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(382, 27);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(156, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(177, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // button_Find
            // 
            this.button_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Find.Location = new System.Drawing.Point(642, 23);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(104, 28);
            this.button_Find.TabIndex = 4;
            this.button_Find.Text = "查询(&F)";
            this.button_Find.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // groupBox_3
            // 
            this.groupBox_3.Controls.Add(this.dataGridView1);
            this.groupBox_3.Location = new System.Drawing.Point(26, 188);
            this.groupBox_3.Name = "groupBox_3";
            this.groupBox_3.Size = new System.Drawing.Size(799, 358);
            this.groupBox_3.TabIndex = 2;
            this.groupBox_3.TabStop = false;
            this.groupBox_3.Text = "第三步：查询结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Cornsilk;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardID,
            this.OperTime,
            this.OperType,
            this.Value,
            this.AfterBalance});
            this.dataGridView1.Location = new System.Drawing.Point(12, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 5;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // CardID
            // 
            this.CardID.HeaderText = "卡片号码";
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.Width = 200;
            // 
            // OperTime
            // 
            this.OperTime.HeaderText = "操作时间";
            this.OperTime.Name = "OperTime";
            this.OperTime.ReadOnly = true;
            this.OperTime.Width = 180;
            // 
            // OperType
            // 
            this.OperType.HeaderText = "操作类型";
            this.OperType.Name = "OperType";
            this.OperType.ReadOnly = true;
            this.OperType.Width = 120;
            // 
            // Value
            // 
            this.Value.HeaderText = "变化金额";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 120;
            // 
            // AfterBalance
            // 
            this.AfterBalance.HeaderText = "卡片余额";
            this.AfterBalance.Name = "AfterBalance";
            this.AfterBalance.ReadOnly = true;
            this.AfterBalance.Width = 130;
            // 
            // button_Retry
            // 
            this.button_Retry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Retry.Location = new System.Drawing.Point(26, 558);
            this.button_Retry.Name = "button_Retry";
            this.button_Retry.Size = new System.Drawing.Size(104, 28);
            this.button_Retry.TabIndex = 3;
            this.button_Retry.Text = "重来(&N)";
            this.button_Retry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Retry.UseVisualStyleBackColor = true;
            this.button_Retry.Click += new System.EventHandler(this.button_Retry_Click);
            // 
            // button_Print
            // 
            this.button_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Print.Location = new System.Drawing.Point(373, 558);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(104, 28);
            this.button_Print.TabIndex = 4;
            this.button_Print.Text = "打印(&P)";
            this.button_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // frm_Firm_QryTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(854, 604);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.button_Retry);
            this.Controls.Add(this.groupBox_3);
            this.Controls.Add(this.groupBox_2);
            this.Controls.Add(this.groupBox_1);
            this.Controls.Add(this.button_Exit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Firm_QryTrade";
            this.Text = "交易情况查询功能";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Firm_QryTrade_FormClosing);
            this.Load += new System.EventHandler(this.frm_Firm_QryTrade_Load);
            this.groupBox_1.ResumeLayout(false);
            this.groupBox_1.PerformLayout();
            this.groupBox_2.ResumeLayout(false);
            this.groupBox_2.PerformLayout();
            this.groupBox_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBox_1;
        private System.Windows.Forms.TextBox textBox_CardID;
        private System.Windows.Forms.Button button_CheckCard;
        private System.Windows.Forms.GroupBox groupBox_2;
        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox_3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Retry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn AfterBalance;
        private System.Windows.Forms.Button button_Print;
    }
}