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
    public partial class frm_Setup_Key : Form
    {
        // 窗体上N个键的定义 
        const int iMaxKeyNum = 15;

        // 设计：键值L01--L(N-1) 对应的商品编号、商品名称，LN＝其它不用赋值
        //string[,] KeyToProc = new string[N, 2];            // [N,0] = 商品编号，[N,1] = 商品名称

        // 保存现在所有商品的信息：商品编号、商品名称
        Button[] oButton = new Button[iMaxKeyNum];
        string[] ArrayProcID=new string[iMaxKeyNum];                                // 所有商品的编号信息
        string[] ArrayProcName = new string[iMaxKeyNum];                            // 所有商品的名称
        int iProdNum = 0;

        public frm_Setup_Key()
        {
            InitializeComponent();

            // 1、从数据库读出所有的商品名称的信息, 然后把它们逐一放到 ArrayProcID、ArrayProcName中
            string szSql = "select prod_id,prod_name from base_prod where PROD_LEVEL=1 order by prod_id";
            DataSet ds = new DataSet();
            string szErr = "";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyIniFile.WriteLog("定义快捷键－读出所有的商品名称的信息", "SQL=" + szSql + ",Err=" + szErr);
                MessageBox.Show("查询商品名称时出错，操作失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = false;
                return;
            }

            DataTable dt = ds.Tables[0];
            iProdNum = dt.Rows.Count;
            if (iProdNum == 0)
            {
                MyIniFile.WriteLog("定义快捷键－读出所有的商品名称的信息", "SQL=" + szSql + ",Err=没有商品明细");
                MessageBox.Show("没有查询到商品名称，请先设置商品信息！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = false;
                return;
            }

            // 读数据库
            //ArrayProcID = new string[iProdNum];
            //ArrayProcName = new string[iProdNum];
            for(int i=0;i< iProdNum; i++)
            {
                DataRow dr = dt.Rows[i];
                comboBox_ProdList.Items.Add(dr[0].ToString()+"-"+dr[1].ToString());
            }
            //ArrayProcID[0] = "10001"; ArrayProcName[0] = "三文鱼";
            //ArrayProcID[1] = "10002"; ArrayProcName[1] = "石斑鱼";
            //ArrayProcID[2] = "20001"; ArrayProcName[2] = "马哈鱼";
            //ArrayProcID[3] = "20002"; ArrayProcName[3] = "芒鱼";
            //ArrayProcID[4] = "30001"; ArrayProcName[4] = "象拔蚌";
            //ArrayProcID[5] = "30002"; ArrayProcName[5] = "花甲";
            //ArrayProcID[6] = "40001"; ArrayProcName[6] = "鲩鱼";


            // 2、把所有的商品名称放到comboBox_ProdList 中
            //if (ArrayProcID.Length > 0)
            //{
            //    for (int i = 0; i < iProdNum; i++)
            //    {
            //    }
            //}

            // 3、读出现在各键的定义
            //cmd = new MySqlCommand();                                 //定义OleDbCommand对象cmd
            //cmd.Connection = DBConnection;
            //cmd.CommandType = System.Data.CommandType.Text;           //指定SqlCommand类型
            //cmd.CommandText = "select KEY_ID, KEY_NAME, A.PROD_ID, PROD_NAME from base_keys AS A, base_prod AS B WHERE KEY_TYPE = 2 AND A.FUNC_NAME = B.PROD_ID AND PROD_LEVEL = 1 AND USER_ID = 0 GROUP BY KEY_ID";

            //myRead = cmd.ExecuteReader();
            //while (myRead.Read())
            //{
            //    sTemp = myRead.GetString("KEY_NAME");
            //    if (sTemp.Substring(0, 1) == "L")
            //    {
            //        try
            //        {
            //            i = int.Parse(sTemp.Substring(1, 2));
            //            KeyToProc[i - 1,0] = myRead.GetInt32("PROD_NAME").ToString();
            //            KeyToProc[i - 1,1] = myRead.GetString("PROD_NAME");
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
            //myRead.Close();
            //bResult = true;
            szSql= "select KEY_NAME, PROD_ID, PROD_NAME from base_keys a, base_prod b WHERE KEY_TYPE = 2 AND a.FUNC_NAME = b.PROD_ID AND PROD_LEVEL = 1 order by key_name";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst != 0)
            {
                MyIniFile.WriteLog("定义快捷键－读出所有的商品快捷键的信息", "SQL=" + szSql + ",Err=" + szErr);
                MessageBox.Show("查询快捷键信息错误，操作失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = false;
                return;
            }

            dt = ds.Tables[0];
            int iNum = dt.Rows.Count;
            if (iNum == 0)
            {
                MyIniFile.WriteLog("定义快捷键－读出所有的商品快捷键的信息", "SQL=" + szSql + ",Err=没有快捷键信息");
                MessageBox.Show("没有查询到快捷键信息！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //groupBox2.Enabled = false;
                return;
            }
            for (int i = 0; i < iNum; i++)
            {
                DataRow dr = dt.Rows[i];
                string szX = dr[0].ToString();
                int KeyIndex = Convert.ToInt16(szX.Substring(1, szX.Length - 1));
                ArrayProcID[i] = dr[1].ToString();
                ArrayProcName[i] = dr[2].ToString();
                //KeyToProc[KeyIndex-1, 0] = dr[1].ToString();
                //KeyToProc[KeyIndex - 1, 1] = dr[2].ToString();
            }
            /*
            KeyToProc[0, 0] = "10001";
            KeyToProc[0, 1] = "三文鱼";

            KeyToProc[1, 0] = "10002";
            KeyToProc[1, 1] = "石斑鱼";
            */
        }

        private void frm_Def_Key_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.KEYS01.ICO"));
            pictureBox1.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.KEYS01.ICO"));
            button_Save.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Save.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));
            button_Define.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.Yes.ico"));
            
            DefButton();
            SetButton(0);
            if(comboBox_ProdList.Items.Count>0)
                comboBox_ProdList.SelectedIndex = 0;
        }

        private void DefButton()
        {
            oButton[0] = button_01;
            oButton[1] = button_02;
            oButton[2] = button_03;
            oButton[3] = button_04;
            oButton[4] = button_05;
            oButton[5] = button_06;
            oButton[6] = button_07;
            oButton[7] = button_08;
            oButton[8] = button_09;
            oButton[9] = button_10;

            oButton[10] = button_11;
            oButton[11] = button_12;
            oButton[12] = button_13;
            oButton[13] = button_14;
            oButton[14] = button_15;
        }

        private void SetButton(int KeyNum)
        {
            for (int i = 0; i < iMaxKeyNum; i++)
            {
                if (i == KeyNum)
                {
                    oButton[i].BackColor = Color.CornflowerBlue;
                    //oButton[i].Focus();
                    label_KeyName.Text = "L" + (i+1).ToString("00");
                    label_ProdName.Text = ArrayProcName[i]; //KeyToProc[i, 1];
                }
                else
                    oButton[i].BackColor = System.Drawing.SystemColors.Control; 
            }
        }

        private void button_20_Click(object sender, EventArgs e)
        {
            string sTmp = (sender.ToString());
            int i = int.Parse(sTmp.Substring(sTmp.Length - 2, 2)) - 1;
            sTmp = sTmp.Substring(sTmp.Length - 3, 3);
            SetButton(i);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Define_Click(object sender, EventArgs e)
        {/*
            string sTmp = label_KeyName.Text.Substring(1, 2);
            int i = int.Parse(sTmp.Substring(sTmp.Length - 2, 2)) - 1;

            if(i>iProdNum)
            {
                MessageBox.Show("定义失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            KeyToProc[i, 0] = ArrayProcID[i];
            KeyToProc[i, 1] = ArrayProcName[i];
            label_ProdName.Text = ArrayProcName[i];*/
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            string szKeyName = label_KeyName.Text.Trim();// .Substring(1, 2);
            int iKeyName = Convert.ToInt16(szKeyName.Substring(1));
            string[] szX = comboBox_ProdList.Text.Split('-');

            string szSql = "select * from base_keys where func_name='"+szX[0]+"' and key_name <> '" + szKeyName + "'";
            try
            {
                DataSet ds = new DataSet();
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MyIniFile.WriteLog("定义快捷键－查找商品快捷键的信息", "SQL=" + szSql + ",Err=" + szErr);
                    MessageBox.Show("查询商品快捷键信息失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MyIniFile.WriteLog("定义快捷键－查找商品快捷键的信息", "SQL=" + szSql + ",Err=已定义该商品的快捷键");
                    if (DialogResult.No == MessageBox.Show("已定义了该商品的快捷键，是否重复定义？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        goto Eend;
                }
                if (label_ProdName.Text.Length == 0)//new, need insert
                    szSql = "INSERT INTO base_keys(USER_ID,KEY_NAME,KEY_TYPE,FUNC_NAME) VALUES (0,'" + szKeyName + "',2,'" + szX[0] + "')";
                else//old,need update
                    szSql = "UPDATE base_keys SET FUNC_NAME = '" + szX[0] + "' WHERE KEY_NAME = '" + szKeyName + "'";

                iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
                if (iRst < 1)
                {
                    MyIniFile.WriteLog("定义快捷键－保存商品快捷键的信息", "SQL=" + szSql + ",Err=" + szErr);
                    MessageBox.Show("保存商品快捷键失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                MessageBox.Show("保存商品快捷键成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ArrayProcID[iKeyName - 1] = szX[0];
                ArrayProcName[iKeyName - 1] = szX[1];
                label_ProdName.Text = szX[1];
                SetButton(iKeyName - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存商品快捷键失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }
    }
}
