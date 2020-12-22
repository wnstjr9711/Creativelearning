using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Byte ComNo = 3;

        byte maxId=20;// maxId = 400;
     //   int minId = 1;
        string status = "";


        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("RF303s_Com.dll")]
        public static extern bool Set_Hnd_MsgNo(IntPtr AppH, IntPtr WndH, int MsgNo);
        [DllImport("RF303s_Com.dll")]
        public static extern bool CloseHnd();


        [DllImport("RF303s_Com.dll")]
        public static extern int Connect(Byte CommPort, byte  MaxID, Byte PortType, int Sn1, int Sn2, int Sn3, int Sn4, int Sn5, int Sn6, int Sn7, int Sn8, Byte ReceiveId);
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
        public static extern int PrevSetIdPage(Byte mBase,int LedId,Byte Flag, Byte Lum, Byte mR, Byte mG,Byte mB);       //0-3839
  
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateOneId(Byte mBase, int LedId, Byte Flag,Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateAllIdSame(Byte mBase, Byte Lum, Byte Flag,Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int UpdateIdPage(Byte mBase,bool ResetTime);
 
        [DllImport("RF303s_Com.dll")]
        public static extern int SetSleep(Byte mBase, Byte Sleep_Count, Byte Off_Count,Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int SetAwake(Byte mBase, Byte Lum, Byte mR, Byte mG, Byte mB);
        [DllImport("RF303s_Com.dll")]
        public static extern int SetAllLum(Byte mBase,Byte LumValue);
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


        private void ClearInfo()
        {
          //  lblTitle.Text = "";
            lblID.Text = "";
            lblContent.Text = "";
    //        lblModeType.Text = "";
      //      labelQuestionNo.Text = "";
            labelStatus.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr vHandle = FindWindow("TestRF303S", null);
            //System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("Test");
            bool a = Set_Hnd_MsgNo(vHandle, this.Handle, 111);
            //            comboBox1.SelectedItem = "A-F single";
            //          comboBox2.SelectedItem = "One by one";
            comboBoxComNo.SelectedIndex = 0;//.SelectedItem = "Hid";
         //   comboBoxMode.SelectedIndex = 0;
            comboBoxBaseId.SelectedIndex = 0;
            comboBoxPortType.SelectedIndex = 0;//.SelectedItem = "HID";
            comboBoxSn1.SelectedIndex = 0;
            comboBoxSn2.SelectedIndex = 0;
            comboBoxSn3.SelectedIndex = 0;
            comboBoxSn4.SelectedIndex = 0;
            comboBoxSn5.SelectedIndex = 0;
            comboBoxSn6.SelectedIndex = 0;
            comboBoxSn7.SelectedIndex = 0;
            comboBoxSn8.SelectedIndex = 0;

            comboBoxBaseId.SelectedIndex = 0;
            comboBoxBlue.SelectedIndex = 0;
            comboBoxBlue2.SelectedIndex = 0;
            comboBoxBlue3.SelectedIndex = 0;
            comboBoxComNo.SelectedIndex = 0;
            comboBoxGreen.SelectedIndex = 0;
            comboBoxGreen2.SelectedIndex = 0;
            comboBoxGreen3.SelectedIndex = 0;
         //   comboBoxGroupMode.SelectedIndex = 0;
            comboBoxFlag1.SelectedIndex = 0;
            comboBoxFlag2.SelectedIndex = 0;
            comboBoxLum.SelectedIndex = 1;
            comboBoxLum2.SelectedIndex = 1;
            comboBoxLum3.SelectedIndex = 0;
            comboBoxPortType.SelectedIndex = 0;
            comboBoxRed.SelectedIndex = 0;
            comboBoxRed2.SelectedIndex = 0;
            comboBoxRed3.SelectedIndex = 0;
        //    comboBoxType.SelectedIndex = 0;
         //   comboBoxUpdateMode.SelectedIndex = 0;
     //       comboBoxSleepMode.SelectedIndex = 0;
            //        comboBoxSysType.SelectedItem = "RF218";
            labelStatus.Text = a.ToString();
            ClearInfo();


            // initial vote set
   
        }

 
        private int MyConvertToInt(int ComboIndex)
        {
            if (ComboIndex == 0)
            {
                return 0;
            }
            else if (ComboIndex <= 10)
            {
                return 0x30 + ComboIndex - 1;
            }
            else
            {
                return 0x41 + ComboIndex - 11;
            }

        }
        
        //    connect and disconnect
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Byte PortType,BaseId;
            int Sn1, Sn2, Sn3, Sn4, Sn5, Sn6, Sn7, Sn8;

            Sn1 = 0;
            Sn2 = 0;
            Sn3 = 0;
            Sn4 = 0;
            Sn5 = 0;
            Sn6 = 0;
            Sn7 = 0;
            Sn8 = 0;

            ClearInfo();
            maxId =Convert.ToByte(textBoxMaxId.Text);
  //          minId = int.Parse(textBoxMinId.Text);
            if (maxId > 64 || maxId <= 0 )
            {
                MessageBox.Show("Input error!");
                return;
            }

            ComNo = Convert.ToByte(comboBoxComNo.SelectedIndex);
            BaseId = Convert.ToByte(comboBoxBaseId.SelectedIndex);

            PortType = (byte)comboBoxPortType.SelectedIndex;
            if (PortType == 0)
            {
                Sn1 = MyConvertToInt(comboBoxSn1.SelectedIndex);
                Sn2 = MyConvertToInt(comboBoxSn2.SelectedIndex);
                Sn3 = MyConvertToInt(comboBoxSn3.SelectedIndex);
                Sn4 = MyConvertToInt(comboBoxSn4.SelectedIndex);
                Sn5 = MyConvertToInt(comboBoxSn5.SelectedIndex);
                Sn6 = MyConvertToInt(comboBoxSn6.SelectedIndex);
                Sn7 = MyConvertToInt(comboBoxSn7.SelectedIndex);
                Sn8 = MyConvertToInt(comboBoxSn8.SelectedIndex);
            }
            else if (PortType == 1)
            {
                Sn1 = Convert.ToInt32(textBoxIp1.Text);
                Sn2 = Convert.ToInt32(textBoxIp2.Text);
                Sn3 = Convert.ToInt32(textBoxIp3.Text);
                Sn4 = Convert.ToInt32(textBoxIp4.Text);
                Sn5 = Convert.ToInt32(textBoxIpPort.Text);
            }

            if (Connect(ComNo, maxId,  PortType, Sn1, Sn2, Sn3, Sn4, Sn5, Sn6, Sn7, Sn8,BaseId) == 1)
            //if (Connect(ComNo, maxId, minId, 1, 0,0) == 1)  //default cangetmessage, receiveId=0 means is main receiver
            {
                MessageBox.Show("Connect Base OK!");
            }
            else
            {
                MessageBox.Show("Communication Error!");
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            ClearInfo();
            if (DisConnect(ComNo) == 1)
            {
                MessageBox.Show("Disconnect OK!");
            }
            else
            {
                MessageBox.Show("error!");
            }
        }


 
        private void buttonStop_Click(object sender, EventArgs e)
        {
            ClearInfo();
            if (Stop_Base(ComNo) == 1)
            {
            //    MessageBox.Show("Stop receiver OK!");
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

 

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            ClearInfo();
            if (Open_Base(ComNo) != 1)
                MessageBox.Show("Open Error");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (Close_Base(ComNo) != 1)
                MessageBox.Show("Close Error");
        }




        // get message
        protected override void WndProc(ref Message msg)
        {
            unsafe
            {
                if (msg.Msg == 111)
                {
                    byte[] tempi = new byte[200];
//                    byte[] ssB = new byte[250];
  //                  int St_Id;
                    //StringBuilder szUser = new StringBuilder(32);
                    byte* ss = (byte*)msg.LParam.ToPointer();
                    int i=0;
                    int StrLen = 0;
                    while (ss[i] != 0)
                    {
                        tempi[i] = Convert.ToByte(ss[i]);// int.Parse((ss[i].ToString()));
                        i++;
                        StrLen++;
                    }
                    
//                    i = 5;
  //                  
                      string AnswerStr = "";
                      string GetColor = "";
                      string TimeInfo = ""
;      //              while (ss[i] != 0)
        //            {
          //              ssB[StrLen] = ss[i];
            //            i++;
              //          StrLen++;
                //    }
                  //  AnswerStr = Encoding.ASCII.GetString(ssB, 0, StrLen);
                    //                    MessageBox.Show(AnswerStr);
                    switch (tempi[0])
                    {
                        case 1:
                            {
                           //     lblTitle.Text = "Vote answer";
                                lblID.Text = Encoding.ASCII.GetString(tempi, 1, 3);
                                AnswerStr = Encoding.ASCII.GetString(tempi, 4, 2);
                                GetColor = Encoding.ASCII.GetString(tempi, 6, 10);
                                TimeInfo=Encoding.ASCII.GetString(tempi,16,StrLen-14);
                                lblContent.Text = AnswerStr;
                                labelTimeInfo.Text = TimeInfo;
                                labelGetColor.Text = GetColor;
                                break;
                            }
  
                        case 3:
                            {
                          //      lblTitle.Text = "Set ID";
                                if (tempi[1] == 0x41)
                                {
                                    lblID.Text = "RF303s";//ID.ToString();
                                }
                                else
                                {
                                    lblID.Text = "RF300";
                                };

                                if (tempi[4] == 0x41)
                                {
                                    labelStatus.Text = "OK";
                                }
                                else
                                {
                                    labelStatus.Text = "Error";
                                }
                                break;
                            }

  
                    }

                }
            }
            status = msg.Msg.ToString();
            base.WndProc(ref msg);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool a = CloseHnd();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        private void buttonPrevSet_Click(object sender, EventArgs e)
        {
            int SetId;
            byte  Flag,Lum, RR, GG, BB;
            SetId = int.Parse(textBoxPrevSetId.Text);
            Flag = Convert.ToByte(comboBoxFlag1.SelectedIndex);
            Lum = Convert.ToByte(comboBoxLum.SelectedIndex);
            RR = Convert.ToByte(comboBoxRed.SelectedIndex);
            GG = Convert.ToByte(comboBoxGreen.SelectedIndex);
            BB = Convert.ToByte(comboBoxBlue.SelectedIndex);

                        if ((SetId < 0) || (SetId > 63))
                        {
                            MessageBox.Show("Id input error");
                        }
                        else
                        {
                            PrevSetIdPage(ComNo, SetId,Flag, Lum, RR, GG, BB); 
                        }
 
           
        }

        private void buttonUupdateIdPage_Click(object sender, EventArgs e)
        {
            if (UpdateIdPage(ComNo, false) != 1)
            {
                MessageBox.Show("Update Id page error");
            }
        }

 



        private void buttonSet301_Click(object sender, EventArgs e)
        {
            ClearInfo();
            byte  SetID;
            byte Group, Row, Col;
            if (txtID.Text == "")
            {
                return;
            }
            SetID =Convert.ToByte (txtID.Text);
            if (SetID < 0 || SetID >= 63)
            {
                MessageBox.Show("SetID value Error!");
                return;
            }
            Group = Convert.ToByte(textBoxGroup.Text);
            Row = Convert.ToByte(textBoxRow.Text);
            Col = Convert.ToByte(textBoxCol.Text);

            if (Set_Id_331(ComNo,SetID,0, Group, Row, Col) != 1)
            {
                MessageBox.Show("Set Id Error!");
            }
        }

   

        private void buttonSleep_Click(object sender, EventArgs e)
        {
            byte SleepCount, OffCount;
            byte Lum, RR, GG, BB;
            SleepCount = Convert.ToByte(textBoxSleepCount.Text);
            OffCount = Convert.ToByte(textBoxOffCount.Text);
            Lum = Convert.ToByte(comboBoxLum3.SelectedIndex);
            RR = Convert.ToByte(comboBoxRed3.SelectedIndex);
            GG = Convert.ToByte(comboBoxGreen3.SelectedIndex);
            BB = Convert.ToByte(comboBoxBlue3.SelectedIndex);
            SetSleep(ComNo, SleepCount, OffCount, Lum, RR, GG, BB);
        }

        private void buttonAwake_Click(object sender, EventArgs e)
        {
            byte Lum, RR, GG, BB;
            Lum = Convert.ToByte(comboBoxLum3.SelectedIndex);
            RR = Convert.ToByte(comboBoxRed3.SelectedIndex);
            GG = Convert.ToByte(comboBoxGreen3.SelectedIndex);
            BB = Convert.ToByte(comboBoxBlue3.SelectedIndex);
            SetAwake(ComNo, Lum, RR, GG, BB);
        }

        private void buttonUpdateOneId_Click(object sender, EventArgs e)
        {
            int  UpdateId;
            byte Flag,Lum, RR, GG, BB;
            UpdateId = Convert.ToInt32 (textBoxId2.Text);
            if ((UpdateId < 0) || (UpdateId > 63))
            {
                MessageBox.Show("Id input error!");
            }
            Flag = Convert.ToByte(comboBoxFlag2.SelectedIndex);
            Lum = Convert.ToByte(comboBoxLum2.SelectedIndex);
            RR = Convert.ToByte(comboBoxRed2.SelectedIndex);
            GG = Convert.ToByte(comboBoxGreen2.SelectedIndex);
            BB = Convert.ToByte(comboBoxBlue2.SelectedIndex);
            if (UpdateOneId(ComNo, UpdateId,Flag, Lum, RR, GG, BB) != 1)
            {
                MessageBox.Show("Update one Id error");
            }
        }

        private void buttonUpdateAllId_Click(object sender, EventArgs e)
        {
            byte Flag,Lum, RR, GG, BB;
            Flag = Convert.ToByte(comboBoxFlag2.SelectedIndex);
            Lum = Convert.ToByte(comboBoxLum2.SelectedIndex);
            RR = Convert.ToByte(comboBoxRed2.SelectedIndex);
            GG = Convert.ToByte(comboBoxGreen2.SelectedIndex);
            BB = Convert.ToByte(comboBoxBlue2.SelectedIndex);
            if (UpdateAllIdSame(ComNo,Flag, Lum, RR, GG, BB) != 1)
            {
                MessageBox.Show("Update All id same error");
            }
        }


 

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBoxLumVal.Text);
            if (i < 127)
            {
                textBoxLumVal.Text = (i + 1).ToString();
                i++;
            }
            if (i >= 0 & i <= 127)
            {
                SetAllLum(ComNo, Convert.ToByte(i));
            }
        }

        private void buttonSub1_Click(object sender, EventArgs e)
        {
            int i = int.Parse(textBoxLumVal.Text);
            if (i > 0)
            {
                textBoxLumVal.Text = (i - 1).ToString();
                i--;
            }
            if (i >= 0 & i <= 127)
            {
                SetAllLum(ComNo, Convert.ToByte(i));
            }
        }

        private void buttonStartPing_Click(object sender, EventArgs e)
        {
            StartPing(ComNo);
        }

        private void buttonStartVote_Click_1(object sender, EventArgs e)
        {
            StartVote(ComNo);
        }

        private void buttonStopVote_Click(object sender, EventArgs e)
        {
            StopVote(ComNo);
        }

        private void buttonResetTime_Click(object sender, EventArgs e)
        {
            ResetTime(ComNo);
        }

 


    }
}