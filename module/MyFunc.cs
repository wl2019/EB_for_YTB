using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;//for DataSet
using System.Windows.Forms;//for disp
using System.IO;//for file
using Microsoft.Office.Interop.Word;//need add refrence:Microsoft Word X.X object library
using Microsoft.Office.Interop.Excel;//need add refrence:Microsoft xlApp X.X object library (9.0=xlApp2000, 10.0=2002, 11.0=2003, 
using System.Runtime.InteropServices;//for define dll
//using System.Windows.Forms;

namespace YTB
{
    class MyFunc
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public const int MY_ERR = -10000;
        public const int MY_ERR_PARA = MY_ERR - 1;

        public static int GetSysParaFromIni(string sIniFileName)
        {
            string str = "";
            short sI;
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Sys", "Login", ref MyStart.gszSysLogin);
            if (sI < 0) MyStart.gszSysLogin = "123";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Sys", "Code", ref MyStart.gszSysCode);
            if (sI < 0) MyStart.gszSysCode = "37601008";
            
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Sys", "Pwd", ref str);
            if (sI < 0)
            {
                MyStart.gszSysPwd = "1234567890";
            }
            else
            {
                if (str.Length == 16 && MyTools.StringIsHex(str))
                {
                    MyStart.gszSysPwd = MyTools.HideString_To_OpenString(str, MyIniFile.mszIniKey);
                    MyStart.gszSysPwd = MyStart.gszSysPwd.Trim();
                }
                else
                    MyStart.gszSysPwd = "1234567890";
            }

            // DB
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "IP", ref MyStart.gszDbIp);
            if (sI < 0) MyStart.gszDbIp = "rm-wz9767aj327o0ai0ro.mysql.rds.aliyuncs.com";
            //MyStart.gszDbIp = "183.58.24.209";//生产IP
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Port", ref MyStart.gszDbPort);
            if (sI < 0) MyStart.gszDbPort = "3306";
            //MyStart.gszDbPort = "8878";//生产端口
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Srv", ref MyStart.gszDbSrv);
            if (sI < 0) MyStart.gszDbSrv = "zsmkt";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Login", ref MyStart.gszDbLogin);
            if (sI < 0) MyStart.gszDbLogin = "root";
            /*sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Pwd", ref str);
            if (sI < 0)
            {
                MyStart.gszDbPwd = "Ztb_1324";// ThisSqlAly02&&";
            }
            else
            {
                if (str.Length == 16 && MyTools.StringIsHex(str))
                {
                    MyStart.gszDbPwd = MyTools.HideString_To_OpenString(str, MyIniFile.mszIniKey);
                    MyStart.gszDbPwd = MyStart.gszDbPwd.Trim();
                }
                else
                    MyStart.gszDbPwd = "Ztb_1324";//ThisSqlAly02&&";
            }*/
            if(MyStart.gszDbIp == "139.159.212.93")
                MyStart.gszDbPwd = "4077232";
            else
                MyStart.gszDbPwd = "Ztb_1324";
            return 0;
        }
        public static int GetSysParaFromDb(CDb oDb, ref string szErr)
        {
            int iRst;
            string szSql = "select para_val,para_name from sys_para";
            DataSet odt = new DataSet();

            iRst = oDb.ReadData(szSql, "TableA", ref odt, ref szErr);
            if (iRst != 0)
                return CDb.ERR_READ;

            int iNum = odt.Tables[0].Rows.Count;
            for (int i = 0; i < iNum; i++)
            {
                DataRow dr = odt.Tables[0].Rows[i];
                string szItem = dr[1].ToString();
                switch (szItem)
                {
                    case "YTB_SRV": MyStart.gszYTBIp = dr[0].ToString(); break;
                    case "YTB_PORT": MyStart.gszYTBPort = dr[0].ToString(); break;
                    case "RDR_PORT": MyStart.gszRdrPort = dr[0].ToString(); break;
                    case "RDR2_PORT": MyStart.gszRdr2Port = dr[0].ToString(); break;
                    case "RDR_BAUD": MyStart.gszRdrBaud = dr[0].ToString(); break;
                    case "PS_PORT": MyStart.gszPsPort = dr[0].ToString(); break;
                    case "PS_BAUD": MyStart.gszPsBaud = dr[0].ToString(); break;
                    case "CARD_YTB": MyStart.gszCardYtbFirst = dr[0].ToString(); break;
                    case "CARD_FIRM": MyStart.gszCardFirmFirst = dr[0].ToString(); break;
                    case "FIRM_ID": MyStart.gszFirmID = dr[0].ToString(); break;
                    case "POS_ID": MyStart.gszPosID = dr[0].ToString(); break;                        
                    case "MKT_GROUP": MyStart.gszMrktMnger = dr[0].ToString(); break;
                    case "MKT_NAME": MyStart.gszMrktName = dr[0].ToString(); break;
                    case "MKT_ADDR": MyStart.gszMrktAddr = dr[0].ToString(); break;
                    case "MKT_TELE": MyStart.gszMrktTel = dr[0].ToString(); break;
                    case "WEIGHT_UNIT": MyStart.gszWeight = (dr[0].ToString()=="1"?"斤":"公斤"); break;
                    case "FEE_CHG_CARD": MyStart.giFeeChgCard = Convert.ToInt16(dr[0]); break;
                    default: break;//return MY_ERR_PARA;
                }
            }
            return 0;
        }

        public static int SetSysParaToDb(CDb oDb, string szItem, string szVal, ref string szErr)
        {
            string szSql = "update sys_para set para_val='" + szVal.Trim()
                + "' where para_name='" + szItem.Trim() + "'";
            return oDb.WriteData(szSql, ref szErr);
        }

        public static void GridInit(ref DataGridView oGrid, string szHeaderTitle, string szColWidth, int iRowHeaderWidth, int iMinSpaceRows, bool bHasVBar)
        {
            string[] szTitle = szHeaderTitle.Split(',');
            string[] szWidth = szColWidth.Split(',');
            if (szTitle.Length != szWidth.Length)
                return;

            int ivBarWidth = 2;
            if (bHasVBar)
                ivBarWidth = 20;

            int iCols = szTitle.Length;
            int[] iWidth = new int[iCols];
            int iMaxColWidth = 0;
            for (int index = 0; index < iCols; index++)
            {
                iWidth[index] = Convert.ToInt32(szWidth[index]);
                iMaxColWidth += iWidth[index];
            }

            oGrid.RowHeadersWidth = iRowHeaderWidth;
            oGrid.ColumnCount = iCols;
            for (int index = 0; index < iCols; index++)
            {
                oGrid.Columns[index].HeaderText = szTitle[index];
                oGrid.Columns[index].Width = (oGrid.Width - iRowHeaderWidth - ivBarWidth) * iWidth[index] / iMaxColWidth;
            }
            oGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oGrid.RowCount = iMinSpaceRows;
        }

        public static void GridWriteData(ref DataGridView oGrid, string szText, ref int iCurNum)
        {
            //oGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            string[] szItem = szText.Split('#');
            int iCols = szItem.Length;

            if (iCurNum >= oGrid.RowCount)
                oGrid.RowCount++;

            for (int index = 0; index < iCols; index++)
                oGrid.Rows[iCurNum].Cells[index].Value = szItem[index];//- .SetValues(szCurSysName, "-", MyStart.sErrMsg);

            iCurNum++;
        }
        public static void GridWriteDt(ref DataGridView oGrid, ref System.Data.DataTable dt,
            int iBgnRow, int iCols, ref int iCurNum)
        {
            //oGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            int iRowNum = dt.Rows.Count;
            if (iRowNum == 0)
                return;
            //int iOff = iRowNum + iBgnRow - oGrid.RowCount;
            //if (iOff > 0)
            //    oGrid.RowCount += iOff;
            if (iRowNum + iBgnRow > oGrid.RowCount)
                oGrid.RowCount += iRowNum;

            for (int i = 0; i < iRowNum; i++)
            {
                //if (iCurNum >= oGrid.RowCount)
                //    oGrid.RowCount++;

                DataRow dr = dt.Rows[i];
                for (int index = 0; index < iCols; index++)
                    oGrid.Rows[i + iBgnRow].Cells[index].Value = dr[index].ToString();
                iCurNum++;
            }
        }

        public static void DispStall(ComboBox objFirm, ComboBox objStall,bool bDispAll)
        {
            int iStallNum = 0;
            DataSet ds = new DataSet();
            string szErr = "";
            string[] szFirmInf = objFirm.Text.Split('-');
            string szSql = "select concat(stall_id,'-',stall_inf),STALL_PERSON,STALL_TEL from base_stall where STALL_STAT='USED' ";
            if (Convert.ToInt16(szFirmInf[0]) > 0)
                szSql += " and store_id=" + szFirmInf[0];
            szSql += " order by stall_id";
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst == 0)
            {
                iStallNum = ds.Tables[0].Rows.Count;
                if (iStallNum > 0)
                    objStall.Items.Clear();

                if (bDispAll)// & szFirmInf[0] == "0")
                    objStall.Items.Add("0-所有档口");
                
                for (int i = 0; i < iStallNum; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    objStall.Items.Add(dr[0].ToString());
                }
            }
            if (iStallNum > 0)
            {
                objStall.Enabled = true;
                objStall.SelectedIndex = 0;
            }
            else
                objStall.Enabled = false;
        }

        public static void WriteToDbLog(string szTitle, string szInf, string szType, int iUserID)
        {
            try
            {
                string szLogSql = "INSERT INTO sys_log (LOG_RMRK,LOG_INFO,REC_TIME,LOG_LEVEL,LOG_USER) VALUES (";
                string szErr = "";
                int iRst;
                if (szInf.Length > 0)
                    szLogSql += "'" + szTitle + "','" + szInf + "',curtime(),'" + szType + "'," + iUserID + ")";
                else
                    szLogSql += "'" + szTitle + "','',curtime(),'" + szType + "'," + iUserID + ")";

                iRst = MyStart.oMyDb.WriteData(szLogSql, ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("写日志出错（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyIniFile.WriteLog(szTitle, "SQL=" + szLogSql + ",Err=" + szErr);
                    //return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("解挂卡片失败( " + ex.Message + " )", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string sz = ex.Message;
            }
            MyStart.oMyDb.Close();
        }

        public static bool ExportDataToFile(string szTitle, string szDate,string szUnit, string szRange, string szColName, 
            ref DataGridView oGrid, int iRows, string szSum, string szSavePath,string szFileName, ref string szErr)
        {//save as excel
            //没有数据的话就不往下执行  
            if (iRows == 0)
                return false;

            bool bRst = false;
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.Title = "另存为";
            sDlg.InitialDirectory = szSavePath;
            sDlg.RestoreDirectory = true;
            //sDlg.Filter = "EXECL文件(*.csv) |*.csv |所有文件(*.*) |*.*";
            sDlg.Filter = "EXECL文件(*.xlsx) |*.xlsx |所有文件(*.*) |*.*";
            sDlg.FilterIndex = 0;
            sDlg.FileName = szFileName;

            if (sDlg.ShowDialog() == DialogResult.OK)
                //bRst = GridExpCVS(szTitle,ref dt, sDlg.FileName,ref szErr);
                bRst = GridExpExcelNoFormat(szTitle,szDate,szUnit, szRange,szColName, ref oGrid, iRows, szSum, sDlg.FileName, ref szErr);

            if (bRst)
                szErr = sDlg.FileName;
            return bRst;
        }
        /*public static bool ExportDataToFile2(string szTemplate, string szDstFile, string szTitle, string szDate, string szUser,
            ref DataGridView oGrid, int iRows, string szSum, string szSavePath, string szFileName, ref string szErr)
        {//save as word
            if (iRows == 0)
                return false;

            bool bRst = false;
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.Title = "另存为";
            sDlg.InitialDirectory = szSavePath;
            sDlg.RestoreDirectory = true;
            //sDlg.Filter = "EXECL文件(*.csv) |*.csv |所有文件(*.*) |*.*";
            sDlg.Filter = "EXECL文件(*.xlsx) |*.xlsx |所有文件(*.*) |*.*";
            sDlg.FilterIndex = 0;
            sDlg.FileName = szFileName;

            if (sDlg.ShowDialog() == DialogResult.OK)
                bRst = GridExpWordNoFormat(szTemplate, szDstFile,szTitle+","+szDate + ",操作员：" + szUser + ",打印日期：" + DateTime.Now.ToString("yyyy.MM.dd"), ref szErr);

            return bRst;
        }*/
        /*private static bool GridExpCVS(string szTitle, ref DataGridView oGrid, int iRows, string szDstFile, ref string szErr)
        {
            bool bRst = true;
            FileStream myStream = new FileStream(szDstFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str;
            try
            {
                //title
                sw.WriteLine(szTitle);
                //detail
                for (int j = 0; j < iRows; j++)
                {
                    DataRow dr = dt.Rows[j];
                    str = dr[0].ToString();
                    for (int k = 1; k < dt.Columns.Count; k++)
                    {
                        str += ",";
                        str += dr[k].ToString();
                    }
                    sw.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                szErr = ex.Message;
                bRst = false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
            return bRst;
        }*/
        /*private static bool GridExpWordNoFormat(string szTemplate,string szDstFile,string szBookMarks, ref string szErr)
        {
            bool bRst = false;
            //将内容输出到word文档中
            object oMissing = System.Reflection.Missing.Value;
            //创建一个Word应用程序实例
            Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
            //设置为不可见
            oWord.Visible = false;
            //模板文件地址，这里假设在X盘根目录
            object oTemplateFile = szTemplate;

            //2007 版本 以模板为基础生成文档
            Microsoft.Office.Interop.Word.Document oDoc = oWord.Documents.Add(ref oTemplateFile, ref oMissing, ref oMissing, ref oMissing);

            //设置表头表尾
            string[] szMarkItem = szBookMarks.Split(',');
            int iMarkNum = szMarkItem.Length;
            object[] oBookMark = new object[iMarkNum];
            ////赋值书签名
            //oBookMark[0] = "beizhu";
            //oBookMark[1] = "name";
            //oBookMark[2] = "sex";
            //oBookMark[3] = "birthday";
            //oBookMark[4] = "hometown";

            //赋值任意数据到书签的位置
            //oDoc.Bookmarks.get_Item(ref oBookMark[0]).Range.Text="使用模板实现Word生成";
            //oDoc.Bookmarks.get_Item(ref oBookMark[1]).Range.Text = "李四";
            //oDoc.Bookmarks.get_Item(ref oBookMark[2]).Range.Text = "女";
            //oDoc.Bookmarks.get_Item(ref oBookMark[3]).Range.Text = "1987.06.07";
            //oDoc.Bookmarks.get_Item(ref oBookMark[4]).Range.Text = "贺州";
            for (int index = 0; index < iMarkNum; index++)
                oDoc.Bookmarks.get_Item(ref oBookMark[index]).Range.Text = szMarkItem[index];

            // 弹出保存文件对话框，保存生成的Word
            object oFName = szDstFile;
            oDoc.SaveAs(ref oFName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing
                , ref oMissing, ref oMissing, ref oMissing);
            oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            //关闭word
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);

            return bRst;
        }*/
        private static bool GridExpExcelNoFormat(string szTitle,string szDate, string szUnit, string szRange,string szColName,
            ref DataGridView oGrid, int iRows, string szSum, string szDstFile, ref string szErr)
        {
            string[] szItem = szColName.Split(',');
            string[] szMerge=szRange.Split(',');
            int iColNum = szItem.Length;
            int iRowNum = iRows;
            int iRowOff = 0;
            bool bRst = false;
            //实例化一个xlApp.Application对象                  
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlBook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            Microsoft.Office.Interop.Excel.Range xlRange;
            try
            {
                //让后台执行设置为不可见，为true的话会看到打开一个xlApp，然后数据在往里写  
                xlApp.Visible = false;
                //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错  
                //xlApp.Application.Workbooks.Add(true);
                xlBook=xlApp.Workbooks.Add(true);
                xlSheet = xlBook.Sheets[1];//第1个SHEET detail
                //xlSheet.Columns.EntireColumn.AutoFit();//列宽自适应
                xlSheet.PageSetup.PrintGridlines = true;//打印时有网格线
                xlSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;//
                System.Windows.Forms.Application.DoEvents();

                //xlSheet = xlApp.ActiveSheet;
                //生成xlApp标题  
                xlApp.Cells[1, 1] = szTitle;
                iRowOff++;
                ////合并横着的单元格
                //xlRange.Areas = 
                xlRange = xlSheet.Range[szMerge[0]+"1",szMerge[2]+"1"];//获取需要合并的单元格的范围
                xlRange.Application.DisplayAlerts = false;
                xlRange.Merge(xlRange.MergeCells);
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlRange.Font.Size = 15;
                xlRange.Application.DisplayAlerts = true;

                //生成xlApp日期
                xlApp.Cells[ iRowOff + 1,1] = szDate;
                iRowOff++;
                xlRange = xlSheet.Range[szMerge[0] + "2", szMerge[2] + "2"];//获取需要合并的单元格的范围
                xlRange.Application.DisplayAlerts = false;
                xlRange.Merge(xlRange.MergeCells);
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlRange.Application.DisplayAlerts = true;

                //生成xlApp表格计量单位
                xlApp.Cells[iRowOff + 1, 1] = szUnit;
                iRowOff++;
                xlRange = xlSheet.Range[szMerge[0] + "3", szMerge[2] + "3"];//获取需要合并的单元格的范围
                xlRange.Application.DisplayAlerts = false;
                xlRange.Merge(xlRange.MergeCells);
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                xlRange.Application.DisplayAlerts = true;

                //生成xlApp中列头名称  
                for (int i = 0; i < iColNum; i++)
                    xlApp.Cells[1 + iRowOff, i + 1] = szItem[i];
                xlRange = xlSheet.Range[szMerge[0] + "4", szMerge[2] + "4"];//获取需要自动调整列宽的单元格的范围
                xlRange.EntireColumn.AutoFit();

                //把DataGridView当前页的数据保存在xlApp中,全部以字符串方式写入
                for (int i = 0; i < iRowNum; i++)
                {
                    //DataRow dr = dt.Rows[i];
                    for (int j = 0; j < iColNum; j++)
                    {
                        if (oGrid.Rows[i].Cells[j].Value is null)
                            continue;
                        string szX= oGrid.Rows[i ].Cells[j].Value.ToString();
                        xlApp.Cells[i + iRowOff + 2, j + 1] = "'" + szX;// oGrid.Rows[i + 1].Cells[j + 1].Value.ToString();//dr[j].ToString();
                    }
                }
                //szItem = szSum.Split('|');
                //if(szItem.Length==(iColNum+1))
                //{
                //    for (int i = 0; i < iColNum; i++)
                //        xlApp.Cells[1 + iRowOff+iRowNum, i + 1] = szItem[i];
                //}

                //oper & print date  --  add by lily 2017.12.04
                iRowOff += iRowNum+2;
                xlApp.Cells[iRowOff + 1, 1] = "操作员：" + MyStart.gszUsername;
                //xlRange = xlSheet.Range[szMerge[0] + (iRowOff + 1).ToString(),
                //    szMerge[1] + (iRowOff + 1).ToString()];//获取需要合并的单元格的范围
                //xlRange.Application.DisplayAlerts = false;
                //xlRange.Merge(xlRange.MergeCells);
                ////xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //xlRange.Application.DisplayAlerts = true;

                xlApp.Cells[iRowOff + 1, iColNum-1] = "打印日期："+ DateTime.Now.ToString("yyyy.MM.dd");
                xlRange = xlSheet.Range[szMerge[1] + (iRowOff + 1).ToString(), 
                    szMerge[2] + (iRowOff + 1).ToString()];//获取需要合并的单元格的范围
                xlRange.Application.DisplayAlerts = false;
                xlRange.Merge(xlRange.MergeCells);
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                xlRange.Application.DisplayAlerts = true;
                
                //设置禁止弹出保存和覆盖的询问提示框  
                xlApp.DisplayAlerts = false;
                xlApp.AlertBeforeOverwriting = false;

                //保存工作簿  
                //xlApp.Application.Workbooks.Add(true).Save();
                //xlApp.Workbooks.Add(true).Save();
                //保存xlApp文件  
                //xlApp.Save(szDstFile);
                xlApp.ActiveWorkbook.SaveAs(szDstFile);

                //确保xlApp进程关闭  
                xlApp.Quit();
                bRst = true;
            }
            catch (Exception ex)
            {
                szErr = ex.ToString();
            }
            finally
            {
                IntPtr t = new IntPtr(xlApp.Hwnd);
                xlApp = null;
                GC.Collect();
                int k = 0;
                GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
                p.Kill();     //关闭进程k
            }
            return bRst;
        }

        public static void PrintExcelFile(string filePath,ref string szErr)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            try
            { 
                xlApp.Visible = true;
                object oMissing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, 0, true, 5, oMissing, oMissing, true, 1, oMissing, false, false, oMissing, false, oMissing, oMissing);
                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets[1];
                //xlWorksheet.PrintPreview(null);
                //xlWorksheet.PrintPreview(true);
                //xlApp.Visible = false;
                //xlWorksheet = null;
                xlWorksheet.PrintOut(1, 1, 2, true);//.PrintOutEx()
            }
            catch (Exception ex)
            {
                szErr = ex.ToString();
            }
            finally
            {
                IntPtr t = new IntPtr(xlApp.Hwnd);
                xlApp = null;
                GC.Collect();
                int k = 0;
                GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
                p.Kill();     //关闭进程k
            }
        }
        /*public static int GetDataFromExcel(string szFName, string szTitle,
            ref System.Data.DataTable dt, ref string szErr)
        {//return rows
            //szType=System.Int32/System.String
            string[] szItem = szTitle.Split(',');
            //string[] szItemType=szType.Split(',');
            int iRowNum = 0;
            int iColNum = szItem.Length;
            int iReturn = 0;
            //if(iColNum!=szItemType.Length)
            //{
            //    szErr = "输入参数错误";
            //    return 0;
            //}
            //实例化一个xlApp.Application对象                  
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlBook;
            Microsoft.Office.Interop.Excel.Worksheet xlSheet;
            object missing = System.Reflection.Missing.Value;

            //Microsoft.Office.Interop.Excel.Range xlRange;
            try
            {
                //让后台执行设置为不可见，为true的话会看到打开一个xlApp，然后数据在往里写  
                xlApp.Visible = false;
                // 以只读的形式打开EXCEL文件
                xlBook = xlApp.Application.Workbooks.Open(szFName, missing, true, missing, missing, missing,
                    missing, missing, missing, true, missing, missing, missing, missing, missing);
                //取得第一个工作薄
                xlSheet = xlBook.Sheets[1];//第1个SHEET detail

                //取得总记录行数   (包括标题列)
                iRowNum = xlSheet.UsedRange.Cells.Rows.Count; //得到行数
                //iColNum = xlSheet.UsedRange.Cells.Columns.Count;//得到列数

                ////取得数据范围区域 (不包括标题列) 
                //Range rng1 = xlSheet.Cells.get_Range("B2", "B" + rowsint);   //item


                //Range rng2 = ws.Cells.get_Range("K2", "K" + rowsint); //Customer
                //object[,] arryItem = (object[,])rng1.Value2;   //get range's value
                //object[,] arryCus = (object[,])rng2.Value2;
                ////将新值赋给一个数组
                //string[,] arry = new string[rowsint - 1, 2];
                for (int i = 2; i <= iRowNum - 1; i++)
                {
                    //dt.Rows.Add(new object[])
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= iColNum; j++)
                    {
                        string szX = xlApp.Cells[i, j].Value2;
                        dr[szItem[j - 1]] = szX;// xlApp.Cells[i, j].Value2;
                    }
                    dt.Rows.Add(dr);
                }

                //确保xlApp进程关闭  
                xlApp.Quit();
                iReturn = iRowNum - 1;
            }
            catch (Exception ex)
            {
                szErr = ex.ToString();
            }
            finally
            {
                //xlSheet = null;
                //xlBook = null;
                IntPtr t = new IntPtr(xlApp.Hwnd);
                xlApp = null;
                GC.Collect();
                int k = 0;
                GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
                p.Kill();     //关闭进程k
                //Process[] procs = Process.GetProcessesByName("excel");
                //  foreach (Process pro in procs)
                //      pro.Kill();//没有更好的方法,只有杀掉进程
                //  GC.Collect();
            }
            return iReturn;
        }*/
        public static int GetDataFromTxt(string szFName, string szTitle,
            ref System.Data.DataTable dt, ref string szErr)
        {//return rows
            string[] szItem = szTitle.Split(',');
            int iColNum = szItem.Length;
            int iReturn = 0;
            try
            {
                FileStream fs = new FileStream(szFName, FileMode.Open, FileAccess.Read, FileShare.None);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
                string szX = "";
                //string s = Console.ReadLine();
                while (szX != null)
                {
                    szX = sr.ReadLine();
                    string[] szItemX = szX.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < iColNum; j++)
                        dr[szItem[j]] = szItemX[j];
                    dt.Rows.Add(dr);
                    iReturn++;
                }                
                sr.Close();
            }
            catch (Exception ex)
            {
                szErr = ex.ToString();
            }
            return iReturn;
        }
        public static void GetApp(string szApp, ref bool[,] bApp)
        {
            if (szApp.Length == 0)
                return;

            int iLen = szApp.Length;
            int iAppMainDone = 0;
            int iAppSubDone = 0;
            int iMaxDone = frm_Main.iMenu[iAppMainDone];
            //bool[,] bApp = new bool[frm_Main.iMainMenuNum, frm_Main.iSubMenuMaxNum];
            for (int i = 0; i < iLen; i++)
            {
                if (iAppSubDone < iMaxDone)
                {
                    iAppSubDone++;
                }
                else
                {
                    iAppMainDone++;
                    iAppSubDone = 1;
                    iMaxDone = frm_Main.iMenu[iAppMainDone];
                }

                string szItem = szApp.Substring(i, 1);
                bool bItem = (szItem == "1") ? true : false;
                bApp[iAppMainDone, iAppSubDone - 1] = bItem;
            }//end for
        }

        

        public static void GetNetInf(ref string szErr)
        {
            string szSql = "select ID, net_key,teller_no,CONCAT(net_name,'_',psam_no),tel,flag from base_net where psam_no='" + MyStart.gszSysCode.Trim() + "'";
            szErr = "";
            DataSet ds = new DataSet();
            int iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                //MessageBox.Show("读取网点信息失败，请重新操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                szErr = "读取网点信息失败，请重新操作";
                return;
            }

            int iNum = ds.Tables[0].Rows.Count;
            if (iNum < 1)
            {
                //MessageBox.Show("读取网点信息错误，请检查是否有该网点信息", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                szErr = "读取网点信息错误，请检查是否有该网点信息";
                return;
            }
            if (iNum > 1)
            {
                // MessageBox.Show("网点信息有重复，请检查后再用卡", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                szErr = "网点信息有重复，请检查后再用卡";
                return;
            }

            DataRow dr = ds.Tables[0].Rows[0];
            frm_Main.mbHaveReg = true;
            if (dr[5].ToString().ToUpper() == "N")
                frm_Main.mbHaveReg = false;
            frm_Main.mID = Convert.ToInt16(dr[0]);
            frm_Main.mszKey = dr[1].ToString();
            frm_Main.mszTellerNo = dr[2].ToString();
            frm_Main.mszNetName = dr[3].ToString();
            frm_Main.mszNetTel = dr[4].ToString();
            /* add by lily 2018.9.20(V2.51),cancel by lily 2018.9.21(back to V2.49)
            szSql = "select * from base_net where flag='Y' and teller_no='" + frm_Main.mszTellerNo+"'";
            iRst = MyStart.oMyDb.ReadData(szSql, "tableA", ref ds, ref szErr);
            if (iRst < 0)
            {
                //MessageBox.Show("读取网点信息失败，请重新操作", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                szErr = "读取网点状态失败，请重新操作";
                return;
            }

            iNum = ds.Tables[0].Rows.Count;
            if (iNum == 0)
                frm_Main.mbHaveReg = false;
            else
            {
                szSql= "update base_net set flag='Y' where  teller_no='" + frm_Main.mszTellerNo + "'";
                iRst=MyStart.oMyDb.WriteData(szSql,ref szErr);
                if (iRst < 1)
                {
                    MessageBox.Show("更新网点状态失败（错误原因：" + szErr + "）", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MyIniFile.WriteLog(szTitle, "SQL=" + szLogSql + ",Err=" + szErr);
                    //return;
                }
            }*/
        }
    }
}
