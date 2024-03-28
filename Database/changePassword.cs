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
using System.Security.Cryptography;
using System.Reflection.Emit;

namespace Database
{
    public partial class changePassword : Form
    {
        OleDbConnection conn;
        string id;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public changePassword(string id)
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            this.id = id;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]{5,}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, pattern))
            {
                if (textBox1.Text.Equals(textBox2.Text))
                {
                    string value = textBox1.Text;

                    // SHA256 해시 생성
                    SHA256 hash = new SHA256Managed();
                    byte[] bytes = hash.ComputeHash(Encoding.ASCII.GetBytes(value));

                    // 16진수 형태로 문자열 결합
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in bytes)
                        sb.AppendFormat("{0:x2}", b);
                   
                    OleDbCommand cmd = new OleDbCommand();


                    cmd.CommandText = $"update 교수 set 비밀번호='{sb.ToString()}' where 교수번호='{id}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    
                 
                    


                    cmd.CommandText = $"update 학생 set 비밀번호='{sb.ToString()}' where 학번='{id}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("비밀번호를 변경했습니다.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("두 비밀번호가 일치하지 않습니다.");
                }
            }
            else
            {
                // 유효하지 않은 입력
                // 여기에 사용자에게 알림 등을 추가
                MessageBox.Show("영어와 숫자의 조합으로 5자 이상 입력하세요.");
            }
        }





        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                this.button1_Click(sender, e);
            }
        }

        private void changePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(textBox2.Text) && !textBox1.Text.Equals(""))
            {
                label4.Text = "두 비밀번호가 일치합니다.";
                label4.ForeColor = Color.Blue;
            }
            else
            {
                label4.Text = "두 비밀번호가 일치하지 않습니다.";
                label4.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(textBox2.Text) && !textBox2.Text.Equals(""))
            {
                label4.Text = "두 비밀번호가 일치합니다.";
                label4.ForeColor = Color.Blue;
            }
            else
            {
                label4.Text = "두 비밀번호가 일치하지 않습니다.";
                label4.ForeColor = Color.Red;
            }
        }
    }
}
