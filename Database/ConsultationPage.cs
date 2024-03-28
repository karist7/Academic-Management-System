using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.TwiML.Voice;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{
    public partial class ConsultationPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public ConsultationPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            try
            {
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = $"select 이름 || '(' || 학번 || ')' AS 새로운필드 from 학생 where 지도교수='{MainPage.ID}'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;



                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
            LoadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            int lengths = 0;
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                index = comboBox1.Text.IndexOf('(');
                lengths = comboBox1.Text.IndexOf(')') - index - 1; // 괄호 안의 길이 계산
            }

            string result = "";
            if (index != -1 && lengths > 0)
            {
                result = comboBox1.Text.Substring(index + 1, lengths); // 괄호 안의 내용 추출
            }

            DateTime selectedDate = dateTimePicker1.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select * from 상담 where 학번 = :num and 상담일시 = TO_DATE(:year, 'YYYY-MM-DD')";
            cmd.Parameters.AddWithValue(":num", result);
            cmd.Parameters.AddWithValue(":year", formattedDate);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            bool flag = false;



            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dates = (DateTime)reader.GetValue(1);
                string format = dates.ToString("yyyy-MM-dd");
                if (formattedDate.Equals(format) && result.Equals(reader.GetString(0)))
                {

                    flag = true;
                    break;
                }
            }

            reader.Close();
            cmd.Parameters.Clear();

            if (!flag)
            {
                cmd.CommandText = "insert into 상담 values(:num, TO_DATE(:year, 'YYYY-MM-DD'), :value)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(":num", result);
                cmd.Parameters.AddWithValue(":year", formattedDate);
                cmd.Parameters.AddWithValue(":value", textBox1.Text.Trim());

                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                MessageBox.Show("등록이 완료되었습니다.");
            }
            else
            {

                cmd.CommandText = $"UPDATE 상담 SET 상담내용='{textBox1.Text}' WHERE 학번='{result}' AND 상담일시 = '{formattedDate}'";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                MessageBox.Show("수정이 완료되었습니다.");
            }
            LoadDataIntoDataGridView();

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT e.학번, e.상담일시, e.상담내용 " +
                                $"FROM 상담 e " +
                                $"JOIN 학생 g ON e.학번 = g.학번 " +
                                $"WHERE g.지도교수 = '{MainPage.ID}' " +
                                $"ORDER BY e.학번 ASC, e.상담일시 asc";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String c = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"select 이름 from 학생 where 학번='{a}'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            string res = "";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                res = reader.GetString(0);
            }
            string formated = res + "(" + a + ")";

            comboBox1.Text = formated;
            dateTimePicker1.Text = b;
            textBox1.Text = c;
        }

        private void ConsultationPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
