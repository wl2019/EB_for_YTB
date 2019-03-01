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
    public partial class frm_Firm_Card : Form
    {
        string mszFirm;
        string mszStall;
        string mszPerson;
        string mszCell;
        string mszCardTYpe;
        string mszCard;
        string mszCertID;
        int miFirmID;
        int miStallID;
        string mszStallInf;
        int miFee;


        public frm_Firm_Card()
        {
            InitializeComponent();
        }
        private void GridDataRefresh(int iFirmID, int iStallID)
        {
            DataSet ds = new DataSet();
            string szErr = "";
            /*string szSql = "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称,"
                + " concat(b.STALL_ID, '-', b.STALL_INF) as 档口信息,"
                + "b.STALL_PERSON as 档口联系人,b.STALL_TEL as 联系人电话,substring(c.STORE_CARD,2) as 卖方卡号 "
                + "FROM base_store a, base_stall b,mng_card c "
                + " WHERE c.CARD_STAT = 'BGN' and a.STORE_ID = b.STORE_ID and b.STALL_ID = c.STALL_ID ";*/
            /*string szSql = "(SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称,"
                + "concat(b.STALL_ID, '-', b.STALL_INF) as 档口信息,"
                + "b.STALL_PERSON as 档口联系人,b.STALL_TEL as 联系人电话,"
                + "if(CARD_TYPE=1,'第一副卡',if(CARD_TYPE=3,'结算卡','副卡')) as 卡类,"
                + "substring(c.STORE_CARD, 2) as 卖方卡,b.CERT_ID as 身份证号 "
                + "FROM base_store a, base_store b, mng_card c "
                + "WHERE c.CARD_STAT = 'BGN' and a.STORE_ID = b.STORE_ID and b.STALL_ID = c.STALL_ID";
            if (iFirmID > 0)
                szSql += " and a.STORE_ID=" + iFirmID;
            if (iStallID > 0)
                szSql += " and b.STALL_ID=" + iStallID;
            szSql += " ORDER by a.STORE_ID,b.STALL_ID,c.CARD_ID)";
            */
            string szSql="";
            if(iStallID>0)//card(stall)
            {
                szSql = "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称, concat(c.STALL_ID, '-', c.STALL_INF) as 档口信息, "
                    +"b.STORE_PERSON as 联系人,USER_TEL as 联系电话,'副卡' as 卡类,STORE_CARD as 卡号, "
                    +"if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态, "
                    +"b.cert_id as 身份证,ADD_DT as 发卡时间 FROM mng_card b,base_store a, base_stall c "
                    +"WHERE a.STORE_ID = b.STORE_ID and b.STORE_ID = c.STORE_ID and b.STALL_ID = c.STALL_ID "
                    +"and b.CARD_TYPE = 2 and b.STORE_ID = " + iFirmID + " and b.STALL_ID=" + iStallID;
            }
            else//all card (firm and stall)
            {
                szSql = "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称, '' as 档口信息,"
                    + "b.STORE_PERSON as 联系人,USER_TEL as 联系电话,"
                    + "if (CARD_TYPE = 1,'第一副卡','结算卡') as 卡类,STORE_CARD as 卡号,"
                    + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,"
                    + "b.cert_id as 身份证,ADD_DT as 发卡时间 FROM mng_card b,base_store a "
                    + "WHERE a.STORE_ID = b.STORE_ID and b.CARD_TYPE <> 2 and b.STORE_ID = "+ iFirmID
                    + " union "
                    + "SELECT concat(a.STORE_ID, '-', a.STORE_NAME) as 卖方名称, concat(c.STALL_ID, '-', c.STALL_INF) as 档口信息, "
                    + "b.STORE_PERSON as 联系人,USER_TEL as 联系电话,'副卡' as 卡类,STORE_CARD as 卡号, "
                    + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态, "
                    + "b.cert_id as 身份证,ADD_DT as 发卡时间 FROM mng_card b,base_store a, base_stall c "
                    + "WHERE a.STORE_ID = b.STORE_ID and b.STORE_ID = c.STORE_ID and b.STALL_ID = c.STALL_ID "
                    + "and b.CARD_TYPE = 2 and b.STORE_ID = " + iFirmID;
            }
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            dataGridView1.RowHeadersWidth = 15;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            MyStart.oMyDb.Close();
            if (iNum == 0)
            {
                label_num.Text = "";
                return;
            }
            label_num.Text = "共发卡 " + iNum +" 张";

            mszFirm = dataGridView1.Rows[0].Cells[0].Value.ToString();
            mszStall = dataGridView1.Rows[0].Cells[1].Value.ToString();
            mszPerson = dataGridView1.Rows[0].Cells[2].Value.ToString();
            mszCell = dataGridView1.Rows[0].Cells[3].Value.ToString();
            mszCardTYpe= dataGridView1.Rows[0].Cells[4].Value.ToString();
            mszCard = dataGridView1.Rows[0].Cells[5].Value.ToString();
            mszCertID = dataGridView1.Rows[0].Cells[7].Value.ToString();
            /*
            comboBox_NameM.Text = mszFirm;
            comboBox_NameS.Text = mszFirm;
            comboBox_Rent.Text = mszStall;
            switch(mszCardTYpe)
            {
                case "第一副卡":
                    textBox_PersonM.Text = mszPerson;
                    textBox_TelM.Text = mszCell;
                    textBox_CertIDM.Text = mszCertID;
                    textBox_CardM.Text = mszCard;
                    break;
                case "副卡":
                    textBox_PersonS.Text = mszPerson;
                    textBox_TelS.Text = mszCell;
                    textBox_CertIDS.Text = mszCertID;
                    textBox_CardS.Text = mszCard;
                    break;
                case "结算卡":
                    textBox_PersonM.Text = mszPerson;
                    textBox_TelM.Text = mszCell;
                    textBox_CertIDM.Text = mszCertID;
                    textBox_CardV.Text = mszCard;
                    break;
            }*/
        }
        private void frm_Firm_Card_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            button_SaveM.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_SaveS.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Cancel.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_CardM.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_CardS.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_CardV.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            label_num.Text = "";

            textBox_CardM.Text = "";
            textBox_CardV.Text = "";
            textBox_CardS.Text = "";

            textBox_PersonM.Text = "";
            textBox_PersonS.Text = "";

            textBox_TelM.Text = "";
            textBox_TelS.Text = "";

            textBox_CertIDM.Text = "";
            textBox_CertIDS.Text = "";

            textBox_search.Text = "";

            checkBox_Fee_M.Checked = true;
            textBox_Fee_M.Text = MyStart.giFeeChgCard.ToString("0.00");
            checkBox_Fee_S.Checked = true;
            textBox_Fee_S.Text = MyStart.giFeeChgCard.ToString("0.00");
            miFee = MyStart.giFeeChgCard;

            DataSet ds = new DataSet();
            string szErr = "";
            int iStoreNum = 0;//卖方
            string szSql = "select concat(store_id,'-',store_name) from base_store where STORE_STAT='USED' order by store_id desc";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                //if (iStoreNum > 0)
                //    comboBox_Firm.Items.Add("0-所有卖方");
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Firm.Items.Add(dr[0].ToString());
                    comboBox_NameM.Items.Add(dr[0].ToString());
                    comboBox_NameS.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
            {
                comboBox_Firm.SelectedIndex = 0;
                comboBox_Stall.Enabled = false;
                comboBox_NameM.SelectedIndex = 0;
                comboBox_NameS.SelectedIndex = 0;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MyStart.oMyDb.Close();
        }

        private void comboBox_Firm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_Firm.SelectedIndex > 0)
            //    comboBox_Stall.Enabled = true;
            //else
            //{
            //    comboBox_Stall.Enabled = false;
            //    comboBox_Stall.Text = "";
            //    return;
            //}
            string[] szFirmInf = comboBox_Firm.Text.Split('-');
            miFirmID = Convert.ToInt16(szFirmInf[0]);
            MyFunc.DispStall(comboBox_Firm, comboBox_Stall, true);
            if (comboBox_Stall.Items.Count > 0)
                comboBox_Stall.SelectedIndex = 0;
            GridDataRefresh(miFirmID, 0);
        }

        private void comboBox_Stall_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] szStallInf = comboBox_Stall.Text.Split('-');
            miStallID = Convert.ToInt16(szStallInf[0]);
            GridDataRefresh(miFirmID, miStallID);
        }

        private void button_SaveM_Click(object sender, EventArgs e)
        {
            if (textBox_CardM.Text.Length != 15)
            {
                MessageBox.Show("第一副卡卡号长度错误（卖方卡号长度为15），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_CardM.Focus();
                return;
            }
            if (textBox_CardV.Text.Length != 16)
            {
                MessageBox.Show("结算卡卡号长度错误（卖方卡号长度为16），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_CardM.Focus();
                return;
            }
            if (textBox_pwd.Text.Trim()!=textBox_pwd2.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不同，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_pwd.SelectAll();
                textBox_pwd.Focus();
                return;
            }


            DataSet ds = new DataSet();
            string szErr = "";
            string[] szFirmInf = comboBox_NameM.Text.Split('-');
            int iFirmID = Convert.ToInt16(szFirmInf[0]);
            string szSql = "select * from mng_card where STORE_CARD='" + MyStart.gszCardFirmFirst + textBox_CardM.Text.Trim() + "'";
            try
            {
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    MessageBox.Show("卡号重复，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_CardM.Focus();
                    goto Eend;
                }

                szSql = "select * from mng_card a where CARD_TYPE = 1 and store_id = " + iFirmID;
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    MessageBox.Show("该卖方已发第一副卡和结算卡，请换卖方", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox_NameM.Focus();
                    goto Eend;
                }

                //必须同时发第一副卡和结算卡
                if (textBox_CardM.TextLength == 0 || textBox_CardV.TextLength == 0)
                {
                    MessageBox.Show("第一副卡和结算卡必须同时发放，请输入卡号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_CardM.Focus();
                    goto Eend;
                }
                if (textBox_pwd.TextLength != 6)
                {
                    MessageBox.Show("必须设置提款密码！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_pwd.Focus();
                    goto Eend;

                }
                //连接银石后台
                EbHttpClass objHttp = new EbHttpClass();
                string szPwd = "1," + textBox_pwd.Text;
                bool bRst = objHttp.IssueNewUserCard(textBox_CardV.Text, szFirmInf[1],textBox_TelM.Text, textBox_CertIDM.Text, ref szPwd, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台注册结算卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //EbHttpClass objHttp = new EbHttpClass();
                szPwd = textBox_pwd.Text;
                bRst = objHttp.IssueNewFirmCard(textBox_CardM.Text, textBox_CardV.Text, szFirmInf[1], textBox_TelM.Text, textBox_CertIDM.Text, ref szPwd, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台注册卖方卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                //写入DB
                szPwd = textBox_pwd.Text + "," + szPwd;
                szSql = "INSERT INTO mng_card (STORE_ID,STORE_PERSON,USER_TEL,CERT_ID,CARD_TYPE,STORE_CARD,RMRK,ADD_DT,ADD_ID) VALUES ("
                    + iFirmID + ",'" + textBox_PersonM.Text.Trim() + "','" + textBox_TelM.Text.Trim() + "','"
                    + textBox_CertIDM.Text.Trim() + "',1,'"
                    + MyStart.gszCardFirmFirst + textBox_CardM.Text.Trim() + "',' ',curtime()," + MyStart.giUserID + ")";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("发卖方第一副卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                szSql = iFirmID + "-持卡人" + textBox_PersonM.Text.Trim() + "-电话" + textBox_TelM.Text.Trim() + "-卡号"
                    + textBox_CardM.Text.Trim();
                MyFunc.WriteToDbLog("发卖方第一副卡", szSql, "MSG", MyStart.giUserID);

                szSql = "INSERT INTO mng_card (STORE_ID,STORE_PERSON,USER_TEL,CERT_ID,CARD_TYPE,STORE_CARD,RMRK,ADD_DT,ADD_ID) VALUES ("
                    + iFirmID + ",'" + textBox_PersonM.Text.Trim() + "','" + textBox_TelM.Text.Trim() + "','"
                    + textBox_CertIDM.Text.Trim() + "',3,'"
                    + textBox_CardV.Text.Trim() + "',' ',curtime()," + MyStart.giUserID + ")";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("发卖方结算卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                szSql = iFirmID + "-持卡人" + textBox_PersonM.Text.Trim() + "-电话" + textBox_TelM.Text.Trim() + "-卡号"
                    + textBox_CardV.Text.Trim();
                MyFunc.WriteToDbLog("发卖方结算卡", szSql, "MSG", MyStart.giUserID);

                if (Convert.ToDecimal(textBox_Fee_M.Text) > 0)
                {
                    long lVal = (long)(Convert.ToDecimal(textBox_Fee_M.Text) * 100);
                    szSql = "insert into rec_firm (card_no,rmrk,store_id,oper_time,oper_type,chg_val,oper_id,tmn_id) values ('"
                        + textBox_CardV.Text.Trim() + "','"+ MyStart.gszCardFirmFirst + textBox_CardM.Text.Trim()+"',"+ iFirmID + ",curtime(),'ISSU',"
                        + lVal + "," + MyStart.giUserID + ",'" + frm_Main.POS_ID + "')";
                    iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                    if (iRst < 1)
                    {
                        MessageBox.Show("记录卖方第一副卡与结算卡工本费出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("发卖方第一副卡与结算卡收费", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                }

                MessageBox.Show("发卖方卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh(iFirmID, 0);
                //GridDataRefresh(miFirmID, miStallID);
                textBox_CardM.Text = "";
                textBox_CardV.Text = "";
                textBox_PersonM.Text = "";
                textBox_TelM.Text = "";
                textBox_CertIDM.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("发卖方卡失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            return;

        }

        private void ReadCardNo(string szType,Button objBtn,TextBox objText)
        {
            objBtn.Enabled = false;
            CIcRdr myRdr = new CIcRdr();
            //string szErr = "";
            if (!frm_Main.bHaveRd)
            {
                MessageBox.Show("没有连接读卡器，请检查。", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objBtn.Enabled = true;
                objBtn.Focus();
                return;
            }

            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("连接读卡器失败，请检查连接", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objBtn.Enabled = true;
                objBtn.Focus();
                return;
            }

            //Application.DoEvents();
            if (!myRdr.Link())
            {
                MessageBox.Show("连接读卡器失败，请联系供应商", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                objBtn.Enabled = true;
                objBtn.Focus();
                return;
            }

            //Application.DoEvents();
            string szInf;
            if (!myRdr.ReadCardInf(out szInf))
            {
                MessageBox.Show("读卡失败，请重新放卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                objBtn.Enabled = true;
                objBtn.Focus();
                return;
            }

            string szTypeDesc = "买方卡";
            if (szType.CompareTo(MyStart.gszCardFirmFirst) == 0)
                szTypeDesc = "卖方卡";
            if (szInf.Substring(0, 1).CompareTo(szType) != 0)
            {
                MessageBox.Show("卡号错误（不是" + szTypeDesc+ ",卡号第一位应是" + szType + ")," + "，请换卡",
                    "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                objBtn.Enabled = true;
                objBtn.Focus();
                return;
            }
            if (szType.CompareTo(MyStart.gszCardFirmFirst) == 0)
                objText.Text = szInf.Substring(1, 15);
            else
                objText.Text = szInf.Substring(0, 16);
            myRdr.ComClose();
            objBtn.Enabled = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {/*
            string szCard = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (szCard.Length == 0)
            {
                MessageBox.Show("请先选择要解绑的卖方卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql = "select count(*) from rec_trade where substr(store_card,2)='" + szCard + "'";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                MessageBox.Show("卖方卡号查询失败，请重新操作", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            int iNum = Convert.ToInt16(dr[0]);
            if (iNum > 0)
            {
                MessageBox.Show("该卖方卡号已有交易，不能解绑", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (iNum > 1)
            {
                if (DialogResult.No == MessageBox.Show("有" + iNum + "张卡号相同，会同时解绑，解绑后不可恢复，是否继续？", "操作提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
            }
            else
            {
                if (DialogResult.No == MessageBox.Show("卖方卡解绑后不可恢复，是否继续？", "操作提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
            }
            //连接银石后台

            //写入DB
            szSql = "delete from mng_card where substr(STORE_CARD,2)='" + szCard + "'";
            iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst <= 0)
            {
                MessageBox.Show("该卖方卡号解绑失败(错误原因＝" + szErr + ")", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("该卖方卡号解绑成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MyFunc.WriteToDbLog("发卖方卡－解绑", "卖方卡号" + szCard, "MSG", MyStart.giUserID);
            GridDataRefresh(miFirmID, miStallID);*/
        }

        private void comboBox_Rent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] szFirm = comboBox_NameS.Text.Split('-');
            string[] szRent = comboBox_Rent.Text.Split('-');
            string szSql = "select STALL_PERSON, STALL_TEL, a.CERT_ID from base_stall a,base_store b where a.STORE_ID =" + szFirm[0]
                + " and STALL_ID = " + szRent[0] + " and a.STORE_ID = b.STORE_ID";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (1 != iNum)
            {
                MyStart.oMyDb.Close();
                return;
            }

            DataRow dr = ds.Tables[0].Rows[0];
            textBox_PersonS.Text = dr[0].ToString();
            textBox_TelS.Text = dr[1].ToString();
            textBox_CertIDS.Text = dr[2].ToString();
            MyStart.oMyDb.Close();
        }

        private void comboBox_NameM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] szFirm = comboBox_NameM.Text.Split('-');
            string szSql = "select store_boss,store_tel, cert_id from base_store where STORE_ID =" + szFirm[0];
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (1 != iNum)
            {
                MyStart.oMyDb.Close();
                return;
            }

            DataRow dr = ds.Tables[0].Rows[0];
            textBox_PersonM.Text = dr[0].ToString();
            textBox_TelM.Text = dr[1].ToString();
            textBox_CertIDM.Text = dr[2].ToString();
            MyStart.oMyDb.Close();
        }

        private void comboBox_NameS_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Rent.Items.Clear();
            comboBox_Rent.Text = "";
            textBox_PersonS.Text = "";
            textBox_TelS.Text = "";
            textBox_CertIDS.Text = "";

            MyFunc.DispStall(comboBox_NameS, comboBox_Rent, false);
            if (comboBox_Rent.Items.Count > 0)
            {
                comboBox_Rent.SelectedIndex = 0;
                button_CardS.Enabled = true;
                button_SaveS.Enabled = true;
            }
            else
            {
                button_CardS.Enabled = false;
                button_SaveS.Enabled = false;
            }
        }

        private void button_CardM_Click(object sender, EventArgs e)
        {
            ReadCardNo(MyStart.gszCardFirmFirst, button_CardM, textBox_CardM);
        }

        private void button_CardV_Click(object sender, EventArgs e)
        {
            ReadCardNo(MyStart.gszCardYtbFirst, button_CardV, textBox_CardV);
        }

        private void button_CardS_Click(object sender, EventArgs e)
        {
            ReadCardNo(MyStart.gszCardFirmFirst, button_CardS, textBox_CardS);
        }

        private void button_SaveS_Click(object sender, EventArgs e)
        {
            if (textBox_CardS.Text.Length != 15)
            {
                MessageBox.Show("卡号长度错误（卖方卡号长度为15），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_CardM.Focus();
                return;
            }

            DataSet ds = new DataSet();
            string szErr = "";
            string[] szFirmInf = comboBox_NameS.Text.Split('-');
            int iFirmID = Convert.ToInt16(szFirmInf[0]);
            string[] szStall = comboBox_Rent.Text.Split('-');
            int iRendID = Convert.ToInt16(szStall[0]);
            //string szStallInf = szStall[1];
            string szSql = "select * from mng_card where STORE_CARD='" + MyStart.gszCardFirmFirst + textBox_CardS.Text.Trim() + "'";
            try
            {
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    MessageBox.Show("卡号重复，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_CardS.Focus();
                    goto Eend;
                }

                szSql = "select STORE_CARD,STORE_PERSON from mng_card where CARD_TYPE = 1 and STORE_ID=" + iFirmID;
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                iNum = ds.Tables[0].Rows.Count;
                if (iNum == 0)
                {
                    MessageBox.Show("该卖方没有第一副卡和结算卡，不能发副卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + "该卖方没有第一副卡和结算卡，不能发副卡");
                    goto Eend;
                }
                DataRow dr = ds.Tables[0].Rows[0];
                string szCardM = dr[0].ToString();
                string szCardName = dr[1].ToString();

                szSql = "select * from mng_card where CARD_TYPE = 2 and STALL_ID=" + szStall[0]
                    + " and STORE_PERSON='" + textBox_PersonS.Text.Trim()
                    + "' and USER_TEL='" + textBox_TelS.Text.Trim() + "'";
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    if (MessageBox.Show("该持卡人已有" + iNum + "张副卡，确认继续发卡吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        goto Eend;
                }

                /*连接银石后台
                EbHttpClass objHttp = new EbHttpClass();
                string szPwd = "";
                bool bRst = objHttp.IssueNewFirmCard(szCardM.Substring(1,15), textBox_CardS.Text, szFirmInf[1], textBox_TelS.Text, textBox_CertIDS.Text,  ref szPwd, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台注册卖方卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }*/

                //写入DB              
                szSql = "INSERT INTO mng_card (STORE_ID,STALL_ID,STALL_INF,STORE_PERSON,USER_TEL,CERT_ID,CARD_TYPE,STORE_CARD,ADD_DT,ADD_ID) VALUES (";
                if (textBox_PersonS.Text.Trim() != "")
                    szSql += iFirmID + "," + szStall[0] + ",'" + comboBox_Rent.Text + "','" + textBox_PersonS.Text.Trim() + "','" + textBox_TelS.Text.Trim() + "','";
                else
                    szSql += iFirmID + "," + szStall[0] + ",'" + comboBox_Rent.Text + "','" + szCardName.Trim() + "','" + textBox_TelS.Text.Trim() + "','";
                szSql += textBox_CertIDS.Text.Trim() + "',2,'";
                szSql += MyStart.gszCardFirmFirst + textBox_CardS.Text.Trim() + "',curtime()," + MyStart.giUserID + ")";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("发卖方副卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方副卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                szSql = "select STALL_ID from mng_card where CARD_TYPE=1 and STORE_ID=" + iFirmID;
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 1)
                {
                    MessageBox.Show("发卡出错（错误原因：该卖方有多张第一副卡）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发卖方卡", "SQL=" + szSql + ",Err=该卖方有多张第一副卡");
                    goto Eend;
                }
                dr = ds.Tables[0].Rows[0];
                if (Convert.ToInt16(dr[0]) == 0)
                {
                    szSql = "update mng_card set STALL_ID=" + szStall[0] + " where STORE_ID=" + iFirmID + " and CARD_TYPE<>2";
                    iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                    if (iRst < 1)
                    {
                        MessageBox.Show("发卖方副卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("发卖方副卡", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                }

                szSql = szStall[1] + "-持卡人" + textBox_PersonS.Text.Trim() + "-电话" + textBox_TelS.Text.Trim() + "-卡号"
                    + textBox_CardS.Text.Trim();
                MyFunc.WriteToDbLog("发卖方副卡", szSql, "MSG", MyStart.giUserID);
                GridDataRefresh(iFirmID, iRendID);

                if (Convert.ToDecimal(textBox_Fee_S.Text) > 0)
                {
                    long lVal = (long)(Convert.ToDecimal(textBox_Fee_S.Text) * 100);
                    szSql = "insert into rec_firm (card_no,store_id,oper_time,oper_type,chg_val,oper_id,tmn_id) values ('"
                        + MyStart.gszCardFirmFirst + textBox_CardS.Text.Trim() + "'," + iFirmID + ",curtime(),'ISSU',"
                        + lVal + "," + MyStart.giUserID + ",'" + frm_Main.POS_ID + "')";
                    iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                    if (iRst < 1)
                    {
                        MessageBox.Show("记录卖方副卡工本费出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("发卖方副卡收费", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                }
                MessageBox.Show("发卖方副卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_CardS.Text = "";
                textBox_PersonS.Text = "";
                textBox_TelS.Text = "";
                textBox_CertIDS.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("发卖方副卡失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            return;
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            comboBox_NameS.Items.Clear();
            comboBox_NameS.Text = "";
            int iStoreNum=0;
            DataSet ds = new DataSet();
            string szSql = "";
            string szErr = "";
            if (textBox_search.Text.Trim().Length > 0)
                szSql = "select concat(store_id,'-',store_name) from base_store where STORE_STAT='USED' and STORE_NAME like '%" + textBox_search.Text.Trim() + "%' order by store_id desc";
            else
                szSql = "select concat(store_id,'-',store_name) from base_store where STORE_STAT='USED' order by store_id desc";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                //if (iStoreNum > 0)
                //    comboBox_Firm.Items.Add("0-所有卖方");
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_NameS.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
                comboBox_NameS.SelectedIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MyStart.oMyDb.Close();
        }

        private void checkBox_Fee_S_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Fee_S.Enabled = checkBox_Fee_S.Checked;
            button_SaveFee_S.Enabled = checkBox_Fee_S.Checked;
        }

        private void checkBox_Fee_M_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Fee_M.Enabled = checkBox_Fee_M.Checked;
            button_SaveFee_M.Enabled = checkBox_Fee_M.Checked;

        }

        private void textBox_Fee_M_TextChanged(object sender, EventArgs e)
        {
            miFee = Convert.ToInt16(Convert.ToDecimal(textBox_Fee_M.Text));
        }

        private void textBox_Fee_S_TextChanged(object sender, EventArgs e)
        {
            miFee = Convert.ToInt16(Convert.ToDecimal(textBox_Fee_S.Text));
        }

        private void button_SaveFee_S_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("确认要保存IC卡工本费吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            string szErr = "";
            try
            {
                int iRst = MyFunc.SetSysParaToDb(MyStart.oMyDb, "FEE_CHG_CARD", miFee.ToString(), ref szErr);
                if (iRst < 0)
                {
                    MessageBox.Show("操作错误：保存IC卡工本费时出错。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MyFunc.WriteToDbLog("修改运营参数", "IC卡工本费" + textBox_Fee_S.Text + "元", "MSG", MyStart.giUserID);
                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存IC卡工本费失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }

        private void button_SaveFee_M_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("确认要保存IC卡工本费吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            string szErr = "";
            try
            {
                int iRst = MyFunc.SetSysParaToDb(MyStart.oMyDb, "FEE_CHG_CARD", miFee.ToString(), ref szErr);
                if (iRst < 0)
                {
                    MessageBox.Show("操作错误：保存IC卡工本费时出错。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MyFunc.WriteToDbLog("修改运营参数", "IC卡工本费" + textBox_Fee_M.Text + "元", "MSG", MyStart.giUserID);
                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存IC卡工本费失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }
    }
}
