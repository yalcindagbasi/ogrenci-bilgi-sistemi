namespace YazLab1
{
    partial class AnaMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaMenu));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            button1 = new Button();
            hocaSifre = new TextBox();
            label9 = new Label();
            hocaId = new TextBox();
            label8 = new Label();
            panel5 = new Panel();
            ogrenciGirisYap = new Button();
            ogrencıSifre = new TextBox();
            label7 = new Label();
            ogrencıID = new TextBox();
            label6 = new Label();
            panel4 = new Panel();
            yoneticiGirisYap = new Button();
            yöneticipass = new TextBox();
            label5 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            panel3 = new Panel();
            label3 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(panel6, 2, 1);
            tableLayoutPanel1.Controls.Add(panel5, 1, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(0, -4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.24353F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 79.75647F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1464, 657);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = System.Drawing.Color.Khaki;
            panel6.Controls.Add(button1);
            panel6.Controls.Add(hocaSifre);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(hocaId);
            panel6.Controls.Add(label8);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(979, 135);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(482, 519);
            panel6.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Khaki;
            button1.BackgroundImage = (System.Drawing.Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new System.Drawing.Point(210, 249);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(108, 78);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // hocaSifre
            // 
            hocaSifre.Location = new System.Drawing.Point(210, 182);
            hocaSifre.Name = "hocaSifre";
            hocaSifre.PasswordChar = '*';
            hocaSifre.Size = new System.Drawing.Size(147, 23);
            hocaSifre.TabIndex = 8;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft Sans Serif", 15F);
            label9.Location = new System.Drawing.Point(86, 178);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(137, 23);
            label9.TabIndex = 7;
            label9.Text = "SİFRE";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hocaId
            // 
            hocaId.Location = new System.Drawing.Point(210, 134);
            hocaId.Name = "hocaId";
            hocaId.Size = new System.Drawing.Size(147, 23);
            hocaId.TabIndex = 6;
            hocaId.TextChanged += textBox2_TextChanged;
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft Sans Serif", 15F);
            label8.Location = new System.Drawing.Point(86, 134);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(137, 23);
            label8.TabIndex = 6;
            label8.Text = "ID";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = System.Drawing.Color.MistyRose;
            panel5.Controls.Add(ogrenciGirisYap);
            panel5.Controls.Add(ogrencıSifre);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(ogrencıID);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new System.Drawing.Point(491, 135);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(482, 519);
            panel5.TabIndex = 4;
            // 
            // ogrenciGirisYap
            // 
            ogrenciGirisYap.BackColor = System.Drawing.Color.Khaki;
            ogrenciGirisYap.BackgroundImage = (System.Drawing.Image)resources.GetObject("ogrenciGirisYap.BackgroundImage");
            ogrenciGirisYap.BackgroundImageLayout = ImageLayout.Stretch;
            ogrenciGirisYap.Location = new System.Drawing.Point(208, 259);
            ogrenciGirisYap.Name = "ogrenciGirisYap";
            ogrenciGirisYap.Size = new System.Drawing.Size(108, 78);
            ogrenciGirisYap.TabIndex = 5;
            ogrenciGirisYap.UseVisualStyleBackColor = false;
            ogrenciGirisYap.Click += ogrenciGirisYap_Click;
            // 
            // ogrencıSifre
            // 
            ogrencıSifre.Location = new System.Drawing.Point(240, 182);
            ogrencıSifre.Name = "ogrencıSifre";
            ogrencıSifre.PasswordChar = '*';
            ogrencıSifre.Size = new System.Drawing.Size(147, 23);
            ogrencıSifre.TabIndex = 5;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft Sans Serif", 15F);
            label7.Location = new System.Drawing.Point(79, 182);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(137, 23);
            label7.TabIndex = 5;
            label7.Text = "SİFRE";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ogrencıID
            // 
            ogrencıID.Location = new System.Drawing.Point(240, 134);
            ogrencıID.Name = "ogrencıID";
            ogrencıID.Size = new System.Drawing.Size(147, 23);
            ogrencıID.TabIndex = 3;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft Sans Serif", 15F);
            label6.Location = new System.Drawing.Point(79, 138);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(137, 23);
            label6.TabIndex = 2;
            label6.Text = "ID";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ActiveCaption;
            panel4.Controls.Add(yoneticiGirisYap);
            panel4.Controls.Add(yöneticipass);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(textBox1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(3, 135);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(482, 519);
            panel4.TabIndex = 3;
            // 
            // yoneticiGirisYap
            // 
            yoneticiGirisYap.BackgroundImage = (System.Drawing.Image)resources.GetObject("yoneticiGirisYap.BackgroundImage");
            yoneticiGirisYap.BackgroundImageLayout = ImageLayout.Stretch;
            yoneticiGirisYap.Location = new System.Drawing.Point(163, 259);
            yoneticiGirisYap.Name = "yoneticiGirisYap";
            yoneticiGirisYap.Size = new System.Drawing.Size(108, 78);
            yoneticiGirisYap.TabIndex = 6;
            yoneticiGirisYap.UseVisualStyleBackColor = true;
            yoneticiGirisYap.Click += button2_Click;
            // 
            // yöneticipass
            // 
            yöneticipass.Location = new System.Drawing.Point(200, 182);
            yöneticipass.Name = "yöneticipass";
            yöneticipass.PasswordChar = '*';
            yöneticipass.Size = new System.Drawing.Size(147, 23);
            yöneticipass.TabIndex = 3;
            yöneticipass.TextChanged += yöneticipass_TextChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft Sans Serif", 15F);
            label5.Location = new System.Drawing.Point(41, 182);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(137, 23);
            label5.TabIndex = 2;
            label5.Text = "SİFRE";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft Sans Serif", 15F);
            label4.Location = new System.Drawing.Point(41, 138);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(137, 23);
            label4.TabIndex = 1;
            label4.Text = "ID";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            label4.Click += label4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(200, 138);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(147, 23);
            textBox1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.Khaki;
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(979, 3);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(482, 126);
            panel3.TabIndex = 2;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 20F);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new System.Drawing.Point(54, 38);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(375, 51);
            label3.TabIndex = 2;
            label3.Text = "ÖĞRETMEN GİRİŞİ";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = SystemColors.GrayText;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(482, 126);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new System.Drawing.Point(53, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(375, 51);
            label1.TabIndex = 0;
            label1.Text = "YÖNETİCİ PANEL GİRİŞİ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.MistyRose;
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(491, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(482, 126);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 20F);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new System.Drawing.Point(54, 38);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(375, 51);
            label2.TabIndex = 1;
            label2.Text = "ÖGRENCİ GİRİŞİ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1463, 648);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private TextBox yöneticipass;
        private Button ogrenciGirisYap;
        private TextBox ogrencıSifre;
        private Label label7;
        private TextBox ogrencıID;
        private Label label6;
        private Button yoneticiGirisYap;
        private Label label5;
        private Button button1;
        private TextBox hocaSifre;
        private Label label9;
        private TextBox hocaId;
        private Label label8;
    }
}
