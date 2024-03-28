using Newtonsoft.Json.Linq;
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
    public partial class AddPicture : Form
    {
        OleDbConnection conn;
        string connectionString = "Provider=OraOLEDB.Oracle;Password=term;User ID=term"; //oracle 서버 연결
        Image image = null;
        Image thumnail_img = null;
        public AddPicture()
        {
            InitializeComponent();
            conn = new OleDbConnection(connectionString);
            conn.Open();
            LoadDataIntoDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = $"SELECT 과목번호,(select 과목이름 from 과목 where 과목번호=e.과목번호 ) as 과목이름,연도,학기,교재 FROM 개설과목 e where 담당교수번호 = '{MainPage.ID}'";
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
        public bool ThumbnailCallback()
        {
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = @"C:\Users\user\Pictures";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string image_file = string.Empty;
                image_file = dialog.FileName;

                image = Bitmap.FromFile(image_file);
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);//썸네일 만들기
                thumnail_img = image.GetThumbnailImage(400, 400, callback, new IntPtr()); //썸네일 만들기
                pictureBox1.Image = thumnail_img;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;



            }
            else return;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String a = (String)dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            object value = dataGridView1.Rows[e.RowIndex].Cells[4].Value;
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
                    textBox1.Text = a;
                    pictureBox1.Image = image;
                }
            }
            else
            {
                textBox1.Text = a;
                // 교재가 DBNull.Value일 때
                pictureBox1.Image = null;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE 개설과목 SET 교재 = ? WHERE 과목번호 = ?";
            cmd.Connection = conn;

            byte[] bytes = imageToByteArray(image);

            OleDbParameter imageParam = new OleDbParameter();
            imageParam.OleDbType = OleDbType.LongVarBinary;
            imageParam.ParameterName = "@image";
            imageParam.Value = bytes;

            OleDbParameter subjectNumberParam = new OleDbParameter();
            subjectNumberParam.OleDbType = OleDbType.VarChar;
            subjectNumberParam.ParameterName = "@subjectNumber";
            subjectNumberParam.Value = textBox1.Text;

            cmd.Parameters.Add(imageParam);
            cmd.Parameters.Add(subjectNumberParam);



            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            MessageBox.Show("이미지가 성공적으로 저장되었습니다.");
            LoadDataIntoDataGridView();



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

        private void AddPicture_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
