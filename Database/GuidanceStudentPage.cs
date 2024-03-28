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
    public partial class GuidanceStudentPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public GuidanceStudentPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            LoadDataIntoDataGridView();
            
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                if (comboBox1.Text.Equals("전체"))
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 학번,이름,학년 FROM 학생 where 지도교수 = '{MainPage.ID}'order by 학번 asc";
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
                else
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"SELECT 학번,이름,학년 FROM 학생 where 지도교수 = '{MainPage.ID}' and 학년='{comboBox1.Text.Trim()}' order by 학번 asc";
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void GuidanceStudentPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }

}
