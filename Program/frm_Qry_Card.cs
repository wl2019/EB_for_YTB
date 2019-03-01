using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YTB
{
    public partial class frm_Qry_Card : Form
    {
        string mszTitle = "交易流水号,交易时间,卖方卡号,买方卡号,商品名称,单价(元),"
            + "毛重(" + MyStart.gszWeight + "),皮重(" + MyStart.gszWeight + "),净重(" + MyStart.gszWeight + "),总价(元),"
            + "买方费率,买方服务费(元),卖方费率,卖方服务费(元),买方系统使用费率,买方系统使用费(元),卖方系统使用费率,卖方系统使用费(元),销售总价(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
        int miCols;
        int miDefRows = 1000;
        DataTable mDt;
        string mszRptTitle;
        string mszRptDate;
        string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        string mszSumSql;
        int miRows;

        public frm_Qry_Card()
        {
            InitializeComponent();
        }

        private void frm_Qry_Card_Load(object sender, EventArgs e)
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

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
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
            myRdr.ComClose();

            if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardFirmFirst) != 0)//not firm card
            {
                if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardYtbFirst) != 0)//not user card
                {
                    MessageBox.Show("卡号错误（既不是卖方卡、结算卡，也不是买方卡），请换卡",
                        "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((Button)sender).Enabled = true;
                    button_Card.Focus();
                    return;
                }
                else
                    textBox_Card.Text = szInf.Substring(0, 16);
            }
            else
            {
                textBox_Card.Text = szInf.Substring(1, 15);
            }
            ((Button)sender).Enabled = true;
        }

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成销售明细报表", "", "MSG", MyStart.giUserID);
            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,Q,S", mszTitle, ref dataGridViewRst, miRows, "", "E:\\", "销售明细报表" + DateTime.Now.ToString("yyyyMMdd"),
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
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            string szCard = textBox_Card.Text;
            if (szCard.Length == 15)
                szCard = MyStart.gszCardFirmFirst + textBox_Card.Text;

            MyFunc.WriteToDbLog("刷卡查询销售明细", "", "MSG", MyStart.giUserID);
            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "销售明细表";
            else
                mszRptTitle = "销售明细表";
            DataSet ds = new DataSet();
            string szWhere = "";
            string szDetailSql = "select a.sys_id,jy_tim,substring(a.store_card,2),user_card,prod_name,format(prod_up / 100, 2),"
                + "format(prod_w / 1000, 3),format(prod_nw / 1000, 3),"
                + "format((prod_w - prod_nw) / 1000, 3),format(prod_amount / 100, 2), "
                + "concat(format(MKT_BUYER_FEE_RATE/10,1),'%'),format(MKT_BUYER_FEE/ 100, 2), "
                + "concat(format(MKT_SELLER_FEE_RATE/10,1),'%'),format(MKT_SELLER_FEE/ 100, 2),"
                + "concat(format(YTB_BUYER_FEE_RATE/10,1),'%'),format(YTB_BUYER_FEE/ 100, 2), "
                + "concat(format(YTB_SELLER_FEE_RATE/10,1),'%'),format(YTB_SELLER_FEE/ 100, 2),"
                /*+ "concat(format((YTB_BUYER_FEE_RATE+YTB_SELLER_FEE_RATE)/10,1),'%'),"
                + "format((YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2), "*/
                + "format((prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";

            mszSumSql = "select '合计','-','-','-','-','-',"
                + "format(sum(prod_w) / 1000, 3),format(sum(prod_nw) / 1000, 3),"
                + "format(sum(prod_w - prod_nw) / 1000, 3),format(sum(prod_amount) / 100, 2), "
                + "'-',format(sum(MKT_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(MKT_SELLER_FEE)/ 100, 2),"
                + "'-',format(sum(YTB_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(YTB_SELLER_FEE)/ 100, 2), "
                + "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";

            szWhere = " from rec_trade a, base_prod b,mng_card c,base_store e,sys_msg f  "
                    + " where a.CANCEL_MARK='N' and a.STORE_CARD=c.STORE_CARD and c.STORE_ID=e.STORE_ID"
                    + " and a.PROD_ID = b.PROD_ID and b.PROD_LEVEL=1 and a.MSG_ID=f.MSG_ID";
            szWhere += " and jy_tim>='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value) + "' ";// + " 00:00:00' ";
            szWhere += " and jy_tim<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_End.Value) + "' ";// + " 23:59:59' ";
            //szWhere += " and jy_tim>='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value) + " 00:00:00' ";
            //szWhere += " and jy_tim<='" + string.Format("{0:yyyy-MM-dd}", dateTimePicker_End.Value) + " 23:59:59' ";
            //验卡
            string szSql = "select user_card from base_ucard where user_card='" + szCard + "'";
            string szErr = "";
            try
            {
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("卡片查询失败，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("刷卡查询商品交易明细信息", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)//买方卡
                {
                    if (DialogResult.No == MessageBox.Show("是否查询买方卡" + szCard + "的交易明细?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        goto Eend;
                    szWhere += " and a.user_card='" + szCard + "' ";
                }
                else
                {
                    szSql = "select a.STORE_ID,CARD_TYPE,STORE_NAME from mng_card a,base_store b "
                        + "where a.STORE_ID=b.STORE_ID and STORE_CARD = '" + szCard + "'";
                    iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if (iRst != 0)
                    {
                        MessageBox.Show("卡片查询失败，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("刷卡查询商品交易明细信息", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                    iNum = ds.Tables[0].Rows.Count;
                    if (iNum == 0)
                    {
                        MessageBox.Show("系统中无此卡号，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("刷卡查询商品交易明细信息", "SQL=" + szSql + ",Err=系统中无此卡号");
                        goto Eend;
                    }
                    if (iNum > 1)
                    {
                        MessageBox.Show("系统中卡号重复记录，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("刷卡查询商品交易明细信息", "SQL=" + szSql + ",Err=系统中卡号重复记录");
                        goto Eend;
                    }
                    DataRow dr = ds.Tables[0].Rows[0];
                    int iFirmID = Convert.ToInt16(dr[0]);
                    int iCardType = Convert.ToInt16(dr[1]);
                    string szFirmName = dr[2].ToString();
                    if (iCardType == 2)//副卡
                    {
                        if (DialogResult.No == MessageBox.Show("是否查询卖方副卡" + textBox_Card.Text + "的交易明细?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            goto Eend;
                        szWhere += " and a.STORE_CARD='" + szCard + "' ";
                    }
                    else
                    {
                        szSql = "select STORE_CARD from mng_card where STORE_ID=" + iFirmID + " and CARD_TYPE<3";
                        iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                        if (iRst != 0)
                        {
                            MessageBox.Show("查询卖方副卡失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MyIniFile.WriteLog("查询卖方副卡信息", "SQL=" + szSql + ",Err=" + szErr);
                            goto Eend;
                        }
                        iNum = ds.Tables[0].Rows.Count;

                        szCard = "";
                        if (iNum > 0)
                        {
                            if (DialogResult.No == MessageBox.Show("是否查询卖方(" + szFirmName + ")的交易明细?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                goto Eend;
                            szCard = "";
                            for (int i = 0; i < iNum; i++)
                            {
                                dr = ds.Tables[0].Rows[i];
                                szCard += "'" + dr[0].ToString() + "'";
                                if ((i + 1) < iNum)
                                    szCard += ",";
                            }
                        }
                        szWhere += " and a.STORE_CARD in (" + szCard + ") ";
                    }
                }

                szDetailSql = szDetailSql + szWhere + " order by jy_tim desc";
                if (mszSumSql.Length > 0)
                    mszSumSql += szWhere;

                iRst = MyStart.oMyDb.ReadData(szDetailSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询商品交易明细信息", "SQL=" + szDetailSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                iNum = dt.Rows.Count;
                if (iNum == 0)
                {
                    MessageBox.Show("没有数据", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
                MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, 0, miCols, ref iCurNum);
                miRows = iNum;
                mszRptDate = string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value) + " 至 " + string.Format("{0:yyyy-MM-dd}", dateTimePicker_End.Value);
                button_Rpt.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }
    }
}
