namespace Database
{
    partial class StudentPage
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 21);
            label1.TabIndex = 0;
            label1.Text = "안녕하세요 학생님";
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(33, 66);
            button1.Name = "button1";
            button1.Size = new Size(145, 65);
            button1.TabIndex = 1;
            button1.Text = "수강신청";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(304, 66);
            button2.Name = "button2";
            button2.Size = new Size(145, 65);
            button2.TabIndex = 2;
            button2.Text = "성적조회";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(33, 193);
            button3.Name = "button3";
            button3.Size = new Size(145, 65);
            button3.TabIndex = 3;
            button3.Text = "상담조회";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(359, 2);
            button4.Name = "button4";
            button4.Size = new Size(101, 38);
            button4.TabIndex = 4;
            button4.Text = "logout";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(304, 193);
            button5.Name = "button5";
            button5.Size = new Size(145, 65);
            button5.TabIndex = 5;
            button5.Text = "수강신청 확인";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(252, 5);
            button7.Name = "button7";
            button7.Size = new Size(92, 35);
            button7.TabIndex = 8;
            button7.Text = "비밀번호 변경";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // StudentPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 289);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "StudentPage";
            Text = "StudentPage";
            FormClosed += StudentPage_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
    }
}