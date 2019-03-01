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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            label_Tips.Text = "欢迎光临！请按提示输入登录名称和密码。";
            textBox_Name.Text = MyStart.gszSysLogin;// "test"; //"";//
            textBox_PW.Text =  "123";//"";//

            this.Show();
            textBox_Name.Focus();
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            //String szYear = System.DateTime.Now.Year.ToString();
            //int iMonth = System.DateTime.Now.Month;
            //if (System.DateTime.Now > DateTime.Parse("2018.12.31"))
            //{
            //    MessageBox.Show("读程序参数错误，请检查!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select user_pwd,user_id,USER_APP,USER_NAME,USER_STAT from sys_users where user_login='" + textBox_Name.Text.Trim() + "'";// and USER_STAT='STOP'";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            MyStart.oMyDb.Close();

            if (iRst != 0)
            {
                MessageBox.Show("连接数据库失败（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("登录", "SQL=" + szSql + ",Err=" + szErr);
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum !=1)
            {
                MessageBox.Show("没有用户信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("登录", "SQL=" + szSql + ",Err=没有用户信息");
                return;
            }

            DataRow dr = ds.Tables[0].Rows[0];
            if(dr[4].ToString().ToUpper()=="STOP")
            {
                MessageBox.Show("该帐号已停用，请重新登录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("登录", "SQL=" + szSql + ",Err=该帐号已停用，请重新登录");
                textBox_Name.Focus();
                return;
            }

            string szPwd = MyTools.HideString_To_OpenString(dr[0].ToString(),MyStart.gszPwdKey);
            if (textBox_PW.Text.Trim() == szPwd.Trim())
            {
                MyStart.giUserID = Convert.ToInt16(dr[1]);
                MyStart.gszUserPwd = textBox_PW.Text.Trim();
                MyStart.gszUserApp = dr[2].ToString();
                MyStart.gszUsername = dr[3].ToString();
                MyStart.UserCheckIn = true;

                string sIniFileName = Application.StartupPath + "\\YTB.ini";
                int sI = 0;
                string sErrorMessage = "";
                MyStart.gszSysLogin = textBox_Name.Text;
                sI = MyIniFile.SetIniKeyValue(sIniFileName, "Sys", "Login", MyStart.gszSysLogin);
                if (sI < 0)
                {
                    sErrorMessage = "保存 " + sIniFileName + "文件的操作员信息" + " 项时出错";
                    MessageBox.Show("操作错误：" + sErrorMessage + "。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("登录信息错误，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Name.Focus();
                return;
            }
        }

        private void button_Login_Leave(object sender, EventArgs e)
        {
            button_Login.BackColor = Color.Transparent;
        }

        private void button_Login_Enter(object sender, EventArgs e)
        {
            button_Login.BackColor = Color.SkyBlue;
        }

        private void button_Exit_Enter(object sender, EventArgs e)
        {
            button_Exit.BackColor = Color.SkyBlue;
        }

        private void button_Exit_Leave(object sender, EventArgs e)
        {
            button_Exit.BackColor = Color.Transparent;
        }
    }
}
