namespace YTB
{
    partial class frm_Firm_Card
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.comboBox_Stall = new System.Windows.Forms.ComboBox();
            this.label_num = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Firm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_Fee_M = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Fee_M = new System.Windows.Forms.TextBox();
            this.button_SaveFee_M = new System.Windows.Forms.Button();
            this.button_SaveM = new System.Windows.Forms.Button();
            this.comboBox_NameM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_CardV = new System.Windows.Forms.TextBox();
            this.textBox_CardM = new System.Windows.Forms.TextBox();
            this.textBox_CertIDM = new System.Windows.Forms.TextBox();
            this.textBox_TelM = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_pwd2 = new System.Windows.Forms.TextBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.textBox_PersonM = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_CardV = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.button_CardM = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox_Fee_S = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Fee_S = new System.Windows.Forms.TextBox();
            this.button_SaveFee_S = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_SaveS = new System.Windows.Forms.Button();
            this.comboBox_Rent = new System.Windows.Forms.ComboBox();
            this.comboBox_NameS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_CardS = new System.Windows.Forms.TextBox();
            this.textBox_CertIDS = new System.Windows.Forms.TextBox();
            this.textBox_TelS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_PersonS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_CardS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(849, 470);
            this.dataGridView1.TabIndex = 34;
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(58, 21);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(161, 12);
            this.label_Topic.TabIndex = 59;
            this.label_Topic.Text = "功能说明：用于发放卖方卡。";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.button_Cancel);
            this.groupBoxList.Controls.Add(this.comboBox_Stall);
            this.groupBoxList.Controls.Add(this.label_num);
            this.groupBoxList.Controls.Add(this.label3);
            this.groupBoxList.Controls.Add(this.comboBox_Firm);
            this.groupBoxList.Controls.Add(this.label1);
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Location = new System.Drawing.Point(7, 48);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(864, 540);
            this.groupBoxList.TabIndex = 60;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "已发卡列表：";
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Cancel.Location = new System.Drawing.Point(523, 17);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(77, 40);
            this.button_Cancel.TabIndex = 64;
            this.button_Cancel.Text = "解绑(&U)";
            this.button_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Visible = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // comboBox_Stall
            // 
            this.comboBox_Stall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Stall.FormattingEnabled = true;
            this.comboBox_Stall.Location = new System.Drawing.Point(369, 23);
            this.comboBox_Stall.Name = "comboBox_Stall";
            this.comboBox_Stall.Size = new System.Drawing.Size(142, 28);
            this.comboBox_Stall.TabIndex = 32;
            this.comboBox_Stall.SelectedIndexChanged += new System.EventHandler(this.comboBox_Stall_SelectedIndexChanged);
            // 
            // label_num
            // 
            this.label_num.AutoSize = true;
            this.label_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_num.Location = new System.Drawing.Point(592, 27);
            this.label_num.Name = "label_num";
            this.label_num.Size = new System.Drawing.Size(89, 20);
            this.label_num.TabIndex = 43;
            this.label_num.Text = "指定档口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "指定档口：";
            // 
            // comboBox_Firm
            // 
            this.comboBox_Firm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Firm.FormattingEnabled = true;
            this.comboBox_Firm.Location = new System.Drawing.Point(96, 22);
            this.comboBox_Firm.Name = "comboBox_Firm";
            this.comboBox_Firm.Size = new System.Drawing.Size(177, 28);
            this.comboBox_Firm.TabIndex = 31;
            this.comboBox_Firm.SelectedIndexChanged += new System.EventHandler(this.comboBox_Firm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "指定卖方：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1204, 548);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(81, 40);
            this.button_Exit.TabIndex = 41;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(877, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(424, 494);
            this.tabControl1.TabIndex = 63;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox_Fee_M);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox_Fee_M);
            this.tabPage1.Controls.Add(this.button_SaveFee_M);
            this.tabPage1.Controls.Add(this.button_SaveM);
            this.tabPage1.Controls.Add(this.comboBox_NameM);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.textBox_CardV);
            this.tabPage1.Controls.Add(this.textBox_CardM);
            this.tabPage1.Controls.Add(this.textBox_CertIDM);
            this.tabPage1.Controls.Add(this.textBox_TelM);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.textBox_pwd2);
            this.tabPage1.Controls.Add(this.textBox_pwd);
            this.tabPage1.Controls.Add(this.textBox_PersonM);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.button_CardV);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.button_CardM);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(416, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发第一副卡与结算卡";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_Fee_M
            // 
            this.checkBox_Fee_M.AutoSize = true;
            this.checkBox_Fee_M.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Fee_M.Location = new System.Drawing.Point(17, 365);
            this.checkBox_Fee_M.Name = "checkBox_Fee_M";
            this.checkBox_Fee_M.Size = new System.Drawing.Size(107, 20);
            this.checkBox_Fee_M.TabIndex = 9;
            this.checkBox_Fee_M.Text = "IC卡工本费";
            this.checkBox_Fee_M.UseVisualStyleBackColor = true;
            this.checkBox_Fee_M.CheckedChanged += new System.EventHandler(this.checkBox_Fee_M_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(207, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 91;
            this.label6.Text = "元";
            // 
            // textBox_Fee_M
            // 
            this.textBox_Fee_M.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Fee_M.Location = new System.Drawing.Point(139, 363);
            this.textBox_Fee_M.MaxLength = 15;
            this.textBox_Fee_M.Name = "textBox_Fee_M";
            this.textBox_Fee_M.Size = new System.Drawing.Size(57, 26);
            this.textBox_Fee_M.TabIndex = 10;
            this.textBox_Fee_M.Text = "20.00";
            this.textBox_Fee_M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Fee_M.TextChanged += new System.EventHandler(this.textBox_Fee_M_TextChanged);
            // 
            // button_SaveFee_M
            // 
            this.button_SaveFee_M.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveFee_M.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveFee_M.Location = new System.Drawing.Point(232, 364);
            this.button_SaveFee_M.Name = "button_SaveFee_M";
            this.button_SaveFee_M.Size = new System.Drawing.Size(54, 26);
            this.button_SaveFee_M.TabIndex = 11;
            this.button_SaveFee_M.Text = "...";
            this.button_SaveFee_M.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_SaveFee_M.UseVisualStyleBackColor = true;
            this.button_SaveFee_M.Click += new System.EventHandler(this.button_SaveFee_M_Click);
            // 
            // button_SaveM
            // 
            this.button_SaveM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveM.Location = new System.Drawing.Point(297, 409);
            this.button_SaveM.Name = "button_SaveM";
            this.button_SaveM.Size = new System.Drawing.Size(81, 40);
            this.button_SaveM.TabIndex = 12;
            this.button_SaveM.Text = "绑定(&I)";
            this.button_SaveM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_SaveM.UseVisualStyleBackColor = true;
            this.button_SaveM.Click += new System.EventHandler(this.button_SaveM_Click);
            // 
            // comboBox_NameM
            // 
            this.comboBox_NameM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_NameM.FormattingEnabled = true;
            this.comboBox_NameM.Location = new System.Drawing.Point(139, 19);
            this.comboBox_NameM.Name = "comboBox_NameM";
            this.comboBox_NameM.Size = new System.Drawing.Size(239, 28);
            this.comboBox_NameM.TabIndex = 1;
            this.comboBox_NameM.SelectedIndexChanged += new System.EventHandler(this.comboBox_NameM_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "结算卡号：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 76;
            this.label15.Text = "第一副卡卡号：";
            // 
            // textBox_CardV
            // 
            this.textBox_CardV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CardV.Location = new System.Drawing.Point(139, 116);
            this.textBox_CardV.MaxLength = 16;
            this.textBox_CardV.Name = "textBox_CardV";
            this.textBox_CardV.Size = new System.Drawing.Size(152, 26);
            this.textBox_CardV.TabIndex = 5;
            this.textBox_CardV.Text = "6688668866886688";
            // 
            // textBox_CardM
            // 
            this.textBox_CardM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CardM.Location = new System.Drawing.Point(139, 73);
            this.textBox_CardM.MaxLength = 15;
            this.textBox_CardM.Name = "textBox_CardM";
            this.textBox_CardM.Size = new System.Drawing.Size(152, 26);
            this.textBox_CardM.TabIndex = 3;
            this.textBox_CardM.Text = "6688668866886688";
            // 
            // textBox_CertIDM
            // 
            this.textBox_CertIDM.Enabled = false;
            this.textBox_CertIDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CertIDM.Location = new System.Drawing.Point(139, 307);
            this.textBox_CertIDM.Name = "textBox_CertIDM";
            this.textBox_CertIDM.Size = new System.Drawing.Size(212, 26);
            this.textBox_CertIDM.TabIndex = 8;
            this.textBox_CertIDM.Text = "440103123456780123";
            // 
            // textBox_TelM
            // 
            this.textBox_TelM.Enabled = false;
            this.textBox_TelM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TelM.Location = new System.Drawing.Point(139, 272);
            this.textBox_TelM.Name = "textBox_TelM";
            this.textBox_TelM.Size = new System.Drawing.Size(152, 26);
            this.textBox_TelM.TabIndex = 7;
            this.textBox_TelM.Text = "12345678901";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 310);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 20);
            this.label16.TabIndex = 70;
            this.label16.Text = "联系人身份证：";
            // 
            // textBox_pwd2
            // 
            this.textBox_pwd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pwd2.Location = new System.Drawing.Point(139, 202);
            this.textBox_pwd2.MaxLength = 6;
            this.textBox_pwd2.Name = "textBox_pwd2";
            this.textBox_pwd2.PasswordChar = '*';
            this.textBox_pwd2.Size = new System.Drawing.Size(167, 26);
            this.textBox_pwd2.TabIndex = 5;
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pwd.Location = new System.Drawing.Point(139, 170);
            this.textBox_pwd.MaxLength = 6;
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.PasswordChar = '*';
            this.textBox_pwd.Size = new System.Drawing.Size(167, 26);
            this.textBox_pwd.TabIndex = 4;
            // 
            // textBox_PersonM
            // 
            this.textBox_PersonM.Enabled = false;
            this.textBox_PersonM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PersonM.Location = new System.Drawing.Point(139, 237);
            this.textBox_PersonM.Name = "textBox_PersonM";
            this.textBox_PersonM.Size = new System.Drawing.Size(167, 26);
            this.textBox_PersonM.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 275);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 20);
            this.label17.TabIndex = 71;
            this.label17.Text = "联系人电话：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "密码确认：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 20);
            this.label18.TabIndex = 68;
            this.label18.Text = "卖方名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 69;
            this.label4.Text = "提款密码：";
            // 
            // button_CardV
            // 
            this.button_CardV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CardV.Location = new System.Drawing.Point(297, 111);
            this.button_CardV.Name = "button_CardV";
            this.button_CardV.Size = new System.Drawing.Size(107, 40);
            this.button_CardV.TabIndex = 3;
            this.button_CardV.Text = "读结算卡(&V)";
            this.button_CardV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_CardV.UseVisualStyleBackColor = true;
            this.button_CardV.Click += new System.EventHandler(this.button_CardV_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 240);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 20);
            this.label19.TabIndex = 69;
            this.label19.Text = "联系人姓名：";
            // 
            // button_CardM
            // 
            this.button_CardM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CardM.Location = new System.Drawing.Point(297, 60);
            this.button_CardM.Name = "button_CardM";
            this.button_CardM.Size = new System.Drawing.Size(107, 40);
            this.button_CardM.TabIndex = 2;
            this.button_CardM.Text = "读第一副卡(&M)";
            this.button_CardM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_CardM.UseVisualStyleBackColor = true;
            this.button_CardM.Click += new System.EventHandler(this.button_CardM_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox_Fee_S);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_Fee_S);
            this.tabPage2.Controls.Add(this.button_SaveFee_S);
            this.tabPage2.Controls.Add(this.textBox_search);
            this.tabPage2.Controls.Add(this.button_SaveS);
            this.tabPage2.Controls.Add(this.comboBox_Rent);
            this.tabPage2.Controls.Add(this.comboBox_NameS);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBox_CardS);
            this.tabPage2.Controls.Add(this.textBox_CertIDS);
            this.tabPage2.Controls.Add(this.textBox_TelS);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textBox_PersonS);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.button_CardS);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(416, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发副卡";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox_Fee_S
            // 
            this.checkBox_Fee_S.AutoSize = true;
            this.checkBox_Fee_S.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Fee_S.Location = new System.Drawing.Point(17, 322);
            this.checkBox_Fee_S.Name = "checkBox_Fee_S";
            this.checkBox_Fee_S.Size = new System.Drawing.Size(107, 20);
            this.checkBox_Fee_S.TabIndex = 28;
            this.checkBox_Fee_S.Text = "IC卡工本费";
            this.checkBox_Fee_S.UseVisualStyleBackColor = true;
            this.checkBox_Fee_S.CheckedChanged += new System.EventHandler(this.checkBox_Fee_S_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(187, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 95;
            this.label7.Text = "元";
            // 
            // textBox_Fee_S
            // 
            this.textBox_Fee_S.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Fee_S.Location = new System.Drawing.Point(124, 320);
            this.textBox_Fee_S.MaxLength = 15;
            this.textBox_Fee_S.Name = "textBox_Fee_S";
            this.textBox_Fee_S.Size = new System.Drawing.Size(57, 26);
            this.textBox_Fee_S.TabIndex = 29;
            this.textBox_Fee_S.Text = "20.00";
            this.textBox_Fee_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Fee_S.TextChanged += new System.EventHandler(this.textBox_Fee_S_TextChanged);
            // 
            // button_SaveFee_S
            // 
            this.button_SaveFee_S.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveFee_S.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveFee_S.Location = new System.Drawing.Point(212, 321);
            this.button_SaveFee_S.Name = "button_SaveFee_S";
            this.button_SaveFee_S.Size = new System.Drawing.Size(54, 26);
            this.button_SaveFee_S.TabIndex = 30;
            this.button_SaveFee_S.Text = "...";
            this.button_SaveFee_S.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_SaveFee_S.UseVisualStyleBackColor = true;
            this.button_SaveFee_S.Click += new System.EventHandler(this.button_SaveFee_S_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_search.Location = new System.Drawing.Point(124, 20);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(235, 26);
            this.textBox_search.TabIndex = 21;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // button_SaveS
            // 
            this.button_SaveS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveS.Location = new System.Drawing.Point(255, 379);
            this.button_SaveS.Name = "button_SaveS";
            this.button_SaveS.Size = new System.Drawing.Size(77, 40);
            this.button_SaveS.TabIndex = 31;
            this.button_SaveS.Text = "绑定(&I)";
            this.button_SaveS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_SaveS.UseVisualStyleBackColor = true;
            this.button_SaveS.Click += new System.EventHandler(this.button_SaveS_Click);
            // 
            // comboBox_Rent
            // 
            this.comboBox_Rent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Rent.FormattingEnabled = true;
            this.comboBox_Rent.Location = new System.Drawing.Point(124, 157);
            this.comboBox_Rent.Name = "comboBox_Rent";
            this.comboBox_Rent.Size = new System.Drawing.Size(167, 28);
            this.comboBox_Rent.TabIndex = 24;
            this.comboBox_Rent.SelectedIndexChanged += new System.EventHandler(this.comboBox_Rent_SelectedIndexChanged);
            // 
            // comboBox_NameS
            // 
            this.comboBox_NameS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_NameS.FormattingEnabled = true;
            this.comboBox_NameS.Location = new System.Drawing.Point(124, 59);
            this.comboBox_NameS.Name = "comboBox_NameS";
            this.comboBox_NameS.Size = new System.Drawing.Size(235, 28);
            this.comboBox_NameS.TabIndex = 22;
            this.comboBox_NameS.SelectedIndexChanged += new System.EventHandler(this.comboBox_NameS_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 77;
            this.label9.Text = "副卡卡号：";
            // 
            // textBox_CardS
            // 
            this.textBox_CardS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CardS.Location = new System.Drawing.Point(124, 109);
            this.textBox_CardS.MaxLength = 15;
            this.textBox_CardS.Name = "textBox_CardS";
            this.textBox_CardS.Size = new System.Drawing.Size(152, 26);
            this.textBox_CardS.TabIndex = 23;
            this.textBox_CardS.Text = "6688668866886688";
            // 
            // textBox_CertIDS
            // 
            this.textBox_CertIDS.Enabled = false;
            this.textBox_CertIDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CertIDS.Location = new System.Drawing.Point(124, 257);
            this.textBox_CertIDS.Name = "textBox_CertIDS";
            this.textBox_CertIDS.Size = new System.Drawing.Size(212, 26);
            this.textBox_CertIDS.TabIndex = 27;
            this.textBox_CertIDS.Text = "440103123456780123";
            // 
            // textBox_TelS
            // 
            this.textBox_TelS.Enabled = false;
            this.textBox_TelS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TelS.Location = new System.Drawing.Point(124, 224);
            this.textBox_TelS.Name = "textBox_TelS";
            this.textBox_TelS.Size = new System.Drawing.Size(152, 26);
            this.textBox_TelS.TabIndex = 26;
            this.textBox_TelS.Text = "12345678901";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 20);
            this.label10.TabIndex = 71;
            this.label10.Text = "联系人身份证：";
            // 
            // textBox_PersonS
            // 
            this.textBox_PersonS.Enabled = false;
            this.textBox_PersonS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PersonS.Location = new System.Drawing.Point(124, 191);
            this.textBox_PersonS.Name = "textBox_PersonS";
            this.textBox_PersonS.Size = new System.Drawing.Size(167, 26);
            this.textBox_PersonS.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 72;
            this.label11.Text = "联系人电话：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 68;
            this.label12.Text = "卖方名称：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 20);
            this.label13.TabIndex = 69;
            this.label13.Text = "联系人姓名：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(7, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 70;
            this.label14.Text = "档口信息：";
            // 
            // button_CardS
            // 
            this.button_CardS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CardS.Location = new System.Drawing.Point(282, 104);
            this.button_CardS.Name = "button_CardS";
            this.button_CardS.Size = new System.Drawing.Size(77, 40);
            this.button_CardS.TabIndex = 23;
            this.button_CardS.Text = "读副卡(&S)";
            this.button_CardS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_CardS.UseVisualStyleBackColor = true;
            this.button_CardS.Click += new System.EventHandler(this.button_CardS_Click);
            // 
            // frm_Firm_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1315, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Firm_Card";
            this.Text = "发卖方卡";
            this.Load += new System.EventHandler(this.frm_Firm_Card_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxList.ResumeLayout(false);
            this.groupBoxList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ComboBox comboBox_Stall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Firm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_SaveM;
        private System.Windows.Forms.ComboBox comboBox_NameM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_CardV;
        private System.Windows.Forms.TextBox textBox_CardM;
        private System.Windows.Forms.TextBox textBox_CertIDM;
        private System.Windows.Forms.TextBox textBox_TelM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_PersonM;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button_CardV;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_CardM;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_SaveS;
        private System.Windows.Forms.ComboBox comboBox_Rent;
        private System.Windows.Forms.ComboBox comboBox_NameS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_CardS;
        private System.Windows.Forms.TextBox textBox_CertIDS;
        private System.Windows.Forms.TextBox textBox_TelS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_PersonS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_CardS;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_pwd2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_num;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.CheckBox checkBox_Fee_M;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Fee_M;
        private System.Windows.Forms.Button button_SaveFee_M;
        private System.Windows.Forms.CheckBox checkBox_Fee_S;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Fee_S;
        private System.Windows.Forms.Button button_SaveFee_S;
    }
}