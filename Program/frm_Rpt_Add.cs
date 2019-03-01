﻿using System;
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
    public partial class frm_Rpt_Add : Form
    {
        string mszTitle = "收银员,充值类型,充值笔数,充值金额(元)";
        string mszTitleWidth = "1,1,1,1";
        int miCols;
        int miDefRows = 100;
        //DataTable mDt;
        string mszRptTitle = "充值汇总";
        string mszRptDate;
        //string mszRptUnit = "货币单位：人民币元";
        int miRows;

        public frm_Rpt_Add()
        {
            InitializeComponent();
        }

        private void frm_Rpt_Add_Load(object sender, EventArgs e)
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

            comboBox_Type.Items.Clear();
            string szSql = "select sub_type from base_value where type=1 order by id";
            string szErr = "";
            DataSet ds = new DataSet();
            int iNum=0;
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    comboBox_Type.Items.Add("所有");
                    for (int i = 0; i < iNum; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        comboBox_Type.Items.Add(dr[0].ToString());
                    }
                    comboBox_Type.SelectedIndex = 0;
                }
            }

            szSql = "select concat(user_id,'-',user_name) from sys_users where USER_DPT='财务' and user_stat='USED' order by user_id";
            szErr = "";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
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

            textBox_buyer.Text = "";
            szSql = "select concat(user_card,'-',user_name) from base_ucard order by user_card";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                    comboBox_Buyer.Items.Add("0-所有买方");
                for (int i = 0; i < iNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Buyer.Items.Add(dr[0].ToString());
                }
            }
            if (iNum > 0)
                comboBox_Buyer.SelectedIndex = 0;

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
            MyStart.oMyDb.Close();
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
                //select 
                //case when b.USER_NAME is not null then b.USER_NAME else '合计' end as '操作员',
                //case when oper_subtype is not null then oper_subtype else '小计' end as '类型',
                //sum(chg_val) as '金额' from rec_user a,sys_users b 
                //where oper_type = 'ADD' and a.Oper_ID = b.USER_ID group by b.USER_NAME, oper_subtype with rollup;

            MyFunc.WriteToDbLog("查询充值汇总", "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker_Bgn.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker_End.Value);
            //dataGridViewRst.Rows.Clear();
            //MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (MyStart.gszMrktName.Length > 0)
                mszRptTitle = MyStart.gszMrktName + "充值汇总表";
            else
                mszRptTitle = "充值汇总表";

            string szDateCondition = "Oper_Time>='" + szBgn + "' and Oper_Time<='" + szEnd + "'";
            string szSql = "select "
                + "case when b.USER_NAME is not null then b.USER_NAME else '合计' end as '收银员',"
                + "case when oper_subtype is not null then oper_subtype else '小计' end as '充值类型',"
                + "count(chg_val) as 充值笔数,format(sum(chg_val) / 100, 2) as '充值金额(元)' from rec_user a,sys_users b where oper_type = 'ADD' and a.Oper_ID=b.USER_ID  ";

            if (comboBox_Type.SelectedIndex>0)//only one type
            {
                szSql += " and oper_subtype='"+ comboBox_Type.Text.Trim()+ "' ";
            }
            if(comboBox_POS.SelectedIndex>0)//only one oper
            {
                string[] szX = comboBox_POS.Text.Split('-');
                szSql += " and a.Oper_ID=" + szX[0];
            }
            if(!(textBox_buyer.Text.Length==0 && comboBox_Buyer.SelectedIndex==0))//only one buyer
            {
                string[] szX = comboBox_Buyer.Text.Split('-');
                szSql += " and a.Card_No='" + szX[0]+"' ";
            }
            szSql += " and "+ szDateCondition + " group by b.USER_NAME, oper_subtype with rollup";
            try
            {
                DataSet ds = new DataSet();
                string szErr="";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询充值汇总", "SQL=" + szSql + ",Err=" + szErr);
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

                int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
                int iBgnRow = 0;
                //MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, iBgnRow, miCols, ref iCurNum);
                iBgnRow += iNum;

                if (iBgnRow == 0)
                    goto Eend;


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
            MyFunc.WriteToDbLog("生成充值汇总报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,C,D", mszTitle, ref dataGridViewRst, miRows, "", "E:\\", "充值销售汇总报表" + DateTime.Now.ToString("yyyyMMdd"),
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

        private void textBox_buyer_TextChanged(object sender, EventArgs e)
        {
            comboBox_Buyer.Items.Clear();
            comboBox_Buyer.Text = "";
            int iStoreNum = 0;
            DataSet ds = new DataSet();
            string szSql = "";
            string szErr = "";
            if (textBox_buyer.Text.Trim().Length > 0)
                szSql = "select concat(user_card,'-',user_name) from base_ucard where card_flag='BGN' and user_name like '%" + textBox_buyer.Text.Trim() + "%' order by user_card";
            else
                szSql = "select concat(user_card,'-',user_name) from base_ucard order by user_card";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                if (iStoreNum > 0 && textBox_buyer.Text.Length==0)
                    comboBox_Buyer.Items.Add("0-所有买方");
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
    }
}
