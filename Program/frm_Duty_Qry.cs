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
    public partial class frm_Duty_Qry : Form
    {
        public frm_Duty_Qry()
        {
            InitializeComponent();
        }

        private void frm_Duty_Qry_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report2.ico"));
            button_Search.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_New.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_PrintDetail.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.print.ico"));
            button_Print.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.print.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            NewSearch();
            dateTimePicker1.Focus();
        }

        //int iNum = 0;
        //float fValue = 0;
        int iUserAddNum = 0;
        float fUserAddValue = 0;
        int iFirmAddNum = 0;
        float fFirmAddValue = 0;
        int iAddNum = 0;
        float fAddValue = 0;

        int iUserCashNum = 0;
        float fUserCashValue = 0;
        int iFirmCashNum = 0;
        float fFirmCashValue = 0;
        int iCashNum = 0;
        float fCashValue = 0;

        private void NewSearch()
        {
            groupBox1.Enabled = true;
            //dateTimePicker1.Text = MyStart.gdtLogin.ToString("yyyy-MM-dd 08:00:00");//DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 08:00:00"); //DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            //dateTimePicker2.Text = MyStart.gdtLogin.AddDays(1).ToString("yyyy-MM-dd 07:59:59");//DateTime.Now.ToString("yyyy-MM-dd 07:59:59"); //DateTime.Now.ToString("yyyy-MM-dd 23:59:59");
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

            groupBox2.Visible = false;
            ClearGrid();
        }

        private void ClearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            for (int i = 0; i < 2; i++)
            {
                dataGridView2.Rows.Add();
                if ( i==0)
                    dataGridView2.Rows[i].Cells[0].Value = "笔数";
                else
                    dataGridView2.Rows[i].Cells[0].Value = "金额";

                for (int j = 1; j < 8; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = "0";
                }
            }
        }

        DateTime T1, T2;
        private void button_Search_Click(object sender, EventArgs e)
        {
            int iNum = 0;
            int iValue = 0;
            int iRet = 0;
            float fi = 0;

            string sMsg = "";
            string sSqlString = "";
            string sTmp = "";
            DataSet DS = null;
            ClearGrid();

            iNum = 0;
            iValue = 0;

            iUserAddNum = 0;
            fUserAddValue = 0;
            iFirmAddNum = 0;
            fFirmAddValue = 0;
            iAddNum = 0;
            fAddValue = 0;

            iUserCashNum = 0;
            fUserCashValue = 0;
            iFirmCashNum = 0;
            fFirmCashValue = 0;
            iCashNum = 0;
            fCashValue = 0;

            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                T1 = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                T2 = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                T1 = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                T2 = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            try
            {
                int j = 0;
                sSqlString = "SELECT Card_No, Oper_Time, Oper_Type, Chg_Val FROM rec_user WHERE Oper_ID = " + MyStart.giUserID + 
                             " AND (Oper_Type = 'ADD' OR Oper_Type = 'CASH') AND Oper_Time Between '" + T1.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + T2.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                iRet = MyStart.oMyDb.ReadData(sSqlString, "tableA", ref DS, ref sMsg);
                if (iRet == 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        iNum = DS.Tables[0].Rows.Count;
                        for (j = 0; j < iNum; j++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[j].Cells[0].Value = DS.Tables[0].Rows[j]["Card_No"].ToString();
                            dataGridView1.Rows[j].Cells[1].Value = DateTime.Parse(DS.Tables[0].Rows[j]["Oper_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            dataGridView1.Rows[j].Cells[2].Value = DS.Tables[0].Rows[j]["Oper_Type"].ToString();

                            iValue = int.Parse(DS.Tables[0].Rows[j]["Chg_Val"].ToString());
                            fi = iValue;
                            fi /= 100;
                            dataGridView1.Rows[j].Cells[3].Value = fi.ToString("0.00");
                            dataGridView1.Rows[j].Cells[5].Value = "User";
                        }
                    }
                }

                sSqlString = "SELECT Card_No, Oper_Time, Oper_Type, Chg_Val FROM rec_firm WHERE Oper_ID = " + MyStart.giUserID +
                             " AND (Oper_Type = 'ADD' OR Oper_Type = 'CASH') AND Oper_Time Between '" + T1.ToString("yyyy-MM-dd HH:mm:ss") + "' AND '" + T2.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                iRet = MyStart.oMyDb.ReadData(sSqlString, "tableA", ref DS, ref sMsg);
                if (iRet == 0)
                {
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        for (j = 0; j < DS.Tables[0].Rows.Count; j++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[j+ iNum].Cells[0].Value = DS.Tables[0].Rows[j]["Card_No"].ToString();
                            dataGridView1.Rows[j+ iNum].Cells[1].Value = DateTime.Parse(DS.Tables[0].Rows[j]["Oper_Time"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                            dataGridView1.Rows[j+ iNum].Cells[2].Value = DS.Tables[0].Rows[j]["Oper_Type"].ToString();

                            iValue = int.Parse(DS.Tables[0].Rows[j]["Chg_Val"].ToString());
                            fi = iValue;
                            fi /= 100;
                            dataGridView1.Rows[j+ iNum].Cells[3].Value = fi.ToString("0.00");
                            dataGridView1.Rows[j+ iNum].Cells[5].Value = "Firm";
                        }
                    }
                    //iNum += DS.Tables[0].Rows.Count;
                }

                if (dataGridView1.Rows.Count > 0)            //已经找到记录了
                {
                    float fii = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        sTmp = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        fi = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                        switch (sTmp)
                        {
                            case "ADD":
                                dataGridView1.Rows[i].Cells[2].Value = "充值";
                                fii += fi;
                                iAddNum++;
                                fAddValue += fi;
                                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "User")
                                {
                                    iUserAddNum++;
                                    fUserAddValue += fi;
                                }
                                else
                                {
                                    iFirmAddNum++;
                                    fFirmAddValue += fi;
                                }
                                break;
                            case "CASH":
                                dataGridView1.Rows[i].Cells[2].Value = "取款";
                                fii -= fi;
                                iCashNum++;
                                fCashValue += fi;
                                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "User")
                                {
                                    iUserCashNum++;
                                    fUserCashValue += fi;
                                }
                                else
                                {
                                    iFirmCashNum++;
                                    fFirmCashValue += fi;
                                }
                                break;
                            //case "CHG":
                            //    dataGridView1.Rows[i].Cells[2].Value = "换卡";
                            //    fii += fi;
                            //    iChangeNum++;
                            //    fChangeValue += fi;
                            //    break;
                            //case "SETT":
                            //    dataGridView1.Rows[i].Cells[2].Value = "结算";
                            //    fii += fi;
                            //    iSettNum++;
                            //    fSettValue += fi;
                            //    break;
                            //    //case "TRADE":
                            //    //    dataGridView1.Rows[i].Cells[2].Value = "消费";
                            //    //    break;
                            //    //case "CANC":
                            //    //    dataGridView1.Rows[i].Cells[2].Value = "取消";
                            //    //    break;
                        }
                        dataGridView1.Rows[i].Cells[4].Value = fii.ToString("0.00");
                    }

                    dataGridView2.Rows[0].Cells[1].Value = iUserAddNum.ToString();
                    dataGridView2.Rows[1].Cells[1].Value = fUserAddValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[2].Value = iFirmAddNum.ToString();
                    dataGridView2.Rows[1].Cells[2].Value = fFirmAddValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[3].Value = iAddNum.ToString();
                    dataGridView2.Rows[1].Cells[3].Value = fAddValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[4].Value = iUserCashNum.ToString();
                    dataGridView2.Rows[1].Cells[4].Value = fUserCashValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[5].Value = iFirmCashNum.ToString();
                    dataGridView2.Rows[1].Cells[5].Value = fFirmCashValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[6].Value = iCashNum.ToString();
                    dataGridView2.Rows[1].Cells[6].Value = fCashValue.ToString("0.00");

                    dataGridView2.Rows[0].Cells[7].Value = dataGridView1.Rows.Count.ToString();
                    dataGridView2.Rows[1].Cells[7].Value = fii.ToString("0.00");

                    dataGridView1.Focus();
                    dataGridView1.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("没有找到符合条件的记录。" , "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // log
                MyFunc.WriteToDbLog("当班人员-收银结算", "", "MSG", MyStart.giUserID);

                groupBox1.Enabled = false;
                groupBox2.Visible = true;
                button_New.Focus();
                //return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("检索失败：" + ex, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MyStart.oMyDb.Close();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            NewSearch();
            dateTimePicker1.Focus();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            // Print
            MyTools.sPrintTopic = "操作员汇总打印功能";
            MyTools.sPrintID = "";

            MyTools.oPrintData = new string[50];
            int i = 0;
            //MyTools.oPrintData[i++] = "操作员号：" + MyStart.giUserID.ToString();
            //MyTools.oPrintData[i++] = "操作员名：" + MyStart.gszUsername.ToString();
            MyTools.oPrintData[i++] = "开始统计：" + T1.ToString("yyyy-MM-dd HH:mm:ss");
            MyTools.oPrintData[i++] = "结束统计：" + T2.ToString("yyyy-MM-dd HH:mm:ss");
            MyTools.oPrintData[i++] = "";
            MyTools.oPrintData[i++] = "工作情况：";
            MyTools.oPrintData[i++] = "买方充值：" + dataGridView2.Rows[0].Cells[1].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "卖方充值：" + dataGridView2.Rows[0].Cells[2].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[2].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "收入合计：" + dataGridView2.Rows[0].Cells[3].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[3].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "----------------------------------------";

            MyTools.oPrintData[i++] = "买方取款：" + dataGridView2.Rows[0].Cells[4].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[4].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "卖方取款：" + dataGridView2.Rows[0].Cells[5].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[5].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "支出合计：" + dataGridView2.Rows[0].Cells[6].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[6].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "----------------------------------------";

            MyTools.oPrintData[i++] = "结余合计：" + dataGridView2.Rows[0].Cells[7].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[7].Value.ToString().PadLeft(11) + "元";

            MyTools.iPrintData = i;
            MyTools.PrintTicket();
        }

        private void button_PrintDetail_Click(object sender, EventArgs e)
        {
            // Print
            MyTools.sPrintTopic = "操作员汇总打印功能";
            MyTools.sPrintID = "";

            MyTools.oPrintData = new string[3000];
            int i = 0;
            //MyTools.oPrintData[i++] = "操作员号：" + MyStart.giUserID.ToString();
            //MyTools.oPrintData[i++] = "操作员名：" + MyStart.gszUsername.ToString();
            MyTools.oPrintData[i++] = "开始统计：" + T1.ToString("yyyy-MM-dd HH:mm:ss");
            MyTools.oPrintData[i++] = "结束统计：" + T2.ToString("yyyy-MM-dd HH:mm:ss");
            MyTools.oPrintData[i++] = "----------------------------------------";
            MyTools.oPrintData[i++] = "明细情况：";
            if (dataGridView1.Rows.Count > 0)            //已经找到记录了
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    MyTools.oPrintData[i++] = "IC 卡 号：" + dataGridView1.Rows[j].Cells[0].Value.ToString();
                    MyTools.oPrintData[i++] = "交易时间：" + dataGridView1.Rows[j].Cells[1].Value.ToString();
                    MyTools.oPrintData[i++] = "操作类型：" + dataGridView1.Rows[j].Cells[2].Value.ToString();
                    MyTools.oPrintData[i++] = "变化金额：" + dataGridView1.Rows[j].Cells[3].Value.ToString();
                    MyTools.oPrintData[i++] = "金额小计：" + dataGridView1.Rows[j].Cells[4].Value.ToString();

                    if (j < dataGridView1.Rows.Count - 1)
                        MyTools.oPrintData[i++] = "---------------";
                }
            }
            MyTools.oPrintData[i++] = "----------------------------------------";
            MyTools.oPrintData[i++] = "汇总情况：";
            MyTools.oPrintData[i++] = "买方充值：" + dataGridView2.Rows[0].Cells[1].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[1].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "卖方充值：" + dataGridView2.Rows[0].Cells[2].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[2].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "收入合计：" + dataGridView2.Rows[0].Cells[3].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[3].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "----------------------------------------";

            MyTools.oPrintData[i++] = "买方取款：" + dataGridView2.Rows[0].Cells[4].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[4].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "卖方取款：" + dataGridView2.Rows[0].Cells[5].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[5].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "支出合计：" + dataGridView2.Rows[0].Cells[6].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[6].Value.ToString().PadLeft(11) + "元";
            MyTools.oPrintData[i++] = "----------------------------------------";

            MyTools.oPrintData[i++] = "结余合计：" + dataGridView2.Rows[0].Cells[7].Value.ToString().PadLeft(8) + "笔，" +
                                                     dataGridView2.Rows[1].Cells[7].Value.ToString().PadLeft(11) + "元";

            MyTools.iPrintData = i;
            MyTools.PrintTicket();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
