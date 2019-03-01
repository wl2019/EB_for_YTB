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
    public partial class frm_Firm_Qry : Form
    {
        string mszTitle = "卖方名称                ,开卡时间          ,卡类  ,卡号                ,卡状态,档口信息,联系人,联系电话       ,身份证               ,开卡人";
        string mszTitleWidth = "1,1,1,1,1,1,1,1,1,1";
        int miCols;
        int miDefRows = 5000;//100;//
        //DataTable mDt;
        string mszRptTitle = "发卖方卡统计表";
        string mszRptDate;
        int miRows;

        int miFirmID;
        int miStallID;
        int miCurFirm;
        int miCurStall;
        DataTable mDt;
        public frm_Firm_Qry()
        {
            InitializeComponent();
        }

        private void frm_Firm_Qry_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report1.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Rpt.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

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

            //MyFunc.GridInit(ref dataGridView_Total, "卖方,档口,发卡数量", "1,1,1", 15, 15, true);
            MyFunc.GridInit(ref dataGridView_Detail, mszTitle, mszTitleWidth, 15, miDefRows, true);
            miCols = mszTitle.Split(',').Length;
            MyStart.oMyDb.Close();

            textBox_Card.Text = "";
            textBox_Cell.Text = "";
            textBox_name.Text = "";
            radioButton_card.Checked = true;
            SelEnable();
        }

        private void comboBox_Firm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_Firm.SelectedIndex==0)
            {
                comboBox_Stall.Enabled = false;
                comboBox_Stall.Text = "";
                comboBox_Stall.Items.Clear();
                return;
            }

            comboBox_Stall.Enabled = true;
            string[] szFirmInf = comboBox_Firm.Text.Split('-');
            miFirmID = Convert.ToInt16(szFirmInf[0]);
            MyFunc.DispStall(comboBox_Firm, comboBox_Stall,true);
            if (comboBox_Stall.Items.Count > 0)
                comboBox_Stall.SelectedIndex = 0;
        }
        private void WriteDataToGrid(string szFirm, string szFirmCard, string szDateCondition, ref int iBgnRow,ref int iCardNum, ref bool HasCard)
        {
            HasCard = false;
            string szSql = "(SELECT '"+ szFirm + "' as 卖方名称,a.ADD_DT as 发卡时间, "
                + "if (CARD_TYPE = 1,'第一副卡',if (CARD_TYPE = 2,'副卡','结算卡')) as 卡类,STORE_CARD as 卡号, "
                + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,STALL_INF as 档口信息, "
                + "STORE_PERSON as 联系人,a.USER_TEL as 联系电话, a.cert_id as 身份证, b.USER_NAME as 开卡人 "
                + "FROM mng_card a,sys_users b where a.ADD_ID=b.USER_ID and STORE_CARD in( " + szFirmCard + ") order by a.ADD_DT) "
                + "union "
                + "(select '小计', '', '', count(*),  '','', '', '', '',  '' from mng_card where STORE_CARD in( " + szFirmCard + "))";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            DataTable dt = ds.Tables[0];
            int iNum = dt.Rows.Count;
            if (iNum == 1)
            {
                MyStart.oMyDb.Close();
                return;
            }
            //mDt = dt;

            iCardNum = iNum - 1;
            int iCurNum = (iNum < miDefRows ? miDefRows :iNum);
            MyFunc.GridWriteDt(ref dataGridView_Detail, ref dt, iBgnRow, miCols, ref iCurNum);
            iBgnRow += iNum;
            HasCard = true;
            MyStart.oMyDb.Close();
        }

        private string Get_STORE_CARD(string szFirmID, string szRentID)
        {
            string szFirmCard = "";
            string szSql;
            if (szRentID.Length > 0)
                szSql = "select STORE_CARD from mng_card where CARD_TYPE =2 and STORE_ID = " + szFirmID +" and STALL_ID=" + szRentID;
            else
                szSql = "select STORE_CARD from mng_card where CARD_TYPE<4 and STORE_ID = " + szFirmID;
            string szErr = "";
            try
            {
                DataSet ds = new DataSet();
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询卖方卡信息", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                szFirmCard = "";
                DataRow dr;
                if (iNum > 0)
                {
                    for (int j = 0; j < iNum - 1; j++)
                    {
                        dr = ds.Tables[0].Rows[j];
                        szFirmCard += dr[0].ToString() + ",";
                    }
                    dr = ds.Tables[0].Rows[iNum - 1];
                    szFirmCard += dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询卖方卡信息失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            return szFirmCard;
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询发卡明细", "", "MSG", MyStart.giUserID);

            dataGridView_Detail.Columns.Clear();
            dataGridView_Detail.DataSource = null;
            MyFunc.GridInit(ref dataGridView_Detail, mszTitle, mszTitleWidth, 15, miDefRows, true);

            int iFirmNum = comboBox_Firm.Items.Count - 1;
            string[] szFirmID = new string[iFirmNum];
            //string[] szFirmName = new string[iFirmNum];
            string[] szFirmCard = new string[iFirmNum];
            int iBgnRow = 0;
            int iCardNum = 0;
            int iAllCardNum = 0;
            int iCurLine = 0;
            bool bHasCard = false;
            int iDoFirm=0;
            dataGridView_Detail.Rows.Clear();
            MyFunc.GridInit(ref dataGridView_Detail, mszTitle, mszTitleWidth, 15, miDefRows, true);
            if (comboBox_Firm.SelectedIndex == 0)//all
            {
                //2)get STORE_CARD
                for (int i = 0; i < iFirmNum; i++)
                {
                    string[] szItem = comboBox_Firm.Items[i + 1].ToString().Split('-');
                    szFirmID[i] = szItem[0];
                    //szFirmName[i] = szItem[1];
                    szFirmCard[i] = Get_STORE_CARD(szFirmID[i],"");
                    //if(Convert.ToInt16( szFirmID[i])>160)
                    //{
                    //    ;
                    //}
                    //3)get data
                    iCardNum = 0;
                    bHasCard = false;
                    if (szFirmCard[i].Trim().Length > 16)
                        WriteDataToGrid(comboBox_Firm.Items[i + 1].ToString(), szFirmCard[i], "", ref iBgnRow,ref iCardNum,ref bHasCard);
                    if (bHasCard)
                        iDoFirm++;
                    iAllCardNum += iCardNum;
                    //iCurLine += iCardNum + 1;
                }
                DataTable dt = new DataTable();
                for (int i = 0; i < miCols; i++)
                    dt.Columns.Add(i.ToString(), Type.GetType("System.String"));
                dt.Rows.Add(new object[] { "合计 " + iDoFirm + " 卖方已发卡", "", "", "发卡总数 " + iAllCardNum + " 张", "", "", "", "", "" });

                //int iRtnNum = iCurLine;
                MyFunc.GridWriteDt(ref dataGridView_Detail, ref dt, iBgnRow, miCols, ref iCurLine);
                groupBox3.Text = "发卡明细：总卖方数 "+ iFirmNum + " 户，已发卡卖方 " + iDoFirm + " 户，发卡总数 " + iAllCardNum + " 张";
            }
            else//only one firm
            {
                if (comboBox_Stall.SelectedIndex == 0)//all
                {//2)get STORE_CARD
                    string[] szItem = comboBox_Firm.Items[comboBox_Firm.SelectedIndex].ToString().Split('-');
                    szFirmID[0] = szItem[0];
                    //szFirmName[0] = szItem[1];
                    szFirmCard[0] = Get_STORE_CARD(szFirmID[0], "");
                    //3)get data
                    iCardNum = 0;
                    if (szFirmCard[0].Trim().Length > 0)
                        WriteDataToGrid(comboBox_Firm.Items[comboBox_Firm.SelectedIndex].ToString(), szFirmCard[0], "", ref iBgnRow, ref iCardNum, ref bHasCard);

                    groupBox3.Text = "发卡明细：该卖方发卡总数 " + iCardNum + " 张";
                }
                else
                {
                    string[] szItem = comboBox_Firm.Items[comboBox_Firm.SelectedIndex].ToString().Split('-');
                    szFirmID[0] = szItem[0];
                    string[] szX=comboBox_Stall.Items[comboBox_Stall.SelectedIndex].ToString().Split('-');
                    string szRentID = szX[0];
                    //szFirmName[0] = szItem[1];
                    szFirmCard[0] = Get_STORE_CARD(szFirmID[0], szRentID);
                    //3)get data
                    iCardNum = 0;
                    if (szFirmCard[0].Trim().Length > 0)
                        WriteDataToGrid(comboBox_Firm.Items[comboBox_Firm.SelectedIndex].ToString(), szFirmCard[0], "", ref iBgnRow, ref iCardNum, ref bHasCard);

                    groupBox3.Text = "发卡明细：该档口发卡总数 " + iCardNum + " 张";
                }
            }
            if(dataGridView_Detail.RowCount>0)
                button_Rpt.Enabled = true;
            miRows = iBgnRow+1;
        }

        //private void GetDataTotal(ref DataSet ds)
        //{
        //    string szSql;
        //    if (comboBox_Stall.Enabled )
        //    { 
        //        string[] szStallInf = comboBox_Stall.Text.Split('-');
        //        miStallID = Convert.ToInt16(szStallInf[0]);
        //        szSql = "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称,"
        //            + "concat(b.STALL_ID, '-', b.STALL_INF) as 档口信息,count(*) as 发卡数量 "
        //            + "FROM base_store a, base_stall b, mng_card c "
        //            //+ "WHERE c.CARD_STAT = 'BGN' and a.STORE_ID = b.STORE_ID and b.STALL_ID = c.STALL_ID " 
        //            + "WHERE a.STORE_ID = b.STORE_ID and b.STORE_ID = c.STORE_ID "
        //            + "and a.STORE_STAT='USED' and b.STALL_STAT='USED'";
        //        if (miStallID > 0)
        //            szSql += " and b.STALL_ID =" + miStallID;
        //        if (miFirmID > 0)
        //            szSql += " and a.STORE_ID =" + miFirmID;
        //        szSql += " group by b.stall_ID order by a.STORE_ID, b.STALL_ID";
        //    }
        //    else//no stall
        //    {
        //        szSql = "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称,'-' as 档口信息,count(*) as 发卡数量 "
        //            +"FROM base_store a,  mng_card c WHERE a.STORE_ID = c.STORE_ID and a.STORE_STAT = 'USED' "
        //            + "and a.STORE_ID =" + miFirmID;
        //    }

        //    string szErr = "";
        //    int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
        //}
        //private void GetDataDetail(int iStoreID, ref DataSet ds)
        //{//发卡时间,卡号,卡类,档口联系人,联系电话
        //    string szErr = "";
        //    //string szSql = "SELECT ADD_DT as 发卡时间,STORE_CARD as 卡号,if(CARD_TYPE=1,'第一副卡',if(CARD_TYPE=3,'结算卡','副卡')) as 卡类,"
        //    //    + " if(CARD_STAT='BGN','正常',if(CARD_STAT='STOP','无效','挂失')) as 卡片状态,STALL_PERSON as 档口联系人,STALL_TEL as 联系电话 "
        //    //    + " FROM base_stall a,mng_card b WHERE a.STORE_ID=b.STORE_ID and b.STORE_ID = " + iStoreID 
        //    //    + " order by CARD_ID desc  ";

        //    string szSql = "SELECT ADD_DT as 发卡时间,STORE_CARD as 卡号,"
        //        + "if (CARD_TYPE = 1,'第一副卡','结算卡') as 卡类,"
        //        + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,"
        //        + "STORE_PERSON as 联系人,USER_TEL as 联系电话,b.cert_id as 身份证 "
        //        + "FROM mng_card b WHERE b.CARD_TYPE<>2 and b.STORE_ID = " + iStoreID + " UNION "
        //        + "SELECT ADD_DT as 发卡时间,STORE_CARD as 卡号,"
        //        + "'副卡' as 卡类,"
        //        + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,"
        //        + "STORE_PERSON as 联系人,USER_TEL as 联系电话,b.cert_id as 身份证 "
        //        + "FROM base_stall a,mng_card b WHERE b.CARD_TYPE=2 and a.STORE_ID = b.STORE_ID and b.STORE_ID = " + iStoreID;
        //    int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
        //    if (iRst != 0)
        //        return;
        //}

        

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成卖方发卡报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,H,J", mszTitle, ref dataGridView_Detail, miRows, "", "E:\\", "发卖方卡统计表" + DateTime.Now.ToString("yyyyMMdd"),
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

        private void SelEnable()
        {
            if (radioButton_card.Checked)
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

        private void button_qry2_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询发卡明细", "", "MSG", MyStart.giUserID);

            dataGridView_Detail.Columns.Clear();
            dataGridView_Detail.DataSource = null;
            MyFunc.GridInit(ref dataGridView_Detail, mszTitle, mszTitleWidth, 15, miDefRows, true);

            string szWhere = "";
            if (radioButton_card.Checked)
                szWhere += "STORE_CARD like '%" + textBox_Card.Text.Trim() + "%' ";
            if (radioButton_cell.Checked)
                szWhere += "a.USER_TEL like '%" + textBox_Cell.Text.Trim() + "%' ";
            if (radioButton_name.Checked)
                szWhere += "a.STORE_PERSON like '%" + textBox_name.Text.Trim() + "%' ";
            if (radioButton_date.Checked)
                szWhere += "DATE_FORMAT(a.ADD_DT, '%Y-%m-%d') = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ";

            string szSql = "(SELECT store_name as 卖方名称,a.ADD_DT as 发卡时间, "
                + "if (CARD_TYPE = 1,'第一副卡',if (CARD_TYPE = 2,'副卡','结算卡')) as 卡类,STORE_CARD as 卡号, "
                + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,STALL_INF as 档口信息, "
                + "a.STORE_PERSON as 联系人,a.USER_TEL as 联系电话, a.cert_id as 身份证, b.USER_NAME as 开卡人 "
                + "FROM mng_card a,sys_users b,base_store c where a.ADD_ID=b.USER_ID and a.STORE_ID=c.STORE_ID and "+szWhere+" order by a.ADD_DT) "
                + "union "
                + "(select '小计', '', '', count(*),  '','', '', '', '',  '' from mng_card a where "+ szWhere+")";
            try
            {
                string szErr = "";
                DataSet ds = new DataSet();
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                    goto Eend;

                DataTable dt = ds.Tables[0];
                int iNum = dt.Rows.Count;

                dataGridView_Detail.Columns.Clear();//
                dataGridView_Detail.DataSource = dt;
                dataGridView_Detail.Refresh();

                if (iNum > 0)
                {
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

            if (dataGridView_Detail.RowCount > 0)
                button_Rpt.Enabled = true;
            //miRows = iBgnRow + 1;
        }
    }
}
