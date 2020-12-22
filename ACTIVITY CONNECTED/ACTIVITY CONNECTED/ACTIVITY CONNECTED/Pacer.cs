using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class Pacer : UserControl, IGame
    {
        string[] studentname;
        List<List<string>> result = new List<List<string>>(); // result는 엑셀 저장용 내부 리스트에는 참가자당 코스별 기록
        Dictionary<string, string> rank; // key: 순서 + 이름 value: 시간
        Receiver303 buzzer = new Receiver303();
        Game game = new Game();
        
        public Pacer(string[] stu)
        {
            InitializeComponent();
            studentname = stu;
        }
        private void Pacer_Load(object sender, EventArgs e)
        {
            rank = new Dictionary<string, string>(studentname.Length);
            buzzer.SetMsgNo(Handle);
            if (!buzzer.SetConnection())
            {
                MessageBox.Show("수신기 연결 오류");
            }
            Receiver303.StartVote(buzzer.ComNo);
            Game.recordhistory = game.Recordhistory().OrderByDescending(x => x[1]).ToList(); ; // 역대 recordhistory 가져오기
            Ranking();
        }
        private void Ranking() // 역대 랭킹 표시
        {// 내림차순으로 정렬 후 1, 2, 3등 표시
            try
            {
                rank1label.Text = Game.Trimnumname(game.getName(Convert.ToInt32(Game.recordhistory[0][0]))) + " " + Game.recordhistory[0][1] + "회";
                rank2label.Text = Game.Trimnumname(game.getName(Convert.ToInt32(Game.recordhistory[1][0]))) + " " + Game.recordhistory[1][1] + "회";
                rank3label.Text = Game.Trimnumname(game.getName(Convert.ToInt32(Game.recordhistory[2][0]))) + " " + Game.recordhistory[2][1] + "회";
            }
            catch
            {
                return;
            }
        }
        public void GameRule()
        {
            int id = Convert.ToInt32(buzzer.ID);
            if (id == 1)
            {
                game.UpdateRecord(game.getGamenum(), 1, "30");
            }
            Game.recordhistory = game.Recordhistory().OrderByDescending(x => x[1]).ToList(); ; // 종료시에 내림차순 정렬
            Ranking();
        }
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 111)
            {
                unsafe
                {
                    buzzer.WndP((byte*)msg.LParam.ToPointer());
                }
                GameRule();
            }
            base.WndProc(ref msg);
        }
        public void SaveGame()
        {
            game.SaveGame(result); // 엑셀 저장
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = false;
            }
            foreach (KeyValuePair<string, string> kvp in rank) //unknown 참가자의 결과를 일시적으로 저장
            {
                if (Game.Trimnumname(kvp.Key).StartsWith("unknown"))
                {
                    List<string> temp = new List<string>();
                    temp.Add(kvp.Key);
                    temp.Add(kvp.Value);
                    Game.recordhistory.Add(temp);
                    Game.recordhistory = Game.recordhistory.OrderByDescending(x => x[1]).ToList(); // unknown의 정보 내림차순 정렬
                }
            }
            ResultALL ra = new ResultALL(rank); // 결과컨트롤에 현재 랭크를 전달
            ra.Dock = DockStyle.Fill;
            this.Controls.Add(ra);
        }

        private void GameEnd_Click(object sender, EventArgs e)
        {
            Parent.Parent.Parent.Width -= 160; // Main Panel 크기 축소
            this.Dispose();
        }

        private void Pacer_Resize(object sender, EventArgs e)
        {
            // movechallenge용
            label1.Font = new Font("맑은고딕", (38 * (float)(this.Width * 0.0011) > 0) ? (38 * (float)(this.Width * 0.0011)) : (1), FontStyle.Bold);
            /*
             label1은 movechallenge에서 타이머가 수동으로 폰트조절했기때문에 임시로 해놈
             label들은 autosize 속성 = false 한 후 size 수동 조절 후 autofontsize 하면 됩니다.
             */
            pictureBox1.Location = new Point(0, label1.Height);
            pictureBox1.Size = new Size(label1.Width, this.Height - label1.Height);
            int locx, locy;
            locx = (int)(pictureBox1.Width * 0.1);
            pictureBox2.Location = new Point(locx, pictureBox1.Location.Y + (int)(pictureBox1.Height * 0.25));
            pictureBox3.Location = new Point(locx, pictureBox1.Location.Y + (int)(pictureBox1.Height * 0.5));
            pictureBox4.Location = new Point(locx, pictureBox1.Location.Y + (int)(pictureBox1.Height * 0.75));
            int pic1size = 80 + (int)((pictureBox3.Location.Y - pictureBox2.Location.Y - pictureBox2.Height) * 0.5);
            pictureBox2.Size = pictureBox3.Size = pictureBox4.Size = new Size(pic1size, pic1size);
            locx = pictureBox2.Location.X + pictureBox2.Width;
            locy = (int)(pictureBox2.Height * 0.25);
            rank1label.Location = new Point(locx, pictureBox2.Location.Y + locy);
            rank2label.Location = new Point(locx, pictureBox3.Location.Y + locy);
            rank3label.Location = new Point(locx, pictureBox4.Location.Y + locy);
            rank1label.Size = rank2label.Size = rank3label.Size = new Size(pictureBox1.Width - rank1label.Location.X - 10, (int)(pic1size * 0.5));
            rank1label.Font = rank2label.Font = rank3label.Font = new Font("맑은고딕", ViewList.AutoFontSize(rank1label), FontStyle.Bold);
        }
    }
}
