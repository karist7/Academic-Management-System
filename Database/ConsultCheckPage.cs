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
    public partial class ConsultCheckPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public ConsultCheckPage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            LoadDataIntoDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT * FROM 상담 where 학번='{MainPage.ID}' order by 상담일시 asc";
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

        private void ConsultCheckPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = a;
        }
    }
}
