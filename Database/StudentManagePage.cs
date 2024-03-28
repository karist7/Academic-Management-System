using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{
    public partial class StudentManagePage : Form
    {
        OleDbConnection conn;

        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결

        public StudentManagePage()
        {
            InitializeComponent();

            try
            {
                conn = new OleDbConnection(connectionString);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = $"select 학과이름 from 학과";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
                cmd.Parameters.Clear();
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                LoadProfessor(conn);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }

            LoadDataIntoDataGridView();

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT 학번,이름,학년,지도교수,학과이름 FROM 학생 order by 학과이름 asc";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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
        private void LoadProfessor(OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand();

            if (!comboBox1.Text.Equals(""))
            {
                cmd.CommandText = $"SELECT 이름 || ' (' || 교수번호 || ')' AS 새로운필드 FROM 교수 WHERE 학과이름 = ? order by 교수번호 asc";
                cmd.Parameters.AddWithValue("?", comboBox1.Text);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            else
            {
                cmd.CommandText = $"SELECT 이름 || ' (' || 교수번호 || ')' AS 새로운필드 FROM 교수 order by 교수번호 asc";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }

        }

        private void StudentManagePage_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            LoadProfessor(conn);
        }

        private void 추가_Click(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand();
            bool flag = false;
            if (!textBox1.Text.Equals("") && !comboBox3.Text.Equals("전체") && !comboBox1.Text.Equals("전체") && !comboBox2.Text.Equals(""))
            {
                int index = comboBox2.Text.IndexOf('(');
                string result = "";
                if (index != -1)
                {
                    result = comboBox2.Text.Substring(0, index);

                }

                cmd.CommandText = $"insert into 학생 values(학번.NEXTVAL, '{textBox1.Text.Trim()}', '{comboBox3.Text.Trim()}', " +
                              $"'0000',(select 교수번호 from 교수 where 이름 = '{result.Trim()}' and 학과이름 = '{comboBox1.Text.Trim()}'),'{comboBox1.Text.Trim()}')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                MessageBox.Show($"등록이 완료되었습니다.");
                LoadDataIntoDataGridView();


                flag = true;
            }
            else
            {
                MessageBox.Show("빈칸을 모두 채워주세요.");
            }
            if (flag)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = 0;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        bool flag = false;


                        cmd.CommandText = $"delete from 학생 where 학번 = '{textBox2.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("삭제가 완료되었습니다.");
                        LoadDataIntoDataGridView();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = 0;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }
                }
            }
            else if (comboBox1.Text.Equals("전체") || comboBox3.Text.Equals("전체"))
                MessageBox.Show("삭제 시 전체항목은 선택 불가입니다.");
            else
            {
                MessageBox.Show("학생을 선택해주세요.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String c = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String d = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String f = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();



            textBox2.Text = f;
            textBox1.Text = a;
            comboBox1.Text = b;
            comboBox2.Text = c;
            comboBox3.Text = d;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals("") && !textBox1.Text.Equals("") && !comboBox2.Text.Equals("") && !comboBox1.Text.Equals("전체") && !comboBox3.Text.Equals("전체"))
            {
                DialogResult result = MessageBox.Show("수정하시겠습니까?", "수정 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int index = comboBox2.Text.IndexOf('(');
                    string result2 = "";
                    if (index != -1)
                    {
                        result2 = comboBox2.Text.Substring(0, index);

                    }
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        bool flag = false;




                        cmd.CommandText = $"update 학생 set 이름='{textBox1.Text.Trim()}', 학년='{comboBox3.Text.Trim()}' " +
                            $",지도교수=(select 교수번호 from 교수 where 이름 = '{result2.Trim()}' and 학과이름 = '{comboBox1.Text.Trim()}'),학과이름='{comboBox1.Text.Trim()}' where 학번 = '{textBox2.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        MessageBox.Show("수정이 완료되었습니다.");

                        LoadDataIntoDataGridView();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = 0;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = 0;
                        LoadDataIntoDataGridView();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }

                }
            }
            else if (comboBox1.Text.Equals("전체") || comboBox3.Text.Equals("전체"))
                MessageBox.Show("수정 시 전체항목은 선택 불가입니다.");
            else
            {
                MessageBox.Show("항목을 모두 채워주세요.");
            }
        }

        private void StudentManagePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 폼이 닫힐 때 커넥션 닫기
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("전체") && comboBox3.Text.Equals("전체"))
            {
                LoadDataIntoDataGridView();
            }
            else if (!comboBox1.Text.Equals("전체") && !comboBox3.Text.Equals("전체"))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 학번, 이름, 학년, 지도교수, 학과이름 FROM 학생 where 학과이름='{comboBox1.Text.Trim()}' and 학년='{comboBox3.Text.Trim()}' order by 학과이름 desc, 학번 asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                }
            }
            else if (!comboBox1.Text.Equals("전체") && comboBox3.Text.Equals("전체"))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 학번, 이름, 학년, 지도교수, 학과이름 FROM 학생 where 학과이름='{comboBox1.Text.Trim()}' order by 학과이름 desc, 학번 asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AllowUserToAddRows = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                }
            }
            else if (comboBox1.Text.Equals("전체") && !comboBox3.Text.Equals("전체"))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 학번, 이름, 학년, 지도교수, 학과이름 FROM 학생 where 학년='{comboBox3.Text.Trim()}' order by 학과이름 desc, 학번 asc";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.AllowUserToAddRows = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                }
            }
            else
            {
                MessageBox.Show("항목을 모두 선택하십시오.");
            }

        }
    }
}
