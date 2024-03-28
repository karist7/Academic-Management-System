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
    public partial class ConfirmPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public ConfirmPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            InitializeComponent();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = $"SELECT g.과목이름 " +
                            $"FROM 개설과목 e join 과목 g on e.과목번호 = g.과목번호 " +
                            $"where e.담당교수번호 = '{MainPage.ID}'" +
                            $"order by g.과목이름 asc";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }

        }
        private void LoadDataIntoDataGridView()
        {
            if (!comboBox1.Text.Equals(""))
            {

                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT e.학번, g.이름, g.학년 " +
                                    $"FROM 수강 e join 학생 g on e.학번 = g.학번 " +
                                    $"join 개설과목 h on e.과목번호 = h.과목번호 " +
                                    $"where h.담당교수번호 = '{MainPage.ID}' " +
                                    $"and e.과목번호 = (select 과목번호 from 과목 where 과목이름 = '{comboBox1.Text.Trim()}')" +
                                    $"order by e.학번 asc";
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
                MessageBox.Show("과목을 선택해주세요"); //에러 메세지 
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void ConfirmPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
