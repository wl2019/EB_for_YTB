namespace YTB
{
    partial class frm_Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.button_Exit = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.label_Tips = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.Transparent;
            this.button_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Exit.BackgroundImage")));
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.button_Exit.FlatAppearance.BorderSize = 0;
            this.button_Exit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Exit.ForeColor = System.Drawing.Color.LemonChiffon;
            this.button_Exit.Location = new System.Drawing.Point(408, 388);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(90, 39);
            this.button_Exit.TabIndex = 4;
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.buttonExit_Click);
            this.button_Exit.MouseEnter += new System.EventHandler(this.button_Exit_Enter);
            this.button_Exit.MouseLeave += new System.EventHandler(this.button_Exit_Leave);
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.textBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Name.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.textBox_Name.ForeColor = System.Drawing.Color.White;
            this.textBox_Name.Location = new System.Drawing.Point(347, 292);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(175, 25);
            this.textBox_Name.TabIndex = 1;
            this.textBox_Name.Text = "Test";
            // 
            // textBox_PW
            // 
            this.textBox_PW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.textBox_PW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PW.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.textBox_PW.ForeColor = System.Drawing.Color.White;
            this.textBox_PW.Location = new System.Drawing.Point(347, 335);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.PasswordChar = '*';
            this.textBox_PW.Size = new System.Drawing.Size(175, 25);
            this.textBox_PW.TabIndex = 2;
            this.textBox_PW.Text = "Test";
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.Transparent;
            this.button_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Login.BackgroundImage")));
            this.button_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Login.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.button_Login.FlatAppearance.BorderSize = 0;
            this.button_Login.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Login.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Login.ForeColor = System.Drawing.Color.LemonChiffon;
            this.button_Login.Location = new System.Drawing.Point(305, 388);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(90, 39);
            this.button_Login.TabIndex = 3;
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            this.button_Login.MouseEnter += new System.EventHandler(this.button_Login_Enter);
            this.button_Login.MouseLeave += new System.EventHandler(this.button_Login_Leave);
            // 
            // label_Tips
            // 
            this.label_Tips.AutoSize = true;
            this.label_Tips.BackColor = System.Drawing.Color.Transparent;
            this.label_Tips.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.label_Tips.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_Tips.Location = new System.Drawing.Point(13, 564);
            this.label_Tips.Name = "label_Tips";
            this.label_Tips.Size = new System.Drawing.Size(65, 25);
            this.label_Tips.TabIndex = 4;
            this.label_Tips.Text = "label1";
            // 
            // frm_Login
            // 
            this.AcceptButton = this.button_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label_Tips);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_PW);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.button_Exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.Label label_Tips;
    }
}

