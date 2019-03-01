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
    public partial class frm_Card_MinusVal : Form
    {
        CIcRdr myRdr = new CIcRdr();
        EbHttpClass objHttp = null;
        public string mszFlag;
        string CardPwd = "";
        string CardHidePwd = "";
        string UserName = "";
        public frm_Card_MinusVal()
        {
            InitializeComponent();
        }

        private void frm_Card_MinusVal_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money16.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money32.png"));
            button_CheckUserCard.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_MinusValue.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money16.ico"));
            button_Print.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.print.ico"));
            button_Retry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            if (mszFlag.ToUpper() == "FIRM_CARD")
            {
                this.Text = "卖方卡取款";
                textBox_Oper.Text = "卖方卡取款";
                groupBox_FirstStep.Text = "第一步：验证卖方结算卡";
                label_UserCardID.Text = "结算卡片";
            }
            else // if (mszFlag.ToUpper() == "USER_CARD")
            {
                this.Text = "买方卡取款";
                textBox_Oper.Text = "买方卡取款";
                groupBox_FirstStep.Text = "第一步：验证买方卡";
                label_UserCardID.Text = "买方卡片";
            }
            comboBox_Type.Items.Clear();
            string szSql = "select sub_type from base_value where type=2 order by id";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                //MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MyIniFile.WriteLog("查询卖方卡交易记录", "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum > 0)
            {
                for (int i = 0; i < iNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Type.Items.Add(dr[0].ToString());
                }
                comboBox_Type.SelectedIndex = 0;
            }
            NewAdd();
            button_Retry.Enabled = false;
            //if (!frm_Main.bHaveRd)
            //{
            //    MessageBox.Show("没有连接读写器，不能执行取款功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    groupBox_FirstStep.Enabled = false;
            //    return;
            //}

            //if (!myRdr.ComOpen(frm_Main.sRdPort))
            //{
            //    MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    groupBox_FirstStep.Enabled = false;
            //    return;
            //}
            button_CheckUserCard.Focus();
        }

        private void NewAdd()
        {
            groupBox_FirstStep.Enabled = true;
            textBox_UserCardID.Text = "";

            groupBox_ThirdStep.Enabled = false;
            textBox_FinishBalance.Text = "";
            textBox_UnFinishBalance.Text = "";
            textBox_OldBalance.Text = "";
            textBox_Value.Text = "";
            textBox_Value2.Text = "";
            textBox_Pwd.Text = "";
            CardPwd = "";
            CardHidePwd = "";
            UserName = "";

            groupBox_FourthStep.Enabled = false;
            textBox_Result.Text = "";
            textBox_NewBalance.Text = "";
        }

        private void button_CheckUserCard_Click(object sender, EventArgs e)
        {
            string szInf = "";
            bool IsUser = false;
            bool IsCust = false;
            string sCardID = "";
            
            if (!frm_Main.bHaveRd)
            {
                MessageBox.Show("没有连接读写器，不能执行取款功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myRdr.ComClose();
                return;
            }

            if (!myRdr.ReadCardInf(out szInf))
            {
                if (textBox_UserCardID.Text.Trim() != "")
                {
                    sCardID = textBox_UserCardID.Text.Trim();
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
            myRdr.ComClose();
            textBox_UserCardID.Text = sCardID;
            
            //sCardID = textBox_UserCardID.Text;
            if (sCardID.Substring(0, 1) == MyStart.gszCardFirmFirst)
            {
                MessageBox.Show("这是卖方卡，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int iB = 0;
            int iT = 0;
            float fi = 0;
            if (mszFlag.ToUpper() == "USER_CARD")
            {
                if (!CheckUserCard(sCardID, ref IsUser, ref CardPwd, ref CardHidePwd, ref szInf))
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsUser)
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("所使用的卡不是买方卡，请更换！" + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!GetCardBalance(sCardID, ref iB, ref iT, ref szInf))
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else   // (mszFlag.ToUpper() == "FIRM_CARD")
            {
                if (!CheckCustCard(sCardID, ref IsCust, ref CardPwd, ref CardHidePwd, ref szInf))
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsCust)
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("所使用的卡不是卖方卡，请更换！" + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                iT = 1;  // 查未结算金额
                if (!GetCardBalance(sCardID, ref iB, ref iT, ref szInf))
                {
                    MyStart.oMyDb.Close();
                    MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            MyStart.oMyDb.Close();

            fi = iB;
            fi /= 100;
            textBox_FinishBalance.Text = fi.ToString("0.00");

            fi = iT;
            fi /= 100;
            textBox_UnFinishBalance.Text = fi.ToString("0.00");

            fi = (iB + iT);
            fi /= 100;
            textBox_OldBalance.Text = fi.ToString("0.00");

            groupBox_FirstStep.Enabled = false;
            groupBox_ThirdStep.Enabled = true;
            button_Retry.Enabled = true;
            textBox_Value.Focus();
        }


        private bool CheckUserCard(string sCardID, ref bool IsUserCard, ref string sCardPwd, ref string sCardHidePws, ref string sErrMsg)
        {
            // 在数据库中检查是否 UserCard
            bool bResult = false;
            string sSql = "SELECT * FROM base_ucard WHERE user_card = '" + sCardID + "' AND card_flag = 'BGN'";
            DataSet odt = new DataSet();
            IsUserCard = false;

            try
            {
                int iRst = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
                if (iRst == 0)
                {
                    if (odt.Tables[0].Rows.Count > 0)
                    {
                        sCardPwd = odt.Tables[0].Rows[0]["card_pwd"].ToString().Trim();
                        sCardHidePws = odt.Tables[0].Rows[0]["pwd_crypt"].ToString().Trim();
                        UserName = odt.Tables[0].Rows[0]["user_name"].ToString().Trim();
                        IsUserCard = true;
                        sErrMsg = "";
                    }
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
            }
            return bResult;
        }

        string sStoreID = "";
        string sStoreCard = "";
        private bool CheckCustCard(string CustCardID, ref bool IsCust, ref string sCardPwd, ref string sCardHidePws, ref string sErrMsg)
        {
            // 检查是否提款卡
            bool bResult = false;
            sStoreID = "";
            IsCust = false;
            sCardPwd = "";
            sCardHidePws = "";
            sErrMsg = "";
            string sSql = "SELECT STORE_ID, STORE_CARD, RMRK, STORE_PERSON FROM mng_card WHERE CARD_TYPE = 3 AND STORE_CARD = '" + CustCardID + "' AND CARD_STAT = 'BGN'";
            DataSet odt = null;

            try
            {
                odt = new DataSet();

                int iRst = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
                if (iRst != 0)
                {
                    goto Eend;
                }

                if (odt.Tables[0].Rows.Count <= 0)
                {
                    bResult = true;                      // 不是 pair
                    sErrMsg = "不是有效的卖方提款卡！";
                    goto Eend;
                }

                sStoreID = odt.Tables[0].Rows[0]["STORE_ID"].ToString().Trim();
                UserName = odt.Tables[0].Rows[0]["STORE_PERSON"].ToString().Trim();
                string sTmp = odt.Tables[0].Rows[0]["RMRK"].ToString().Trim();
                if (sTmp.IndexOf(',') > 0)
                {
                    string[] sTemp = sTmp.Split(',');
                    sCardPwd = sTemp[0];
                    sCardHidePws = sTemp[1];
                }

                odt = new DataSet();
                sSql = "SELECT STORE_ID, STORE_CARD, RMRK FROM mng_card WHERE CARD_TYPE = 1 AND STORE_ID = " + sStoreID + " AND CARD_STAT = 'BGN'";
                iRst = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
                if (iRst != 0)
                {
                    // sErrMsg 从程序中返回
                    goto Eend;
                }

                if (odt.Tables[0].Rows.Count <= 0)
                {
                    bResult = true;            // 不是 pair
                    sErrMsg = "不是有效的卖方提款卡！";
                    goto Eend;
                }

                sStoreCard = odt.Tables[0].Rows[0]["STORE_CARD"].ToString().Trim();
                IsCust = true;
                bResult = true;
                sErrMsg = "";
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                return false;
            }
            Eend:
            if (odt != null)
                odt.Clear();

            return bResult;
        }

        private void button_MinusValue_Click(object sender, EventArgs e)
        {
            float fValue = 0.00f;
            float fBalance = 0;

            textBox_Value.Text = textBox_Value.Text.Trim();
            textBox_Value2.Text = textBox_Value2.Text.Trim();
            try
            {
                fValue = float.Parse(textBox_Value.Text.Trim());
            }
            catch
            {
                MessageBox.Show("取款金额错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Value.Focus();
                return;
            }

            if (textBox_Value.Text != textBox_Value2.Text)
            {
                MessageBox.Show("两次输入的取款金额不相等！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Value.Focus();
                return;
            }

            if (fValue == 0)
            {
                MessageBox.Show("取款金额不能为0！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Value.Focus();
                return;
            }

            //// 检查密码
            //if ( CardPwd != textBox_Pwd.Text.Trim())
            //{
            //    MessageBox.Show("取款密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textBox_Pwd.Focus();
            //    return;
            //}

            // 检查余额是否足够
            if (mszFlag.ToUpper() == "FIRM_CARD")
            {
                fBalance = float.Parse(textBox_FinishBalance.Text.Trim());
            }
            else
            {
                fBalance = float.Parse(textBox_OldBalance.Text.Trim());
            }

            if (fValue > fBalance)
            {
                MessageBox.Show("取款金额不足够！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Value.Focus();
                return;
            }
            
            // 取得TradeID
            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("打开串口失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            
            //银石后台
            objHttp = new EbHttpClass();

            fValue *= -1;
            string szSysID = iReaderTradeID.ToString();
            string szErr = "";
            bool bRst = false;

            if (mszFlag.ToUpper() == "USER_CARD")
            {
                bRst = objHttp.OperUserMoney("MinusVal", textBox_UserCardID.Text, fValue, szSysID, textBox_Pwd.Text.Trim(), ref szErr);
            }
            else
            {
                bRst = objHttp.OperFirmMoney(sStoreCard.Substring(1), textBox_UserCardID.Text, fValue, szSysID, textBox_Pwd.Text.Trim(), ref szErr);
            }

            if (bRst)
            {
                string sSql = "";
                string szInf = "";
                float f = 0;
                int i;

                // 余额显示
                fValue *= -1;
                f = fBalance - fValue;
                textBox_NewBalance.Text = f.ToString("0.00");

                // 写入数据库
                if (mszFlag.ToUpper() == "USER_CARD")
                {
                    // 写入数据库
                    sSql = "INSERT INTO rec_user (Card_No, Oper_Time, Oper_Type,Oper_SubType, Before_Val, Chg_Val, After_Val, Oper_ID, Tmn_ID, Sys_ID) VALUE(" +
                           "'" + textBox_UserCardID.Text + "'," +
                           "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                           "'CASH','"+comboBox_Type.Text.Trim()+"',";
                    f = float.Parse(textBox_OldBalance.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + ",";

                    f = float.Parse(textBox_Value.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + ",";

                    f = float.Parse(textBox_NewBalance.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + "," +
                            MyStart.giUserID + "," +
                            "'" + frm_Main.POS_ID + "'," +
                            iReaderTradeID.ToString() + ")";
                }
                else
                {
                    sSql = "INSERT INTO rec_firm (Card_No, Rmrk, STORE_ID, Oper_Time, Oper_Type,Oper_SubType, Before_Val, Chg_Val, After_Val, Oper_ID, Tmn_ID, Sys_ID) VALUE(" +
                       "'" + textBox_UserCardID.Text + "'," +
                       "'" + sStoreCard + "'," +
                       sStoreID + "," +
                       "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                       "'CASH','" + comboBox_Type.Text.Trim() + "',";

                    f = float.Parse(textBox_OldBalance.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + ",";

                    f = float.Parse(textBox_Value.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + ",";

                    f = float.Parse(textBox_NewBalance.Text);
                    f *= 100;
                    i = (int)(f+0.5);
                    sSql += i.ToString() + "," +
                            MyStart.giUserID + "," +
                            "'" + frm_Main.POS_ID + "'," + szSysID.ToString() + ")";
                }

                int iRst = MyStart.oMyDb.WriteData(sSql, ref szInf);
                if (iRst <= 0)
                {
                    textBox_Result.Text = "取款成功! 但写数据库失败(" + szInf + ")";
                }
                else
                {
                    textBox_Result.Text = "取款成功!";
                }
                // log
                if (mszFlag.ToUpper() == "USER_CARD")
                {
                    MyFunc.WriteToDbLog("买方资金-退款", "买方卡号=" + textBox_UserCardID.Text + ",取款=" + textBox_Value.Text + "元,时间=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "MSG", MyStart.giUserID);
                }
                else
                {
                    MyFunc.WriteToDbLog("卖方资金-提款", "卖方卡号=" + textBox_UserCardID.Text + ",取款=" + textBox_Value.Text + "元,时间=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "MSG", MyStart.giUserID);
                }

                MyStart.oMyDb.Close();

                //打印票据
                button_Print_Click(sender, e);
                button_Print_Click(sender, e);
            }
            else
            {
                textBox_Result.Text = "取款失败 = " + szErr;
                textBox_NewBalance.Text = textBox_FinishBalance.Text;
            }

            groupBox_ThirdStep.Enabled = false;
            groupBox_FourthStep.Visible = true;
            groupBox_FourthStep.Enabled = true;
            button_Retry.Focus();
        }

        private void button_Retry_Click(object sender, EventArgs e)
        {
            NewAdd();
            button_CheckUserCard.Focus();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            if (myRdr.ComIsOpen)
                myRdr.ComClose();

            this.Close();
        }

        private void textBox_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b' || e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool GetCardBalance(string sCardID, ref int iBalance, ref int iTrade,  ref string sErrMsg)
        {
            //银石后台
            objHttp = new EbHttpClass();
            bool bRst = objHttp.QryCard(sCardID, ref iBalance, ref iTrade, ref sErrMsg);
            return bRst;
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            int i = 0;

            // 打印票据
            if (mszFlag.ToUpper() == "FIRM_CARD")
            {
                MyTools.sPrintTopic = "卖方取款凭证";
            }
            else
            {
                MyTools.sPrintTopic = "买方取款凭证";
            }
            MyTools.sPrintID = "";

            MyTools.oPrintData = new string[10];
            MyTools.oPrintData[i++] = "卡片号码：" + textBox_UserCardID.Text ;
            MyTools.oPrintData[i++] = "持卡人名：" + UserName;
            MyTools.oPrintData[i++] = "--------------------------------------";
            MyTools.oPrintData[i++] = "卡片原额：" + textBox_OldBalance.Text;
            MyTools.oPrintData[i++] = "取款金额：" + textBox_Value.Text;
            MyTools.oPrintData[i++] = "取后余额：" + textBox_NewBalance.Text;

            MyTools.iPrintData = i;
            MyTools.PrintTicket();
        }
    }
}
