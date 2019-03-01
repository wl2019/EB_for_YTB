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
    public partial class frm_Client_QryCard : Form
    {
        public frm_Client_QryCard()
        {
            InitializeComponent();
        }

        private void frm_Client_QryCard_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            //pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            button_Card.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            textBox_Card.Text = "";
            textBox_time.Text = "";
            textBox_stat.Text = "";
            textBox_Person.Text = "";
            textBox_Cell.Text = "";
            textBox_CertID.Text = "";
            textBox_Addr.Text = "";
            textBox_rmrk.Text = "";
            textBoxOper.Text = "";
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
            textBox_Card.Text = szInf.Substring(0, 16);
            ((Button)sender).Enabled = true;
            myRdr.ComClose();

            button_Qry_Click(sender, e);
        }

        private void textBox_Card_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Card.TextLength == 16)
                button_Qry.Enabled = true;
            else
                button_Qry.Enabled = false;
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select oper_time,card_flag,a.user_name,a.user_tel,a.CERT_ID,b.USER_NAME,a.user_addr,a.rmrk from base_ucard a,sys_users b "
                + "where a.ADD_ID=b.USER_ID and user_card='" + textBox_Card.Text.Trim() + "'";
            try
            {
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("买方卡查询失败，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_time.Text = "";
                    textBox_stat.Text = "";
                    textBox_Person.Text = "";
                    textBox_Cell.Text = "";
                    textBox_CertID.Text = "";
                    textBox_Addr.Text = "";
                    textBox_rmrk.Text = "";
                    textBoxOper.Text = "";
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum == 0)
                {
                    MessageBox.Show("系统无此买方卡信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_time.Text = "";
                    textBox_stat.Text = "";
                    textBox_Person.Text = "";
                    textBox_Cell.Text = "";
                    textBox_CertID.Text = "";
                    textBox_Addr.Text = "";
                    textBox_rmrk.Text = "";
                    textBoxOper.Text = "";
                    goto Eend;
                }

                DataRow dr = ds.Tables[0].Rows[0];
                textBox_time.Text = dr[0].ToString();
                switch (dr[1].ToString().ToUpper())
                {
                    case "BGN": textBox_stat.Text = "正常"; break;
                    case "LOST": textBox_stat.Text = "挂失"; break;
                    default: textBox_stat.Text = "无效"; break;
                }
                textBox_Person.Text = dr[2].ToString();
                textBox_Cell.Text = dr[3].ToString();
                textBox_CertID.Text = dr[4].ToString();
                textBoxOper.Text = dr[5].ToString();
                textBox_Addr.Text = dr[6].ToString();
                textBox_rmrk.Text = dr[7].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("买方卡查询失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            if (textBox_Person.TextLength > 0)
                button_Edit.Enabled = true;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("确认修改持卡人信息吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

            //连接银石后台
            EbHttpClass objHttp = new EbHttpClass();
            string szErr = "";
            bool bRst = objHttp.ChgUserInf(textBox_Card.Text, textBox_Person.Text, textBox_Cell.Text, textBox_CertID.Text, ref szErr);
            if (!bRst)
            {
                MessageBox.Show("后台修改持卡人信息失败( " + szErr + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string szSql = "update base_ucard set user_name='"+textBox_Person.Text.Trim()
                + "',USER_TEL='"+textBox_Cell.Text.Trim()+"',CERT_ID='"+textBox_CertID.Text.Trim()
                +"',CHG_ID="+MyStart.giUserID+ ",user_addr='"+textBox_Addr.Text.Trim()+ "',rmrk='"+textBox_rmrk.Text.Trim()
                +"', CHG_DT=curtime() where user_card='" + textBox_Card.Text.Trim()+"'";
            DataSet ds = new DataSet();
            szErr = "";
            int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst < 1)
            {
                MessageBox.Show("修改持卡人信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog("买方卡查询－修改", "SQL=" + szSql + ",Err=" + szErr);
            }
            MessageBox.Show("修改持卡人信息成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button_Edit.Enabled = false;
        }
    }
}
