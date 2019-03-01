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
    public partial class frm_Firm_QryTrade : Form
    {
        string mszTitle = "卡号                ,操作时间        ,操作类型,变化金额(元),卡片余额(元)";
        string mszTitleWidth = "1,1,1,1,1";
        int miCols;
        //int miDefRows = 100;
        //DataTable mDt;
        string mszRptTitle = "卖方交易查询表";
        string mszRptDate;
        int miRows;

        CIcRdr myRdr = new CIcRdr();
        public string mszFlag;

        public frm_Firm_QryTrade()
        {
            InitializeComponent();
        }

        private void frm_Firm_QryTrade_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            //pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            //button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            NewAdd();
            button_Retry.Enabled = false;
            button_CheckCard.Focus();
        }
        private void NewAdd()
        {
            groupBox_1.Enabled = true;
            textBox_CardID.Text = "";

            groupBox_2.Enabled = true;
            groupBox_2.Visible = false;
            //dateTimePicker_End.Value = DateTime.Now;
            //dateTimePicker1.Text = MyStart.gdtLogin.ToString("yyyy-MM-dd 08:00:00");//DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 08:00:00");//.AddMonths(-1);
            //dateTimePicker2.Text = MyStart.gdtLogin.AddDays(1).ToString("yyyy-MM-dd 07:59:59");//DateTime.Now.ToString("yyyy-MM-dd 07:59:59");
            DateTime Dt = DateTime.Now;
            if (Dt >= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")) && Dt < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 08:00:00")))
            {
                dateTimePicker1.Text = Dt.AddDays(-1).ToString("yyyy-MM-dd 08:00:00");
                //dateTimePicker1.MaxDate = DateTime.Parse(dateTimePicker1.Text);

                dateTimePicker2.Text = Dt.ToString("yyyy-MM-dd 07:59:59");
                //dateTimePicker2.MaxDate = DateTime.Parse(dateTimePicker2.Text);
            }
            else
            {
                dateTimePicker1.Text = Dt.ToString("yyyy-MM-dd 08:00:00");
                //dateTimePicker1.MaxDate = DateTime.Parse(dateTimePicker1.Text);

                dateTimePicker2.Text = Dt.AddDays(1).ToString("yyyy-MM-dd 07:59:59");
                //dateTimePicker2.MaxDate = DateTime.Parse(dateTimePicker2.Text);
            }

            groupBox_3.Enabled = true;
            groupBox_3.Visible = false;
            dataGridView1.Rows.Clear();
            groupBox_3.Text = "第三步：查询结果";
            //textBox_TradeNum.Text = "";
            //textBox_TradeAmount.Text = "";

            button_Retry.Enabled = false;
            button_CheckCard.Focus();
        }

        private void frm_Firm_QryTrade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myRdr.ComIsOpen)
                myRdr.ComClose();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Retry_Click(object sender, EventArgs e)
        {
            NewAdd();
        }

        private void button_CheckCard_Click(object sender, EventArgs e)
        {
            string szInf = "";
            string sCardID = "";
            string sSql = "";

            if (!frm_Main.bHaveRd)
            {
                if (textBox_CardID.Text.Trim() != "")
                {
                    sCardID = textBox_CardID.Text;
                }
                else
                {
                    MessageBox.Show("没有连接读写器，也没有输入卡号，不能执行查询功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!myRdr.ComOpen(frm_Main.sRdPort))
                {
                    myRdr.ComClose();
                    if (textBox_CardID.Text.Trim() != "")
                    {
                        sCardID = textBox_CardID.Text;
                    }
                    else
                    {
                        MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (!myRdr.ReadCardInf(out szInf))
                    {
                        if (textBox_CardID.Text.Trim() != "")
                        {
                            sCardID = textBox_CardID.Text;
                        }
                        else
                        {
                            MessageBox.Show("读卡失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            myRdr.ComClose();
                            return;
                        }
                    }
                    else
                    {
                        sCardID = szInf.Substring(0, 16);
                    }
                }
                myRdr.ComClose();
            }
            textBox_CardID.Text = sCardID;

            sSql = "SELECT * FROM mng_card WHERE store_card = '" + sCardID + "' and CARD_STAT = 'BGN'";
            DataSet odt = null;
            string sErrMsg = "";
            int iRt = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);

            if (iRt != 0)
            {
                MessageBox.Show("查询数据库时出现错误 = " + sErrMsg, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Eend;
            }

            if (odt.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("未找到该卡片的信息, 请更换！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Eend;
            }

            sStoreID = odt.Tables[0].Rows[0]["STORE_ID"].ToString().Trim();
            sCardType = odt.Tables[0].Rows[0]["CARD_TYPE"].ToString().Trim();
            groupBox_1.Enabled = false;
            button_Retry.Enabled = true;
            groupBox_2.Visible = true;
            dateTimePicker1.Focus();

            Eend:
            MyStart.oMyDb.Close();
        }

        string sCardType = "";
        string sStoreID = "";
        string sStoreCardID = "";
        private void button_Find_Click(object sender, EventArgs e)
        {
            string T1 = "";
            string T2 = "";
            string sSql = "";

            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                T1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                T2 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                T2 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
                T1 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            if (sCardType == "1" || sCardType == "3")
            {
                sSql = "SELECT * FROM rec_firm WHERE Store_ID = " + sStoreID;
            }
            else
            {
                sSql = "SELECT * FROM rec_firm WHERE (Card_No = '" + textBox_CardID.Text + "' || Rmrk = '" + textBox_CardID.Text + "')";
            }
            sSql += " AND Oper_Time BETWEEN '" + T1 + "' AND '" + T2 + "' ORDER BY ID Desc";

            DataSet odt = null;
            string sErrMsg = "";
            string sTmp = "";

            int iRt = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
            if (iRt != 0)
            {
                MessageBox.Show("查询数据库时出现错误 = " + sErrMsg, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Eend;
            }

            int iValue = 0;
            int iTradeNum = 0;
            int iTradeAmount = 0;
            float fi = 0;
            miRows = odt.Tables[0].Rows.Count;

            if (odt.Tables[0].Rows.Count == 0)
            {   // 没有数据
            }
            else
            {   // 已检索到数据
                for (int i = 0; i < odt.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = odt.Tables[0].Rows[i]["Oper_Time"].ToString().Trim();

                    sTmp = odt.Tables[0].Rows[i]["Chg_Val"].ToString().Trim();
                    iValue = int.Parse(sTmp);
                    fi = iValue;
                    fi /= 100;
                    dataGridView1.Rows[i].Cells[3].Value = fi.ToString("0.00");

                    sTmp = odt.Tables[0].Rows[i]["Oper_Type"].ToString().Trim();
                    switch(sTmp)
                    {
                        case "ADD":
                            sTmp = "充值";
                            iTradeAmount += iValue;
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Card_No"].ToString().Trim();
                            break;
                        case "TRADE":
                            sTmp = "消费";
                            iTradeAmount += iValue;
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Rmrk"].ToString().Trim();
                            break;
                        case "CASH":
                            sTmp = "退款";
                            iTradeAmount -= iValue;
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Card_No"].ToString().Trim();
                            break;
                        case "CHG":
                            sTmp = "换卡";
                            iTradeAmount -= iValue;
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Card_No"].ToString().Trim();
                            break;
                        case "SETT":
                            sTmp = "结算";
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Card_No"].ToString().Trim();
                            break;
                        case "CANC":
                            sTmp = "取消";
                            dataGridView1.Rows[i].Cells[0].Value = odt.Tables[0].Rows[i]["Rmrk"].ToString().Trim();
                            iTradeAmount -= iValue;
                            break;
                    }
                    dataGridView1.Rows[i].Cells[2].Value = sTmp;

                    iTradeNum++;

                    sTmp = odt.Tables[0].Rows[i]["After_Val"].ToString().Trim();
                    iValue = int.Parse(sTmp);
                    fi = iValue;
                    fi /= 100;
                    dataGridView1.Rows[i].Cells[4].Value = fi.ToString("0.00");
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "合计";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = " ";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = iTradeNum.ToString() + "笔";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = " ";
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = " ";
                miRows++;
                dataGridView1.Rows[0].Selected = true;
            }
            groupBox_3.Text = "第三步：查询结果（合计 = " + iTradeNum.ToString() + "笔）";
            //fi = iTradeAmount;
            //fi /= 100;
            //textBox_TradeAmount.Text = fi.ToString("0.00");

            groupBox_2.Enabled = false;
            groupBox_3.Visible = true;

            Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成"+ mszRptTitle, "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd HH:mm:ss}", dateTimePicker1.Value);
            string szEnd = string.Format("{0:yyyy-MM-dd  HH:mm:ss}", dateTimePicker2.Value);
            mszRptDate = szBgn + " 至 " + szEnd;
            if (miRows == 0)
            {
                MessageBox.Show("没有数据，不打印", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szErr = "";
            string szRptFle = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate, "", "A,D,E", mszTitle, ref dataGridView1, miRows, "", "E:\\", mszRptTitle + DateTime.Now.ToString("yyyyMMdd"),
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

            if (DialogResult.Yes == MessageBox.Show("是否打印报表？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                MyFunc.PrintExcelFile(szRptFle, ref szErr);
        }
    }
}
