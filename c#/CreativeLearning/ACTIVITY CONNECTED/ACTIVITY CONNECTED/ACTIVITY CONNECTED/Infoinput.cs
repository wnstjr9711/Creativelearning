using System;
using System.Windows.Forms;

namespace ACTIVITY_CONNECTED
{
    public partial class Infoinput : UserControl
    {
        const int infosize = 5;
        string[] info = new string[infosize];
        TextBox[] textBoxes = new TextBox[infosize];
        public Infoinput()
        {
            InitializeComponent();
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
        }
        public string[] Getinfo() // string 배열 가져오기
        {
            Clearinfo();
            for (int i = 0; i < infosize; i++)
            {
                info[i] = textBoxes[i].Text;
            }
            return info;
        }
        public void Setinfo(string[] infos) // string 배열 채우기
        {
            for (int i = 0; i < infosize; i++)
            {
                textBoxes[i].Text = infos[i];
            }
        }
        void Clearinfo()
        {
            info = new string[5];
        }
    }
}
