namespace YTB
{
    partial class frm_Setup_Run
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Topic = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Quit = new System.Windows.Forms.Button();
            this.groupBox_para = new System.Windows.Forms.GroupBox();
            this.textBox_MinusType = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_AddType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton_jin = new System.Windows.Forms.RadioButton();
            this.radioButton_kg = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTmn = new System.Windows.Forms.DataGridView();
            this.textBox_FeeChgCard = new System.Windows.Forms.TextBox();
            this.textBox_Firm_ID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_SrvUserPass = new System.Windows.Forms.Label();
            this.textBox_Card_Firm = new System.Windows.Forms.TextBox();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.label_SrvPort = new System.Windows.Forms.Label();
            this.textBox_mrkt_name = new System.Windows.Forms.TextBox();
            this.textBox_mrkt_addr = new System.Windows.Forms.TextBox();
            this.textBox_mrkt_tel = new System.Windows.Forms.TextBox();
            this.textBox_Card_YTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_mrkt_mnger = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_para.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTmn)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(43, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Topic.Location = new System.Drawing.Point(81, 26);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(488, 16);
            this.label_Topic.TabIndex = 33;
            this.label_Topic.Text = "功能说明：用于设置卡号规则、终端编码、供应商编码等运营参数。";
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(709, 16);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 6;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Save.Location = new System.Drawing.Point(773, 441);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 42;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Edit.Location = new System.Drawing.Point(687, 441);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(77, 40);
            this.button_Edit.TabIndex = 44;
            this.button_Edit.Text = "修改(&E)";
            this.button_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Quit
            // 
            this.button_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Quit.Location = new System.Drawing.Point(859, 441);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(77, 40);
            this.button_Quit.TabIndex = 45;
            this.button_Quit.Text = "还原(&U)";
            this.button_Quit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // groupBox_para
            // 
            this.groupBox_para.Controls.Add(this.textBox_MinusType);
            this.groupBox_para.Controls.Add(this.label9);
            this.groupBox_para.Controls.Add(this.textBox_AddType);
            this.groupBox_para.Controls.Add(this.label6);
            this.groupBox_para.Controls.Add(this.radioButton_jin);
            this.groupBox_para.Controls.Add(this.radioButton_kg);
            this.groupBox_para.Controls.Add(this.label1);
            this.groupBox_para.Controls.Add(this.dataGridViewTmn);
            this.groupBox_para.Controls.Add(this.textBox_FeeChgCard);
            this.groupBox_para.Controls.Add(this.textBox_Firm_ID);
            this.groupBox_para.Controls.Add(this.label8);
            this.groupBox_para.Controls.Add(this.label7);
            this.groupBox_para.Controls.Add(this.label2);
            this.groupBox_para.Controls.Add(this.label_SrvUserPass);
            this.groupBox_para.Controls.Add(this.textBox_Card_Firm);
            this.groupBox_para.Controls.Add(this.label_SrvUserName);
            this.groupBox_para.Controls.Add(this.label_SrvPort);
            this.groupBox_para.Controls.Add(this.textBox_mrkt_mnger);
            this.groupBox_para.Controls.Add(this.textBox_mrkt_name);
            this.groupBox_para.Controls.Add(this.textBox_mrkt_addr);
            this.groupBox_para.Controls.Add(this.textBox_mrkt_tel);
            this.groupBox_para.Controls.Add(this.label10);
            this.groupBox_para.Controls.Add(this.textBox_Card_YTB);
            this.groupBox_para.Controls.Add(this.label5);
            this.groupBox_para.Controls.Add(this.label4);
            this.groupBox_para.Controls.Add(this.label3);
            this.groupBox_para.Controls.Add(this.label_SrvIP);
            this.groupBox_para.Location = new System.Drawing.Point(24, 77);
            this.groupBox_para.Name = "groupBox_para";
            this.groupBox_para.Size = new System.Drawing.Size(975, 354);
            this.groupBox_para.TabIndex = 43;
            this.groupBox_para.TabStop = false;
            // 
            // textBox_MinusType
            // 
            this.textBox_MinusType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_MinusType.Location = new System.Drawing.Point(378, 220);
            this.textBox_MinusType.Multiline = true;
            this.textBox_MinusType.Name = "textBox_MinusType";
            this.textBox_MinusType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_MinusType.Size = new System.Drawing.Size(96, 128);
            this.textBox_MinusType.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(298, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "取款类型";
            // 
            // textBox_AddType
            // 
            this.textBox_AddType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_AddType.Location = new System.Drawing.Point(379, 85);
            this.textBox_AddType.Multiline = true;
            this.textBox_AddType.Name = "textBox_AddType";
            this.textBox_AddType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_AddType.Size = new System.Drawing.Size(96, 128);
            this.textBox_AddType.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(301, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "充值类型";
            // 
            // radioButton_jin
            // 
            this.radioButton_jin.AutoSize = true;
            this.radioButton_jin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_jin.Location = new System.Drawing.Point(376, 20);
            this.radioButton_jin.Name = "radioButton_jin";
            this.radioButton_jin.Size = new System.Drawing.Size(58, 20);
            this.radioButton_jin.TabIndex = 37;
            this.radioButton_jin.TabStop = true;
            this.radioButton_jin.Text = "市斤";
            this.radioButton_jin.UseVisualStyleBackColor = true;
            // 
            // radioButton_kg
            // 
            this.radioButton_kg.AutoSize = true;
            this.radioButton_kg.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton_kg.Location = new System.Drawing.Point(376, 46);
            this.radioButton_kg.Name = "radioButton_kg";
            this.radioButton_kg.Size = new System.Drawing.Size(58, 20);
            this.radioButton_kg.TabIndex = 37;
            this.radioButton_kg.TabStop = true;
            this.radioButton_kg.Text = "公斤";
            this.radioButton_kg.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(610, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "(修改状态时双击下表可添加)";
            // 
            // dataGridViewTmn
            // 
            this.dataGridViewTmn.AllowUserToOrderColumns = true;
            this.dataGridViewTmn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTmn.Location = new System.Drawing.Point(498, 44);
            this.dataGridViewTmn.Name = "dataGridViewTmn";
            this.dataGridViewTmn.ReadOnly = true;
            this.dataGridViewTmn.RowTemplate.Height = 23;
            this.dataGridViewTmn.Size = new System.Drawing.Size(460, 304);
            this.dataGridViewTmn.TabIndex = 35;
            // 
            // textBox_FeeChgCard
            // 
            this.textBox_FeeChgCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_FeeChgCard.Location = new System.Drawing.Point(100, 308);
            this.textBox_FeeChgCard.MaxLength = 20;
            this.textBox_FeeChgCard.Name = "textBox_FeeChgCard";
            this.textBox_FeeChgCard.Size = new System.Drawing.Size(48, 26);
            this.textBox_FeeChgCard.TabIndex = 4;
            // 
            // textBox_Firm_ID
            // 
            this.textBox_Firm_ID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Firm_ID.Location = new System.Drawing.Point(95, 270);
            this.textBox_Firm_ID.MaxLength = 20;
            this.textBox_Firm_ID.Name = "textBox_Firm_ID";
            this.textBox_Firm_ID.Size = new System.Drawing.Size(179, 26);
            this.textBox_Firm_ID.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(154, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "元";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "IC卡工本费";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(301, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "计重单位";
            // 
            // label_SrvUserPass
            // 
            this.label_SrvUserPass.AutoSize = true;
            this.label_SrvUserPass.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvUserPass.Location = new System.Drawing.Point(6, 273);
            this.label_SrvUserPass.Name = "label_SrvUserPass";
            this.label_SrvUserPass.Size = new System.Drawing.Size(88, 16);
            this.label_SrvUserPass.TabIndex = 6;
            this.label_SrvUserPass.Text = "供应商编码";
            // 
            // textBox_Card_Firm
            // 
            this.textBox_Card_Firm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Card_Firm.Location = new System.Drawing.Point(144, 232);
            this.textBox_Card_Firm.Name = "textBox_Card_Firm";
            this.textBox_Card_Firm.Size = new System.Drawing.Size(62, 26);
            this.textBox_Card_Firm.TabIndex = 2;
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvUserName.Location = new System.Drawing.Point(6, 235);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(136, 16);
            this.label_SrvUserName.TabIndex = 4;
            this.label_SrvUserName.Text = "卖方卡第一位编码";
            // 
            // label_SrvPort
            // 
            this.label_SrvPort.AutoSize = true;
            this.label_SrvPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvPort.Location = new System.Drawing.Point(484, 19);
            this.label_SrvPort.Name = "label_SrvPort";
            this.label_SrvPort.Size = new System.Drawing.Size(120, 16);
            this.label_SrvPort.TabIndex = 2;
            this.label_SrvPort.Text = "电子秤终端信息";
            // 
            // textBox_mrkt_name
            // 
            this.textBox_mrkt_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_mrkt_name.Location = new System.Drawing.Point(84, 59);
            this.textBox_mrkt_name.Name = "textBox_mrkt_name";
            this.textBox_mrkt_name.Size = new System.Drawing.Size(190, 26);
            this.textBox_mrkt_name.TabIndex = 1;
            // 
            // textBox_mrkt_addr
            // 
            this.textBox_mrkt_addr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_mrkt_addr.Location = new System.Drawing.Point(84, 97);
            this.textBox_mrkt_addr.Multiline = true;
            this.textBox_mrkt_addr.Name = "textBox_mrkt_addr";
            this.textBox_mrkt_addr.Size = new System.Drawing.Size(190, 47);
            this.textBox_mrkt_addr.TabIndex = 1;
            // 
            // textBox_mrkt_tel
            // 
            this.textBox_mrkt_tel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_mrkt_tel.Location = new System.Drawing.Point(84, 156);
            this.textBox_mrkt_tel.Name = "textBox_mrkt_tel";
            this.textBox_mrkt_tel.Size = new System.Drawing.Size(190, 26);
            this.textBox_mrkt_tel.TabIndex = 1;
            // 
            // textBox_Card_YTB
            // 
            this.textBox_Card_YTB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Card_YTB.Location = new System.Drawing.Point(144, 194);
            this.textBox_Card_YTB.Name = "textBox_Card_YTB";
            this.textBox_Card_YTB.Size = new System.Drawing.Size(62, 26);
            this.textBox_Card_YTB.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "市场名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "市场地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "联系电话";
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvIP.Location = new System.Drawing.Point(6, 197);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(136, 16);
            this.label_SrvIP.TabIndex = 0;
            this.label_SrvIP.Text = "买方卡第一位编码";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "市场管理方";
            // 
            // textBox_mrkt_mnger
            // 
            this.textBox_mrkt_mnger.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_mrkt_mnger.Location = new System.Drawing.Point(95, 24);
            this.textBox_mrkt_mnger.Name = "textBox_mrkt_mnger";
            this.textBox_mrkt_mnger.Size = new System.Drawing.Size(179, 26);
            this.textBox_mrkt_mnger.TabIndex = 1;
            // 
            // frm_Setup_Run
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1011, 492);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.groupBox_para);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Setup_Run";
            this.Text = "运营参数设置";
            this.Load += new System.EventHandler(this.frm_Setup_Run_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_para.ResumeLayout(false);
            this.groupBox_para.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTmn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.GroupBox groupBox_para;
        private System.Windows.Forms.RadioButton radioButton_jin;
        private System.Windows.Forms.RadioButton radioButton_kg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTmn;
        private System.Windows.Forms.TextBox textBox_FeeChgCard;
        private System.Windows.Forms.TextBox textBox_Firm_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_SrvUserPass;
        private System.Windows.Forms.TextBox textBox_Card_Firm;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.Label label_SrvPort;
        private System.Windows.Forms.TextBox textBox_mrkt_name;
        private System.Windows.Forms.TextBox textBox_mrkt_addr;
        private System.Windows.Forms.TextBox textBox_mrkt_tel;
        private System.Windows.Forms.TextBox textBox_Card_YTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_SrvIP;
        private System.Windows.Forms.TextBox textBox_MinusType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_AddType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_mrkt_mnger;
        private System.Windows.Forms.Label label10;
    }
}