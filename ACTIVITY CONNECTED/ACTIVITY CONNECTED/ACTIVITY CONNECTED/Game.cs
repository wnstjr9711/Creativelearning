using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    delegate void SG();
    public partial class Game : UserControl
    {
        DBfunction db = new DBfunction();
        TextBox[] texts;
        public static string gamename; //게임이름
        int students; //참가학생수
        string[] studentname; //참가학생이름
        int participatenum; //참가번호
        public static List<List<string>> recordhistory; // "00:00.00"
        static char[] trimnum = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // 없앨 문자

        Size s;
        public Game()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
        }
        private void Game_Load(object sender, EventArgs e)
        {
            s = this.Size;
            Game_Resize(sender, e);
        }
        #region
        /// <summary>
        /// DBfunction 대리실행
        /// </summary>
        public void Buzzerdata(int id, string content, string color, string time)
        {
            db.InsertBuzzer(db.Getgamekey(), id, content, color, time);
        }
        public void UpdateRecord(int gamenum, int pnum, string record)
        {
            db.InsertRecord(gamenum, pnum, record);
        }
        public void SaveGame(List<List<string>> result)
        {
            db.SaveAsExcel(result);
        }
        public int getGamenum()
        {
            return db.Getgamekey();
        }
        public string getName(int stunum)
        {
            return db.Getname(stunum);
        }
        public List<List<string>> Recordhistory()
        {
            return db.GetRecords();
        }
        #endregion
        private void maxparticipatecomboBox_SelectedIndexChanged(object sender, EventArgs e) // 참가학생 수 설정
        {
            participatenum = 0; // 참가인원 변경시 등록사항 초기화
            students = Convert.ToInt32(maxparticipatescomboBox.SelectedItem);
            participatepanel.Controls.Clear();
            studentname = new string[students];
            texts = new TextBox[students];
            infoinput1.Enabled = showinfocomboBox.Enabled = find.Enabled = register.Enabled = true;
            button2.Enabled = button3.Enabled = false;
            showinfocomboBox.SelectedItem = null;
            showinfocomboBox.Text = "";
            int height = -30;
            for (int i = 0; i < texts.Length; i++)
            {
                TextBox t = new TextBox();
                t.Size = new Size(participatepanel.Width - 2, 30);
                t.Location = new Point(0, height += 30);
                t.Font = new Font("굴림", 11, FontStyle.Bold);
                t.TextAlign = HorizontalAlignment.Center;
                t.Text = "참가 번호" + (i + 1);
                texts[i] = t;
                participatepanel.Controls.Add(t);
            }
            button2.Enabled = button3.Enabled = true;
        }
        private void gamestart_Click(object sender, EventArgs e) // 게임 시작
        {
            gamename = ((Button)sender).Text;
            if (MessageBox.Show("게임을 생성하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Receiver303 connectioncheck = new Receiver303();
                connectioncheck.SetMsgNo(Handle);
                if (!connectioncheck.SetConnection())
                {
                    MessageBox.Show("수신기 연결 오류로 게임생성 불가");
                    return;
                }
                gamepanel.Controls.Clear();
                Parent.Width = this.Width += 160;
                db.InsertGame(gamename);
                int[] stunum = new int[students]; // 학생 고유 번호
                int unum = 1; // unknown 번호
                for (int i = 0; i < students; i++)
                {
                    try
                    {
                        stunum[i] = Convert.ToInt32(texts[i].Text.Split('/')[0]);
                    }
                    catch
                    {
                        studentname[i] = studentname[i] == null ? "unknown" + unum++ : studentname[i];
                    }
                }
                db.InsertParticipate(stunum); // 참가인원 등록
                switch (gamename)
                {
                    case "movechallenge":
                        Movechallenge movechallenge = new Movechallenge(studentname);
                        movechallenge.Dock = DockStyle.Fill;
                        gamepanel.Controls.Add(movechallenge);
                        break;
                    case "pacer":
                        Pacer pacer = new Pacer(studentname);
                        pacer.Dock = DockStyle.Fill;
                        gamepanel.Controls.Add(pacer);
                        break;
                }
            }
        }
        private void find_Click(object sender, EventArgs e) // 학생 검색 결과 가져오기
        {
            string[] info = infoinput1.Getinfo();
            showinfocomboBox.Items.Clear();
            foreach (List<string> s in db.FindStudent(info))
            {
                showinfocomboBox.Items.Add(String.Join("/", s.ToArray()));
            }
        }
        private void register_Click(object sender, EventArgs e) // 게임 참가 학생 등록
        {
            foreach (TextBox check in texts)
            {
                try
                {
                    if (showinfocomboBox.SelectedItem.ToString().Equals(check.Text))
                    {
                        MessageBox.Show("이미 선택된 학생입니다.");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("선택된 학생이 없습니다.");
                    return;
                }
            }
            texts[participatenum++].Text = showinfocomboBox.SelectedItem.ToString();
            studentname[participatenum - 1] = showinfocomboBox.SelectedItem.ToString().Split('/')[5];
            if (participatenum == texts.Length)
            {
                register.Enabled = showinfocomboBox.Enabled = false;
            }
        }
        private void Game_Resize(object sender, EventArgs e)
        {
            gamepanel.Size = new Size(this.Width - 10, this.Height - 10);
            gamesetpanel.Location = new Point((Main.size.Width - s.Width) / 2, (Main.size.Height - s.Height) / 2);
        }
        public static string Trimnumname(string name) //name이 번호 + 이름인 경우 이름만 표기하기 위함
        {
            while (name != (name = name.TrimStart(trimnum)))
            {
                name = name.TrimStart(trimnum);
            }
            return name;
        }
    }
}