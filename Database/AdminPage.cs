using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }



        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MainPage mainForm = new MainPage();
                this.Visible = false;

                MainPage.INFO = "";
                MainPage.ID = "";
                mainForm.ShowDialog();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProfessorManagePage professorManagePage = new ProfessorManagePage();
            professorManagePage.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DepartmentManagePage departmentManagePage = new DepartmentManagePage();
            departmentManagePage.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StudentManagePage studentManagePage = new StudentManagePage();
            studentManagePage.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SubjectManagePage subjectManagePage = new SubjectManagePage();
            subjectManagePage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoursesOfferedPage courseManagePage = new CoursesOfferedPage();
            courseManagePage.ShowDialog();
        }

        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApprovalPage approvalPage = new ApprovalPage();
            approvalPage.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckCourseCreditsPage checkCourseCreditsPage = new CheckCourseCreditsPage();
            checkCourseCreditsPage.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LectureCreditInquiryPage lectureCreditInquiryPage = new LectureCreditInquiryPage();
            lectureCreditInquiryPage.ShowDialog();
        }
    }
}
