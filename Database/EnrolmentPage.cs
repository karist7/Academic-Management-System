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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{

    public partial class EnrolmentPage : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public EnrolmentPage()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            LoadDataIntoDataGridView();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            object value = dataGridView1.Rows[e.RowIndex].Cells[7].Value;
            if (value != DBNull.Value)
            {
                byte[] b = (byte[])value;

                if (b == null || b.Length == 0)
                {
                    // 교재가 null이거나 이미지 바이트 배열이 비어 있을 때
                    pictureBox1.Image = null;
                }
                else
                {
                    // 이미지 바이트 배열을 이미지로 변환하여 표시
                    Image image = ByteArrayToImage(b);

                    pictureBox1.Image = image;
                }
            }
            else
            {

                // 교재가 DBNull.Value일 때
                pictureBox1.Image = null;
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
                cmd.CommandText = $"SELECT e.과목번호, e.연도, e.학기, g.대상학년, g.과목이름, (select 이름 from 교수 where 교수번호 = e.담당교수번호)as 담당교수, e.교재 " +
                                $"FROM 개설과목 e join 과목 g on e.과목번호 = g.과목번호 " +
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
                    cmd.CommandText = $"select 과목번호 from 수강 where 학번='{MainPage.ID}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    OleDbDataReader reader = cmd.ExecuteReader();
                    bool flag = false;
                    while (reader.Read())
                    {

                        if (reader.GetString(0).Equals(rowView.Row[0].ToString().Trim()))
                        {
                            flag = true;
                            break;
                        }

                    }
                    cmd.Parameters.Clear();
                    reader.Close();


                    cmd.CommandText = $"select 학년 from 학생 where 학번='{MainPage.ID}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    OleDbDataReader reader2 = cmd.ExecuteReader();
                    bool flag2 = false;
                    while (reader2.Read())
                    {

                        if (reader2.GetString(0).Equals(rowView.Row[3].ToString().Trim()))
                        {
                            flag2 = true;
                            break;
                        }

                    }
                    reader2.Close();
                    cmd.Parameters.Clear();
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
                    if (flag3)
                    {
                        MessageBox.Show($"{rowView.Row[4].ToString().Trim()}과목은 이미 신청하셨습니다.");
                    }
                    else if (!flag && flag2)
                    {
                        DialogResult result = MessageBox.Show(rowView.Row[4].ToString() + "과목을 신청하시겠습니까?", "신청 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            cmd.CommandText = $"insert into 수강신청 values(:name,:num,:year,:semester,NULL)";

                            cmd.Parameters.AddWithValue(":name", MainPage.ID);
                            cmd.Parameters.AddWithValue(":num", rowView.Row[0].ToString().Trim());
                            cmd.Parameters.AddWithValue(":year", rowView.Row[1].ToString().Trim());
                            cmd.Parameters.AddWithValue(":semester", rowView.Row[2].ToString().Trim());
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            MessageBox.Show("수강신청을 완료했습니다.");
                        }

                    }
                    else if (!flag2)
                    {

                        MessageBox.Show($"{rowView.Row[4].ToString().Trim()}과목은 학년이 일치하지 않습니다.");
                    }
                    else
                    {
                        MessageBox.Show($"{rowView.Row[4].ToString().Trim()}과목은 이미 수강신청이 완료되었습니다.");
                    }




                    // 각 체크된 행에 대한 처리를 수행합니다.

                }

                LoadDataIntoDataGridView();
            }
            // 체크된 행들에 대한 처리를 수행합니다.

        }

        private void EnrolmentPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        private byte[] imageToByteArray(Image img)
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] b = (byte[])imageConverter.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private Image ByteArrayToImage(byte[] bytes)
        {
            ImageConverter imageConverter = new ImageConverter();
            Image img = (Image)imageConverter.ConvertFrom(bytes);
            return img;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myCoursePage CoursePage = new myCoursePage();
            CoursePage.ShowDialog();

        }
    }
}
