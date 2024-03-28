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
    public partial class CoursesOfferedPage : Form
    {
        OleDbConnection conn;

        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        string dept = "";
        public CoursesOfferedPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();

            LoadDataIntoDataGridView();
        }

        private void CoursesOfferedPage_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT * FROM 과목 order by 학과이름 asc,과목번호 asc";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                DataColumn newColumn = new DataColumn("개설여부", typeof(string));
                dataTable.Columns.Add(newColumn);


                // 특정 값으로 채우기 (예: "개설됨")
                foreach (DataRow row in dataTable.Rows)
                {
                    row["개설여부"] = "미개설";
                }

                OleDbCommand cmdCheck = new OleDbCommand();
                cmdCheck.CommandText = "SELECT DISTINCT 과목번호 FROM 개설과목";
                cmdCheck.CommandType = CommandType.Text;
                cmdCheck.Connection = conn;

                OleDbDataReader reader = cmdCheck.ExecuteReader();

                while (reader.Read())
                {
                    string 과목번호 = reader["과목번호"].ToString();

                    // 개설과목 테이블에 해당 과목번호가 존재하는지 확인
                    DataRow[] rows = dataTable.Select($"과목번호 = '{과목번호}'");

                    foreach (DataRow row in rows)
                    {
                        // 존재한다면 "미개설"을 "개설"로 변경
                        row["개설여부"] = "개설";
                    }
                }

                reader.Close();
                dataGridView1.DataSource = dataTable;
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }

        private void CoursesOfferedPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            bool flag = false;
            if (!textBox1.Text.Equals("") && !maskedTextBox1.Text.Equals("") && !comboBox1.Text.Equals("") && !comboBox2.Text.Equals(""))
            {
                if (int.Parse(maskedTextBox1.Text) >= 2023 && comboBox1.Text.Equals("2"))
                {
                    int index = 0;
                    int lengths = 0;
                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        index = comboBox2.Text.IndexOf('(');
                        lengths = comboBox2.Text.IndexOf(')') - index - 1; // 괄호 안의 길이 계산
                    }

                    string result = "";
                    if (index != -1 && lengths > 0)
                    {
                        result = comboBox2.Text.Substring(index + 1, lengths); // 괄호 안의 내용 추출
                    }

                    cmd.CommandText = $"insert into 개설과목 values('{textBox1.Text.Trim()}', '{maskedTextBox1.Text.Trim()}', " +
                                  $"'{comboBox1.Text.Trim()}','{result}',NULL)";

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();


                    MessageBox.Show($"개설되었습니다.");
                    LoadDataIntoDataGridView();


                    flag = true;
                }
                else
                {
                    MessageBox.Show("2023년도 이상, 해당 학기 과목만 개설 가능합니다.");
                }
            }
            else
            {
                MessageBox.Show("빈칸을 모두 채워주세요.");
            }
            if (flag)
            {

                textBox1.Text = "";
                maskedTextBox1.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "";
            if (e.RowIndex == -1)
            {
                return;
            }
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String h = (String)dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox1.Text = a;
            comboBox1.Text = b;
            dept = h;

            try
            {
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = $"SELECT 이름 || ' (' || 교수번호 || ')' AS 새로운필드 FROM 교수 WHERE 학과이름 = ? order by 교수번호 asc";
                cmd.Parameters.AddWithValue("?", dept);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }




        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = 0;
        }
    }
}
