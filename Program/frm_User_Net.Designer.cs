namespace YTB
{
    partial class frm_User_Net
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
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.textBox_tellerNo = new System.Windows.Forms.TextBox();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Psam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_Topic = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Controls.Add(this.button_Del);
            this.groupBoxList.Controls.Add(this.button_Edit);
            this.groupBoxList.Controls.Add(this.button_Add);
            this.groupBoxList.Location = new System.Drawing.Point(11, 64);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(715, 258);
            this.groupBoxList.TabIndex = 50;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "工作网点列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(671, 184);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(616, 210);
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
            this.button_Edit.Location = new System.Drawing.Point(533, 210);
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
            this.button_Add.Location = new System.Drawing.Point(450, 210);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(77, 40);
            this.button_Add.TabIndex = 31;
            this.button_Add.Text = "新增(&A)";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(34, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(533, 145);
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
            this.button_Save.Location = new System.Drawing.Point(534, 99);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 32;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.textBox_tellerNo);
            this.groupBoxInf.Controls.Add(this.textBox_Key);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.label5);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.textBox_Psam);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.label1);
            this.groupBoxInf.Controls.Add(this.textBox_Name);
            this.groupBoxInf.Controls.Add(this.label_SrvUserName);
            this.groupBoxInf.Controls.Add(this.textBox_tel);
            this.groupBoxInf.Controls.Add(this.label7);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Location = new System.Drawing.Point(11, 329);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(623, 199);
            this.groupBoxInf.TabIndex = 51;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "工作网点详情：";
            // 
            // textBox_tellerNo
            // 
            this.textBox_tellerNo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_tellerNo.Location = new System.Drawing.Point(174, 160);
            this.textBox_tellerNo.Name = "textBox_tellerNo";
            this.textBox_tellerNo.Size = new System.Drawing.Size(237, 30);
            this.textBox_tellerNo.TabIndex = 41;
            // 
            // textBox_Key
            // 
            this.textBox_Key.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Key.Location = new System.Drawing.Point(174, 124);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(237, 30);
            this.textBox_Key.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(406, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "(后台分配)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(406, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "(后台分配)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "发起方操作员：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "签名安全码：";
            // 
            // textBox_Psam
            // 
            this.textBox_Psam.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Psam.Location = new System.Drawing.Point(117, 88);
            this.textBox_Psam.Name = "textBox_Psam";
            this.textBox_Psam.Size = new System.Drawing.Size(223, 30);
            this.textBox_Psam.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(346, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "(安装在读卡器内)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "PSAM卡：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Name.Location = new System.Drawing.Point(118, 16);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(397, 30);
            this.textBox_Name.TabIndex = 41;
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvUserName.Location = new System.Drawing.Point(19, 20);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(109, 20);
            this.label_SrvUserName.TabIndex = 40;
            this.label_SrvUserName.Text = "网点名称：";
            // 
            // textBox_tel
            // 
            this.textBox_tel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_tel.Location = new System.Drawing.Point(194, 52);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(321, 30);
            this.textBox_tel.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(19, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "网点联系人电话：";
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(73, 28);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(233, 12);
            this.label_Topic.TabIndex = 49;
            this.label_Topic.Text = "功能说明：用于设置工作网点的基本信息。";
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(649, 440);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 48;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // frm_User_Net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(741, 540);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_User_Net";
            this.Text = "工作网点信息管理";
            this.Load += new System.EventHandler(this.frm_User_Net_Load);
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Psam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.TextBox textBox_tellerNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.Label label7;
    }
}