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

    public partial class DepartmentManagePage : Form
    {
        OleDbConnection conn;

        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public DepartmentManagePage()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();

            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT * FROM 학과 order by 학과이름 asc";
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

        private void 추가_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            bool flag = false;
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
            {

                cmd.CommandText = $"insert into 학과 values('{textBox1.Text.Trim()}','{textBox2.Text.Trim()}'," +
                    $"'{textBox3.Text.Trim()}')";

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

                cmd.CommandText = $@"
                    CREATE SEQUENCE {textBox1.Text.Trim()}_시퀀스
                      START WITH 1
                      INCREMENT BY 1
                      MAXVALUE 999
                      NOCYCLE";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            String name = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String c = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox1.Text = name;
            textBox2.Text = b;
            textBox3.Text = c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        bool flag = false;
                   

                            cmd.CommandText = $"delete from 학과 where 학과이름 = '{textBox1.Text}'";

                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("삭제가 완료되었습니다.");
                            LoadDataIntoDataGridView();

                            cmd.CommandText = $"drop sequence {textBox1.Text.Trim()}_시퀀스";
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }


                }
            }
            else
            {
                MessageBox.Show("학과를 선택해주세요.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals("") && !textBox3.Text.Equals(""))
            {
                DialogResult result = MessageBox.Show("수정하시겠습니까?", "수정 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int row = 0;
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        bool flag = false;
                    

                            cmd.CommandText = $"update 학과 set 단과대학='{textBox2.Text.Trim()}' " +
                                $",과사무실='{textBox3.Text.Trim()}' where 학과이름 = '{textBox1.Text.Trim()}'";

                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            row = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            if (row != 0)
                                MessageBox.Show("수정이 완료되었습니다.");
                            else
                                MessageBox.Show("수정을 실패했습니다. 학과 이름은 변경할 수 없습니다.");
                        
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            LoadDataIntoDataGridView();
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                    }
                }
            }
            else
            {
                MessageBox.Show("항목을 모두 채워주세요.");
            }
        }

        private void DepartmentManagePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 폼이 닫힐 때 커넥션 닫기
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

}
