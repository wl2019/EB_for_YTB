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
    public partial class frm_Card_ChgPwd : Form
    {
        public string mszFlag;
        string mszTip;
        int miFee;
        int miUncofirmVal = 0;
        int miStoreID = 0;
       
        public frm_Card_ChgPwd()
        {
            InitializeComponent();
        }

        private void frm_Card_ChgPwd_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            button_Card_ChgPwd.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            textBox_Card_ChgPwd.Text = "";
            textBox_chg_pwd.Text = "";


            textBox_Card_Old.Text = "";
            textBox_Card_New.Text = "";
            textBox_Val.Text = "0.00";
            textBox_Fee.Text = MyStart.giFeeChgCard.ToString("0.00");
            miFee = MyStart.giFeeChgCard;
            tabControl1.SelectedIndex = 0;

            radioButton_lost_card.Checked = true;
            textBox_Card_Lost.Text = "";
            textBox_Card_Lost.Enabled = true;
            textBox_Cell_lost.Text = "";
            textBox_Cell_lost.Enabled = false;
            textBox_cert_lost.Text = "";
            textBox_cert_lost.Enabled = false;
            radioButton_unlost_card.Checked = true;
            textBox_unlost_card.Text = "";
            textBox_unlost_card.Enabled = true;
            textBox_unlost_cell.Text = "";
            textBox_unlost_cell.Enabled = false;
            textBox_unlost_cert.Text = "";
            textBox_unlost_cert.Enabled = false;
            textBox_unlost_pwd.Text = "";
            radioButton_chg_card.Checked = true;
            textBox_Card_Old.Text = "";
            textBox_Card_Old.Enabled = true;
            textBox_chg_cell.Text = "";
            textBox_chg_cell.Enabled = false;
            textBox_chg_cert.Text = "";
            textBox_chg_cert.Enabled = false;

            if (mszFlag.ToUpper() == "USER_CARD")
            {
                this.Text = "买方卡片管理";
                label_Inf_ChgPwd.Text = "说明：买方卡修改密码。";
                label_Inf_ChgCard.Text = "说明：买方卡更换卡片。";
                label_Inf_Lost.Text = "说明：买方卡挂失与解挂。";
                miUncofirmVal = 0;
            }
            else if (mszFlag.ToUpper() == "FIRM_CARD")
            {
                this.Text = "卖方卡片管理";
                label_Inf_ChgPwd.Text = "说明：只有卖方结算卡可修改密码。";
                label_Inf_ChgCard.Text = "说明：只有卖方结算卡可换卡。";
                label_Inf_Lost.Text = "说明：只有卖方结算卡可挂失与解挂。";
                miUncofirmVal = 1;
            }
            else
                this.Text = "卡片管理";

            mszTip = "挂失";

            comboBox_Why.Items.Clear();
            comboBox_Why.Items.Add("1-损坏");
            comboBox_Why.Items.Add("2-挂失");
            comboBox_Why.Items.Add("3 升级");
            comboBox_Why.Items.Add("4 降级");
            comboBox_Why.SelectedIndex = 1;
            label_LostCard.Text = "";
            label_unLostCard.Text = "";
            label_ChgCard.Text = "";

        }

        private void ReadCardNo(string szCardFlag, Button btnObj, TextBox EditObj)
        {
            CIcRdr myRdr = new CIcRdr();
            //string szErr = "";
            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("连接读卡器失败，请检查连接", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnObj.Focus();
                return;
            }

            //Application.DoEvents();
            if (!myRdr.Link())
            {
                MessageBox.Show("连接读卡器失败，请联系供应商", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                btnObj.Focus();
                return;
            }

            //Application.DoEvents();
            string szInf;
            if (!myRdr.ReadCardInf(out szInf))
            {
                MessageBox.Show("读卡失败，请重新放卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                btnObj.Focus();
                return;
            }

            if(szInf.Substring(0, 1).CompareTo(szCardFlag) != 0)
            {
                if (mszFlag.ToUpper() == "USER_CARD")
                    MessageBox.Show("卡号错误（不是买方卡），请换卡","操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (mszFlag.ToUpper() == "FIRM_CARD")
                {
                    if(szCardFlag == MyStart.gszCardYtbFirst)
                        MessageBox.Show("卡号错误（不是卖方结算卡），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("卡号错误（不是卖方卡），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myRdr.ComClose();
                btnObj.Focus();
                return;
            }
            EditObj.Text = szInf.Substring(0, 16);//szInf.Substring(1, 15); //
            myRdr.ComClose();
        }

        private void button_Card_ChgPwd_Click(object sender, EventArgs e)
        {
            ReadCardNo(MyStart.gszCardYtbFirst,button_Card_ChgPwd, textBox_Card_ChgPwd);
        }

        private void button_ChgPwd_Click(object sender, EventArgs e)
        {
            /*if (textBox_Old_Pwd.Text.Trim().ToUpper().CompareTo(MyStart.gszUserPwd.ToUpper()) != 0)
            {
                MessageBox.Show("旧密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Old_Pwd.Focus();
                return;
            }*/

            if (textBox_New_Pwd.Text.CompareTo(textBox_2nd_Pwd.Text) != 0)
            {
                MessageBox.Show("两次输入的新密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_New_Pwd.Focus();
                return;
            }

            //读旧卡密码密文
            //string szSql = "";
            string szErr = "";
            string szOldPwd = "";
            //if (mszFlag.ToUpper() == "USER_CARD")
            //{
            //    szSql = "select card_pwd,pwd_crypt from base_ucard where user_card='" + textBox_Card_ChgPwd.Text + "'";
            //}
            //else
            //{
            //    szSql = "select RMRK from mng_card where STORE_CARD='" + textBox_Card_ChgPwd.Text + "'";
            //}
            //DataSet ds = new DataSet();
            //int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            //if (iRst != 0)
            //{
            //    MessageBox.Show("读取卡片信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    MyIniFile.WriteLog(this.Text + "-更改密码", "SQL=" + szSql + ",Err=" + szErr);
            //    return;
            //}
            //int iNum = ds.Tables[0].Rows.Count;
            //if (iNum < 1)
            //{
            //    MessageBox.Show("查不到卡片信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    button_Card_ChgPwd.Focus();
            //    return;
            //}
            //if (iNum > 1)
            //{
            //    MessageBox.Show("卡片信息错误，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    button_Card_ChgPwd.Focus();
            //    return;
            //}

            //DataRow dr = ds.Tables[0].Rows[0];
            //string[] szX;
            //if (mszFlag.ToUpper() == "USER_CARD")
            //{
            //    if (textBox_Old_Pwd.Text.Trim().ToUpper().CompareTo(dr[0].ToString().ToUpper()) != 0)
            //    {
            //        MessageBox.Show("旧密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        textBox_Old_Pwd.Focus();
            //        return;
            //    }
            //    szOldPwd = dr[1].ToString();
            //}
            //else
            //{
            //    szX = dr[0].ToString().Split(',');
            //    if (textBox_Old_Pwd.Text.Trim().ToUpper().CompareTo(szX[0].ToString().ToUpper()) != 0)
            //    {
            //        MessageBox.Show("旧密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        textBox_Old_Pwd.Focus();
            //        return;
            //    }
            //    szOldPwd = szX[1];
            //}
            //银石后台验密
            EbHttpClass objHttp = new EbHttpClass();
            bool bRst = objHttp.GetPwdCrypt(textBox_Card_ChgPwd.Text.Trim(), textBox_Old_Pwd.Text.Trim(),ref szOldPwd,  ref szErr);
            if (!bRst)//szPwd != textBox_unlost_pwd.Text)
            {
                MessageBox.Show("旧密码错误！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Old_Pwd.Focus();
                return;
            }

            //银石后台修改
            string szNewPwd = "1," + textBox_New_Pwd.Text;
            //EbHttpClass objHttp = new EbHttpClass();
            /*bool*/ bRst = objHttp.ChgPwd(textBox_Card_ChgPwd.Text, szOldPwd, ref szNewPwd, ref szErr);
            if (!bRst)
            {
                MessageBox.Show("后台修改卡片密码失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            /*新密码和密文写DB
            //szNewPwd = textBox_New_Pwd.Text  + "," + szNewPwd;
            if (mszFlag.ToUpper() == "USER_CARD")
            {
                szSql = "update base_ucard set card_pwd='" + textBox_New_Pwd.Text + "',pwd_crypt='"
                    + szNewPwd + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                    + " where user_card='" + textBox_Card_ChgPwd.Text + "'";
            }
            else
            {
                szNewPwd = textBox_New_Pwd.Text + "," + szNewPwd;
                szSql = "update mng_card set RMRK='" + szNewPwd + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                    + " where CARD_TYPE=3 " + "and STORE_CARD='" + textBox_Card_ChgPwd.Text + "'";
            }
            try
            {
                int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("更改密码失败（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + "-更改密码", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("更改密码失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();*/
            MyFunc.WriteToDbLog(this.Text + "-更改密码", "卡号" + textBox_Card_ChgPwd.Text, "MSG", MyStart.giUserID);
            MessageBox.Show("更改密码成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_Card_Old_Click(object sender, EventArgs e)
        {
            //读卡号
            ReadCardNo(MyStart.gszCardYtbFirst,button_Card_Old, textBox_Card_Old);

            //银石后台读余额
            EbHttpClass objHttp = new EbHttpClass();
            int iVal=0;
            string szErr = "";
            bool bRst = objHttp.QryCard(textBox_Card_Old.Text,ref iVal,ref miUncofirmVal, ref szErr);
            if (!bRst)
            {
                MessageBox.Show("后台换卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox_Val.Text = ((decimal)iVal/100).ToString("#0.00");
        }

        private void button_Card_New_Click(object sender, EventArgs e)
        {
            ReadCardNo(MyStart.gszCardYtbFirst,button_Card_New, textBox_Card_New);
        }

        private void button_ChgCard_Click(object sender, EventArgs e)
        {
            if(textBox_Card_New.TextLength != 16)
            {
                MessageBox.Show("请输入换卡后，新卡卡号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string szSql = "";
            if (radioButton_chg_card.Checked)
            {
                if (textBox_Card_Old.TextLength != 16)
                {
                    MessageBox.Show("请输入换卡前，旧卡卡号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,cert_id,card_flag,card_pwd from base_ucard where user_card='" + textBox_Card_Old.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, cert_id,STORE_ID,RMRK from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_Card_Old.Text.Trim() + "'";
                }
            }
            if (radioButton_chg_cell.Checked)
            {
                if (textBox_chg_cell.TextLength <= 0)
                {
                    MessageBox.Show("手机号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_card,cert_id,card_flag,card_pwd from base_ucard where user_tel='" + textBox_chg_cell.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, STORE_CARD, cert_id,STORE_ID,RMRK from mng_card where CARD_TYPE = 3 and user_tel = '" + textBox_chg_cell.Text.Trim() + "'";
                }
            }
            if (radioButton_chg_cert.Checked)
            {
                if (textBox_chg_cert.TextLength <= 0)
                {
                    MessageBox.Show("身份证号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,user_card,card_flag,card_pwd from base_ucard where cert_id='" + textBox_chg_cert.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, STORE_CARD,STORE_ID,RMRK from mng_card where CARD_TYPE = 3 and  cert_id= '" + textBox_chg_cert.Text.Trim() + "'";
                }
            }

            //确认卡片信息
            //if (mszFlag.ToUpper() == "USER_CARD")//买方卡
            //{
            //    szSql = "select user_name,user_tel,cert_id from base_ucard where user_card='" + textBox_Card_Old.Text + "'";
            //}
            //else//卖方结算卡
            //{
            //    szSql = "select STORE_PERSON, user_tel, cert_id,STORE_ID from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_Card_Old.Text + "'";
            //}
            try
            {
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("卡片查询出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + "换卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum < 1)
                {
                    MessageBox.Show("查不到卡片信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                if (iNum > 1)
                {
                    MessageBox.Show("卡号关联多买方，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                DataRow dr = ds.Tables[0].Rows[0];
                string szPwd = "";
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szPwd = dr[4].ToString();
                }
                else//卖方结算卡
                {
                    string[] szItem = dr[4].ToString().Split(',');
                    szPwd = szItem[0];
                }


                //}
                string szCard = "";
                if (radioButton_chg_card.Checked)
                {
                    szCard = textBox_Card_Old.Text.Trim();
                    label_ChgCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_chg_cell.Checked)
                {
                    szCard = dr[1].ToString();
                    label_ChgCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + textBox_chg_cell.Text + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_chg_cert.Checked)
                {
                    szCard = dr[2].ToString();
                    label_ChgCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + textBox_chg_cert.Text;
                }
                //银石后台验密
                EbHttpClass objHttp = new EbHttpClass();
                bool bRst = objHttp.CheckPwd(szCard, textBox_chg_pwd.Text.Trim(), ref szErr);
                if (!bRst)//if (szPwd != textBox_chg_pwd.Text)
                {
                    MessageBox.Show("卡号密码错误，不能换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                if (DialogResult.No == MessageBox.Show("是否继续换卡操作？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    goto Eend;

                //EbHttpClass objHttp = new EbHttpClass();
                /*bool*/
                bRst = false;
                /*int iVal = 0;// Convert.ToInt16(Convert.ToDecimal( textBox_Val.Text)*100)/100;
                int iFee = miFee * 100;// Convert.ToInt16(Convert.ToDecimal(textBox_Fee.Text)*100);
                if (iFee > 0)
                {
                    if (iVal == 0)
                    {//银石后台读余额
                        bRst = objHttp.QryCard(MyStart.gszCardYtbFirst + textBox_Card_Old.Text, ref iVal,ref miUncofirmVal, ref szErr);
                        if (!bRst)
                        {
                            MessageBox.Show("后台读余额失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        textBox_Val.Text = (Convert.ToDecimal(iVal) /100).ToString("0.00");
                    }
                    if(iVal<iFee)
                    {
                        if(DialogResult.No== MessageBox.Show("卡内余额不足，是否继续?", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            return;
                    }

                    //扣费 -- not code yet
                    ;
                }*/

                //银石后台修改
                string szNewPwd = "888888";// + textBox_New_Pwd.Text;
                string[] szX = comboBox_Why.Text.Split('-');
                decimal dFee = Convert.ToDecimal(textBox_Fee.Text);
                bRst = objHttp.ChangeCard(szCard, textBox_Card_New.Text, szX[0], dFee, ref szNewPwd, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台换卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                if (mszFlag.ToUpper() != "USER_CARD")//重新捆绑
                {
                    miStoreID = Convert.ToInt16(dr[3]);
                    //read 
                    szSql = "select STORE_CARD, STORE_NAME,USER_TEL, a.cert_id from mng_card a,base_store b "
                        + "where a.STORE_ID = b.STORE_ID and CARD_TYPE = 1 and a.STORE_ID = " + miStoreID;
                    iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if (iRst != 0)
                    {
                        MessageBox.Show("换卖方卡查询出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(this.Text + "换卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                    iNum = ds.Tables[0].Rows.Count;
                    if (iNum < 1)
                    {
                        MessageBox.Show("查不到卖方卡信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        goto Eend;
                    }

                    dr = ds.Tables[0].Rows[0];
                    bRst = objHttp.IssueNewFirmCard(dr[0].ToString().Substring(1, 15), textBox_Card_New.Text, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), ref szNewPwd, ref szErr);
                    if (!bRst)
                    {
                        MessageBox.Show("后台绑定新的结算卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        goto Eend;
                    }
                }

                //旧卡写DB
                if (mszFlag.ToUpper() == "USER_CARD")//换买方卡
                {
                    szSql = "update base_ucard CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID + ",card_flag='STOP' where user_card = '" + szCard + "'";
                }
                else//换卖方结算卡
                {
                    szSql = "update mng_card set CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID + ",card_flag='STOP' where CARD_TYPE = 3 and STORE_CARD = '" + szCard + "'";
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("换卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + "换卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                //新卡写DB
                if (mszFlag.ToUpper() == "USER_CARD")//换买方卡
                {
                    //szSql = "update base_ucard set user_card = '" + textBox_Card_New.Text
                    //    + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID + " where user_card = '" + szCard + "'";
                    szSql = "insert into base_ucard(user_card, user_name, oper_time, USER_TEL, card_flag, CERT_ID, ADD_ID, rmrk, user_addr, card_type, parent_ID) "
                        + "(select '" + textBox_Card_New.Text + "', user_name, curtime(), USER_TEL, 'BGN', CERT_ID, " + MyStart.giUserID + ", rmrk, user_addr, card_type, parent_ID " +
                        "from base_ucard where user_card = '" + szCard + "')";
                }
                else//换卖方结算卡
                {
                    //szSql = "update mng_card set STORE_CARD = '" + textBox_Card_New.Text
                    //    + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID + " where CARD_TYPE = 3 and STORE_CARD = '" + szCard + "'";
                    szSql = "insert into mng_card(STORE_ID, STALL_ID, STORE_PERSON, USER_TEL, CARD_TYPE, STORE_CARD, CARD_STAT, ADD_DT, ADD_ID, CERT_ID, STALL_INF) "
                        + "(select STORE_ID, STALL_ID, STORE_PERSON, USER_TEL, 3, '" + szCard + "', 'BGN', curtime(),  " + MyStart.giUserID + ", CERT_ID, STALL_INF " +
                        "from mng_card where STORE_CARD = '" + szCard + "')";
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("换卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + "换卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MyFunc.WriteToDbLog(this.Text + "-换卡", "旧卡号" + szCard + ",新卡号" + textBox_Card_New.Text, "MSG", MyStart.giUserID);
                MessageBox.Show("换卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //收费记录
                if(checkBox_Fee.Checked && Convert.ToDecimal(textBox_Fee.Text) > 0)
                {
                    long lVal = (long)(Convert.ToDecimal(textBox_Fee.Text) * 100);
                    if (mszFlag.ToUpper() == "USER_CARD")//换买方卡
                    {
                        szSql = "insert into rec_user (card_no,oper_time,oper_type,chg_val,oper_id,tmn_id) values ('" + szCard
                           + "',curtime(),'CHG'," + lVal + "," + MyStart.giUserID + ",'" + frm_Main.POS_ID + "')";
                        iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                        if (iRst < 1)
                        {
                            MessageBox.Show("记录买方换卡工本费出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MyIniFile.WriteLog("买方换卡", "SQL=" + szSql + ",Err=" + szErr);
                            goto Eend;
                        }
                    }
                    else//换卖方结算卡
                    {
                        szSql = "select STORE_ID from mng_card where STORE_CARD='" + szCard + "'";
                        szErr = "";
                        iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                        if(iRst<1)
                        {
                            MessageBox.Show("查找卖方换卡记录出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MyIniFile.WriteLog("卖方换卡", "SQL=" + szSql + ",Err=" + szErr);
                            goto Eend;
                        }
                        dr = ds.Tables[0].Rows[0];
                        int iFirmID = Convert.ToInt32(dr[0]);

                        szSql = "insert into rec_firm (card_no,store_id,oper_time,oper_type,chg_val,oper_id,tmn_id) values ('"
                           + MyStart.gszCardFirmFirst + szCard + "'," + iFirmID + ",curtime(),'CHG',"
                           + lVal + "," + MyStart.giUserID + ",'" + frm_Main.POS_ID + "')";
                        iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                        if (iRst < 1)
                        {
                            MessageBox.Show("记录卖方换卡工本费出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MyIniFile.WriteLog("卖方换卡", "SQL=" + szSql + ",Err=" + szErr);
                            goto Eend;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("更换卡片失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Lost_Click(object sender, EventArgs e)
        {
            mszTip = "挂失";
            string szSql = "";
            if (radioButton_lost_card.Checked)
            {
                if (textBox_Card_Lost.TextLength != 16)
                {
                    MessageBox.Show("请输入" + mszTip + "卡的卡号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,cert_id,card_flag from base_ucard where user_card='" + textBox_Card_Lost.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, cert_id,CARD_STAT from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_Card_Lost.Text.Trim() + "'";
                }
            }
            if (radioButton_lost_cell.Checked)
            {
                if (textBox_Cell_lost.TextLength <=0)
                {
                    MessageBox.Show("手机号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_card,cert_id,card_flag from base_ucard where user_tel='" + textBox_Cell_lost.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, STORE_CARD, cert_id,CARD_STAT from mng_card where CARD_TYPE = 3 and user_tel = '" + textBox_Cell_lost.Text.Trim() + "'";
                }
            }
            if (radioButton_lost_cert.Checked)
            {
                if (textBox_cert_lost.TextLength <= 0)
                {
                    MessageBox.Show("身份证号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,user_card,card_flag from base_ucard where cert_id='" + textBox_cert_lost.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, STORE_CARD,CARD_STAT from mng_card where CARD_TYPE = 3 and  cert_id= '" + textBox_cert_lost.Text.Trim() + "'";
                }
            }

            //确认卡片信息
            //if (mszFlag.ToUpper() == "USER_CARD")//买方卡
            //{
            //    szSql = "select user_name,user_tel,cert_id,card_flag from base_ucard where user_card='" + textBox_Card_Lost.Text + "'";
            //}
            //else//卖方结算卡
            //{
            //    szSql = "select STORE_PERSON, user_tel, cert_id,CARD_STAT from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_Card_Lost.Text + "'";
            //}
            try
            { 
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("卡片查询出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + mszTip+"卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum < 1)
                {
                    MessageBox.Show("查不到卡片信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                if (iNum > 1)
                {
                    MessageBox.Show("卡号关联多买方，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                DataRow dr = ds.Tables[0].Rows[0];
                //bool bLost = (mszTip == "挂失" ? true : false);
                //if(bLost)
                //{
                    if(dr[3].ToString().ToUpper()=="LOST")
                    {
                        MessageBox.Show("卡号已挂失，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        goto Eend;
                    }
                //}
                //else
                //{
                //    if (dr[3].ToString().ToUpper() == "BGN")
                //    {
                //        MessageBox.Show("卡号已解挂，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                string szCard = "";
                if (radioButton_lost_card.Checked)
                {
                    szCard = textBox_Card_Lost.Text.Trim();
                    label_LostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_lost_cell.Checked)
                {
                    szCard = dr[1].ToString();
                    label_LostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + textBox_Cell_lost.Text + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_lost_cert.Checked)
                {
                    szCard = dr[2].ToString();
                    label_LostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + textBox_cert_lost.Text;
                }
                if (DialogResult.No == MessageBox.Show("是否继续"+ mszTip+"卡操作？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    goto Eend;

                //银石后台修改
                EbHttpClass objHttp = new EbHttpClass();
                bool bRst = objHttp.LostCard(true, szCard, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台"+mszTip+"卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //新卡写DB
                string szField = "LOST";// (bLost ? "LOST" : "BGN");
                if (mszFlag.ToUpper() == "USER_CARD")//换买方卡
                {
                    szSql = "update base_ucard set card_flag = '" + szField + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                        +" where user_card = '" + szCard + "'";
                }
                else//换卖方结算卡
                {
                    szSql = "update mng_card set CARD_STAT = '" + szField + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                        + " where CARD_TYPE = 3 and STORE_CARD = '" + szCard + "'";
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show(mszTip+"卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + mszTip+ "卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend; 
                }
                MyFunc.WriteToDbLog(this.Text + mszTip + "卡","卡号"+ textBox_Card_Lost.Text, "MSG", MyStart.giUserID);
                MessageBox.Show(mszTip+"卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("挂失卡片失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        Eend:
            MyStart.oMyDb.Close();
        }

        private void checkBox_Fee_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Fee.Enabled = checkBox_Fee.Checked;
            button_SaveFee.Enabled = checkBox_Fee.Checked;
        }

        private void button_SaveFee_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("确认要保存换卡手续费吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            string szErr = "";
            try
            { 
                int iRst = MyFunc.SetSysParaToDb(MyStart.oMyDb, "FEE_CHG_CARD", miFee.ToString(), ref szErr);
                if (iRst < 0)
                {
                    MessageBox.Show("操作错误：保存换卡手续费时出错。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MyFunc.WriteToDbLog("修改运营参数", "换卡手续费"+ textBox_Fee.Text+"元", "MSG", MyStart.giUserID);
                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存换卡手续费失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }

        private void textBox_Fee_TextChanged(object sender, EventArgs e)
        {
            miFee = Convert.ToInt16(Convert.ToDecimal(textBox_Fee.Text));
        }

        private void radioButton_lost_card_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Lost.Enabled = radioButton_lost_card.Checked;
            textBox_Cell_lost.Enabled = radioButton_lost_cell.Checked;
            textBox_cert_lost.Enabled=radioButton_lost_cert.Checked;
            textBox_Card_Lost.Focus();
            textBox_Cell_lost.Text = "";
            textBox_cert_lost.Text = "";
        }

        private void radioButton_lost_cell_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Lost.Enabled = radioButton_lost_card.Checked;
            textBox_Cell_lost.Enabled = radioButton_lost_cell.Checked;
            textBox_cert_lost.Enabled = radioButton_lost_cert.Checked;
            textBox_Cell_lost.Focus();
            textBox_Card_Lost.Text = "";
            textBox_cert_lost.Text = "";
        }

        private void radioButton_lost_cert_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Lost.Enabled = radioButton_lost_card.Checked;
            textBox_Cell_lost.Enabled = radioButton_lost_cell.Checked;
            textBox_cert_lost.Enabled = radioButton_lost_cert.Checked;
            textBox_cert_lost.Focus();
            textBox_Card_Lost.Text = "";
            textBox_Cell_lost.Text = "";
        }

        private void radioButton_unlost_card_CheckedChanged(object sender, EventArgs e)
        {
            textBox_unlost_card.Enabled = radioButton_unlost_card.Checked;
            textBox_unlost_cell.Enabled = radioButton_unlost_cell.Checked;
            textBox_unlost_cert.Enabled = radioButton_unlost_cert.Checked;
            textBox_unlost_card.Focus();
            textBox_unlost_cell.Text = "";
            textBox_unlost_cert.Text = "";
        }

        private void radioButton_unlost_cell_CheckedChanged(object sender, EventArgs e)
        {
            textBox_unlost_card.Enabled = radioButton_unlost_card.Checked;
            textBox_unlost_cell.Enabled = radioButton_unlost_cell.Checked;
            textBox_unlost_cert.Enabled = radioButton_unlost_cert.Checked;
            textBox_unlost_cell.Focus();
            textBox_unlost_card.Text = "";
            textBox_unlost_cert.Text = "";
        }

        private void radioButton_unlost_cert_CheckedChanged(object sender, EventArgs e)
        {
            textBox_unlost_card.Enabled = radioButton_unlost_card.Checked;
            textBox_unlost_cell.Enabled = radioButton_unlost_cell.Checked;
            textBox_unlost_cert.Enabled = radioButton_unlost_cert.Checked;
            textBox_unlost_cert.Focus();
            textBox_unlost_cell.Text = "";
            textBox_unlost_card.Text = "";
        }

        private void button_unlost_Click(object sender, EventArgs e)
        {
            mszTip = "解挂";
            string szSql = "";
            if (radioButton_unlost_card.Checked)
            {
                if (textBox_unlost_card.TextLength != 16)
                {
                    MessageBox.Show("请输入" + mszTip + "卡的卡号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,cert_id,card_flag,card_pwd from base_ucard where user_card='" + textBox_unlost_card.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, cert_id,CARD_STAT,RMRK from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_unlost_card.Text.Trim() + "'";
                }
            }
            if (radioButton_unlost_cell.Checked)
            {
                if (textBox_unlost_cell.TextLength <= 0)
                {
                    MessageBox.Show("手机号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_card,cert_id,card_flag,card_pwd from base_ucard where user_tel='" +  textBox_unlost_cell.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, STORE_CARD, cert_id,CARD_STAT,RMRK from mng_card where CARD_TYPE = 3 and user_tel = '" + textBox_unlost_cell.Text.Trim() + "'";
                }
            }
            if (radioButton_unlost_cert.Checked)
            {
                if (textBox_unlost_cert.TextLength <= 0)
                {
                    MessageBox.Show("身份证号不能为空", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szSql = "select user_name,user_tel,user_card,card_flag,card_pwd from base_ucard where cert_id='" + textBox_unlost_cert.Text.Trim() + "'";
                }
                else//卖方结算卡
                {
                    szSql = "select STORE_PERSON, user_tel, STORE_CARD,CARD_STAT,RMRK from mng_card where CARD_TYPE = 3 and  cert_id= '" + textBox_unlost_cert.Text.Trim() + "'";
                }
            }

            //确认卡片信息
            //if (mszFlag.ToUpper() == "USER_CARD")//买方卡
            //{
            //    szSql = "select user_name,user_tel,cert_id,card_flag from base_ucard where user_card='" + textBox_Card_Lost.Text + "'";
            //}
            //else//卖方结算卡
            //{
            //    szSql = "select STORE_PERSON, user_tel, cert_id,CARD_STAT from mng_card where CARD_TYPE = 3 and STORE_CARD = '" + textBox_Card_Lost.Text + "'";
            //}
            try
            { 
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("卡片查询出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + mszTip + "卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum < 1)
                {
                    MessageBox.Show("查不到卡片信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                if (iNum > 1)
                {
                    MessageBox.Show("卡号关联多买方，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                DataRow dr = ds.Tables[0].Rows[0];
                string szPwd = "";
                if (mszFlag.ToUpper() == "USER_CARD")//买方卡
                {
                    szPwd = dr[4].ToString();
                }
                else//卖方结算卡
                {
                    string[] szX = dr[4].ToString().Split(',');
                    szPwd = szX[0];
                }
                if (dr[3].ToString().ToUpper() == "BGN")
                {
                    MessageBox.Show("非挂失状态，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //bool bLost = (mszTip == "挂失" ? true : false);
                //if(bLost)
                //{
                //if (dr[3].ToString().ToUpper() == "LOST")
                //{
                //    MessageBox.Show("卡号已挂失，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //}
                //else
                //{
                //}
                string szCard = "";
                if (radioButton_unlost_card.Checked)
                {
                    szCard = textBox_unlost_card.Text.Trim();
                    label_unLostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_unlost_cell.Checked)
                {
                    szCard = dr[1].ToString();
                    label_unLostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + textBox_unlost_cell.Text + "\r\n" + "身份证号：" + dr[2].ToString();
                }
                if (radioButton_unlost_cert.Checked)
                {
                    szCard = dr[2].ToString();
                    label_unLostCard.Text = "卡号：" + szCard + "\r\n" + "持卡人：" + dr[0].ToString() + "\r\n" + "联系电话：" + dr[1].ToString() + "\r\n" + "身份证号：" + textBox_unlost_cert.Text;
                }
                if (DialogResult.No == MessageBox.Show("是否继续" + mszTip + "卡操作？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    goto Eend;

                ////银石后台验密
                //EbHttpClass objHttp = new EbHttpClass();
                //bool bRst = objHttp.CheckPwd(szCard, textBox_unlost_pwd.Text.Trim(), ref szErr);
                //if (!bRst)//szPwd != textBox_unlost_pwd.Text)
                //{
                //    MessageBox.Show("验密失败（后台"+szErr+"），不能解挂", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //MessageBox.Show("卡号密码错误，不能解挂", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                //银石后台修改
                EbHttpClass objHttp = new EbHttpClass();
                bool bRst = objHttp.LostCard(false, szCard, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台" + mszTip + "卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //新卡写DB
                string szField = "BGN";// (bLost ? "LOST" : "BGN");
                if (mszFlag.ToUpper() == "USER_CARD")//换买方卡
                {
                    szSql = "update base_ucard set card_flag = '" + szField + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                        + " where user_card = '" + szCard + "'";
                }
                else//换卖方结算卡
                {
                    szSql = "update mng_card set CARD_STAT = '" + szField + "',CHG_DT=curtime(),CHG_ID=" + MyStart.giUserID
                        + " where CARD_TYPE = 3 and STORE_CARD = '" + szCard + "'";
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show(mszTip + "卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(this.Text + mszTip + "卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MyFunc.WriteToDbLog(this.Text + mszTip + "卡", "卡号" + textBox_Card_Lost.Text, "MSG", MyStart.giUserID);
                MessageBox.Show(mszTip + "卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("解挂卡片失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
    }

    private void radioButton_chg_card_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Old.Enabled = radioButton_chg_card.Checked;
            textBox_chg_cell.Enabled = radioButton_chg_cell.Checked;
            textBox_chg_cert.Enabled = radioButton_chg_cert.Checked;
            textBox_Card_Old.Focus();
            textBox_chg_cell.Text = "";
            textBox_chg_cert.Text = "";
        }

        private void radioButton_chg_cell_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Old.Enabled = radioButton_chg_card.Checked;
            textBox_chg_cell.Enabled = radioButton_chg_cell.Checked;
            textBox_chg_cert.Enabled = radioButton_chg_cert.Checked;
            textBox_chg_cell.Focus();
            textBox_Card_Old.Text = "";
            textBox_chg_cert.Text = "";

        }

        private void radioButton_chg_cert_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Card_Old.Enabled = radioButton_chg_card.Checked;
            textBox_chg_cell.Enabled = radioButton_chg_cell.Checked;
            textBox_chg_cert.Enabled = radioButton_chg_cert.Checked;
            textBox_chg_cert.Focus();
            textBox_Card_Old.Text = "";
            textBox_chg_cell.Text = "";
        }
    }
}
