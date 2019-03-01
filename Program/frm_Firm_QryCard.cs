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
    public partial class frm_Firm_QryCard : Form
    {
        public frm_Firm_QryCard()
        {
            InitializeComponent();
        }

        private void frm_Firm_QryCard_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            //pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.chip.ico"));
            button_Card.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.idcard.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            textBox_Card.Text = "";
            textBox_time.Text = "";
            textBox_stat.Text = "";
            textBox_Firm.Text = "";
            textBox_Person.Text = "";
            textBox_Cell.Text = "";
            textBox_CertID.Text = "";
            textBoxOper.Text = "";
            MyFunc.GridInit(ref dataGridView1, "发卡时间,卡号,卡类,卡片状态,档口联系人,联系电话,身份证,开卡人", "1,1,1,1,1,1,1,1", 15, 15, true);
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
            myRdr.ComClose();

            if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardFirmFirst) != 0)//not firm card
            {
                if (szInf.Substring(0, 1).CompareTo(MyStart.gszCardYtbFirst) != 0)//not user card
                {
                    MessageBox.Show("卡号错误（既不是卖方卡，也不是结算卡），请换卡",
                        "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((Button)sender).Enabled = true;
                    button_Card.Focus();
                    return;
                }
                else
                    textBox_Card.Text = szInf.Substring(0, 16);
            }
            else
            {
                textBox_Card.Text = szInf.Substring(1, 15);
            }

            ((Button)sender).Enabled = true;
            button_Qry_Click(sender, e);
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            string szCard = textBox_Card.Text;
            if (szCard.Length == 15)
                szCard = MyStart.gszCardFirmFirst + textBox_Card.Text;

            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select a.ADD_DT,CARD_STAT,a.STORE_PERSON,a.user_tel,a.cert_id,CARD_TYPE,a.STORE_ID,STORE_NAME,c.USER_NAME "
                + "from mng_card a,base_store b, sys_users c where a.ADD_ID=c.USER_ID "
                + "and a.STORE_ID=b.STORE_ID and STORE_CARD='" + szCard + "'";
            try
            {
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("卖方卡查询失败，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_time.Text = "";
                    textBox_stat.Text = "";
                    textBox_Firm.Text = "";
                    textBox_Person.Text = "";
                    textBox_Cell.Text = "";
                    textBox_CertID.Text = "";
                    textBoxOper.Text = "";
                    dataGridView1.Rows.Clear();
                    MyFunc.GridInit(ref dataGridView1, "发卡时间,卡号,卡类,卡片状态,档口联系人,联系电话,身份证,开卡人", "1,1,1,1,1,1,1,1", 15, 15, true);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum == 0)
                {
                    MessageBox.Show("系统无此卖方卡信息，请换卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_time.Text = "";
                    textBox_stat.Text = "";
                    textBox_Firm.Text = "";
                    textBox_Person.Text = "";
                    textBox_Cell.Text = "";
                    textBox_CertID.Text = "";
                    textBoxOper.Text = "";
                    dataGridView1.Rows.Clear();
                    MyFunc.GridInit(ref dataGridView1, "发卡时间,卡号,卡类,卡片状态,档口联系人,联系电话,身份证,开卡人", "1,1,1,1,1,1,1,1", 15, 15, true);
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
                switch (Convert.ToInt16(dr[5]))
                {
                    case 1: textBox_Type.Text = "第一副卡"; break;
                    case 2: textBox_Type.Text = "副卡"; break;
                    default: textBox_Type.Text = "结算卡"; break;
                }
                textBox_Firm.Text = dr[7].ToString();
                textBoxOper.Text = dr[8].ToString();
                //ds = null;

                int iFirmID = Convert.ToInt16(dr[6]);
                szSql = "SELECT b.ADD_DT as 发卡时间,STORE_CARD as 卡号,"
                    + "if (CARD_TYPE = 1,'第一副卡','结算卡') as 卡类,"
                    + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,"
                    + "STORE_PERSON as 联系人,b.USER_TEL as 联系电话,b.cert_id as 身份证,c.USER_NAME as 开卡人 "
                    + "FROM mng_card b, sys_users c where b.ADD_ID=c.USER_ID and b.CARD_TYPE<>2 and b.STORE_ID = " + iFirmID 
                    + " UNION "
                    + "SELECT b.ADD_DT as 发卡时间,STORE_CARD as 卡号,"
                    + "'副卡' as 卡类,"
                    + "if (CARD_STAT = 'BGN','正常',if (CARD_STAT = 'STOP','无效','挂失')) as 状态,"
                    + "STORE_PERSON as 联系人,b.USER_TEL as 联系电话,b.cert_id as 身份证,c.USER_NAME as 开卡人 "
                    + "FROM base_stall a,mng_card b, sys_users c where b.ADD_ID=c.USER_ID and b.CARD_TYPE=2 and a.STORE_ID = b.STORE_ID and b.STORE_ID = " + iFirmID;
                //+"order by CARD_TYPE,CARD_ID desc";
                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                    goto Eend;

                DataTable dt = ds.Tables[0];
                dataGridView1.Columns.Clear();//
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("卖方卡查询失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void textBox_Card_TextChanged(object sender, EventArgs e)
        {
            if (textBox_Card.TextLength >=15 && textBox_Card.TextLength<=16)
                button_Qry.Enabled = true;
            else
                button_Qry.Enabled = false;
        }
    }
}
