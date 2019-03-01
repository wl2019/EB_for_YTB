using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YTB
{
    public partial class frm_Duty_Pause : Form
    {
        int BackPictMark = 0;
        public frm_Duty_Pause()
        {
            InitializeComponent();
            BackPictMark = 0;
        }

        private void SetControl(int iSetModel)
        {
            if (iSetModel == 0)
            {
                BackPictMark = 0;
                this.BackgroundImage = global::YTB.Properties.Resources.TakeRest04;
                label_LoginName.Visible = false;
                textBox_LoginName.Visible = false;
                button_ReLogin.Visible = false;
                button_Rest.Visible = false;
            }
            else
            {
                this.BackgroundImage = global::YTB.Properties.Resources.TakeRestEmpty02;
                label_LoginName.Visible = true;
                textBox_LoginName.Visible = true;
                button_ReLogin.Visible = true;
                button_Rest.Visible = true;

                textBox_LoginName.Focus();
            }
        }
        private void frm_Duty_Pause_Load(object sender, EventArgs e)
        {
            BackPictMark = 0;
            SetControl(0);
        }

        private void button_Rest_Click(object sender, EventArgs e)
        {
            BackPictMark = 0;
            SetControl(0);
            textBox_LoginName.Text = "";
        }

        private void button_ReLogin_Click(object sender, EventArgs e)
        {
            textBox_LoginName.Text = textBox_LoginName.Text.Trim();

            if (textBox_LoginName.Text != MyStart.gszUserPwd)
            {
                MessageBox.Show("密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //textBox_LoginName.SelectionLength = textBox_LoginName.Text.Length;
                textBox_LoginName.Focus();
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void frm_Duty_Pause_Click(object sender, EventArgs e)
        {
            if (BackPictMark == 0)
            {
                BackPictMark = 1;
                SetControl(BackPictMark);
            }
        }
    }
}
