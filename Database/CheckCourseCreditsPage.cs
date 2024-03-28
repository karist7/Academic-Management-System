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
    public partial class CheckCourseCreditsPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결

        public CheckCourseCreditsPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT e.이름 || '(' || e.학번 || ')' AS 수강학생, NVL(SUM(h.이수학점), 0) as 수강학점 " +
                                $"FROM 학생 e " +
                                $"LEFT JOIN 수강 g ON e.학번 = g.학번 AND g.학기='{comboBox1.Text.Trim()}' " +
                                $"LEFT JOIN 과목 h ON g.과목번호 = h.과목번호 " +
                                $"GROUP BY e.학번, e.이름";

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
            LoadDataIntoDataGridView();
        }

        private void CheckCourseCreditsPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
