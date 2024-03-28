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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database
{
    public partial class FindPassword : Form
    {
        int num = 0;
        bool check = false;
        string str = "";
        string ID = "";
        public FindPassword()
        {
            InitializeComponent();
        }

        private void check_btn_Click(object sender, EventArgs e)
        {
            string accountSid = "your id";
            string authToken = "your token";

            TwilioClient.Init(accountSid, authToken);
            Random rand = new Random();
            num = rand.Next(100000, 999999);
            str = num.ToString();


            var message = MessageResource.Create(

                body: $"인증번호는 {str}입니다",
                from: new Twilio.Types.PhoneNumber("+12056191558"),
                to: new Twilio.Types.PhoneNumber("+82" + maskedTextBox1.Text)
            );
            MessageBox.Show("인증번호를 발송했습니다.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (str.Equals(textBox3.Text.Trim()))
            {
                MessageBox.Show("인증에 성공하였습니다.");
                ID = textBox1.Text.Trim();
                changePassword change = new changePassword(ID);
                change.ShowDialog();
                this.Close();

            }
            else
                MessageBox.Show("인증에 실패하였습니다.");
        }

        private void FindPassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
