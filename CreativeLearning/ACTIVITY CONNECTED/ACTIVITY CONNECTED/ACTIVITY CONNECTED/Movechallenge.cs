using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace ACTIVITY_CONNECTED
{
    public partial class Movechallenge : UserControl, IGame
    {
        string[] studentname; // 학생 이름
        const int bps = 7; // buzzer per student
        int showstudent = 1; // 측정 학생 순서
        List<List<string>> result = new List<List<string>>(); // 엑셀 출력용
        List<ViewList> viewarray; // panel에 출력될 viewlist배열
        bool[] checkbuzzer; // 버저 적정성 검사
        Dictionary<string, string> rank; // 결과 순위
        Receiver303 buzzer = new Receiver303();
        Game game = new Game();
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

        public Movechallenge(string[] stu)
        {
            InitializeComponent();
            studentname = stu;
        }
        private void Movechallenge_Load(object sender, EventArgs e)
        {
            viewarray = new List<ViewList>();
            for (int i = 0; i < studentname.Length; i++)
            {
                ViewList viewList = new ViewList();
                viewList.Settext((i + 1).ToString(), studentname[i]);
                if (i == 0) // 첫 줄은 타이틀
                {
                    ViewList title = new ViewList();
                    title.Settitle();
                    result.Add(title.GetList());
                    viewarray.Add(title);
                }
                viewarray.Add(viewList);
            }
            viewarray.ForEach(x => x.Dock = DockStyle.Top);
            viewarray.Reverse<ViewList>().ToList().ForEach(x => panel1.Controls.Add(x)); // 역순 추가해야 마지막이 최상단에 위치
            buzzer.SetMsgNo(Handle);
            if (!buzzer.SetConnection())
            {
                MessageBox.Show("수신기 연결 오류");
            }
            Receiver303.StartVote(buzzer.ComNo);
            checkbuzzer = new bool[bps];
            rank = new Dictionary<string, string>(studentname.Length);
            panel1.Visible = true;
        }
        public void SaveGame() // 결과 엑셀 저장
        {
            game.SaveGame(result); // 엑셀 저장
        }
        public void GameRule() // 게임 규칙
        {
            if (showstudent <= studentname.Length)
            {
                int id = Convert.ToInt32(buzzer.ID);
                for (int i = 0; i < checkbuzzer.Length; i++) // 버저의 눌림상태를 번호순으로 확인하여 순서대로 눌릴 수 있도록함
                {
                    if (checkbuzzer[i] == false)
                    {
                        if (i == (id - 1) % bps) //버저는 (bps * n) + 1번부터 (bps * n) + bps까지 할당
                        {
                            checkbuzzer[i] = true;
                            if (!studentname[showstudent - 1].StartsWith("unknown")) // unknown의 경우 DB접근 X
                            {
                                game.Buzzerdata(id, buzzer.Content, buzzer.Color, buzzer.Time);
                            }
                            if (i == 0) // 게임 시작
                            {
                                stopwatch.Restart();
                                return;
                            }
                            viewarray[showstudent].Settime(i, stopwatch.Elapsed.ToString().Substring(3, 8));
                            if (i == bps - 1) // 마지막 버저
                            {
                                stopwatch.Stop();
                                checkbuzzer = new bool[bps];
                                rank.Add(viewarray[showstudent].GetName(), viewarray[showstudent].Gettotal());
                                List<string> r = viewarray[showstudent].GetList();
                                result.Add(r);
                                game.UpdateRecord(game.getGamenum(), Convert.ToInt32(r[0]), r[7]); // 기록 DB저장
                                Ranking();
                                if (showstudent++ == studentname.Length) // 마지막 참가자
                                {
                                    MessageBox.Show("게임종료");
                                    Game.recordhistory = game.Recordhistory().OrderBy(x => x[1]).ToList(); // 역대 기록 갱신
                                    GetResult.Enabled = true;
                                    Receiver303.StopVote(buzzer.ComNo);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
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
        private void Ranking() // 실시간 랭킹 표시
        {// 시간의 오름차순으로 정렬 후 1, 2, 3등 표시
            int i = 0;
            foreach(KeyValuePair<string, string> kvp in rank.OrderBy(x => x.Value))
            {
                switch (i++)
                {// rank의 key는 순서 + 이름으로 순서를 지워 표시한다.
                    case 0:
                        rank1label.Text = Game.Trimnumname(kvp.Key) + " " + kvp.Value;
                        break;
                    case 1:
                        rank2label.Text = Game.Trimnumname(kvp.Key) + " " + kvp.Value;
                        break;
                    case 2:
                        rank3label.Text = Game.Trimnumname(kvp.Key) + " " + kvp.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = stopwatch.IsRunning ? stopwatch.Elapsed.ToString().Substring(3, 8) : "00:00.00";
        }
        private void Movechallenge_Resize(object sender, EventArgs e)
        {
            label1.Font = new Font("맑은고딕", (38 * (float)(this.Width * 0.0011) > 0) ? (38 * (float)(this.Width * 0.0011)) : (1), FontStyle.Bold);
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
            panel1.SuspendLayout();
            panel1.Location = new Point(label1.Width, label1.Location.Y);
            panel1.Size = new Size(this.Width - label1.Width, this.Height - GameEnd.Height);
            viewarray.ForEach(x => x.Height = panel1.Height / 8);
            panel1.ResumeLayout();
        }
        private void RankingLabel_TextChanged(object sender, EventArgs e) // 랭킹 갱신시 폰트 크기 조절
        {
            ((Label)sender).Font = new Font("맑은고딕", ViewList.AutoFontSize(((Label)sender)), FontStyle.Bold);
        }
        private void GameEnd_Click(object sender, EventArgs e) // main 화면 복귀
        {
            Parent.Parent.Parent.Width -= 160; // Main Panel 크기 축소
            this.Dispose();
        }
        private void GetResult_Click(object sender, EventArgs e) // 결과 창 열기
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
                    Game.recordhistory = Game.recordhistory.OrderBy(x => x[1]).ToList();
                }
            }
            ResultALL ra = new ResultALL(rank); // 결과컨트롤에 현재 랭크를 전달
            ra.Dock = DockStyle.Fill;
            this.Controls.Add(ra);
        }
    }
}
