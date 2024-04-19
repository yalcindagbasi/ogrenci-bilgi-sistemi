namespace YazLab1
{
    partial class HocaEkran
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HocaEkran));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button2 = new Button();
            pictureBox2 = new PictureBox();
            derslerimButton = new Button();
            button3 = new Button();
            lblKalanZaman = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox1 = new PictureBox();
            DerslerimPanel = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel3 = new Panel();
            dataGridViewDersiAlanlar = new DataGridView();
            dersAlanOgrenciListele = new Button();
            label1 = new Label();
            dersSecenOgrencilerComboBox = new ComboBox();
            panel2 = new Panel();
            mesajPanelHoca = new Panel();
            btnyeniMesaj = new Button();
            mesajTablePanelHoca = new TableLayoutPanel();
            lblsonmesajlar = new Label();
            panel7 = new Panel();
            ilgiEkleButton = new Button();
            label3 = new Label();
            ilgiBox = new TextBox();
            panel6 = new Panel();
            label6 = new Label();
            button4 = new Button();
            kriterdersComboBox = new ComboBox();
            kriterdersTextBox = new TextBox();
            label7 = new Label();
            hocaDerslerimDataView = new DataGridView();
            label2 = new Label();
            tabPage2 = new TabPage();
            panel4 = new Panel();
            button1 = new Button();
            label4 = new Label();
            tumderslerbox = new ComboBox();
            ogrenciDurumlarıDataGrid = new DataGridView();
            tabPage3 = new TabPage();
            panel5 = new Panel();
            button5 = new Button();
            label5 = new Label();
            ogrencininAldigiDerslerDataGrid = new DataGridView();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            panel9 = new Panel();
            btn_yeniMesaj = new Button();
            mesajTablePanel = new TableLayoutPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDersiAlanlar).BeginInit();
            panel2.SuspendLayout();
            mesajPanelHoca.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hocaDerslerimDataView).BeginInit();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ogrenciDurumlarıDataGrid).BeginInit();
            tabPage3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ogrencininAldigiDerslerDataGrid).BeginInit();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(288, 772);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.2056732F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.79433F));
            tableLayoutPanel1.Controls.Add(button2, 1, 2);
            tableLayoutPanel1.Controls.Add(pictureBox2, 0, 0);
            tableLayoutPanel1.Controls.Add(derslerimButton, 1, 0);
            tableLayoutPanel1.Controls.Add(button3, 1, 1);
            tableLayoutPanel1.Controls.Add(lblKalanZaman, 1, 3);
            tableLayoutPanel1.Controls.Add(pictureBox3, 0, 1);
            tableLayoutPanel1.Controls.Add(pictureBox4, 0, 2);
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 169);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.6598625F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.3401375F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 366F));
            tableLayoutPanel1.Size = new System.Drawing.Size(282, 600);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(91, 155);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(188, 75);
            button2.TabIndex = 3;
            button2.Text = "OGRENCİLERİ LİSTELE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(3, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(82, 67);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // derslerimButton
            // 
            derslerimButton.Location = new System.Drawing.Point(91, 3);
            derslerimButton.Name = "derslerimButton";
            derslerimButton.Size = new System.Drawing.Size(188, 67);
            derslerimButton.TabIndex = 1;
            derslerimButton.Text = "DERSLERİM";
            derslerimButton.UseVisualStyleBackColor = true;
            derslerimButton.Click += derslerimButton_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(91, 78);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(188, 70);
            button3.TabIndex = 4;
            button3.Text = "ONAY DURUMU EKRANI";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // lblKalanZaman
            // 
            lblKalanZaman.AutoSize = true;
            lblKalanZaman.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblKalanZaman.Location = new System.Drawing.Point(91, 233);
            lblKalanZaman.Name = "lblKalanZaman";
            lblKalanZaman.Size = new System.Drawing.Size(157, 64);
            lblKalanZaman.TabIndex = 7;
            lblKalanZaman.Text = "Kalan Zaman:\r\n00.00:00:00";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new System.Drawing.Point(3, 78);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(82, 67);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new System.Drawing.Point(3, 155);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(82, 67);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(162, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // DerslerimPanel
            // 
            DerslerimPanel.Location = new System.Drawing.Point(292, 3);
            DerslerimPanel.Name = "DerslerimPanel";
            DerslerimPanel.Size = new System.Drawing.Size(1157, 769);
            DerslerimPanel.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new System.Drawing.Point(292, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1154, 772);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(1146, 744);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.NavajoWhite;
            panel3.Controls.Add(dataGridViewDersiAlanlar);
            panel3.Controls.Add(dersAlanOgrenciListele);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(dersSecenOgrencilerComboBox);
            panel3.Location = new System.Drawing.Point(3, 374);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(1144, 362);
            panel3.TabIndex = 7;
            // 
            // dataGridViewDersiAlanlar
            // 
            dataGridViewDersiAlanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDersiAlanlar.Location = new System.Drawing.Point(293, 35);
            dataGridViewDersiAlanlar.Name = "dataGridViewDersiAlanlar";
            dataGridViewDersiAlanlar.Size = new System.Drawing.Size(640, 302);
            dataGridViewDersiAlanlar.TabIndex = 6;
            // 
            // dersAlanOgrenciListele
            // 
            dersAlanOgrenciListele.Location = new System.Drawing.Point(44, 77);
            dersAlanOgrenciListele.Name = "dersAlanOgrenciListele";
            dersAlanOgrenciListele.Size = new System.Drawing.Size(141, 40);
            dersAlanOgrenciListele.TabIndex = 5;
            dersAlanOgrenciListele.Text = "LİSTELE";
            dersAlanOgrenciListele.UseVisualStyleBackColor = true;
            dersAlanOgrenciListele.Click += dersAlanOgrenciListele_Click_1;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.White;
            label1.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(6, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(105, 23);
            label1.TabIndex = 4;
            label1.Text = "DERS SEÇ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dersSecenOgrencilerComboBox
            // 
            dersSecenOgrencilerComboBox.BackColor = SystemColors.InactiveCaption;
            dersSecenOgrencilerComboBox.FormattingEnabled = true;
            dersSecenOgrencilerComboBox.Location = new System.Drawing.Point(122, 35);
            dersSecenOgrencilerComboBox.Name = "dersSecenOgrencilerComboBox";
            dersSecenOgrencilerComboBox.Size = new System.Drawing.Size(165, 23);
            dersSecenOgrencilerComboBox.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ScrollBar;
            panel2.Controls.Add(mesajPanelHoca);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(hocaDerslerimDataView);
            panel2.Controls.Add(label2);
            panel2.Location = new System.Drawing.Point(3, 6);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1144, 371);
            panel2.TabIndex = 2;
            // 
            // mesajPanelHoca
            // 
            mesajPanelHoca.AutoScroll = true;
            mesajPanelHoca.BackColor = System.Drawing.Color.Gainsboro;
            mesajPanelHoca.Controls.Add(btnyeniMesaj);
            mesajPanelHoca.Controls.Add(mesajTablePanelHoca);
            mesajPanelHoca.Controls.Add(lblsonmesajlar);
            mesajPanelHoca.Location = new System.Drawing.Point(827, 0);
            mesajPanelHoca.Name = "mesajPanelHoca";
            mesajPanelHoca.Size = new System.Drawing.Size(317, 369);
            mesajPanelHoca.TabIndex = 12;
            // 
            // btnyeniMesaj
            // 
            btnyeniMesaj.BackColor = System.Drawing.Color.White;
            btnyeniMesaj.Location = new System.Drawing.Point(180, 0);
            btnyeniMesaj.Name = "btnyeniMesaj";
            btnyeniMesaj.Size = new System.Drawing.Size(119, 23);
            btnyeniMesaj.TabIndex = 2;
            btnyeniMesaj.Text = "Yeni Mesaj Oluştur";
            btnyeniMesaj.UseVisualStyleBackColor = false;
            btnyeniMesaj.Click += btnyeniMesaj_Click;
            // 
            // mesajTablePanelHoca
            // 
            mesajTablePanelHoca.ColumnCount = 1;
            mesajTablePanelHoca.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mesajTablePanelHoca.Location = new System.Drawing.Point(0, 23);
            mesajTablePanelHoca.Name = "mesajTablePanelHoca";
            mesajTablePanelHoca.RowCount = 8;
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanelHoca.Size = new System.Drawing.Size(300, 800);
            mesajTablePanelHoca.TabIndex = 1;
            // 
            // lblsonmesajlar
            // 
            lblsonmesajlar.AutoSize = true;
            lblsonmesajlar.Location = new System.Drawing.Point(3, 3);
            lblsonmesajlar.Name = "lblsonmesajlar";
            lblsonmesajlar.Size = new System.Drawing.Size(74, 15);
            lblsonmesajlar.TabIndex = 0;
            lblsonmesajlar.Text = "Son Mesajlar";
            // 
            // panel7
            // 
            panel7.BackColor = System.Drawing.Color.OldLace;
            panel7.Controls.Add(ilgiEkleButton);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(ilgiBox);
            panel7.Location = new System.Drawing.Point(507, 3);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(283, 179);
            panel7.TabIndex = 11;
            // 
            // ilgiEkleButton
            // 
            ilgiEkleButton.Location = new System.Drawing.Point(67, 100);
            ilgiEkleButton.Name = "ilgiEkleButton";
            ilgiEkleButton.Size = new System.Drawing.Size(116, 40);
            ilgiEkleButton.TabIndex = 7;
            ilgiEkleButton.Text = "EKLE";
            ilgiEkleButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(13, 24);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92, 20);
            label3.TabIndex = 6;
            label3.Text = "İLGİ EKLE";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // ilgiBox
            // 
            ilgiBox.Location = new System.Drawing.Point(127, 24);
            ilgiBox.Name = "ilgiBox";
            ilgiBox.Size = new System.Drawing.Size(100, 23);
            ilgiBox.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.BackColor = System.Drawing.Color.Tan;
            panel6.Controls.Add(label6);
            panel6.Controls.Add(button4);
            panel6.Controls.Add(kriterdersComboBox);
            panel6.Controls.Add(kriterdersTextBox);
            panel6.Controls.Add(label7);
            panel6.Location = new System.Drawing.Point(507, 183);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(283, 179);
            panel6.TabIndex = 10;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(17, 21);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(135, 23);
            label6.TabIndex = 6;
            label6.Text = "KRİTER DERS SEÇ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(106, 100);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(110, 40);
            button4.TabIndex = 9;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // kriterdersComboBox
            // 
            kriterdersComboBox.FormattingEnabled = true;
            kriterdersComboBox.Location = new System.Drawing.Point(158, 21);
            kriterdersComboBox.Name = "kriterdersComboBox";
            kriterdersComboBox.Size = new System.Drawing.Size(121, 23);
            kriterdersComboBox.TabIndex = 5;
            // 
            // kriterdersTextBox
            // 
            kriterdersTextBox.Location = new System.Drawing.Point(158, 57);
            kriterdersTextBox.Name = "kriterdersTextBox";
            kriterdersTextBox.Size = new System.Drawing.Size(121, 23);
            kriterdersTextBox.TabIndex = 8;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new System.Drawing.Point(17, 54);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(135, 23);
            label7.TabIndex = 7;
            label7.Text = "KATSAYI SEÇ";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hocaDerslerimDataView
            // 
            hocaDerslerimDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hocaDerslerimDataView.Location = new System.Drawing.Point(37, 67);
            hocaDerslerimDataView.Name = "hocaDerslerimDataView";
            hocaDerslerimDataView.Size = new System.Drawing.Size(450, 277);
            hocaDerslerimDataView.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new System.Drawing.Point(37, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(419, 44);
            label2.TabIndex = 0;
            label2.Text = "DERSLERİM";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel4);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(1146, 744);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(tumderslerbox);
            panel4.Controls.Add(ogrenciDurumlarıDataGrid);
            panel4.Location = new System.Drawing.Point(3, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(1143, 744);
            panel4.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(427, 87);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(126, 35);
            button1.TabIndex = 3;
            button1.Text = "GÖSTER";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(38, 47);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(104, 23);
            label4.TabIndex = 2;
            label4.Text = "DERS SEÇ";
            // 
            // tumderslerbox
            // 
            tumderslerbox.FormattingEnabled = true;
            tumderslerbox.Location = new System.Drawing.Point(175, 47);
            tumderslerbox.Name = "tumderslerbox";
            tumderslerbox.Size = new System.Drawing.Size(121, 23);
            tumderslerbox.TabIndex = 1;
            tumderslerbox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // ogrenciDurumlarıDataGrid
            // 
            ogrenciDurumlarıDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ogrenciDurumlarıDataGrid.Location = new System.Drawing.Point(3, 133);
            ogrenciDurumlarıDataGrid.Name = "ogrenciDurumlarıDataGrid";
            ogrenciDurumlarıDataGrid.Size = new System.Drawing.Size(1137, 605);
            ogrenciDurumlarıDataGrid.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel5);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new System.Drawing.Size(1146, 744);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = System.Drawing.Color.LightSalmon;
            panel5.Controls.Add(button5);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(ogrencininAldigiDerslerDataGrid);
            panel5.Location = new System.Drawing.Point(3, 0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(1147, 745);
            panel5.TabIndex = 0;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(437, 71);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(158, 47);
            button5.TabIndex = 2;
            button5.Text = "GÖSTER";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(125, 12);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(936, 56);
            label5.TabIndex = 1;
            label5.Text = "ÖĞRENCİLERİN ALDIKLARI DERSLERİ GÖRMEK İÇİN İLGİLİ BUTONA TIKLAYINIZ";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ogrencininAldigiDerslerDataGrid
            // 
            ogrencininAldigiDerslerDataGrid.BackgroundColor = SystemColors.ControlLight;
            ogrencininAldigiDerslerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ogrencininAldigiDerslerDataGrid.Location = new System.Drawing.Point(0, 124);
            ogrencininAldigiDerslerDataGrid.Name = "ogrencininAldigiDerslerDataGrid";
            ogrencininAldigiDerslerDataGrid.Size = new System.Drawing.Size(1147, 612);
            ogrencininAldigiDerslerDataGrid.TabIndex = 0;
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // panel9
            // 
            panel9.AutoScroll = true;
            panel9.BackColor = System.Drawing.Color.Gainsboro;
            panel9.Controls.Add(btn_yeniMesaj);
            panel9.Location = new System.Drawing.Point(0, 0);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(200, 100);
            panel9.TabIndex = 0;
            // 
            // btn_yeniMesaj
            // 
            btn_yeniMesaj.BackColor = System.Drawing.Color.White;
            btn_yeniMesaj.Location = new System.Drawing.Point(180, 0);
            btn_yeniMesaj.Name = "btn_yeniMesaj";
            btn_yeniMesaj.Size = new System.Drawing.Size(119, 23);
            btn_yeniMesaj.TabIndex = 2;
            btn_yeniMesaj.Text = "Yeni Mesaj Oluştur";
            btn_yeniMesaj.UseVisualStyleBackColor = false;
            // 
            // mesajTablePanel
            // 
            mesajTablePanel.ColumnCount = 1;
            mesajTablePanel.Location = new System.Drawing.Point(0, 0);
            mesajTablePanel.Name = "mesajTablePanel";
            mesajTablePanel.RowCount = 8;
            mesajTablePanel.Size = new System.Drawing.Size(200, 100);
            mesajTablePanel.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // HocaEkran
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1451, 772);
            Controls.Add(tabControl1);
            Controls.Add(DerslerimPanel);
            Controls.Add(panel1);
            Name = "HocaEkran";
            Text = "Hoca";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDersiAlanlar).EndInit();
            panel2.ResumeLayout(false);
            mesajPanelHoca.ResumeLayout(false);
            mesajPanelHoca.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)hocaDerslerimDataView).EndInit();
            tabPage2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ogrenciDurumlarıDataGrid).EndInit();
            tabPage3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ogrencininAldigiDerslerDataGrid).EndInit();
            panel9.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button derslerimButton;
        private Panel DerslerimPanel;
        private TableLayoutPanel mesajTablePanelHoca;
        private DataGridView hocaDersAlanOgrencilerDataView;
        private Panel dersSecenOgrencileriGoster;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel2;
        private DataGridView hocaDerslerimDataView;
        private Label label2;
        private Panel panel3;
        private DataGridView dataGridViewDersiAlanlar;
        private Button dersAlanOgrenciListele;
        private Label label1;
        private ComboBox dersSecenOgrencilerComboBox;
        private TabPage tabPage2;
        private Panel panel4;
        private ComboBox tumderslerbox;
        private DataGridView ogrenciDurumlarıDataGrid;
        private Label label4;
        private Button button1;
        private TabPage tabPage3;
        private Panel panel5;
        private DataGridView ogrencininAldigiDerslerDataGrid;
        private Button button2;
        private Button button3;
        private Label label5;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Label label7;
        private Label label6;
        private ComboBox kriterdersComboBox;
        private Panel panel7;
        private Button ilgiEkleButton;
        private Label label3;
        private TextBox ilgiBox;
        private Panel panel6;
        private Button button4;
        private TextBox kriterdersTextBox;
        private Button button5;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Panel mesajPanelHoca;
        private Button btnyeniMesaj;
        private Label lblsonmesajlar;
        private Panel panel9;
        private Button btn_yeniMesaj;
        private TableLayoutPanel mesajTablePanel;
        private Label lblKalanZaman;
        private System.Windows.Forms.Timer timer1;
    }
}