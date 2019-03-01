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
    public partial class frm_Client_Card : Form
    {
        string mszPerson;
        string mszCard;
        string mszPwd;
        string mszCell;
        string mszCertID;
        int miFee;
        public frm_Client_Card()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            //string szSql = "select user_name as 姓名,substring(user_card,2) as 买方卡, user_tel as 联系电话, cert_id as 身份证号,pwd_crypt as 卡密2,card_pwd as 卡密1 from base_ucard order by ID ";
            string szSql = "select user_name as 姓名,user_card as 买方卡, user_tel as 联系电话,user_addr as 经营地址, cert_id as 身份证号,rmrk as 备注 from base_ucard order by ID ";
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
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }

            /*textBox_Person.Text*/mszPerson = dataGridView1.Rows[0].Cells[0].Value.ToString();
            /*textBox_Card.Text */
            mszCard = dataGridView1.Rows[0].Cells[1].Value.ToString();
            /*textBox_Cell.Text */
            mszCell = dataGridView1.Rows[0].Cells[2].Value.ToString();
            /*textBox_CertID.Text */
            mszCertID = dataGridView1.Rows[0].Cells[3].Value.ToString();

            //mszPerson = textBox_Person.Text;
            //mszCard = textBox_Card.Text;
            mszPwd = textBox_pwd.Text;
            //mszCell = textBox_Cell.Text;
            //mszCertID = textBox_CertID.Text;
            MyStart.oMyDb.Close();
        }
        private void frm_Client_Card_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Cancel.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Card.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            textBox_Card.Text = "";
            textBox_pwd.Text = "";
            textBox_Person.Text = "";
            textBox_Cell.Text = "";
            textBox_CertID.Text = "";
            textBox_Addr.Text = "";
            textBox_rmrk.Text = "";

            checkBox_Fee.Checked = true;
            textBox_Fee.Text = MyStart.giFeeChgCard.ToString("0.00");
            miFee = MyStart.giFeeChgCard;

            string szCity = "北京（京）、天津（津）、黑龙江（黑）、吉林（吉）、辽宁（辽）、河北（冀）、河南（豫）、山东（鲁）、山西（晋）、陕西（陕）、内蒙古（蒙）、宁夏（宁）、甘肃（甘）、新疆（新）、青海（青）、西藏（藏）、湖北（鄂）、安徽（皖）、江苏（苏）、上海（沪）、浙江（浙）、福建（闵）、湖南（湘）、江西（赣）、四川（川）、重庆（渝）、贵州（黔）、云南（滇）、广东（粤）、广西（桂）、海南（琼）、香港（港）、澳门（澳）、台湾（台）";
            string[] szCities = szCity.Split('、');
            comboBox_truck.Items.Clear();
            for (int i = 0; i < szCities.Length; i++)
            {
                int iPos = szCities[i].IndexOf('）');
                comboBox_truck.Items.Add(szCities[i].Substring(iPos-1, 1));
            }
            comboBox_truck.Text = "粤";
            textBox_truck.Text = "";

            GridDataRefresh();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button_Card_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            CIcRdr myRdr = new CIcRdr();
            //string szErr = "";
            if (!myRdr.ComOpen(frm_Main.sRdPort))
            {
                MessageBox.Show("连接读卡器失败，请检查连接", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            //Application.DoEvents();
            if (!myRdr.Link())
            {
                MessageBox.Show("连接读卡器失败，请联系供应商", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            //Application.DoEvents();
            string szInf;
            if (!myRdr.ReadCardInf(out szInf))
            {
                MessageBox.Show("读卡失败，请重新放卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }

            if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardYtbFirst) != 0)
            {
                MessageBox.Show("卡号错误（买方卡号第一位是" + MyStart.gszCardYtbFirst + "），请换卡",
                    "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myRdr.ComClose();
                ((Button)sender).Enabled = true;
                button_Card.Focus();
                return;
            }
            textBox_Card.Text =szInf.Substring(0, 16);
            ((Button)sender).Enabled = true;
            myRdr.ComClose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            string szCard = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (szCard.Length == 0)
            {
                MessageBox.Show("请先选择要解绑的买方卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql = "select count(*) from rec_trade where substr(USER_CARD,2)='" + szCard + "'";
            string szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                MessageBox.Show("买方卡号查询失败，请重新操作", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto EEnd;
            }
            DataRow dr = ds.Tables[0].Rows[0];
            int iNum = Convert.ToInt16(dr[0]);
            if (iNum > 0)
            {
                MessageBox.Show("该买方卡号已有交易，不能解绑", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto EEnd;
            }

            if (iNum > 1)
            {
                if (DialogResult.No == MessageBox.Show("有" + iNum + "张卡号相同，会同时解绑，解绑后不可恢复，是否继续？", "操作提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    goto EEnd;
            }
            else
            {
                if (DialogResult.No == MessageBox.Show("买方卡解绑后不可恢复，是否继续？", "操作提示",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    goto EEnd;
            }

            //连接银石后台

            //写入DB
            szSql = "delete from base_ucard where substr(user_card,2)='" + szCard + "'";
            iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst <= 0)
            {
                MessageBox.Show("该买方卡号解绑失败(错误原因＝" + szErr + ")", "操作提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                goto EEnd;
            }
            MessageBox.Show("该买方卡号解绑成功", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MyFunc.WriteToDbLog("发买方卡－解绑", "买方卡号" + szCard, "MSG", MyStart.giUserID);
            //GridDataRefresh(miFirmID, miStallID);
           EEnd:
            MyStart.oMyDb.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确认当前的发卡信息吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            //    return;
            if (textBox_Person.TextLength == 0)
            {
                MessageBox.Show("姓名不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Person.SelectAll();
                textBox_Person.Focus();
                return;
            }
            if (textBox_Card.Text.Length != 16)
            {
                MessageBox.Show("卡号长度错误（买方卡号长度为16），请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_Card.Focus();
                return;
            }

            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "";
            try
            {
                szErr = "";
                szSql = "select * from base_ucard where user_card='" + textBox_Card.Text.Trim() + "'";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发买方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    MessageBox.Show("卡号重复，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button_Card.Focus();
                    goto Eend;
                }

                szSql = "select * from base_ucard where card_type=1 and user_name='" + textBox_Person.Text.Trim() + "'";
                    //+ "' and USER_TEL='" + textBox_Cell.Text.Trim() + "'";
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("发卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发买方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                iNum = ds.Tables[0].Rows.Count;
                int iPID = 0;
                if (iNum > 0)
                {
                    if (MessageBox.Show("该持卡人已有" + iNum + "张买方卡，确认发副卡吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        goto Eend;

                    checkBox_multy.Checked = true;
                    DataRow dr = ds.Tables[0].Rows[0];
                    textBox_Cell.Text = dr["USER_TEL"].ToString();
                    textBox_CertID.Text = dr["CERT_ID"].ToString();
                    textBox_Addr.Text = dr["user_addr"].ToString();
                    textBox_rmrk.Text = dr["rmrk"].ToString();
                    string szTruck = dr["truck_no"].ToString();
                    if (szTruck.Length > 1)
                    {
                        comboBox_truck.Text = dr["truck_no"].ToString().Substring(0, 1);
                        textBox_truck.Text = dr["truck_no"].ToString().Substring(1);
                    }
                    iPID = Convert.ToInt32(dr["ID"]);
                    if (dr["is_sign"].ToString() == "1")
                        checkBox_Sign.Checked = true;
                    else
                        checkBox_Sign.Checked = false;

                    //checkBox_Sign.Enabled = false;
                    //textBox_Addr.Enabled = false;
                    //comboBox_truck.Enabled = false;
                    //textBox_truck.Enabled = false;
                    if (MessageBox.Show("是否需要继续补齐资料？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        goto Eend;
                }
                else
                {
                    MessageBox.Show("该人未开过卡，只能开主卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox_multy.Checked = false;  
                }

                if (textBox_Cell.TextLength == 0)
                {
                    MessageBox.Show("请输入联系电话", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Cell.SelectAll();
                    textBox_Cell.Focus();
                    return;
                }
                if (textBox_CertID.TextLength == 0)
                {
                    MessageBox.Show("身份证号不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_CertID.SelectAll();
                    textBox_CertID.Focus();
                    return;
                }
                if (textBox_pwd.Text.Trim() != textBox_pwd2.Text.Trim())
                {
                    MessageBox.Show("两次输入的密码不同，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_pwd.SelectAll();
                    textBox_pwd.Focus();
                    return;
                }
                if (textBox_pwd.TextLength == 0)
                {
                    MessageBox.Show("退款时需要密码，请输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_pwd.SelectAll();
                    textBox_pwd.Focus();
                    goto Eend;
                }
                /*if (textBox_Cell.TextLength != 11)
                {
                    MessageBox.Show("请输入买方手机号码，长度为11", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Cell.SelectAll();
                    textBox_Cell.Focus();
                    return;
                }*/

                //连接银石后台
                EbHttpClass objHttp = new EbHttpClass();
                string szPwd = "1," + textBox_pwd.Text;
                bool bRst = objHttp.IssueNewUserCard(textBox_Card.Text, textBox_Person.Text, textBox_Cell.Text,textBox_CertID.Text, ref szPwd, ref szErr);
                if (!bRst)
                {
                    MessageBox.Show("后台注册买方卡失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                
                //写入DB
                szSql = "INSERT INTO base_ucard (user_name,USER_TEL,CERT_ID,user_card,card_pwd,pwd_crypt,oper_time,ADD_ID,user_addr,rmrk,truck_no,is_sign,card_type,parent_ID) VALUES ('"
                    + textBox_Person.Text.Trim() + "','" + textBox_Cell.Text.Trim() + "','" + textBox_CertID.Text.Trim() + "','"
                    + textBox_Card.Text.Trim() + "',' ',' ',curtime()," + MyStart.giUserID +",'"+textBox_Addr.Text.Trim() +"','"+textBox_rmrk.Text.Trim()+ "','"
                    +comboBox_truck.Text+textBox_truck.Text.Trim()+"', ";
                if (checkBox_Sign.Checked)
                    szSql += "1,";
                else
                    szSql += "0,";

                if (checkBox_multy.Checked)
                    szSql += "2," + iPID+")";
                else
                    szSql += "1,0)";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("发买方卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("发买方卡", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                if (!checkBox_multy.Checked)
                {
                    szSql = "update base_ucard set parent_ID=id where card_type=1 and parent_ID=0";
                    iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                    if (iRst < 1)
                    {
                        MessageBox.Show("发买方卡出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("发买方卡", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                }
                szSql = "持卡人" + textBox_Person.Text.Trim() + "-电话" + textBox_Cell.Text.Trim() + "-卡号"+ textBox_Card.Text.Trim();
                MyFunc.WriteToDbLog("发买方卡", szSql, "MSG", MyStart.giUserID);
                GridDataRefresh();

                if (Convert.ToDecimal(textBox_Fee.Text) > 0)
                {
                    long lVal = (long)(Convert.ToDecimal(textBox_Fee.Text) * 100);
                    szSql = "insert into rec_user (card_no,oper_time,oper_type,chg_val,oper_id,tmn_id) values ('" + textBox_Card.Text.Trim()
                        + "',curtime(),'ISSU'," + lVal + "," + MyStart.giUserID + ",'" + frm_Main.POS_ID + "')";
                    iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                    if (iRst < 1)
                    {
                        MessageBox.Show("记录买方卡工本费出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("发买方卡", "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                }
                MessageBox.Show("发买方卡成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_Card.Text = "";
                textBox_pwd.Text = "";
                textBox_Person.Text = "";
                textBox_Cell.Text = "";
                textBox_CertID.Text = "";
                textBox_Addr.Text = "";
                textBox_rmrk.Text = "";
                comboBox_truck.Text = "粤";
                textBox_truck.Text = "";
                goto Eend;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发买方卡失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MyFunc.WriteToDbLog("修改运营参数", "IC卡工本费" + textBox_Fee.Text + "元", "MSG", MyStart.giUserID);
                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存IC卡工本费失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }

        private void textBox_Fee_TextChanged(object sender, EventArgs e)
        {
            miFee = Convert.ToInt16(Convert.ToDecimal(textBox_Fee.Text));
        }
    }
}
