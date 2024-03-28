namespace Database
{
    partial class FindPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            check_btn = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 88);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "전화번호";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(113, 137);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(277, 23);
            textBox3.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 140);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "인증번호";
            // 
            // check_btn
            // 
            check_btn.Location = new Point(410, 88);
            check_btn.Name = "check_btn";
            check_btn.Size = new Size(100, 23);
            check_btn.TabIndex = 13;
            check_btn.Text = "인증번호 받기";
            check_btn.UseVisualStyleBackColor = true;
            check_btn.Click += check_btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(410, 137);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 16;
            button1.Text = "인증번호 확인";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 23);
            textBox1.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 33);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 17;
            label1.Text = "아이디";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(113, 88);
            maskedTextBox1.Mask = "(999)9000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(277, 23);
            maskedTextBox1.TabIndex = 19;
            // 
            // FindPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 191);
            Controls.Add(maskedTextBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(check_btn);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FindPassword";
            Text = "ProfessorRegister";
            FormClosed += FindPassword_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private Button check_btn;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private MaskedTextBox maskedTextBox1;
    }
}