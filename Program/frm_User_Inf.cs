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
    public partial class frm_User_Inf : Form
    {
        string mszCode;
        string mszName;
        string mszSex;
        string mszBirth;
        string mszLogin;
       // string mszPwd;
        string mszDpt;
        string mszPosition;
        string mszCell;
        string mszTel;
        string mszAddr;
        string mszCertType;
        string mszCert;
        string mszInf;
        //bool bIsAddNew;
        public frm_User_Inf()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "SELECT USER_ID as 人员编号,USER_NAME as 姓名,USER_SEX as 性别,USER_BIRTH as 出生年月,"
                + " USER_DPT as 所属部门,USER_POS as 工作岗位,USER_MOBILE as 手机,USER_POS as 电话,USER_ADDR as 住址,"
                + " concat(if(CERT_TYPE=1,'1,身份证',if(CERT_TYPE=2,'2,工作证','3,其它证件')),'-',CERT_ID) as 证件号码,"
                + " USER_LOGIN as 登录名,RMRK as 备注 FROM sys_users "
                + " where /*USER_TYPE=2 and*/ USER_STAT='USED' order by USER_ID";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            dataGridView1.RowHeadersWidth = 15;

            int iNum = ds.Tables[0].Rows.Count;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            if(iNum>0)
            { 
                textBox_Code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                comboBox_Sex.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                string szItem = dataGridView1.Rows[0].Cells[3].Value.ToString();
                if (szItem.Length == 0)
                    dateTimePicker_birth.Text = "1995-1-1";
                else
                    dateTimePicker_birth.Text = szItem;
                textBox_Dpt.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                textBox_Position.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                textBox_Cell.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                textBox_Tel.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
                textBox_Addr.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
                string[] szX = dataGridView1.Rows[0].Cells[9].Value.ToString().Split('-');
                comboBox_Cert.Text = szX[0];
                textBox_Cert.Text = "";
                if (szX.Length>1)
                    textBox_Cert.Text = szX[1];
                textBox_login.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
                //textBox_pwd.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();
                textBox_Desc.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();

                mszCode = textBox_Code.Text;
                mszName = textBox_Name.Text;
                mszSex = comboBox_Sex.Text;
                mszBirth = dateTimePicker_birth.Text;
                mszLogin= textBox_login.Text;
                //mszPwd= textBox_pwd.Text;
                mszDpt = textBox_Dpt.Text;
                mszPosition = textBox_Position.Text;
                mszCell = textBox_Cell.Text;
                mszTel = textBox_Tel.Text;
                mszAddr = textBox_Addr.Text;
                mszCertType = comboBox_Cert.Text;
                mszCert = textBox_Cert.Text;
                mszInf = textBox_Desc.Text;
            }
            MyStart.oMyDb.Close();
        }
        private void frm_User_Inf_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            comboBox_Sex.Items.Add("男");
            comboBox_Sex.Items.Add("女");

            comboBox_Cert.Items.Add("1,身份证");
            comboBox_Cert.Items.Add("2,工作证");
            comboBox_Cert.Items.Add("3,其它证件");

            //bIsAddNew = true;

            //MyFunc.GridInit(ref dataGridView1, "人员编号,姓名,性别,出生年月,所属部门,工作岗位,手机,电话,住址,证件号码,备注", "1,1,1,1,1,1,1,1,1,1,1", 15, 8, true);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox_Sex.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string szItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_birth.Text = "1995-1-1";
            else
                dateTimePicker_birth.Text = szItem;
            textBox_Dpt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox_Position.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox_Cell.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox_Tel.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox_Addr.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string[] szX = dataGridView1.CurrentRow.Cells[9].Value.ToString().Split('-');
            comboBox_Cert.Text = szX[0];
            textBox_Cert.Text = "";
            if (szX.Length > 1)
                textBox_Cert.Text = szX[1];
            textBox_login.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            //textBox_pwd.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszSex = comboBox_Sex.Text;
            mszBirth = dateTimePicker_birth.Text;
            mszLogin = textBox_login.Text;
            //mszPwd = textBox_pwd.Text;
            mszDpt = textBox_Dpt.Text;
            mszPosition = textBox_Position.Text;
            mszCell = textBox_Cell.Text;
            mszTel = textBox_Tel.Text;
            mszAddr = textBox_Addr.Text;
            mszCert = comboBox_Cert.Text;
            mszInf = textBox_Desc.Text;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            //bIsAddNew = true;
            textBox_Code.Text = "";
            textBox_Code.Enabled = false;
            textBox_Name.Text = "";
            if(comboBox_Sex.Items.Count>0)
                comboBox_Sex.SelectedIndex=0;
            dateTimePicker_birth.Text = "1995-1-1";
            textBox_Dpt.Text = "";
            textBox_Position.Text = "";
            textBox_Cell.Text = "";
            textBox_Tel.Text = "";
            textBox_Addr.Text = "";
            if(comboBox_Cert.Items.Count>0)
                comboBox_Cert.SelectedIndex = 0;
            textBox_Cert.Text = "";
            textBox_login.Text = "";
            textBox_pwd.Text = "";
            textBox_Desc.Text = "";
            textBox_Name.Focus();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;
            //bIsAddNew = false;

            textBox_Code.Enabled = false;
            textBox_Name.Enabled = false;
            textBox_login.Enabled = false;
            comboBox_Sex.Focus();

        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow oCurRow = dataGridView1.CurrentRow;
            if (oCurRow == null)
            {
                MessageBox.Show("请先选择要删除的人员信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.No == MessageBox.Show("请确认要删除该人员信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前删除操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string szSql = "select count(*) from sys_users where user_id=" + mszCode;
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("工作人员信息管理－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                int iNum = ds.Tables[0].Rows.Count;
                if (iNum != 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：selete count(*) error）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("工作人员信息管理－删除", "SQL=" + szSql + ",Err=no record return");
                    goto Eend;
                }

                szSql = "update sys_users set USER_STAT='STOP' where user_id=" + mszCode;
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("工作人员信息管理－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MessageBox.Show("删除该人员成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除该人员失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Code.Text = mszCode;
            textBox_Name.Text = mszName;
            comboBox_Sex.Text = mszSex;
            dateTimePicker_birth.Text = mszBirth;
            textBox_Dpt.Text= mszDpt ;
            textBox_Position.Text= mszPosition ;
            textBox_Cell.Text= mszCell ;
            textBox_Tel.Text= mszTel ;
            textBox_Addr.Text= mszAddr ;
            comboBox_Cert.Text= mszCertType;
            textBox_Cert.Text = mszCert;
            textBox_Desc.Text = mszInf;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该工作人员信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szNewPwd = MyTools.OpenString_To_HideString((textBox_pwd.Text + "        ").Substring(0, 8),MyStart.gszPwdKey);

            string szSql;
            string szTitle;
            string szErr = "";
            int iRst;
            string[] szItem = comboBox_Cert.Text.Split(',');
            try
            {
                if (textBox_login.Enabled)//add
                {
                    szTitle = "工作人员基本信息－新增";
                    szSql = "select * from sys_users where USER_LOGIN='" + textBox_login.Text.Trim() + "'";
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
                        MessageBox.Show("登录帐号不能重复，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=登录帐号不能重复，请重新输入");
                        textBox_login.SelectAll();
                        textBox_login.Focus();
                        goto Eend;
                    }

                    szSql = "INSERT INTO sys_users(USER_LOGIN,USER_PWD,USER_TYPE,USER_NAME,USER_SEX,USER_BIRTH,CERT_TYPE,CERT_ID,"
                        + "USER_ADDR,USER_DPT,USER_POS,USER_TEL,USER_MOBILE,CITY,RMRK,USER_STAT,ADD_DT,USER_APP) VALUES "
                        + "('" + textBox_login.Text.Trim() + "','" + szNewPwd + "',2,'"
                        + textBox_Name.Text.Trim() + "','" + comboBox_Sex.Text.Trim() + "','" + dateTimePicker_birth.Value + "',"
                        + Convert.ToInt16(szItem[0]) + ",'" + textBox_Cert.Text.Trim() + "','" + textBox_Addr.Text.Trim() + "','"
                        + textBox_Dpt.Text.Trim() + "','" + textBox_Position.Text.Trim() + "','" + textBox_Tel.Text.Trim() + "','"
                        + textBox_Cell.Text.Trim() + "','ZHONGSHAN','" + textBox_Desc.Text.Trim() + "','USED',curtime(),'000000000000000000000000000000001')";
                }
                else//edit
                {
                    szTitle = "工作人员基本信息－修改";
                    szSql = "UPDATE sys_users SET USER_PWD = '" + szNewPwd
                        + "',USER_SEX = '" + comboBox_Sex.Text.Trim()
                        + "',USER_BIRTH = '" + dateTimePicker_birth.Value
                        + "',CERT_TYPE = " + Convert.ToInt16(szItem[0])
                        + ",CERT_ID = '" + textBox_Cert.Text.Trim()
                        + "',USER_ADDR = '" + textBox_Addr.Text.Trim()
                        + "',USER_DPT = '" + textBox_Dpt.Text.Trim()
                        + "',USER_POS = '" + textBox_Position.Text.Trim()
                        + "',USER_TEL = '" + textBox_Tel.Text.Trim()
                        + "',USER_MOBILE = '" + textBox_Cell.Text.Trim()
                        + "',RMRK = '" + textBox_Desc.Text.Trim()
                        + "' WHERE USER_ID=" + textBox_Code.Text.Trim();
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "编号" + mszCode + "-姓名" + mszName;
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
                textBox_Desc.Text = mszInf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
