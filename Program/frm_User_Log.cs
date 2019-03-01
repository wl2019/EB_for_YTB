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
    public partial class frm_User_Log : Form
    {
        string mszTitle = "操作员,操作时间               ,操作类型                  ,操作明细                  ";
        string mszTitleWidth = "1,2,2,4";
        int miCols;
        int miDefRows = 15;
        DataTable mDt;
        string mszRptTitle="操作员日志报表";
        string mszRptDate;
        int miRows;
        public frm_User_Log()
        {
            InitializeComponent();
        }

        private void frm_User_Log_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report2.ico"));
            button_Qry.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.preview.ico"));
            button_Rpt.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.report.ico"));
            button_Exit.Image = Image.FromStream(frm_Main.oResource.GetManifestResourceStream(frm_Main.szProjName + ".Pict.exit01.ico"));

            dateTimePicker_Bgn.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker_End.Value = DateTime.Now;

            DataSet ds = new DataSet();
            string szErr = "";
            int iNum = 0;//商户
            string szSql = "select concat(user_id,'-',user_name) from sys_users where /*user_type=2 and*/ user_stat='USED' order by user_id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iNum = ds.Tables[0].Rows.Count;
                if (iNum > 0)
                    comboBox_User.Items.Add("0-所有人员");
                for (int i = 0; i < iNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    comboBox_User.Items.Add(dr[0].ToString());
                }
            }
            if (iNum > 0)
                comboBox_User.SelectedIndex = 0;

            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            string[] szX = mszTitle.Split(',');
            miCols = szX.Length;
            MyStart.oMyDb.Close();
        }

        private void button_Qry_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("查询工作日志", "", "MSG", MyStart.giUserID);
            string szBgn = string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value) + " 00:00:00";
            string szEnd = string.Format("{0:yyyy-MM-dd}", dateTimePicker_End.Value) + " 23:59:59";

            dataGridViewRst.Rows.Clear();
            MyFunc.GridInit(ref dataGridViewRst, mszTitle, mszTitleWidth, 15, miDefRows, true);
            try
            {
                DataSet ds = new DataSet();
                string szSql = "select user_name,rec_time,log_rmrk,log_info from sys_log a,sys_users b "
                    + "where a.LOG_USER = b.USER_ID and user_type>1 ";
                if (comboBox_User.SelectedIndex > 0)
                {
                    string[] szX = comboBox_User.Text.Split('-');
                    szSql += " and a.LOG_USER = " + szX[0];
                }
                szSql += " and rec_time>='" + szBgn + "' and rec_time<='" + szEnd + "' order by a.LOG_USER,rec_time desc";
                string szErr = "";
                int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
                if (iRst != 0)
                {
                    MessageBox.Show("查询失败！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog("查询操作日志", "SQL=" + szSql + ",Err=" + szErr);
                    goto Eend;
                }

                DataTable dt = ds.Tables[0];
                mDt = dt;
                int iNum = dt.Rows.Count;
                if (iNum == 0)
                {
                    MessageBox.Show("没有数据", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    goto Eend;
                }
                int iCurNum = (iNum < miDefRows ? miDefRows : iNum);
                MyFunc.GridWriteDt(ref dataGridViewRst, ref dt, 0, miCols, ref iCurNum);
                miRows = iNum;
                mszRptDate = string.Format("{0:yyyy-MM-dd}", dateTimePicker_Bgn.Value) + " 至 " + string.Format("{0:yyyy-MM-dd}", dateTimePicker_End.Value);
                button_Rpt.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询操作日志失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        Eend:
            MyStart.oMyDb.Close();
        }

        private void button_Rpt_Click(object sender, EventArgs e)
        {
            MyFunc.WriteToDbLog("生成工作日志报表", "", "MSG", MyStart.giUserID);

            string szErr = "";
            bool bRst = MyFunc.ExportDataToFile(mszRptTitle, mszRptDate,"", "A,C,D", mszTitle, ref dataGridViewRst, miRows, "", "E:\\", "工作日志报表" + DateTime.Now.ToString("yyyyMMdd"),
                ref szErr);
            if (bRst)
                MessageBox.Show("已生成报表", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("生成报表失败(" + szErr + ")", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            button_Rpt.Enabled = false;
        }
    }
}
