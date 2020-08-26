using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    /// <summary>
    /// 하나의 게임에 대한 결과 화면 표시
    /// ViewRank와 IndivisualResult 교차 출력
    /// </summary>
    public partial class ResultALL : UserControl
    {
        Dictionary<string, string> rank;
        ViewRank[] viewRanks;
        public ResultALL(Dictionary<string, string> rank) // 게임에서 순위 결과 인자로 받아 표시
        {
            InitializeComponent();
            this.rank = rank;
        }
        private void ResultALL_Load(object sender, EventArgs e)
        {
            viewRanks = new ViewRank[rank.Count + 1];
            for (int i = 0; i < rank.Count + 1; i++)
            {
                ViewRank vr = new ViewRank();
                viewRanks[i] = vr;
                vr.Dock = DockStyle.Top;
                panel2.Controls.Add(vr);
            }
            viewRanks[rank.Count].SetTitle(); // 첫줄은 title
            int count = rank.Count - 1;
            foreach (KeyValuePair<string, string> kvp in rank.OrderBy(x => x.Value))
            { // 전체 결과 출력
                string level = Levelsetting(kvp.Value, Game.recordhistory);
                viewRanks[count].SetRank((rank.Count - count--).ToString(), Game.Trimnumname(kvp.Key), kvp.Value, level);
            }
        }
        private void ResultALL_Resize(object sender, EventArgs e)
        {
            panel1.Height = (int)(this.Height * 0.2);
            label1.Width = (int)(this.Width * 0.1);
            label1.Font = new Font("맑은고딕", ViewList.AutoFontSize(label1), FontStyle.Bold);
            panel2.SuspendLayout();
            foreach (ViewRank vr in viewRanks)
            {
                vr.Height = (int)(panel2.Height * 0.125);
            }
            panel2.ResumeLayout();
        }
        private void GoBack_Click(object sender, EventArgs e) // 결과 창 종료
        {
            foreach (Control c in Parent.Controls)
            {
                c.Visible = true;
            }
            this.Dispose();
        }
        private void SaveExcel_Click(object sender, EventArgs e) // 게임 결과 엑셀 저장
        {
            SG sg = new SG(((IGame)Parent).SaveGame);
            sg();
        }
        private void panel2_ControlAdded(object sender, ControlEventArgs e) // 개인결과 창이 표시되면 "랭킹" -> "참가자이름" 텍스트 변경
        {
            if (e.Control.Name == "IndivisualResult")
            {
                label1.Text = ((IndivisualResult)e.Control).indivisual.label2.Text;
            }
        }
        private string Levelsetting(string myrecord, List<List<string>>recordhistory) //단계 계산 (현재는 20%마다 한단계)
        {
            List<string> allrecords = new List<string>();
            recordhistory.ForEach(x => allrecords.Add(x[1]));
            double rate = (allrecords.IndexOf(myrecord) + 1) / (double)allrecords.Count * 100;
            switch (Math.Ceiling(rate / 20))
            {
                case 0:
                case 1:
                    return "LEVEL5";
                case 2:
                    return "LEVEL4";
                case 3:
                    return "LEVEL3";
                case 4:
                    return "LEVEL2";
                default:
                    return "LEVEL1";
            }
        }
        private void label1_TextChanged(object sender, EventArgs e) // 텍스트 변경시마다 폰트 크기 조절
        {
            label1.Font = new Font("맑은고딕", ViewList.AutoFontSize(label1), FontStyle.Bold);
        }

    }
}
