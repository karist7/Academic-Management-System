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
    public partial class SubjectManagePage : Form
    {
        OleDbConnection conn;

        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        public SubjectManagePage()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = $"select 학과이름 from 학과";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); //에러 메세지 
            }
            LoadDataIntoDataGridView();
        }

        private void 추가_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals("") && comboBox3.SelectedIndex != -1 && comboBox4.SelectedIndex != -1 && comboBox5.SelectedIndex != -1
                && comboBox2.SelectedIndex != -1 && comboBox1.SelectedIndex != -1)
            {
                string dept = "";
                string subDept = "";
                string sequenceValue = "";
                string name = "";
                if (comboBox4.Text.Equals("전공"))
                {
                    dept = comboBox1.Text.ToString();
                    subDept = dept.Substring(0, dept.Length - 1) + "_C_";
                    name = subDept;
                }
                else
                {
                    dept = "SCH";
                    name = dept + "_C_";
                }

                using (OleDbCommand cmd = new OleDbCommand($"SELECT to_char({dept}_시퀀스.NEXTVAL,'FM000') FROM DUAL", conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        sequenceValue = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("시퀀스 오류");
                        return;
                    }
                }
                name += sequenceValue;
                using (OleDbCommand cmd = new OleDbCommand("insert into 과목 values(:name, :value2, :value3, :value4, :value5, :value6, :value7)", conn))
                {
                    // 파라미터 추가
                    cmd.Parameters.AddWithValue(":name", name);
                    cmd.Parameters.AddWithValue(":value2", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue(":value3", comboBox2.Text.Trim());
                    cmd.Parameters.AddWithValue(":value4", comboBox3.Text.Trim());
                    cmd.Parameters.AddWithValue(":value5", comboBox4.Text.Trim());
                    cmd.Parameters.AddWithValue(":value6", comboBox5.Text.Trim());
                    cmd.Parameters.AddWithValue(":value7", comboBox1.Text.Trim());

                    // 쿼리 실행
                    int result = cmd.ExecuteNonQuery();

                    // result에는 쿼리로 영향을 받은 행의 수가 포함됩니다.
                    if (result != 0)
                        MessageBox.Show("과목을 추가했습니다.");
                    else
                        MessageBox.Show("과목추가를 실패했습니다.");

                }

                LoadDataIntoDataGridView();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
            }
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT * FROM 과목 order by 학과이름 asc,과목번호 asc";
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    bool flag = false;
                    if (!textBox1.Text.Equals(""))
                    {

                        cmd.CommandText = $"delete from 과목 where 과목번호 = '{textBox1.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        MessageBox.Show("삭제가 완료되었습니다.");
                        LoadDataIntoDataGridView();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        comboBox4.SelectedIndex = -1;
                        comboBox5.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("과목을 선택해주세요.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                }
            }
            else
            {
                // 사용자가 '아니오' 또는 창을 닫은 경우
                // 삭제 작업 취소 또는 다른 작업 수행
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            String b = (String)dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String c = (String)dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String d = (String)dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            String f = (String)dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            String g = (String)dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            String h = (String)dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();


            textBox1.Text = a;
            textBox2.Text = b;

            comboBox1.Text = h;
            comboBox2.Text = c;
            comboBox3.Text = d;
            comboBox4.Text = f;
            comboBox5.Text = g;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("수정하시겠습니까?(과목구분, 학과는 수정이 불가능합니다)", "수정 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                try
                {
                    OleDbCommand cmd = new OleDbCommand();
                    bool flag = false;


                    if (!textBox1.Text.Equals("") && !comboBox2.Text.Equals("") && !comboBox3.Text.Equals("") && !comboBox5.Text.Equals(""))
                    {

                        cmd.CommandText = $"update 과목 set 과목이름='{textBox2.Text.Trim()}', 대상학년='{comboBox2.Text.Trim()}' " +
                            $",개설학기='{comboBox3.Text.Trim()}',이수학점='{comboBox5.Text.Trim()}' where 과목번호 = '{textBox1.Text.Trim()}'";

                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        MessageBox.Show("수정이 완료되었습니다.");

                        LoadDataIntoDataGridView();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        comboBox4.SelectedIndex = -1;
                        comboBox5.SelectedIndex = -1;
                    }
                    else
                        MessageBox.Show("과목을 선택해주세요.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); //에러 메세지 
                }
            }
        }

        private void SubjectManagePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
