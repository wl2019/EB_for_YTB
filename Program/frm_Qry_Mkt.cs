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
    public partial class frm_Qry_Mkt : Form
    {
        string mszTitle = "市场名称           ,交易笔数,总净重(" + MyStart.gszWeight + "),总价(元),均价(元/" + MyStart.gszWeight + "),"
            + "买方服务费(元),卖方服务费(元),服务费收入汇总(元),买方系统使用费(元),卖方系统使用费(元),系统使用费收入汇总(元),销售总价(元)";
        string mszTitleWidth = "4,2,4,3,3,4,4,4,4,4,4,4";
        int miCols;
        int miDefRows = 100;
        //DataTable mDt;
        string mszRptTitle = "销售汇总";
        string mszRptDate;
        string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        int miRows;
        public frm_Qry_Mkt()
        {
            InitializeComponent();
        }

        private void frm_Qry_Mkt_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report2.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Rpt.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            groupBox2.Width = this.Width - 45;
            //groupBox2.Height = this.Height - groupBox2.Top - 50;
            dataGridViewRst.Width = groupBox2.Width - 20;
            //dataGridViewRst.Height = groupBox2.Height - 30;

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

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询市场交易汇总", "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker_End.Value);
            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "交易汇总表";
            else
                mszRptTitle = "市场交易汇总表";

            string szDateCondition = "jy_tim>='" + szBgn + "' and jy_tim<='" + szEnd + "'";
            string szSql = "select '"+ MyStart.gszMrktName + "',count(*), format(sum(prod_w - prod_nw) / 1000, 3),"
                + "format(sum(prod_amount) / 100, 2),format(sum(prod_amount) * 10 / sum(prod_w - prod_nw), 2),"
                + "format(sum(MKT_BUYER_FEE) / 100, 2), format(sum(MKT_SELLER_FEE) / 100, 2),"
                + "format(sum(MKT_BUYER_FEE + MKT_SELLER_FEE) / 100, 2), "
                + "format(sum(YTB_BUYER_FEE) / 100, 2), format(sum(YTB_SELLER_FEE) / 100, 2),"
                + "format(sum(YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2), "
                + "format(sum(prod_amount + MKT_BUYER_FEE + MKT_SELLER_FEE + YTB_BUYER_FEE + YTB_SELLER_FEE) / 100, 2) "
                + "from rec_trade where CANCEL_MARK='N' and PROD_ID>0 and " + szDateCondition;
            string szErr = "";

            try
            {
                DataSet ds = new DataSet();
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询市场交易记录", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                DataTable dt = ds.Tables[0];
                int iNum = dt.Rows.Count;
                if (iNum == 0)
                    goto Eend;
                //mDt = dt;

                int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
                int iBgnRow = 0;
                MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, iBgnRow, miCols, ref iCurNum);
                iBgnRow += iNum;

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

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成商场交易汇总报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,J,L", mszTitle, ref dataGridViewRst, miRows, "", "E:\\", "市场交易汇总报表" + DateTime.Now.ToString("yyyyMMdd"),
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
    }
}
