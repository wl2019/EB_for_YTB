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
    public partial class frm_Prod_Fee : Form
    {
        string mszCode;
        string mszName;
        string mszType_Prod;
        string mszType_Rate;
        string mszBgn;
        string mszEnd;
        string mszRate;
        string mszInf;

        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "SELECT a.PROD_ID as 商品编号,PROD_NAME as 商品名称,"
                + "if(RATE_TYPE=1,'1-买方服务费',if(RATE_TYPE=2,'2-买方系统使用费',if(RATE_TYPE=3,'3-卖方服务费','4-卖方系统使用费'))) as 收费类型,"
                + "concat(format(RATE/10,1),'%') as 收费费率,"
                + "DATE_FORMAT(BGN_TIME,'%Y-%m-%d') as 生效时间,DATE_FORMAT(END_TIME,'%Y-%m-%d') as 失效时间,RMRK as 备注 "
                            + "FROM base_prod a, mng_rate b "
                + "where a.PROD_ID = b.PROD_ID and RATE_VALID = 'Y' order by a.PROD_ID,RATE_TYPE";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            dataGridView1.RowHeadersWidth = 15;
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();

            radioButton_Type.Checked = false;
            radioButton_Type.Checked = false;
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            comboBox_Type_Prod.Text = "";
            comboBox_Name.Text = dataGridView1.Rows[0].Cells[0].Value.ToString() 
                + "-" + dataGridView1.Rows[0].Cells[1].Value.ToString();
            comboBox_Type_Rate.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            string szItem = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox_Rate.Text = szItem.Substring(0, szItem.Length - 1);
            dateTimePicker_Bgn.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            szItem = dataGridView1.Rows[0].Cells[5].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_End.Text = "2100-12-31";
            else
                dateTimePicker_End.Text = szItem;
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();

            mszCode = dataGridView1.Rows[0].Cells[0].Value.ToString();
            mszName = comboBox_Name.Text;
            mszType_Prod = "";
            mszType_Rate = comboBox_Type_Prod.Text;
            mszBgn = dataGridView1.Rows[0].Cells[4].Value.ToString();
            mszEnd = dataGridView1.Rows[0].Cells[5].Value.ToString();
            mszRate = textBox_Rate.Text;            
            mszInf = textBox_Desc.Text;
            MyStart.oMyDb.Close();
        }

        public frm_Prod_Fee()
        {
            InitializeComponent();
        }

        private void frm_Prod_Fee_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Crab.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Crab.ico"));
            button_Add.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.add.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Del.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Delete.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Undo.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            groupBoxInf.Enabled = false;
            GridDataRefresh();

            comboBox_Type_Rate.Items.Add("1-买方服务费"); //市场方收取");// 买方服务费");
            comboBox_Type_Rate.Items.Add("2-买方系统使用费");// 益通宝收取");// 市场方收取卖方服务费");
            comboBox_Type_Rate.Items.Add("3-卖方服务费");//买方收取");// 益通宝收取买方服务费");
            comboBox_Type_Rate.Items.Add("4-卖方系统使用费");//卖方收取");// 益通宝收取卖方服务费");

            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select prod_id, prod_name from base_prod where prod_level = 0 and prod_id>0 order by prod_id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }

            for (int i = 0; i < iNum; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string szItem = dr[0].ToString() + "-" + dr[1].ToString();
                comboBox_Type_Prod.Items.Add(szItem);
            }

            //ds = new DataSet();
            //szSql = "select prod_id, prod_name from base_prod where prod_level = 1 order by prod_id";
            //iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            //if (iRst != 0)
            //    return;
            //iNum = ds.Tables[0].Rows.Count;
            //if (iNum == 0)
            //    return;

            //for (int i = 0; i < iNum; i++)
            //{
            //    DataRow dr = ds.Tables[0].Rows[i];
            //    string szItem = dr[0].ToString() + "-" + dr[1].ToString();
            //    comboBox_Name.Items.Add(szItem);
            //}
            MyStart.oMyDb.Close();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            radioButton_Type.Enabled = true;
            radioButton_Name.Enabled = true;
            comboBox_Type_Prod.Enabled = true;

            radioButton_Type.Checked = true;
            comboBox_Name.Enabled = false;
            comboBox_Type_Rate.Enabled = true;
            //textBox_Rate.Focus();

            comboBox_Type_Prod.SelectedIndex = 0;
            comboBox_Name.Text = "";
            comboBox_Type_Rate.SelectedIndex = 0;
            textBox_Rate.Text = "";
            dateTimePicker_Bgn.Text = DateTime.Now.ToShortDateString();
            dateTimePicker_End.Text = DateTime.Now.AddDays(+365).ToShortDateString();
            textBox_Desc.Text = "";

            comboBox_Type_Prod.Focus();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;

            radioButton_Type.Enabled = false;
            radioButton_Name.Enabled = false;
            comboBox_Type_Prod.Enabled = false;
            comboBox_Name.Enabled = false;
            comboBox_Type_Rate.Enabled = false;
            textBox_Rate.Focus();
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow oCurRow = dataGridView1.CurrentRow;
            if (oCurRow == null)
            {
                MessageBox.Show("请先选择要删除的收费信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql = "select prod_level from base_prod where prod_id=" + mszCode;
            try
            {
                DataSet ds = new DataSet();
                string szErr = "";
                string szItem;
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst < 0)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("商品收费信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                else
                {
                    int iNum = ds.Tables[0].Rows.Count;
                    if (iNum != 1)
                    {
                        MessageBox.Show("删除操作出错（错误原因：商品信息错误", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyIniFile.WriteLog("商品收费信息－删除", "SQL=" + szSql + ",Err=商品信息错误");
                        goto Eend;
                    }

                    DataRow dr = ds.Tables[0].Rows[0];
                    int iProdLevel = Convert.ToInt16(dr[0]);
                    if (iProdLevel == 0)//type
                        szItem = "商品分类";
                    else//name
                        szItem = "商品";
                }
                if (DialogResult.No == MessageBox.Show("请确认要删除该" + szItem + "的收费信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    MessageBox.Show("取消当前删除操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }

                string[] szX = comboBox_Type_Rate.Text.Split('-');
                szSql = "INSERT INTO mng_rate_his (PROD_ID,RATE_TYPE,BGN_TIME,END_TIME,RATE,RATE_VALID,ADD_DT,ADD_ID,RMRK) VALUES ("
                    + mszCode + "," + szX[0] + ",'" + mszBgn + "',curdate()," + (Convert.ToSingle(mszRate) * 10).ToString()
                    + ",'N',curtime()," + MyStart.giUserID.ToString() + ",'" + mszInf + "')";
                szErr = "";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("商品收费信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                szSql = "delete from mng_rate where prod_id=" + mszCode + " and rate_type=" + szX[0];
                szErr = "";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("商品收费信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }
                MessageBox.Show("删除该" + szItem + "的收费信息成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
            return;
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            radioButton_Type.Checked = false;
            radioButton_Type.Checked = false;
            comboBox_Type_Prod.Text = "";
            comboBox_Name.Text = mszName;
            comboBox_Type_Rate.Text = mszType_Rate;
            textBox_Rate.Text = mszRate;
            dateTimePicker_Bgn.Text = mszBgn;            
            if (mszEnd.Length == 0)
                dateTimePicker_End.Text = "2100-12-31";
            else
                dateTimePicker_End.Text = mszEnd;
            textBox_Desc.Text = mszInf;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该收费信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szRate = (Convert.ToSingle(textBox_Rate.Text) * 10).ToString();
            string szSql;
            string szTitle;
            string[] szCode;
            if (!comboBox_Type_Rate.Enabled)//edit,code from name
                szCode = comboBox_Name.Text.Split('-');
            else//add
            {
                if (radioButton_Type.Checked)//code from type
                    szCode = comboBox_Type_Prod.Text.Split('-');
                else//code from name
                    szCode = comboBox_Name.Text.Split('-');
            }
            string[] szX = comboBox_Type_Rate.Text.Split('-');
            string szErr = "";
            int iRst;
            string szBgn = string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value) + " 00:00:00";
            string szEnd = string.Format("{0:yyyy-MM-dd}", dateTimePicker_End.Value) + " 23:59:59";
            try
            {
                if (comboBox_Type_Rate.Enabled)//add
                {
                    szTitle = "商品收费信息－新增";
                    if (radioButton_Name.Checked)
                    {
                        AddNewFee(szTitle, szCode[0], szCode[1], szX[0], szRate, szBgn, szEnd);
                    }
                    if (radioButton_Type.Checked)
                    {
                        if (szCode[0] == "0")//all prod
                            szSql = "select PROD_ID,prod_name from base_prod where PROD_LEVEL=1";
                        else
                            szSql = "select PROD_ID,prod_name from base_prod where PARENT_ID=" + szCode[0];
                        szErr = "";
                        DataSet ds = new DataSet();
                        iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                        if (iRst != 0)
                        {
                            MessageBox.Show("保存修改后的信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                            goto Eend;
                        }

                        int iNum = ds.Tables[0].Rows.Count;
                        if (iNum == 0)
                        {
                            MessageBox.Show("没有要修改的商品", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            for (int i = 0; i < iNum; i++)
                            {
                                DataRow dr = ds.Tables[0].Rows[i];
                                szSql = "select * from mng_rate where PROD_ID=" + dr[0].ToString() + " and RATE_TYPE=" + szX[0];
                                DataSet ds2 = new DataSet();
                                iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds2, ref szErr);
                                if (iRst != 0)
                                {
                                    MessageBox.Show("保存修改后的信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                                    goto Eend;
                                }

                                if (ds2.Tables[0].Rows.Count > 0)//edit
                                    EditNewFee(szTitle, dr[0].ToString(), dr[1].ToString(), szX[0], szRate, szBgn, szEnd);
                                else
                                    AddNewFee(szTitle, dr[0].ToString(), dr[1].ToString(), szX[0], szRate, szBgn, szEnd);
                            }
                        }
                    }
                }
                else//edit
                {
                    szTitle = "商品收费信息－修改";
                    EditNewFee(szTitle, szCode[0], szCode[1], szX[0], szRate, szBgn, szEnd);
                }
                groupBoxInf.Enabled = false;
                groupBoxList.Enabled = true;
                MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //textBox_Code.Text = mszCode;
                comboBox_Name.Text = mszName;
                comboBox_Type_Prod.Text = mszType_Rate;
                textBox_Rate.Text = mszRate;
                textBox_Desc.Text = mszInf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void AddNewFee(string szTitle,string szProdID,string szProdName,string szRateType,string szRate,
            string szBgn,string szEnd)
        {
            string szSql = "INSERT INTO mng_rate (PROD_ID,RATE_TYPE,BGN_TIME,END_TIME,RATE,RATE_VALID,ADD_DT,ADD_ID,RMRK) VALUES ("
                        + szProdID + "," + szRateType + ",'" + szBgn + " ','" + szEnd + "'," + szRate
                        + ",'Y',curtime()," + MyStart.giUserID.ToString() + ",'" + textBox_Desc.Text + "')";
            string szErr="";
            int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst < 1)
            {
                MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
            }
            else
            {
                szSql = szProdName + "-" + textBox_Rate.Text + "% (" + szBgn + "," + szEnd + ")";
                MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                //MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
                MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
            }
            MyStart.oMyDb.Close();
            return;
        }

        private void EditNewFee(string szTitle, string szProdID, string szProdName, string szRateType, string szRate, 
            string szBgn, string szEnd)
        {
            string szSql = "INSERT INTO mng_rate_his (PROD_ID,RATE_TYPE,BGN_TIME,END_TIME,RATE,RATE_VALID,ADD_DT,ADD_ID,RMRK) VALUES ("
                + szProdID + "," + szRateType + ",'" + mszBgn + "','"
                + string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value.AddDays(-1))
                + " 23:59:59'," + szRate + ",'N',curtime()," + MyStart.giUserID.ToString() + ",'" + mszInf + "')";
            string szErr = "";
            int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst < 1)
            {
                MessageBox.Show("保存修改后的信息出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
                MyStart.oMyDb.Close();
                return;
            }

            szSql = "UPDATE mng_rate SET BGN_TIME='" + szBgn
                + "',END_TIME = '" + szEnd
                + " ',RATE = " + (Convert.ToSingle(textBox_Rate.Text) * 10).ToString()
                + ",CHG_DT = curtime()"
                + ",CHG_ID = " + MyStart.giUserID.ToString()
                + ",RMRK = '" + textBox_Desc.Text
                + "' where prod_id=" + mszCode + " and rate_type=" + szRateType;
            iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst < 1)
            {
                MessageBox.Show("保存出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",Err=" + szErr);
            }
            else
            {
                szSql = szProdName + "-" + textBox_Rate.Text + "% (" + szBgn + "," + szEnd + ")";
                MyFunc.WriteToDbLog(szTitle, szSql, "MSG", MyStart.giUserID);

                //MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
                MyIniFile.WriteLog(szTitle, "SQL=" + szSql + ",OK");
            }
            MyStart.oMyDb.Close();
            return;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            radioButton_Type.Checked = false;
            radioButton_Type.Checked = false;
            comboBox_Type_Prod.Text = "";
            comboBox_Name.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString()
                + "-" + dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox_Type_Rate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string szItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if(szItem.Length>0)
                textBox_Rate.Text = szItem.Substring(0, szItem.Length - 1);
            dateTimePicker_Bgn.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            szItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (szItem.Length == 0)
                dateTimePicker_End.Text = "2100-12-31";
            else
                dateTimePicker_End.Text = szItem;
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            mszCode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mszName = comboBox_Name.Text;
            mszType_Prod = "";
            mszType_Rate = comboBox_Type_Rate.Text;
            mszBgn = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            mszEnd = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            mszRate = textBox_Rate.Text;
            mszInf = textBox_Desc.Text;
        }

        private void radioButton_Type_Click(object sender, EventArgs e)
        {
            comboBox_Type_Prod.Enabled = true;
            comboBox_Name.Enabled = false;
        }

        private void radioButton_Name_Click(object sender, EventArgs e)
        {
            comboBox_Type_Prod.Enabled = true;
            comboBox_Name.Enabled = true;
        }

        private void comboBox_Type_Prod_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Name.Text = "";
            comboBox_Name.Items.Clear();

            DataSet ds = new DataSet();
            string szErr = "";
            string[] szType = comboBox_Type_Prod.Text.Split('-');
            string szSql = "select prod_id, prod_name from base_prod "
                +" where prod_level = 1 and parent_id=" + szType[0].Trim()
                +" order by prod_id";
            if (Convert.ToInt16(szType[0]) == 0)//all
                szSql = "select prod_id, prod_name from base_prod where prod_level = 1 order by prod_id";

            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }

            for (int i = 0; i < iNum; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string szItem = dr[0].ToString() + "-" + dr[1].ToString();
                comboBox_Name.Items.Add(szItem);
            }
            if(comboBox_Name.Items.Count>0)
                comboBox_Name.SelectedIndex = 0;
            MyStart.oMyDb.Close();
        }
    }
}
