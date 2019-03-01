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
    public partial class frm_Firm_Trans : Form
    {
        CIcRdr myRdr = new CIcRdr();
        EbHttpClass objHttp = null;
        public string mszFlag;
        string CardPwd = "";
        string CardHidePwd = "";
        string UserName = "";

        public frm_Firm_Trans()
        {
            InitializeComponent();
        }

        private void frm_Firm_Trans_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money16.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money32.png"));
            button_CheckUserCard.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_JK.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.money bag.ico"));
            button_Print.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.print.ico"));
            button_Retry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            //this.Text = "卖方卡结算";
            //textBox_Oper.Text = "卖方卡取款";
            //groupBox_FirstStep.Text = "第一步：验证卖方结算卡";
            //label_UserCardID.Text = "结算卡片";
            //button_CheckCustCard.Enabled = true;

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
            textBox_Pwd.Text = "";
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
            bool IsCust = false;
            string sCardID = "";

            if (!frm_Main.bHaveRd)
            {
                if (textBox_UserCardID.Text.Trim() != "")
                {
                    sCardID = textBox_UserCardID.Text;
                }
                else
                {
                    MessageBox.Show("没有连接读写器，也没有输入卡号，不能执行结算功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!myRdr.ComOpen(frm_Main.sRdPort))
                {
                    myRdr.ComClose();
                    if (textBox_UserCardID.Text.Trim() != "")
                    {
                        sCardID = textBox_UserCardID.Text;
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
                        if (textBox_UserCardID.Text.Trim() != "")
                        {
                            sCardID = textBox_UserCardID.Text;
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
            textBox_UserCardID.Text = sCardID;

            if (sCardID.Substring(0, 1) == MyStart.gszCardFirmFirst)
            {
                MessageBox.Show("不能使用卖方卡结算，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int iB = 0;
            int iT = 0;
            float fi = 0;
            if (!CheckCustCard(sCardID, ref IsCust, ref CardPwd, ref CardHidePwd, ref szInf))
            {
                MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Eend;
            }

            if (!IsCust)
            {
                MessageBox.Show("所使用的卡不是结算卡，请更换！" + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Eend;
            }

            iT = 1;  // 查未结算金额
            if (!GetCardBalance(sCardID, ref iB, ref iT, ref szInf))
            {
                MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                goto Eend;
            }

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
            if (iT <= 0)
            {
                button_JK.Enabled = false;
                textBox_Pwd.Enabled = false;
                button_Retry.Focus();
            }
            else
            {
                button_JK.Enabled = true;
                textBox_Pwd.Enabled = true;
                textBox_Pwd.Focus();
            }

            Eend:
            MyStart.oMyDb.Close();
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
            string sSql = "SELECT STORE_ID,STORE_CARD, RMRK, STORE_PERSON FROM mng_card WHERE CARD_TYPE = 3 AND STORE_CARD = '" + CustCardID + "' AND CARD_STAT = 'BGN'";
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
                    sErrMsg = "不是有效的卖方结算卡！";
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
                    sErrMsg = "不是有效的卖方结算卡！";
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

        private void button_JK_Click(object sender, EventArgs e)
        {
            string sErr = "";
            //if (textBox_Pwd.Text.Trim() != CardPwd)
            //{
            //    MessageBox.Show("密码错误!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //银石后台
            objHttp = new EbHttpClass();
            //bool bRst = objHttp.TransMoney(textBox_CustCardID.Text.Substring(1), textBox_UserCardID.Text, ref sErr);
            bool bRst = objHttp.TransMoney(sStoreCard.Substring(1), textBox_UserCardID.Text, textBox_Pwd.Text.Trim(), ref sErr);
            
            if (!bRst)
            {
                MessageBox.Show("结算失败：" + sErr, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int iB = 0;
                int iT = 0;
                int iOldBalance = 0;
                float fi = 0;
                string szInf = "";
                string sSql = "";

                if (!GetCardBalance(textBox_UserCardID.Text, ref iB, ref iT, ref szInf))
                {
                    MessageBox.Show("读数据库错误 = " + szInf, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    goto Eend;
                }
                //fi = iB;
                //fi /= 100;
                //textBox_FinishBalance.Text = fi.ToString("0.00");

                //if (iT <= 0)
                //{
                //    iT = 0;
                //}
                //fi = iT;
                //fi /= 100;
                //textBox_UnFinishBalance.Text = fi.ToString("0.00");

                iOldBalance = iB + iT;
                fi = iOldBalance;
                fi /= 100;
                textBox_NewBalance.Text = fi.ToString("0.00");

                // 写入数据库
                sSql = "INSERT INTO rec_firm (Card_No, Rmrk, STORE_ID, Oper_Time, Oper_Type, Before_Val, Chg_Val, After_Val, Oper_ID, Tmn_ID, Sys_ID) VALUE(" +
                       "'" + textBox_UserCardID.Text + "'," +
                       "'" + sStoreCard + "'," +
                       sStoreID + "," +
                       "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                       "'SETT',";
                float f = float.Parse(textBox_OldBalance.Text);
                f *= 100;
                int i = (int)(f+0.5);
                sSql += i.ToString() + ", 0,";

                i = iOldBalance;
                sSql += i.ToString() + "," +
                        MyStart.giUserID + "," +
                        "'" + frm_Main.POS_ID + "'," +
                        "0)";

                int iRst = MyStart.oMyDb.WriteData(sSql, ref szInf);
                if (iRst < 0)
                {
                    textBox_Result.Text = "结算成功! 但写数据库失败(" + szInf + ")";
                    MessageBox.Show("结算成功! 但写数据库失败(" + szInf + ")", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    textBox_Result.Text = "结算成功! ";
                    MessageBox.Show("结算成功!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // log
                MyFunc.WriteToDbLog("卖方资金-结算", " ", "MSG", MyStart.giUserID);


                // 打印
                // button_Print_Click(sender, e);

                groupBox_ThirdStep.Enabled = false;
                groupBox_FourthStep.Enabled = true;

                Eend:
                MyStart.oMyDb.Close();
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            int i = 0;
            // Print
            MyTools.sPrintTopic = "卖方结算票据";
            MyTools.sPrintID = "";

            MyTools.oPrintData = new string[10];
            MyTools.oPrintData[i++] = "卡片号码：" + textBox_UserCardID.Text;
            MyTools.oPrintData[i++] = "持卡人名：" + UserName;
            MyTools.oPrintData[i++] = "--------------------------------------";
            MyTools.oPrintData[i++] = "原有金额：" + textBox_FinishBalance.Text;
            MyTools.oPrintData[i++] = "结算余额：" + textBox_UnFinishBalance.Text;
            MyTools.oPrintData[i++] = "结后余额：" + textBox_NewBalance.Text;

            MyTools.iPrintData = i;
            MyTools.PrintTicket();
        }
}
}
