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
    public partial class frm_User_App : Form
    {
        string mszCode;
        string mszName;
        string mszLogin;
        string mszApp;
        string mszInf;

        public frm_User_App()
        {
            InitializeComponent();
        }

        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "SELECT USER_ID as 人员编号,USER_NAME as 姓名,USER_LOGIN as 登录名,"
                + " USER_APP as 用户权限,RMRK as 备注 FROM sys_users "
                + " where USER_TYPE>1 and USER_STAT='USED' order by USER_ID";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            dataGridView1.RowHeadersWidth = 15;

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            textBox_Code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox_login.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszLogin = textBox_login.Text;
            mszInf = textBox_Desc.Text;

            mszApp = dataGridView1.Rows[0].Cells[3].Value.ToString();
            ShowApp(mszApp);
            MyStart.oMyDb.Close();
        }
        private void ShowApp(string szApp)
        {
            if (szApp.Length == 0)
                return;
            bool[,] bApp = new bool[frm_Main.iMainMenuNum, frm_Main.iSubMenuMaxNum];            
            MyFunc.GetApp(szApp, ref bApp);

            checkBox_Set_Sys.Checked = bApp[0, 0];
            checkBox_Set_Run.Checked = bApp[0, 1];
            checkBox_Set_Key.Checked = bApp[0, 2];

            checkBox_User_Net.Checked = bApp[1, 0];
            checkBox_User_Base.Checked = bApp[1, 1];
            checkBox_User_App.Checked = bApp[1, 2];
            checkBox_User_Log.Checked = bApp[1, 3];

            checkBox_Prod_type.Checked = bApp[2, 0];
            checkBox_Prod_Base.Checked = bApp[2, 1];
            checkBox_Prod_Fee.Checked = bApp[2, 2];

            checkBox_Firm_Base.Checked = bApp[3, 0];
            checkBox_Firm_Pos.Checked = bApp[3, 1];
            checkBox_Firm_Card.Checked = bApp[3, 2];
            checkBox_Firm_Qry.Checked = bApp[3, 3];
            checkBox_Firm_QryCard.Checked = bApp[3, 4];
            checkBox_Firm_Mng.Checked = bApp[3, 5];
            checkBox_Firm_QryTrade.Checked = bApp[3, 6];

            checkBox_Firm_Trans.Checked = bApp[4, 0];
            checkBox_Firm_QryVal.Checked = bApp[4, 1];
            checkBox_Firm_Cash.Checked = bApp[4, 2];
            checkBox_Firm_QryMoney.Checked = bApp[4, 3];

            checkBox_User_Card.Checked = bApp[5, 0];
            checkBox_User_Mng.Checked = bApp[5, 1];
            checkBox_User_Qry.Checked = bApp[5, 2];
            checkBox_User_QryCard.Checked = bApp[5, 3];

            checkBox_User_QryVal.Checked = bApp[6, 0];
            checkBox_User_Add.Checked = bApp[6, 1];
            checkBox_User_Cash.Checked = bApp[6, 2];
            checkBox_User_QryMoney.Checked = bApp[6, 3];

            checkBox_Sum_Mkt.Checked = bApp[7, 0];
            checkBox_Sum_Firm.Checked = bApp[7, 1];
            checkBox_Sum_User.Checked = bApp[7, 2];
            checkBox_Sum_Prod.Checked = bApp[7, 3];
            checkBox_Qry_Pos.Checked = bApp[7, 4];
            checkBox_Qry_Detail.Checked = bApp[7,5];
            checkBox_Qry_Card.Checked = bApp[7, 6];

            checkBox_Duty_Pwd.Checked = bApp[8, 0];
            checkBox_Duty_Run.Checked = bApp[8, 1];
            checkBox_Duty_Qry.Checked = bApp[8, 2];

            checkBox_Pos.Checked = bApp[9, 0];
        }
        private void frm_User_App_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.users.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            textBox_Code.Enabled = false;
            textBox_Name.Enabled = false;
            textBox_login.Enabled = false;
            textBox_Desc.Focus();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_login.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszLogin = textBox_login.Text;
            mszInf = textBox_Desc.Text;

            mszApp = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            ShowApp(mszApp);
        }

        private string GetApp()
        {
            string szItem = (checkBox_Set_Sys.Checked ? "1" : "0");
            szItem += (checkBox_Set_Run.Checked ? "1" : "0");
            szItem += (checkBox_Set_Key.Checked ? "1" : "0");
            //szItem += "000";

            szItem += (checkBox_User_Net.Checked ? "1" : "0");
            szItem += (checkBox_User_Base.Checked ? "1" : "0");
            szItem += (checkBox_User_App.Checked ? "1" : "0");
            szItem += (checkBox_User_Log.Checked ? "1" : "0");

            szItem += (checkBox_Prod_type.Checked ? "1" : "0");
            szItem += (checkBox_Prod_Base.Checked ? "1" : "0");
            szItem += (checkBox_Prod_Fee.Checked ? "1" : "0");

            szItem += (checkBox_Firm_Base.Checked ? "1" : "0");
            szItem += (checkBox_Firm_Pos.Checked ? "1" : "0");
            szItem += (checkBox_Firm_Card.Checked ? "1" : "0");
            szItem += (checkBox_Firm_Qry.Checked ? "1" : "0");
            szItem += (checkBox_Firm_QryCard.Checked ? "1" : "0");
            szItem += (checkBox_Firm_Mng.Checked ? "1" : "0");
            szItem += (checkBox_Firm_QryTrade.Checked ? "1" : "0");

            szItem += (checkBox_Firm_Trans.Checked ? "1" : "0");
            szItem += (checkBox_Firm_QryVal.Checked ? "1" : "0");
            szItem += (checkBox_Firm_Cash.Checked ? "1" : "0");
            szItem += (checkBox_Firm_QryMoney.Checked ? "1" : "0");

            szItem += (checkBox_User_Card.Checked ? "1" : "0");
            szItem += (checkBox_User_Mng.Checked ? "1" : "0");
            szItem += (checkBox_User_Qry.Checked ? "1" : "0");
            szItem += (checkBox_User_QryCard.Checked ? "1" : "0");

            szItem += (checkBox_User_QryVal.Checked ? "1" : "0");
            szItem += (checkBox_User_Add.Checked ? "1" : "0");
            szItem += (checkBox_User_Cash.Checked ? "1" : "0");
            szItem += (checkBox_User_QryMoney.Checked ? "1" : "0");

            szItem += (checkBox_Sum_Mkt.Checked ? "1" : "0");
            szItem += (checkBox_Sum_Firm.Checked ? "1" : "0");
            szItem += (checkBox_Sum_User.Checked ? "1" : "0");
            szItem += (checkBox_Sum_Prod.Checked ? "1" : "0");
            szItem += (checkBox_Qry_Pos.Checked ? "1" : "0");
            szItem += (checkBox_Qry_Detail.Checked ? "1" : "0");
            szItem += (checkBox_Qry_Card.Checked ? "1" : "0");

            szItem += (checkBox_Duty_Pwd.Checked ? "1" : "0");
            szItem += (checkBox_Duty_Run.Checked ? "1" : "0");
            szItem += (checkBox_Duty_Qry.Checked ? "1" : "0");

            szItem += (checkBox_Pos.Checked ? "1" : "0");

            return szItem;
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            string szTitle = "人员权限管理";
            string szApp = GetApp();
            string szSql = "UPDATE sys_users SET USER_APP = '" + szApp
                + "',RMRK = '" + textBox_Desc.Text.Trim()+ "'";
            if (checkBox_Pos.Checked)//pos
                szSql += ", USER_TYPE=3";
            szSql += " WHERE USER_ID=" + textBox_Code.Text.Trim();
            string szErr = "";
            try
            {
                int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "编号" + mszCode + "-姓名" + mszName + "-权限" + szApp;
                    MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridDataRefresh();
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
                }
                groupBoxInf.Enabled = false;
                groupBoxList.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }
    }
}
