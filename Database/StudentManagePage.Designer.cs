namespace Database
{
    partial class StudentManagePage
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
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            button3 = new Button();
            button2 = new Button();
            추가 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox2 = new TextBox();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(496, 313);
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
            label4.TabIndex = 11;
            label4.Text = "학생 관리 페이지";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(542, 112);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 12;
            label1.Text = "이름";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(601, 112);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 23);
            textBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.CausesValidation = false;
            label2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(542, 159);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 14;
            label2.Text = "학년";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(526, 249);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 16;
            label3.Text = "지도교수";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(526, 203);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 18;
            label5.Text = "학과이름";
            // 
            // button3
            // 
            button3.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(671, 302);
            button3.Name = "button3";
            button3.Size = new Size(69, 51);
            button3.TabIndex = 22;
            button3.Text = "수정";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(746, 302);
            button2.Name = "button2";
            button2.Size = new Size(69, 51);
            button2.TabIndex = 21;
            button2.Text = "삭제";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // 추가
            // 
            추가.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            추가.Location = new Point(596, 302);
            추가.Name = "추가";
            추가.Size = new Size(69, 51);
            추가.TabIndex = 20;
            추가.Text = "추가";
            추가.UseVisualStyleBackColor = true;
            추가.Click += 추가_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "전체" });
            comboBox1.Location = new Point(601, 204);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(212, 23);
            comboBox1.TabIndex = 23;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(601, 250);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(212, 23);
            comboBox2.TabIndex = 24;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox2.Click += comboBox2_Click;
            // 
            // comboBox3
            // 
            comboBox3.CausesValidation = false;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "전체", "1", "2", "3", "4" });
            comboBox3.Location = new Point(601, 160);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(212, 23);
            comboBox3.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(601, 60);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(212, 23);
            textBox2.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(542, 60);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 26;
            label6.Text = "학번";
            // 
            // button1
            // 
            button1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(526, 302);
            button1.Name = "button1";
            button1.Size = new Size(64, 51);
            button1.TabIndex = 28;
            button1.Text = "조회";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // StudentManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 414);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(추가);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Name = "StudentManagePage";
            Text = "StudentManagePage";
            FormClosed += StudentManagePage_FormClosed;
            Load += StudentManagePage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label4;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Button button3;
        private Button button2;
        private Button 추가;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private TextBox textBox2;
        private Label label6;
        private Button button1;
    }
}