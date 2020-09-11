using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class Main : Form
    {
        public static Size size;
        bool maxstate;
        Game game;
        DBsetting dbset;
        BuzzerSetting setting;
        public Main()
        {
            InitializeComponent();
            MinimumSize = this.Size;
        }
        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                c.Size = size = panel1.Size;
            }
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) // 최대화 크기에서 변화 시(이전크기 복원 버튼 클릭시 변경 위함)
            {
                maxstate = true;
            }
            if (maxstate)
            {
                Main_ResizeEnd(sender, e);
                maxstate = WindowState == FormWindowState.Maximized;
            }
        }

        private void opengame_Click(object sender, EventArgs e)
        {
            game = new Game();
            panel1.Controls.Clear();
            panel1.Controls.Add(game);
            Main_ResizeEnd(sender, e);
        }

        private void opendbset_Click(object sender, EventArgs e)
        {
            dbset = new DBsetting();
            panel1.Controls.Clear();
            panel1.Controls.Add(dbset);
            Main_ResizeEnd(sender, e);
        }

        private void openbuzzerset_Click(object sender, EventArgs e)
        {
            setting = new BuzzerSetting();
            panel1.Controls.Clear();
            panel1.Controls.Add(setting);
            Main_ResizeEnd(sender, e);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (setting != null)
            {
                setting.BuzzerSetting_VisibleChanged(sender, e);
            }
        }
    }
}
