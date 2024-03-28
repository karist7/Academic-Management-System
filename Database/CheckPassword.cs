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
using System.Security.Cryptography;

namespace Database
{
    public partial class CheckPassword : Form
    {
        OleDbConnection conn;
        bool flag = false;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public CheckPassword()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string value = textBox1.Text;
            SHA256 hash = new SHA256Managed();
            byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(value));

            // 16진수 형태로 문자열 결합
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.AppendFormat("{0:x2}", b);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"SELECT 비밀번호 FROM 학생 ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;


            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals(sb.ToString()))
                {
                    flag = true;
                    break;
                }
            }
            reader.Close();
            cmd.Parameters.Clear();

            cmd.CommandText = $"SELECT 비밀번호 FROM 교수 ";

            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;


            OleDbDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                if (reader2.GetString(0).Equals(sb.ToString()))
                {
                    flag = true;
                    break;
                }
            }
            reader2.Close();

            if (flag)
            {
                MessageBox.Show("비밀번호가 일치합니다.");
                changePassword password = new changePassword(MainPage.ID);
                password.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
        }
        private void CheckPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.button1_Click(sender, e);
            }
        }
    }
}
