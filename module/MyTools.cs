using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using System.Drawing.Printing;
//using System.Runtime.InteropServices;//for define dll
/*using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Core;
//using ICSharpCode.SharpZipLib.Tests.TestSupport;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;*/

namespace YTB
{
    public class MyTools
    {
        //1 �������ݸ�ʽת��
        //2 DES�ӽ���
        //3 ZIP

        public static string StrTimeToStrDateTime(string StrTime)
        {
            if (StrTime.Length == 16)
                return StrTime.Substring(0, 4) + "-" + StrTime.Substring(4, 2) + "-" +
                         StrTime.Substring(6, 2) + " " + StrTime.Substring(8, 2) + ":" +
                         StrTime.Substring(10, 2) + ":" + StrTime.Substring(12, 2) + "." + StrTime.Substring(14, 2);
            else
                return StrTime;
        }

        public static string StrDataTimeToStrTime(string StrDataTime)
        {
            if (StrDataTime.Length == 21)
                return StrDataTime.Substring(0, 4) + StrDataTime.Substring(5, 2) + StrDataTime.Substring(8, 2) +
                       StrDataTime.Substring(11, 2) + StrDataTime.Substring(14, 2) + StrDataTime.Substring(17, 2) + StrDataTime.Substring(20, 2);
            else
                return StrDataTime;
        }

        public static string ByteToString(byte[] byteSourceArry, int iBeginPos, int iByteLen)
        {
            int iI,iJ;
            byte Ch;
            string sTargetStr="";
            string sAscII = "0123456789ABCDEF";

            for (iI = 0; iI < iByteLen; iI++)
            {
                Ch = byteSourceArry[iI + iBeginPos];
                iJ = (Ch & 0xf0) >> 4;
                sTargetStr += sAscII[iJ];

                iJ = Ch & 0x0f;
                sTargetStr += sAscII[iJ];
            }
            return sTargetStr;
        }

        public static void StringToByte(string sStringSource, byte[] bByteTarget, int iDstPos,int iByteLen)
        {
            int iI, iJ;
            char cC1, cC2;

            for (iI = 0; iI < iByteLen; iI++)
            {
                cC1 = sStringSource[2 * iI];
                cC2 = sStringSource[2 * iI+1];

                if (cC1 >= 0x30 && cC1 <= 0x39)
                    iJ = cC1 - 0x30;
                else if (cC1 >= 0x41 && cC1 <= 0x46)
                    iJ = 10 + cC1 - 0x41;
                else
                    iJ = 10 + cC1 - 0x61;

                if (cC2 >= 0x30 && cC2 <= 0x39)
                    iJ = (iJ << 4) + cC2 - 0x30;
                else if (cC2 >= 0x41 && cC2 <= 0x46)
                    iJ = (iJ << 4) + 10 + cC2 - 0x41;
                else
                    iJ = (iJ << 4) + 10 + cC2 - 0x61;

                bByteTarget[iI + iDstPos] = (byte)(iJ & 0xff);
            }
        }
        public static int BytesCompare(byte[] b1, int iPos1, byte[] b2, int iPos2, int iLen)
        {
            int result = 0;
            for (int i = 0; i < iLen; i++)
            {
                if (b1[iPos1 + i] != b2[iPos2 + i])
                {
                    result = (int)(b1[iPos1 + i] - b2[iPos2 + i]);
                    break;
                }
            }
            return result;
        }
        public static long BytesToNum(byte[] Src, int iSrcPos, int iLen)
        {
            long lTemp = 0;
            for (int index = 0; index < iLen; index++)
            {
                lTemp += Src[index + iSrcPos];
                if (index + 1 != iLen)
                    lTemp *= 256;
            }
            return lTemp;
        }

