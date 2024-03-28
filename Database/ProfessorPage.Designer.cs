namespace Database
{
    partial class ProfessorPage
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
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(57, 68);
            button1.Name = "button1";
            button1.Size = new Size(133, 61);
            button1.TabIndex = 0;
            button1.Text = "교과목 사진 등록";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(295, 68);
            button2.Name = "button2";
            button2.Size = new Size(133, 61);
            button2.TabIndex = 1;
            button2.Text = "수강명부 조회";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(510, 68);
            button3.Name = "button3";
            button3.Size = new Size(133, 61);
            button3.TabIndex = 2;
            button3.Text = "과목별 성적관리";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 9);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 3;
            label1.Text = "안녕하세요 교수님";
            // 
            // button4
            // 
            button4.Location = new Point(638, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 35);
            button4.TabIndex = 4;
            button4.Text = "logout";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(57, 217);
            button5.Name = "button5";
            button5.Size = new Size(133, 61);
            button5.TabIndex = 5;
            button5.Text = "지도학생 조회";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(295, 217);
            button6.Name = "button6";
            button6.Size = new Size(133, 61);
            button6.TabIndex = 6;
            button6.Text = "상담입력 및 조회";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(524, 12);
            button7.Name = "button7";
            button7.Size = new Size(92, 35);
            button7.TabIndex = 7;
            button7.Text = "비밀번호 변경";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // ProfessorPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 351);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ProfessorPage";
            Text = "ProfessorPage";
            FormClosed += ProfessorPage_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}