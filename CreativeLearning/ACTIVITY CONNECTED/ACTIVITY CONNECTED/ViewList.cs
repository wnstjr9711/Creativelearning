using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class ViewList : UserControl
    {
        Label[] times = new Label[6];
        bool created = false;
        public ViewList()
        {
            InitializeComponent();
            times[0] = label3;
            times[1] = label4;
            times[2] = label5;
            times[3] = label6;
            times[4] = label7;
            times[5] = label8;
        }
        private void ViewList_Load(object sender, EventArgs e)
        {
            created = true;
        }
        #region
        /// <summary>
        /// title 설정 및 각 text 설정
        /// </summary>
        public void Settitle()
        {
            label1.Text = "순서";
            label2.Text = "팀명";
            int i = 1;
            foreach(Label label in times)
            {
                label.Text = i++.ToString();
            }
        }
        public void Settext(string num, string name)
        {
            label1.Text = num;
            label2.Text = name;
        }
        public void Settime(int course, string time)
        {
            times[course - 1].Text = time;
        }
        #endregion
        public string GetName() // 순서 + 이름
        {
            return label1.Text + label2.Text;
        }
        public string Gettotal() // 코스6
        {
            return times[5].Text;
        }
        public List<string> GetList() // [순서, 이름, 코스1, 코스2, 코스3, 코스4, 코스5, 코스6]
        {
            List<string> list = new List<string>();
            list.Add(label1.Text);
            list.Add(label2.Text);
            foreach(Label l in times)
            {
                list.Add(l.Text);
            }
            return list;
        }
        private void ViewList_Resize(object sender, System.EventArgs e)
        {
            if (created)
            {
                this.SuspendLayout();
                label1.Size = new Size(Convert.ToInt32(Width * 0.12) - 1, Height - 3);
                label2.Size = new Size(Convert.ToInt32(Width * 0.16) - 1, Height - 3);
                times.ToList().ForEach(x => x.Size = new Size(Convert.ToInt32(Width * 0.12) - 1, Height - 3));
                float font1 = AutoFontSize(label1) > AutoFontSize(label2) ? AutoFontSize(label2) : AutoFontSize(label1);
                float font2 = 0;
                label1.Font = label2.Font = new Font("맑은고딕", font1, FontStyle.Bold);
                times.ToList().ForEach(x => x.Font = new Font("맑은고딕", (font2 = AutoFontSize(x)) < font1 ? font2 : font1, FontStyle.Bold));
                this.ResumeLayout();
            }

        }
        private void time_TextChanged(object sender, EventArgs e) // 코스별 시간 갱신 시 폰트 크기
        {
            Label label = ((Label)sender);
            label.Font = new Font("맑은고딕", AutoFontSize(label), FontStyle.Bold) ;
        }
        public static float AutoFontSize(Label label) // 폰트 크기 자동화 function
        {
            if (label.Text == "")
            {
                return 0.1f;
            }
            Font ft;
            Graphics gp;
            SizeF sz;
            float Faktor, FaktorX, FaktorY;
            gp = label.CreateGraphics();
            sz = gp.MeasureString(label.Text, label.Font);
            gp.Dispose();

            FaktorX = (label.Width) / sz.Width;
            FaktorY = (label.Height) / sz.Height;
            Faktor = FaktorX > FaktorY ? FaktorY : FaktorX;
            ft = label.Font;
            float size = ft.Size * Faktor - 2;
            if (Faktor > 0)
                return size > 0 ? size : 0.1f;
            else
                return ft.Size * 0.1f;
        }
    }
}
