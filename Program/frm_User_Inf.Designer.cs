namespace YTB
{
    partial class frm_User_Inf
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
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker_birth = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Cert = new System.Windows.Forms.ComboBox();
            this.comboBox_Sex = new System.Windows.Forms.ComboBox();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_Cert = new System.Windows.Forms.TextBox();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.textBox_Tel = new System.Windows.Forms.TextBox();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.textBox_Position = new System.Windows.Forms.TextBox();
            this.textBox_Dpt = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_Topic = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxInf.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(872, 444);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 30;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.textBox_pwd);
            this.groupBoxInf.Controls.Add(this.label10);
            this.groupBoxInf.Controls.Add(this.textBox_login);
            this.groupBoxInf.Controls.Add(this.label11);
            this.groupBoxInf.Controls.Add(this.dateTimePicker_birth);
            this.groupBoxInf.Controls.Add(this.comboBox_Cert);
            this.groupBoxInf.Controls.Add(this.comboBox_Sex);
            this.groupBoxInf.Controls.Add(this.textBox_Desc);
            this.groupBoxInf.Controls.Add(this.label_Database);
            this.groupBoxInf.Controls.Add(this.textBox_Cert);
            this.groupBoxInf.Controls.Add(this.textBox_Addr);
            this.groupBoxInf.Controls.Add(this.textBox_Tel);
            this.groupBoxInf.Controls.Add(this.textBox_Cell);
            this.groupBoxInf.Controls.Add(this.textBox_Position);
            this.groupBoxInf.Controls.Add(this.textBox_Dpt);
            this.groupBoxInf.Controls.Add(this.textBox_Name);
            this.groupBoxInf.Controls.Add(this.label8);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.label7);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label1);
            this.groupBoxInf.Controls.Add(this.label5);
            this.groupBoxInf.Controls.Add(this.label_SrvUserName);
            this.groupBoxInf.Controls.Add(this.label9);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.textBox_Code);
            this.groupBoxInf.Controls.Add(this.label_SrvIP);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Location = new System.Drawing.Point(12, 309);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(854, 195);
            this.groupBoxInf.TabIndex = 46;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "工作人员详情：";
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_pwd.Location = new System.Drawing.Point(69, 159);
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.PasswordChar = '*';
            this.textBox_pwd.Size = new System.Drawing.Size(128, 21);
            this.textBox_pwd.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(19, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 42;
            this.label10.Text = "密码：";
            // 
            // textBox_login
            // 
            this.textBox_login.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_login.Location = new System.Drawing.Point(69, 132);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(128, 21);
            this.textBox_login.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(237, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 43;
            this.label11.Text = "联系电话：";
            // 
            // dateTimePicker_birth
            // 
            this.dateTimePicker_birth.Location = new System.Drawing.Point(69, 105);
            this.dateTimePicker_birth.Name = "dateTimePicker_birth";
            this.dateTimePicker_birth.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker_birth.TabIndex = 41;
            // 
            // comboBox_Cert
            // 
            this.comboBox_Cert.FormattingEnabled = true;
            this.comboBox_Cert.Location = new System.Drawing.Point(308, 79);
            this.comboBox_Cert.Name = "comboBox_Cert";
            this.comboBox_Cert.Size = new System.Drawing.Size(129, 20);
            this.comboBox_Cert.TabIndex = 40;
            // 
            // comboBox_Sex
            // 
            this.comboBox_Sex.FormattingEnabled = true;
            this.comboBox_Sex.Location = new System.Drawing.Point(69, 79);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(59, 20);
            this.comboBox_Sex.TabIndex = 40;
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Desc.Location = new System.Drawing.Point(539, 74);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.Size = new System.Drawing.Size(298, 48);
            this.textBox_Desc.TabIndex = 39;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("宋体", 9F);
            this.label_Database.Location = new System.Drawing.Point(492, 79);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(41, 12);
            this.label_Database.TabIndex = 38;
            this.label_Database.Text = "备注：";
            // 
            // textBox_Cert
            // 
            this.textBox_Cert.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Cert.Location = new System.Drawing.Point(308, 105);
            this.textBox_Cert.Name = "textBox_Cert";
            this.textBox_Cert.Size = new System.Drawing.Size(154, 21);
            this.textBox_Cert.TabIndex = 37;
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Addr.Location = new System.Drawing.Point(539, 21);
            this.textBox_Addr.Multiline = true;
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(298, 42);
            this.textBox_Addr.TabIndex = 37;
            // 
            // textBox_Tel
            // 
            this.textBox_Tel.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Tel.Location = new System.Drawing.Point(308, 159);
            this.textBox_Tel.Name = "textBox_Tel";
            this.textBox_Tel.Size = new System.Drawing.Size(154, 21);
            this.textBox_Tel.TabIndex = 37;
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Cell.Location = new System.Drawing.Point(308, 132);
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.Size = new System.Drawing.Size(154, 21);
            this.textBox_Cell.TabIndex = 37;
            // 
            // textBox_Position
            // 
            this.textBox_Position.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Position.Location = new System.Drawing.Point(308, 52);
            this.textBox_Position.Name = "textBox_Position";
            this.textBox_Position.Size = new System.Drawing.Size(129, 21);
            this.textBox_Position.TabIndex = 37;
            // 
            // textBox_Dpt
            // 
            this.textBox_Dpt.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Dpt.Location = new System.Drawing.Point(308, 25);
            this.textBox_Dpt.Name = "textBox_Dpt";
            this.textBox_Dpt.Size = new System.Drawing.Size(129, 21);
            this.textBox_Dpt.TabIndex = 37;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Name.Location = new System.Drawing.Point(69, 52);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(128, 21);
            this.textBox_Name.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(237, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "证件号码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(237, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "证件类型：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(492, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "住址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(237, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "手机号码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(19, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "帐号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(237, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "工作岗位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(237, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "所属部门：";
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 9F);
            this.label_SrvUserName.Location = new System.Drawing.Point(19, 114);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(41, 12);
            this.label_SrvUserName.TabIndex = 36;
            this.label_SrvUserName.Text = "生日：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(19, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 34;
            this.label9.Text = "性别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(19, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "姓名：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Font = new System.Drawing.Font("宋体", 9F);
            this.textBox_Code.Location = new System.Drawing.Point(69, 25);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(128, 21);
            this.textBox_Code.TabIndex = 35;
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("宋体", 9F);
            this.label_SrvIP.Location = new System.Drawing.Point(19, 34);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(41, 12);
            this.label_SrvIP.TabIndex = 34;
            this.label_SrvIP.Text = "编号：";
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(728, 137);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(77, 40);
            this.button_Undo.TabIndex = 33;
            this.button_Undo.Text = "放弃(&U)";
            this.button_Undo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // button_Save
            // 
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Save.Location = new System.Drawing.Point(629, 137);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 32;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Controls.Add(this.button_Del);
            this.groupBoxList.Controls.Add(this.button_Edit);
            this.groupBoxList.Controls.Add(this.button_Add);
            this.groupBoxList.Location = new System.Drawing.Point(12, 44);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(949, 258);
            this.groupBoxList.TabIndex = 45;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "工作人员列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(928, 184);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(843, 212);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(77, 40);
            this.button_Del.TabIndex = 33;
            this.button_Del.Text = "删除(&D)";
            this.button_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Edit.Location = new System.Drawing.Point(760, 212);
            this.button_Edit.Name = "button_Edit";
            this.button_Edit.Size = new System.Drawing.Size(77, 40);
            this.button_Edit.TabIndex = 32;
            this.button_Edit.Text = "修改(&E)";
            this.button_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Edit.UseVisualStyleBackColor = true;
            this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Add.Location = new System.Drawing.Point(677, 212);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(77, 40);
            this.button_Add.TabIndex = 31;
            this.button_Add.Text = "新增(&A)";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(51, 17);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(233, 12);
            this.label_Topic.TabIndex = 44;
            this.label_Topic.Text = "功能说明：用于设置工作人员的基本信息。";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // frm_User_Inf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(973, 516);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_User_Inf";
            this.Text = "工作人员信息管理";
            this.Load += new System.EventHandler(this.frm_User_Inf_Load);
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Label label_SrvIP;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_Cert;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.TextBox textBox_Tel;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.TextBox textBox_Position;
        private System.Windows.Forms.TextBox textBox_Dpt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_birth;
        private System.Windows.Forms.ComboBox comboBox_Cert;
        private System.Windows.Forms.ComboBox comboBox_Sex;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label11;
    }
}