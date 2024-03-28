namespace Database
{
    partial class ProfessorManagePage
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
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 28);
            label1.TabIndex = 0;
            label1.Text = "교수 관리 페이지";
            // 
            // button1
            // 
            button1.Location = new Point(634, 360);
            button1.Name = "button1";
            button1.Size = new Size(70, 58);
            button1.TabIndex = 1;
            button1.Text = "추가";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(786, 360);
            button2.Name = "button2";
            button2.Size = new Size(68, 58);
            button2.TabIndex = 2;
            button2.Text = "삭제";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(710, 360);
            button3.Name = "button3";
            button3.Size = new Size(67, 58);
            button3.TabIndex = 3;
            button3.Text = "수정";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(22, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(501, 373);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "전체" });
            comboBox1.Location = new Point(621, 252);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 23);
            comboBox1.TabIndex = 13;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(547, 252);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 12;
            label4.Text = "학과이름";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(621, 161);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(233, 23);
            textBox1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(547, 164);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 10;
            label2.Text = "이름";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(621, 83);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(233, 23);
            textBox2.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(547, 86);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 14;
            label3.Text = "교수번호";
            // 
            // button4
            // 
            button4.Location = new Point(558, 360);
            button4.Name = "button4";
            button4.Size = new Size(70, 58);
            button4.TabIndex = 16;
            button4.Text = "조회";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // ProfessorManagePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 460);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "ProfessorManagePage";
            Text = "ProfessorManagePage";
            FormClosed += ProfessorManagePage_FormClosed;
            Load += ProfessorManagePage_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private Button button4;
    }
}