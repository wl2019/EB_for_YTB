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
    public partial class frm_User_Net : Form
    {
        int miType;
        string mszName;
        string mszKey;
        string mszTeller;
        string mszPsam;
        string mszTel;

        public frm_User_Net()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select id as 编号, net_name as 网点名称, tel as 网点联系电话,"
                + "psam_no as PSAM卡号,net_key as 签名安全码, teller_no as 发起方操作员 "
                + "from base_net order by id";
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
            if (iNum > 0)
            {
                textBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox_tel.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox_Psam.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                textBox_Key.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                textBox_tellerNo.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();

                mszName = textBox_Name.Text;
                mszKey = textBox_Key.Text;
                mszPsam = textBox_Psam.Text;
                mszTeller = textBox_tellerNo.Text;
                mszTel = textBox_tel.Text;
            }
            MyStart.oMyDb.Close();
        }
        private void frm_User_Net_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.net.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.net.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            //MyFunc.GridInit(ref dataGridView1, "网点编号,名称,PSAM,KEY,发起方操作员", "1,1,1,1", 15, 8, true);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox_tel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_Psam.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_Key.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox_tellerNo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            mszName = textBox_Name.Text;
            mszKey = textBox_Key.Text;
            mszPsam = textBox_Psam.Text;
            mszTeller = textBox_tellerNo.Text;
            mszTel = textBox_tel.Text;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            miType = 1;
            //textBox_Code.Enabled = false;
            textBox_Name.Text = "";
            textBox_Psam.Text = "";
            textBox_Key.Text = "";
            textBox_tellerNo.Text = "";
            textBox_tel.Text = "";
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;
            //bIsAddNew = false;

            miType = 2;
            textBox_Psam.Enabled = false;
            textBox_Name.Focus();

        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Name.Text = mszName;
            textBox_Psam.Text = mszPsam;
            textBox_Key.Text = mszKey;
            textBox_tellerNo.Text = mszTeller;
            textBox_tel.Text = mszTel;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string szSql;
            string szTitle;
            string szErr = "";
            int iRst;

            if (DialogResult.No == MessageBox.Show("请确认要保存该工作网点信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (miType==1)//add
                szTitle = "工作网点基本信息－新增";
            else//edit
                szTitle = "工作网点基本信息－修改";

            if (textBox_Name.Text.Length == 0)
            {
                MessageBox.Show("网点名称不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Name.SelectAll();
                textBox_Name.Focus();
                return;
            }

            if (textBox_Key.Text.Length == 0)
            {
                MessageBox.Show("KEY值不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Key.SelectAll();
                textBox_Key.Focus();
                return;
            }

            if (textBox_tellerNo.Text.Length == 0)
            {
                MessageBox.Show("发起方操作员不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_tellerNo.SelectAll();
                textBox_tellerNo.Focus();
                return;
            }

            if (textBox_Psam.Text.Length == 0)
            {
                MessageBox.Show("PSAM卡不能为空，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Psam.SelectAll();
                textBox_Psam.Focus();
                return;
            }
            try
            {
                if (miType == 1)//add
                {
                    szSql = "select * from base_net where psam_no='" + textBox_Psam.Text.Trim() + "'";
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
                        MessageBox.Show("PSAM卡号不能重复，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=PSAM卡号不能重复，请重新输入");
                        textBox_Psam.SelectAll();
                        textBox_Psam.Focus();
                        goto Eend;
                    }

                    szSql = "INSERT INTO base_net(net_name,net_key,teller_no,psam_no,tel) VALUES ('"
                        + textBox_Name.Text.Trim() + "','" + textBox_Key.Text.Trim() + "','" + textBox_tellerNo.Text.Trim() + "','"
                        + textBox_Psam.Text.Trim() + "','" + textBox_tel.Text.Trim() + "')";
                }
                else//edit
                {
                    szSql = "UPDATE base_net SET net_name = '" + textBox_Name.Text.Trim()
                        + "',net_key = '" + textBox_Key.Text.Trim()
                        + "',tel = '" + textBox_tel.Text.Trim()
                        + "',teller_no = '" + textBox_tellerNo.Text.Trim()
                        + "' WHERE psam_no=" + textBox_Psam.Text.Trim();
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "PSAM号" + mszPsam + "-网点名称" + mszName;
                    MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridDataRefresh();
                    //dataGridView1.Refresh();
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
                }
                groupBoxInf.Enabled = false;
                groupBoxList.Enabled = true;

                mszName = textBox_Name.Text;
                mszKey = textBox_Key.Text;
                mszPsam = textBox_Psam.Text;
                mszTeller = textBox_tellerNo.Text;
                mszTel = textBox_tel.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            //textBox_Name.Text = mszName;
            //textBox_Psam.Text = mszPsam;
            //textBox_Key.Text = mszKey;
            //textBox_tellerNo.Text = mszTeller;
            //textBox_tel.Text = mszTel;
        }
    }
}
