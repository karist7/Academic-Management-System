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
    public partial class ApprovalPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결

        public ApprovalPage()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            LoadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DataRowView> checkedRows = new List<DataRowView>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // "체크" 열의 셀을 가져옵니다.
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["체크"] as DataGridViewCheckBoxCell;

                // null 체크 및 체크 여부 확인
                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                {
                    // DataRowView를 가져옵니다.
                    DataRowView dataRowView = row.DataBoundItem as DataRowView;

                    // null 체크
                    if (dataRowView != null)
                    {
                        checkedRows.Add(dataRowView);
                    }
                }
            }
            if (checkedRows.Count == 0)
            {
                MessageBox.Show("최소한 하나의 항목을 선택해주세요.");
            }
            else
            {
                DialogResult result = MessageBox.Show("모두 승인하시겠습니까?", "승인 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (DataRowView rowView in checkedRows)
                    {
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = $"insert into 수강 values(:name,:num,:year,:semester,NULL)";

                        cmd.Parameters.AddWithValue(":name", rowView.Row[0].ToString().Trim());
                        cmd.Parameters.AddWithValue(":num", rowView.Row[1].ToString().Trim());
                        cmd.Parameters.AddWithValue(":year", rowView.Row[2].ToString().Trim());
                        cmd.Parameters.AddWithValue(":semester", rowView.Row[3].ToString().Trim());
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        // 각 체크된 행에 대한 처리를 수행합니다.
                        cmd.CommandText = $"delete from 수강신청 where 과목번호=:num";
                        cmd.Parameters.AddWithValue(":num", rowView.Row[1].ToString().Trim());
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                    MessageBox.Show("수강승인을 완료했습니다.");
                    LoadDataIntoDataGridView();
                }
            }


        }
        bool isFirstLoad = true;  // 첫 번째 로드 여부를 나타내는 변수
        private void LoadDataIntoDataGridView()
        {
            try
            {
                if (isFirstLoad)
                {
                    DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                    dgvCmb.ValueType = typeof(bool);
                    dgvCmb.Name = "체크";
                    dataGridView1.Columns.Add(dgvCmb);

                    isFirstLoad = false;  // 첫 번째 로드가 끝났음을 표시
                }

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"select * from 수강신청 order by 학번 asc";
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

        private void ApprovalPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
