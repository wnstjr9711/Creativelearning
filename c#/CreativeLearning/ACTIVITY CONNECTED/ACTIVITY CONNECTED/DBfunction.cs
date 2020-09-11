using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using System.Linq;

namespace ACTIVITY_CONNECTED
{
    public class DBfunction
    {
        const string DBname = "../../studentDB.sqlite";
        public SQLiteConnection conn;
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        public DBfunction()
        {
            if (!OpenDB())
            {
                CreateDB();
            }
        }
        void CreateDB()
        {
            SQLiteConnection.CreateFile(DBname);
            OpenDB();
            string[] sql = File.ReadAllText("../../CREATETABLE.txt").Split(';'); // form들과 같은 폴더임
            Executequery(sql);
        }
        bool OpenDB()
        {
            if (File.Exists(DBname))
            {
                conn = new SQLiteConnection(string.Format("Data Source={0:s};Version=3;", DBname));
                conn.Open();
                return true;
            }
            return false;
        }
        public bool Executequery(string[] query)
        {
            bool executed = true;
            try
            {
                foreach (string s in query)
                {
                    SQLiteCommand command = new SQLiteCommand(s, conn);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                executed = false;
            }
            return executed;
        } // sql문 실행 (except select문)
        public List<List<string>> Selectquery(string[] query)
        {
            List<List<string>> Selectreturn = new List<List<string>>();
            try
            {
                foreach (string s in query)
                {
                    SQLiteCommand command = new SQLiteCommand(s, conn);
                    SQLiteDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        List<string> temp = new List<string>();
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            temp.Add(rdr[i].ToString());
                        }
                        Selectreturn.Add(temp);
                    }
                    rdr.Close();
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Selectreturn;
        } // select 쿼리문 실행
        private int Getkey(string sql) // select문으로 기본키 가져오기
        {
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = command.ExecuteReader();
            rdr.Read();
            int key = Convert.ToInt32(rdr[0]);
            rdr.Close();
            command.Dispose();
            return key;
        }
        public int Getgamekey() // 현재 실행중인 게임의 기본키 가져오기
        {
            return Getkey("SELECT MAX(game_num) FROM GAME");
        }
        public bool InsertStudent(string[] info)
        {
            info[4] = (info[4] == "") ? "null" : String.Format("'{0}'", info[4]);
            string[] sql = { String.Format("INSERT INTO STUDENT VALUES(null, '{0}', '{1}', '{2}', '{3}', {4})",
                            info[0], info[1], info[2], info[3], info[4])};
            return Executequery(sql);
        } // 학생정보 insert
        public List<List<string>> FindStudent(string[] info)
        {
            List<List<string>> found = new List<List<string>>();
            string[] sql = { String.Format("SELECT * FROM STUDENT " +
            "WHERE school_name LIKE '%{0}%' AND grade LIKE '%{1}%' AND number LIKE '%{2}%' AND gender LIKE '%{3}%' AND student_name LIKE '%{4}%'"
            , info[0], info[1], info[2], info[3], info[4])};
            foreach (List<string> s in Selectquery(sql))
            {
                found.Add(s);
            }
            return found;
        } // 검색한 학생정보 가져오기(다수)
        public void ReviseStudent(int num, string[] info) // 학생정보 수정
        {
            string[] column = { "school_name", "grade", "number", "gender", "student_name" };
            for (int i = 0; i < column.Length; i++)
            {
                if (info[i] != "")
                {
                    string[] sql = { string.Format("UPDATE STUDENT SET {0} = '{1}' WHERE student_num = {2}", column[i], info[i], num) };
                    Executequery(sql);
                }
            }

        }
        public void DeleteStudent(int num) // 학생 삭제
        {
            string[] sql = { String.Format("DELETE FROM STUDENT WHERE student_num = {0}", num) };
            Executequery(sql);
        }
        public void InsertGame(string name) // 게임 생성
        {
            string[] sql = { String.Format("INSERT INTO GAME VALUES(null, '{0}')", name) };
            Executequery(sql);
        }
        public void InsertParticipate(int[] student_num) // 게임 참가자(들) 삽입
        {
            for (int i = 0; i < student_num.Length; i++)
            {
                if (student_num[i] != 0)
                {
                    string[] sql = { String.Format("INSERT INTO PARTICIPATE VALUES({0}, {1}, {2}, '{3}')", student_num[i], Getgamekey(), i + 1, "") };
                    Executequery(sql);
                }
            }
        }
        public void InsertBuzzer(int gamenum, int buzzerid, string content, string color, string time) // 버저 입력 저장
        {
            string[] sql = { String.Format("INSERT INTO BUZZER VALUES({0}, {1}, '{2}', '{3}', '{4}')",
                             gamenum, buzzerid, content, color, time) };
            Executequery(sql);
        }
        public void InsertRecord(int gamenum, int participatenum, string record) // 참가자 기록 삽입
        {
            string[] sql = { string.Format("UPDATE PARTICIPATE SET record = '{0}' WHERE game_num = {1} AND participate_num = {2}", record, gamenum, participatenum) };
            Executequery(sql);
        }
        public List<List<string>> GetAllStudent() // 학생테이블 가져오기
        {
            string[] sql = { "SELECT * FROM STUDENT;" };
            return Selectquery(sql);
        }
        public List<List<string>> GetAllGame()
        {
            string[] sql = { "SELECT * FROM GAME;" };
            return Selectquery(sql);
        } // 게임테이블 가져오기
        public List<List<string>> GetAllParticipate() // 참가자테이블 가져오기
        {
            string[] sql = { "SELECT * FROM PARTICIPATE;" };
            return Selectquery(sql);
        }
        public List<List<string>> GetAllBuzzer() // 버저테이블 가져오기
        {
            string[] sql = { "SELECT * FROM BUZZER;" };
            return Selectquery(sql);
        }
        List<string> Getstudent(int participatenum) // 게임 참가번호로 학생 정보 가져오기(1인)
        {
            string[] sql = { string.Format("SELECT * FROM STUDENT WHERE student_num = (SELECT student_num FROM PARTICIPATE WHERE participate_num = {0} AND game_num = {1})",
                             participatenum, Getgamekey())};
            return Selectquery(sql)[0];
        }
        public string Getname(int stunum) // 고유 번호로 학생 이름 가져오기(1인)
        {
            string[] sql = { string.Format("SELECT student_name FROM STUDENT WHERE student_num = {0}", stunum)};
            return stunum + Selectquery(sql)[0][0];
        }
        string Filelocation(string name) // 저장 위치
        {
            string filename = name;
            int version = 2;
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (File.Exists(Path.Combine(dialog.FileName, filename + ".xlsx")))
                    {
                        while (File.Exists(Path.Combine(dialog.FileName, filename + ".xlsx")))
                        {
                            filename = name;
                            filename += version++.ToString();
                        }
                    }
                }
                filename = Path.Combine(dialog.FileName, filename);
            }
            catch (Exception)
            {
                filename = "";
            }
            return filename;
        }
        
