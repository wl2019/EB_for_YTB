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
    public partial class frm_Firm_Rent : Form
    {
        string mszCode;
        string mszName;
        string mszSotreID;
        string mszPerson;
        string mszCell;
        string mszBgn;
        //string mszEnd;
        string mszInf;
        public frm_Firm_Rent()
        {
            InitializeComponent();
        }
        private void GridDataRefresh(int iFirmID)
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "SELECT STALL_ID as 档口编号,concat(b.STORE_ID, '-', b.STORE_NAME) as 卖方名称,"
                + " STALL_PERSON as 联络人,STALL_TEL as 联系电话,"
                + "RENT_BGN as 租用日期,RENT_END as 退租日期,STALL_INF as 备注 FROM base_stall a, base_store b "
                + " where a.store_id = b.store_id and STALL_STAT='USED' ";
            if (iFirmID != 0)
                szSql += "  and b.store_id=" + iFirmID;
            szSql+= " order by b.STORE_ID,STALL_ID"; 

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

            textBox_Code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            comboBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox_Person.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox_Cell.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            radioButton_Bgn.Checked = true;
            dateTimePicker_valid.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = comboBox_Name.Text;
            mszPerson = textBox_Person.Text;
            mszCell = textBox_Cell.Text;
            mszBgn = dateTimePicker_valid.Text;
            mszInf = textBox_Desc.Text;
            MyStart.oMyDb.Close();
        }
        private void frm_Firm_Rent_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            DataSet ds = new DataSet();
            string szErr = "";
            int iStoreNum = 0;
            string szSql = "select concat(store_id,'-',store_name) as store from base_store order by store_id desc";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStoreNum = ds.Tables[0].Rows.Count;
                if (iStoreNum > 0)
                    comboBox_Firm.Items.Add("0-所有卖方");                   
                for (int i = 0; i < iStoreNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_Firm.Items.Add(dr[0].ToString());
                    comboBox_Name.Items.Add(dr[0].ToString());
                }
            }
            if (iStoreNum > 0)
                comboBox_Firm.SelectedIndex = 0;
            //MyFunc.GridInit(ref dataGridView1, "卖方编号,卖方名称,卖方住址,法人姓名,证件号码,证件有效期,联络人,联系电话,卖方性质,备注", "1,1,1,1,1,1,1,1,1,1,1", 15, 8, true);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh(0);
            MyStart.oMyDb.Close();
        }

        private void comboBox_Firm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] szItem = comboBox_Firm.Text.Split('-');
            mszSotreID = szItem[0];
            GridDataRefresh(Convert.ToInt16(szItem[0]));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_Person.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_Cell.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            radioButton_Bgn.Checked = true;
            dateTimePicker_valid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = comboBox_Name.Text;
            mszPerson = textBox_Person.Text;
            mszCell = textBox_Cell.Text;
            mszBgn = dateTimePicker_valid.Text;
            mszInf = textBox_Desc.Text;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            //bIsAddNew = true;
            textBox_Code.Text = "";
            textBox_Code.Enabled = false;
            comboBox_Name.Text = "";
            textBox_Person.Text = "";
            textBox_Cell.Text = "";
            radioButton_Bgn.Checked = true;
            radioButton_End.Checked = false;
            radioButton_End.Enabled = false;
            dateTimePicker_valid.Text = DateTime.Now.ToShortDateString();
            textBox_Desc.Text = "";
            comboBox_Name.Focus();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            textBox_Code.Enabled = false;
            comboBox_Name.Enabled = false;
            radioButton_Bgn.Enabled = true;
            radioButton_End.Enabled = true;
            textBox_Person.Focus();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Code.Text = mszCode;
            comboBox_Name.Text = mszName;
            textBox_Person.Text = mszPerson;
            textBox_Cell.Text = mszCell;
            dateTimePicker_valid.Text = mszBgn;
            textBox_Desc.Text = mszInf;
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow oCurRow = dataGridView1.CurrentRow;
            if (oCurRow == null)
            {
                MessageBox.Show("请先选择要删除的档口信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.No == MessageBox.Show("请确认要删除该档口信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前删除操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string szSql = "select count(*) from base_stall where STALL_ID=" + mszCode;
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方档口信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum != 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：selete count(*) error）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方档口信息－删除", "SQL=" + szSql + ",Err=no record return");
                    goto Eend;
                }

                szSql = "update base_stall set STALL_STAT='STOP',RENT_END=curtime() where STALL_ID=" + mszCode;
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("卖方档口信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MessageBox.Show("删除该档口成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh(Convert.ToInt16(mszSotreID));
                goto Eend;
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除该档口失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该档口信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql;
            string szTitle;
            string szErr = "";
            int iRst;
            string[] szItem = comboBox_Name.Text.Split('-');
            if (comboBox_Name.Enabled)//add
            {
                /*if (textBox_Cert.TextLength == 0)
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
                }*/
                szTitle = "卖方档口信息－新增";
                szSql = "INSERT INTO base_stall(STORE_ID,STALL_INF,STALL_PERSON,STALL_TEL,RENT_BGN,STALL_STAT) VALUES "
                    + "(" + szItem[0].Trim() + ",'" + textBox_Desc.Text.Trim() + "','"
                    + textBox_Person.Text.Trim() + "','" + textBox_Cell.Text.Trim() + "','"
                    + dateTimePicker_valid.Value + "','USED')";                
            }
            else//edit
            {
                szTitle = "卖方档口信息－修改";
                if (radioButton_Bgn.Checked)
                {
                    mszBgn = dateTimePicker_valid.Value.ToString();
                    
                }
                szSql = "UPDATE base_stall SET STORE_ID = " + szItem[0].Trim()
                    + ",STALL_PERSON = '" + textBox_Person.Text.Trim()
                    + "',STALL_TEL = '" + textBox_Cell.Text.Trim()
                    + "',STALL_INF = '" + textBox_Desc.Text.Trim() + "',";
                if (radioButton_Bgn.Checked)
                    szSql += "RENT_BGN='" +dateTimePicker_valid.Value+"' ";
                if (radioButton_End.Checked)
                {
                    if (dateTimePicker_valid.Value<= Convert.ToDateTime(mszBgn))
                    {
                        MessageBox.Show("退租日期应该晚于租用日期，请重新设置", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dateTimePicker_valid.Focus();
                        return;
                    }
                    szSql += "RENT_END='" + dateTimePicker_valid.Value + "' ";

                    if(dateTimePicker_valid.Value<=DateTime.Now)
                        szSql += ",STALL_STAT='STOP' ";
                }
                szSql += " WHERE STALL_ID=" + textBox_Code.Text.Trim();
            }
            try
            {
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "卖方名：" + comboBox_Name.Text + "-档口信息：" + textBox_Code.Text + textBox_Desc.Text;
                    MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridDataRefresh(Convert.ToInt16(mszSotreID));
                    //dataGridView1.Refresh();
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存档口信息失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();

            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Code.Text = mszCode;
            comboBox_Name.Text = mszName;
            textBox_Person.Text= mszPerson ;
            textBox_Cell.Text= mszCell ;
           //if(radioButton_Bgn.Checked)
            //dateTimePicker_valid.Text = mszBgn;
            textBox_Desc.Text = mszInf;      
        }
    }
}
