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
    public partial class frm_Card_QryVal : Form
    {
        CIcRdr myRdr = new CIcRdr();
        EbHttpClass objHttp = null;
        string sUserName = "";

        public string mszFlag;
        public frm_Card_QryVal()
        {
            InitializeComponent();
        }

        private void frm_Card_QryVal_Load(object sender, EventArgs e)
        {
            //this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            //pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            button_CheckCard.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            if (mszFlag.ToUpper() == "USER_CARD")
                this.Text = "买方卡余额查询";
            else if (mszFlag.ToUpper() == "FIRM_CARD")
                this.Text = "卖方卡余额查询";
            else
                this.Text = "卡片余额查询";

            NewAdd();
            button_CheckCard.Focus();
        }

        private void NewAdd()
        {
            textBox_CardID.Text = "";
            textBox_FinishBalance.Text = "";
            textBox_UnFinishBalance.Text = "";
            textBox_OldBalance.Text = "";
            sUserName = "";
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Card_QryVal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myRdr.ComIsOpen)
                myRdr.ComClose();
        }

        private void button_CheckCard_Click(object sender, EventArgs e)
        {
            string szInf = "";
            string sCardID = "";
            DataSet odt = null;
            string sErrMsg = "";

            if (!frm_Main.bHaveRd)
            {
                if (textBox_CardID.Text.Trim() != "")
                {
                    sCardID = textBox_CardID.Text;
                }
                else
                {
                    MessageBox.Show("没有连接读写器，也没有输入卡号，不能执行查询余额功能！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            goto Eend;
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

            if (sCardID.Substring(0, 1) == MyStart.gszCardFirmFirst )
            {
                MessageBox.Show("不接受商户卡查询余额，请换卡！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto Eend;
            }

            try
            {
                string sSql = "";
                if (mszFlag.ToUpper() == "FIRM_CARD")
                {
                    sSql = "SELECT * FROM mng_card WHERE STORE_CARD = '" + sCardID + "' AND card_type = 3";
                }
                else  // if (mszFlag.ToUpper() == "USER_CARD")
                {
                    sSql = "SELECT * FROM base_ucard WHERE user_card = '" + sCardID + "'";
                }

                int iRst = MyStart.oMyDb.ReadData(sSql, "TableA", ref odt, ref sErrMsg);
                if (iRst != 0)
                {
                    MessageBox.Show("后台查询卡余额失败( " + sErrMsg + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                if (odt.Tables[0].Rows.Count <= 0)
                {

                    if (mszFlag.ToUpper() == "FIRM_CARD")
                    {
                        MessageBox.Show("这是错误的商户结算卡，请更换。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else  // if (mszFlag.ToUpper() == "USER_CARD")
                    {
                        MessageBox.Show("没有此用户卡的信息，请更换。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    goto Eend;
                }

                if (mszFlag.ToUpper() == "FIRM_CARD")
                {
                    sUserName = odt.Tables[0].Rows[0]["STORE_PERSON"].ToString().Trim();
                }
                else  // if (mszFlag.ToUpper() == "USER_CARD")
                {
                    sUserName = odt.Tables[0].Rows[0]["user_name"].ToString().Trim();
                }

                //银石后台
                objHttp = new EbHttpClass();
                string szErr = "";
                int iValue = 0;
                int iTrade = 0;
                int CardBalance = 0;
                float fi = 0.00f;

                if (mszFlag.ToUpper() == "FIRM_CARD")
                {
                    iTrade = 1;
                }
                else
                {
                    iTrade = 0;
                }

                bool bRst = objHttp.QryCard(sCardID, ref iValue, ref iTrade, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台查询卡余额失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                }
                else
                {
                    if (mszFlag.ToUpper() == "FIRM_CARD")
                    {
                        fi = iValue;
                        fi = fi / 100;
                        textBox_FinishBalance.Text = fi.ToString("0.00");

                        if (iTrade > 0)
                        {
                            fi = iTrade;
                        }
                        else
                        {
                            fi = 0;
                        }
                        fi = fi / 100;
                        textBox_UnFinishBalance.Text = fi.ToString("0.00");

                        CardBalance = iValue + iTrade;
                        fi = CardBalance;
                        fi = fi / 100;
                        textBox_OldBalance.Text = fi.ToString("0.00");
                        MyFunc.WriteToDbLog("卖方资金-余额查询", " ", "MSG", MyStart.giUserID);
                    }
                    else
                    {
                        textBox_FinishBalance.Text = "";
                        textBox_UnFinishBalance.Text = "";
                        fi = iValue;
                        fi = fi / 100;
                        textBox_OldBalance.Text = fi.ToString("0.00");
                        MyFunc.WriteToDbLog("买方资金-余额查询", " ", "MSG", MyStart.giUserID);
                    }

                    if (checkBox1.Checked)
                    {
                        int i = 0;
                        // 打印票据
                        MyTools.sPrintTopic = "余额查询票据";
                        MyTools.sPrintID = "";

                        MyTools.oPrintData = new string[10];
                        MyTools.oPrintData[i++] = "卡片号码：" + textBox_CardID.Text;
                        MyTools.oPrintData[i++] = "持卡人名：" + sUserName;
                        MyTools.oPrintData[i++] = "--------------------------------------";
                        MyTools.oPrintData[i++] = "可取金额：" + textBox_FinishBalance.Text;
                        MyTools.oPrintData[i++] = "未结余额：" + textBox_UnFinishBalance.Text;
                        MyTools.oPrintData[i++] = "合计余额：" + textBox_OldBalance.Text;

                        MyTools.iPrintData = i;
                        MyTools.PrintTicket();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败 = " + ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Eend:
            if (odt != null)
                odt.Clear();
            MyStart.oMyDb.Close();

            button_CheckCard.Focus();
        }

    }
}