        public static long StrToLong(string sStrBuff, int iStrLen)
        {
            int i;
            long li;

            li = 0;
            for (i = 0; i < iStrLen; i++)
            {
                li = li * 10 + (long)(sStrBuff[i]-0x30);
            }
            return li;
        }

        
        // �ַ���ת��������"899091"��Unicode��
        public static string String_To_UnicodeHexString(string Str)
        {
            // ���� to Unicode
            string hz = "";

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(Str);
            for (int i = 0; i < bytes.Length; i++)
            {
                hz += bytes[i].ToString("X2");
            }
            return hz;
        }

        public static string String_To_AscHexString(string Str)
        {
            // ���� to Unicode
            string hz = "";

            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Str);
            for (int i = 0; i < bytes.Length; i++)
            {
                hz += bytes[i].ToString("X2");
            }
            return hz;
        }

        public static string UnicodeHexString_To_String(string HexStr)
        {
            string hz;

            try
            {
                byte[] bytes = new byte[HexStr.Length / 2];
                for (int i = 0; i < HexStr.Length / 2; i++)
                {
                    bytes[i] = Convert.ToByte(HexStr.Substring(i * 2, 2), 16);
                }
                hz = System.Text.Encoding.Unicode.GetString(bytes);
            }
            catch
            {
                hz = null;
            }
            return hz;
        }

        public static string AscHexString_To_String(string HexStr)
        {
            string hz;

            try
            {
                byte[] bytes = new byte[HexStr.Length / 2];
                for (int i = 0; i < HexStr.Length / 2; i++)
                {
                    bytes[i] = Convert.ToByte(HexStr.Substring(i * 2, 2), 16);
                }
                hz = System.Text.Encoding.ASCII.GetString(bytes);
            }
            catch
            {
                hz = null;
            }
            return hz;
        }

        //�Ƚ����ִ����飬 �������������ͬ������0���������1С������2������С��0��ֵ���������1��������2�����ش���0��ֵ��
        public static int MemoryCompare(byte[] b1, byte[] b2)
        {
            int result = 0;
            if (b1.Length != b2.Length)
                result = b1.Length - b2.Length;
            else
            {
                for (int i = 0; i < b1.Length; i++)
                {
                    if (b1[i] != b2[i])
                    {
                        result = (int)(b1[i] - b2[i]);
                        break;
                    }
                }
            }
            return result;
        }

        // pverride 1
        public static string IPValueToIPStr( int IP1, int IP2, int IP3, int IP4)
        {
            return IP1.ToString() + "." + IP2.ToString() + "." + IP3.ToString() + "." + IP4.ToString("000") ;
        }
        // pverride 2
        public static string IPValueToIPStr(int IP1, int IP2, int IP3, int IP4, int Port)
        {
            return IP1.ToString() + "." + IP2.ToString() + "." + IP3.ToString() + "." + IP4.ToString("000") + ":" + Port.ToString();
        }

        // pverride 1
        public static void IPStrToIPValue(string IPStr, out int IP1, out int IP2, out int IP3, out int IP4)
        {
            int i;
            string sStr, sStrOld;

            sStrOld = IPStr;
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP1 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP2 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP3 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            //i = sStrOld.IndexOf(':');
            //sStr = sStrOld.Substring(0, i);
            IP4 = (int)StrToLong(sStrOld, sStrOld.Length);
        }

        // pverride 2
        public static void IPStrToIPValue(string IPStr, out int IP1, out int IP2, out int IP3, out int IP4, out int Port)
        {
            int i;
            string sStr, sStrOld;

            sStrOld = IPStr;
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP1 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP2 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            i = sStrOld.IndexOf('.');
            sStr = sStrOld.Substring(0, i);
            IP3 = (int)StrToLong(sStr, sStr.Length);

            sStrOld = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            i = sStrOld.IndexOf(':');
            sStr = sStrOld.Substring(0, i);
            IP4 = (int)StrToLong(sStr, sStr.Length);

            sStr = sStrOld.Substring(i + 1, sStrOld.Length - i - 1);
            Port = (int)StrToLong(sStr, sStr.Length);
        }

