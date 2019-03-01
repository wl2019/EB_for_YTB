namespace YTB
{
    partial class frm_Prod_Fee
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
            this.label_Topic = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.radioButton_Name = new System.Windows.Forms.RadioButton();
            this.radioButton_Type = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Bgn = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.comboBox_Type_Rate = new System.Windows.Forms.ComboBox();
            this.comboBox_Type_Prod = new System.Windows.Forms.ComboBox();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_Rate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
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
            this.button_Exit.Location = new System.Drawing.Point(897, 501);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 30;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(51, 23);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(209, 12);
            this.label_Topic.TabIndex = 45;
            this.label_Topic.Text = "功能说明：用于设置商品的收费情况。";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.radioButton_Name);
            this.groupBoxInf.Controls.Add(this.radioButton_Type);
            this.groupBoxInf.Controls.Add(this.dateTimePicker_End);
            this.groupBoxInf.Controls.Add(this.dateTimePicker_Bgn);
            this.groupBoxInf.Controls.Add(this.comboBox_Name);
            this.groupBoxInf.Controls.Add(this.comboBox_Type_Rate);
            this.groupBoxInf.Controls.Add(this.comboBox_Type_Prod);
            this.groupBoxInf.Controls.Add(this.textBox_Desc);
            this.groupBoxInf.Controls.Add(this.label_Database);
            this.groupBoxInf.Controls.Add(this.textBox_Rate);
            this.groupBoxInf.Controls.Add(this.label6);
            this.groupBoxInf.Controls.Add(this.label_SrvUserName);
            this.groupBoxInf.Controls.Add(this.label3);
            this.groupBoxInf.Controls.Add(this.label5);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.label1);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Location = new System.Drawing.Point(726, 50);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(284, 445);
            this.groupBoxInf.TabIndex = 49;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "收费明细：";
            // 
            // radioButton_Name
            // 
            this.radioButton_Name.AutoSize = true;
            this.radioButton_Name.Font = new System.Drawing.Font("宋体", 15F);
            this.radioButton_Name.Location = new System.Drawing.Point(15, 45);
            this.radioButton_Name.Name = "radioButton_Name";
            this.radioButton_Name.Size = new System.Drawing.Size(207, 24);
            this.radioButton_Name.TabIndex = 42;
            this.radioButton_Name.Text = "按明细商品设置费率";
            this.radioButton_Name.UseVisualStyleBackColor = true;
            this.radioButton_Name.Click += new System.EventHandler(this.radioButton_Name_Click);
            // 
            // radioButton_Type
            // 
            this.radioButton_Type.AutoSize = true;
            this.radioButton_Type.Checked = true;
            this.radioButton_Type.Font = new System.Drawing.Font("宋体", 15F);
            this.radioButton_Type.Location = new System.Drawing.Point(15, 19);
            this.radioButton_Type.Name = "radioButton_Type";
            this.radioButton_Type.Size = new System.Drawing.Size(207, 24);
            this.radioButton_Type.TabIndex = 42;
            this.radioButton_Type.TabStop = true;
            this.radioButton_Type.Text = "按分类商品设置费率";
            this.radioButton_Type.UseVisualStyleBackColor = true;
            this.radioButton_Type.Click += new System.EventHandler(this.radioButton_Type_Click);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Font = new System.Drawing.Font("宋体", 15F);
            this.dateTimePicker_End.Location = new System.Drawing.Point(110, 253);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(166, 30);
            this.dateTimePicker_End.TabIndex = 41;
            // 
            // dateTimePicker_Bgn
            // 
            this.dateTimePicker_Bgn.Font = new System.Drawing.Font("宋体", 15F);
            this.dateTimePicker_Bgn.Location = new System.Drawing.Point(110, 217);
            this.dateTimePicker_Bgn.Name = "dateTimePicker_Bgn";
            this.dateTimePicker_Bgn.Size = new System.Drawing.Size(166, 30);
            this.dateTimePicker_Bgn.TabIndex = 41;
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.Font = new System.Drawing.Font("宋体", 15F);
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(110, 110);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(166, 28);
            this.comboBox_Name.TabIndex = 40;
            // 
            // comboBox_Type_Rate
            // 
            this.comboBox_Type_Rate.Font = new System.Drawing.Font("宋体", 15F);
            this.comboBox_Type_Rate.FormattingEnabled = true;
            this.comboBox_Type_Rate.Location = new System.Drawing.Point(110, 144);
            this.comboBox_Type_Rate.Name = "comboBox_Type_Rate";
            this.comboBox_Type_Rate.Size = new System.Drawing.Size(166, 28);
            this.comboBox_Type_Rate.TabIndex = 40;
            // 
            // comboBox_Type_Prod
            // 
            this.comboBox_Type_Prod.Font = new System.Drawing.Font("宋体", 15F);
            this.comboBox_Type_Prod.FormattingEnabled = true;
            this.comboBox_Type_Prod.Location = new System.Drawing.Point(110, 76);
            this.comboBox_Type_Prod.Name = "comboBox_Type_Prod";
            this.comboBox_Type_Prod.Size = new System.Drawing.Size(166, 28);
            this.comboBox_Type_Prod.TabIndex = 40;
            this.comboBox_Type_Prod.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_Prod_SelectedIndexChanged);
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Desc.Location = new System.Drawing.Point(14, 326);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.Size = new System.Drawing.Size(262, 59);
            this.textBox_Desc.TabIndex = 39;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Database.Location = new System.Drawing.Point(10, 296);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(69, 20);
            this.label_Database.TabIndex = 38;
            this.label_Database.Text = "备注：";
            // 
            // textBox_Rate
            // 
            this.textBox_Rate.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Rate.Location = new System.Drawing.Point(110, 178);
            this.textBox_Rate.Name = "textBox_Rate";
            this.textBox_Rate.Size = new System.Drawing.Size(53, 30);
            this.textBox_Rate.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(10, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "商品分类：";
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 15F);
            this.label_SrvUserName.Location = new System.Drawing.Point(10, 116);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(109, 20);
            this.label_SrvUserName.TabIndex = 36;
            this.label_SrvUserName.Text = "商品名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(167, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.Location = new System.Drawing.Point(10, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "失效日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(10, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "生效日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(10, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "收取费率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(10, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "收费类型：";
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(171, 393);
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
            this.button_Save.Location = new System.Drawing.Point(61, 393);
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
            this.groupBoxList.Location = new System.Drawing.Point(9, 50);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(711, 491);
            this.groupBoxList.TabIndex = 48;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "收费列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(694, 407);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(592, 439);
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
            this.button_Edit.Location = new System.Drawing.Point(491, 439);
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
            this.button_Add.Location = new System.Drawing.Point(390, 439);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(77, 40);
            this.button_Add.TabIndex = 31;
            this.button_Add.Text = "新增(&A)";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // frm_Prod_Fee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(1020, 548);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Prod_Fee";
            this.Text = "商品收费信息";
            this.Load += new System.EventHandler(this.frm_Prod_Fee_Load);
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
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.ComboBox comboBox_Type_Prod;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_Rate;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Bgn;
        private System.Windows.Forms.RadioButton radioButton_Name;
        private System.Windows.Forms.RadioButton radioButton_Type;
        private System.Windows.Forms.ComboBox comboBox_Name;
        private System.Windows.Forms.ComboBox comboBox_Type_Rate;
        private System.Windows.Forms.Label label6;
    }
}