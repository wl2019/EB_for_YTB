namespace YTB
{
    partial class frm_Client_Base
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
            this.comboBox_state = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.checkBox_Sign = new System.Windows.Forms.CheckBox();
            this.comboBox_truck = new System.Windows.Forms.ComboBox();
            this.textBox_truck = new System.Windows.Forms.TextBox();
            this.dateTimePicker_valid = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Cert = new System.Windows.Forms.ComboBox();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_Cert = new System.Windows.Forms.TextBox();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxInf.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(1026, 512);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 53;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // comboBox_state
            // 
            this.comboBox_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_state.FormattingEnabled = true;
            this.comboBox_state.Location = new System.Drawing.Point(81, 119);
            this.comboBox_state.Name = "comboBox_state";
            this.comboBox_state.Size = new System.Drawing.Size(128, 28);
            this.comboBox_state.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.checkBox_Sign);
            this.groupBoxInf.Controls.Add(this.comboBox_truck);
            this.groupBoxInf.Controls.Add(this.textBox_truck);
            this.groupBoxInf.Controls.Add(this.dateTimePicker_valid);
            this.groupBoxInf.Controls.Add(this.comboBox_state);
            this.groupBoxInf.Controls.Add(this.comboBox_Cert);
            this.groupBoxInf.Controls.Add(this.textBox_Desc);
            this.groupBoxInf.Controls.Add(this.label_Database);
            this.groupBoxInf.Controls.Add(this.textBox_Cert);
            this.groupBoxInf.Controls.Add(this.textBox_Addr);
            this.groupBoxInf.Controls.Add(this.textBox_Cell);
            this.groupBoxInf.Controls.Add(this.textBox_Name);
            this.groupBoxInf.Controls.Add(this.label8);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.label7);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label_SrvUserName);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.textBox_Code);
            this.groupBoxInf.Controls.Add(this.label_SrvIP);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Controls.Add(this.label11);
            this.groupBoxInf.Location = new System.Drawing.Point(12, 410);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(997, 163);
            this.groupBoxInf.TabIndex = 56;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "买方详情：";
            // 
            // checkBox_Sign
            // 
            this.checkBox_Sign.AutoSize = true;
            this.checkBox_Sign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Sign.Location = new System.Drawing.Point(437, 23);
            this.checkBox_Sign.Name = "checkBox_Sign";
            this.checkBox_Sign.Size = new System.Drawing.Size(91, 20);
            this.checkBox_Sign.TabIndex = 46;
            this.checkBox_Sign.Text = "签约客户";
            this.checkBox_Sign.UseVisualStyleBackColor = true;
            // 
            // comboBox_truck
            // 
            this.comboBox_truck.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_truck.FormattingEnabled = true;
            this.comboBox_truck.Location = new System.Drawing.Point(347, 124);
            this.comboBox_truck.Name = "comboBox_truck";
            this.comboBox_truck.Size = new System.Drawing.Size(46, 24);
            this.comboBox_truck.TabIndex = 44;
            // 
            // textBox_truck
            // 
            this.textBox_truck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_truck.Location = new System.Drawing.Point(400, 122);
            this.textBox_truck.MaxLength = 18;
            this.textBox_truck.Name = "textBox_truck";
            this.textBox_truck.Size = new System.Drawing.Size(119, 26);
            this.textBox_truck.TabIndex = 45;
            // 
            // dateTimePicker_valid
            // 
            this.dateTimePicker_valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_valid.Location = new System.Drawing.Point(347, 85);
            this.dateTimePicker_valid.Name = "dateTimePicker_valid";
            this.dateTimePicker_valid.Size = new System.Drawing.Size(172, 26);
            this.dateTimePicker_valid.TabIndex = 41;
            // 
            // comboBox_Cert
            // 
            this.comboBox_Cert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Cert.FormattingEnabled = true;
            this.comboBox_Cert.Location = new System.Drawing.Point(347, 15);
            this.comboBox_Cert.Name = "comboBox_Cert";
            this.comboBox_Cert.Size = new System.Drawing.Size(74, 28);
            this.comboBox_Cert.TabIndex = 40;
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Desc.Location = new System.Drawing.Point(647, 87);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.Size = new System.Drawing.Size(199, 61);
            this.textBox_Desc.TabIndex = 39;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Database.Location = new System.Drawing.Point(555, 88);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(89, 20);
            this.label_Database.TabIndex = 38;
            this.label_Database.Text = "备        注：";
            // 
            // textBox_Cert
            // 
            this.textBox_Cert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cert.Location = new System.Drawing.Point(347, 51);
            this.textBox_Cert.Name = "textBox_Cert";
            this.textBox_Cert.Size = new System.Drawing.Size(172, 26);
            this.textBox_Cert.TabIndex = 37;
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Addr.Location = new System.Drawing.Point(647, 20);
            this.textBox_Addr.Multiline = true;
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(199, 57);
            this.textBox_Addr.TabIndex = 37;
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cell.Location = new System.Drawing.Point(81, 87);
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.Size = new System.Drawing.Size(129, 26);
            this.textBox_Cell.TabIndex = 37;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name.Location = new System.Drawing.Point(81, 51);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(129, 26);
            this.textBox_Name.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(237, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "证件号码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "证件类型：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(555, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "经营地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(237, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "车牌号码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "状态：";
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SrvUserName.Location = new System.Drawing.Point(237, 88);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(105, 20);
            this.label_SrvUserName.TabIndex = 36;
            this.label_SrvUserName.Text = "证件有效期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "姓名：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Code.Location = new System.Drawing.Point(81, 17);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(128, 26);
            this.textBox_Code.TabIndex = 35;
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SrvIP.Location = new System.Drawing.Point(21, 23);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(57, 20);
            this.label_SrvIP.TabIndex = 34;
            this.label_SrvIP.Text = "编号：";
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(885, 89);
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
            this.button_Save.Location = new System.Drawing.Point(885, 32);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 32;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "手机：";
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(51, 23);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(209, 12);
            this.label_Topic.TabIndex = 54;
            this.label_Topic.Text = "功能说明：用于设置买方的基本信息。";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Controls.Add(this.button_Del);
            this.groupBoxList.Controls.Add(this.button_Edit);
            this.groupBoxList.Controls.Add(this.button_Add);
            this.groupBoxList.Location = new System.Drawing.Point(12, 50);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(1106, 354);
            this.groupBoxList.TabIndex = 55;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "买方列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 281);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(1016, 308);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(77, 40);
            this.button_Del.TabIndex = 33;
            this.button_Del.Text = "删除(&D)";
            this.button_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Visible = false;
            // 
            // button_Edit
            // 
            this.button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Edit.Location = new System.Drawing.Point(933, 308);
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
            this.button_Add.Location = new System.Drawing.Point(850, 308);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(77, 40);
            this.button_Add.TabIndex = 31;
            this.button_Add.Text = "新增(&A)";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // frm_Client_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1129, 585);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.groupBoxList);
            this.Name = "frm_Client_Base";
            this.Text = "买方基本信息";
            this.Load += new System.EventHandler(this.frm_Client_Base_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ComboBox comboBox_state;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker_valid;
        private System.Windows.Forms.ComboBox comboBox_Cert;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_Cert;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Label label_SrvIP;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_truck;
        private System.Windows.Forms.TextBox textBox_truck;
        private System.Windows.Forms.CheckBox checkBox_Sign;
    }
}