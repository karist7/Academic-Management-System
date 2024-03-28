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
    public partial class myCoursePage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결

        public myCoursePage()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            InitializeComponent();
            LoadDataIntoDataGridView();
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
                cmd.CommandText = $"SELECT e.과목번호, e.연도, e.학기, g.대상학년, g.과목이름, (select 이름 from 교수 where 교수번호 = h.담당교수번호)as 담당교수 " +
                              $"FROM 수강신청 e join 과목 g on e.과목번호 = g.과목번호 " +
                              $"join 개설과목 h on e.과목번호 = h.과목번호 " +
                              $"where g.학과이름 = (select 학과이름 from 학생 where 학번 = '{MainPage.ID}') " +
                              $"order by e.과목번호 asc";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);


                dataGridView1.DataSource = dataTable;
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            String number = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String name = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox1.Text = number;
            textBox2.Text = name;


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
                foreach (DataRowView rowView in checkedRows)
                {

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = $"select 과목번호 from 수강신청 where 과목번호='{rowView.Row[0].ToString().Trim()}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    OleDbDataReader reader3 = cmd.ExecuteReader();
                    bool flag3 = false;
                    while (reader3.Read())
                    {

                        if (reader3.GetString(0).Equals(rowView.Row[0].ToString().Trim()))
                        {
                            flag3 = true;
                            break;
                        }

                    }
                    reader3.Close();
                    cmd.Parameters.Clear();
                    DialogResult result = MessageBox.Show(rowView.Row[4].ToString() + "과목 수강신청을 취소하시겠습니까?", "취소 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (flag3)
                        {
                            cmd.CommandText = $"delete from 수강신청 where 과목번호='{rowView.Row[0].ToString().Trim()}'";


                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("수강신청을 취소했습니다.");
                        }
                        else
                        {
                            MessageBox.Show($"{rowView.Row[4].ToString()}과목은 수강신청이 되어있지 않습니다.");
                        }
                    }
                    // 각 체크된 행에 대한 처리를 수행합니다.

                }

                LoadDataIntoDataGridView();


            }
        }
    }
}
