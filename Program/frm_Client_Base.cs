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
    public partial class frm_Client_Base : Form
    {
        bool mbSign,IsNew;
        string mszCode, mszName, mszCertType, mszCert, mszValid, mszCell, mszStat, mszTruck, mszAddr, mszInf;

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该买方信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql;
            string szTitle;
            string szErr = "";
            int iRst;
            string[] szItem = comboBox_Cert.Text.Split(',');
            string szStat="STOP";
            if (comboBox_state.SelectedIndex == 0)
                szStat = "BGN";
            int iSign = 0;
            if (checkBox_Sign.Checked)
                iSign = 1;
            try
            {
                if (IsNew)//add
                {
                    szTitle = "买方基本信息－新增";
                    if (textBox_Cert.TextLength == 0)
                    {
                        MessageBox.Show("请输入买方身份证号", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Cert.SelectAll();
                        textBox_Cert.Focus();
                        return;
                    }
                    if (textBox_Cell.TextLength == 0)
                    {
                        MessageBox.Show("请输入买方联系电话", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Cell.SelectAll();
                        textBox_Cell.Focus();
                        return;
                    }
                    szSql = "select * from base_buyer where user_name='" + textBox_Name.Text.Trim() + "'";
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
                        MessageBox.Show("买方姓名不能重复，请重新输入", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=买方姓名不能重复，请重新输入");
                        textBox_Name.SelectAll();
                        textBox_Name.Focus();
                        goto Eend;
                    }

                    szSql = "INSERT INTO base_buyer (user_name,user_addr,user_tel,cert_type,cert_id,cert_valid,add_id,add_dt,truck_no,rmrk,is_sign,user_stat) VALUES "
                        + "('" + textBox_Name.Text.Trim() + "','" + textBox_Addr.Text.Trim() + "','" + textBox_Cell.Text.Trim() + "',"
                        + Convert.ToInt16(szItem[0]) + ",'" + textBox_Cert.Text.Trim() + "','" + dateTimePicker_valid.Value + "',"
                        + MyStart.giUserID + ",curtime(),'" + comboBox_truck.Text.Trim() + textBox_truck.Text.Trim() + "','"
                        + textBox_Desc.Text.Trim() + "',"+ iSign+",'"+ szStat+ "')";
                }
                else//edit
                {
                    szTitle = "买方基本信息－修改";
                    szSql = "UPDATE base_buyer set user_addr = '" + textBox_Addr.Text.Trim()
                        + "',user_name = '" + textBox_Name.Text.Trim()
                        + "',user_tel = '" + textBox_Cell.Text.Trim()
                        + "',CERT_TYPE = " + Convert.ToInt16(szItem[0])
                        + ",CERT_ID = '" + textBox_Cert.Text.Trim()
                        + "',CERT_VALID = '" + dateTimePicker_valid.Value
                        + "',user_stat = '" + szStat
                        + "',truck_no = '" + comboBox_truck.Text.Trim() + textBox_truck.Text.Trim()
                        + "',is_sign = " + iSign
                        + ",RMRK = '" + textBox_Desc.Text.Trim()
                        + "' WHERE ID=" + textBox_Code.Text.Trim();
                }
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                }
                else
                {
                    szSql = "编号" + textBox_Code.Text + "-买方名" + textBox_Name.Text;
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
                textBox_Cell.Text = mszCell;
                comboBox_state.Text = mszStat;

                checkBox_Sign.Checked = mbSign;
                comboBox_Cert.Text = mszCertType;
                textBox_Cert.Text = mszCert;
                dateTimePicker_valid.Text = mszValid;
                if (mszTruck.Length > 1)
                {
                    comboBox_truck.Text = mszTruck.Substring(0, 1);
                    textBox_truck.Text = mszTruck.Substring(1);
                }
                else
                {
                    comboBox_truck.Text = "";
                    textBox_truck.Text = "";
                }
                textBox_Addr.Text = mszAddr;
                textBox_Desc.Text = mszInf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            textBox_Cell.Text = mszCell;
            comboBox_state.Text=mszStat;

            checkBox_Sign.Checked= mbSign ;
            comboBox_Cert.Text = mszCertType;
            textBox_Cert.Text = mszCert;
            dateTimePicker_valid.Text = mszValid;
            if(mszTruck.Length>1)
            {
                comboBox_truck.Text = mszTruck.Substring(0, 1);
                textBox_truck.Text = mszTruck.Substring(1);
            }
            else
            {
                comboBox_truck.Text = "";
                textBox_truck.Text = "";
            }
            textBox_Addr.Text= mszAddr;
            textBox_Desc.Text= mszInf;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            IsNew = false;
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            textBox_Code.Enabled = false;
            //textBox_Name.Enabled = false;
            textBox_Cell.Focus();

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
            textBox_Cell.Text = "";
            comboBox_state.SelectedIndex = 0;

            comboBox_Cert.SelectedIndex = 0;
            textBox_Cert.Text = "";
            dateTimePicker_valid.Text = "2050-12-31";
            comboBox_truck.Text ="粤";
            textBox_truck.Text = "";

            textBox_Addr.Text = "";
            textBox_Desc.Text = "";
            textBox_Name.Focus();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string[] szX = dataGridView1.CurrentRow.Cells[2].Value.ToString().Split('-');
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
            string szItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_valid.Text = "2020-12-31";
            else
                dateTimePicker_valid.Text = szItem;

            textBox_Cell.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox_state.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "是")
                checkBox_Sign.Checked = true;
            else
                checkBox_Sign.Checked = false;
            string szX = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            if (szX.Length > 1)
            {
                comboBox_truck.Text = szX.Substring(0, 1);
                textBox_truck.Text = szX.Substring(1);
            }
            else
            {
                comboBox_truck.Text = "";
                textBox_truck.Text = "";
            }

            textBox_Addr.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszCell = textBox_Cell.Text;
            mszStat = comboBox_state.Text;

            mbSign = checkBox_Sign.Checked;
            mszCertType = comboBox_Cert.Text;
            mszCert = textBox_Cert.Text;
            mszValid = dateTimePicker_valid.Text;
            mszTruck = comboBox_truck.Text + textBox_truck.Text;

            mszAddr = textBox_Addr.Text;
            mszInf = textBox_Desc.Text;
        }

        public frm_Client_Base()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {//买方编号,姓名,证件号码,证件有效期,电话,状态,签约客户,车牌号,经营地址,备注
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select id as 买方编号,user_name as 姓名,concat(if (CERT_TYPE = 1,'1,身份证',if (CERT_TYPE = 2,'2,驾驶证','3,其它证件')),'-',CERT_ID) as 证件号码," +
                "cert_valid as 证件有效期,user_tel as 电话,if (user_stat = 'BGN','正常','注销') as 状态,if (is_sign = 1,'是','否') as 签约客户,truck_no as 车牌号," +
                "user_addr as 经营地址,rmrk as 备注 from base_buyer order by ID desc";
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
            string[] szX = dataGridView1.Rows[0].Cells[2].Value.ToString().Split('-');
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
            string szItem = dataGridView1.Rows[0].Cells[3].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_valid.Text = "2020-12-31";
            else
                dateTimePicker_valid.Text = szItem;

            textBox_Cell.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            comboBox_state.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            if (dataGridView1.Rows[0].Cells[5].Value.ToString() == "是")
                checkBox_Sign.Checked = true;
            else
                checkBox_Sign.Checked = false;
            comboBox_truck.Text = dataGridView1.Rows[0].Cells[7].Value.ToString().Substring(0,1);
            textBox_truck.Text = dataGridView1.Rows[0].Cells[7].Value.ToString().Substring(1);

            textBox_Addr.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
            
            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszCell = textBox_Cell.Text;
            mszStat = comboBox_state.Text;

            mbSign = checkBox_Sign.Checked;
            mszCertType = comboBox_Cert.Text;
            mszCert = textBox_Cert.Text;
            mszValid = dateTimePicker_valid.Text;
            mszTruck = comboBox_truck.Text + textBox_truck.Text;

            mszAddr = textBox_Addr.Text;
            mszInf = textBox_Desc.Text;
            MyStart.oMyDb.Close();
        }
        private void frm_Client_Base_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.ie4power.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            comboBox_state.Items.Add("正常");
            comboBox_state.Items.Add("注销");

            comboBox_Cert.Items.Add("1,身份证");
            comboBox_Cert.Items.Add("2,驾驶证");
            comboBox_Cert.Items.Add("3,其它证件");

            string szCity = "北京（京）、天津（津）、黑龙江（黑）、吉林（吉）、辽宁（辽）、河北（冀）、河南（豫）、山东（鲁）、山西（晋）、陕西（陕）、内蒙古（蒙）、宁夏（宁）、甘肃（甘）、新疆（新）、青海（青）、西藏（藏）、湖北（鄂）、安徽（皖）、江苏（苏）、上海（沪）、浙江（浙）、福建（闵）、湖南（湘）、江西（赣）、四川（川）、重庆（渝）、贵州（黔）、云南（滇）、广东（粤）、广西（桂）、海南（琼）、香港（港）、澳门（澳）、台湾（台）";
            string[] szCities = szCity.Split('、');
            comboBox_truck.Items.Clear();
            for (int i = 0; i < szCities.Length; i++)
            {
                int iPos = szCities[i].IndexOf('）');
                comboBox_truck.Items.Add(szCities[i].Substring(iPos - 1, 1));
            }
            //comboBox_truck.Text = "粤";
            //textBox_truck.Text = "";

            //MyFunc.GridInit(ref dataGridView1, "买方编号,姓名,证件号码,证件有效期,电话,状态,签约客户,车牌号,经营地址,备注", "1,1,1,1,1,1,1,1,1,1", 15, 12, true);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
