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
    public partial class frm_Qry_Detail : Form
    {
        string mszTitle = "交易单号,交易时间,卖方卡号,买方卡号,商品名称,单价(元),"
            +"毛重(" + MyStart.gszWeight + "),皮重(" + MyStart.gszWeight + "),净重(" + MyStart.gszWeight + "),总价(元),"
            + "买方费率,买方服务费(元),卖方费率,卖方服务费(元),买方系统使用费率,买方系统使用费(元),卖方系统使用费率,卖方系统使用费(元),销售总价(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
        int miCols;
        int miDefRows=5000;
        DataTable mDt;
        string mszRptTitle;
        string mszRptDate;
        string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        string mszSumSql;
        int miRows;

        public frm_Qry_Detail()
        {
            InitializeComponent();
        }

        private void frm_Qry_Detail_Load(object sender, EventArgs e)
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

            DataSet ds = new DataSet();
            string szErr = "";
            int iStoreNum = 0;//卖方
            string szSql = "select concat(store_id,'-',store_name) from base_store where STORE_STAT='USED' order by store_id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                if (iStoreNum > 0)
                    comboBox_Firm.Items.Add("0-所有卖方");
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Firm.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
                comboBox_Firm.SelectedIndex = 0;

            int iUserNum = 0;//买方
            szSql = "select concat(user_card,'-',user_name) from base_ucard order by user_card";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iUserNum = ds.Tables[0].Rows.Count;
                if (iUserNum > 0)
                    comboBox_User.Items.Add("0-所有买方");
                for (int i = 0; i < iUserNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_User.Items.Add(dr[0].ToString());
                }
            }
            if (iUserNum > 0)
                comboBox_User.SelectedIndex = 0;

            int iProdNum = 0;//商品
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
                comboBox_POS.SelectedIndex = 0;

            radioButton_SysId.Checked = false;
            textBox_SysId.Enabled = false;
            radioButton_Other.Checked = true;
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
            MyStart.oMyDb.Close();
        }

        private void radioButton_SysId_CheckedChanged(object sender, EventArgs e)
        {
            textBox_SysId.Enabled = radioButton_SysId.Checked;
        }

        private void radioButton_Other_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker_Bgn.Enabled = radioButton_Other.Checked;
            dateTimePicker_End.Enabled = radioButton_Other.Checked;
            comboBox_Firm.Enabled = radioButton_Other.Checked;
            comboBox_Prod.Enabled = radioButton_Other.Checked;

        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询销售明细", "", "MSG", MyStart.giUserID);
            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "销售明细表";
            else
                mszRptTitle = "销售明细表";

            DataSet ds = new DataSet();
            //string szSql = "select sys_id,jy_tim,a.store_card,user_card,prod_name,concat(format(prod_up / 100, 2), '元'),"
            //    + "concat(format(prod_w / 1000, 3), '公斤'),concat(format(prod_nw / 1000, 3), '公斤'),"
            //    + "concat(format((prod_w - prod_nw) / 1000, 3), '公斤'),concat(format(prod_amount / 100, 2), '元'), "
            //    + "concat(format(MKT_FEE_RATE/10,1),'%'),concat(format(MKT_FEE/ 100, 2), '元'),"
            //    + "concat(format(YTB_FEE_RATE/10,1),'%'),concat(format(YTB_FEE/ 100, 2), '元')";
            string szSql = "select JY_ID,jy_tim,substring(a.store_card,2),user_card,prod_name,format(prod_up / 100, 2),"
                + "format(prod_w / 1000, 3),format(prod_nw / 1000, 3),"
                + "format((prod_w - prod_nw) / 1000, 3),format(prod_amount / 100, 2), "
                + "concat(format(MKT_BUYER_FEE_RATE/10,1),'%'),format(MKT_BUYER_FEE/ 100, 2), "
                + "concat(format(MKT_SELLER_FEE_RATE/10,1),'%'),format(MKT_SELLER_FEE/ 100, 2),"
                + "concat(format(YTB_BUYER_FEE_RATE/10,1),'%'),format(YTB_BUYER_FEE/ 100, 2), "
                + "concat(format(YTB_SELLER_FEE_RATE/10,1),'%'),format(YTB_SELLER_FEE/ 100, 2),"
                /*+ "concat(format((YTB_BUYER_FEE_RATE+YTB_SELLER_FEE_RATE)/10,1),'%'),"
                + "format((YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2), "*/
                + "format((prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";
            string szTemp="";

            if (radioButton_SysId.Checked)
            {
                szSql += " from rec_trade a, base_prod b where a.CANCEL_MARK='N' and a.PROD_ID = b.PROD_ID "
                    + " and JY_ID=" + textBox_SysId.Text.Trim();
                mszSumSql = "";
            }
            if (radioButton_Other.Checked)
            {
                mszSumSql = "select '合计','-','-','-','-','-',"
                + "format(sum(prod_w) / 1000, 3),format(sum(prod_nw) / 1000, 3),"
                + "format(sum(prod_w - prod_nw) / 1000, 3),format(sum(prod_amount) / 100, 2), "
                + "'-',format(sum(MKT_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(MKT_SELLER_FEE)/ 100, 2),"
                + "'-',format(sum(YTB_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(YTB_SELLER_FEE)/ 100, 2), "
                + "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";

                //szTemp = " from rec_trade a, base_prod b,mng_card c,base_stall d,base_store e,sys_msg f  "
                //    + " where a.CANCEL_MARK='N' and a.STORE_CARD=c.STORE_CARD and c.STALL_ID=d.STALL_ID and d.STORE_ID=e.STORE_ID"
                //    + " and a.PROD_ID = b.PROD_ID and a.MSG_ID=f.MSG_ID";
                szTemp = " from rec_trade a, base_prod b,mng_card c,sys_msg f  "
                    + " where a.CANCEL_MARK='N' and a.STORE_CARD=c.STORE_CARD and c.CARD_TYPE<3 "
                    + " and a.PROD_ID = b.PROD_ID and a.MSG_ID=f.MSG_ID";
                string[] szItem;
                if (comboBox_Firm.SelectedIndex > 0)
                {
                    szItem = comboBox_Firm.Text.Split('-');
                    szTemp += " and c.STORE_ID = " + szItem[0];
                    //mszRptTitle = "销售明细表（卖方："+ szItem[1] + "）";
                }
                //else
                //    mszRptTitle = "销售明细表（所有卖方）";

                if (comboBox_User.SelectedIndex > 0)
                {
                    szItem = comboBox_User.Text.Split('-');
                    szTemp += " and USER_CARD = " + szItem[0];
                }
                if (comboBox_Prod.SelectedIndex > 0)
                {
                    szItem = comboBox_Prod.Text.Split('-');
                    szTemp += " and a.PROD_ID = " + szItem[0];
                }
                if (comboBox_POS.SelectedIndex > 0)
                {
                    szItem = comboBox_POS.Text.Split('-');
                    szTemp += " and f.POS_ID = '" + szItem[0] + "' ";
                }
                //szTemp += " and USER_CARD in ('3352300066101744','3352300066100738','3352300066105463','3352300066105356','3352300066103716')";// +
                    //"'3352300066109473','3352300066103096','3352300066102296','3352300066106826','3352300066106388')";
                szTemp += " and jy_tim>='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value)+"' ";// + " 00:00:00' ";
                szTemp += " and jy_tim<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_End.Value) + "' ";// + " 23:59:59' ";
            }
            szSql = szSql + szTemp+" order by jy_tim desc";
            if(mszSumSql.Length>0)
                mszSumSql += szTemp;

            try
            {
                string szErr = "";

                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询商品交易明细信息", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                int iNum = dt.Rows.Count;
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

            button_Rpt.Enabled = false;
            //        string mszTitle = "交易流水号,交易时间,卖方卡号,买方卡号,商品名称,单价(元),毛重(公斤),皮重(公斤),净重(公斤),总价(元),"
            //            +"市场方服务费率,市场方收费(元),益通宝服务费率,益通宝收费(元),买方支付费率,买方支付(元),卖方支付费率,卖方支付(元)";
            //string szSum="";
            //if (mszSumSql.Length > 0)
            //{
            //    DataSet ds = new DataSet();
            //    int iRst = MyStart.oMyDb.ReadData(mszSumSql, "tableA", ref ds, ref szErr);
            //    if (iRst != 0)
            //    {
            //        MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        MyIniFile.WriteLog("查询交易明细信息", "SQL=" + mszSumSql + ",Err=" + szErr);
            //        return;
            //    }
            //    DataRow dr = ds.Tables[0].Rows[0];
            //    int iNum = mszTitle.Split(',').Length;
            //    for(int i=0;i< iNum; i++)
            //        szSum+=dr[i].ToString()+"|";                
            //}
        }

        private void button_temp_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("旧卡查询销售明细", "", "MSG", MyStart.giUserID);
            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "旧卡销售明细表";
            else
                mszRptTitle = "旧卡销售明细表";

            DataSet ds = new DataSet();
            //查找卖方旧卡
            string szSql = "select substr(log_info,4,16) from sys_log where LOG_RMRK like '%卖方%换卡%' ";
            szSql += " and rec_time>='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value) + "' ";// + " 00:00:00' ";
            szSql += " and rec_time<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_End.Value) + "' ";// + " 23:59:59' ";
            string szFirmCard = "";
            int iFirmNum = 0;
            try
            {
                string szErr = "";

                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询卖方换卡记录失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询卖方换卡记录", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                iFirmNum = dt.Rows.Count;
                if (iFirmNum == 0)
                {
                    MessageBox.Show("该时间段没有卖方换卡记录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //goto Eend;
                }
                else
                {
                    for (int i = 0; i < iFirmNum; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        szFirmCard += "'" + dr[0].ToString() + "',";
                    }
                    szFirmCard = szFirmCard.Substring(0, szFirmCard.Length - 1);
                    MessageBox.Show("该时间段有"+ iFirmNum + "笔卖方换卡记录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询卖方换卡失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //查找买方旧卡
            szSql = "select substr(log_info,4,16) from sys_log where LOG_RMRK like '%买方%换卡%' ";
            szSql += " and rec_time>='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value) + "' ";// + " 00:00:00' ";
            szSql += " and rec_time<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_End.Value) + "' ";// + " 23:59:59' ";
            string szUserCard = "";
            int iUserNum = 0;
            try
            {
                string szErr = "";

                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询买方换卡记录失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询买方换卡记录", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                iUserNum = dt.Rows.Count;
                if (iUserNum == 0)
                {
                    MessageBox.Show("该时间段没有买方换卡记录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(iFirmNum==0 && iUserNum==0)
                        goto Eend;
                }
                else
                {
                    for (int i = 0; i < iUserNum; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        szUserCard += "'" + dr[0].ToString() + "',";
                    }
                    szUserCard = szUserCard.Substring(0, szUserCard.Length - 1);
                    MessageBox.Show("该时间段有" + iUserNum + "笔买方换卡记录", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询买方换卡失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            szSql = "select JY_ID,jy_tim,substring(a.store_card,2),user_card,prod_name,format(prod_up / 100, 2),"
                + "format(prod_w / 1000, 3),format(prod_nw / 1000, 3),"
                + "format((prod_w - prod_nw) / 1000, 3),format(prod_amount / 100, 2), "
                + "concat(format(MKT_BUYER_FEE_RATE/10,1),'%'),format(MKT_BUYER_FEE/ 100, 2), "
                + "concat(format(MKT_SELLER_FEE_RATE/10,1),'%'),format(MKT_SELLER_FEE/ 100, 2),"
                + "concat(format(YTB_BUYER_FEE_RATE/10,1),'%'),format(YTB_BUYER_FEE/ 100, 2), "
                + "concat(format(YTB_SELLER_FEE_RATE/10,1),'%'),format(YTB_SELLER_FEE/ 100, 2),"
                /*+ "concat(format((YTB_BUYER_FEE_RATE+YTB_SELLER_FEE_RATE)/10,1),'%'),"
                + "format((YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2), "*/
                + "format((prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";
            string szTemp = "";

            if (radioButton_SysId.Checked)
            {
                szSql += " from rec_trade a, base_prod b where a.CANCEL_MARK='N' and a.PROD_ID = b.PROD_ID "
                    + " and JY_ID=" + textBox_SysId.Text.Trim();
                mszSumSql = "";
            }
            if (radioButton_Other.Checked)
            {
                mszSumSql = "select '合计','-','-','-','-','-',"
                + "format(sum(prod_w) / 1000, 3),format(sum(prod_nw) / 1000, 3),"
                + "format(sum(prod_w - prod_nw) / 1000, 3),format(sum(prod_amount) / 100, 2), "
                + "'-',format(sum(MKT_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(MKT_SELLER_FEE)/ 100, 2),"
                + "'-',format(sum(YTB_BUYER_FEE)/ 100, 2), "
                + "'-',format(sum(YTB_SELLER_FEE)/ 100, 2), "
                + "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE)/ 100, 2)";

                //szTemp = " from rec_trade a, base_prod b,mng_card c,base_stall d,base_store e,sys_msg f  "
                //    + " where a.CANCEL_MARK='N' and a.STORE_CARD=c.STORE_CARD and c.STALL_ID=d.STALL_ID and d.STORE_ID=e.STORE_ID"
                //    + " and a.PROD_ID = b.PROD_ID and a.MSG_ID=f.MSG_ID";
                szTemp = " from rec_trade a, base_prod b,mng_card c,sys_msg f  "
                    + " where a.CANCEL_MARK='N' and a.STORE_CARD=c.STORE_CARD and c.CARD_TYPE<3 "
                    + " and a.PROD_ID = b.PROD_ID and a.MSG_ID=f.MSG_ID";
                string[] szItem;
                if (comboBox_Firm.SelectedIndex > 0)
                {
                    szItem = comboBox_Firm.Text.Split('-');
                    szTemp += " and c.STORE_ID = " + szItem[0];
                    //mszRptTitle = "销售明细表（卖方："+ szItem[1] + "）";
                }
                //else
                //    mszRptTitle = "销售明细表（所有卖方）";

                if (comboBox_User.SelectedIndex > 0)
                {
                    szItem = comboBox_User.Text.Split('-');
                    szTemp += " and USER_CARD = " + szItem[0];
                }
                if (comboBox_Prod.SelectedIndex > 0)
                {
                    szItem = comboBox_Prod.Text.Split('-');
                    szTemp += " and a.PROD_ID = " + szItem[0];
                }
                if (comboBox_POS.SelectedIndex > 0)
                {
                    szItem = comboBox_POS.Text.Split('-');
                    szTemp += " and f.POS_ID = '" + szItem[0] + "' ";
                }
                if(iUserNum>0)
                {
                    if(iFirmNum>0)
                        szTemp += " and (USER_CARD in (" + szUserCard + ") or a.STORE_CARD in (" + szFirmCard + "))";// +
                    else
                        szTemp += " and USER_CARD in (" + szUserCard + ") ";// +
                }
                else
                {
                    if (iFirmNum > 0)
                        szTemp += " and a.STORE_CARD in (" + szFirmCard + ")";// +
                    else
                        ;
                }

                //"'3352300066109473','3352300066103096','3352300066102296','3352300066106826','3352300066106388')";
                szTemp += " and jy_tim>='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value) + "' ";// + " 00:00:00' ";
                szTemp += " and jy_tim<='" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_End.Value) + "' ";// + " 23:59:59' ";
            }
            szSql = szSql + szTemp + " order by jy_tim desc";
            if (mszSumSql.Length > 0)
                mszSumSql += szTemp;

            try
            {
                string szErr = "";

                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询商品交易明细信息", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                int iNum = dt.Rows.Count;
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
