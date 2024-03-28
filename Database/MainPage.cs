using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Security.Cryptography;
namespace Database
{
    public partial class MainPage : Form
    {
        OleDbConnection conn;
        public static string INFO = "";
        public static string ID = "";
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public MainPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text.Equals("관리자"))
            {
                if (textBox1.Text.Equals("root"))
                {
                    if (textBox2.Text.Equals("123456"))
                    {
                        MessageBox.Show("관리자 모드로 접속합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminPage admin = new AdminPage();
                        this.Visible = false;
                        admin.ShowDialog();


                    }
                    else
                    {
                        MessageBox.Show("비밀번호가 일치하지 않습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("아이디가 일치하지 않습니다.");
                }

            }
            else if (comboBox1.Text.Equals("교수"))
            {
                INFO = "교수";
                bool id = false;
                bool pwd = false;
                bool cpwd = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT 교수번호,비밀번호 FROM 교수 ";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("아이디를 입력하세요.");

                }
                else if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("비밀번호를 입력하세요.");
                }
                else if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
                {
                    while (reader.Read())
                    {

                        if (textBox1.Text.Equals(reader.GetString(0)))
                        {
                            id = true;
                            if (reader.GetString(1).Equals("0000") && textBox2.Text.Equals("0000"))
                            {
                                ID = reader.GetString(0);
                                cpwd = true;
                                break;
                            }
                            else
                            {
                                string value = textBox2.Text;
                                SHA256 hash = new SHA256Managed();
                                byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(value));

                                // 16진수 형태로 문자열 결합
                                StringBuilder sb = new StringBuilder();
                                foreach (byte b in bytes)
                                    sb.AppendFormat("{0:x2}", b);

                                if (sb.ToString().Equals(reader.GetString(1)))
                                {
                                    ID = reader.GetString(0);
                                    pwd = true;
                                    break;
                                }
                            }


                        }
                    }
                    reader.Close();
                    if (id)
                    {
                        if (cpwd)
                        {
                            MessageBox.Show("첫 접속입니다. 비밀번호를 변경해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            changePassword changePassword = new changePassword(ID);
                            changePassword.ShowDialog();

                            textBox2.Text = "";
                        }
                        else
                        {
                            if (pwd)
                            {
                                MessageBox.Show("로그인 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ProfessorPage professor = new ProfessorPage();
                                this.Visible = false;
                                professor.ShowDialog();


                            }
                            else
                            {
                                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                                textBox2.Text = "";
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("아이디가 일치하지 않습니다.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }

            }
            else if (comboBox1.Text.Equals("학생"))
            {
                INFO = "학생";
                bool id = false;
                bool pwd = false;
                bool cpwd = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT 학번,비밀번호 FROM 학생 ";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader reader = cmd.ExecuteReader();
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("아이디를 입력하세요.");

                }
                else if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("비밀번호를 입력하세요.");
                }
                else if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
                {
                    while (reader.Read())
                    {

                        if (textBox1.Text.Equals(reader.GetString(0)))
                        {
                            id = true;
                            if (reader.GetString(1).Equals("0000") && textBox2.Text.Equals("0000"))
                            {
                                ID = reader.GetString(0);
                                cpwd = true;
                                break;
                            }
                            else
                            {
                                string value = textBox2.Text;
                                SHA256 hash = new SHA256Managed();
                                byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(value));

                                // 16진수 형태로 문자열 결합
                                StringBuilder sb = new StringBuilder();
                                foreach (byte b in bytes)
                                    sb.AppendFormat("{0:x2}", b);

                                if (sb.ToString().Equals(reader.GetString(1)))
                                {
                                    ID = reader.GetString(0);
                                    pwd = true;
                                    break;
                                }
                            }
                        }
                    }
                    reader.Close();
                    if (id)
                    {
                        if (cpwd)
                        {
                            MessageBox.Show("첫 접속입니다. 비밀번호를 변경해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            changePassword changePassword = new changePassword(ID);
                            changePassword.ShowDialog();

                            textBox2.Text = "";
                        }
                        else
                        {
                            if (pwd)
                            {


                                MessageBox.Show("로그인 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                StudentPage studentPage = new StudentPage();
                                this.Visible = false;
                                studentPage.ShowDialog();


                            }
                            else
                            {
                                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                                textBox2.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("아이디가 일치하지 않습니다.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("구분을 선택해주세요.");
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            FindPassword findPassword = new FindPassword();
            findPassword.ShowDialog();
        }



        private void password_enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.login_btn_Click(sender, e);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}