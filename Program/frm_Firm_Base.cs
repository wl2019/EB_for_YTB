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
    public partial class frm_Firm_Base : Form
    {
        string mszCode;
        string mszName;
        string mszAddr;
        string mszBoss;
        string mszCertType;
        string mszCert;
        string mszValid;
        string mszPerson;
        string mszCell;
        string mszType;
        string mszInf;
        bool IsNew;
        public frm_Firm_Base()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {
             DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "SELECT STORE_ID as 卖方编号,STORE_NAME as 卖方名称,STORE_ADDR as 卖方住址,STORE_BOSS as 法人姓名,"
                + " concat(if(CERT_TYPE=1,'1,身份证',if(CERT_TYPE=2,'2,营业执照','3,其它证件')),'-',CERT_ID) as 证件号码,"
                + " CERT_VALID as 证件有效期,STORE_PERSON as 联络人,STORE_CELL as 联系电话,"
                + "if(STORE_TYPE=1,'1,卖方','2,买方') as 卖方性质,RMRK as 备注 FROM base_store "
                + " where STORE_STAT='USED' order by STORE_ID";

            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            dataGridView1.RowHeadersWidth = 15;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }

            textBox_Code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox_Addr.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox_Boss.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            string[] szX = dataGridView1.Rows[0].Cells[4].Value.ToString().Split('-');
            if(szX.Length==2)
            { 
                comboBox_Cert.Text = szX[0];
                textBox_Cert.Text = szX[1];
            }
            else
            {
                comboBox_Cert.Text = "";
                textBox_Cert.Text = "";
            }
            string szItem = dataGridView1.Rows[0].Cells[5].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_valid.Text = "2020-12-31";
            else
                dateTimePicker_valid.Text = szItem;            
            textBox_Person.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            textBox_Cell.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            comboBox_Type.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszAddr = textBox_Addr.Text;
            mszBoss = textBox_Boss.Text;
            mszCertType = comboBox_Cert.Text;
            mszCert = textBox_Cert.Text;
            mszValid = dateTimePicker_valid.Text;
            mszPerson = textBox_Person.Text;
            mszCell = textBox_Cell.Text;
            mszType = comboBox_Type.Text;
            mszInf = textBox_Desc.Text;
            MyStart.oMyDb.Close();
        }
        private void frm_Firm_Base_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            comboBox_Type.Items.Add("1-卖方");
            comboBox_Type.Items.Add("2-买方");

            comboBox_Cert.Items.Add("1,身份证");
            //comboBox_Cert.Items.Add("2,营业执照");
            //comboBox_Cert.Items.Add("3,其它证件");

            //MyFunc.GridInit(ref dataGridView1, "卖方编号,卖方名称,卖方住址,法人姓名,证件号码,证件有效期,联络人,联系电话,卖方性质,备注", "1,1,1,1,1,1,1,1,1,1,1", 15, 8, true);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            IsNew = true;
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            //bIsAddNew = true;
            textBox_Code.Text = "";
            textBox_Code.Enabled = false;
            textBox_Name.Text = "";
            textBox_Addr.Text = "";
            textBox_Boss.Text = "";
            comboBox_Cert.SelectedIndex = 0;
            textBox_Cert.Text = "";
            dateTimePicker_valid.Text = "2020-12-31";
            textBox_Person.Text = "";
            textBox_Cell.Text = "";
            comboBox_Type.SelectedIndex = 0;
            textBox_Desc.Text = "";
            textBox_Name.Focus();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            IsNew = false;
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            textBox_Code.Enabled = false;
            //textBox_Name.Enabled = false;
            comboBox_Type.Focus();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Code.Text = mszCode;
            textBox_Name.Text = mszName;
            textBox_Addr.Text = mszAddr;
            textBox_Boss.Text = mszBoss;
            comboBox_Cert.Text = mszCertType;
            textBox_Cert.Text = mszCert;
            dateTimePicker_valid.Text = mszValid;
            textBox_Person.Text = mszPerson;
            textBox_Cell.Text = mszCell;
            comboBox_Type.Text = mszType;
            textBox_Desc.Text = mszInf;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_Addr.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_Boss.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string[] szX = dataGridView1.CurrentRow.Cells[4].Value.ToString().Split('-');
            if (szX.Length == 2)
            {
                comboBox_Cert.Text = szX[0];
                textBox_Cert.Text = szX[1];
            }
            else
            {
                comboBox_Cert.Text = "";
                textBox_Cert.Text = "";
            }
            string szItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_valid.Text = "2020-12-31";
            else
                dateTimePicker_valid.Text = szItem;
            textBox_Person.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_Cell.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox_Type.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszAddr = textBox_Addr.Text;
            mszBoss = textBox_Boss.Text;
            mszCertType = comboBox_Cert.Text;
            mszCert = textBox_Cert.Text;
            mszValid = dateTimePicker_valid.Text;
            mszPerson = textBox_Person.Text;
            mszCell = textBox_Cell.Text;
            mszType = comboBox_Type.Text;
            mszInf = textBox_Desc.Text;
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow oCurRow = dataGridView1.CurrentRow;
            if (oCurRow == null)
            {
                MessageBox.Show("请先选择要删除的卖方信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.No == MessageBox.Show("请确认要删除该卖方信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前删除操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string szSql = "select count(*) from base_store where STORE_ID=" + mszCode;
            try
            {
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方基本信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum != 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：selete count(*) error）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方基本信息－删除", "SQL=" + szSql + ",Err=no record return");
                    goto Eend;
                }

                szSql = "update base_store set STORE_STAT='STOP' where STORE_ID=" + mszCode;
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方基本信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MessageBox.Show("删除该卖方成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除该卖方失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            return;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该卖方信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql;
            string szTitle;
            string szErr = "";
            int iRst;
            string[] szItem = comboBox_Cert.Text.Split(',');
            try
            {
                if (IsNew)// textBox_Name.Enabled)//add
                {
                    szTitle = "卖方基本信息－新增";
                    if (textBox_Cert.TextLength == 0)
                    {
                        MessageBox.Show("请输入卖方联系人身份证号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Cert.SelectAll();
                        textBox_Cert.Focus();
                        return;
                    }
                    if (textBox_Cell.TextLength == 0)
                    {
                        MessageBox.Show("请输入卖方联系电话", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Cell.SelectAll();
                        textBox_Cell.Focus();
                        return;
                    }
                    szSql = "select * from base_store where STORE_NAME='" + textBox_Name.Text.Trim() + "'";
                    DataSet ds = new DataSet();
                    iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if (iRst < 0)
                    {
                        MessageBox.Show("查询信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                        goto Eend;
                    }
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        MessageBox.Show("卖方名称不能重复，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=卖方名称不能重复，请重新输入");
                        textBox_Name.SelectAll();
                        textBox_Name.Focus();
                        goto Eend;
                    }

                    szSql = "INSERT INTO base_store(STORE_NAME,STORE_ADDR,STORE_BOSS,STORE_TEL,CERT_TYPE,CERT_ID,CERT_VALID,"
                        + "STORE_PERSON,STORE_CELL,STORE_TYPE,CITY,RMRK,STORE_STAT) VALUES "
                        + "('" + textBox_Name.Text.Trim() + "','" + textBox_Addr.Text.Trim() + "','"
                        + textBox_Boss.Text.Trim() + "','" + textBox_Cell.Text.Trim() + "',"
                        + Convert.ToInt16(szItem[0]) + ",'" + textBox_Cert.Text.Trim() + "','" + dateTimePicker_valid.Value + "','"
                        + textBox_Person.Text.Trim() + "','" + textBox_Cell.Text.Trim() + "',"
                        + comboBox_Type.SelectedIndex + 1 + ",'ZHONGSHAN','" + textBox_Desc.Text.Trim() + "','USED')";
                }
                else//edit
                {
                    szTitle = "卖方基本信息－修改";
                    szSql = "UPDATE base_store set STORE_ADDR = '" + textBox_Addr.Text.Trim()
                        + "',STORE_NAME = '" + textBox_Name.Text.Trim()
                        + "',STORE_BOSS = '" + textBox_Boss.Text.Trim()
                        + "',STORE_TEL = '" + textBox_Cell.Text.Trim()
                        + "',CERT_TYPE = " + Convert.ToInt16(szItem[0])
                        + ",CERT_ID = '" + textBox_Cert.Text.Trim()
                        + "',CERT_VALID = '" + dateTimePicker_valid.Value
                        + "',STORE_PERSON = '" + textBox_Person.Text.Trim()
                        + "',STORE_CELL = '" + textBox_Cell.Text.Trim()
                        + "',STORE_TYPE = " + (comboBox_Type.SelectedIndex + 1)
                        + ",RMRK = '" + textBox_Desc.Text.Trim()
                        + "' WHERE STORE_ID=" + textBox_Code.Text.Trim();
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "编号" + textBox_Code.Text + "-卖方名" + textBox_Name.Text;
                    MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridDataRefresh();
                    //dataGridView1.Refresh();
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
                }
                groupBoxInf.Enabled = false;
                groupBoxList.Enabled = true;

                textBox_Code.Text = mszCode;
                textBox_Name.Text = mszName;
                textBox_Addr.Text = mszAddr;
                textBox_Boss.Text = mszBoss;
                comboBox_Cert.Text = mszCertType;
                textBox_Cert.Text = mszCert;
                dateTimePicker_valid.Text = mszValid;
                textBox_Person.Text = mszPerson;
                textBox_Cell.Text = mszCell;
                comboBox_Type.Text = mszType;
                textBox_Desc.Text = mszInf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();

        }
    }
}
