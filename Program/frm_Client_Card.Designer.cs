namespace YTB
{
    partial class frm_Client_Card
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
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.checkBox_Fee = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Fee = new System.Windows.Forms.TextBox();
            this.button_SaveFee = new System.Windows.Forms.Button();
            this.textBox_pwd2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Card = new System.Windows.Forms.TextBox();
            this.textBox_rmrk = new System.Windows.Forms.TextBox();
            this.textBox_Addr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_CertID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.textBox_Person = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Card = new System.Windows.Forms.Button();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_truck = new System.Windows.Forms.TextBox();
            this.comboBox_truck = new System.Windows.Forms.ComboBox();
            this.checkBox_Sign = new System.Windows.Forms.CheckBox();
            this.checkBox_multy = new System.Windows.Forms.CheckBox();
            this.groupBoxInf.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.checkBox_multy);
            this.groupBoxInf.Controls.Add(this.checkBox_Sign);
            this.groupBoxInf.Controls.Add(this.comboBox_truck);
            this.groupBoxInf.Controls.Add(this.checkBox_Fee);
            this.groupBoxInf.Controls.Add(this.label9);
            this.groupBoxInf.Controls.Add(this.textBox_Fee);
            this.groupBoxInf.Controls.Add(this.button_SaveFee);
            this.groupBoxInf.Controls.Add(this.textBox_pwd2);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Controls.Add(this.label7);
            this.groupBoxInf.Controls.Add(this.textBox_Card);
            this.groupBoxInf.Controls.Add(this.textBox_rmrk);
            this.groupBoxInf.Controls.Add(this.textBox_Addr);
            this.groupBoxInf.Controls.Add(this.label8);
            this.groupBoxInf.Controls.Add(this.textBox_truck);
            this.groupBoxInf.Controls.Add(this.textBox_CertID);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.label10);
            this.groupBoxInf.Controls.Add(this.textBox_Cell);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.textBox_pwd);
            this.groupBoxInf.Controls.Add(this.textBox_Person);
            this.groupBoxInf.Controls.Add(this.label1);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label5);
            this.groupBoxInf.Controls.Add(this.button_Card);
            this.groupBoxInf.Location = new System.Drawing.Point(721, 50);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(290, 583);
            this.groupBoxInf.TabIndex = 66;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "发卡详情：";
            // 
            // checkBox_Fee
            // 
            this.checkBox_Fee.AutoSize = true;
            this.checkBox_Fee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Fee.Location = new System.Drawing.Point(16, 489);
            this.checkBox_Fee.Name = "checkBox_Fee";
            this.checkBox_Fee.Size = new System.Drawing.Size(107, 20);
            this.checkBox_Fee.TabIndex = 14;
            this.checkBox_Fee.Text = "IC卡工本费";
            this.checkBox_Fee.UseVisualStyleBackColor = true;
            this.checkBox_Fee.CheckedChanged += new System.EventHandler(this.checkBox_Fee_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(186, 492);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 87;
            this.label9.Text = "元";
            // 
            // textBox_Fee
            // 
            this.textBox_Fee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Fee.Location = new System.Drawing.Point(123, 487);
            this.textBox_Fee.MaxLength = 15;
            this.textBox_Fee.Name = "textBox_Fee";
            this.textBox_Fee.Size = new System.Drawing.Size(57, 26);
            this.textBox_Fee.TabIndex = 15;
            this.textBox_Fee.Text = "20.00";
            this.textBox_Fee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_Fee.TextChanged += new System.EventHandler(this.textBox_Fee_TextChanged);
            // 
            // button_SaveFee
            // 
            this.button_SaveFee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_SaveFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveFee.Location = new System.Drawing.Point(211, 488);
            this.button_SaveFee.Name = "button_SaveFee";
            this.button_SaveFee.Size = new System.Drawing.Size(54, 26);
            this.button_SaveFee.TabIndex = 16;
            this.button_SaveFee.Text = "...";
            this.button_SaveFee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_SaveFee.UseVisualStyleBackColor = true;
            this.button_SaveFee.Click += new System.EventHandler(this.button_SaveFee_Click);
            // 
            // textBox_pwd2
            // 
            this.textBox_pwd2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pwd2.Location = new System.Drawing.Point(93, 134);
            this.textBox_pwd2.MaxLength = 6;
            this.textBox_pwd2.Name = "textBox_pwd2";
            this.textBox_pwd2.PasswordChar = '*';
            this.textBox_pwd2.Size = new System.Drawing.Size(183, 26);
            this.textBox_pwd2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 71;
            this.label3.Text = "密码确认：";
            // 
            // button_Save
            // 
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Save.Location = new System.Drawing.Point(199, 526);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 17;
            this.button_Save.Text = "发卡(&I)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "卡号：";
            // 
            // textBox_Card
            // 
            this.textBox_Card.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Card.Location = new System.Drawing.Point(41, 52);
            this.textBox_Card.MaxLength = 16;
            this.textBox_Card.Name = "textBox_Card";
            this.textBox_Card.Size = new System.Drawing.Size(152, 26);
            this.textBox_Card.TabIndex = 2;
            this.textBox_Card.Text = "6688668866886688";
            // 
            // textBox_rmrk
            // 
            this.textBox_rmrk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rmrk.Location = new System.Drawing.Point(93, 420);
            this.textBox_rmrk.MaxLength = 18;
            this.textBox_rmrk.Multiline = true;
            this.textBox_rmrk.Name = "textBox_rmrk";
            this.textBox_rmrk.Size = new System.Drawing.Size(183, 61);
            this.textBox_rmrk.TabIndex = 13;
            this.textBox_rmrk.Text = "440103123456780123";
            // 
            // textBox_Addr
            // 
            this.textBox_Addr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Addr.Location = new System.Drawing.Point(93, 361);
            this.textBox_Addr.MaxLength = 18;
            this.textBox_Addr.Multiline = true;
            this.textBox_Addr.Name = "textBox_Addr";
            this.textBox_Addr.Size = new System.Drawing.Size(183, 53);
            this.textBox_Addr.TabIndex = 12;
            this.textBox_Addr.Text = "440103123456780123";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "备注：";
            // 
            // textBox_CertID
            // 
            this.textBox_CertID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CertID.Location = new System.Drawing.Point(93, 284);
            this.textBox_CertID.MaxLength = 18;
            this.textBox_CertID.Name = "textBox_CertID";
            this.textBox_CertID.Size = new System.Drawing.Size(183, 26);
            this.textBox_CertID.TabIndex = 9;
            this.textBox_CertID.Text = "440103123456780123";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "经营地址：";
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cell.Location = new System.Drawing.Point(93, 242);
            this.textBox_Cell.MaxLength = 11;
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.Size = new System.Drawing.Size(183, 26);
            this.textBox_Cell.TabIndex = 8;
            this.textBox_Cell.Text = "12345678901";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "身份证：";
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_pwd.Location = new System.Drawing.Point(93, 99);
            this.textBox_pwd.MaxLength = 6;
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.PasswordChar = '*';
            this.textBox_pwd.Size = new System.Drawing.Size(183, 26);
            this.textBox_pwd.TabIndex = 3;
            // 
            // textBox_Person
            // 
            this.textBox_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Person.Location = new System.Drawing.Point(93, 177);
            this.textBox_Person.Name = "textBox_Person";
            this.textBox_Person.Size = new System.Drawing.Size(183, 26);
            this.textBox_Person.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "取款密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "手机：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "姓名：";
            // 
            // button_Card
            // 
            this.button_Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Card.Location = new System.Drawing.Point(199, 43);
            this.button_Card.Name = "button_Card";
            this.button_Card.Size = new System.Drawing.Size(77, 40);
            this.button_Card.TabIndex = 1;
            this.button_Card.Text = "读卡(&R)";
            this.button_Card.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Card.UseVisualStyleBackColor = true;
            this.button_Card.Click += new System.EventHandler(this.button_Card_Click);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(62, 23);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(161, 12);
            this.label_Topic.TabIndex = 64;
            this.label_Topic.Text = "功能说明：用于发放买方卡。";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Location = new System.Drawing.Point(14, 50);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(687, 629);
            this.groupBoxList.TabIndex = 65;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "已发卡列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(652, 593);
            this.dataGridView1.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 67;
            this.pictureBox1.TabStop = false;
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(920, 639);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 18;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Cancel.Location = new System.Drawing.Point(824, 639);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(77, 40);
            this.button_Cancel.TabIndex = 68;
            this.button_Cancel.Text = "解绑(&U)";
            this.button_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "车牌：";
            // 
            // textBox_truck
            // 
            this.textBox_truck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_truck.Location = new System.Drawing.Point(157, 322);
            this.textBox_truck.MaxLength = 18;
            this.textBox_truck.Name = "textBox_truck";
            this.textBox_truck.Size = new System.Drawing.Size(119, 26);
            this.textBox_truck.TabIndex = 11;
            this.textBox_truck.Text = "440103123456780123";
            // 
            // comboBox_truck
            // 
            this.comboBox_truck.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_truck.FormattingEnabled = true;
            this.comboBox_truck.Location = new System.Drawing.Point(93, 324);
            this.comboBox_truck.Name = "comboBox_truck";
            this.comboBox_truck.Size = new System.Drawing.Size(58, 24);
            this.comboBox_truck.TabIndex = 10;
            // 
            // checkBox_Sign
            // 
            this.checkBox_Sign.AutoSize = true;
            this.checkBox_Sign.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Sign.Location = new System.Drawing.Point(18, 216);
            this.checkBox_Sign.Name = "checkBox_Sign";
            this.checkBox_Sign.Size = new System.Drawing.Size(123, 20);
            this.checkBox_Sign.TabIndex = 6;
            this.checkBox_Sign.Text = "是否签约客户";
            this.checkBox_Sign.UseVisualStyleBackColor = true;
            // 
            // checkBox_multy
            // 
            this.checkBox_multy.AutoSize = true;
            this.checkBox_multy.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_multy.Location = new System.Drawing.Point(157, 216);
            this.checkBox_multy.Name = "checkBox_multy";
            this.checkBox_multy.Size = new System.Drawing.Size(91, 20);
            this.checkBox_multy.TabIndex = 7;
            this.checkBox_multy.Text = "是否副卡";
            this.checkBox_multy.UseVisualStyleBackColor = true;
            // 
            // frm_Client_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1027, 691);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Client_Card";
            this.Text = "买方卡开卡";
            this.Load += new System.EventHandler(this.frm_Client_Card_Load);
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Card;
        private System.Windows.Forms.TextBox textBox_CertID;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Person;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Card;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_pwd2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_rmrk;
        private System.Windows.Forms.TextBox textBox_Addr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.CheckBox checkBox_Fee;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Fee;
        private System.Windows.Forms.Button button_SaveFee;
        private System.Windows.Forms.CheckBox checkBox_multy;
        private System.Windows.Forms.CheckBox checkBox_Sign;
        private System.Windows.Forms.ComboBox comboBox_truck;
        private System.Windows.Forms.TextBox textBox_truck;
        private System.Windows.Forms.Label label10;
    }
}