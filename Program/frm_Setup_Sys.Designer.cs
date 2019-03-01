namespace YTB
{
    partial class frm_Setup_Sys
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
            this.button_Quit = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.label_Topic = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox_YTB = new System.Windows.Forms.GroupBox();
            this.textBox_YTB_PORT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_YTB_IP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_RDR = new System.Windows.Forms.GroupBox();
            this.comboBox_Rdr_Baud = new System.Windows.Forms.ComboBox();
            this.comboBox_Rdr2_Comm = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_Rdr_Comm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_PS = new System.Windows.Forms.GroupBox();
            this.comboBox_PS_Baud = new System.Windows.Forms.ComboBox();
            this.comboBox_PS_Comm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.textBox_SrvIP = new System.Windows.Forms.TextBox();
            this.label_SrvPort = new System.Windows.Forms.Label();
            this.textBox_SrvPort = new System.Windows.Forms.TextBox();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.textBox_SrvUserName = new System.Windows.Forms.TextBox();
            this.label_SrvUserPass = new System.Windows.Forms.Label();
            this.textBox_SrvUserPass = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_SrvDataBase = new System.Windows.Forms.TextBox();
            this.groupBox_Db = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_YTB.SuspendLayout();
            this.groupBox_RDR.SuspendLayout();
            this.groupBox_PS.SuspendLayout();
            this.groupBox_Db.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Quit
            // 
            this.button_Quit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Quit.Location = new System.Drawing.Point(404, 440);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(77, 40);
            this.button_Quit.TabIndex = 28;
            this.button_Quit.Text = "还原(&U)";
            this.button_Quit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(490, 440);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 29;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Save.Location = new System.Drawing.Point(318, 440);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 27;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Edit.Location = new System.Drawing.Point(232, 440);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(77, 40);
            this.button_Edit.TabIndex = 26;
            this.button_Edit.Text = "修改(&E)";
            this.button_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(86, 35);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(461, 12);
            this.label_Topic.TabIndex = 23;
            this.label_Topic.Text = "功能说明：用于设置数据库、益通宝平台、刷卡设备、磅秤等参数等运行环境的参数。";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(48, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox_YTB
            // 
            this.groupBox_YTB.Controls.Add(this.textBox_YTB_PORT);
            this.groupBox_YTB.Controls.Add(this.label4);
            this.groupBox_YTB.Controls.Add(this.textBox_YTB_IP);
            this.groupBox_YTB.Controls.Add(this.label5);
            this.groupBox_YTB.Location = new System.Drawing.Point(12, 202);
            this.groupBox_YTB.Name = "groupBox_YTB";
            this.groupBox_YTB.Size = new System.Drawing.Size(559, 62);
            this.groupBox_YTB.TabIndex = 31;
            this.groupBox_YTB.TabStop = false;
            this.groupBox_YTB.Text = "益通宝平台登录参数";
            // 
            // textBox_YTB_PORT
            // 
            this.textBox_YTB_PORT.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_YTB_PORT.Location = new System.Drawing.Point(358, 23);
            this.textBox_YTB_PORT.Name = "textBox_YTB_PORT";
            this.textBox_YTB_PORT.Size = new System.Drawing.Size(154, 26);
            this.textBox_YTB_PORT.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(288, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "IP 端口";
            // 
            // textBox_YTB_IP
            // 
            this.textBox_YTB_IP.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_YTB_IP.Location = new System.Drawing.Point(98, 23);
            this.textBox_YTB_IP.Name = "textBox_YTB_IP";
            this.textBox_YTB_IP.Size = new System.Drawing.Size(154, 26);
            this.textBox_YTB_IP.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP 地址";
            // 
            // groupBox_RDR
            // 
            this.groupBox_RDR.Controls.Add(this.comboBox_Rdr_Baud);
            this.groupBox_RDR.Controls.Add(this.comboBox_Rdr2_Comm);
            this.groupBox_RDR.Controls.Add(this.label8);
            this.groupBox_RDR.Controls.Add(this.comboBox_Rdr_Comm);
            this.groupBox_RDR.Controls.Add(this.label7);
            this.groupBox_RDR.Controls.Add(this.label1);
            this.groupBox_RDR.Controls.Add(this.label2);
            this.groupBox_RDR.Location = new System.Drawing.Point(12, 270);
            this.groupBox_RDR.Name = "groupBox_RDR";
            this.groupBox_RDR.Size = new System.Drawing.Size(559, 90);
            this.groupBox_RDR.TabIndex = 32;
            this.groupBox_RDR.TabStop = false;
            this.groupBox_RDR.Text = "刷卡设备参数";
            // 
            // comboBox_Rdr_Baud
            // 
            this.comboBox_Rdr_Baud.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_Rdr_Baud.FormattingEnabled = true;
            this.comboBox_Rdr_Baud.Location = new System.Drawing.Point(358, 23);
            this.comboBox_Rdr_Baud.Name = "comboBox_Rdr_Baud";
            this.comboBox_Rdr_Baud.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Rdr_Baud.TabIndex = 6;
            // 
            // comboBox_Rdr2_Comm
            // 
            this.comboBox_Rdr2_Comm.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_Rdr2_Comm.FormattingEnabled = true;
            this.comboBox_Rdr2_Comm.Location = new System.Drawing.Point(150, 53);
            this.comboBox_Rdr2_Comm.Name = "comboBox_Rdr2_Comm";
            this.comboBox_Rdr2_Comm.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Rdr2_Comm.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(16, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "市场后台连接端口";
            // 
            // comboBox_Rdr_Comm
            // 
            this.comboBox_Rdr_Comm.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_Rdr_Comm.FormattingEnabled = true;
            this.comboBox_Rdr_Comm.Location = new System.Drawing.Point(151, 23);
            this.comboBox_Rdr_Comm.Name = "comboBox_Rdr_Comm";
            this.comboBox_Rdr_Comm.Size = new System.Drawing.Size(121, 24);
            this.comboBox_Rdr_Comm.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(17, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "收银POS连接端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(288, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "通讯速率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, -77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "连接端口";
            // 
            // groupBox_PS
            // 
            this.groupBox_PS.Controls.Add(this.comboBox_PS_Baud);
            this.groupBox_PS.Controls.Add(this.comboBox_PS_Comm);
            this.groupBox_PS.Controls.Add(this.label3);
            this.groupBox_PS.Controls.Add(this.label6);
            this.groupBox_PS.Location = new System.Drawing.Point(10, 366);
            this.groupBox_PS.Name = "groupBox_PS";
            this.groupBox_PS.Size = new System.Drawing.Size(559, 62);
            this.groupBox_PS.TabIndex = 32;
            this.groupBox_PS.TabStop = false;
            this.groupBox_PS.Text = "磅秤参数";
            // 
            // comboBox_PS_Baud
            // 
            this.comboBox_PS_Baud.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_PS_Baud.FormattingEnabled = true;
            this.comboBox_PS_Baud.Location = new System.Drawing.Point(360, 20);
            this.comboBox_PS_Baud.Name = "comboBox_PS_Baud";
            this.comboBox_PS_Baud.Size = new System.Drawing.Size(121, 24);
            this.comboBox_PS_Baud.TabIndex = 8;
            // 
            // comboBox_PS_Comm
            // 
            this.comboBox_PS_Comm.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_PS_Comm.FormattingEnabled = true;
            this.comboBox_PS_Comm.Location = new System.Drawing.Point(112, 21);
            this.comboBox_PS_Comm.Name = "comboBox_PS_Comm";
            this.comboBox_PS_Comm.Size = new System.Drawing.Size(121, 24);
            this.comboBox_PS_Comm.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(288, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "通讯速率";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(19, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "连接端口";
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("宋体", 12F);
            this.label_SrvIP.Location = new System.Drawing.Point(16, 27);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(64, 16);
            this.label_SrvIP.TabIndex = 0;
            this.label_SrvIP.Text = "IP 地址";
            // 
            // textBox_SrvIP
            // 
            this.textBox_SrvIP.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_SrvIP.Location = new System.Drawing.Point(97, 23);
            this.textBox_SrvIP.Name = "textBox_SrvIP";
            this.textBox_SrvIP.Size = new System.Drawing.Size(154, 26);
            this.textBox_SrvIP.TabIndex = 1;
            // 
            // label_SrvPort
            // 
            this.label_SrvPort.AutoSize = true;
            this.label_SrvPort.Font = new System.Drawing.Font("宋体", 12F);
            this.label_SrvPort.Location = new System.Drawing.Point(288, 26);
            this.label_SrvPort.Name = "label_SrvPort";
            this.label_SrvPort.Size = new System.Drawing.Size(64, 16);
            this.label_SrvPort.TabIndex = 2;
            this.label_SrvPort.Text = "IP 端口";
            // 
            // textBox_SrvPort
            // 
            this.textBox_SrvPort.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_SrvPort.Location = new System.Drawing.Point(358, 23);
            this.textBox_SrvPort.Name = "textBox_SrvPort";
            this.textBox_SrvPort.Size = new System.Drawing.Size(154, 26);
            this.textBox_SrvPort.TabIndex = 3;
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.label_SrvUserName.Location = new System.Drawing.Point(16, 57);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(72, 16);
            this.label_SrvUserName.TabIndex = 4;
            this.label_SrvUserName.Text = "登录名称";
            // 
            // textBox_SrvUserName
            // 
            this.textBox_SrvUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_SrvUserName.Location = new System.Drawing.Point(97, 55);
            this.textBox_SrvUserName.Name = "textBox_SrvUserName";
            this.textBox_SrvUserName.Size = new System.Drawing.Size(154, 26);
            this.textBox_SrvUserName.TabIndex = 5;
            // 
            // label_SrvUserPass
            // 
            this.label_SrvUserPass.AutoSize = true;
            this.label_SrvUserPass.Font = new System.Drawing.Font("宋体", 12F);
            this.label_SrvUserPass.Location = new System.Drawing.Point(288, 59);
            this.label_SrvUserPass.Name = "label_SrvUserPass";
            this.label_SrvUserPass.Size = new System.Drawing.Size(72, 16);
            this.label_SrvUserPass.TabIndex = 6;
            this.label_SrvUserPass.Text = "登录密码";
            // 
            // textBox_SrvUserPass
            // 
            this.textBox_SrvUserPass.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_SrvUserPass.Location = new System.Drawing.Point(358, 56);
            this.textBox_SrvUserPass.MaxLength = 20;
            this.textBox_SrvUserPass.Name = "textBox_SrvUserPass";
            this.textBox_SrvUserPass.PasswordChar = '*';
            this.textBox_SrvUserPass.Size = new System.Drawing.Size(154, 26);
            this.textBox_SrvUserPass.TabIndex = 7;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("宋体", 12F);
            this.label_Database.Location = new System.Drawing.Point(16, 92);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(72, 16);
            this.label_Database.TabIndex = 8;
            this.label_Database.Text = "数据库名";
            // 
            // textBox_SrvDataBase
            // 
            this.textBox_SrvDataBase.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_SrvDataBase.Location = new System.Drawing.Point(97, 88);
            this.textBox_SrvDataBase.Name = "textBox_SrvDataBase";
            this.textBox_SrvDataBase.Size = new System.Drawing.Size(154, 26);
            this.textBox_SrvDataBase.TabIndex = 9;
            // 
            // groupBox_Db
            // 
            this.groupBox_Db.Controls.Add(this.textBox_SrvDataBase);
            this.groupBox_Db.Controls.Add(this.label_Database);
            this.groupBox_Db.Controls.Add(this.textBox_SrvUserPass);
            this.groupBox_Db.Controls.Add(this.label_SrvUserPass);
            this.groupBox_Db.Controls.Add(this.textBox_SrvUserName);
            this.groupBox_Db.Controls.Add(this.label_SrvUserName);
            this.groupBox_Db.Controls.Add(this.textBox_SrvPort);
            this.groupBox_Db.Controls.Add(this.label_SrvPort);
            this.groupBox_Db.Controls.Add(this.textBox_SrvIP);
            this.groupBox_Db.Controls.Add(this.label_SrvIP);
            this.groupBox_Db.Location = new System.Drawing.Point(14, 69);
            this.groupBox_Db.Name = "groupBox_Db";
            this.groupBox_Db.Size = new System.Drawing.Size(559, 126);
            this.groupBox_Db.TabIndex = 25;
            this.groupBox_Db.TabStop = false;
            this.groupBox_Db.Text = "数据库服务器参数";
            // 
            // frm_Setup_Sys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(591, 492);
            this.Controls.Add(this.groupBox_PS);
            this.Controls.Add(this.groupBox_RDR);
            this.Controls.Add(this.groupBox_YTB);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Edit);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_Db);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Setup_Sys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统参数设置";
            this.Load += new System.EventHandler(this.frm_Setup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_YTB.ResumeLayout(false);
            this.groupBox_YTB.PerformLayout();
            this.groupBox_RDR.ResumeLayout(false);
            this.groupBox_RDR.PerformLayout();
            this.groupBox_PS.ResumeLayout(false);
            this.groupBox_PS.PerformLayout();
            this.groupBox_Db.ResumeLayout(false);
            this.groupBox_Db.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox_YTB;
        private System.Windows.Forms.TextBox textBox_YTB_PORT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_YTB_IP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_RDR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox_PS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_Rdr_Baud;
        private System.Windows.Forms.ComboBox comboBox_Rdr_Comm;
        private System.Windows.Forms.ComboBox comboBox_PS_Baud;
        private System.Windows.Forms.ComboBox comboBox_PS_Comm;
        private System.Windows.Forms.Label label_SrvIP;
        private System.Windows.Forms.TextBox textBox_SrvIP;
        private System.Windows.Forms.Label label_SrvPort;
        private System.Windows.Forms.TextBox textBox_SrvPort;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.TextBox textBox_SrvUserName;
        private System.Windows.Forms.Label label_SrvUserPass;
        private System.Windows.Forms.TextBox textBox_SrvUserPass;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_SrvDataBase;
        private System.Windows.Forms.GroupBox groupBox_Db;
        private System.Windows.Forms.ComboBox comboBox_Rdr2_Comm;
        private System.Windows.Forms.Label label8;
    }
}