        string Getgamename() // 현재 게임 이름 가져오기
        {
            string[] sql = { string.Format("SELECT game_name FROM GAME WHERE game_num = {0}", Getgamekey()) };
            return Selectquery(sql)[0][0];
        }
        
        public void SaveAsExcel(List<List<string>> result) // 게임마다 엑셀 저장방식은 다름
        {
            string name = Getgamename();
            if ((name = Filelocation(name)) != "")
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workBook = excelApp.Workbooks.Add();
                Excel.Worksheet workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;
                workSheet.Cells[1, 1] = "고유 번호";
                workSheet.Cells[1, 2] = "학교명";
                workSheet.Cells[1, 3] = "학년";
                workSheet.Cells[1, 4] = "번호";
                workSheet.Cells[1, 5] = "성별";
                workSheet.Cells[1, 6] = "이름";
                for (int i = 0; i < result.Count; i++)
                {
                    for (int j = 2; j < result[i].Count; j++)
                    {
                        workSheet.Columns[5 + j].NumberFormat = "@";
                        workSheet.Cells[i + 1, 5 + j] = result[i][j];
                    }
                }
                for (int i = 1; i < result.Count; i++)
                {
                    int j = 1;
                    if (!result[i][1].StartsWith("unknown"))
                    {
                        foreach (string s in Getstudent(Convert.ToInt32(result[i][0])))
                        {
                            workSheet.Cells[i + 1, j++] = s;
                        }
                    }
                    else
                    {
                        workSheet.Cells[i + 1, 6] = result[i][1];
                    }
                }
                workSheet.Columns.AutoFit();
                workBook.SaveAs(name);
                workBook.Close(true);
                GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out uint processId);
                excelApp.Quit();
                if (processId != 0)
                {
                    System.Diagnostics.Process excelProcess = System.Diagnostics.Process.GetProcessById((int)processId);
                    excelProcess.CloseMainWindow();
                    excelProcess.Refresh();
                    excelProcess.Kill();
                }
            }
        }
        public List<List<string>> GetRecords() // 현재 게임의 역대 기록([고유번호+이름, 기록])가져오기(오름차순)
        {
            List<List<string>> record = new List<List<string>>();
            string[] sql = { string.Format("SELECT student_num, record FROM PARTICIPATE, GAME WHERE GAME.game_name = '{0}' AND PARTICIPATE.game_num = GAME.game_num;", Getgamename()) };
            record = Selectquery(sql);
            record.RemoveAll(x => x[1] == "");
            return record;
        }
        public void StudentExceltoDB() // 엑셀로 학생 등록하기
        {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workBook = excelApp.Workbooks.Open(dialog.FileName);
                    Excel.Worksheet workSheet = workBook.Worksheets.get_Item(1) as Excel.Worksheet;
                    Excel.Range range = workSheet.UsedRange; // 사용중인 셀 범위를 가져오기 
                    List<string> fail = new List<string>();
                    List<string> success = new List<string>();
                    if (!(range.Columns.Count == 5)) // 데이터 적정성 검사
                    {
                        throw new Exception("데이터 형식 오류");
                    }
                    for (int row = 1; row <= range.Rows.Count; row++) // 가져온 행 만큼 반복 
                    {
                        List<string> student = new List<string>();
                        for (int column = 1; column <= range.Columns.Count; column++) // 가져온 열 만큼 반복 
                        {
                            student.Add(Convert.ToString((range.Cells[row, column] as Excel.Range).Value2));
                        }
                        if (student[4] == "이름") // 타이틀인 경우
                        {
                            continue;
                        }
                        if (!InsertStudent(student.ToArray()))
                        {
                            fail.Add(string.Join("/", student) + " 등록실패\n");
                        }
                        else
                        {
                            success.Add(string.Join("/", student) + " 등록성공\n");
                        }
                    }
                    if (fail.Count != 0)
                    {
                        MessageBox.Show(string.Join("", fail));
                    }
                    if (success.Count != 0)
                    {
                        MessageBox.Show(string.Join("", success));
                    }
                    workBook.Close(true);
                    GetWindowThreadProcessId(new IntPtr(excelApp.Hwnd), out uint processId);
                    excelApp.Quit();
                    if (processId != 0)
                    {
                        System.Diagnostics.Process excelProcess = System.Diagnostics.Process.GetProcessById((int)processId);
                        excelProcess.CloseMainWindow();
                        excelProcess.Refresh();
                        excelProcess.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}