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
    public partial class LectureCreditInquiryPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결

        public LectureCreditInquiryPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            OleDbCommand cmd = new OleDbCommand();

            comboBox2.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
        private void LoadDataIntoDataGridView()
        {


            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT e.이름 || ' (' || e.교수번호 || ')' AS 강의자, NVL(SUM(h.이수학점),0) as 강의학점 " +
                                $"FROM 교수 e " +
                                $"LEFT JOIN 개설과목 g ON e.교수번호 = g.담당교수번호 and g.학기='{comboBox2.Text.Trim()}'" +
                                $"LEFT JOIN 과목 h ON g.과목번호 = h.과목번호 " +

                                $"GROUP BY e.교수번호, e.이름";
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

        private void LectureCreditInquiryPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
