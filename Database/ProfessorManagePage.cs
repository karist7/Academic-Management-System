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

using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{
    public partial class ProfessorManagePage : Form
    {
        OleDbConnection conn;

        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public ProfessorManagePage()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
            comboBox1.SelectedIndex = 0;
            LoadDataIntoDataGridView();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            bool flag = false;
            if (!textBox1.Text.Equals("") && !comboBox1.Text.Equals("전체"))
            {

                cmd.CommandText = $"insert into 교수 values(교수번호.NEXTVAL,'{textBox1.Text.Trim()}'," +
                    $"'0000','{comboBox1.Text.Trim()}')";

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

                comboBox1.Text = "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void ProfessorManagePage_Load(object sender, EventArgs e)
        {

        }

        private void ProfessorManagePage_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            String number = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String name = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String rn = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox2.Text = number;
            textBox1.Text = name;
            comboBox1.Text = rn;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT 교수번호, 이름, 학과이름 FROM 교수 order by 학과이름 desc, 교수번호 asc";
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


                        cmd.CommandText = $"delete from 교수 where 교수번호 = '{textBox2.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("삭제가 완료되었습니다.");
                        LoadDataIntoDataGridView();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.Text = "";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }
                }
            }
            else if (comboBox1.Text.Equals("전체"))
                MessageBox.Show("삭제 시 전체항목은 선택 불가입니다.");
            else
            {
                MessageBox.Show("교수번호를 선택해주세요.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals("") && !textBox1.Text.Equals("") && !comboBox1.Text.Equals("전체"))
            {
                DialogResult result = MessageBox.Show("수정하시겠습니까?", "수정 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int row = 0;
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        bool flag = false;


                        cmd.CommandText = $"update 교수 set 이름='{textBox1.Text.Trim()}', 학과이름='{comboBox1.Text.Trim()}' " +
                            $"where 교수번호 = '{textBox2.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        row = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        if (row != 0)
                            MessageBox.Show("수정이 완료되었습니다.");
                        else
                            MessageBox.Show("수정을 실패했습니다. 교수번호는 변경할 수 없습니다.");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;
                        LoadDataIntoDataGridView();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }
                }
            }
            else if (comboBox1.Text.Equals("전체"))
                MessageBox.Show("수정 시 전체항목은 선택 불가입니다.");
            else
            {
                MessageBox.Show("항목을 모두 채워주세요.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProfessorManagePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 폼이 닫힐 때 커넥션 닫기
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("전체"))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 교수번호, 이름, 학과이름 FROM 교수 where 학과이름='{comboBox1.Text.Trim()}' order by 학과이름 desc, 교수번호 asc";
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
            else
            {
                LoadDataIntoDataGridView();
            }
        }
    }
}