        public static bool StringIsNumberic(string sMessage, out long lValue)
        {
            //�ж��ִ��Ƿ�Ϊ�����ַ���
            //�ǵĻ�����ת��Ϊ���ֲ�������Ϊout���͵����ֵ������true, ����Ϊfalse

            lValue = -1;   //lValue ����Ϊout �������ֵ
            try
            {
                //�������ַ�����Ϊ������4ʱ���������ֶ�����ת������ѡһ��
                //���λ������4�Ļ�����ѡ��Convert.ToInt32() ��int.Parse()

                //lValue = int.Parse(sMessage);
                //lValue = Convert.ToInt16(sMessage);
                lValue = Convert.ToInt32(sMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool StringIsHex(string sMMessage)
        {
            //�ж��ִ��Ƿ�ΪHex16���Ƶ��ַ�����0��9��A��B��a��b��
            //����ǿմ������� false
            int i;

            if (sMMessage.Length == 0) 
                return false;

            char[] cCS = sMMessage.ToCharArray(0, sMMessage.Length);
            
            for ( i = 0; i < sMMessage.Length; i++)
            {
                if ((cCS[i] >= '0' && cCS[i] <= '9') || (cCS[i] >= 'A' && cCS[i] <= 'F') || (cCS[i] >= 'a' && cCS[i] <= 'f'))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static void NumToBytes(long Src, byte[] Dst, int iDstPos,int iLen)
        {
            long lTemp = Src;
            for (int index = iLen; index >0; index--)
            {
                Dst[index - 1 + iDstPos] = Convert.ToByte(lTemp % 256);
                lTemp -= Dst[index - 1 + iDstPos];
                lTemp /= 256;
            }
        }

        static byte[] Key1 = { 0x9d, 0x87, 0xfa, 0x6a, 0x80, 0x5b, 0xcc, 0x77, 0x49, 0x6c, 0xd7, 0x32, 0x40, 0xbc, 0x08, 0x68 };

        //�������ַ���(8�ֽڣ� ���� �����ģ�16�����ַ�����ʾ��16�ֽڣ�
        public static string OpenString_To_HideString(string OpenString,string szKey)
        {
            byte[] bS1 = new byte[8];
            byte[] bT1 = new byte[8];
            byte[] bK1 = new byte[8];
            string bResult;

            if (OpenString.Length != 8)
            {
                bResult = "";
            }
            else
            {
                bS1 = System.Text.Encoding.Default.GetBytes(OpenString);
                if (szKey != "" && szKey.Length == 16)
                    bK1 = System.Text.Encoding.Default.GetBytes(szKey);
                else
                    Array.Copy(Key1, 0, bK1, 0, 8);

                ThreeDesEncryptByte(bK1, bS1, ref bT1);
                bResult = ByteToString(bT1, 0, 8);
            }
            return bResult;
        }


        //�����ģ�16�����ַ�����ʾ��16���ֽڣ����ܳ� �����ַ�����8�ֽڣ�
        public static string HideString_To_OpenString(string HideString, string szKey)
        {
            byte[] bS1 = new byte[8];
            byte[] bT1 = new byte[8];
            byte[] bK1 = new byte[8];
            string bResult;

            if (HideString.Length != 16 || !StringIsHex(HideString))
            {
                bResult = "";
            }
            else
            {
                StringToByte(HideString, bS1,0, 8);
                if (szKey != "" && szKey.Length == 16)
                    bK1 = System.Text.Encoding.Default.GetBytes(szKey);
                else
                    Array.Copy(Key1, 0, bK1, 0, 8);

                ThreeDesDecryptByte(bK1, bS1, ref bT1);
                bResult = "";
                for (int i = 0; i < bT1.Length; i++)
                {
                    bResult += Convert.ToChar(bT1[i]);
                }
            }
            return bResult;
        }

        // 3Des����˵����
        // 1����Կ byte[] sKey�����ȱ�����16�ֽڡ�
        // 2������Դ byte[] SourceValue��������8�ı������ɵ����߷�װ���ܳ�����ϵͳ���ܾ�����
        // 3������������������8���ַ�
        //const string sIV = "W&L-ZZZS";

        //����
        public static string ThreeDesEncryptHex(string szSrc, string szKey)
        {
            if (!StringIsHex(szSrc))
                return "";

            int iLen = szSrc.Length;            
            if (iLen % 16 != 0)
                return "";
            iLen = iLen / 2;

            int iKeyLen=szKey.Length;
            if (iKeyLen % 16 != 0)
                return "";
            iKeyLen = iKeyLen / 2;

            //StringBuilder szDst = new StringBuilder(iLen);
            //TriDesEncrypt_HEX(szKey, szSrc, szDst);
            //return szDst.ToString().Substring(0,iLen);
            byte[] ucSrc = new byte[iLen];
            byte[] ucKey = new byte[iKeyLen];
            byte[] ucDst = new byte[iLen];
            StringToByte(szSrc, ucSrc, 0, iLen);
            StringToByte(szKey, ucKey, 0, iKeyLen);
            if (!ThreeDesEncryptByte(ucKey, ucSrc, ref ucDst))
                return "";

            return ByteToString(ucDst, 0, iLen);
        }

        public static string ThreeDesDecryptHex(string szSrc, string szKey)
        {
            if (!StringIsHex(szSrc))
                return "";

            int iLen = szSrc.Length;
            if (iLen % 16 != 0)
                return "";
            iLen = iLen / 2;

            int iKeyLen = szKey.Length;
            if (iKeyLen % 16 != 0)
                return "";
            iKeyLen = iKeyLen / 2;

            //StringBuilder szDst = new StringBuilder(iLen);
            //TriDesDecrypt_HEX(szKey, szSrc, szDst);                    
            //return szDst.ToString();
            byte[] ucSrc = new byte[iLen];
            byte[] ucKey = new byte[iKeyLen];
            byte[] ucDst = new byte[iLen];
            StringToByte(szSrc, ucSrc, 0, iLen);
            StringToByte(szKey, ucKey, 0, iKeyLen);
            if (!ThreeDesDecryptByte(ucKey, ucSrc, ref ucDst))
                return "";

            return ByteToString(ucDst, 0, iLen);
        }


        public static bool ThreeDesEncryptByte(byte[] sKey, byte[] SourceValue, ref byte[] TargetValue)
        {//key len=8,DES;key len=16,3DES
            try
            {
                ICryptoTransform ct;
                MemoryStream ms;
                CryptoStream cs;
                SymmetricAlgorithm mCSP;

                if (sKey.Length == 8)
                    mCSP = new DESCryptoServiceProvider();
                else if (sKey.Length == 16)
                    mCSP = new TripleDESCryptoServiceProvider();
                else
                    return false;

                byte[] byt;
                //mCSP.KeySize = 128;
                mCSP.Key = sKey;

                //ָ����ʼ������
                //mCSP.IV = Convert.FromBase64String(sIV);  ԭ����
                string szIV = "\x0\x0\x0\x0\x0\x0\x0\x0";
                mCSP.IV = System.Text.Encoding.Default.GetBytes(szIV);

                //ָ�����ܵ�����ģʽ--�������뱾 (ECB) ģʽ�ֱ����ÿ����
                mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;

                //��ȡ�����ü����㷨�����ģʽ
                mCSP.Padding = System.Security.Cryptography.PaddingMode.Zeros;

                ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);                      //�������ܶ���
                //byt = Encoding.UTF8.GetBytes(SourceValue);
                byt = SourceValue;

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();

                //TargetValue = Convert.ToBase64String(ms.ToArray());  // ԭ����
                TargetValue = ms.ToArray();
                return true;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("�����㷨����" + ex.Message, "�����쳣", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public static bool ThreeDesDecryptByte(byte[] sKey, byte[] SourceValue, ref byte[] TargetValue)
        {
            try
            {
                ICryptoTransform ct;            //����ת������
                MemoryStream ms;                //�ڴ���
                CryptoStream cs;                //���������ӵ����ݼ���ת������
                SymmetricAlgorithm mCSP;

                if (sKey.Length == 8)
                    mCSP = new DESCryptoServiceProvider();
                else if (sKey.Length == 16)
                    mCSP = new TripleDESCryptoServiceProvider();
                else
                    return false;

                byte[] byt;
                //mCSP.KeySize = 128;
                mCSP.Key = sKey;

                //ָ����ʼ������
                //mCSP.IV = Convert.FromBase64String(sIV);  ԭ����
                string szIV = "\x0\x0\x0\x0\x0\x0\x0\x0";
                mCSP.IV = System.Text.Encoding.Default.GetBytes(szIV);

                //ָ�����ܵ�����ģʽ--�������뱾 (ECB) ģʽ�ֱ����ÿ����
                mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;

                //��ȡ�����ü����㷨�����ģʽ
                mCSP.Padding = System.Security.Cryptography.PaddingMode.Zeros;

                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);                     //�����Գƽ��ܶ���
                //byt = Convert.FromBase64String(SourceValue);
                byt = SourceValue;

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();
                cs.Close();

                TargetValue = ms.ToArray();
                return true;
            }
            catch(Exception ex)
            {
                String szMsg = ex.Message;
                //MessageBox.Show(ex.Message, "�����쳣", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /*public void ZipOneFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //����ļ�û���ҵ����򱨴�
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }*/

        /*public static void ZipFiles(string szSrcPath,string szDstFile)
        {//��Ҫϵͳ����ICSharpCode.SharpZipLib.dll 
            //32λ����ѹ��ʧ�ܣ�64λ����ѹ���ɹ�����2016.9.12
            //   szSrcPath = "C:\\unzipped\\";//��ѹ���ļ�Ŀ¼
            //   szDstFile = "C:\\zip\\a.zip";  //ѹ�����Ŀ���ļ�

            string[] filenames = Directory.GetFiles(szSrcPath);

            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(szDstFile));
            s.SetLevel(6); // 0 - store only to 9 - means best compression
            foreach (string file in filenames)
            {
                //��ѹ���ļ�
                FileStream fs = File.OpenRead(file);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(file);
                entry.DateTime = DateTime.Now;

                // set Size and the crc, because the information
                // about the size and crc should be stored in the header
                // if it is not set it is automatically written in the footer.
                // (in this case size == crc == -1 in the header)
                // Some ZIP programs have problems with zip files that don't store
                // the size and crc in the header.
                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                s.PutNextEntry(entry);
                s.Write(buffer, 0, buffer.Length);
            }
            s.Finish();
            s.Close();
        }

        public static void UnZipFiles(string szSrcFile, string szDstPath)
        {//��Ҫϵͳ����ICSharpCode.SharpZipLib.dll 
            //szSrcFile = "C:\\zip\\test.zip";//����ѹ���ļ�
            //szDstPath = "C:\\unzipped\\";//��ѹ����õ�Ŀ��Ŀ¼
            ZipInputStream s = new ZipInputStream(File.OpenRead(szSrcFile));

            ZipEntry theEntry;
            while ((theEntry = s.GetNextEntry()) != null)
            {
                string directoryName = Path.GetDirectoryName(szDstPath);
                string fileName = Path.GetFileName(theEntry.Name);

                //���ɽ�ѹĿ¼
                Directory.CreateDirectory(directoryName);
                if (fileName != String.Empty)
                {
                    //��ѹ�ļ���ָ����Ŀ¼
                    FileStream streamWriter = File.Create(szDstPath + theEntry.Name);

                    int size = 2048;
                    byte[] data = new byte[2048];
                    while (true)
                    {
                        size = s.Read(data, 0, data.Length);
                        if (size > 0)
                        {
                            streamWriter.Write(data, 0, size);
                        }
                        else
                        {
                            break;
                        }
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
        }*/

        // ��ӡСƱ���� ====================================================================
        public static string sPrintTopic;
        public static string sPrintID;
        public static string[] oPrintData;
        public static int iPrintData;
        static float iPageWidth = (int)(80 / 25.4) * 100;
        //static float iPageWidth = (int)(58 / 25.4) * 100;

        static bool bPriviewMode = false; 
        public static void PrintTicket()
        {
            PrintDocument pd = new PrintDocument();

            //���ñ߾�
            Margins margin = new Margins(0, 0, 0, 0);
            pd.DefaultPageSettings.Margins = margin;

            ////ֽ������Ĭ��
            PaperSize pageSize = new PaperSize("MySize", (int)iPageWidth, 2000);
            pd.DefaultPageSettings.PaperSize = pageSize;

            //��ӡ�¼�����            
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

            //��ӡԤ��
            DialogResult dr = DialogResult.Yes;
            if (bPriviewMode)
            {
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = pd;
                dr = ppd.ShowDialog();
            }
            else
            {
                dr = DialogResult.Yes;
            }

            if (dr == DialogResult.Yes)
            {
                try
                {
                    pd.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "��ӡ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pd.PrintController.OnEndPrint(pd, new PrintEventArgs());
                }
            }
        }

        static void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Black);//��ˢ 
            Pen pen = new Pen(Color.Black);           //������ɫ

            Point poTxt = new Point(0, 0); ;
            Font fntTxt = new Font("����", 10, FontStyle.Regular);//��������
            SizeF sizeF;
            string sTmp = "";
            int ixPos = 0;
            int iyPos = 40;

            try
            {
                sTmp = "����ƾ��";
                fntTxt = new Font("����", 13, FontStyle.Bold);  //    .Regular);                   //��������
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                ixPos = (int)(iPageWidth - sizeF.Width) / 2;
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height - 2;

                sTmp = "==========";
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                ixPos = (int)(iPageWidth - sizeF.Width) / 2;
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 10;

                sTmp = "�г����ƣ�" + MyStart.gszMrktName;
                fntTxt = new Font("����", 10, FontStyle.Regular);                   //��������
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                ixPos = 0;
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                sTmp = "����绰��" + MyStart.gszMrktTel;
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                sTmp = "Ʊ�����ƣ�" + sPrintTopic;
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                if (sPrintID != "")
                {
                    sTmp = "���׵��ţ�" + sPrintID;
                    sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                    poTxt = new Point(ixPos, iyPos);
                    e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                    iyPos += (int)sizeF.Height + 2;
                }

                //     "01234567890123456789012345678901234567890";
                sTmp = "-----------------------------------------";
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                for (int i = 0; i < iPrintData; i++)
                {
                    sizeF = e.Graphics.MeasureString(oPrintData[i], fntTxt);
                    poTxt = new Point(0, iyPos);
                    e.Graphics.DrawString(oPrintData[i], fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                    iyPos += (int)sizeF.Height + 2;
                }

                // End
                sTmp = "-----------------------------------------";
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                sTmp = "��ӡʱ�䣺" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                sTmp = "����Ա�ţ�" + MyStart.giUserID.ToString() + "/������" + MyStart.gszUsername.Trim();
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                sTmp = "��ӭʹ����ɽ��ͨ������ϵͳ";
                fntTxt = new Font("����", 10, FontStyle.Bold);                   //��������
                sizeF = e.Graphics.MeasureString(sTmp, fntTxt);
                poTxt = new Point(ixPos, iyPos);
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //DrawString��ʽ���д�ӡ��
                iyPos += (int)sizeF.Height + 2;

                iyPos += 20;
                ixPos = 0;
                fntTxt = new Font("����", 10, FontStyle.Regular);                   //��������
                poTxt = new Point(ixPos, iyPos);
                sTmp = "";
                e.Graphics.DrawString(sTmp, fntTxt, brush, poTxt);   //��ֽ��
            }
            catch (Exception ex)
            {
                string sz = ex.Message;
                MessageBox.Show("��ӡ���������飡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }
}
