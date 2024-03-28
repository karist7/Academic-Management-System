namespace Database
{
    partial class SubjectManagePage
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
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button2 = new Button();
            추가 = new Button();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 40);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(842, 412);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 9);
            label4.Name = "label4";
            label4.Size = new Size(166, 28);
            label4.TabIndex = 12;
            label4.Text = "과목 관리 페이지";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(880, 38);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 13;
            label1.Text = "과목번호";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(952, 35);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(159, 23);
            textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(952, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(159, 23);
            textBox2.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(880, 88);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 15;
            label2.Text = "과목이름";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(880, 143);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 17;
            label3.Text = "대상학년";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(880, 186);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 19;
            label5.Text = "개설학기";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(880, 236);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 21;
            label6.Text = "전공구분";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(880, 286);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 23;
            label7.Text = "이수학점";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(880, 332);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 25;
            label8.Text = "학과이름";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(952, 332);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(159, 23);
            comboBox1.TabIndex = 26;
            // 
            // button3
            // 
            button3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(1040, 391);
            button3.Name = "button3";
            button3.Size = new Size(71, 47);
            button3.TabIndex = 29;
            button3.Text = "수정";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(952, 391);
            button2.Name = "button2";
            button2.Size = new Size(71, 47);
            button2.TabIndex = 28;
            button2.Text = "삭제";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // 추가
            // 
            추가.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            추가.Location = new Point(860, 391);
            추가.Name = "추가";
            추가.Size = new Size(71, 47);
            추가.TabIndex = 27;
            추가.Text = "추가";
            추가.UseVisualStyleBackColor = true;
            추가.Click += 추가_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4" });
            comboBox2.Location = new Point(952, 143);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(159, 23);
            comboBox2.TabIndex = 30;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "1", "2" });
            comboBox3.Location = new Point(952, 186);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(159, 23);
            comboBox3.TabIndex = 31;
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "전공", "교양" });
            comboBox4.Location = new Point(952, 236);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(159, 23);
            comboBox4.TabIndex = 32;
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "1", "2", "3" });
            comboBox5.Location = new Point(952, 286);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(159, 23);
            comboBox5.TabIndex = 33;
            // 
            // SubjectManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 493);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(추가);
            Controls.Add(comboBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Name = "SubjectManagePage";
            Text = "SubjectManagePage";
            FormClosed += SubjectManagePage_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label4;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Button 추가;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
    }
}