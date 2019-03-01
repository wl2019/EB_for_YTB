using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using System.Diagnostics;//Process
using System.IO;

namespace YTB
{
    static class MyStart
    {
        public static bool UserCheckIn = false;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static string gszDbIp, gszDbPort, gszDbSrv, gszDbLogin, gszDbPwd;//save by ini
        public static string gszSysLogin, gszSysPwd,gszSysCode;//, gszSysLogin0, gszSysPwd0;
        public static string gszYTBIp, gszYTBPort;
        public static string gszRdrPort, gszRdr2Port, gszRdrBaud,gszPsPort,gszPsBaud;
        public static string gszCardYtbFirst, gszCardFirmFirst, gszFirmID, gszPosID;
        public static string gszMrktName,gszMrktAddr,gszMrktTel,gszWeight;
        public static int giUserID, giFeeChgCard;
        //public static decimal giFeeChgCard;
        public static string gszUsername;
        public static string gszUserPwd, gszUserApp;
        public static string gszPwdKey= "1234567890ABCDEF13579ACE24680BDF";
        public static string gszHttpSrv;
        //public static bool bAuthCodeIsOK;

        public static CDb oMyDb;

        [STAThread]
        static void Main()
        {
            //Process current = Process.GetCurrentProcess();
            //Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //if (processes.GetLength(0) > 1)
            //{
            //    MessageBox.Show("该程序已经运行，请退出！", "系统提示",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            
            if (File.Exists(Application.StartupPath + "\\YTB.ini") != true)
            {
                MessageBox.Show("没有找到配置文件YTB.ini，请修改后再运行!", "系统提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MyFunc.GetSysParaFromIni(Application.StartupPath + MyIniFile.mszIniFile)!=0)
            {
                MessageBox.Show("读取配置文件YTB.ini失败，请检查后再运行!", "系统提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            oMyDb = new CDb("MYSQL",gszDbIp, gszDbPort, gszDbSrv, gszDbLogin, gszDbPwd);
            if(oMyDb==null)
            {
                MessageBox.Show("连接数据库失败，请检查后再运行!", "系统提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string szErr = "";
            if(MyFunc.GetSysParaFromDb(oMyDb,ref szErr) !=0)
            {
                MessageBox.Show("读取数据库失败(错误原因＝"+szErr+")，请检查后再运行!", "系统提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            oMyDb.Close();

            if (gszYTBIp.CompareTo("183.58.24.209") == 0)//生产环境
                gszHttpSrv = "https://183.58.24.209:8088/ytb-http-sersc/servlet/server";
            else
                gszHttpSrv = "http://58.213.110.146:9082/ytb-http-server/servlet/server";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UserCheckIn = false;
            frm_Login Frm_Login = new frm_Login();
            Frm_Login.ShowDialog();

            giUserID = 1;//only for test

            if (UserCheckIn)
                Application.Run(new frm_Main());
        }
    }
}
