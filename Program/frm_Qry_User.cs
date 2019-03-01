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
    public partial class frm_Qry_User : Form
    {
        string mszTitle = "买方        ,商品名称        ,总净重(" + MyStart.gszWeight+ "),总价(元),均价(元/" + MyStart.gszWeight + "),"
            + "买方服务费(元),卖方服务费(元),系统服务费(元),买方应付总额(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1,1,1";
        int miCols;
        int miDefRows = 5000;
        //DataTable mDt;
        string mszRptTitle="买方交易汇总";
        string mszRptDate;
        string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        int miRows;
        public frm_Qry_User()
        {
            InitializeComponent();
        }

        private void frm_Qry_DayProd_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report2.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Rpt.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            groupBox2.Width = this.Width - 50;
            groupBox2.Height = this.Height - groupBox2.Top - 50;
            dataGridViewRst.Width = groupBox2.Width - 20;
            dataGridViewRst.Height = groupBox2.Height - 30;

            dateTimePicker_Bgn.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_Bgn.Format = DateTimePickerFormat.Custom;
            dateTimePicker_End.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker_End.Format = DateTimePickerFormat.Custom;
            //dateTimePicker_End.Value = DateTime.Now;
            dateTimePicker_Bgn.Text = MyStart.gdtLogin.ToString("yyyy-MM-dd 08:00:00");//DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 08:00:00");//.AddMonths(-1);
            dateTimePicker_End.Text = MyStart.gdtLogin.AddDays(1).ToString("yyyy-MM-dd 07:59:59");//DateTime.Now.ToString("yyyy-MM-dd 07:59:59");
            DateTime Dt = DateTime.Now;
            if (Dt >= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")) && Dt < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 08:00:00")))
            {
                dateTimePicker_Bgn.Text = Dt.AddDays(-1).ToString("yyyy-MM-dd 08:00:00");
                //dateTimePicker_Bgn.MaxDate = DateTime.Parse(dateTimePicker_Bgn.Text);

                dateTimePicker_End.Text = Dt.ToString("yyyy-MM-dd 07:59:59");
                //dateTimePicker_End.MaxDate = DateTime.Parse(dateTimePicker_End.Text);
            }
            else
            {
                dateTimePicker_Bgn.Text = Dt.ToString("yyyy-MM-dd 08:00:00");
                //dateTimePicker_Bgn.MaxDate = DateTime.Parse(dateTimePicker_Bgn.Text);

                dateTimePicker_End.Text = Dt.AddDays(1).ToString("yyyy-MM-dd 07:59:59");
                //dateTimePicker_End.MaxDate = DateTime.Parse(dateTimePicker_End.Text);
            }

            textBox_Card.Text = "";
            textBox_name.Text = "";

            DataSet ds = new DataSet();
            string szErr = "";
            int iStoreNum = 0;//买方
            string szSql = "select concat(user_card,'-',user_name) from base_ucard order by user_card";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                if (iStoreNum > 0)
                    comboBox_Firm.Items.Add("0-所有买方");
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Firm.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
                comboBox_Firm.SelectedIndex = 0;

             /*            int iProdNum = 0;//商品
                       szSql = "select concat(PROD_ID,'-',PROD_NAME) from base_prod where PROD_LEVEL=1 order by PROD_ID";
                       iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                       if (iRst == 0)
                       {
                           iProdNum = ds.Tables[0].Rows.Count;
                           if (iProdNum > 0)
                               comboBox_Prod.Items.Add("0-所有商品");
                           for (int i = 0; i < iProdNum; i++)
                           {
                               DataRow dr = ds.Tables[0].Rows[i];
                               comboBox_Prod.Items.Add(dr[0].ToString());
                           }
                       }
                       if (iProdNum > 0)
                           comboBox_Prod.SelectedIndex = 0;

                       int iPosNum = 0;
                       szSql = "select concat(tmn_code,'-',tmn_name) from base_psam order by tmn_code";
                       iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                       if (iRst == 0)
                       {
                           iPosNum = ds.Tables[0].Rows.Count;
                           if (iPosNum > 0)
                               comboBox_POS.Items.Add("0-所有收银终端");
                           for (int i = 0; i < iPosNum; i++)
                           {
                               DataRow dr = ds.Tables[0].Rows[i];
                               comboBox_POS.Items.Add(dr[0].ToString());
                           }
                       }
                       if (iPosNum > 0)
                           comboBox_POS.SelectedIndex = 0;*/

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;

            radioButton_Sel.Checked = true;
            MyStart.oMyDb.Close();
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询买方交易汇总", "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker_End.Value);
            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "买方交易汇总表";
            else
                mszRptTitle = "买方交易汇总表";

            string szDateCondition = "jy_tim>='" + szBgn + "' and jy_tim<='" + szEnd + "'";
            DataSet ds = new DataSet();

            int iFirmNum = comboBox_Firm.Items.Count - 1;
            string[] szFirmID = new string[iFirmNum];//user card id
            string[] szFirmName = new string[iFirmNum];
            string[] szFirmCard = new string[iFirmNum];//user card id
            int iBgnRow = 0;
            try
            {
                if (radioButton_Sel.Checked)
                {
                    if (comboBox_Firm.SelectedIndex == 0)//all
                    {
                        //2)get STORE_CARD
                        for (int i = 0; i < iFirmNum; i++)
                        {
                            string[] szItem = comboBox_Firm.Items[i + 1].ToString().Split('-');
                            szFirmID[i] = szItem[0];
                            szFirmName[i] = szItem[1];
                            szFirmCard[i] = szFirmID[i];
                            //3)get data
                            if (szFirmCard[i].Trim().Length > 0)
                                WriteDataToGrid(szFirmName[i], szFirmCard[i], szDateCondition, ref iBgnRow);
                        }
                    }
                    else//only one firm
                    {
                        //2)get STORE_CARD
                        string[] szItem = comboBox_Firm.Items[comboBox_Firm.SelectedIndex].ToString().Split('-');
                        szFirmID[0] = szItem[0];
                        szFirmName[0] = szItem[1];
                        szFirmCard[0] = szFirmID[0];
                        //3)get data
                        if (szFirmCard[0].Trim().Length > 0)
                            WriteDataToGrid(szFirmName[0], szFirmCard[0], szDateCondition, ref iBgnRow);
                    }
                }
                if (radioButton_Input.Checked)
                {
                    szFirmID[0] = textBox_Card.Text.Trim();
                    szFirmCard[0] = szFirmID[0];
                    //check card and get name
                    string szSql = "select user_name from base_ucard where user_card='" + szFirmCard[0] + "'";
                    string szErr = "";
                    int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if (iRst != 0)
                    {
                        MessageBox.Show("查询买方卡失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("查询买方卡信息", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend; 
                    }
                    int iNum = ds.Tables[0].Rows.Count;
                    if (iNum == 0)
                    {
                        MessageBox.Show("系统里无此买方卡，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("查询买方卡信息", "SQL=" + szSql + ",Err=系统里无此买方卡");
                        goto Eend;
                    }
                    if (iNum > 1)
                    {
                        MessageBox.Show("重复发卡，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("查询买方卡信息", "SQL=" + szSql + ",Err=重复发卡");
                        goto Eend;
                    }
                    DataRow dr = ds.Tables[0].Rows[0];
                    szFirmName[0] = dr[0].ToString();

                    //3)get data
                    if (szFirmCard[0].Trim().Length > 0)
                        WriteDataToGrid(szFirmName[0], szFirmCard[0], szDateCondition, ref iBgnRow);
                }
                if (radioButton_name.Checked)
                {
                    szFirmID[0] = textBox_Card.Text.Trim();
                    szFirmCard[0] = szFirmID[0];
                    //check card and get name
                    string szSql = "select user_card,user_name from base_ucard where user_name like '%" + textBox_name.Text  + "%'";
                    string szErr = "";
                    int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if (iRst != 0)
                    {
                        MessageBox.Show("查询买方卡失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("查询买方卡信息", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                    iFirmNum = ds.Tables[0].Rows.Count;
                    if (iFirmNum == 0)
                    {
                        MessageBox.Show("系统里无此买方卡，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("查询买方卡信息", "SQL=" + szSql + ",Err=系统里无此买方卡");
                        goto Eend;
                    }
                    for (int i = 0; i < iFirmNum; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        string[] szItem = comboBox_Firm.Items[i + 1].ToString().Split('-');
                        szFirmID[i] = dr[0].ToString();
                        szFirmName[i] = dr[1].ToString();
                        szFirmCard[i] = szFirmID[i];
                        //3)get data
                        if (szFirmCard[i].Trim().Length > 0)
                            WriteDataToGrid(szFirmName[i], szFirmCard[i], szDateCondition, ref iBgnRow);
                    }
                }

                if (iBgnRow == 0)
                {
                    MessageBox.Show("没有数据", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                miRows = iBgnRow;
                mszRptDate = szBgn + " 至 " + szEnd;
                button_Rpt.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }
        private void WriteDataToGrid(string szFirmName, string szFirmCard, string szDateCondition, ref int iBgnRow)
        {
            string szSql = "select '" + szFirmName + "',PROD_NAME,format(sum(prod_w - prod_nw) / 1000, 3),"
                + "format(sum(prod_amount) / 100, 2),format(sum(prod_amount) * 10 / sum(prod_w - prod_nw), 2),"
                + "format(sum(MKT_BUYER_FEE) / 100, 2), 0.00,"//format(sum(MKT_SELLER_FEE) / 100, 2),"
                + "format(sum(YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2), "                
                //+ "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2) "
                + "format(sum(prod_amount + MKT_BUYER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2) "
                + "from rec_trade a,base_prod b "
                + "where a.CANCEL_MARK='N' and user_card in (" + szFirmCard + ") and a.PROD_ID = b.PROD_ID and b.PROD_LEVEL=1 and " + szDateCondition
                + " group by a.prod_id";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询买方交易记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            DataTable dt = ds.Tables[0];
            int iNum = dt.Rows.Count;
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            //mDt = dt;

            int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
            MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, iBgnRow, miCols, ref iCurNum);
            iBgnRow += iNum;

            szSql = "select ' ','汇总',format(sum(prod_w - prod_nw) / 1000, 3),"
                    + "format(sum(prod_amount) / 100, 2),format(sum(prod_amount) * 10 / sum(prod_w - prod_nw), 2),"
                    + "format(sum(MKT_BUYER_FEE) / 100, 2),0.00,"// format(sum(MKT_SELLER_FEE) / 100, 2),"
                    + "format(sum(YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2), "
                    //+ "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2)"
                    + "format(sum(prod_amount + MKT_BUYER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2)"
                    + "from rec_trade where CANCEL_MARK='N' and user_card in (" + szFirmCard + ") and PROD_ID>0 and " + szDateCondition;
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询买方交易汇总记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }

            dt = ds.Tables[0];
            //mDt = dt;
            iCurNum = 1;// (iNum < miDefRows ? miDefRows : iNum);
            MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, iBgnRow, miCols, ref iCurNum);
            iBgnRow++;
            MyStart.oMyDb.Close();
        }
        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成买方交易汇总报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate,"", "A,G,I", mszTitle, ref dataGridViewRst,miRows, "", "E:\\", "买方交易汇总报表" + DateTime.Now.ToString("yyyyMMdd"),
                ref szErr);
            if (bRst)
            {
                szRptFle = szErr;
                MessageBox.Show("已生成报表", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("生成报表失败(" + szErr + ")", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button_Rpt.Enabled = false;

            if (DialogResult.Yes == MessageBox.Show("是否打印报表？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                MyFunc.PrintExcelFile(szRptFle, ref szErr);

            button_Rpt.Enabled = false;
        }

        private void button_Card_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CIcRdr myRdr = new CIcRdr();
            //string szErr = "";
            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("连接读卡器失败，请检查连接", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            //Application.DoEvents();
            if (!myRdr.Link())
            {
                MessageBox.Show("连接读卡器失败，请联系供应商", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            //Application.DoEvents();
            string szInf;
            if (!myRdr.ReadCardInf(out szInf))
            {
                MessageBox.Show("读卡失败，请重新放卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardYtbFirst) != 0)
            {
                MessageBox.Show("卡号错误（买方卡号第一位是" + MyStart.gszCardYtbFirst + "），请换卡",
                    "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }
            textBox_Card.Text = szInf.Substring(0, 16);
            myRdr.ComClose();
            ((Button)sender).Enabled = true;
        }

        private void radioButton_Input_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_Firm.Enabled = radioButton_Sel.Checked;
            textBox_Card.Enabled = radioButton_Input.Checked;
            button_Card.Enabled = radioButton_Input.Checked;
            if (!textBox_Card.Enabled)
                textBox_Card.Text = "";
            textBox_name.Enabled = radioButton_name.Checked;
            if (!textBox_name.Enabled)
                textBox_name.Text = "";

            if (radioButton_Sel.Checked)
                comboBox_Firm.Focus();
            if (radioButton_Input.Checked)
                button_Card.Focus();
            if (radioButton_name.Checked)
                textBox_name.Focus();
        }
    }
}
