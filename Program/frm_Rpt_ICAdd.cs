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
    public partial class frm_Rpt_ICAdd : Form
    {
        //string mszTitleAll = "收银员,开卡时间,持卡人,卡号,卡类,状态,收费总额(元)";
        //string mszTitleAllWidth = "1,1,1,1,1,1,1";
        string mszTitle = "开卡人,开卡时间,类型,持卡人,卡号,卡类,状态,收费总额(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1,1";
        int miCols;
        int miDefRows = 100;
        //DataTable mDt;
        string mszRptTitle = "开卡统计";
        string mszRptDate;
        //string mszRptUnit = "货币单位：人民币元";
        int miRows;

        public frm_Rpt_ICAdd()
        {
            InitializeComponent();
        }

        private void DispUser(string szDpt)
        {
            comboBox_POS.Items.Clear();

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
                    comboBox_POS.Items.Add("0-所有收银员");
                for (int i = 0; i < iNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_POS.Items.Add(dr[0].ToString());
                }
            }
            if (iNum > 0)
                comboBox_POS.SelectedIndex = 0;
        }

        private void frm_Rpt_IC_Load(object sender, EventArgs e)
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
                comboBox_dpt.SelectedIndex = 4;
                DispUser(comboBox_dpt.Text);
            }
            comboBox_dpt.Enabled = false;

            textBox_buyer.Text = "";
            radioButton_all.Checked = true;
            //radioButton_buyer.Checked = true;

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
            MyStart.oMyDb.Close();
        }

        private void comboBox_dpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_dpt.SelectedIndex == 0)
                DispUser("");
            else
                DispUser(comboBox_dpt.Text.Trim());
        }

        private void radioButton_all_CheckedChanged(object sender, EventArgs e)
        {
            textBox_buyer.Enabled = false;
            comboBox_Buyer.Enabled = false;
        }

        private void radioButton_buyer_CheckedChanged(object sender, EventArgs e)
        {
            textBox_buyer.Enabled = true;
            comboBox_Buyer.Enabled = true;
            textBox_buyer_TextChanged(sender, e);
        }

        private void radioButton_seller_CheckedChanged(object sender, EventArgs e)
        {
            textBox_buyer.Enabled = true;
            comboBox_Buyer.Enabled = true;
            textBox_buyer_TextChanged(sender, e);
        }

        private void radioButton_seller_Click(object sender, EventArgs e)
        {
            textBox_buyer.Enabled = true;
            comboBox_Buyer.Enabled = true;
            textBox_buyer_TextChanged(sender, e);
        }

        private void radioButton_buyer_Click(object sender, EventArgs e)
        {
            textBox_buyer.Enabled = true;
            comboBox_Buyer.Enabled = true;
            textBox_buyer_TextChanged(sender, e);
        }

        private void textBox_buyer_TextChanged(object sender, EventArgs e)
        {
            comboBox_Buyer.Items.Clear();
            comboBox_Buyer.Text = "";
            int iStoreNum = 0;
            DataSet ds = new DataSet();
            string szSql = "";
            string szErr = "";
            if (textBox_buyer.Text.Trim().Length > 0)
            {
                if (radioButton_buyer.Checked)
                    szSql = "select concat(user_card,' - ',user_name) from base_ucard where card_flag='BGN' and user_name like '%" + textBox_buyer.Text.Trim() + "%' order by user_name";
                if (radioButton_seller.Checked)
                    szSql = "select distinct(concat(STORE_ID,' - ',STORE_PERSON)) from mng_card where STORE_PERSON like '%" + textBox_buyer.Text.Trim() + "%'  order by STORE_PERSON";
            }
            else
            {
                if (radioButton_buyer.Checked)
                    szSql = "select concat(user_card,' - ',user_name) from base_ucard order by user_name";
                if (radioButton_seller.Checked)
                    szSql = "select distinct(concat(STORE_ID,' - ',STORE_PERSON)) from mng_card where STORE_PERSON<>'' order by STORE_PERSON";
            }
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                if (iStoreNum > 0 && textBox_buyer.Text.Length == 0)
                {
                    if (radioButton_buyer.Checked)
                        comboBox_Buyer.Items.Add("0-所有买方");
                    if (radioButton_seller.Checked)
                        comboBox_Buyer.Items.Add("0-所有卖方");
                }
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Buyer.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
                comboBox_Buyer.SelectedIndex = 0;
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MyStart.oMyDb.Close();
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            //dataGridViewRst.Rows.Clear();
            //MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName;

            MyFunc.WriteToDbLog("查询开卡汇总", "", "MSG", MyStart.giUserID);
            if (radioButton_buyer.Checked)
                mszRptTitle += "买方开卡汇总表";
            if (radioButton_seller.Checked)
                mszRptTitle += "卖方开卡汇总表";
             
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker_End.Value);
            string szBuyerDateCondition = "a.oper_time>='" + szBgn + "' and a.oper_time<='" + szEnd + "' ";
            string szSellerDateCondition = "a.ADD_DT>='" + szBgn + "' and a.ADD_DT<='" + szEnd + "' ";
            string szSqlItem = "select A1 as '开卡人',A2 as '开卡时间',A3 as '类型',A4 as '持卡人',A5 as '卡号',A6 as '卡类'," +
                    "if (A7 = '-','-',(if (A7 = 'BGN','正常','停用'))) as '卡状态',format(A8 / 100, 2) as '收费金额(元)' ";
            string szSqlBuyerDetail = "select b.USER_NAME as A1,a.oper_time as A2,'买方' as A3,a.user_name as A4,user_card as A5," +
                "if(card_type=1,'主卡','副卡') as A6,card_flag as A7,Chg_Val as A8 " +
                "from base_ucard a ,sys_users b, rec_user c " +
                "where a.ADD_ID = b.USER_ID and a.user_card = c.Card_No and c.Oper_Type = 'ISSU' and " + szBuyerDateCondition + " ";
            string szSqlSellerDetail= "select b.USER_NAME as A1,a.ADD_DT as A2,'卖方' as A3,a.STORE_PERSON as A4,STORE_CARD as A5," +
                "if (card_type = 3,'结算卡',(if (card_type = 1,'第一副卡','副卡'))) as A6,CARD_STAT as A7,Chg_Val as A8 " +
                "from mng_card a,sys_users b, rec_firm c " +
                "where a.ADD_ID = b.USER_ID and a.STORE_CARD = c.Card_No and c.Oper_Type = 'ISSU' and " + szSellerDateCondition + " ";
            string szSqlBuyerSum = "select b.USER_NAME as A1,a.oper_time as A2,'买方' as A3,a.user_name as A4,user_card as A5,card_type as A6,card_flag as A7,Chg_Val as A8 " +
                "from base_ucard a ,sys_users b, rec_user c " +
                "where a.ADD_ID = b.USER_ID and a.user_card = c.Card_No and c.Oper_Type = 'ISSU' and " + szBuyerDateCondition + " ";
            string szSqlSellerSum = "select b.USER_NAME as A1,a.ADD_DT as A2,'卖方' as A3,a.STORE_PERSON as A4,STORE_CARD as A5,card_type as A6,CARD_STAT as A7,Chg_Val as A8 " +
                "from mng_card a,sys_users b, rec_firm c " +
                "where a.ADD_ID = b.USER_ID and a.STORE_CARD = c.Card_No and c.Oper_Type = 'ISSU' and " + szSellerDateCondition + " ";
            string szSql = "";
            if (radioButton_all.Checked)
            {
                szSql = szSqlItem+" from ( " +
                    szSqlBuyerDetail +
                    " union " + szSqlSellerDetail +
                    " union (select A1,'-','-','小计',count(A2),'-','-',sum(A8)  from ( " + szSqlBuyerSum + " union " + szSqlSellerSum + " )M group by A1) " +
                    " union (select '-','-','-','合计',count(A2),'-','-',sum(A8)  from ( " + szSqlBuyerSum + " union " + szSqlSellerSum + " )N ) " +
                    ") Z ";
                //if (comboBox_POS.SelectedIndex > 0)
                //{
                //    string[] szX = comboBox_POS.Text.Split('-');
                //    szSql += "where Z.A1='"+szX[1].Trim()+"' ";
                //}
                //szSql += "order by Z.A1 desc, Z.A2 desc";
            }

            if (radioButton_buyer.Checked)
            {
                string szName = " and a.user_name ";
                //if (comboBox_Buyer.SelectedIndex <0)
                //    szName += "like '%" + textBox_buyer.Text.Trim() + "%' ";
                //else
                //{
                    string[] szX = comboBox_Buyer.Text.Split('-');
                    szName += "='"+szX[1].Trim()+"' ";
                //}
                szSql = szSqlItem + " from ( " +
                    szSqlBuyerDetail  + szName +
                    " union (select A1,'-','-','小计',count(A2),'-','-',sum(A8)  from ( " + szSqlBuyerSum + szName + " )M group by A1) " +
                    " union (select '-','-','-','合计',count(A2),'-','-',sum(A8)  from ( " + szSqlBuyerSum + szName +  " )N ) " +
                    ") Z ";
                //if (comboBox_POS.SelectedIndex > 0)
                //{
                //    string[] szX = comboBox_POS.Text.Split('-');
                //    szSql += "where Z.A1='" + szX[1].Trim() + "' ";
                //}
                //szSql += "order by Z.A1 desc, Z.A2 desc";
            }
            if (radioButton_seller.Checked)
            {
                string szName = " and a.STORE_PERSON ";
                string[] szX = comboBox_Buyer.Text.Split('-');
                szName += "='" + szX[1].Trim() + "' ";
                //}
                szSql = szSqlItem + " from ( " +
                    szSqlSellerDetail + szName +
                    " union (select A1,'-','-','小计',count(A2),'-','-',sum(A8)  from ( " + szSqlSellerSum + szName + " )M group by A1) " +
                    " union (select '-','-','-','合计',count(A2),'-','-',sum(A8)  from ( " + szSqlSellerSum + szName + " )N ) " +
                    ") Z ";
            }

            if (comboBox_POS.SelectedIndex > 0)
            {
                string[] szX = comboBox_POS.Text.Split('-');
                szSql += "where Z.A1='" + szX[1].Trim() + "' ";
            }
            szSql += "order by Z.A1 desc, Z.A2 desc";
            try
            {
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询开卡汇总", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                DataTable dt = ds.Tables[0];
                if (dataGridViewRst.Columns.Count > 0)
                    dataGridViewRst.Columns.Clear();
                dataGridViewRst.DataSource = dt;
                dataGridViewRst.Refresh();

                int iNum = dt.Rows.Count;
                if (iNum == 0)
                {
                    button_Rpt.Enabled = false;
                    MessageBox.Show("没有数据", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
                //int iBgnRow = 0;
                ////MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, iBgnRow, miCols, ref iCurNum);
                //iBgnRow += iNum;

                //if (iBgnRow == 0)
                //    goto Eend;


                miRows = iNum;// iBgnRow;
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
            MyFunc.WriteToDbLog("生成开卡汇总报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            string szRptFile = "开卡汇总报表";
            if (radioButton_seller.Checked)
                szRptFile = "卖方开卡报表";
            if(radioButton_buyer.Checked)
                szRptFile = "买方开卡报表";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,F,H", mszTitle, ref dataGridViewRst, miRows, "", "E:\\", szRptFile + DateTime.Now.ToString("yyyyMMdd"),
                ref szErr);
            if (bRst)
            {
                szRptFile = szErr;
                MessageBox.Show("已生成报表", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("生成报表失败(" + szErr + ")", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button_Rpt.Enabled = false;

            if (DialogResult.Yes == MessageBox.Show("是否打印报表？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                MyFunc.PrintExcelFile(szRptFile, ref szErr);

            button_Rpt.Enabled = false;
        }

    }
}
