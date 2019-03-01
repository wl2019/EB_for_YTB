namespace YTB
{
    partial class frm_Card_QryVal
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label_OldBalance;
            System.Windows.Forms.Label label_CardID;
            System.Windows.Forms.Label label_Topic;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.groupBox_CheckCard = new System.Windows.Forms.GroupBox();
            this.textBox_OldBalance = new System.Windows.Forms.TextBox();
            this.textBox_UnFinishBalance = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_CardID = new System.Windows.Forms.TextBox();
            this.textBox_FinishBalance = new System.Windows.Forms.TextBox();
            this.button_CheckCard = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            label8 = new System.Windows.Forms.Label();
            label_OldBalance = new System.Windows.Forms.Label();
            label_CardID = new System.Windows.Forms.Label();
            label_Topic = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.groupBox_CheckCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("宋体", 12F);
            label8.Location = new System.Drawing.Point(446, 102);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(24, 16);
            label8.TabIndex = 5;
            label8.Text = "元";
            // 
            // label_OldBalance
            // 
            label_OldBalance.AutoSize = true;
            label_OldBalance.Font = new System.Drawing.Font("宋体", 12F);
            label_OldBalance.Location = new System.Drawing.Point(98, 102);
            label_OldBalance.Name = "label_OldBalance";
            label_OldBalance.Size = new System.Drawing.Size(72, 16);
            label_OldBalance.TabIndex = 3;
            label_OldBalance.Text = "可取金额";
            // 
            // label_CardID
            // 
            label_CardID.AutoSize = true;
            label_CardID.Font = new System.Drawing.Font("宋体", 12F);
            label_CardID.Location = new System.Drawing.Point(98, 71);
            label_CardID.Name = "label_CardID";
            label_CardID.Size = new System.Drawing.Size(72, 16);
            label_CardID.TabIndex = 1;
            label_CardID.Text = "卡片号码";
            // 
            // label_Topic
            // 
            label_Topic.AutoSize = true;
            label_Topic.Font = new System.Drawing.Font("宋体", 12F);
            label_Topic.Location = new System.Drawing.Point(44, 33);
            label_Topic.Name = "label_Topic";
            label_Topic.Size = new System.Drawing.Size(424, 16);
            label_Topic.TabIndex = 0;
            label_Topic.Text = "操作提示：请把卡片放到读写器上，然后按“验卡”按钮。";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("宋体", 12F);
            label1.Location = new System.Drawing.Point(446, 134);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 16);
            label1.TabIndex = 10;
            label1.Text = "元";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("宋体", 12F);
            label2.Location = new System.Drawing.Point(98, 134);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 16);
            label2.TabIndex = 8;
            label2.Text = "未结余额";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("宋体", 12F);
            label3.Location = new System.Drawing.Point(446, 167);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 16);
            label3.TabIndex = 13;
            label3.Text = "元";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("宋体", 12F);
            label4.Location = new System.Drawing.Point(98, 166);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(72, 16);
            label4.TabIndex = 11;
            label4.Text = "合计余额";
            // 
            // groupBox_CheckCard
            // 
            this.groupBox_CheckCard.Controls.Add(this.textBox_OldBalance);
            this.groupBox_CheckCard.Controls.Add(label3);
            this.groupBox_CheckCard.Controls.Add(label4);
            this.groupBox_CheckCard.Controls.Add(this.textBox_UnFinishBalance);
            this.groupBox_CheckCard.Controls.Add(label1);
            this.groupBox_CheckCard.Controls.Add(label2);
            this.groupBox_CheckCard.Controls.Add(this.checkBox1);
            this.groupBox_CheckCard.Controls.Add(this.textBox_CardID);
            this.groupBox_CheckCard.Controls.Add(this.textBox_FinishBalance);
            this.groupBox_CheckCard.Controls.Add(label8);
            this.groupBox_CheckCard.Controls.Add(label_OldBalance);
            this.groupBox_CheckCard.Controls.Add(this.button_CheckCard);
            this.groupBox_CheckCard.Controls.Add(label_CardID);
            this.groupBox_CheckCard.Controls.Add(label_Topic);
            this.groupBox_CheckCard.Location = new System.Drawing.Point(23, 24);
            this.groupBox_CheckCard.Name = "groupBox_CheckCard";
            this.groupBox_CheckCard.Size = new System.Drawing.Size(704, 226);
            this.groupBox_CheckCard.TabIndex = 50;
            this.groupBox_CheckCard.TabStop = false;
            // 
            // textBox_OldBalance
            // 
            this.textBox_OldBalance.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_OldBalance.Location = new System.Drawing.Point(176, 161);
            this.textBox_OldBalance.MaxLength = 20;
            this.textBox_OldBalance.Name = "textBox_OldBalance";
            this.textBox_OldBalance.ReadOnly = true;
            this.textBox_OldBalance.Size = new System.Drawing.Size(264, 26);
            this.textBox_OldBalance.TabIndex = 12;
            // 
            // textBox_UnFinishBalance
            // 
            this.textBox_UnFinishBalance.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_UnFinishBalance.Location = new System.Drawing.Point(176, 130);
            this.textBox_UnFinishBalance.MaxLength = 20;
            this.textBox_UnFinishBalance.Name = "textBox_UnFinishBalance";
            this.textBox_UnFinishBalance.ReadOnly = true;
            this.textBox_UnFinishBalance.Size = new System.Drawing.Size(264, 26);
            this.textBox_UnFinishBalance.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox1.Location = new System.Drawing.Point(176, 197);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 20);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "打印结果";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox_CardID
            // 
            this.textBox_CardID.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_CardID.Location = new System.Drawing.Point(177, 68);
            this.textBox_CardID.MaxLength = 20;
            this.textBox_CardID.Name = "textBox_CardID";
            this.textBox_CardID.Size = new System.Drawing.Size(264, 26);
            this.textBox_CardID.TabIndex = 2;
            // 
            // textBox_FinishBalance
            // 
            this.textBox_FinishBalance.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_FinishBalance.Location = new System.Drawing.Point(176, 99);
            this.textBox_FinishBalance.MaxLength = 20;
            this.textBox_FinishBalance.Name = "textBox_FinishBalance";
            this.textBox_FinishBalance.ReadOnly = true;
            this.textBox_FinishBalance.Size = new System.Drawing.Size(264, 26);
            this.textBox_FinishBalance.TabIndex = 4;
            // 
            // button_CheckCard
            // 
            this.button_CheckCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CheckCard.Location = new System.Drawing.Point(538, 107);
            this.button_CheckCard.Name = "button_CheckCard";
            this.button_CheckCard.Size = new System.Drawing.Size(104, 40);
            this.button_CheckCard.TabIndex = 6;
            this.button_CheckCard.Text = "验卡(&C)";
            this.button_CheckCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_CheckCard.UseVisualStyleBackColor = true;
            this.button_CheckCard.Click += new System.EventHandler(this.button_CheckCard_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(324, 265);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(104, 40);
            this.button_Exit.TabIndex = 56;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // frm_Card_QryVal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(752, 319);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox_CheckCard);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Card_QryVal";
            this.Text = "frm_Card_QryVal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Card_QryVal_FormClosing);
            this.Load += new System.EventHandler(this.frm_Card_QryVal_Load);
            this.groupBox_CheckCard.ResumeLayout(false);
            this.groupBox_CheckCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_CheckCard;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_CardID;
        private System.Windows.Forms.TextBox textBox_FinishBalance;
        private System.Windows.Forms.Button button_CheckCard;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_OldBalance;
        private System.Windows.Forms.TextBox textBox_UnFinishBalance;
    }
}