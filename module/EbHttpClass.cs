using System;
using System.Collections.Generic;//for 有序字典 SortedDictionary<string,Object> 
using System.Linq;
using System.Text;
//using Newtonsoft.Json;
using System.Net;
using System.IO;
//如果需要添加System.Web.Script.Serialization引用，请先引用System.Web.Extensions
using System.Web.Script.Serialization;//for json dictory
//using System.Runtime.Serialization.Json;
using System.Data;//for db

namespace YTB
{
    class HttpSendClass
    {
        //public int kv { get; set; }             //-- 控制信息，用于标识密钥版本
        //public string dn { get; set; }			   //-- 控制信息，用于标识设备ID
        //public string nc { get; set; }            //-- 控制信息，用于标识随机数
        public string data { get; set; }          //	-- 数据信息，用于传递具体的应用数据
        //public string sign { get; set; }          //	-- 控制信息，用于标识数据签名
    }
    class EbHttpClass
    {
        /*public const string CMD_RegUserAccount = "104";// 104	会员账号注册
        public const string CMD_QryUserAccount = "50";// 50	会员账户资料查询
        public const string CMD_ChgUserAccount = "51";// 51	会员账户资料修改
        //public const string CMD_RegAccount = "104";// 15	会员卡积分累计
        public const string CMD_AddMoney = "20";// 20	会员卡充值
        public const string CMD_MinusTrade = "2";// 2	会员卡在线消费
        public const string CMD_QryTrade = "103";// 103	在线消费订单查询
        public const string CMD_RebackMoney = "33";// 33	会员卡金额退款
        public const string CMD_BindUserCard = "105";// 105	会员卡绑定
        public const string CMD_FreeUserCard = "107";// 107	会员卡解绑
        public const string CMD_U_ChkTradePwd = "223";// 223	会员卡交易验密
        public const string CMD_U_ChgPwd = "72";// 72	会员卡支付密码修改
        public const string CMD_U_QryTrade = "W900";// W900    会员卡交易记录查询
        //public const string CMD_RegAccount = "104";// W901    会员卡积分获取记录查询
        public const string CMD_GetSrvList = "W902";// W902    获取会员权益服务
        //public const string CMD_RegAccount = "104";// 236	活动赠券
        //public const string CMD_RegAccount = "104";// 237	会员权益电子券查询
        //public const string CMD_RegAccount = "104";// 239	会员权益电子券领取
        public const string CMD_ChgCard = "112";// 112	更换绑定卡号
        //public const string CMD_RegAccount = "104";// 514	在线积分消费交易
        public const string CMD_ChkForAddMoney = "515";// 515	会员卡充值预检查
        public const string CMD_ChgFirmAccount = "52";// 52	商户资料修改
        public const string CMD_FirmBindUserCard = "18";// 18	商户绑定会员卡结款
        public const string CMD_LostCard = "31";// 31	挂失
        public const string CMD_RestoreCard = "32";// 32	解挂失
        public const string CMD_RenewCard = "25";// 25	换卡
        */

        //string SrvUrl = "http://58.213.110.146:9082/ytb-http-server/servlet/server";//"https://183.58.24.209:8088/ytb-http-sersc/servlet/server";


        string sErrMsg = "";
        public string ErrMsg
        {
            get { return sErrMsg; }
        }

        public bool HttpPost(string HttpCmd, string SendData,string szKey,ref Dictionary<string, string> objRecv)
        {
            bool bResult = false;
            try
            {
                HttpSendClass ThisSendData = new HttpSendClass();
                ThisSendData.data = SendData;

                string ThisUrl = MyStart.gszHttpSrv;// SrvUrl;// + "/"  + HttpCmd;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ThisUrl);
                request.Method = "POST";
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json";
                request.Accept = "*/*";
                request.Timeout = 15000;
                request.AllowAutoRedirect = false;

                // Send Order
                string sOrder = SendData;// ObjToJson<HttpSendClass>(ThisSendData);
                //sOrder = "{\"kv\":1,\"dn\":\"90000001\",\"nc\":\"20171122220809031\",\"data\":\"XuZOwUeF9GP434d9wQP4FaIdL76il+okXYWTDGwvZxDiMISld4cWiZlNXua3W0z+q5FQ6MAC0Oke/o3fw6qY9Q==\",\"sign\":\"0d94466ce73af685f473bf722f8d9e11\"}";
                //save to log -- add by lily 2018.09.20 
                MyIniFile.WriteLog("HTTP", "Send=" + sOrder);
                using (StreamWriter requestStream = new StreamWriter(request.GetRequestStream()))
                {
                    requestStream.Write(sOrder);
                }

                // Receive ReturnBag
                string szRecv = "";
                //HttpReceClass ReceClass = new HttpReceClass();
                Dictionary<string, string> objItem;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default))// Encoding.GetEncoding("GBK")))//Encoding.UTF8))
                    {
                        szRecv = reader.ReadToEnd();
                        //save to log -- add by lily 2018.09.20 
                        MyIniFile.WriteLog("HTTP", "Recv=" + szRecv);
                    }                    

