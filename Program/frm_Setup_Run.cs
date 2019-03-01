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
    public partial class frm_Setup_Run : Form
    {
        string mszTitle = "PSAM卡号,终端编码,终端名称,PSAM卡状态";
        string mszTitleWidth = "1,1,1,1";
        int miCols = 4;
        int miDefRows = 50;
        //int miPsamNum;
        DataTable mDt;
        string mszFName, mszFTitle;
        public frm_Setup_Run()
        {
            InitializeComponent();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Setup_Run_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Setup.ico"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Setup.ico"));
            button_Edit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Edit0.ico"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Save.ico"));
            button_Quit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Undo.ico"));
            //button_update.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            textBox_mrkt_mnger.Text = MyStart.gszMrktMnger;
            textBox_mrkt_name.Text = MyStart.gszMrktName;
            textBox_mrkt_addr.Text = MyStart.gszMrktAddr;
            textBox_mrkt_tel.Text = MyStart.gszMrktTel;

            textBox_Card_YTB.Text = MyStart.gszCardYtbFirst;
            textBox_Card_Firm.Text = MyStart.gszCardFirmFirst;
            //textBox_Pos_ID.Text = MyStart.gszPosID;
            textBox_Firm_ID.Text = MyStart.gszFirmID;
            textBox_FeeChgCard.Text = MyStart.giFeeChgCard.ToString("0.00");
            if (MyStart.gszWeight == "斤")
                radioButton_jin.Checked = true;
            else
                radioButton_kg.Checked = true;

            MyFunc.GridInit(ref dataGridViewTmn, mszTitle, mszTitleWidth, 15, miDefRows, true);
            DataSet ds = new DataSet();
            string szErr = "";
            string szSql = "select PSAM_NO as PSAM卡号,TMN_CODE as 终端编码,TMN_NAME as 终端名称,"
                + "if(PSAM_STAT='Y','有效','无效') as PSAM卡状态 from base_psam order by id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            DataTable dt = ds.Tables[0];
            mDt = dt;
            int iNum = dt.Rows.Count;
            if (iNum == 0)
            {
                MyStart.oMyDb.Close();
                return;
            }
            //miPsamNum = iNum;

            int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
            MyFunc.GridWriteDt(ref dataGridViewTmn, ref dt,0, miCols, ref iCurNum);

            szSql = "select sub_type from base_value where type=1";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    textBox_AddType.Text = "";
                    for (int i = 0; i < iNum; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        if (dr[0].ToString().Trim().Length == 0)
                            continue;
                        textBox_AddType.Text += dr[0].ToString() + "\r\n";
                    }
                }
            }

            szSql = "select sub_type from base_value where type=2";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                {
                    textBox_MinusType.Text = "";
                    for (int i = 0; i < iNum; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        if (dr[0].ToString().Trim().Length == 0)
                            continue;
                        textBox_MinusType.Text += dr[0].ToString() + "\r\n";
                    }
                }
            }
            groupBox_para.Enabled = false;
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;
            button_Exit.Select();
            MyStart.oMyDb.Close();
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            button_Edit.Enabled = false;
            button_Save.Enabled = true;
            button_Quit.Enabled = true;
            button_Exit.Enabled = true;

            groupBox_para.Enabled = true;
            textBox_mrkt_name.Select();
            //dataGridViewTmn.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewTmn.ReadOnly = false;
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;

            textBox_mrkt_name.Text = MyStart.gszMrktName;
            textBox_mrkt_addr.Text = MyStart.gszMrktAddr;
            textBox_mrkt_tel.Text = MyStart.gszMrktTel;

            textBox_Card_YTB.Text = MyStart.gszCardYtbFirst;
            textBox_Card_Firm.Text = MyStart.gszCardFirmFirst;
            textBox_FeeChgCard.Text = MyStart.giFeeChgCard.ToString("0.00");
            //textBox_Pos_ID.Text = MyStart.gszPosID;
            textBox_Firm_ID.Text = MyStart.gszFirmID;
            if (MyStart.gszWeight == "斤")
                radioButton_jin.Checked = true;
            else
                radioButton_kg.Checked = true;

            dataGridViewTmn.ReadOnly = true;
            dataGridViewTmn.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewTmn, mszTitle, mszTitleWidth, 15, miDefRows, true);
            int iNum = mDt.Rows.Count;
            int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
            MyFunc.GridWriteDt(ref dataGridViewTmn, ref mDt,0, miCols, ref iCurNum);

            groupBox_para.Enabled = false;
            button_Exit.Select();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string sIniFileName = Application.StartupPath + "\\SYS.ini";
            int sI = -1;
            string sErrorMessage = "";
            //string sTmp;

            MyStart.gszMrktMnger = textBox_mrkt_mnger.Text.Trim();
            MyStart.gszMrktName = textBox_mrkt_name.Text.Trim();
            MyStart.gszMrktAddr = textBox_mrkt_addr.Text.Trim();
            MyStart.gszMrktTel = textBox_mrkt_tel.Text.Trim();
            MyStart.gszFirmID =textBox_Firm_ID.Text.Trim();
            //MyStart.gszPosID = textBox_Pos_ID.Text.Trim();
            MyStart.gszCardFirmFirst = textBox_Card_Firm .Text.Trim();
            MyStart.gszCardYtbFirst = textBox_Card_YTB.Text.Trim();
            //MyStart.giFeeChgCard = Convert.ToInt16(Convert.ToDecimal(textBox_FeeChgCard.Text.Trim())*100)/100;
            if (textBox_FeeChgCard.Text.Trim().Length == 0)
                MyStart.giFeeChgCard = 0;
            else
                MyStart.giFeeChgCard = (int)(Convert.ToDecimal(textBox_FeeChgCard.Text.Trim()));
            string szWeight = "";
            if (radioButton_kg.Checked)
            {
                MyStart.gszWeight = "公斤";
                szWeight = "2";
            }
            if (radioButton_jin.Checked)
            {
                MyStart.gszWeight = "斤";
                szWeight = "1";
            }
            dataGridViewTmn.ReadOnly = true;

            string szErr = "";
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "MKT_GROUP", MyStart.gszMrktName, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存市场管理方" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "MKT_NAME", MyStart.gszMrktName, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存市场名称" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "MKT_ADDR", MyStart.gszMrktAddr, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存市场地址" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "MKT_TELE", MyStart.gszMrktTel, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存市场电话" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "FIRM_ID", MyStart.gszFirmID, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存供应商编码" + " 项时出错";
                goto Eend;
            }
            //sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "POS_ID", MyStart.gszPosID, ref szErr);
            //if (sI < 0)
            //{
            //    sErrorMessage = "保存终端代码" + " 项时出错";
            //    goto Eend;
            //}
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "CARD_FIRM", MyStart.gszCardFirmFirst, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存卖方卡第一位编码" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "CARD_YTB", MyStart.gszCardYtbFirst, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存买方卡第一位编码" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "WEIGHT_UNIT", szWeight, ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存计重单位" + " 项时出错";
                goto Eend;
            }
            sI = MyFunc.SetSysParaToDb(MyStart.oMyDb, "FEE_CHG_CARD", MyStart.giFeeChgCard.ToString(), ref szErr);
            if (sI < 0)
            {
                sErrorMessage = "保存换卡手续费" + " 项时出错";
                goto Eend;
            }

            int iRows = dataGridViewTmn.Rows.Count;
            int iNum = 0;
            string szSql = "";
            DataSet ds = new DataSet();
            int iRst = 0;
            try
            {
                szSql = "delete from base_value";
                szErr = "";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);

                string szX = textBox_MinusType.Text.Replace("\r\n", ",");
                string[] szItem = szX.Split(',');
                iNum = szItem.Length;
                szSql = "insert into base_value (type,sub_type) values ";
                for (int i = 0; i < iNum; i++)
                {
                    if (szItem[i].Trim().Length == 0)
                        continue;
                    szSql += "(2,'" + szItem[i] + "'),";
                }
                szX = textBox_AddType.Text.Replace("\r\n", ",");
                szItem = szX.Split(',');
                iNum = szItem.Length;
                for (int i = 0; i < iNum; i++)
                {
                    if (szItem[i].Trim().Length == 0)
                        continue;
                    szSql += "(1,'" + szItem[i] + "'),";
                }
                szSql = szSql.Substring(0, szSql.Length - 1);
                szErr = "";
                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);

                for (int i=0;i<iRows;i++)
                {
                    string szPsamID = dataGridViewTmn.Rows[i].Cells[0].Value.ToString().Trim();
                    string szPosID = dataGridViewTmn.Rows[i].Cells[1].Value.ToString().Trim();
                    string szPosName = dataGridViewTmn.Rows[i].Cells[2].Value.ToString().Trim();
                    string szPsamStat="N";
                    if (dataGridViewTmn.Rows[i].Cells[3].Value.ToString().Trim().CompareTo("有效") == 0)
                        szPsamStat = "Y";

                    szSql = "select * from base_psam where psam_no='" + szPsamID + "'";
                    //string szErr="";
                    iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                    if(iRst!=0)
                    {
                        sErrorMessage = "保存终端编码（查询失败）" + " 项时出错";
                        goto Eend;
                    }
                    iNum = ds.Tables[0].Rows.Count;
                    if (iNum == 0)//add
                        szSql = "INSERT INTO base_psam (TMN_CODE,TMN_NAME,PSAM_NO,PSAM_STAT) VALUES ('"
                            + szPosID + "','" + szPosName+"','"+szPsamID + "','" + szPsamStat + "')";
                    else//edit
                        szSql = "UPDATE base_psam SET TMN_CODE = '" + szPosID + "',TMN_NAME='" +szPosName +"',"
                            + "PSAM_STAT = '" + szPsamStat + "' WHERE PSAM_NO='" + szPsamID + "'";

                      iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                }                
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        Eend:
            button_Edit.Enabled = true;
            button_Save.Enabled = false;
            button_Quit.Enabled = false;
            button_Exit.Enabled = true;

            groupBox_para.Enabled = false;
            if (sI < 0)
            {
                MessageBox.Show("操作错误：" + sErrorMessage + "。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MyFunc.WriteToDbLog("修改运营参数", "", "MSG", MyStart.giUserID);
                //MessageBox.Show("Ini文件保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button_Exit.Select();
            MyStart.oMyDb.Close();
        }      
        
    }
}
