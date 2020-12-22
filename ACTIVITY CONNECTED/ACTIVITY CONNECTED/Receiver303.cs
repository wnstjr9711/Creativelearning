using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;

namespace ACTIVITY_CONNECTED
{
    public class Receiver303
    {
        public string ID = "";
        public string Content = "";
        public string Color = "";
        public string Time = "";
        public bool connected = false;
        public bool test = false;
        public byte ComNo = 3;

        [DllImport("RF303s_Com.dll")]
        public static extern bool Set_Hnd_MsgNo(IntPtr AppH, IntPtr WndH, int MsgNo);
        [DllImport("RF303s_Com.dll")]
        public static extern bool CloseHnd();
        [DllImport("RF303s_Com.dll")]
        public static extern int Connect(Byte CommPort, byte MaxID, Byte PortType, int Sn1, int Sn2, int Sn3, int Sn4, int Sn5, int Sn6, int Sn7, int Sn8, Byte ReceiveId);
        [DllImport("RF303s_Com.dll")]
        public static extern int DisConnect(Byte CNo);
        [DllImport("RF303s_Com.dll")]
        public static extern int Open_Base(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int Close_Base(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int Stop_Base(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int Set_Id_331(Byte CommPort, Byte LedId, Byte Para1, Byte Group, Byte Row, Byte Col);
        [DllImport("RF303s_Com.dll")]
        public static extern int PrevSetIdPage(Byte mBase, int LedId, Byte Flag, Byte Lum, Byte mR, Byte mG, Byte mB);       //0-3839
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateOneId(Byte mBase, int LedId, Byte Flag, Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateAllIdSame(Byte mBase, Byte Lum, Byte Flag, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateIdPage(Byte mBase, bool ResetTime);
        [DllImport("RF303s_Com.dll")]
        public static extern int SetSleep(Byte mBase, Byte Sleep_Count, Byte Off_Count, Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int SetAwake(Byte mBase, Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int SetAllLum(Byte mBase, Byte LumValue);
        [DllImport("RF303s_Com.dll")]
        public static extern int StartVote(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int StartPing(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int ResetTime(Byte mBase);
        [DllImport("RF303s_Com.dll")]
        public static extern int StopVote(Byte mBase);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpszClass, string lpszWindow);

        public void SetMsgNo(IntPtr handle)
        {
            IntPtr vHandle = FindWindow("TestRF303S", null);
            Set_Hnd_MsgNo(vHandle, handle, 111);
        }
        public unsafe void WndP(byte* ss)
        {
            byte[] tempi = new byte[200];
            int i = 0;
            int StrLen = 0;
            while (ss[i] != 0)
            {
                tempi[i] = Convert.ToByte(ss[i]);// int.Parse((ss[i].ToString()));
                i++;
                StrLen++;
            }
            switch (tempi[0])
            {
                case 1:
                    ID = Encoding.ASCII.GetString(tempi, 1, 3).Substring(1, 2);
                    Content = Encoding.ASCII.GetString(tempi, 4, 2);
                    Color = Encoding.ASCII.GetString(tempi, 6, 10);
                    Time = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), DateTime.Now.Millisecond.ToString("000").Substring(0, 2));
                    Thread thread = new Thread(new ParameterizedThreadStart(Pressed));
                    thread.Start(ID);
                    break;
                case 3:  // "Set ID"
                    if (tempi[4] == 0x41)
                    {
                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    break;
            }
        }
        private void Pressed(object id)
        {
            UpdateOneId(ComNo, Convert.ToInt32(id) - 1, 0, 0, 1, 1, 1);
            Thread.Sleep(500);
            UpdateOneId(ComNo, Convert.ToInt32(id) - 1, 0, 0, 0, 0, 0);
        }
        public bool SetConnection()
        {
            if (Connect(ComNo, 64, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) == 1)
            {
                return connected = true;
            }
            else
            {
                return false;
            }
        }
        public void TestConnection()
        {
            if (!connected)
            {
                MessageBox.Show("수신기를 연결하시오.");
                return;
            }
            switch (test)
            {
                case false:
                    {
                        test = true;
                        StartVote(ComNo);
                        break;
                    }
                case true:
                    {
                        test = false;
                        StopVote(ComNo);
                        break;
                    }
            }
        }
        public void ChangeID(string id)
        {
            if (!connected)
            {
                MessageBox.Show("수신기를 연결하시오.");
                return;
            }
            Set_Id_331(ComNo, (byte)(Convert.ToByte(id) - 1), 0, 0, 0, 0);
        }
    }
}
