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
    public partial class frm_Client_Qry : Form
    {
        string mszTitle = "姓名    ,身份证号            ,联系电话      ,经营地址      ,开卡时间          ,卡号            ,卡片状态,备注     ,开卡人";
        //    + "毛重(" + MyStart.gszWeight + "),皮重(" + MyStart.gszWeight + "),净重(" + MyStart.gszWeight + "),总价(元),"
        //    + "买方费率,买方服务费(元),卖方费率,卖方服务费(元),系统费率,系统服务费(元),销售总价(元)";
        string mszTitleWidth = "1,1,1,1,1,1,1,1,1";
        //int miCols;
        int miDefRows = 15;
        //DataTable mDt;
        string mszRptTitle = "买方卡发卡统计报表";
        string mszRptDate;
        //string mszRptUnit = "重量单位：" + MyStart.gszWeight + "，货币单位：人民币元";
        //string mszSumSql;
        int miRows;

        public frm_Client_Qry()
        {
            InitializeComponent();
        }

        private void frm_Client_Qry_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report1.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Rpt.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            checkBox_All.Checked = true;
            radioButton_card.Checked = true;
            textBox_Card.Text = "";
            textBox_Cell.Text = "";
            textBox_name.Text = "";
            MyFunc.GridInit(ref dataGridView1, mszTitle, mszTitleWidth, 15, miDefRows, true);
        }

        //private void checkBox_All_Click(object sender, EventArgs e)
        //{
        //    dateTimePicker1.Enabled = !checkBox_All.Checked;
        //}

        private void button_Qry_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            MyFunc.GridInit(ref dataGridView1, mszTitle, mszTitleWidth, 15, miDefRows, true);

            string szWhere ="";
            if (radioButton_card.Checked)
                szWhere += "user_card like '%" + textBox_Card.Text.Trim() + "%' ";
            if (radioButton_cell.Checked)
                szWhere += "a.USER_TEL like '%" + textBox_Cell.Text.Trim() + "%' ";
            if (radioButton_name.Checked)
                szWhere += "a.user_name like '%" + textBox_name.Text.Trim() + "%' ";
            if (radioButton_date.Checked)
                szWhere += "DATE_FORMAT(oper_time, '%Y-%m-%d') = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";

            string szSql = "(select a.user_name as 姓名,a.cert_id as 身份证号,a.user_tel as 联系电话,a.user_addr as 经营地址, oper_time as 开卡时间,"
                + "user_card as 卡号,if(card_flag='BGN','正常',if(card_flag='STOP','无效','挂失')) as 卡片状态,a.rmrk as 备注, b.USER_NAME as 开卡人 "
                + "from base_ucard a,sys_users b  where a.ADD_ID=b.USER_ID ";
            if (!checkBox_All.Checked)
                szSql += "and " + szWhere;
            szSql += "order by a.user_name,a.cert_id) ";
            szSql += "union (select '合计', '', '','', '', count(*), '','', '' from base_ucard a ";
            if (!checkBox_All.Checked)
                szSql += "where "+ szWhere;
            szSql += ")";
            try
            {
                string szErr = "";
                DataSet ds = new DataSet();
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                    goto Eend;

                DataTable dt = ds.Tables[0];
                int iNum = dt.Rows.Count;

                dataGridView1.Columns.Clear();//
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

                if (iNum > 0)
                {
                    if (checkBox_All.Checked)
                        groupBox3.Text = "发卡明细：共发买方卡 " + (iNum - 1).ToString() + " 张";
                    else
                    { 
                        if(radioButton_card.Checked)
                            groupBox3.Text = "发卡明细：卡号包含该信息的买方卡共 " + (iNum - 1).ToString() + " 张";
                        if(radioButton_cell.Checked)
                            groupBox3.Text = "发卡明细：手机号包含该信息的买方卡共 " + (iNum - 1).ToString() + " 张";
                        if(radioButton_name.Checked)
                            groupBox3.Text = "发卡明细：姓名包含该信息的买方卡共 " + (iNum - 1).ToString() + " 张";
                        if (radioButton_date.Checked)
                            groupBox3.Text = "发卡明细：该日共发买方卡 " + (iNum - 1).ToString() + " 张";
                    }
                    button_Rpt.Enabled = true;
                }
                else
                {
                    //groupBox3.Text = "发卡明细：";
                    button_Rpt.Enabled = false;
                }
                if (!radioButton_date.Checked)
                    mszRptDate = "";
                else
                    mszRptDate = "发卡日期：" + dateTimePicker1.Value.ToString("yyyy-MM-dd");
                miRows = iNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show("买方卡开卡查询失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void checkBox_All_CheckedChanged(object sender, EventArgs e)
        {
            if ((checkBox_All.Checked))
            {
                radioButton_card.Enabled = false;
                textBox_Card.Enabled = false;

                radioButton_cell.Enabled = false;
                textBox_Cell.Enabled = false;

                radioButton_name.Enabled = false;
                textBox_name.Enabled = false;

                radioButton_date.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                radioButton_card.Enabled = true;
                textBox_Card.Enabled = true;

                radioButton_cell.Enabled = true;
                radioButton_name.Enabled = true;
                radioButton_date.Enabled = true;
                textBox_Cell.Enabled = false;
                textBox_name.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成买方卡发卡统计报表", "", "MSG", MyStart.giUserID);
            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,E,G", mszTitle, ref dataGridView1, miRows, "", "E:\\", "发买方卡统计表" + DateTime.Now.ToString("yyyyMMdd"),
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

        private void SelEnable()
        {
            if(radioButton_card.Checked)
            {
                textBox_Card.Enabled = true;
                textBox_Cell.Enabled = false;
                textBox_name.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            if (radioButton_cell.Checked)
            {
                textBox_Card.Enabled = false;
                textBox_Cell.Enabled = true;
                textBox_name.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            if (radioButton_name.Checked)
            {
                textBox_Card.Enabled = false;
                textBox_Cell.Enabled = false;
                textBox_name.Enabled = true;
                dateTimePicker1.Enabled = false;
            }
            if (radioButton_date.Checked)
            {
                textBox_Card.Enabled = false;
                textBox_Cell.Enabled = false;
                textBox_name.Enabled = false;
                dateTimePicker1.Enabled = true;
            }
        }

        private void radioButton_card_CheckedChanged(object sender, EventArgs e)
        {
            SelEnable();
        }

        private void radioButton_name_CheckedChanged(object sender, EventArgs e)
        {
            SelEnable();
        }

        private void radioButton_cell_CheckedChanged(object sender, EventArgs e)
        {
            SelEnable();

        }

        private void radioButton_date_CheckedChanged(object sender, EventArgs e)
        {
            SelEnable();

        }
    }
}
