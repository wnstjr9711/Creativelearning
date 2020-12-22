using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class BuzzerSetting : UserControl
    {
        Receiver303 buzzer = new Receiver303();
        Size s;
        public BuzzerSetting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            buzzer.SetMsgNo(Handle);
            label1.Text = buzzer.test.ToString();
            s = this.Size;
            BuzzerSetting_SizeChanged(sender, e);
        }

        public void Labeling() // 누른 buzzer 표시
        {
            label3.Text = buzzer.ID;
            label5.Text = buzzer.Content;
        }

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 111)
            {
                unsafe
                {
                    buzzer.WndP((byte*)msg.LParam.ToPointer());
                }
                Labeling();
            }
            base.WndProc(ref msg);
        }

        private void buzzernumber_Click(object sender, EventArgs e) // buzzer id 변경
        {
            string text = ((Button)sender).Text;
            if (MessageBox.Show(text + "번 버저ID를 변경하시겠습니까?", "ID 변경", (MessageBoxButtons)System.Windows.MessageBoxButton.YesNo) == DialogResult.Yes)
            {
                buzzer.ChangeID(text);
            }
        }
        
        public void BuzzerSetting_VisibleChanged(object sender, EventArgs e) // 화면변경 시 버저 수신종료, 색상 변경 초기화
        {
            Receiver303.StopVote(buzzer.ComNo);
            Receiver303.UpdateAllIdSame(buzzer.ComNo, 0, 0, 0, 0, 0);
        }

        private void BuzzerSetting_SizeChanged(object sender, EventArgs e) // 화면 크기 변경 시 위치 변경
        {
            showpanel.Location = new Point((Parent.Width - s.Width) / 2, (Parent.Height - s.Height) / 2);
        }

        private void connect_Click(object sender, EventArgs e) // connection 설정
        {
            string msg = buzzer.SetConnection() ? "연결됨" : "연결 오류";
            MessageBox.Show(msg);
        }

        private void receivetest_Click(object sender, EventArgs e) // 수신기 open
        {
            buzzer.TestConnection();
            label1.Text = buzzer.test.ToString();
            if (!buzzer.test)
            {
                label3.Text = label5.Text = "";
            }
        }

        private void eachcolor_Click(object sender, EventArgs e) // 선택 buzzer 색상변경
        {
            try
            {
                Receiver303.UpdateOneId(buzzer.ComNo, Convert.ToInt32(textBox2.Text) - 1, 0, Convert.ToByte(comboBox1.Text), Convert.ToByte(comboBox2.Text),
                            Convert.ToByte(comboBox3.Text), Convert.ToByte(comboBox4.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void allcolor_Click(object sender, EventArgs e) // 전체 buzzer 색상변경
        {
            try
            {
                Receiver303.UpdateAllIdSame(buzzer.ComNo, 0, Convert.ToByte(comboBox1.Text), Convert.ToByte(comboBox2.Text),
                            Convert.ToByte(comboBox3.Text), Convert.ToByte(comboBox4.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
