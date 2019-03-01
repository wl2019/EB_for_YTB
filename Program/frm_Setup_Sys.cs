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
    public partial class frm_Setup_Sys : Form
    {
        public frm_Setup_Sys()
        {
            InitializeComponent();
        }

        private void frm_Setup_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Setup.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Setup.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Save.ico"));
            button_Quit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            string szComm = "Comm";
            comboBox_PS_Comm.Items.Clear();
            comboBox_Rdr_Comm.Items.Clear();
            for (int i=0;i<10;i++)
            {
                comboBox_Rdr_Comm.Items.Add(szComm + (i+1).ToString());
                comboBox_Rdr2_Comm.Items.Add(szComm + (i + 1).ToString());
                comboBox_PS_Comm.Items.Add(szComm + (i+1).ToString());
            }
            int[] iBaud = { 9600, 19200, 38400, 57200, 115200 };
            int iNum = iBaud.Length;
            for(int i=0;i<iNum;i++)
            {
                comboBox_Rdr_Baud.Items.Add(iBaud[i].ToString());
                comboBox_PS_Baud.Items.Add(iBaud[i].ToString());
            }

            textBox_SrvIP.Text = MyStart.gszDbIp;
            textBox_SrvPort.Text = MyStart.gszDbPort;
            textBox_SrvDataBase.Text = MyStart.gszDbSrv;
            textBox_SrvUserName.Text = MyStart.gszDbLogin;
            textBox_SrvUserPass.Text = MyStart.gszDbSrv;

            textBox_YTB_IP.Text = MyStart.gszYTBIp;
            textBox_YTB_PORT.Text = MyStart.gszYTBPort;

            comboBox_Rdr_Comm.Text = "Comm" + MyStart.gszRdrPort;
            comboBox_Rdr2_Comm.Text = "Comm" + MyStart.gszRdr2Port;
            comboBox_Rdr_Baud.Text = MyStart.gszRdrBaud;

            comboBox_PS_Comm.Text = "Comm" + MyStart.gszPsPort;
            comboBox_PS_Baud.Text = MyStart.gszPsBaud;

            groupBox_YTB.Enabled = false;
            groupBox_RDR.Enabled = false;
            groupBox_PS.Enabled = false;
            groupBox_Db.Enabled = false;
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;
            button_Exit.Select();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            button_Edit.Enabled = false;
            button_Save.Enabled = true;
            button_Quit.Enabled = true;
            button_Exit.Enabled = true;

            groupBox_YTB.Enabled = true;
            groupBox_RDR.Enabled = true;
            groupBox_PS.Enabled = true;
            groupBox_Db.Enabled = true;
            textBox_SrvIP.Select();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string sIniFileName = Application.StartupPath + "\\YTB.ini";
            int sI=0;
            string sErrorMessage = "";
            string sTmp;
            /*
            if (textBox_Pwd1.Text.Trim() != textBox_Pwd2.Text.Trim())
            {
                sI = -1;
                sErrorMessage = "两次输入的系统登录密码不相等，请更正";
                goto Eend;
            }
            if (textBox_Pwd1.Text.Length > 8)
            {
                sI = -1;
                sErrorMessage = "系统登录密码长度不能超过8个字节，请更正";
                goto Eend;
            }
            //if (textBox_SrvUserPass.Text.Length > 8)
            //{
            //    sI = -1;
            //    sErrorMessage = "数据库密码长度不能超过8个字节，请更正";
            //    goto Eend;
            //}
            */
            sI = -1;
            MyStart.gszDbIp = textBox_SrvIP.Text.Trim();
            MyStart.gszDbPort = textBox_SrvPort.Text.Trim();
            MyStart.gszDbLogin = textBox_SrvUserName.Text.Trim();
            MyStart.gszDbPwd = textBox_SrvUserPass.Text;
            MyStart.gszDbSrv = textBox_SrvDataBase.Text.Trim();

            MyStart.gszYTBIp= textBox_YTB_IP.Text ;
            MyStart.gszYTBPort= textBox_YTB_PORT.Text;

            MyStart.gszRdrPort= comboBox_Rdr_Comm.Text.Substring(4);
            MyStart.gszRdr2Port = comboBox_Rdr2_Comm.Text.Substring(4);
            MyStart.gszRdrBaud= comboBox_Rdr_Baud.Text;

            MyStart.gszPsPort= comboBox_PS_Comm.Text.Substring(4);
            MyStart.gszPsBaud= comboBox_PS_Baud.Text;

            /*sI = MyIniFile.SetIniKeyValue(sIniFileName, "Sys", "Login", MyStart.szSysLogin);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Sys.Login" + " 项时出错";
                goto Eend;
            }

            sTmp = MyTools.OpenString_To_HideString((textBox_Pwd1.Text + "        ").Substring(0, 8));
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Sys", "Pwd", sTmp);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Sys.Pwd" + " 项时出错";
                goto Eend;
            }*/

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Db", "IP", MyStart.gszDbIp);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Db.IP" + " 项时出错";
                goto Eend;
            }
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Db", "Port", MyStart.gszDbPort);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Db.Port" + " 项时出错";
                goto Eend;
            }
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Db", "Srv", MyStart.gszDbSrv);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Db.Srv" + " 项时出错";
                goto Eend;
            }
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Db", "Login", MyStart.gszDbLogin);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Db.Login" + " 项时出错";
                goto Eend;
            }
            if (textBox_SrvUserPass.Text.Length <= 8)
                sTmp = MyTools.OpenString_To_HideString((textBox_SrvUserPass.Text + "        ").Substring(0, 8),MyIniFile.mszIniKey);
            else
            {
                sTmp = MyTools.OpenString_To_HideString((textBox_SrvUserPass.Text.Substring(0, 8)), MyIniFile.mszIniKey);
                sTmp += MyTools.OpenString_To_HideString((textBox_SrvUserPass.Text.Substring(8) + "        ").Substring(0, 8), MyIniFile.mszIniKey);
            }
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Db", "Pwd", sTmp);
            if (sI < 0)
            {
                sErrorMessage = "保存 " + sIniFileName + "文件的 Db.Pwd" + " 项时出错";
                goto Eend;
            }

            string szErr = "";            
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "YTB_SRV", MyStart.gszYTBIp, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存益通宝平台.IP" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "YTB_PORT", MyStart.gszYTBPort, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存益通宝平台.端口" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "RDR_PORT", MyStart.gszRdrPort, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存读卡器.连接端口" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "RDR2_PORT", MyStart.gszRdr2Port, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存后台用读卡器.连接端口" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "RDR_BAUD", MyStart.gszRdrBaud, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存读卡器.连接波特率" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "PS_PORT", MyStart.gszPsPort, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存磅秤.连接端口" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "PS_BAUD", MyStart.gszPsBaud, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存磅秤.连接波特率" + " 项时出错";
                goto Eend;
            }

        Eend:
            //string sUserTZM = MyTools.sGetMachineTZM();
            //if (MyStart.sUserAuthCode == MyTools.sGetAuthCode(sUserTZM))
            //    MyStart.bAuthCodeIsOK = true;
            //else
            //    MyStart.bAuthCodeIsOK = false;
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;

            groupBox_YTB.Enabled = false;
            groupBox_RDR.Enabled = false;
            groupBox_PS.Enabled = false;
            groupBox_Db.Enabled = false;
            if (sI < 0)
            {
                MessageBox.Show("操作错误：" + sErrorMessage + "。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MyFunc.WriteToDbLog("修改系统参数", "", "MSG", MyStart.giUserID);
                //MessageBox.Show("Ini文件保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button_Exit.Select();
            MyStart.oMyDb.Close();
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            textBox_SrvIP.Text = MyStart.gszDbIp;
            textBox_SrvPort.Text = MyStart.gszDbPort;
            textBox_SrvDataBase.Text = MyStart.gszDbSrv;
            textBox_SrvUserName.Text = MyStart.gszDbLogin;
            textBox_SrvUserPass.Text = MyStart.gszDbSrv;

            textBox_YTB_IP.Text = MyStart.gszYTBIp;
            textBox_YTB_PORT.Text = MyStart.gszYTBPort;

            comboBox_Rdr_Comm.Text = "Comm" + MyStart.gszRdrPort;
            comboBox_Rdr2_Comm.Text = "Comm" + MyStart.gszRdr2Port;
            comboBox_Rdr_Baud.Text = MyStart.gszRdrBaud;

            comboBox_PS_Comm.Text = "Comm" + MyStart.gszPsPort;
            comboBox_PS_Baud.Text = MyStart.gszPsBaud;
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;

            groupBox_YTB.Enabled = false;
            groupBox_RDR.Enabled = false;
            groupBox_PS.Enabled = false;
            groupBox_Db.Enabled = false;
            button_Exit.Select();
        }

    }
}
