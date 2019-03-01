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
    public partial class frm_Rpt_Oper : Form
    {
        string mszTitle = "收银员,毛重(" + MyStart.gszWeight + "),皮重(" + MyStart.gszWeight + "),"
    + "净重(" + MyStart.gszWeight + "),均价(元/" + MyStart.gszWeight + "),总价(元),服务金额(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1";
        string mszTitleCash = "收银员,买方充值,收入小结,买方取款,卖方取款,支出小结,资金结余";
        string mszTitleCashWidth = "1,1,1,1,1,1,1";//"1,1,1";
        int miCols;
        int miDefRows = 100;
        //DataTable mDt;
        string mszRptTitle;
        string mszRptDate;
        string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        string mszRptCashUnit = "货币单位：人民币元";
        int miRows;

        public frm_Rpt_Oper()
        {
            InitializeComponent();
        }

        private void DispUser(string szDpt)
        {
            comboBox_Firm.Items.Clear();

            int iNum = 0;
            string szSql = "";
            if (szDpt.Length == 0)//all
                szSql = "select concat(user_id,'-',user_name) from sys_users where user_stat='USED' order by user_id";
            else
                szSql = "select concat(user_id,'-',user_name) from sys_users where USER_DPT='" + szDpt.Trim()
                    + "' and user_stat='USED' order by user_id";
            DataSet ds = new DataSet();
            string szErr = "";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                    comboBox_Firm.Items.Add("0-所有收银员");
                for (int i = 0; i < iNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Firm.Items.Add(dr[0].ToString());
                }
            }
            if (iNum > 0)
                comboBox_Firm.SelectedIndex = 0;
        }

        private void frm_Rpt_Oper_Load(object sender, EventArgs e)
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
            ////dateTimePicker_End.Value = DateTime.Now;
            //dateTimePicker_Bgn.Text = MyStart.gdtLogin.ToString("yyyy-MM-dd 08:00:00");//DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"); //Value = DateTime.Now;//.AddMonths(-1);
            //dateTimePicker_End.Text = MyStart.gdtLogin.AddDays(1).ToString("yyyy-MM-dd 07:59:59");//DateTime.Now.ToString("yyyy-MM-dd 07:59:59");
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

            radioButton_cash.Checked = true;

            DataSet ds = new DataSet();
            string szErr = "";

            int iDptNum = 0;//
            string szSql = "select USER_DPT from sys_users group by USER_DPT ";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iDptNum = ds.Tables[0].Rows.Count;
                if (iDptNum > 0)
                    comboBox_dpt.Items.Add("所有部门");
                for (int i = 0; i < iDptNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_dpt.Items.Add(dr[0].ToString());
                }
            }
            if (iDptNum > 0)
            {
                comboBox_dpt.SelectedIndex = 0;
                DispUser("");
            }

            //radioButton_cash.Checked = true;
            MyFunc.GridInit(ref dataGridViewRst, mszTitleCash, mszTitleCashWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
            MyStart.oMyDb.Close();
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            /*
             select 
case when Z.USER_NAME is not null then Z.USER_NAME else '合计' end as '收银员',
case when Y_TYPE is not null then (if(Y_TYPE='CASH','取款',(if(Y_TYPE='ISSU','开卡',(if(Y_TYPE='ADD','充值','换卡')))))) else '小计' end as '操作类型',
case when Y_SubTYPE is not null then Y_SubTYPE else '小计' end as '操作子类型',
sum(A) as 卖方卡笔数,format(sum(B)/100,2) as '卖方金额(元)',sum(C) as 买方卡笔数,format(sum(D)/100,2)  as '买方金额(元)',
sum(A+C) as 总笔数, format(sum(B+D)/100,2) as '总金额(元)'
from
( select Y_ID,Y_TYPE,Y_SubTYPE,
 case when A is not null then A else 0 end as A,
 case when B is not null then B else 0 end as B,
 case when C is not null then C else 0 end as C,
 case when D is not null then D else 0 end as D
 from
	(select Oper_ID as X_ID,Oper_Type as X_TYPE,Oper_SubType as X_SubTYPE,count(Chg_Val) as A,sum(Chg_Val) as B from rec_firm where Oper_Type in('ADD','CASH','ISSU','CHG')  and Oper_Time>'2019-1-19' 
	group by Oper_ID,Oper_Type,Oper_SubType) X
	right join
	(select Oper_ID as Y_ID,Oper_Type as Y_TYPE,Oper_SubType as Y_SubTYPE,count(Chg_Val) as C,sum(Chg_Val) as D from rec_user where Oper_Type in('ADD','CASH','ISSU','CHG')  and Oper_Time>'2019-1-19' 
	group by Oper_ID,Oper_Type,Oper_SubType) Y
	on X_ID=Y_ID and X_TYPE=Y_TYPE and X_SubTYPE=Y_SubTYPE
) XX,sys_users Z
where XX.Y_ID=Z.USER_ID
group by Z.USER_NAME,XX.Y_TYPE,XX.Y_SubTYPE with rollup
             */
            MyFunc.WriteToDbLog("查询收银汇总", "", "MSG", MyStart.giUserID);
            //MyFunc.WriteToDbLog("查询商品销售汇总", "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker_End.Value);
            dataGridViewRst.Rows.Clear();
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "收银汇总表";
            else
                mszRptTitle = "收银汇总表";

            //if (radioButton_trade.Checked)
            //{
            //    mszRptTitle += "(磅房交易)";
            //    MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            //    string[] szX = mszTitle.Split(',');
            //    miCols = szX.Length;
            //    QryTrade(szBgn, szEnd);
            //}
            if (radioButton_cash.Checked)
            {
                mszRptTitle += "(财务收银)";
                MyFunc.GridInit(ref dataGridViewRst, mszTitleCash, mszTitleCashWidth, 15, miDefRows, true);
                string[] szX = mszTitleCash.Split(',');
                miCols = szX.Length;
                QryCash(szBgn, szEnd);
            }
        }

        private void QryCash(string szBgn, string szEnd)
        {
            DataSet ds = new DataSet();

            int iFirmNum = comboBox_Firm.Items.Count - 1;
            string[] szFirmID = new string[iFirmNum];//prod id
            string[] szFirmName = new string[iFirmNum];
            string[] szFirmCard = new string[iFirmNum];//prod id
            int iBgnRow = 0;

            try
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
                            WriteDataToGrid2(szFirmName[i], szFirmID[i], szBgn, szEnd, ref iBgnRow);
                    }

                    Decimal[] dItem = new Decimal[miCols - 1];
                    for (int i = 0; i < iBgnRow - 1; i++)
                    {
                        for (int j = 0; j < miCols - 1; j++)
                            dItem[j] += Convert.ToDecimal(dataGridViewRst.Rows[i].Cells[j + 1].Value);
                    }
                    string szText = "合计";
                    for (int index = 0; index < miCols - 1; index++)
                        szText += "#" + dItem[index].ToString("#0,000.00");
                    MyFunc.GridWriteData(ref dataGridViewRst, szText, ref iBgnRow);
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
                        WriteDataToGrid2(szFirmName[0], szFirmID[0], szBgn, szEnd, ref iBgnRow);
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

        private void WriteDataToGrid2(string szFirmName, string szID, string szBgn, string szEnd, ref int iBgnRow)
        {
            /*   string szSql = "select b.USER_NAME,if (oper_type = 'ADD','买方充值',"
                   + "if (oper_type = 'TRADE','买方消费',if (oper_type = 'CASH','买方取现',if (oper_type='CHG','买方换卡','买方取消交易')))),"
                   + "format(sum(chg_val)/100,2) from rec_user a,sys_users b "
                   + "where a.Oper_ID = b.USER_ID and b.USER_NAME = '" + szFirmName + "' and " + szDateCondition + " group by oper_type "
                   + "union "
                   + "select b.USER_NAME,if (oper_type = 'ADD','卖方充值',"
                   + "if (oper_type = 'TRADE','卖方消费',if (oper_type = 'CASH','卖方取现',if (oper_type='CHG','卖方换卡','卖方取消交易')))),"
                   + "format(sum(chg_val)/100,2) from rec_firm a,sys_users b "
                   + "where a.Oper_ID = b.USER_ID and b.USER_NAME = '" + szFirmName + "' and " + szDateCondition + " group by oper_type "
                   + "union "
                   + "select '小计','-','-' from dual";*/
            /*select z.USER_ID, z.USER_NAME,i as 买方提现,k as 卖方充值,l as 卖方提现,k-i-l as 结合
            from 
            (sys_users z
            left join
            (select a.Oper_ID as h,sum(a.Chg_Val) as i from rec_firm a where a.Oper_Type='TRADE' group by a.Oper_ID) x
            on z.USER_ID=x.h)
            left join
            (select b.Oper_ID as j,sum(b.Chg_Val) as k,sum(c.Chg_Val) as l from rec_user b,rec_user c 
            where b.Oper_ID=c.Oper_ID and b.Oper_Type='ADD' and c.Oper_Type='CASH' group by b.Oper_ID,c.Oper_ID) y
            on z.USER_ID=y.j 
            where z.USER_STAT='USED' */

            Int64[] iItem = new Int64[miCols - 1];
            string szSql = "select Oper_ID,sum(Chg_Val) from rec_user where Oper_Type='ADD' and Oper_ID=" + szID
                + " and Oper_Time>='" + szBgn + "' and Oper_Time<='" + szEnd + "'";

            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询收银记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            try
            {
                iItem[0] = Convert.ToInt64(dr[1]);//买方充值
            }
            catch
            {
                iItem[0] = 0;
            }
            iItem[1] = iItem[0];//收入结余

            szSql = "select Oper_ID,sum(Chg_Val) from rec_user where Oper_Type='CASH' and Oper_ID=" + szID
                + " and Oper_Time>='" + szBgn + "' and Oper_Time<='" + szEnd + "'";
            szErr = "";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询收银记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            dr = ds.Tables[0].Rows[0];
            try
            {
                iItem[2] = Convert.ToInt64(dr[1]);//买方提现
            }
            catch
            {
                iItem[2] = 0;
            }

            szSql = "select Oper_ID,sum(Chg_Val) from rec_firm where Oper_Type='CASH' and Oper_ID=" + szID
                + " and Oper_Time>='" + szBgn + "' and Oper_Time<='" + szEnd + "'";
            szErr = "";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询收银记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            dr = ds.Tables[0].Rows[0];
            try
            {
                iItem[3] = Convert.ToInt64(dr[1]);//卖方提现
            }
            catch
            {
                iItem[3] = 0;
            }
            iItem[4] = iItem[2] + iItem[3];//支出结余
            iItem[5] = iItem[1] - iItem[4];//总结余

            szSql = szID + "-" + szFirmName;
            for (int index = 0; index < miCols - 1; index++)
                szSql += "#" + ((decimal)iItem[index] / 100).ToString("0,000.00");
            MyFunc.GridWriteData(ref dataGridViewRst, szSql, ref iBgnRow);
        }

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成收银汇总报表", "", "MSG", MyStart.giUserID);
            string szErr = "";
            string szRptFle = "";
            bool bRst = false;
            //if (radioButton_trade.Checked)
            //    bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,E,G", mszTitle, ref dataGridViewRst, miRows, "", "E:\\",
            //        "收银汇总报表(磅房交易)" + DateTime.Now.ToString("yyyyMMdd"), ref szErr);
            if (radioButton_cash.Checked)
                bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,E,G", mszTitleCash, ref dataGridViewRst, miRows, "", "E:\\",
                   "收银汇总报表(财务收银)" + DateTime.Now.ToString("yyyyMMdd"), ref szErr);
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

            if (DialogResult.Yes == MessageBox.Show("是否打印报表？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                MyFunc.PrintExcelFile(szRptFle, ref szErr);

            button_Rpt.Enabled = false;
        }

        private void comboBox_dpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_dpt.SelectedIndex == 0)
                DispUser("");
            else
                DispUser(comboBox_dpt.Text.Trim());
        }
    }
}
