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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{
    public partial class ProfessorPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public ProfessorPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 이름 from 교수 where 교수번호='{MainPage.ID}'";
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

        private void ProfessorPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GuidanceStudentPage guidanceStudentPage = new GuidanceStudentPage();
            guidanceStudentPage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPicture addPicture = new AddPicture();
            addPicture.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GradeManagePage gradeManagePage = new GradeManagePage();
            gradeManagePage.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConsultationPage consultationPage = new ConsultationPage();
            consultationPage.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfirmPage confirmPage = new ConfirmPage();
            confirmPage.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CheckPassword password = new CheckPassword();
            password.ShowDialog();
        }
    }
}
