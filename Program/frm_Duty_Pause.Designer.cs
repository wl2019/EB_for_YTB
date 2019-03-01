namespace YTB
{
    partial class frm_Duty_Pause
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
            this.button_Rest = new System.Windows.Forms.Button();
            this.textBox_LoginName = new System.Windows.Forms.TextBox();
            this.label_LoginName = new System.Windows.Forms.Label();
            this.button_ReLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Rest
            // 
            this.button_Rest.BackColor = System.Drawing.Color.Transparent;
            this.button_Rest.FlatAppearance.BorderSize = 2;
            this.button_Rest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Rest.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Rest.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button_Rest.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Rest.Location = new System.Drawing.Point(284, 231);
            this.button_Rest.Name = "button_Rest";
            this.button_Rest.Size = new System.Drawing.Size(98, 60);
            this.button_Rest.TabIndex = 7;
            this.button_Rest.Text = "继续休息(&R)";
            this.button_Rest.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Rest.UseVisualStyleBackColor = false;
            this.button_Rest.Click += new System.EventHandler(this.button_Rest_Click);
            // 
            // textBox_LoginName
            // 
            this.textBox_LoginName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox_LoginName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBox_LoginName.Location = new System.Drawing.Point(244, 134);
            this.textBox_LoginName.MaxLength = 20;
            this.textBox_LoginName.Name = "textBox_LoginName";
            this.textBox_LoginName.Size = new System.Drawing.Size(179, 33);
            this.textBox_LoginName.TabIndex = 6;
            // 
            // label_LoginName
            // 
            this.label_LoginName.AutoSize = true;
            this.label_LoginName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_LoginName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label_LoginName.Location = new System.Drawing.Point(93, 137);
            this.label_LoginName.Name = "label_LoginName";
            this.label_LoginName.Size = new System.Drawing.Size(145, 26);
            this.label_LoginName.TabIndex = 5;
            this.label_LoginName.Text = "请输入登录密码";
            // 
            // button_ReLogin
            // 
            this.button_ReLogin.BackColor = System.Drawing.Color.Transparent;
            this.button_ReLogin.FlatAppearance.BorderSize = 2;
            this.button_ReLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReLogin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ReLogin.ForeColor = System.Drawing.Color.Goldenrod;
            this.button_ReLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_ReLogin.Location = new System.Drawing.Point(163, 231);
            this.button_ReLogin.Name = "button_ReLogin";
            this.button_ReLogin.Size = new System.Drawing.Size(98, 60);
            this.button_ReLogin.TabIndex = 4;
            this.button_ReLogin.Text = "重新登录(&L)";
            this.button_ReLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_ReLogin.UseVisualStyleBackColor = false;
            this.button_ReLogin.Click += new System.EventHandler(this.button_ReLogin_Click);
            // 
            // frm_Duty_Pause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YTB.Properties.Resources.TakeRestEmpty02;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.ControlBox = false;
            this.Controls.Add(this.button_Rest);
            this.Controls.Add(this.textBox_LoginName);
            this.Controls.Add(this.label_LoginName);
            this.Controls.Add(this.button_ReLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Duty_Pause";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "临时挂机";
            this.Load += new System.EventHandler(this.frm_Duty_Pause_Load);
            this.Click += new System.EventHandler(this.frm_Duty_Pause_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Rest;
        private System.Windows.Forms.TextBox textBox_LoginName;
        private System.Windows.Forms.Label label_LoginName;
        private System.Windows.Forms.Button button_ReLogin;
    }
}