namespace YTB
{
    partial class frm_Firm_Rent
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
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.radioButton_End = new System.Windows.Forms.RadioButton();
            this.radioButton_Bgn = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker_valid = new System.Windows.Forms.DateTimePicker();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.textBox_Cell = new System.Windows.Forms.TextBox();
            this.textBox_Person = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.comboBox_Firm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
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
            this.button_Exit.Location = new System.Drawing.Point(807, 429);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 53;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.comboBox_Name);
            this.groupBoxInf.Controls.Add(this.radioButton_End);
            this.groupBoxInf.Controls.Add(this.radioButton_Bgn);
            this.groupBoxInf.Controls.Add(this.label11);
            this.groupBoxInf.Controls.Add(this.dateTimePicker_valid);
            this.groupBoxInf.Controls.Add(this.textBox_Desc);
            this.groupBoxInf.Controls.Add(this.textBox_Cell);
            this.groupBoxInf.Controls.Add(this.textBox_Person);
            this.groupBoxInf.Controls.Add(this.label7);
            this.groupBoxInf.Controls.Add(this.label2);
            this.groupBoxInf.Controls.Add(this.label4);
            this.groupBoxInf.Controls.Add(this.textBox_Code);
            this.groupBoxInf.Controls.Add(this.label_SrvIP);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Location = new System.Drawing.Point(16, 315);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(785, 171);
            this.groupBoxInf.TabIndex = 56;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "档口详情：";
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(98, 18);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(245, 28);
            this.comboBox_Name.TabIndex = 45;
            // 
            // radioButton_End
            // 
            this.radioButton_End.AutoSize = true;
            this.radioButton_End.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton_End.Location = new System.Drawing.Point(397, 62);
            this.radioButton_End.Name = "radioButton_End";
            this.radioButton_End.Size = new System.Drawing.Size(90, 20);
            this.radioButton_End.TabIndex = 44;
            this.radioButton_End.TabStop = true;
            this.radioButton_End.Text = "退租日期";
            this.radioButton_End.UseVisualStyleBackColor = true;
            // 
            // radioButton_Bgn
            // 
            this.radioButton_Bgn.AutoSize = true;
            this.radioButton_Bgn.Font = new System.Drawing.Font("宋体", 12F);
            this.radioButton_Bgn.Location = new System.Drawing.Point(300, 62);
            this.radioButton_Bgn.Name = "radioButton_Bgn";
            this.radioButton_Bgn.Size = new System.Drawing.Size(90, 20);
            this.radioButton_Bgn.TabIndex = 44;
            this.radioButton_Bgn.TabStop = true;
            this.radioButton_Bgn.Text = "租用日期";
            this.radioButton_Bgn.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "联系电话：";
            // 
            // dateTimePicker_valid
            // 
            this.dateTimePicker_valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_valid.Location = new System.Drawing.Point(497, 56);
            this.dateTimePicker_valid.Name = "dateTimePicker_valid";
            this.dateTimePicker_valid.Size = new System.Drawing.Size(162, 26);
            this.dateTimePicker_valid.TabIndex = 41;
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Desc.Location = new System.Drawing.Point(357, 98);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.Size = new System.Drawing.Size(302, 56);
            this.textBox_Desc.TabIndex = 37;
            // 
            // textBox_Cell
            // 
            this.textBox_Cell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cell.Location = new System.Drawing.Point(98, 128);
            this.textBox_Cell.Name = "textBox_Cell";
            this.textBox_Cell.Size = new System.Drawing.Size(167, 26);
            this.textBox_Cell.TabIndex = 37;
            // 
            // textBox_Person
            // 
            this.textBox_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Person.Location = new System.Drawing.Point(98, 92);
            this.textBox_Person.Name = "textBox_Person";
            this.textBox_Person.Size = new System.Drawing.Size(167, 26);
            this.textBox_Person.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(300, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "备注：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "联系人：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "卖方名称：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Code.Location = new System.Drawing.Point(98, 56);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(128, 26);
            this.textBox_Code.TabIndex = 35;
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SrvIP.Location = new System.Drawing.Point(10, 62);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(89, 20);
            this.label_SrvIP.TabIndex = 34;
            this.label_SrvIP.Text = "档口编号：";
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(681, 100);
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
            this.button_Save.Location = new System.Drawing.Point(681, 49);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 32;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(55, 23);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(233, 12);
            this.label_Topic.TabIndex = 54;
            this.label_Topic.Text = "功能说明：用于设置卖方租用档口的信息。";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.comboBox_Firm);
            this.groupBoxList.Controls.Add(this.label1);
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Controls.Add(this.button_Del);
            this.groupBoxList.Controls.Add(this.button_Edit);
            this.groupBoxList.Controls.Add(this.button_Add);
            this.groupBoxList.Location = new System.Drawing.Point(16, 50);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(868, 258);
            this.groupBoxList.TabIndex = 55;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "档口列表：";
            // 
            // comboBox_Firm
            // 
            this.comboBox_Firm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Firm.FormattingEnabled = true;
            this.comboBox_Firm.Location = new System.Drawing.Point(106, 216);
            this.comboBox_Firm.Name = "comboBox_Firm";
            this.comboBox_Firm.Size = new System.Drawing.Size(245, 28);
            this.comboBox_Firm.TabIndex = 42;
            this.comboBox_Firm.SelectedIndexChanged += new System.EventHandler(this.comboBox_Firm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "指定卖方：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(836, 184);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(764, 212);
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
            this.button_Edit.Location = new System.Drawing.Point(681, 212);
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
            this.button_Add.Location = new System.Drawing.Point(598, 212);
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
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Firm_Rent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(895, 499);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.groupBoxList);
            this.Name = "frm_Firm_Rent";
            this.Text = "卖方租用档铺信息";
            this.Load += new System.EventHandler(this.frm_Firm_Rent_Load);
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            this.groupBoxList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker_valid;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.TextBox textBox_Cell;
        private System.Windows.Forms.TextBox textBox_Person;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.ComboBox comboBox_Firm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_End;
        private System.Windows.Forms.RadioButton radioButton_Bgn;
        private System.Windows.Forms.ComboBox comboBox_Name;
    }
}