using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;//for comm port
//using System.Threading;//for sleep

namespace YTB
{
    public class CIcRdr
    {
        SerialPort ReaderCom = new SerialPort();
        private bool bComIsOpen;
        private string szErr;
        //private string szCardNo;
        //private string szCardTrack;

        public byte[] bPsamID = new byte[30];

        const byte ThisTag = 0x09;
        const byte ThisVer = 0x04;
        const byte ThisNum = 0x00;
        public bool ComIsOpen
        {
            get
            {
                return bComIsOpen;
            }
        }


        public bool ComOpen(string sComPort)
        {
            bool bResult = false;

            try
            {
                if (!bComIsOpen)
                {
                    ReaderCom.PortName = sComPort;                     
                    ReaderCom.BaudRate = int.Parse(MyStart.gszRdrBaud);
                    //ReaderCom.DataBits = 8;
                    //ReaderCom.StopBits = StopBits.One;
                    ReaderCom.ReadBufferSize = 2000;
                    //ReaderCom.DataReceived += new SerialDataReceivedEventHandler(ReaderDataReceived);
                    ReaderCom.ReadTimeout = 30;
                    ReaderCom.Open();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                string ErrMsg = "打开串口时出错：" + ex.Message;
            }
            bComIsOpen = ReaderCom.IsOpen;
            bResult = bComIsOpen;
            return bResult;
        }

        public void ComClose()
        {
            if (ReaderCom.IsOpen)
            {
                ReaderCom.Close();
            }
            bComIsOpen = ReaderCom.IsOpen;
        }

        public bool Link()
        {
            bool bResult = false;
            byte[] sData = new byte[30];
            byte[] rData = new byte[30];
            int iRetLen = 0;

            sData[0] = 0x10;
            sData[1] = 0x00;

            //Thread.Sleep(100);
            if (SendOrder(sData, 2, ref rData, ref iRetLen))
            {
                if (rData[0] == 0 && rData[1] == 0 && iRetLen == 2)
                    bResult = true;
            }
            return bResult;
        }

        public bool ReadCardInf(out string szInf)
        {
            szInf = "";
            bool bResult = false;
            byte[] sData = new byte[30];
            byte[] rData = new byte[50];
            int iRetLen = 0;

            sData[0] = 0xA5;
            sData[1] = 0x00;

            //Thread.Sleep(100);
            if (SendOrder(sData, 2, ref rData, ref iRetLen))
            {
                szInf = MyTools.ByteToString(rData, 2, iRetLen);
                if (rData[0] == 0 && rData[1] == 0 && iRetLen == 40)
                    bResult = true;
            }
            return bResult;
        }

        public bool GetPsamID()
        {
            bool bResult = false;
            byte[] sData = new byte[30];
            byte[] rData = new byte[50];
            int iRetLen = 0;

            sData[0] = 0xA1;
            sData[1] = 0x00;

            if (SendOrder(sData, 2, ref rData, ref iRetLen))
            {
                if (rData[0] == 0 && rData[1] == 0 && iRetLen == 25)
                {
                    Array.Copy(rData, 2, bPsamID, 0, 23);
                    frm_Main.FIRM_ID = Encoding.ASCII.GetString(rData, 2, 15);
                    frm_Main.POS_ID = Encoding.ASCII.GetString(rData, 17, 8);
                    bResult = true;
                }
                else
                {
                    frm_Main.FIRM_ID = "";
                    frm_Main.POS_ID = "";
                }
            }
            return bResult;
        }

        public bool GetTradeID(ref int ReadTradeID)
        {
            bool bResult = false;
            byte[] sData = new byte[30];
            byte[] rData = new byte[30];
            int iRetLen = 0;

            sData[0] = 0xA3;
            sData[1] = 0x00;

            if (SendOrder(sData, 2, ref rData, ref iRetLen))
            {
                if (rData[0] == 0 && rData[1] == 0 && iRetLen == 6)
                {
                    ReadTradeID = rData[2] * 256 * 256 * 256 + rData[3] * 256 * 256 + rData[4] * 256 + rData[5];
                    bResult = true;
                }
            }
            return bResult;
        }

        public bool SendOrder(byte[] SData, int SDataLen, ref byte[] RData, ref int RDataLen)
        {
            bool bResult = false;
            byte[] pData = new byte[300];
            int iRLen = 0;

            if (SDataLen <= 0)
                return false;

            // 关闭 FreeRead
            ReaderCom.DiscardInBuffer();
            if (!SendToReader(SData, SDataLen))
            {
                bResult = false;
                goto EEnd;
            }

            if (ReceivedFromReader(ref pData, ref iRLen, 2000))
            {
                Array.Copy(pData, RData, iRLen);
                RDataLen = iRLen;
                bResult = true;
            }

        EEnd:
            //ReaderCom.ReadTimeout = 30;
            return bResult;
        }

        private bool SendToReader(byte[] SData, int SDataLen)
        {
            bool bResult = false;
            byte[] pData;
            byte bXor = 0;
            int i;

            pData = new byte[SDataLen + 5];
            pData[0] = ThisTag;
            pData[1] = ThisVer;
            pData[2] = ThisNum;
            pData[3] = (byte)SDataLen;
            Array.Copy(SData, 0, pData, 4, SDataLen);

            for (i = 0; i < SDataLen + 4; i++)
            {
                bXor ^= pData[i];
            }
            pData[i] = bXor;

            try
            {
                ReaderCom.Write(pData, 0, SDataLen + 5);
                bResult = true;
            }
            catch(Exception ex)
            {
                szErr = "Exception from SendToReader:" + ex.ToString();
            }
            return bResult;
        }
        /*private void ReaderDataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] pData = new byte[100];
            int i = 0;

            if (ReceivedFromReader(ref pData, ref i, 20))
            {
                if (i == 40)
                {
                    szCardNo = MyTools.ByteToString(pData, 0, 8);
                    szCardTrack = MyTools.ByteToString(pData, 8, 30);
                    ReaderOK(EventArgs.Empty);
                }
            }
        }*/
        private bool ReceivedFromReader(ref byte[] RData, ref int RDataLen, int WaitMSecond)
        {
            bool bReault = false;
            //byte[] pData = new byte[300];
            byte b1 = 0/*, b2 = 0*/;
            byte BagLen = 0, /*bCmd = 0, bState = 0,*/ bXor = 0; ;
            int i;
            long lEndTick;

            try
            {
                lEndTick = DateTime.Now.Ticks + WaitMSecond * 10000;
                while (lEndTick >= DateTime.Now.Ticks)
                {
                    bReault = GetByteFromCom(ref b1, ReaderCom);
                    if (bReault && (b1 == ThisTag))
                        break;
                }
                if (!bReault || (b1 != ThisTag))
                    return false;

                bReault = GetByteFromCom(ref b1, ReaderCom);
                if (!bReault || (b1 != ThisVer))
                    return false;

                bReault = GetByteFromCom(ref b1, ReaderCom);
                if (!bReault || (b1 != ThisNum))
                    return false;

                bReault = GetByteFromCom(ref BagLen, ReaderCom);
                if (!bReault)
                    return false;

                bXor = (byte)(ThisTag ^ ThisVer ^ ThisNum ^ BagLen);

                for (i = 0; i < BagLen; i++)
                {
                    bReault = GetByteFromCom(ref RData[i], ReaderCom);
                    if (!bReault)
                        return false;
                    bXor ^= RData[i];
                }

                bReault = GetByteFromCom(ref b1, ReaderCom);
                if (!bReault || (bXor != b1))
                    return false;

                RDataLen = BagLen;
                bReault= true;
            }
            catch (Exception ex)
            {
                szErr = "Exception from ReceivedFromReader:" + ex.ToString();
                bReault= false;
            }
            return bReault;
        }

        private bool GetByteFromCom(ref byte GetByte, SerialPort ThisCom)
        {
            long lEndTick = DateTime.Now.Ticks + 30 * 10000;              // 1ms = 10,000 Tick, wait 10 ms
            try
            {
                while (DateTime.Now.Ticks <= lEndTick)
                {
                    if (ThisCom.BytesToRead > 0)
                    {
                        GetByte = (byte)(ThisCom.ReadByte() & 0xff);
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                szErr = "Exception from GetByteFromCom:" + ex.ToString();
            }
            return false;
        }

        //定义事件委托
        public delegate void ReaderOKEventHandler(object sender, EventArgs e);
        public event ReaderOKEventHandler ReaderOKEvent;
        protected virtual void ReaderOK(EventArgs e)
        {
            if (ReaderOKEvent != null)
            {
                ReaderOKEvent(this, e);
            }
        }
    }
}
