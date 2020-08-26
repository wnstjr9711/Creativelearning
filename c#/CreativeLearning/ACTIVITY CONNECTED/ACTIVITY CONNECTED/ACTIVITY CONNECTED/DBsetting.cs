using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ACTIVITY_CONNECTED
{
    // 학생 이름은 숫자로 시작할 수 없음
    public partial class DBsetting : UserControl
    {
        DBfunction db = new DBfunction();
        Infoinput addinfo = new Infoinput();
        Infoinput reviseinfo = new Infoinput();
        Size s;

        public DBsetting()
        {
            InitializeComponent();
        }

        private void DBsetting_Load(object sender, EventArgs e)
        {
            s = this.Size;
            DBsetting_SizeChanged(sender, e);
        }

        private void DBALL_Click(object sender, EventArgs e) // 전체 데이터 엑셀로 출력
        {
            List<List<string>> studentinfo = new List<List<string>> { new List<string> { "고유번호", "학교명", "학년", "번호", "성별", "이름" } };
            List<List<string>> gameinfo = new List<List<string>> { new List<string> { "게임번호", "게임이름" } };
            List<List<string>> participateinfo = new List<List<string>> { new List<string> { "고유번호", "게임번호", "참가번호", "기록" } };
            List<List<string>> buzzerinfo = new List<List<string>> { new List<string> { "게임번호", "버저id", "내용", "색", "시간" } };
            studentinfo.AddRange(db.GetAllStudent());
            gameinfo.AddRange(db.GetAllGame());
            participateinfo.AddRange(db.GetAllParticipate());
            buzzerinfo.AddRange(db.GetAllBuzzer());

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;
            for (int i = 0; i < studentinfo.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    workSheet.Cells[i + 1, j + 1] = studentinfo[i][j];
                }
            }
            for (int i = 0; i < gameinfo.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    workSheet.Cells[i + 1, j + 8] = gameinfo[i][j];
                }
            }
            for (int i = 0; i < participateinfo.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    workSheet.Cells[i + 1, j + 11] = participateinfo[i][j];
                }
            }
            for (int i = 0; i < buzzerinfo.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    workSheet.Cells[i + 1, j + 16] = buzzerinfo[i][j];
                }
            }
            workSheet.Columns.AutoFit();
            excelApp.Visible = true;
        }

        private void manage_Click(object sender, EventArgs e) // 학생관리 패널 및 패널 관리
        {
            menupanel.Visible = !menupanel.Visible;
            if (addpanel.Visible || findpanel.Visible || editpanel.Visible)
            {
                addpanel.Visible = false;
                findpanel.Visible = false;
                editpanel.Visible = false;
            }
        }

        private void openadd_Click(object sender, EventArgs e) // 추가 패널
        {
            addpanel.Visible = !addpanel.Visible;
            findpanel.Visible = editpanel.Visible = false;
        }

        private void openfind_Click(object sender, EventArgs e) // 찾기 패널
        {
            findpanel.Visible = !findpanel.Visible;
            editpanel.Visible = false;
            addpanel.Visible = false;
        }

        private void add_Click(object sender, EventArgs e) // 추가 버튼
        {
            if (MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] info = addinfo.Getinfo();
                if (db.InsertStudent(info))
                {
                    MessageBox.Show("등록완료");
                }
                else
                {
                    MessageBox.Show("등록실패");
                }
            }
            else
            {
                MessageBox.Show("등록 취소");
            }
        }

        private void find_Click(object sender, EventArgs e) // 찾기 버튼
        {
            string[] info = reviseinfo.Getinfo();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].Name = "학생 목록";
            dataGridView1.Rows.Clear();
            foreach (List<string> s in db.FindStudent(info))
            {
                dataGridView1.Rows.Add(String.Join("/", s.ToArray()).ToString());
            }
            dataGridView1.ClearSelection();
        }

        private void revise_Click(object sender, EventArgs e) // 수정 버튼
        {
            if (MessageBox.Show("수정하시겠습니까?", "수정", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] info = infoinput1.Getinfo();
                int stunum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Split('/')[0]);
                db.ReviseStudent(stunum, info);
                MessageBox.Show("수정 완료");
            }
            else
            {
                MessageBox.Show("수정 취소");
            }
            editpanel.Visible = false;
            find_Click(sender, e); // Gridview 새로고침
        }

        private void delete_Click(object sender, EventArgs e) // 삭제 버튼
        {
            //MessageBox.Show(dataGridView1.SelectedRows[0].ToString());
            if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int stunum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Split('/')[0]);
                db.DeleteStudent(stunum);
                MessageBox.Show("삭제 완료");
            }
            else
            {
                MessageBox.Show("삭제 취소");
            }
            editpanel.Visible = false;
            find_Click(sender, e); //Gridview 새로고침
        }
        private void addpanel_VisibleChanged(object sender, EventArgs e) // 입력 컨트롤
        {
            addinfo.Dispose();
            addinfo = new Infoinput();
            addinfo.Location = new Point(40, 50);
            addpanel.Controls.Add(addinfo);
        }
        private void findpanel_VisibleChanged(object sender, EventArgs e) // 입력 컨트롤 및 표 초기화
        {
            reviseinfo.Dispose();
            reviseinfo = new Infoinput();
            reviseinfo.Location = new Point(0, 30);
            findpanel.Controls.Add(reviseinfo);
            dataGridView1.Rows.Clear();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e) // 표에서 학생 선택
        {
            try
            {
                string[] set = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Split('/');
                set = set.Skip(1).Take(5).ToArray();
                infoinput1.Setinfo(set);
                editpanel.Visible = true;
            }
            catch
            {
                return;
            }
        }
        private void DBsetting_SizeChanged(object sender, EventArgs e) // 화면 중앙 위치
        {
            panel5.Location = new Point((Parent.Width - s.Width) / 2, (Parent.Height - s.Height) / 2);
        }

        private void DBsetting_MouseClick(object sender, MouseEventArgs e) // 바탕 클릭 시 열린 패널 숨기기
        {
            addpanel.Visible = findpanel.Visible = false;
        }

        private void ExceltoDB_Click(object sender, EventArgs e) // 학생정보 엑셀 가져오기
        {
            db.StudentExceltoDB();
        }

        private void editpanel_VisibleChanged(object sender, EventArgs e) // 수정, 삭제 버튼 활/비활성화(키보드로 접근시 오류방지)
        {
            foreach(Control c in editpanel.Controls)
            {
                c.Enabled = editpanel.Visible;
            }
        }
    }
}
