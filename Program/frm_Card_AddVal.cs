using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YTB
{
    public partial class frm_Card_AddVal : Form
    {
        CIcRdr myRdr = new CIcRdr();
        EbHttpClass objHttp = null;
        string sUserName = "";

        public string mszFlag;
        public frm_Card_AddVal()
        {
            InitializeComponent();
        }

        private void frm_Card_AddVal_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            //pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            button_CheckCard.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_AddValue.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Print.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.print.ico"));
            button_Retry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            if (mszFlag.ToUpper() == "USER_CARD")
                this.Text = "买方卡充值";
            else if (mszFlag.ToUpper() == "FIRM_CARD")
                this.Text = "卖方卡充值";
            else
                this.Text = "卡片充值";

            comboBox_Type.Items.Clear();
            string szSql = "select sub_type from base_value where type=1 order by id";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MessageBox.Show("查询充值类型失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("查询充值类型失败", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            int SeleCash = 0;
            if(iNum>0)
            {
                for(int i=0;i<iNum;i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Type.Items.Add(dr[0].ToString());

                    if (dr[0].ToString() == "现金")
                        SeleCash = i;
                }
                comboBox_Type.SelectedIndex = SeleCash;
            }

            NewAdd();
            button_Retry.Enabled = false;
            button_CheckCard.Focus();
        }

        private void NewAdd()
        {
            groupBox_FirstStep.Enabled = true;
            textBox_CardID.Text = "";
            textBox_OldBalance.Text = "";

            groupBox_SecondStep.Enabled = true;
            groupBox_SecondStep.Visible = false;
            textBox_Value.Text = "";
            textBox_Value2.Text = "";

            label_ValueBig.Text = "";
            label_ValueBig2.Text = "";
            sUserName = "";

            groupBox_ThirdStep.Enabled = true;
            groupBox_ThirdStep.Visible = false;
            textBox_Result.Text = "";
            textBox_NewBalance.Text = "";
            button_Retry.Enabled = false;

            button_CheckCard.Focus();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_Card_AddVal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myRdr.ComIsOpen)
                myRdr.ComClose();
        }

        private void button_Retry_Click(object sender, EventArgs e)
        {
            NewAdd();
        }

        private void button_CheckCard_Click(object sender, EventArgs e)
        {
            string szInf = "";
            string sCardID = "";
            DataSet odt = null;
            if (!frm_Main.bHaveRd)
            {
                MessageBox.Show("没有连接读写器，不能执行充值功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myRdr.ComClose();
                return;
            }

            ((Button)sender).Enabled = false;
            if (!myRdr.ReadCardInf(out szInf))
            {
                if (textBox_CardID.Text.Trim() != "")
                {
                    sCardID = textBox_CardID.Text;
                }
                else
                {
                    MessageBox.Show("读卡失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((Button)sender).Enabled = true;
                    myRdr.ComClose();
                    return;
                }
            }
            else
            {
                sCardID = szInf.Substring(0, 16);
            }
            myRdr.ComClose();
            ((Button)sender).Enabled = true;
            textBox_CardID.Text = sCardID;

            if (sCardID.Substring(0,1) == MyStart.gszCardFirmFirst)
            {
                MessageBox.Show("不接受商户卡的充值，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            odt = null;
            string sErrMsg = "";
            string sSql = "";
            try
            {
                sSql = "SELECT * FROM base_ucard WHERE user_card = '" + sCardID + "'";

                int iRst = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
                if (iRst != 0)
                {
                    MessageBox.Show("后台查询卡余额失败( " + sErrMsg + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                if (odt.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("没有此用户卡的信息，请更换。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                sUserName = odt.Tables[0].Rows[0]["user_name"].ToString().Trim();

                //银石后台
                objHttp = new EbHttpClass();
                string szErr = "";
                int CardBalance = 0;
                int iTrade = 0;

                bool bRst = objHttp.QryCard(sCardID, ref CardBalance, ref iTrade, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台查询卡余额失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                float fi = CardBalance;
                fi = fi / 100;
                textBox_OldBalance.Text = fi.ToString("0.00");

                groupBox_FirstStep.Enabled = false;
                groupBox_SecondStep.Visible = true;
                button_Retry.Enabled = true;
                textBox_Value.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询卡片余额失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Eend:
            if (odt != null)
                odt.Clear();

            MyStart.oMyDb.Close();
        }

        private void button_AddValue_Click(object sender, EventArgs e)
        {
            float fi = 0;

            textBox_Value.Text = textBox_Value.Text.Trim();
            textBox_Value2.Text = textBox_Value2.Text.Trim();
            if (textBox_Value.Text == "")
            {
                MessageBox.Show("请输入充值金额。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBox_Value.Text != textBox_Value2.Text)
            {
                MessageBox.Show("两次输入的充值金额不相等。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                fi = float.Parse(textBox_Value.Text);
            }
            catch
            {
                MessageBox.Show("请输入正确的充值金额。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 取得TradeID
            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myRdr.ComClose();
                return;
            }

            int iReaderTradeID = 0;
            if (!myRdr.GetTradeID(ref iReaderTradeID))
            {
                MessageBox.Show("交易失败：不能从读写器获取交易流水。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myRdr.ComClose();
                return;
            }
            myRdr.ComClose();

            string szSysID = iReaderTradeID.ToString();
            string sErrMsg = "";
            string sSql = "";
            DateTime dTradeTime = DateTime.Now;

            bool bRst = objHttp.OperUserMoney("AddVal", textBox_CardID.Text, fi, szSysID, "", ref sErrMsg);
            if (bRst)
            {
                fi += float.Parse(textBox_OldBalance.Text);
                textBox_NewBalance.Text = fi.ToString("0.00");

                // 写入数据库
                sSql = "INSERT INTO rec_user (Card_No, Oper_Time, Oper_Type,Oper_SubType, Before_Val, Chg_Val, After_Val, Oper_ID, Tmn_ID, Sys_ID) VALUE(" +
                       "'" + textBox_CardID.Text + "'," +
                       "'" + dTradeTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                       "'ADD','"+comboBox_Type.Text.Trim()+"',";
                float f = float.Parse(textBox_OldBalance.Text);
                f *= 100;
                int i = (int)(f+0.5);
                sSql += i.ToString() + ",";

                f = float.Parse(textBox_Value.Text);
                f *= 100;
                i = (int)(f+0.5);
                sSql += i.ToString() + ",";

                f = fi;
                f *= 100;
                i = (int)(f+0.5);
                sSql += i.ToString() + "," +
                        MyStart.giUserID + "," +
                        "'" + frm_Main.POS_ID + "'," +
                        iReaderTradeID.ToString() + ")";

                int iRst = MyStart.oMyDb.WriteData(sSql, ref sErrMsg);
                if (iRst <= 0)
                {
                    textBox_Result.Text = "充值成功！但写数据库失败( " + sErrMsg + " )";
                }
                else
                {
                    textBox_Result.Text = "充值成功！";
                }

                // log
                MyFunc.WriteToDbLog("买方资金-充值", "买方卡号=" + textBox_CardID.Text + ",充值=" + textBox_Value.Text + "元,类型=" + comboBox_Type.Text.Trim() + ",时间 =" + dTradeTime.ToString("yyyy-MM-dd HH:mm:ss"), "MSG", MyStart.giUserID);

                //打印票据
                button_Print_Click(sender, e);
                button_Print_Click(sender, e);
            }
            else
            {
                textBox_Result.Text = "充值失败 = szErr";
                textBox_NewBalance.Text = textBox_OldBalance.Text;
            }
            MyStart.oMyDb.Close();

            groupBox_SecondStep.Enabled = false;
            groupBox_ThirdStep.Visible = true;

            button_Retry.Focus();
        }

        private void textBox_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b' )
            {
                 e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                if (textBox_Value.Text.IndexOf('.') > 0)     // 已经存在小数点
                    e.Handled = true;                        // 无效
                else
                    e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_Value_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Value.Text == "")         // 没有输入
                {
                    label_ValueBig.Text = "";
                    return;
                }

                if (!Regex.IsMatch(textBox_Value.Text, @"^(?:0|[1-9]\d{0,6})(?:\.\d{1,2})?$"))
                {
                    label_ValueBig.Text = "错误";
                }
                else
                {
                    double dTmp = double.Parse(textBox_Value.Text) * 100;
                    int iV = (int)Math.Floor(dTmp + 0.5);
                    label_ValueBig.Text = ChangeDataToBigWrite(iV);
                }
            }
            catch
            {
                label_ValueBig.Text = "错误";
            }
        }
        private void textBox_Value2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                if (textBox_Value2.Text.IndexOf('.') > 0)     // 已经存在小数点
                    e.Handled = true;                         // 无效
                else
                    e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox_Value2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Value2.Text == "")         // 没有输入
                {
                    label_ValueBig2.Text = "";
                    return;
                }

                if (!Regex.IsMatch(textBox_Value2.Text, @"^(?:0|[1-9]\d{0,6})(?:\.\d{1,2})?$"))
                {
                    label_ValueBig2.Text = "错误";
                }
                else
                {
                    double dTmp = double.Parse(textBox_Value2.Text) * 100;
                    int iV = (int)Math.Floor(dTmp + 0.5);
                    label_ValueBig2.Text = ChangeDataToBigWrite(iV);
                }
            }
            catch
            {
                label_ValueBig2.Text = "错误";
            }
        }

        private string ChangeDataToBigWrite(int iSource)   // (转换 7.2格式 to 大写)
        {
            string sResult = "";
            string sBigWrite = "零壹贰叁肆伍陆柒捌玖拾";

            int iTmp = iSource;
            int iI = 0;
            if (iSource == 0)
            {
                sResult = "零元";
            }

            if (iSource >= 10000*100)   // 万元
            {
                if (iTmp >= 1000000 * 100)
                {
                    iI = iTmp / (1000000*100) ;
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "佰";
                       iTmp -= iI * 1000000*100;
                    }
                }

                if (iTmp >= (100000 *100))
                {
                    iI = iTmp / (100000*100);
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "拾";
                        iTmp -= iI * 100000*100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零拾";

                }

                if (iTmp >= 10000*100)
                {
                    iI = iTmp / (10000*100);
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1);
                        iTmp -= iI * 10000*100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零";
                }
                sResult += "萬";

                if (iTmp == 0)
                    sResult += "圆";
            }

            if (iSource >= 100)          // 1元
            {                                                              
                if (iTmp >= 1000*100 )
                {
                    iI = iTmp / (1000*100);
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "仟";
                        iTmp -= iI * 1000*100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零仟";
                }

                if (iTmp >= 100 * 100)
                {
                    iI = iTmp / (100*100);
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "佰";
                        iTmp -= iI * 100*100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零佰";
                }

                if (iTmp >= 10 * 100)
                {
                    iI = iTmp / (10 * 100);
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "拾";
                        iTmp -= iI * 10 * 100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零拾";
                }

                if (iTmp >= 100)
                {
                    iI = iTmp / 100;
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1);
                        iTmp -= iI * 100;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零";
                }
                sResult += "圆";
            }

            if (iTmp > 0)
            {
                if (iTmp >= 10)
                {
                    iI = iTmp / 10;
                    if (iI > 0)
                    {
                        sResult += sBigWrite.Substring(iI, 1) + "角";
                        iTmp -= iI * 10;
                    }
                }
                else
                {
                    if (sResult != "")
                        sResult += "零角";
                }

                if (iTmp > 0)
                {
                    sResult += sBigWrite.Substring(iTmp, 1) + "分";
                }
            }

            return sResult;
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            int i = 0;
            
            // 打印票据
            MyTools.sPrintTopic = "买方充值凭证";
            MyTools.sPrintID = "";

            MyTools.oPrintData = new string[10];
            MyTools.oPrintData[i++] = "卡片号码：" + textBox_CardID.Text;
            MyTools.oPrintData[i++] = "持卡人名：" + sUserName;
            MyTools.oPrintData[i++] = "--------------------------------------";
            MyTools.oPrintData[i++] = "卡片原额：" + textBox_OldBalance.Text;
            MyTools.oPrintData[i++] = "充值金额：" + textBox_Value.Text;
            MyTools.oPrintData[i++] = "充后余额：" + textBox_NewBalance.Text;
            MyTools.oPrintData[i++] = "充值类型：" + comboBox_Type.Text.Trim();

            MyTools.iPrintData = i;
            MyTools.PrintTicket();
        }

    }
}
