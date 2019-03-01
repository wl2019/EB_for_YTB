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
    public partial class frm_Duty_Pwd : Form
    {
        public frm_Duty_Pwd()
        {
            InitializeComponent();
        }

        private void frm_Duty_Pwd_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            label_Topic.Text = "功能说明：用于修改登录密码。修改成功后，\r\n";
            label_Topic.Text += "          退出登录系统后，新密码生效。\r\n";
            label_Topic.Text += "          新密码长度不超过8字符";
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(textBox_Old_Pwd.Text.Trim().ToUpper().CompareTo(MyStart.gszUserPwd.ToUpper())!=0)
            {
                MessageBox.Show("旧密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Old_Pwd.Focus();
                return;
            }

            if(textBox_New_Pwd.Text.CompareTo(textBox_2nd_Pwd.Text)!=0)
            {
                MessageBox.Show("两次输入的新密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_New_Pwd.Focus();
                return;
            }

            string szNewPwd = MyTools.OpenString_To_HideString((textBox_New_Pwd.Text + "        ").Substring(0, 8),
                MyStart.gszPwdKey); 
            string szSql = "UPDATE sys_users SET USER_PWD = '" + szNewPwd
                + "' WHERE USER_ID=" + MyStart.giUserID;
            string szErr="";
            try
            {
                int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("更改密码失败（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("当班人员－更改密码", "SQL=" + szSql + ",Err=" + szErr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更改密码失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();

            MyFunc.WriteToDbLog("当班人员－更改密码", "", "MSG", MyStart.giUserID);
            MessageBox.Show("更改密码成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
