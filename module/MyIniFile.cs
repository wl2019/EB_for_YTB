using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace YTB
{
    class MyIniFile
    {
        //错误代码定义： >0--Succ,  <0--ErrCode
        public const Int16 Err_Succ = 1;
        public const int MY_ERR = -12000;
        public const Int16 Err_IniGeneralErr = MY_ERR - 1;
        public const Int16 Err_IniFileNotFind = MY_ERR - 20;
        public const Int16 Err_IniReadErr = MY_ERR - 21;
        public const Int16 Err_IniWriteErr = MY_ERR - 22;
        public const Int16 Err_IniOpenErr = MY_ERR - 23;
        public const Int16 Err_FileErr = MY_ERR - 24;

        public const Int16 Err_IniKeyNotFound = -101;

        // 读取Ini文件指定Fiels.Key的值，该值一定是string,由用户自己转化为Long
        // sIniFileName-----Ini文件名（包含目录）
        public const string mszIniKey = "12345678";
        public const string mszIniFile = "\\YTB.ini";
        public static short GetIniKeyString(string sIniFileName, string sFieldName, string sKeyName, ref string sValueString)
        {
            short iResult;
            bool bFindField;
            string sBuff;
            StreamReader IniFileStream;

            iResult = -1;
            bFindField = false;
            if (File.Exists(sIniFileName) != true)
            {
                iResult = Err_IniFileNotFind;
                goto EEnd;
            }

            IniFileStream = new StreamReader(sIniFileName);
            try
            {
                while (true)
                {
                    sBuff = IniFileStream.ReadLine();
                    if (sBuff == null)
                    {
                        if (IniFileStream.EndOfStream)
                        {
                            iResult = Err_IniKeyNotFound;
                            break;
                        }
                    }
                    else if (bFindField)  //已经找到field,但没找到key
                    {
                        if (sBuff.Substring(0, sBuff.IndexOf("=") + 1) == sKeyName.Trim() + "=")  // 找到Key了，把等号后面的值取出来
                        {
                            sValueString = sBuff.Substring(sKeyName.Length+1, sBuff.Length - (sKeyName.Length+1));
                            iResult = (short)sValueString.Length;
                            break;
                        }
                    }
                    else //还没找到field
                    {
                        if (sBuff == "[" + sFieldName.Trim() + "]") bFindField = true;
                    }
                }
            }
            catch
            {
                iResult = -1;
            }
            IniFileStream.Close();
EEnd:
            return iResult;
        }

        public static short GetIniKeyValue(string sIniFileName, string sFieldName, string sKeyName, ref long lReturnValue)
        {
            // 把指定项字串值，作为long值返回，成功＝1，失败＝－1
            
            short iResult = -1;
            string sReturnString = "";

            iResult = GetIniKeyString(sIniFileName, sFieldName, sKeyName, ref sReturnString);
            if (iResult > 0)
            {
                try
                {
                    lReturnValue = System.Convert.ToInt32(sReturnString);
                    iResult = 1;
                }
                catch
                {
                    iResult = - 1;
                }
            }
            return iResult;
        }

        // 写Ini文件指定Fiels.Key的值，该值一定是string
        // 如果Ini文件不存在，就自动建立
        public static short SetIniKeyValue(string sIniFileName, string sFieldName, string sKeyName, string sValueString)
        {
            short iResult,iFileLines,iI;
            bool bFindField,bWriteSucc;
            string[] sBuff = new string[1000] ;
            string sTmpFileName;
            StreamReader IniFileReadStream;
            StreamWriter IniFileWriteStream;

            iResult = -1;
            iFileLines = 0;

            if ( File.Exists(sIniFileName) == true)
            {
                IniFileReadStream = new StreamReader(sIniFileName);
                try
                {
                    while(true)
                    {
                        sBuff[iFileLines] =  IniFileReadStream.ReadLine();
                        if (sBuff[iFileLines] == null)
                        {
                            if (IniFileReadStream.EndOfStream)
                            {
                                break;
                            }
                            else
                            {
                                sBuff[iFileLines] = "";
                                iFileLines++;
                            }
                        }
                        else
                        {
                            iFileLines++;
                        }
                    }
                    IniFileReadStream.Close();
                }
                catch
                {
                    iResult = Err_IniReadErr;
                    IniFileReadStream.Close();
                    goto EEnd;
                }
            }
            
            sTmpFileName = sIniFileName + ".tmp";
            try
            {
                if (File.Exists(sTmpFileName) == true)
                {
                    File.Delete(sTmpFileName);
                }
                File.Move(sIniFileName, sTmpFileName);
            }
            catch
            {
                iResult = Err_FileErr;
            }

            bFindField = false;
            bWriteSucc = false;
            IniFileWriteStream = new StreamWriter(sIniFileName, false);
            try
            {
                if (iFileLines == 0)
                {
                    IniFileWriteStream.WriteLine( "["+sFieldName.Trim()+"]");
                    IniFileWriteStream.WriteLine( sKeyName.Trim()+"="+sValueString.Trim() );
                }
                else
                {
                    for (iI = 0; iI < iFileLines; iI++)
                    {
                        if (sBuff[iI].Contains("[") || sBuff[iI].Contains("="))    // 包含 [ or = 的才是需要的语句，否则丢掉
                        {
                            if (bWriteSucc)   // 已经写了，剩下的就直接回写
                            {
                                IniFileWriteStream.WriteLine(sBuff[iI]);
                            }
                            else if (bFindField)  //已经找到field,但没找到key
                            {
                                if (sBuff[iI].Substring(0, 1) == "[")       // 是否下一个field，是的话，就要增加key
                                {
                                    IniFileWriteStream.WriteLine(sKeyName.Trim() + "=" + sValueString.Trim());
                                    bWriteSucc = true;
                                }
                                else if ( sBuff[iI].Substring(0,sBuff[iI].IndexOf("=")+1 ) == sKeyName.Trim() + "=")   // 找到Key了
                                {
                                    IniFileWriteStream.WriteLine(sKeyName.Trim() + "=" + sValueString.Trim());
                                    bWriteSucc = true;
                                }
                                else    // 不是Key，就直接写回去，然后下一行判断
                                {
                                    IniFileWriteStream.WriteLine(sBuff[iI]);
                                }
                            }
                            else //还没找到field
                            {
                                if (sBuff[iI] == "[" + sFieldName.Trim() + "]")
                                {
                                    bFindField = true;
                                }
                                IniFileWriteStream.WriteLine(sBuff[iI]);
                            }
                        }   //if ()
                    }   // for()
                    if (!bWriteSucc)   // 结束了还没写
                    {
                        if (!bFindField)   // 最后的field 是否需要的field，不是就要写field
                        {
                            IniFileWriteStream.WriteLine("[" + sFieldName.Trim() + "]");
                        }
                        IniFileWriteStream.WriteLine(sKeyName.Trim() + "=" + sValueString.Trim());
                    }
                }
                iResult = 1;
            }
            catch
            {
                iResult = Err_IniWriteErr;
            }
            IniFileWriteStream.Close();

        EEnd:
            return iResult;
        }

        /*
        public static void GetIni(ref string szSysLogin, ref string szSysPwd,
            ref string szDbIp, ref string szDbPort, ref string szDbSrv, 
            ref string szDbLogin, ref string szDbPwd)
        {
            string str = "";
            short sI;
            string sIniFileName = Application.StartupPath + mszIniFile;

            sI = MyIniFile.GetIniKeyString(sIniFileName, "Sys", "Login", ref szSysLogin);
            if (sI < 0) szSysLogin = "123";

            sI = MyIniFile.GetIniKeyString(sIniFileName, "Sys", "Pwd", ref str);
            if (sI < 0)
            {
                szSysPwd = "1234567890";
            }
            else
            {
                if (str.Length == 16 && MyTools.StringIsHex(str))
                {
                    szSysPwd = MyTools.HideString_To_OpenString(str, mszIniKey);
                    szSysPwd = szSysPwd.Trim();
                }
                else
                    szSysPwd = "1234567890";
            }

            // DB
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "IP", ref szDbIp);
            if (sI < 0) szDbIp = "rm-bp15ol05h0es8f5eco.mysql.rds.aliyuncs.com";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Port", ref szDbPort);
            if (sI < 0) szDbPort = "3306";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Srv", ref szDbSrv);
            if (sI < 0) szDbSrv = "zsmkt";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Srv", ref szDbLogin);
            if (sI < 0) szDbLogin = "ztb";
            sI = MyIniFile.GetIniKeyString(sIniFileName, "Db", "Pwd", ref str);
            if (sI < 0)
            {
                szDbPwd = "Ztb_1324";
            }
            else
            {
                if (str.Length == 16 && MyTools.StringIsHex(str))
                {
                    szDbPwd = MyTools.HideString_To_OpenString(str, mszIniKey);
                    szDbPwd = szDbPwd.Trim();
                }
                else
                    szDbPwd = "Ztb_1324";
            }
        }*/

        public static bool SetIni(string SysLogin_New, string SysPwd_New, string KM_IP_New, string KM_PORT_New, string DB_Addr_New, int iSamRd_New, int iRFRd_New)
        {
            string str = "";
            short sI;
            string sIniFileName = Application.StartupPath + "\\SYS.ini";

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Sys", "Login", SysLogin_New);
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 Sys.Login 项时出错";
                goto Eend;
            }

            str = MyTools.OpenString_To_HideString((SysPwd_New + "        ").Substring(0, 8), mszIniKey);
            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Sys", "Pwd", str);
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + "文件的 Sys.Pwd 项时出错";
                goto Eend;
            }

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "KM", "IP", KM_IP_New);
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 KM.IP 项时出错";
                goto Eend;
            }

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "KM", "Port", KM_PORT_New);
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 KM.Port 项时出错";
                goto Eend;
            }

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "DbSrv", "Addr", DB_Addr_New);
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 DbSrv.Addr 项时出错";
                goto Eend;
            }

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Comm", "SAM_DEV", iSamRd_New.ToString());
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 Comm.SAM_DEV 项时出错";
                goto Eend;
            }

            sI = MyIniFile.SetIniKeyValue(sIniFileName, "Comm", "RF_DEV", iRFRd_New.ToString());
            if (sI < 0)
            {
                str = "保存 " + sIniFileName + " 文件的 Comm.RF_DEV 项时出错";
                goto Eend;
            }
            return true;

            Eend:
            MessageBox.Show(str, "操作错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    
        public static void WriteLog(string szType, string szMsg)
        {
            string szfName;
            string szTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string szDate = DateTime.Now.ToString("yyyyMM");
            string szLog;

            if (szType.Length == 0)
                szLog = szTime + "--" + szMsg;
            else
                szLog = szTime + "--" + szType + "--" + szMsg;

            try
            {
                szfName = Application.StartupPath + "\\_log\\err" + szDate + ".txt";
                StreamWriter swErr = new StreamWriter(szfName, true);
                swErr.WriteLine(szLog);
                swErr.Close();
            }
            catch (Exception ex)
            {
                string szErrMsg = ex.Message;
            }
        }
    }
}
