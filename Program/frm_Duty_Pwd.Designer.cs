namespace YTB
{
    partial class frm_Duty_Pwd
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
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_2nd_Pwd = new System.Windows.Forms.TextBox();
            this.textBox_New_Pwd = new System.Windows.Forms.TextBox();
            this.textBox_Old_Pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(223, 243);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 30;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Save.Location = new System.Drawing.Point(100, 243);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 36;
            this.button_Save.Text = "更改(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_2nd_Pwd);
            this.groupBox1.Controls.Add(this.textBox_New_Pwd);
            this.groupBox1.Controls.Add(this.textBox_Old_Pwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_SrvIP);
            this.groupBox1.Location = new System.Drawing.Point(38, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 145);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更改密码";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox_2nd_Pwd
            // 
            this.textBox_2nd_Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_2nd_Pwd.Location = new System.Drawing.Point(185, 103);
            this.textBox_2nd_Pwd.MaxLength = 8;
            this.textBox_2nd_Pwd.Name = "textBox_2nd_Pwd";
            this.textBox_2nd_Pwd.PasswordChar = '*';
            this.textBox_2nd_Pwd.Size = new System.Drawing.Size(128, 26);
            this.textBox_2nd_Pwd.TabIndex = 41;
            // 
            // textBox_New_Pwd
            // 
            this.textBox_New_Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_New_Pwd.Location = new System.Drawing.Point(185, 67);
            this.textBox_New_Pwd.MaxLength = 8;
            this.textBox_New_Pwd.Name = "textBox_New_Pwd";
            this.textBox_New_Pwd.PasswordChar = '*';
            this.textBox_New_Pwd.Size = new System.Drawing.Size(128, 26);
            this.textBox_New_Pwd.TabIndex = 41;
            // 
            // textBox_Old_Pwd
            // 
            this.textBox_Old_Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Old_Pwd.Location = new System.Drawing.Point(185, 31);
            this.textBox_Old_Pwd.MaxLength = 8;
            this.textBox_Old_Pwd.Name = "textBox_Old_Pwd";
            this.textBox_Old_Pwd.PasswordChar = '*';
            this.textBox_Old_Pwd.Size = new System.Drawing.Size(128, 26);
            this.textBox_Old_Pwd.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "请再次输入新密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "请输入新密码：";
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SrvIP.Location = new System.Drawing.Point(27, 37);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(121, 20);
            this.label_SrvIP.TabIndex = 40;
            this.label_SrvIP.Text = "请输入旧密码：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(38, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 59;
            this.pictureBox1.TabStop = false;
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(77, 27);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(413, 12);
            this.label_Topic.TabIndex = 58;
            this.label_Topic.Text = "功能说明：用于修改登录密码。修改成功后，退出登录系统后，新密码生效。";
            // 
            // frm_Duty_Pwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(414, 303);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Duty_Pwd";
            this.Text = "更改密码";
            this.Load += new System.EventHandler(this.frm_Duty_Pwd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_2nd_Pwd;
        private System.Windows.Forms.TextBox textBox_New_Pwd;
        private System.Windows.Forms.TextBox textBox_Old_Pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_SrvIP;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Topic;
    }
}