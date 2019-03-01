using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;//for mysql
using MySql.Data.MySqlClient.Properties;//for mysql


namespace YTB
{
    class CDbMysql:IDb
    {
        //引用：MySql.Data.dll
        //参考路径：C:\Program Files (x86)\MySQL\MySQL Connector Net 6.9.9\Assemblies\v4.5
        MySqlConnection MyCon;
//        string szCon;

        public bool DbOpen(string szCon, ref string szErr)
        {
            try
            {
                MyCon = new MySqlConnection(szCon);
                MyCon.Open();
                return true;
            }
            catch( Exception ex)
            {
                szErr = "Mysql.Open ErrMsg=" + ex.Message;
                return false;
            }
        }

        public bool DbClose()
        {
            try
            {
                MyCon.Close();
                MyCon.Dispose();
            }
            catch (Exception ex)
            {
                string szErr = "Mysql.Close ErrMsg=" + ex.Message;
                return true;
            }
            return true;
        }
        public int DbWriteData(string szSql, ref string szErr)
        {
            int iRowNum;
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = MyCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = szSql;
                iRowNum = cmd.ExecuteNonQuery(); 
                return iRowNum;
            }
            catch (Exception ex)
            {
                szErr = "Mysql.WriteData ErrMsg=" + ex.Message;
                return CDb.ERR_WRITE;
            }
        }
        public int DbReadData(string szSql, string szTable, ref DataSet odt, ref string szErr)
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = new MySqlCommand(szSql, MyCon);
                odt = new DataSet();
                da.Fill(odt, szTable);
                return 0;
            }
            catch (Exception ex)
            {
                szErr = "Mysql.ReadData ErrMsg=" + ex.Message;
                //odt = null;
                return CDb.ERR_READ;
            }
        }

    }
}
