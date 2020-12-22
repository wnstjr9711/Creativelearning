using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class ViewRank : UserControl
    {
        readonly string[] title = { "순위", "팀명", "기록", "단계" };
        public ViewRank()
        {
            InitializeComponent();
        }
        public void SetRank(string no, string name, string record, string level) // 값 입력
        {
            label1.Text = no;
            label2.Text = name;
            label3.Text = record;
            label4.Text = level;
        }
        public void SetTitle() // ["순위", "팀명", "기록", "단계"];
        {
            label1.Text = title[0];
            label2.Text = title[1];
            label3.Text = title[2];
            label4.Text = title[3];
        }
        private void ViewRank_Resize(object sender, EventArgs e)
        {
            SuspendLayout();
            label1.Width = label2.Width = label3.Width = label4.Width = (int)Math.Truncate(this.Width * 0.25);
            List<float> fonts = new List<float> { ViewList.AutoFontSize(label1), ViewList.AutoFontSize(label2), ViewList.AutoFontSize(label3), ViewList.AutoFontSize(label4) };
            float font = fonts.Min();
            label1.Font = label2.Font = label3.Font = label4.Font = new Font("맑은고딕", font);
            ResumeLayout();
        }
        private void this_Click(object sender, EventArgs e) // 선택 참가자에 대한 개인 결과창 호출
        {
            Control parent = Parent;
            if (Array.Exists(title, t => t.Equals(((Label)sender).Text)))
            {
                return;
            } // title 클릭은 무효
            IndivisualResult indivisualResult = new IndivisualResult((ViewRank)((Label)sender).Parent); // 개인결과 화면 표시
            indivisualResult.Dock = DockStyle.Fill;
            foreach(Control c in Parent.Controls)
            {
                c.Visible = false;
            }
            parent.Controls.Add(indivisualResult);
        }
    }
}
