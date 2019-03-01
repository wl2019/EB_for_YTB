namespace YTB
{
    partial class frm_Prod_Type
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Topic = new System.Windows.Forms.Label();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Edit = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBoxInf = new System.Windows.Forms.GroupBox();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_SrvUserName = new System.Windows.Forms.Label();
            this.textBox_Code = new System.Windows.Forms.TextBox();
            this.label_SrvIP = new System.Windows.Forms.Label();
            this.button_Undo = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Exit.Location = new System.Drawing.Point(601, 365);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(77, 40);
            this.button_Exit.TabIndex = 30;
            this.button_Exit.Text = "退出(&O)";
            this.button_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(51, 23);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(209, 12);
            this.label_Topic.TabIndex = 41;
            this.label_Topic.Text = "功能说明：用于设置商品的分类信息。";
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.dataGridView1);
            this.groupBoxList.Controls.Add(this.button_Del);
            this.groupBoxList.Controls.Add(this.button_Edit);
            this.groupBoxList.Controls.Add(this.button_Add);
            this.groupBoxList.Location = new System.Drawing.Point(12, 50);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(409, 367);
            this.groupBoxList.TabIndex = 42;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "商品分类列表：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(381, 272);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_Del
            // 
            this.button_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Del.Location = new System.Drawing.Point(293, 312);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(77, 40);
            this.button_Del.TabIndex = 33;
            this.button_Del.Text = "删除(&D)";
            this.button_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Visible = false;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Edit
            // 
            this.button_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Edit.Location = new System.Drawing.Point(210, 312);
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
            this.button_Add.Location = new System.Drawing.Point(127, 312);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(77, 40);
            this.button_Add.TabIndex = 31;
            this.button_Add.Text = "新增(&A)";
            this.button_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // groupBoxInf
            // 
            this.groupBoxInf.Controls.Add(this.textBox_Desc);
            this.groupBoxInf.Controls.Add(this.label_Database);
            this.groupBoxInf.Controls.Add(this.textBox_Name);
            this.groupBoxInf.Controls.Add(this.label_SrvUserName);
            this.groupBoxInf.Controls.Add(this.textBox_Code);
            this.groupBoxInf.Controls.Add(this.label_SrvIP);
            this.groupBoxInf.Controls.Add(this.button_Undo);
            this.groupBoxInf.Controls.Add(this.button_Save);
            this.groupBoxInf.Location = new System.Drawing.Point(437, 50);
            this.groupBoxInf.Name = "groupBoxInf";
            this.groupBoxInf.Size = new System.Drawing.Size(284, 309);
            this.groupBoxInf.TabIndex = 43;
            this.groupBoxInf.TabStop = false;
            this.groupBoxInf.Text = "商品分类明细：";
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Desc.Location = new System.Drawing.Point(34, 188);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.Size = new System.Drawing.Size(223, 59);
            this.textBox_Desc.TabIndex = 39;
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Database.Location = new System.Drawing.Point(27, 160);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(109, 20);
            this.label_Database.TabIndex = 38;
            this.label_Database.Text = "分类特点：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Name.Location = new System.Drawing.Point(34, 123);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(154, 30);
            this.textBox_Name.TabIndex = 37;
            // 
            // label_SrvUserName
            // 
            this.label_SrvUserName.AutoSize = true;
            this.label_SrvUserName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvUserName.Location = new System.Drawing.Point(27, 95);
            this.label_SrvUserName.Name = "label_SrvUserName";
            this.label_SrvUserName.Size = new System.Drawing.Size(109, 20);
            this.label_SrvUserName.TabIndex = 36;
            this.label_SrvUserName.Text = "分类名称：";
            // 
            // textBox_Code
            // 
            this.textBox_Code.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Code.Location = new System.Drawing.Point(34, 63);
            this.textBox_Code.Name = "textBox_Code";
            this.textBox_Code.Size = new System.Drawing.Size(154, 30);
            this.textBox_Code.TabIndex = 35;
            // 
            // label_SrvIP
            // 
            this.label_SrvIP.AutoSize = true;
            this.label_SrvIP.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SrvIP.Location = new System.Drawing.Point(27, 34);
            this.label_SrvIP.Name = "label_SrvIP";
            this.label_SrvIP.Size = new System.Drawing.Size(109, 20);
            this.label_SrvIP.TabIndex = 34;
            this.label_SrvIP.Text = "分类编号：";
            // 
            // button_Undo
            // 
            this.button_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Undo.Location = new System.Drawing.Point(164, 258);
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
            this.button_Save.Location = new System.Drawing.Point(81, 258);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(77, 40);
            this.button_Save.TabIndex = 32;
            this.button_Save.Text = "保存(&S)";
            this.button_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // frm_Prod_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Exit;
            this.ClientSize = new System.Drawing.Size(734, 429);
            this.Controls.Add(this.groupBoxInf);
            this.Controls.Add(this.groupBoxList);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Exit);
            this.Name = "frm_Prod_Type";
            this.Text = "商品分类信息";
            this.Load += new System.EventHandler(this.frm_Prod_Type_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxInf.ResumeLayout(false);
            this.groupBoxInf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Edit;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.GroupBox groupBoxInf;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_SrvUserName;
        private System.Windows.Forms.TextBox textBox_Code;
        private System.Windows.Forms.Label label_SrvIP;
    }
}