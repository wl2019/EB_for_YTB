namespace YTB
{
    partial class frm_Setup_Key
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Setup_Key));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_Define = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.comboBox_ProdList = new System.Windows.Forms.ComboBox();
            this.label_ProdName = new System.Windows.Forms.Label();
            this.label_KeyName = new System.Windows.Forms.Label();
            this.button_15 = new System.Windows.Forms.Button();
            this.button_14 = new System.Windows.Forms.Button();
            this.button_13 = new System.Windows.Forms.Button();
            this.button_12 = new System.Windows.Forms.Button();
            this.button_11 = new System.Windows.Forms.Button();
            this.button_10 = new System.Windows.Forms.Button();
            this.button_09 = new System.Windows.Forms.Button();
            this.button_08 = new System.Windows.Forms.Button();
            this.button_07 = new System.Windows.Forms.Button();
            this.button_06 = new System.Windows.Forms.Button();
            this.button_05 = new System.Windows.Forms.Button();
            this.button_04 = new System.Windows.Forms.Button();
            this.button_03 = new System.Windows.Forms.Button();
            this.button_02 = new System.Windows.Forms.Button();
            this.button_01 = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(22, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(770, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "设置说明";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(26, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(538, 21);
            label2.TabIndex = 1;
            label2.Text = "对应一个商品的名称，本功能用于对这些键进行设置，以关联对应的商品。";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(60, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(702, 21);
            label1.TabIndex = 0;
            label1.Text = "在秤终端专用键盘的左面，倒数的第1～3排共14个按键是设计作为商品名称输入的快捷键，每个键";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("宋体", 12F);
            label3.Location = new System.Drawing.Point(365, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(104, 16);
            label3.TabIndex = 20;
            label3.Text = "选中按键名称";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("宋体", 12F);
            label4.Location = new System.Drawing.Point(365, 105);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 16);
            label4.TabIndex = 22;
            label4.Text = "现在对应商品";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("宋体", 12F);
            label5.Location = new System.Drawing.Point(365, 156);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 16);
            label5.TabIndex = 24;
            label5.Text = "更改对应商品";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_Define);
            this.groupBox2.Controls.Add(this.button_Save);
            this.groupBox2.Controls.Add(this.comboBox_ProdList);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.label_ProdName);
            this.groupBox2.Controls.Add(this.label_KeyName);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.button_15);
            this.groupBox2.Controls.Add(this.button_14);
            this.groupBox2.Controls.Add(this.button_13);
            this.groupBox2.Controls.Add(this.button_12);
            this.groupBox2.Controls.Add(this.button_11);
            this.groupBox2.Controls.Add(this.button_10);
            this.groupBox2.Controls.Add(this.button_09);
            this.groupBox2.Controls.Add(this.button_08);
            this.groupBox2.Controls.Add(this.button_07);
            this.groupBox2.Controls.Add(this.button_06);
            this.groupBox2.Controls.Add(this.button_05);
            this.groupBox2.Controls.Add(this.button_04);
            this.groupBox2.Controls.Add(this.button_03);
            this.groupBox2.Controls.Add(this.button_02);
            this.groupBox2.Controls.Add(this.button_01);
            this.groupBox2.Location = new System.Drawing.Point(22, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 272);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编辑按键";
            // 
            // button_Define
            // 
            this.button_Define.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Define.Location = new System.Drawing.Point(543, 213);
            this.button_Define.Name = "button_Define";
            this.button_Define.Size = new System.Drawing.Size(80, 36);
            this.button_Define.TabIndex = 26;
            this.button_Define.Text = "定义(&D)";
            this.button_Define.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Define.UseVisualStyleBackColor = true;
            this.button_Define.Visible = false;
            this.button_Define.Click += new System.EventHandler(this.button_Define_Click);
            // 
            // button_Save
            // 
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Save.Location = new System.Drawing.Point(657, 213);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(80, 36);
            this.button_Save.TabIndex = 27;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox_ProdList
            // 
            this.comboBox_ProdList.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_ProdList.FormattingEnabled = true;
            this.comboBox_ProdList.Location = new System.Drawing.Point(472, 152);
            this.comboBox_ProdList.Name = "comboBox_ProdList";
            this.comboBox_ProdList.Size = new System.Drawing.Size(252, 24);
            this.comboBox_ProdList.TabIndex = 25;
            // 
            // label_ProdName
            // 
            this.label_ProdName.BackColor = System.Drawing.SystemColors.Control;
            this.label_ProdName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_ProdName.Font = new System.Drawing.Font("宋体", 12F);
            this.label_ProdName.Location = new System.Drawing.Point(472, 101);
            this.label_ProdName.Name = "label_ProdName";
            this.label_ProdName.Size = new System.Drawing.Size(252, 21);
            this.label_ProdName.TabIndex = 23;
            this.label_ProdName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_KeyName
            // 
            this.label_KeyName.BackColor = System.Drawing.SystemColors.Control;
            this.label_KeyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_KeyName.Font = new System.Drawing.Font("宋体", 12F);
            this.label_KeyName.Location = new System.Drawing.Point(472, 50);
            this.label_KeyName.Name = "label_KeyName";
            this.label_KeyName.Size = new System.Drawing.Size(252, 21);
            this.label_KeyName.TabIndex = 21;
            this.label_KeyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_15
            // 
            this.button_15.Enabled = false;
            this.button_15.Location = new System.Drawing.Point(45, 47);
            this.button_15.Name = "button_15";
            this.button_15.Size = new System.Drawing.Size(52, 43);
            this.button_15.TabIndex = 14;
            this.button_15.Text = "L15";
            this.button_15.UseVisualStyleBackColor = true;
            this.button_15.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_14
            // 
            this.button_14.Location = new System.Drawing.Point(102, 47);
            this.button_14.Name = "button_14";
            this.button_14.Size = new System.Drawing.Size(52, 43);
            this.button_14.TabIndex = 13;
            this.button_14.Text = "L14";
            this.button_14.UseVisualStyleBackColor = true;
            this.button_14.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_13
            // 
            this.button_13.Location = new System.Drawing.Point(159, 47);
            this.button_13.Name = "button_13";
            this.button_13.Size = new System.Drawing.Size(52, 43);
            this.button_13.TabIndex = 12;
            this.button_13.Text = "L13";
            this.button_13.UseVisualStyleBackColor = true;
            this.button_13.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_12
            // 
            this.button_12.Location = new System.Drawing.Point(216, 47);
            this.button_12.Name = "button_12";
            this.button_12.Size = new System.Drawing.Size(52, 43);
            this.button_12.TabIndex = 11;
            this.button_12.Text = "L12";
            this.button_12.UseVisualStyleBackColor = true;
            this.button_12.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_11
            // 
            this.button_11.Location = new System.Drawing.Point(273, 47);
            this.button_11.Name = "button_11";
            this.button_11.Size = new System.Drawing.Size(52, 43);
            this.button_11.TabIndex = 10;
            this.button_11.Text = "L11";
            this.button_11.UseVisualStyleBackColor = true;
            this.button_11.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_10
            // 
            this.button_10.Location = new System.Drawing.Point(45, 116);
            this.button_10.Name = "button_10";
            this.button_10.Size = new System.Drawing.Size(52, 43);
            this.button_10.TabIndex = 9;
            this.button_10.Text = "L10";
            this.button_10.UseVisualStyleBackColor = true;
            this.button_10.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_09
            // 
            this.button_09.Location = new System.Drawing.Point(102, 115);
            this.button_09.Name = "button_09";
            this.button_09.Size = new System.Drawing.Size(52, 43);
            this.button_09.TabIndex = 8;
            this.button_09.Text = "L09";
            this.button_09.UseVisualStyleBackColor = true;
            this.button_09.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_08
            // 
            this.button_08.Location = new System.Drawing.Point(159, 116);
            this.button_08.Name = "button_08";
            this.button_08.Size = new System.Drawing.Size(52, 43);
            this.button_08.TabIndex = 7;
            this.button_08.Text = "L08";
            this.button_08.UseVisualStyleBackColor = true;
            this.button_08.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_07
            // 
            this.button_07.Location = new System.Drawing.Point(216, 115);
            this.button_07.Name = "button_07";
            this.button_07.Size = new System.Drawing.Size(52, 43);
            this.button_07.TabIndex = 6;
            this.button_07.Text = "L07";
            this.button_07.UseVisualStyleBackColor = true;
            this.button_07.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_06
            // 
            this.button_06.Location = new System.Drawing.Point(273, 115);
            this.button_06.Name = "button_06";
            this.button_06.Size = new System.Drawing.Size(52, 43);
            this.button_06.TabIndex = 5;
            this.button_06.Text = "L06";
            this.button_06.UseVisualStyleBackColor = true;
            this.button_06.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_05
            // 
            this.button_05.Location = new System.Drawing.Point(45, 183);
            this.button_05.Name = "button_05";
            this.button_05.Size = new System.Drawing.Size(52, 43);
            this.button_05.TabIndex = 4;
            this.button_05.Text = "L05";
            this.button_05.UseVisualStyleBackColor = true;
            this.button_05.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_04
            // 
            this.button_04.Location = new System.Drawing.Point(102, 183);
            this.button_04.Name = "button_04";
            this.button_04.Size = new System.Drawing.Size(52, 43);
            this.button_04.TabIndex = 3;
            this.button_04.Text = "L04";
            this.button_04.UseVisualStyleBackColor = true;
            this.button_04.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_03
            // 
            this.button_03.Location = new System.Drawing.Point(159, 183);
            this.button_03.Name = "button_03";
            this.button_03.Size = new System.Drawing.Size(52, 43);
            this.button_03.TabIndex = 2;
            this.button_03.Text = "L03";
            this.button_03.UseVisualStyleBackColor = true;
            this.button_03.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_02
            // 
            this.button_02.Location = new System.Drawing.Point(216, 183);
            this.button_02.Name = "button_02";
            this.button_02.Size = new System.Drawing.Size(52, 43);
            this.button_02.TabIndex = 1;
            this.button_02.Text = "L02";
            this.button_02.UseVisualStyleBackColor = true;
            this.button_02.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_01
            // 
            this.button_01.BackColor = System.Drawing.SystemColors.Control;
            this.button_01.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.button_01.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.button_01.Location = new System.Drawing.Point(273, 183);
            this.button_01.Name = "button_01";
            this.button_01.Size = new System.Drawing.Size(52, 43);
            this.button_01.TabIndex = 0;
            this.button_01.Text = "L01";
            this.button_01.UseVisualStyleBackColor = true;
            this.button_01.Click += new System.EventHandler(this.button_20_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Exit.Location = new System.Drawing.Point(679, 426);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(80, 36);
            this.button_Exit.TabIndex = 29;
            this.button_Exit.Text = "退出(&X)";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // frm_Setup_Key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(816, 474);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Setup_Key";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快捷键设置功能";
            this.Load += new System.EventHandler(this.frm_Def_Key_Load);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ComboBox comboBox_ProdList;
        private System.Windows.Forms.Label label_ProdName;
        private System.Windows.Forms.Label label_KeyName;
        private System.Windows.Forms.Button button_15;
        private System.Windows.Forms.Button button_14;
        private System.Windows.Forms.Button button_13;
        private System.Windows.Forms.Button button_12;
        private System.Windows.Forms.Button button_11;
        private System.Windows.Forms.Button button_10;
        private System.Windows.Forms.Button button_09;
        private System.Windows.Forms.Button button_08;
        private System.Windows.Forms.Button button_07;
        private System.Windows.Forms.Button button_06;
        private System.Windows.Forms.Button button_05;
        private System.Windows.Forms.Button button_04;
        private System.Windows.Forms.Button button_03;
        private System.Windows.Forms.Button button_02;
        private System.Windows.Forms.Button button_01;
        private System.Windows.Forms.Button button_Define;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Exit;
    }
}