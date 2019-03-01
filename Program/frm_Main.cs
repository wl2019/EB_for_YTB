using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace YTB
{
    public partial class frm_Main : Form
    {
        public static Assembly oResource;                               // 资源
        public static string szProjName;
        //public static int[] iMenu =   { 3, 3, 3, 4, 4, 2,1 };
        //public static int[] iMenu = { 3, 4, 3, 8, 7, 5, 2, 1 };
        public static int[] iMenu = { 3, 4, 3, 7,4,4,4 ,7,4, 3, 1 };
        public static int iMainMenuNum = iMenu.Length;
        public static int iSubMenuMaxNum = 7;

        // 读写器信息: 
        public static bool bHaveRd = false;
        public static string sRdPort = "";    // 读写器连接的端口

        // Psam卡的号码，当 =""时，表示没有得到PsamCardID
        public static string FIRM_ID = "";        // 商户号
        public static string POS_ID = "";         // Psam卡号 ＝ PosID

        //银石后台注册信息：
        public static bool mbHaveReg = false;
        public static string mszKey = "";//网点用KEY
        public static string mszTellerNo = "";//网点用“发起方操作员”
        public static int mID;//网点用会员ID
        public static string mszNetTel = "";//网点联系电话
        public static string mszNetName = "";//网点名称+PSAM卡号

        public frm_Main()
        {
            InitializeComponent();
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            //V2.63 2019-1-3 商品汇总报表，重量汇总的BUG，卖方开副卡，支持模糊查姓名，报表默认时间调整，字体调大
            //V2.64 2019－1－3 临时生成换卡交易明细表
            //V3.0 2019-1-13 根据第3期的需求升级1:买方开卡增加2个字段，充值增加子类型与报表，发卡收费（未出报表），
            //V3.1 2019-1-15 修改V3.0的BUG
            //V3.2 2019-1-19 根据第3期的需求升级2:取款增加子类型与报表，报表日期改为登录日的8点至次日8点，开卡时的TAB按键检查一次，卖方名称可修改,开卡收费报表
            //V3.3 2019-1-20 修改V3.1的BUG
            //V3.4 2019-1-23 买方开卡时，显示卡号加上第一位
            //V3.5 2019-2-2X 根据第3期的需求升级3:发卡报表，权限设置，
            this.Text = "益通宝水产批发市场交易信息管理系统 V3.5 ( 操作员： " +MyStart.gszUsername + " )";
        }
        private void SetMenu()
        {
            bool[,] bDispMenu = new bool[iMainMenuNum, iSubMenuMaxNum];
            MyFunc.GetApp(MyStart.gszUserApp, ref bDispMenu);

            ToolStripMenuItemParaSys.Visible = bDispMenu[0, 0];
            ToolStripMenuItemParaRun.Visible = bDispMenu[0, 1];
            ToolStripMenuItemParaKey.Visible = bDispMenu[0, 2];
            ToolStripMenuItem_Setup.Visible = bDispMenu[0, 0] || bDispMenu[0, 1] || bDispMenu[0, 2];

            ToolStripMenuItemUserNet.Visible = bDispMenu[1, 0];
            ToolStripMenuItemUserInf.Visible = bDispMenu[1, 1];
            ToolStripMenuItemUserApp.Visible = bDispMenu[1, 2];
            ToolStripMenuItemUserLog.Visible = bDispMenu[1, 3];
            ToolStripMenuItem_Worker.Visible = bDispMenu[1, 0] || bDispMenu[1, 1] || bDispMenu[1, 2] || bDispMenu[1, 3];

            ToolStripMenuItemProdType.Visible = bDispMenu[2, 0];
            ToolStripMenuItemProdBase.Visible = bDispMenu[2, 1];
            ToolStripMenuItemProdFee.Visible = bDispMenu[2, 2];
            ToolStripMenuItem_Material.Visible = bDispMenu[2, 0] || bDispMenu[2, 1] || bDispMenu[2, 2];

            ToolStripMenuItemFirmBase.Visible = bDispMenu[3, 0];
            ToolStripMenuItemFirmRent.Visible = bDispMenu[3, 1];
            ToolStripMenuItemFirmCard.Visible = bDispMenu[3, 2];
            ToolStripMenuItemFirmQry.Visible = bDispMenu[3, 3];
            ToolStripMenuItemFirmQryCard.Visible = bDispMenu[3, 4];
            ToolStripMenuItemFirmCard_Mng.Visible = bDispMenu[3, 5];
            ToolStripMenuItemFirmCard_Trade.Visible = false; //bDispMenu[3, 6];
            ToolStripMenuItemFirmCard_Cash.Visible = false;
            ToolStripMenuItemFirmCard_QryVal.Visible = false;
            ToolStripMenuItemFirmCard_QryTrade.Visible = false;
            ToolStripMenuItem_Firm.Visible = bDispMenu[3, 0] || bDispMenu[3, 1] || bDispMenu[3, 2] || bDispMenu[3, 3]
                 || bDispMenu[3, 4] || bDispMenu[3, 5] || bDispMenu[3, 6];

            ToolStripMenuItem_Firm_M_Trans.Visible = bDispMenu[4, 0];
            ToolStripMenuItem_Firm_M_QryVal.Visible = bDispMenu[4, 1];
            ToolStripMenuItem_Firm_M_Cash.Visible = bDispMenu[4, 2];
            ToolStripMenuItem_Firm_M_QryTrade.Visible = bDispMenu[4, 3];
            ToolStripMenuItem_Firm_Money.Visible = bDispMenu[4, 0] || bDispMenu[4, 1] || bDispMenu[4, 2] || bDispMenu[4, 3];

            ToolStripMenuItemClient_Card.Visible = bDispMenu[5, 0];
            ToolStripMenuItemClient_Qry.Visible = bDispMenu[5, 1];
            ToolStripMenuItemClient_QryCard.Visible = bDispMenu[5, 2];
            ToolStripMenuItemClient_Mng.Visible = bDispMenu[5, 3];
            ToolStripMenuItemClient_Add.Visible = false;
            ToolStripMenuItemClient_Cash.Visible = false;
            ToolStripMenuItemClient_QryVal.Visible = false;
            ToolStripMenuItemClient_QryTrade.Visible = false;
            ToolStripMenuItem_User.Visible = bDispMenu[5, 0] || bDispMenu[5, 1] || bDispMenu[5, 2] || bDispMenu[5, 3];

            ToolStripMenuItem_User_M_QryVal.Visible = bDispMenu[6, 0];
            ToolStripMenuItem_User_M_Add.Visible = bDispMenu[6, 1];
            ToolStripMenuItem_User_M_Minus.Visible = bDispMenu[6, 2];
            ToolStripMenuItem_User_M_QryTrade.Visible = bDispMenu[6, 3];
            ToolStripMenuItem_User_Money.Visible = bDispMenu[6, 0] || bDispMenu[6, 1] || bDispMenu[6, 2] || bDispMenu[6, 3];

            ToolStripMenuItemQryMkt.Visible = bDispMenu[7, 0];
            ToolStripMenuItemQryFirm.Visible = bDispMenu[7, 1];
            ToolStripMenuItemQryUser.Visible = bDispMenu[7, 2];
            ToolStripMenuItemQryProd.Visible = bDispMenu[7, 3];
            ToolStripMenuItemQryPos.Visible = bDispMenu[7, 4];
            ToolStripMenuItemQryDetail.Visible = bDispMenu[7, 5];
            ToolStripMenuItemQryCard.Visible = bDispMenu[7, 6];
            ToolStripMenuItem_Search.Visible = bDispMenu[7, 0] || bDispMenu[7, 1] || bDispMenu[7, 2] 
                || bDispMenu[7, 3] || bDispMenu[7, 4] || bDispMenu[7, 5] || bDispMenu[7, 6];

            ToolStripMenuItemRptICAdd.Visible = bDispMenu[8, 0];
            ToolStripMenuItemRptAdd.Visible = bDispMenu[8, 1];
            ToolStripMenuItemRptMinus.Visible = bDispMenu[8, 2];
            ToolStripMenuItemRptPos.Visible = bDispMenu[8, 3];
            ToolStripMenuItem_Rpt.Visible = bDispMenu[8, 0] || bDispMenu[8, 1] || bDispMenu[8, 2] || bDispMenu[8, 3];

            ToolStripMenuItemDutyPwd.Visible = bDispMenu[9, 0];
            ToolStripMenuItemDutyPause.Visible = bDispMenu[9, 1];
            ToolStripMenuItemDutyQry.Visible = bDispMenu[9, 2];
            ToolStripMenuItem_Onduty.Visible = bDispMenu[9, 0] || bDispMenu[9, 1] || bDispMenu[9, 2];
        }
        private void frm_Main_Load(object sender, EventArgs e)
        {
            oResource = Assembly.GetExecutingAssembly();           // get current Assembly object
            szProjName = Assembly.GetExecutingAssembly().GetName().Name.ToString();

            //获取Psam卡卡号
            GetPsamCardID();
            //获取网点KEY和发起方操作员
            string szErr = "";
            MyFunc.GetNetInf(ref szErr);

            //公共参数初始化
            SetFormMax();
            SetMenu();            
            this.Show();

            timer1.Enabled = true;
            MyStart.oMyDb.Close();
        }

        private void SetFormMax()
        {
            int iWidth, iHeight;

            this.Hide();
            this.WindowState = FormWindowState.Maximized;
            iWidth = Screen.GetWorkingArea(new Point(100, 100)).Width;
            iHeight = Screen.GetWorkingArea(new Point(100, 100)).Height;
            this.WindowState = FormWindowState.Normal;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.Top = 0;
            this.Left = 0;
            this.Width = iWidth;
            this.Height = iHeight;
            toolStripStatusLabel_Topic.Width = statusStrip1.Width - 10 - 10 - toolStripStatusLabel_ShowTime.Width - 10;

            pictureBox_Main.Top = menuStrip1.Height;
            pictureBox_Main.Left = 5;
            pictureBox_Main.Height = this.Height - menuStrip1.Height - statusStrip1.Height - 45;
            pictureBox_Main.Width = this.Width - 25;
            pictureBox_Main.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_Main.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream("YTB.Pict.MainForm01.jpg"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_ShowTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void 工作人员信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_User_Inf subForm = new frm_User_Inf();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 工作人员权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_User_App subForm = new frm_User_App();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 工作人员工作日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_User_Log subForm = new frm_User_Log();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 当天汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Qry_Oper subForm = new frm_Qry_Oper();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 商品分类信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Prod_Type subForm = new frm_Prod_Type();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 商品基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Prod_base subForm = new frm_Prod_base();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 商品收费信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Prod_Fee subForm = new frm_Prod_Fee();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 商户基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firm_Base subForm = new frm_Firm_Base();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 商户租用档铺信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firm_Rent subForm = new frm_Firm_Rent();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 商户卡片信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firm_Card subForm = new frm_Firm_Card();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 商户卡片查询统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firm_Qry subForm = new frm_Firm_Qry();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_Refe_Click(object sender, EventArgs e)
        {
            frm_Setup_Run subForm = new frm_Setup_Run();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Duty_Pwd subForm = new frm_Duty_Pwd();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 临时挂机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Duty_Pause subForm = new frm_Duty_Pause();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void 当天营业汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void 当天按商品的销售汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Qry_User subForm = new frm_Qry_User();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void 按商户的汇总统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Qry_Firm subForm = new frm_Qry_Firm();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void 明细查询功能ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Qry_Detail subForm = new frm_Qry_Detail();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void 运营参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setup_Run subForm = new frm_Setup_Run();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 系统参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setup_Sys subForm = new frm_Setup_Sys();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 收银查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Qry_Oper subForm = new frm_Qry_Oper();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void 设置快捷键ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setup_Key subForm = new frm_Setup_Key();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemQryProd_Click(object sender, EventArgs e)
        {
            frm_Qry_Prod subForm = new frm_Qry_Prod();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemUserCard_AddVal_Click(object sender, EventArgs e)
        {
            frm_Card_AddVal subForm = new frm_Card_AddVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_Cash_Click(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemUserCard_Cash_Click(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemUserCard_Loss_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemUserCard_ChgCard_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemUserCard_ChgPwd_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemFirmCard_QryVal_Click(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemUserCard_QryVal_Click(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_QryTrade_Click(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemUserCard_QryTrade_Click(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemUserNet_Click(object sender, EventArgs e)
        {
            frm_User_Net subForm = new frm_User_Net();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemClient_Card_Click(object sender, EventArgs e)
        {
            frm_Client_Card subForm = new frm_Client_Card();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemClient_Qry_Click(object sender, EventArgs e)
        {
            frm_Client_Qry subForm = new frm_Client_Qry();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        public void GetPsamCardID()
        {
            CIcRdr myRdr = new CIcRdr();

            string sPort = "";
            bHaveRd = false;
            for (int i = 1; i < 20; i++)
            {
                sPort = "Com" + i.ToString(); 
                if (!myRdr.ComOpen(sPort))
                {
                    continue;
                }

                //Application.DoEvents();
                if (!myRdr.Link())
                {
                    myRdr.ComClose();
                    continue;
                }

                if (!myRdr.GetPsamID())
                {
                    myRdr.ComClose();
                    continue;
                }

                bHaveRd = true;
                sRdPort = sPort;
                myRdr.ComClose();
                break;
            }
        }

        private void ToolStripMenuItemFirmCardMng_Click(object sender, EventArgs e)
        {
            frm_Card_ChgPwd subForm = new frm_Card_ChgPwd();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void 用户卡管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Card_ChgPwd subForm = new frm_Card_ChgPwd();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemClient_Add_Click(object sender, EventArgs e)
        {
            frm_Card_AddVal subForm = new frm_Card_AddVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemClient_Cash_Click(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemClient_QryVal_Click(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemClient_QryTrade_Click(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_Cash_Click_1(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_QryVal_Click_1(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_QryTrade_Click_1(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItem_Firm_M_Trans_Click(object sender, EventArgs e)
        {
            frm_Firm_Trans subForm = new frm_Firm_Trans();
            //subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_Firm_M_QryVal_Click(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_Firm_M_Cash_Click(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_Firm_M_QryTrade_Click(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_User_M_QryVal_Click(object sender, EventArgs e)
        {
            frm_Card_QryVal subForm = new frm_Card_QryVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_User_M_Add_Click(object sender, EventArgs e)
        {
            frm_Card_AddVal subForm = new frm_Card_AddVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_User_M_Minus_Click(object sender, EventArgs e)
        {
            frm_Card_MinusVal subForm = new frm_Card_MinusVal();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItem_User_M_QryTrade_Click(object sender, EventArgs e)
        {
            frm_Card_QryTrade subForm = new frm_Card_QryTrade();
            subForm.mszFlag = "User_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemClient_Qry_Click_1(object sender, EventArgs e)
        {
            frm_Client_QryCard subForm = new frm_Client_QryCard();            
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemFirmQryCard_Click(object sender, EventArgs e)
        {
            frm_Firm_QryCard subForm = new frm_Firm_QryCard();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemFirmCard_Trade_Click(object sender, EventArgs e)
        {
            frm_Firm_QryTrade subForm = new frm_Firm_QryTrade();
            //subForm.mszFlag = "Firm_Card";
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemQryMkt_Click(object sender, EventArgs e)
        {
            frm_Qry_Mkt subForm = new frm_Qry_Mkt();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 30;
            subForm.Width = this.Width - 60;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemQryCard_Click(object sender, EventArgs e)
        {
            frm_Qry_Card subForm = new frm_Qry_Card();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();

        }

        private void ToolStripMenuItemDutyQry_Click(object sender, EventArgs e)
        {
            frm_Duty_Qry subForm = new frm_Duty_Qry();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemRptIC_Click(object sender, EventArgs e)
        {
            frm_Rpt_ICAdd subForm = new frm_Rpt_ICAdd();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemRptAdd_Click(object sender, EventArgs e)
        {
            frm_Rpt_Add subForm = new frm_Rpt_Add();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemRptMinus_Click(object sender, EventArgs e)
        {
            frm_Rpt_Minus subForm = new frm_Rpt_Minus();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemRptPos_Click(object sender, EventArgs e)
        {
            frm_Rpt_Oper subForm = new frm_Rpt_Oper();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.Left = this.Left + 50;
            subForm.Width = this.Width - 100;
            subForm.Top = this.Top + 150;
            subForm.Height = this.Height - 200;
            subForm.ShowDialog();
        }

        private void ToolStripMenuItemClient_inf_Click(object sender, EventArgs e)
        {
            frm_Client_Base subForm = new frm_Client_Base();
            subForm.StartPosition = FormStartPosition.CenterScreen;
            subForm.MaximizeBox = false;
            subForm.MinimizeBox = false;
            subForm.ShowDialog();
        }
    }
}
