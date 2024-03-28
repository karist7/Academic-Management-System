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
    public partial class GradeManagePage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        string num = "";
        string subject = "";
        string year = "";
        string semester = "";


        public GradeManagePage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT e.과목번호,(select 과목이름 from 과목 where 과목번호=e.과목번호) as 과목이름, e.학번, e.연도, e.학기, e.성적 " +
                                $"FROM 수강 e join 개설과목 g on e.과목번호 = g.과목번호 " +
                                $"where g.담당교수번호 = '{MainPage.ID}'" +
                                $"order by e.과목번호 asc, e.학번 asc";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!num.Equals(""))
            {
                if (!comboBox1.Text.Equals(""))
                {
                    DialogResult result = MessageBox.Show($"성적'{comboBox1.Text}' 확정하시겠습니까?", "성적 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    int row = 0;
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            OleDbCommand cmd = new OleDbCommand();
                            bool flag = false;
                            cmd.CommandText = $"update 수강 set 성적='{comboBox1.Text.Trim()}' where 학번='{num}' and " +
                                $"과목번호='{subject}' and 연도='{year}' and 학기='{semester}'";
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            row = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            if (row != 0)
                                MessageBox.Show("입력을 완료하였습니다.");
                            else
                                MessageBox.Show("입력에 실패했습니다.");


                            comboBox1.SelectedIndex = -1;
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
                    MessageBox.Show("성적을 선택해주세요.");
                }

            }
            else
            {
                MessageBox.Show("항목을 선택해주세요.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String c = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String d = (String)dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            num = b;
            subject = a;
            label2.Text = subject;
            label3.Text = num;
            year = c;
            semester = d;


        }

        private void GradeManagePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