                    //ReceClass = "";// JsonToT<HttpReceClass>(sStr);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    objItem= js.Deserialize<Dictionary<string,string>>(szRecv);
                }
                objRecv = objItem;

                // 是否失败
                if (!objItem.ContainsKey("rc"))//无返回码
                {
                    sErrMsg = "返回的数据中无返回码rc";
                    goto Eend;
                }
                if(objItem["rc"].ToString()!="00")
                {
                    sErrMsg = "rc="+objItem["rc"]+"("+objItem["rcDetail"]+")";
                    goto Eend;
                }

                // check Sign
                string szSrcSign = objItem["sign"];
                objItem.Remove("sign");
                objItem.Add("key", szKey);

                string szDstSign = "";
                bool bRst=GetReqSign(objItem,ref szDstSign);
                if (szSrcSign.CompareTo(szDstSign.ToLower())!=0)
                {
                    sErrMsg = "Receive data Sign Err.（cal sign="+szDstSign+")";
                    goto Eend;
                }
                //objItem.Remove("key");
                objItem.Add("sign", szSrcSign);

                //check txnId ,key
                if(HttpCmd.CompareTo(objItem["txnId"])!=0)
                {
                    sErrMsg = "Receive data txnId Err.";
                    goto Eend;
                }
                if (szKey.CompareTo(objItem["key"]) != 0)
                {
                    sErrMsg = "Receive data key Err.";
                    goto Eend;
                }
                sErrMsg = "HttpPost success.";
                bResult = true;
            }
            catch (Exception ex)
            {
                sErrMsg = "HttpPost Exception = " + ex.Message;
                //save to log -- add by lily 2018.09.20 
                MyIniFile.WriteLog("HTTP", "Oper err=" + ex.Message);
            }
        Eend:
            return bResult;
        }
        public bool HttpSendRecv(Dictionary<string, string> SendData, string szCmd,string szKey, ref Dictionary<string, string> RecvData,ref string szErr)
        {
            bool bRst = false;
            //1 disp send data
            string szSignKey = szKey;
            SendData.Add("key", szSignKey);//签名Key                
            //Disp("发送的数据为：", ref listBoxRst_EB);
            //foreach (KeyValuePair<string, string> kvp in SendData)
            //    Disp(kvp.Key.ToString().Trim() + "=" + kvp.Value.ToString().Trim(), ref listBoxRst_EB);

            //2 cal Sign
            string szSign = "";
            bRst = GetReqSign(SendData, ref szSign);
            if (!bRst)
            {
                //Disp(szSign, ref listBoxRst_EB);
                //Disp("", ref listBoxRst_EB);
                //返回错误信息，加代码
                szErr = "计算签名失败";
                return bRst;
            }
            SendData.Add("sign", szSign);//String(32)  M   M   在请求消息中为请求的参数签名，在响应消息中为响应的参数签名。
            //Disp("sign=" + SendData["sign"].ToString().Trim(), ref listBoxRst_EB);
            //Disp("", ref listBoxRst_EB);

            //3 HTTP
            SendData.Remove("key");
            //Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = GetReqJson(SendData, szCmd, szSignKey, ref RecvData);
            //Disp("接收到的数据为：", ref listBoxRst_EB);
            //foreach (KeyValuePair<string, string> kvp in RecvData)
            //    Disp(kvp.Key.ToString().Trim() + "=" + kvp.Value.ToString().Trim(), ref listBoxRst_EB);
            //Disp("", ref listBoxRst_EB);
            //if (!bRst)
            //{
            //    //Disp("返回信息错误：" + ThisEbHttpClass.ErrMsg, ref listBoxRst_EB);
            //    //Disp("", ref listBoxRst_EB);
            //    //返回错误信息，加代码
            //    szErr = "JSON序列化失败";
            //    return bRst;
            //}
            if (!RecvData.ContainsKey("rc"))//无返回码
            {
                szErr = "返回的数据中无返回码rc";
                return bRst;
            }
            if (RecvData["rc"] != "00")
            {
                szErr = "返回错误信息(rc=" + RecvData["rc"] + ")," + RecvData["rcDetail"];
                return bRst;
            }
            if (SendData.ContainsKey("tellerNo") && RecvData.ContainsKey("tellerNo"))
            {
                if (SendData["tellerNo"].CompareTo(RecvData["tellerNo"]) != 0)
                {
                    //Disp("发起方操作员(tellerNo)发送与接收的不一致，send=" + SendData["tellerNo"] + ",recv=" + RecvData["tellerNo"], ref listBoxRst_EB);
                    //Disp("", ref listBoxRst_EB);
                    //返回错误信息，加代码
                    szErr = "发起方操作员(tellerNo)发送与接收的不一致，send=" + SendData["tellerNo"] + ",recv=" + RecvData["tellerNo"];
                    return bRst;
                }
            }
            if (SendData.ContainsKey("linkMan") && RecvData.ContainsKey("linkMan"))
            {
                if (SendData["linkMan"].CompareTo(RecvData["linkMan"]) != 0)
                {
                    //Disp("用户/会员ID(linkMan)发送与接收的不一致，send=" + SendData["linkMan"] + ",recv=" + RecvData["linkMan"], ref listBoxRst_EB);
                    //Disp("", ref listBoxRst_EB);
                    //返回错误信息，加代码
                    szErr = "用户/会员ID(linkMan)发送与接收的不一致，send=" + SendData["linkMan"] + ",recv=" + RecvData["linkMan"];
                    return bRst;
                }
            }
            return true;
        }

        //计算签名
        public bool GetReqSign(Dictionary<string, string> objItem,ref string szSign)
        {
            bool bResult = false;
            //1 sort item
            SortedDictionary<string, string> objSortItem = new SortedDictionary<string, string>(objItem);
            string szNew = "";
            foreach (KeyValuePair<string, string> kvp in objSortItem)
            {
                if (kvp.Value == "")
                    continue; 
                szNew += kvp.Key.ToString() + "=" + kvp.Value.ToString() + "&";
            }
            szNew = szNew.Substring(0, szNew.Length - 1);

            //2 cal sign
            bResult=MyCryptClass.Sign_SHA256(szNew, ref szSign);
            szSign = szSign.ToLower();
            return bResult;
        }

        public bool GetReqJson(Dictionary<string, string> ThisSendData,string szCmd, string szKey, ref Dictionary<string, string> ThisReceString)
        {
            bool bResult = false;

            try
            {
                //1 turn to json
                string sOpenStr= (new JavaScriptSerializer()).Serialize(ThisSendData);

                //2 http
                Dictionary<string, string> sResultString = new Dictionary<string, string>();
                if (!HttpPost(szCmd, sOpenStr,szKey, ref sResultString))
                {
                    ThisReceString = sResultString;
                    goto ErrEnd;
                }

                ThisReceString = sResultString;
                bResult = true;
                sErrMsg = "SUCC";
            }
            catch (Exception ex)
            {
                sErrMsg = "Exception = " + ex.Message;
            }
        ErrEnd:
            return bResult;
        }

        public bool HttpReg(ref string szErr)
        {//Disp(" ========== 会员帐户注册 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "104");//String(4)   M   R   VIRACC_REG（数值为104）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID,  
            //SendData.Add("pan", "");//String(19)  C   M   卡号
            //1)	如果请求时上送实体卡号，则用openid直接绑定实体卡号。
            //2)	如果请求时未上送实体卡号，卡系统分配给APP的虚拟卡号
            int iLen = frm_Main.mszNetTel.Length;
            if (iLen != 11)
                SendData.Add("mobile", "11122233344");//String(12)  M R   手机，随便录入
            else
                SendData.Add("mobile", frm_Main.mszNetTel);

            string szName = frm_Main.mszNetName;
            byte[] ucName = Encoding.UTF8.GetBytes(szName);
            szName = Convert.ToBase64String(ucName);
            SendData.Add("custName", szName);//String(40)  C - 持卡人姓名，改为设备名称与编号
            //SendData.Add("sex", "M");//String(1)   C -     性别（’F’－女 ‘M’－男）
            //SendData.Add("authNo", "123456");// String(6)   C -     短信验证码（第三方调用时，调用方自己内部验证，无需上送）
            //SendData.Add("certNo", "");//String(18)  C -     证件号码
            //SendData.Add("birthday", "19901231");//String(8)   C -      生日格式：yyyymmdd
            //SendData.Add("email", "a@123.com");//String(50)  C -     Email
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "104", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
            {
                if(RecvData["rc"]!= "W2")//虚拟ID重复注册
                    return bRst;
            }
            
            if (SendData["mobile"].CompareTo(RecvData["mobile"]) != 0)
            {
                //Disp("手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"], ref listBoxRst_EB);
                //Disp("", ref listBoxRst_EB);
                szErr = "手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"];
                return false;
            }

            string szSql = "update base_net set flag='Y' where id=" + frm_Main.mID;
            int iRst = MyStart.oMyDb.WriteData(szSql, ref szErr);
            if (iRst <= 0)
            {
                szErr = "改写注册标识失败( " + szErr+" )";
                return false;
            }
            frm_Main.mbHaveReg = true;
            return true;
        }

        public bool GetPwdCrypt(string szCard,string szPwd,ref string szPin, ref string szErr)
        {//获取卡密码密文 Disp(" ========== 卡密码明文加密 ========== ", ref listBoxRst_EB);
            bool bRst=false;
            szPin = "";
            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "W505");//String(4)   M   R   ENC_PINDATA（数值为W505）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID,  
            SendData.Add("pan", szCard);//String(19)  M   R   实体卡的卡号
            SendData.Add("pinData", szPwd);//String(16)  M  M     卡密码  1、请求上送密码明文；2、返回加密后的密码密文
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "W505", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            if (RecvData.ContainsKey("pinData"))
                szPin = RecvData["pinData"];
            return true;
        }

        public bool IssueNewFirmCard(string szCardM,string szCardV,string szName,string szTel,string szCert, ref string szPwd, ref string szErr)
        {//发商户卡            // Disp(" ========== 商户资料修改 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                MyFunc.GetNetInf(ref szErr);
                if (szErr.Length > 0)
                    return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "52");//String(4)   M   R   52
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID,  
            SendData.Add("pan", szCardV);//String(19)  M   M   结算卡号
            SendData.Add("mid", szCardM);//String(15)  M   R   商户号
            byte[] ucName = Encoding.UTF8.GetBytes(szName);
            szName = Convert.ToBase64String(ucName);
            SendData.Add("custName", szName);//String(40)  M -   商户名称
            //SendData.Add("sex", "M");//String(1)   C C     性别（’F’－女 ‘M’－男）
            //SendData.Add("mobile", "15380898811");// String(12)  C   C   手机
            SendData.Add("phone", szTel);// String(12)  C   C   电话
            //SendData.Add("certType", "123456");// String(1)   C       证件类别
            SendData.Add("certNo", szCert);//String(18)  C -     证件号码
            //SendData.Add("email", "a@123.com");//String(60)  C -     Email            SendData.Add("key", mszSignKey);//签名Key  
            //SendData.Add("custAddr", "");//String(100)	C	C	地址
            //SendData.Add("birthday", "19901231");//String(8)   C -      生日格式：yyyymmdd
            //SendData.Add("smsTag", "1");//	String(1)	C	C	是否愿意接收短消息0 – 否；1 – 是                     
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间
            //SendData.Add("memo", "");//String(100) C       备注
            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "52", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            if (SendData["pan"].CompareTo(RecvData["pan"]) != 0)
            {
                //Disp("卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"], ref listBoxRst_EB);
                //Disp("", ref listBoxRst_EB);
                szErr = "结算卡的卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"];
                return false;
            }
            if (SendData["mid"].CompareTo(RecvData["mid"]) != 0)
            {
                //Disp("商户号(mid)发送与接收的不一致，send=" + SendData["mid"] + ",recv=" + RecvData["mid"], ref listBoxRst_EB);
                //Disp("", ref listBoxRst_EB);
                szErr = "商户号(mid)发送与接收的不一致，send=" + SendData["mid"] + ",recv=" + RecvData["mid"];
                return false;
            }

            if(szPwd.Length==0)//副卡注册，无密码
                return bRst;

            string szOldPwd = "";
            bRst = GetPwdCrypt(szCardV, "888888", ref szOldPwd, ref szErr);
            if (!bRst)
                return bRst;

            if (szPwd.Length==6)
            {
                string szPin = "";
                bRst = GetPwdCrypt(szCardV, szPwd, ref szPin, ref szErr);
                if (!bRst)
                    return bRst;
                szPwd = "2," + szPin;
                bRst = ChgPwd(szCardV, szOldPwd, ref szPwd, ref szErr);
                if (!bRst)
                    return bRst;

                szPwd = szPin;
            }
            return bRst;
        }

        public bool IssueNewUserCard(string szCard,string szName, string szCell,string szCertID,ref string szPwd, ref string szErr)
        {//发会员卡            // Disp(" ========== 会员卡绑定 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst=HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }
            
            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "51");//String(4)   M   R   VIRACC_BIND（数值为105）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  M   R   实体卡的卡号
            SendData.Add("mobile", szCell);//String(12)  M R   手机
            SendData.Add("certNo", szCertID);//String(18)  C -     证件号码
            byte[] ucName = Encoding.UTF8.GetBytes(szName);
            szName = Convert.ToBase64String(ucName);
            SendData.Add("custName", szName);//String(40)  C - 持卡人姓名
            string[] szItem = szPwd.Split(',');
            string szPin = "";
            if (szItem[0] == "1")//明文
            {
                bRst = GetPwdCrypt(szCard, szItem[1], ref szPin, ref szErr);
                if (!bRst)
                    return bRst;
                szPwd = szPin;
            }
            else//密文
            {
                szPin = szItem[1];
                szPwd = szItem[1];
            }
            //SendData.Add("pinData", szPin);//String(16)  M -     密码密文  ???   如何得到
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "51", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            //chg pwd
            string szOldPwd = "";
            bRst = GetPwdCrypt(szCard, "888888", ref szOldPwd, ref szErr);
            if (!bRst)
                return bRst;
            szPwd = "2," + szPin;
            bRst = ChgPwd(szCard, szOldPwd, ref szPwd, ref szErr);
            if (!bRst)
                return bRst;

            //if (SendData["pan"].CompareTo(RecvData["pan"]) != 0)
            //{
            //    //Disp("实体卡的卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"], ref listBoxRst_EB);
            //    //Disp("", ref listBoxRst_EB);
            //    szErr = "实体卡的卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"];
            //    return false;
            //}
            //if (SendData["mobile"].CompareTo(RecvData["mobile"]) != 0)
            //{
            //    //Disp("手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"], ref listBoxRst_EB);
            //    //Disp("", ref listBoxRst_EB);
            //    szErr = "手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"];
            //    return false;
            //}
            return true;
        }

        public bool ChgUserInf(string szCard, string szName, string szCell, string szCertID, ref string szErr)
        {//修改会员信息（非卡号信息）            // Disp(" ========== 会员卡绑定 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "51");//String(4)   M   R   VIRACC_BIND（数值为105）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  M   R   实体卡的卡号
            SendData.Add("mobile", szCell);//String(12)  M R   手机
            SendData.Add("certNo", szCertID);//String(18)  C -     证件号码
            byte[] ucName = Encoding.UTF8.GetBytes(szName);
            szName = Convert.ToBase64String(ucName);
            SendData.Add("custName", szName);//String(40)  C - 持卡人姓名
            
            //SendData.Add("pinData", szPin);//String(16)  M -     密码密文  ???   如何得到
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "51", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            //if (SendData["pan"].CompareTo(RecvData["pan"]) != 0)
            //{
            //    //Disp("实体卡的卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"], ref listBoxRst_EB);
            //    //Disp("", ref listBoxRst_EB);
            //    szErr = "实体卡的卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"];
            //    return false;
            //}
            //if (SendData["mobile"].CompareTo(RecvData["mobile"]) != 0)
            //{
            //    //Disp("手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"], ref listBoxRst_EB);
            //    //Disp("", ref listBoxRst_EB);
            //    szErr = "手机(mobile)发送与接收的不一致，send=" + SendData["mobile"] + ",recv=" + RecvData["mobile"];
            //    return false;
            //}
            return true;
        }

        public bool ChgPwd(string szCard,string szOldPwd, ref string szNewPwd, ref string szErr)
        {//Disp(" ========== 会员卡支付密码修改 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            string[] szItem = szNewPwd.Split(',');
            string szPin = "";
            if (szItem[0] == "1")//明文
            {
                bRst = GetPwdCrypt(szCard, szItem[1], ref szPin, ref szErr);
                if (!bRst)
                    return bRst;
                szNewPwd = szPin;
            }
            else//密文
            {
                szPin = szItem[1];
                szNewPwd = szItem[1];
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "72");//String(4)   M   R   CHG_PIN（数值为72）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  C   C   实体卡的卡号
            //SendData.Add("authNo", "123456");//String(6)   C   C   短信验证码
            SendData.Add("pinData", szOldPwd);//String(16)  M  -     原密码密文
            SendData.Add("newPin", szNewPwd);//String(16)  M  -     新密码密文
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间
            //SendData.Add("memo", "");//String(40)  C -      备注

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "72", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            return true;
        }

        public bool ChangeCard(string szOldCard,string szNewCard,string szWhy,decimal dPaid,ref string szPwd, ref string szErr)
        {//Disp(" ========== 会员卡换卡 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "25");//String(4)   M   R   25
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("pan", szNewCard);//String(19)  C   R   实体卡的卡号
            SendData.Add("oldPan", szOldCard);//String(19)  M   M   原卡号
            SendData.Add("reason", szWhy);//String(2)   M   M   换卡原因
            if(dPaid > 0)
            {
                SendData.Add("paid", "0");//String(2)   M   M   换卡手续费
                SendData.Add("txnFee", dPaid.ToString("#0.00"));//String(2)   M   M   换卡手续费
            }
            else
            {
                SendData.Add("paid", "1");//String(2)   M   M   换卡手续费
            }

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "25", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            bRst = GetPwdCrypt(szNewCard, szPwd, ref szPwd, ref szErr);
            if (!bRst)
                return bRst;

            return true;
        }
        public bool LostCard(bool bIsLost,string szCard, ref string szErr)
        {//Disp(" ========== 会员卡挂失/解挂 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            string szCmd = "31";//挂失
            if (!bIsLost)
                szCmd = "32";//解挂
            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", szCmd);//String(4)   M   R   25
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("pan", szCard);//String(19)  M   R   实体卡的卡号

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, szCmd, frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            return true;
        }

        public bool CheckPwd(string szCard,string szPwd, ref string szErr)
        {//            Disp(" ========== 会员卡交易验密 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            string szPin = szPwd;
            if (szPin.Length != 6)
            {
                szErr = "卡密码长度错误";//"请先执行指令：卡密码明文加密";
                return bRst;
            }
            bRst = GetPwdCrypt(szCard, szPin, ref szPwd, ref szErr);
            if(!bRst)
            {
                szErr = "获取密码密文失败，" + szErr;
                return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "223");//String(4)   M   R   VERIFY_PIN（数值为223）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  C   C   实体卡的卡号
            SendData.Add("pinData", szPwd);//String(16)  M  -     持卡人密码密文
            //rc  String(4)     - M   交易返回码 “00”表示成功
            //rcDetail    String(20)    - M   返回码解释
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "223", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            return true;
        }
        public bool TransMoney(string szFirm,string szCard, string szPwd, ref string szErr)
        {//Disp(" ========== 商户结款会员卡 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            //bRst = CheckPwd(szCard, szPwd, ref szErr);
            //if (!bRst)
            //    return bRst;


            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "18");//String(4)   M   R   18
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  M   M   卡号
            SendData.Add("mid", szFirm);//String(15)  M   R   商户号

            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "18", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            return true;
        }

        public bool OperUserMoney(string sDo, string szCard,double iVal,string szSysID,string szPwd,ref string szErr)
        {//金额为正，表示充值；金额为负，表示退款 Disp(" ========== 会员卡充值 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            if (sDo == "MinusVal")
            //if(szPwd.Length>0)//退款需要验密码
            {   //交易验密码
                bRst = CheckPwd(szCard, szPwd, ref szErr);
                if (!bRst)
                    return bRst;
            }
            else // if (sDo == "AddVal")
            {
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "20");//String(4)   M   R   CHARGE（数值为20）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  M   R   卡号，与linkMan相同
            SendData.Add("trAmt", iVal.ToString("#0.00"));// "1000.00");//Number(12, 2)    M   R   充值金额
            //SendData.Add("voucher", DateTime.Now.ToString("yyyyMMdd") + mID.ToString("000000"));//String(20)  M   R   单据号格式为：YYYYMMDD + 最大12位顺序号，不可重复
            SendData.Add("voucher", szSysID);//String(20)  M   R   单据号格式为：YYYYMMDD + 最大12位顺序号，不可重复
            SendData.Add("accType", "1");//String(1)   M       账户类型（1 - 储值 2 - 赠送，即返利） 默认为储值账户。
            SendData.Add("payMnr", "1");//String(1)   M       付款方式  1：储蓄卡 / 借记卡2：信用卡
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间
            //SendData.Add("memo", "");//String(100) C       备注
            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "20", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            /*if (SendData["pan"].CompareTo(RecvData["pan"]) != 0)
            {
                Disp("卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (SendData["trAmt"].CompareTo(RecvData["trAmt"]) != 0)
            {
                Disp("充值金额(trAmt)发送与接收的不一致，send=" + SendData["trAmt"] + ",recv=" + RecvData["trAmt"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (SendData["voucher"].CompareTo(RecvData["voucher"]) != 0)
            {
                Disp("充值单据号(voucher)发送与接收的不一致，send=" + SendData["voucher"] + ",recv=" + RecvData["voucher"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (RecvData.ContainsKey("rrn"))
                m_rrn = RecvData["rrn"];*/
            return true;
        }
        public bool OperFirmMoney(string szFirm, string szCard, double iVal, string szSysID, string szPwd, ref string szErr)
        {//金额为正，表示充值；金额为负，表示退款 Disp(" ========== 会员卡充值 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            //if (szPwd.Length > 0)//取款需要验密码
            {//交易验密码
                bRst = CheckPwd(szCard, szPwd, ref szErr);
                if (!bRst)
                    return bRst;
            }

            //if (iVal<0)//提款
            //{//商户结算卡，要先结款，再取款
            //    bRst = TransMoney(szFirm, szCard, ref szErr);
            //    if (!bRst)
            //        return bRst;
            //}

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "20");//String(4)   M   R   CHARGE（数值为20）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  M   R   卡号，与linkMan相同
            SendData.Add("trAmt", iVal.ToString("0.00"));// "1000.00");//Number(12, 2)    M   R   充值金额
            //SendData.Add("voucher", DateTime.Now.ToString("yyyyMMdd") + mID.ToString("000000"));//String(20)  M   R   单据号格式为：YYYYMMDD + 最大12位顺序号，不可重复
            SendData.Add("voucher", szSysID);//String(20)  M   R   单据号格式为：YYYYMMDD + 最大12位顺序号，不可重复
            SendData.Add("accType", "1");//String(1)   M       账户类型（1 - 储值 2 - 赠送，即返利） 默认为储值账户。
            SendData.Add("payMnr", "1");//String(1)   M       付款方式  1：储蓄卡 / 借记卡2：信用卡
            //SendData.Add("txnDate", DateTime.Now.ToString("yyyyMMdd"));//String(8)   C   M   交易日期
            //SendData.Add("txnTime", DateTime.Now.ToString("HHmmss"));//String(6)   C   M   交易时间
            //SendData.Add("memo", "");//String(100) C       备注
            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "20", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            /*if (SendData["pan"].CompareTo(RecvData["pan"]) != 0)
            {
                Disp("卡号(pan)发送与接收的不一致，send=" + SendData["pan"] + ",recv=" + RecvData["pan"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (SendData["trAmt"].CompareTo(RecvData["trAmt"]) != 0)
            {
                Disp("充值金额(trAmt)发送与接收的不一致，send=" + SendData["trAmt"] + ",recv=" + RecvData["trAmt"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (SendData["voucher"].CompareTo(RecvData["voucher"]) != 0)
            {
                Disp("充值单据号(voucher)发送与接收的不一致，send=" + SendData["voucher"] + ",recv=" + RecvData["voucher"], ref listBoxRst_EB);
                Disp("", ref listBoxRst_EB);
            }
            if (RecvData.ContainsKey("rrn"))
                m_rrn = RecvData["rrn"];*/
            return true;
        }

        public bool QryCard(string szCard,ref int iVal,ref int iTrade, ref string szErr)
        {//可查询余额            Disp(" ========== 会员帐户资料查询 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "50");//String(4)   M   R   MST_INQ（数值为50）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("pan", szCard);//String(19)  C   M   卡号
            if(iTrade>0)//商户查未结算金额
                SendData.Add("reason", "2");//String(1)   C -      查询目的，查询动态条码 / 二维码填1
            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "50", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;

            string szVal="";
            if (RecvData.ContainsKey("balAmt"))
                szVal = RecvData["balAmt"];

            iVal =Convert.ToInt32 (Convert.ToDecimal(szVal) * 100);
            if (iTrade > 0)//商户查未结算金额
            {
                if (RecvData.ContainsKey("email"))
                    szVal = RecvData["email"];
                if (szVal == "")
                    szVal = "0";
                iTrade = Convert.ToInt32(Convert.ToDecimal(szVal) * 100);
            }
            return true;
            /* 查询示例，余额4700元
             * 2017-11-30 15:43:08  ========== 会员帐户资料查询 ========== 
2017-11-30 15:43:08 发送的数据为：
2017-11-30 15:43:08 txnId=50
2017-11-30 15:43:08 tellerNo=YtbHttpAccessor
2017-11-30 15:43:08 linkMan=0000001
2017-11-30 15:43:08 key=408022a56b52e57f
2017-11-30 15:43:08 sign=d747ed4e784a38ace51260b85fc366c5b8a0ca4bf0b771c608a15514be4e190c
2017-11-30 15:43:08 
2017-11-30 15:43:08 接收到的数据为：
2017-11-30 15:43:08 birthday=
2017-11-30 15:43:08 accno=8807600040000288
2017-11-30 15:43:08 key=408022a56b52e57f
2017-11-30 15:43:08 linkMan=0000001
2017-11-30 15:43:08 trk3=
2017-11-30 15:43:08 lastScore=0.00
2017-11-30 15:43:08 txnTime=154341
2017-11-30 15:43:08 panMac=
2017-11-30 15:43:08 vipCls=1
2017-11-30 15:43:08 pan=8807600040000288
2017-11-30 15:43:08 email=
2017-11-30 15:43:08 cardStatus=0
2017-11-30 15:43:08 balAmt3=
2017-11-30 15:43:08 sex=
2017-11-30 15:43:08 mobile=15380898811
2017-11-30 15:43:08 custAddr=
2017-11-30 15:43:08 custName=
2017-11-30 15:43:08 cardBegindate=20171129
2017-11-30 15:43:08 currScore=0.00
2017-11-30 15:43:08 bindFlag=0
2017-11-30 15:43:08 rc=00
2017-11-30 15:43:08 certNo=
2017-11-30 15:43:08 smsTag=
2017-11-30 15:43:08 tellerNo=YtbHttpAccessor
2017-11-30 15:43:08 phone=
2017-11-30 15:43:08 balAmt=4700.00
2017-11-30 15:43:08 cardExpdate=20250831
2017-11-30 15:43:08 txnDate=20171130
2017-11-30 15:43:08 cardStatusName=5q2j5bi45oi3
2017-11-30 15:43:08 txnId=50
2017-11-30 15:43:08 rcDetail=承兑或交易成功
2017-11-30 15:43:08 sign=6694c7f27090b1930d11578968db8d3a54fdccb21d8fdfab840b0b9a8499da7c
             */
        }

        public bool QryTrade(string szCard,string szBgn,string szEnd,ref string szErr)
        {//            Disp(" ========== 会员卡交易查询 ========== ", ref listBoxRst_EB);
            bool bRst = false;
            szErr = "";
            if (!frm_Main.mbHaveReg)
            {
                bRst = HttpReg(ref szErr);
                if (!bRst)
                    return bRst;
            }

            Dictionary<string, string> SendData = new Dictionary<string, string>();
            SendData.Add("txnId", "W900");//String(4)   M   R    SEARCH_TRNAS（W900）
            SendData.Add("tellerNo", frm_Main.mszTellerNo);//String(20)  M   R   发起方操作员 
            SendData.Add("linkMan", frm_Main.mID.ToString("0000000"));//String(40)  M   R   用户 / 会员ID
            SendData.Add("queryType", "2");//String(1)   M -     查询类型   1：分页查询明细    2：查询所有明细
            SendData.Add("pan", szCard);//String(19) C   C  卡号
            SendData.Add("txnDateFrom", szBgn);// DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));// String(8)   M -     起始交易日期格式：yyyy - mm - dd
            SendData.Add("txnDateTo", szEnd);//DateTime.Now.ToString("yyyy-MM-dd"));//   String(8)   M -     结束交易日期格式：yyyy - mm - dd
            //transArray JSONArray       O 交易明细，trans数组，参考此章节
            //SendData.Add("currentPage", "");// String(6)   C       当前查询页码（queryType = 1时必填）
            //SendData.Add("pageRow", "");// String(6)   C       每页记录数（queryType = 1时必填）
            Dictionary<string, string> RecvData = new Dictionary<string, string>();
            bRst = HttpSendRecv(SendData, "W900", frm_Main.mszKey, ref RecvData, ref szErr);
            if (!bRst)
                return bRst;
            //if (RecvData.ContainsKey("pan"))
            //    m_user_card = RecvData["pan"];
            return true;
        }
    }
}
