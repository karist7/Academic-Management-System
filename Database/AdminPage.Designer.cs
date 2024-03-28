namespace Database
{
    partial class AdminPage
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
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(51, 198);
            button1.Name = "button1";
            button1.Size = new Size(111, 62);
            button1.TabIndex = 0;
            button1.Text = "개설 교과목 입력";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(207, 198);
            button3.Name = "button3";
            button3.Size = new Size(111, 62);
            button3.TabIndex = 2;
            button3.Text = "수강 승인";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(367, 198);
            button4.Name = "button4";
            button4.Size = new Size(111, 62);
            button4.TabIndex = 3;
            button4.Text = "강의학점 수 조회";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(521, 198);
            button5.Name = "button5";
            button5.Size = new Size(111, 62);
            button5.TabIndex = 4;
            button5.Text = "수강학점 수 조회";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(51, 78);
            button6.Name = "button6";
            button6.Size = new Size(111, 62);
            button6.TabIndex = 5;
            button6.Text = "학생관리";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(207, 78);
            button7.Name = "button7";
            button7.Size = new Size(111, 62);
            button7.TabIndex = 6;
            button7.Text = "교수관리";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(367, 78);
            button8.Name = "button8";
            button8.Size = new Size(111, 62);
            button8.TabIndex = 7;
            button8.Text = "학과관리";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(523, 78);
            button9.Name = "button9";
            button9.Size = new Size(111, 62);
            button9.TabIndex = 8;
            button9.Text = "과목관리";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(550, 12);
            button10.Name = "button10";
            button10.Size = new Size(84, 47);
            button10.TabIndex = 9;
            button10.Text = "logout";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(25, 20);
            label1.Name = "label1";
            label1.Size = new Size(203, 28);
            label1.TabIndex = 10;
            label1.Text = "안녕하세요 관리자님.";
            // 
            // AdminPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 288);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Name = "AdminPage";
            Text = "AdminPage";
            FormClosed += AdminPage_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Label label1;
    }
}