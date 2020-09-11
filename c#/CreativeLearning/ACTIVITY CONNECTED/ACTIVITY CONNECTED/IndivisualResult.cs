using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    /// <summary>
    /// 개인 결과 창 표시
    /// ViewRank에서 선택 학생에 대한 개인 결과 표시
    /// </summary>
    public partial class IndivisualResult : UserControl
    {
        public ViewRank indivisual;
        List<string> allrecords = new List<string>();
        public IndivisualResult(ViewRank viewRank)
        {
            InitializeComponent();
            indivisual = viewRank;
            Game.recordhistory.ForEach(x => allrecords.Add(x[1]));
        }
        private void IndivisualResult_Load(object sender, EventArgs e) // 선택한 ViewRank에서 개인 백분위와 평균 결과 표시
        {
            int rate = (int)((allrecords.IndexOf(indivisual.label3.Text) + 1) / (double)allrecords.Count * 100);
            string average = Averagerecord(allrecords, Game.gamename);
            label1.Text = string.Format("훌륭합니다.\n당신은 {0}\n수준입니다.\n\n나의 기록", indivisual.Controls[0].Text);
            label2.Text = indivisual.Controls[1].Text;
            label3.Text = string.Format("상위 {0}% 기록입니다.\n 또래 평균 {1}", rate, average);
        }
        private void IndivisualResult_Resize(object sender, EventArgs e)
        {
            label1.Height = (int)(this.Height * 0.6);
            label2.Height = (int)(this.Height * 0.2);
            label3.Height = (int)(this.Height * 0.2);
            label1.Font = new Font("맑은고딕", ViewList.AutoFontSize(label1), FontStyle.Bold);
            label2.Font = new Font("맑은고딕", ViewList.AutoFontSize(label2), FontStyle.Bold);
            label3.Font = new Font("맑은고딕", ViewList.AutoFontSize(label3), FontStyle.Bold);
        }
        private void this_Click(object sender, EventArgs e) // 본 컨트롤 선택 시 개인결과 화면 종료
        {
            ((ResultALL)Parent.Parent).label1.Text = "랭킹";
            Parent.SuspendLayout();
            foreach(Control c in Parent.Controls)
            {
                c.Visible = true;
            }
            Parent.ResumeLayout();
            this.Dispose();
        }
        private string Averagerecord(List<string> record, string gamename) // 역대 결과 평균 계산
        {
            int sum = 0;
            string average = "";
            switch (gamename)
            {
                case "movechallenge":
                    char[] seperator = { ':', '.' };
                    foreach (string r in record)
                    {
                        sum += Convert.ToInt32(string.Join("", r.Split(seperator)));
                    }
                    average = (sum /= record.Count).ToString("000000");
                    average = average.Insert(4, ".");
                    average = average.Insert(2, ":");
                    return average;
                case "pacer":
                    foreach (string r in record)
                    {
                        sum += Convert.ToInt32(r);
                    }
                    average = (sum /= record.Count).ToString();
                    return average;
                default:
                    return average;
            }
            
        }
    }
}