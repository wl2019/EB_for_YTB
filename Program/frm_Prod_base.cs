﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YTB
{
    public partial class frm_Prod_base : Form
    {
        string mszCode;
        string mszName;
        string mszType;
        string mszOrigin;
        string mszInf;
        public frm_Prod_base()
        {
            InitializeComponent();
        }
        private void GridDataRefresh()
        {
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "(select prod_id as 商品编号, prod_name as 商品名称, concat(prod_id,'-',prod_name) as 所属分类, prod_origin as 商品产地, prod_rmrk as 商品特点 "
                + "from base_prod where prod_level = 0  and prod_id>0 order by prod_id) "
                + "union "
                + "(select prod_id as 商品编号, prod_name as 商品名称, pname as 所属分类, prod_origin as 商品产地, prod_rmrk as 商品特点 "
                + "from base_prod,(select prod_id as pid, concat(prod_id,'-',prod_name) as pname from base_prod where prod_level = 0) a "
                + "where prod_level = 1 and parent_id = a.pid order by prod_id)";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            /*int iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
                return;

            int iDispNum = 0;
            for (int i = 0; i < iNum; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string szItem = dr[0].ToString() + "#" + dr[1].ToString() + "#" + dr[2].ToString();
                MyFunc.GridWriteData(ref dataGridView1, szItem, ref iDispNum);
            }*/
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            textBox_Code.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            comboBox_Type.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox_Origin.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox_Desc.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszType = comboBox_Type.Text;
            mszOrigin = textBox_Origin.Text;
            mszInf = textBox_Desc.Text;
            MyStart.oMyDb.Close();
        }
        private void frm_Prod_base_Load(object sender, EventArgs e)
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

            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select prod_id, prod_name from base_prod where prod_level = 0 and prod_id>0 order by prod_id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
                return;
            int iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
                return;

            //comboBox_Type.Items.Clear();
            for(int i=0;i<iNum;i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string szItem = dr[0].ToString() + "-" + dr[1].ToString();
                comboBox_Type.Items.Add(szItem);
            }
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

            textBox_Code.Text = "";
            textBox_Name.Text = "";
            comboBox_Type.Text = "";
            textBox_Origin.Text = "";
            textBox_Desc.Text = "";

            textBox_Code.Focus();

        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            groupBoxList.Enabled = false;
            groupBoxInf.Enabled = true;
            textBox_Code.Enabled = false;
            textBox_Name.Focus();
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            DataGridViewRow oCurRow = dataGridView1.CurrentRow;
            if (oCurRow == null)
            {
                MessageBox.Show("请先选择要删除的商品信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DialogResult.No == MessageBox.Show("请确认要删除该商品信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前删除操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string szSql = "delete from base_prod where prod_id=" + mszCode;
            string szErr = "";
            try
            {
                int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("删除操作出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("商品基本信息－删除", "SQL=" + szSql + ",Err=" + szErr);
                    return;
                }
                MessageBox.Show("删除该商品成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridDataRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除该商品失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            groupBoxInf.Enabled = false;
            groupBoxList.Enabled = true;

            textBox_Code.Text = mszCode;
            textBox_Name.Text = mszName;
            comboBox_Type.Text = mszType;
            textBox_Origin.Text = mszOrigin;
            textBox_Desc.Text = mszInf;

        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("请确认要保存该商品信息", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                MessageBox.Show("取消当前保存操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string szSql;
            string szTitle;
            string[] szType = comboBox_Type.Text.Split('-');
            int iCode=0xff;
            try
            {
                iCode = Convert.ToInt16(textBox_Code.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("商品的编号输入错误（"+ex.ToString()+"），请重新设置", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (textBox_Code.Enabled)//add
            {
                bool bSameID = false;
                int iNum = dataGridView1.Rows.Count;
                for (int i = 0; i < iNum; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == iCode.ToString())
                        {
                            bSameID = true;
                            break;
                        }
                    }
                }
                if (bSameID)
                {
                    MessageBox.Show("商品的编号不能重复，请重新设置", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Code.SelectAll();
                    textBox_Code.Focus();
                    return;
                }
                
                szTitle = "商品基本信息－新增";
                szSql = "INSERT INTO base_prod(PROD_ID,PROD_NAME,PROD_LEVEL,PROD_ORIGIN,PROD_RMRK,PARENT_ID) VALUES("
                    + iCode + ",'" + textBox_Name.Text.Trim() + "',1,'"
                    + textBox_Origin.Text.Trim() + "','" + textBox_Desc.Text.Trim()
                    + "'," + szType[0] + ")";
            }
            else//edit
            {
                szTitle = "商品基本信息－修改";
                szSql = "UPDATE base_prod SET PROD_NAME='" + textBox_Name.Text.Trim()
                    + "',PROD_RMRK = '" + textBox_Desc.Text.Trim()
                    + "',PROD_ORIGIN = '" + textBox_Origin.Text.Trim()
                    + "',PARENT_ID = " + szType[0]
                    + " WHERE PROD_ID=" + iCode;
            }
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
                    szSql = "编号" + mszCode + "-品名" + mszName;
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
                comboBox_Type.Text = mszType;
                textBox_Origin.Text = mszOrigin;
                textBox_Desc.Text = mszInf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MyStart.oMyDb.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_Code.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox_Type.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox_Origin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox_Desc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            mszCode = textBox_Code.Text;
            mszName = textBox_Name.Text;
            mszType = comboBox_Type.Text;
            mszOrigin = textBox_Origin.Text;
            mszInf = textBox_Desc.Text;
        }
    }
}