using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;  
using System.Security.Cryptography;

namespace YTB
{
    class MyCryptClass
    {
        /// <summary>  
        /// MD5加密  
        /// </summary>  
        /// <param name="sSourceString">需要加密的字符串</param>  
        /// <param name="sTargetString">加密后的字符串，用小写表示</param>  
        /// <returns></returns>  
        public static bool MD5_Encrypt(string sSourceString, ref string sTargetString)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string result = "";
            bool bResult = false;

            try
            {
                if (!string.IsNullOrWhiteSpace(sSourceString))
                {
                    result = BitConverter.ToString(md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(sSourceString.Trim())));
                    //result = Convert.ToBase64String(md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(sSourceData.Trim())));
                    result = result.ToLower();
                    bResult = true;
                }
                else
                {
                    result = "SourceString is NULL or WhiteSpace.";
                }
            }
            catch (Exception ex)
            {
                result = "MD5 Exception error = " + ex.Message;
            }
            sTargetString = result;
            return bResult;
        }

        public static bool AES_Encrypt(string Input, string AESKey, ref string Output)
        {
            bool bResult = false;

            byte[] Key = Encoding.GetEncoding("GBK").GetBytes(AESKey);
            byte[] Iv = new byte[16];
            //Array.Copy(Key, Iv, 16);
            var aes = new RijndaelManaged();
            Output = "";
            try
            {
                //秘钥的大小，以位为单位
                //aes.KeySize = 128;
                //支持的块大小
                aes.BlockSize = 128;
                //填充模式
                aes.Padding = PaddingMode.PKCS7;
                //aes.Padding = PaddingMode.None;
                aes.Mode = CipherMode.ECB;
                aes.Key = Key;
                //aes.IV = Iv;
                var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] xBuff = null;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                    {
                        byte[] xXml = Encoding.GetEncoding("GBK").GetBytes(Input);
                        cs.Write(xXml, 0, xXml.Length);
                        cs.FlushFinalBlock();
                    }
                    xBuff = ms.ToArray();
                }
                Output = Convert.ToBase64String(xBuff);
                bResult = true;
            }
            catch (Exception ex)
            {
                Output = "AES_encrypt Exception error = " + ex.Message;
            }
            return bResult;
        }

        public static bool AES_Decrypt(string Input, string AESKey, ref string Output)
        {
            bool bResult = false;
            byte[] Key = Encoding.GetEncoding("GBK").GetBytes(AESKey);
            byte[] Iv = new byte[16];
            Array.Copy(Key, Iv, 16);

            var aes = new RijndaelManaged();
            Output = "";
            try
            {
                //秘钥的大小，以位为单位
                aes.KeySize = 128;
                //支持的块大小
                aes.BlockSize = 128;
                //填充模式
                aes.Padding = PaddingMode.PKCS7;
                //aes.Padding = PaddingMode.None;
                aes.Mode = CipherMode.ECB;

                aes.Key = Key;
                //aes.IV = Iv;
                var decrypt = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] xBuff = null;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                    {
                        byte[] xXml = Convert.FromBase64String(Input);
                        cs.Write(xXml, 0, xXml.Length);
                    }
                    xBuff = ms.ToArray();        // ?decode2
                }
                Output = Encoding.GetEncoding("GBK").GetString(xBuff);
                bResult = true;
            }
            catch (Exception ex)
            {
                Output = "AES_Decrypt Exception error = " + ex.Message;
            }
            return bResult;
        }

        public static bool Sign_SHA256(string Input, ref string Output)
        {
            bool bResult = false;
            try
            {
                byte[] SHA256Data = Encoding.UTF8.GetBytes(Input); // Encoding.GetEncoding("GBK").GetBytes(Input); //Encoding.Default.GetBytes(Input); //
                SHA256Managed Sha256 = new SHA256Managed();
                byte[] Result = Sha256.ComputeHash(SHA256Data);
                //Output= Convert.ToBase64String(Result);  //返回长度为44字节的字符串
                Output = MyTools.ByteToString(Result, 0, Result.Length);
                bResult = true;
            }
            catch(Exception ex)
            {
                Output = "计算SHA256出错(ex=" + ex.ToString() + ")";
            }
            return bResult;
        }
    }
}
