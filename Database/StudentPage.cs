using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class StudentPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public StudentPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            InitializeComponent();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 이름 from 학생 where 학번='{MainPage.ID}' ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = "안녕하세요. " + reader.GetString(0) + "님";
            }
            reader.Close();
            cmd.Parameters.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MainPage mainForm = new MainPage();
                this.Visible = false;

                MainPage.INFO = "";
                MainPage.ID = "";
                mainForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnrolmentPage enrolmentPage = new EnrolmentPage();
            enrolmentPage.ShowDialog();
        }

        private void StudentPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckGrade checkGrade = new CheckGrade();
            checkGrade.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultCheckPage consultCheckPage = new ConsultCheckPage();
            consultCheckPage.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myCoursePage myCoursePage = new myCoursePage();
            myCoursePage.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckPassword password = new CheckPassword();
            password.ShowDialog();
        }
    }
}
