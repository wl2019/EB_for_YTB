using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;

namespace YTB
{
    interface IDb
    {
        bool DbOpen(string szCon, ref string szErr);
        bool DbClose();
        int DbWriteData(string szSql, ref string szErr);
        int DbReadData(string szSql, string szTable, ref DataSet odt, ref string szErr);

    }

    class CDb
    {
        protected IDb m_oDB;
        public static string m_szCon;
        //protected string m_szDbPort;        
        //protected string m_szDbName;
        //protected string m_szDbUser;
        //protected string m_szDbPwd;
        public static bool bOpenDB;

        public const int MY_ERR = -11000;
        public const int ERR_CON= MY_ERR - 1;
        public const int ERR_WRITE = MY_ERR - 2;
        public const int ERR_READ = MY_ERR - 3;

        public CDb(string szDb,string szAddr, string szPort, string szName, string szUser, string szPwd)
        {
            switch (szDb.ToUpper())
            {
                 /*case "ACCESS":
                    {
                        //public static string szAccessDbName = "\\NTcp.accdb";//for 64bit  "\\NTcp.mdb";//for 32bit
                        //public static string szAccessConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source='" +//for 64bit 
                        ////public static string szAccessConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" +//for 32bit 2007
                        ////public static string szAccessConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data source=" +//for 32bit
                        //                           Application.StartupPath + szAccessDbName + "'";//;Jet OLEDB:DataBase Password=f0sds35nfg8cd9sdrdtt74dcc";
                        m_oDB = new CDbAccess();
                        m_szCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data source=" +
                           szName.Trim() + ";Jet OLEDB:DataBase Password=" + szPwd.Trim();//for 32bit 2007
                        break;
                    }
               case "ORACLE":
                    {
                        m_oDB = new CDbOracle();
                        m_szCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + 
                            szAddr.Trim() + ") (PORT=" +szPort.Trim() + ")))(CONNECT_DATA=(SERVICE_NAME=" + 
                            szName.Trim() + ")));Persist Security Info=True;User Id=" +szUser.Trim() + 
                            ";password = " + szPwd.Trim() + ";";
                        break;
                    }*/
                case "MYSQL":
                    {
                        m_oDB = new CDbMysql();
                        m_szCon = "User Id = "+szUser.Trim()+"; pwd = "+szPwd.Trim()+"; Host = "+
                            szAddr.Trim() +"; Port = "+szPort.Trim()+"; Database = "+
                            szName.Trim() +"; Character Set = utf8";
                        break;
                    }
                default: m_oDB = null;break;
            }
        }

        public bool Open(ref string szErr)
        {
            szErr = "";
            bOpenDB = m_oDB.DbOpen(m_szCon, ref szErr);
            return bOpenDB;
        }

        public bool Close()
        {
            bool bRst=m_oDB.DbClose();
            if (bRst)
                bOpenDB = false;
            return bRst;
        }

        public int WriteData(string szSql, ref string szErr)
        {//for insert,update etc.
            szErr = "";
            //m_oDB.DbOpen(m_szCon, ref szErr);
            //if (bOpenDB)
            //    Close();
            //Open(ref szErr);

            if (!bOpenDB)
                if (!Open(ref szErr))
                    return ERR_CON;

            return m_oDB.DbWriteData(szSql,ref szErr);
        }

        public int ReadData(string szSql, string szTable, ref DataSet odt, ref string szErr)
        {
            szErr = "";
            //m_oDB.DbOpen(m_szCon, ref szErr);
            //if (bOpenDB)
            //    Close();
            //Open(ref szErr);

            if (!bOpenDB)
                if (!Open(ref szErr))
                    return ERR_CON;

            return m_oDB.DbReadData(szSql,szTable, ref odt, ref szErr);
        }
    }
}
