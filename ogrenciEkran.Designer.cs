
namespace YazLab1
{
    partial class ogrenciEkran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ogrenciEkran));
            panel6 = new Panel();
            pictureBox7 = new PictureBox();
            ogrTranskript = new Button();
            panel5 = new Panel();
            dersSecButton = new Button();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            dersBilgileriButton = new Button();
            pictureBox2 = new PictureBox();
            panel3 = new Panel();
            anaMenuDon = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            pictureBox4 = new PictureBox();
            ogrenciSolPanel = new TableLayoutPanel();
            button2 = new Button();
            BtnTranskriptYükle = new Button();
            transkriptPanel = new Panel();
            label3 = new Label();
            pictureBox5 = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            anaMenuPanel = new Panel();
            lblTime = new Label();
            panel9 = new Panel();
            btn_yeniMesaj = new Button();
            mesajTablePanel = new TableLayoutPanel();
            lblsonmesajlar = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            dersbilgisiNumara = new Label();
            dersBilgisiIsım = new Label();
            dataGridView4 = new DataGridView();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            dersSecDataGrid = new DataGridView();
            panel7 = new Panel();
            button1 = new Button();
            dersSecmeButton = new Button();
            ilgialanibox = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            dersSecComboBox = new ComboBox();
            tabPage5 = new TabPage();
            panel8 = new Panel();
            label5 = new Label();
            label6 = new Label();
            GridAlinanDersler = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            ogrenciSinifBindingSource = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ogrenciSolPanel.SuspendLayout();
            transkriptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            anaMenuPanel.SuspendLayout();
            panel9.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dersSecDataGrid).BeginInit();
            panel7.SuspendLayout();
            tabPage5.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridAlinanDersler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ogrenciSinifBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Controls.Add(pictureBox7);
            panel6.Controls.Add(ogrTranskript);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(3, 296);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(288, 52);
            panel6.TabIndex = 6;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = (System.Drawing.Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new System.Drawing.Point(18, 0);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new System.Drawing.Size(48, 48);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 9;
            pictureBox7.TabStop = false;
            // 
            // ogrTranskript
            // 
            ogrTranskript.Dock = DockStyle.Right;
            ogrTranskript.Location = new System.Drawing.Point(85, 0);
            ogrTranskript.Name = "ogrTranskript";
            ogrTranskript.Size = new System.Drawing.Size(203, 52);
            ogrTranskript.TabIndex = 8;
            ogrTranskript.Text = "TRANSKRİPT EKLE";
            ogrTranskript.UseVisualStyleBackColor = true;
            ogrTranskript.Click += ogrTranskript_Click_1;
            // 
            // panel5
            // 
            panel5.Controls.Add(dersSecButton);
            panel5.Controls.Add(pictureBox3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(3, 234);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(288, 56);
            panel5.TabIndex = 5;
            // 
            // dersSecButton
            // 
            dersSecButton.BackColor = System.Drawing.Color.Transparent;
            dersSecButton.Dock = DockStyle.Right;
            dersSecButton.Location = new System.Drawing.Point(85, 0);
            dersSecButton.Name = "dersSecButton";
            dersSecButton.Size = new System.Drawing.Size(203, 56);
            dersSecButton.TabIndex = 1;
            dersSecButton.Text = "DERS SEÇ";
            dersSecButton.UseVisualStyleBackColor = false;
            dersSecButton.Click += dersSecButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new System.Drawing.Point(18, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(48, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(dersBilgileriButton);
            panel4.Controls.Add(pictureBox2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(3, 180);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(288, 48);
            panel4.TabIndex = 4;
            // 
            // dersBilgileriButton
            // 
            dersBilgileriButton.Location = new System.Drawing.Point(85, -4);
            dersBilgileriButton.Name = "dersBilgileriButton";
            dersBilgileriButton.Size = new System.Drawing.Size(206, 52);
            dersBilgileriButton.TabIndex = 6;
            dersBilgileriButton.Text = "DERS BİLGİLERİ GÖR";
            dersBilgileriButton.UseVisualStyleBackColor = true;
            dersBilgileriButton.Click += dersBilgileriButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new System.Drawing.Point(18, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(48, 48);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(anaMenuDon);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 130);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(288, 44);
            panel3.TabIndex = 3;
            // 
            // anaMenuDon
            // 
            anaMenuDon.Dock = DockStyle.Right;
            anaMenuDon.Location = new System.Drawing.Point(85, 0);
            anaMenuDon.Name = "anaMenuDon";
            anaMenuDon.Size = new System.Drawing.Size(203, 44);
            anaMenuDon.TabIndex = 7;
            anaMenuDon.Text = "ANA MENÜ";
            anaMenuDon.UseVisualStyleBackColor = true;
            anaMenuDon.Click += anaMenuDon_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.LightSlateGray;
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(18, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(48, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(pictureBox4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(288, 121);
            panel2.TabIndex = 2;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = SystemColors.InactiveCaption;
            pictureBox6.Image = (System.Drawing.Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new System.Drawing.Point(154, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(134, 136);
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox6.TabIndex = 6;
            pictureBox6.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = System.Drawing.Color.DarkSeaGreen;
            pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new System.Drawing.Point(3, -3);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(153, 124);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // ogrenciSolPanel
            // 
            ogrenciSolPanel.AllowDrop = true;
            ogrenciSolPanel.Anchor = AnchorStyles.None;
            ogrenciSolPanel.BackColor = System.Drawing.Color.SlateGray;
            ogrenciSolPanel.ColumnCount = 1;
            ogrenciSolPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            ogrenciSolPanel.Controls.Add(button2, 0, 5);
            ogrenciSolPanel.Controls.Add(panel2, 0, 0);
            ogrenciSolPanel.Controls.Add(panel3, 0, 1);
            ogrenciSolPanel.Controls.Add(panel4, 0, 2);
            ogrenciSolPanel.Controls.Add(panel5, 0, 3);
            ogrenciSolPanel.Controls.Add(panel6, 0, 4);
            ogrenciSolPanel.Location = new System.Drawing.Point(-6, 0);
            ogrenciSolPanel.Name = "ogrenciSolPanel";
            ogrenciSolPanel.RowCount = 7;
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 71.7277451F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 28.2722511F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            ogrenciSolPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 237F));
            ogrenciSolPanel.Size = new System.Drawing.Size(294, 652);
            ogrenciSolPanel.TabIndex = 0;
            ogrenciSolPanel.Paint += ogrenciSolPanel_Paint;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Right;
            button2.Location = new System.Drawing.Point(88, 354);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(203, 57);
            button2.TabIndex = 9;
            button2.Text = "ALINAN DERSLERİ GÖSTER";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // BtnTranskriptYükle
            // 
            BtnTranskriptYükle.BackColor = SystemColors.ControlLight;
            BtnTranskriptYükle.BackgroundImage = (System.Drawing.Image)resources.GetObject("BtnTranskriptYükle.BackgroundImage");
            BtnTranskriptYükle.BackgroundImageLayout = ImageLayout.Zoom;
            BtnTranskriptYükle.Location = new System.Drawing.Point(384, 217);
            BtnTranskriptYükle.Name = "BtnTranskriptYükle";
            BtnTranskriptYükle.Size = new System.Drawing.Size(226, 147);
            BtnTranskriptYükle.TabIndex = 0;
            BtnTranskriptYükle.UseVisualStyleBackColor = false;
            BtnTranskriptYükle.Click += BtnTranskriptYukle_Click;
            // 
            // transkriptPanel
            // 
            transkriptPanel.BackColor = System.Drawing.Color.DimGray;
            transkriptPanel.Controls.Add(label3);
            transkriptPanel.Controls.Add(pictureBox5);
            transkriptPanel.Controls.Add(BtnTranskriptYükle);
            transkriptPanel.Dock = DockStyle.Fill;
            transkriptPanel.Location = new System.Drawing.Point(3, 3);
            transkriptPanel.Name = "transkriptPanel";
            transkriptPanel.Size = new System.Drawing.Size(1145, 604);
            transkriptPanel.TabIndex = 2;
            transkriptPanel.Paint += transkriptPanel_Paint;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(333, 115);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(177, 99);
            label3.TabIndex = 5;
            label3.Text = "PDF YÜKLE";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Click += label3_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new System.Drawing.Point(516, 111);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new System.Drawing.Size(94, 93);
            pictureBox5.TabIndex = 2;
            pictureBox5.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new System.Drawing.Point(294, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1159, 638);
            tabControl1.TabIndex = 6;
            tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(anaMenuPanel);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new System.Drawing.Size(1151, 610);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // anaMenuPanel
            // 
            anaMenuPanel.Controls.Add(lblTime);
            anaMenuPanel.Controls.Add(panel9);
            anaMenuPanel.Controls.Add(label1);
            anaMenuPanel.Location = new System.Drawing.Point(1, 0);
            anaMenuPanel.Name = "anaMenuPanel";
            anaMenuPanel.Size = new System.Drawing.Size(1148, 611);
            anaMenuPanel.TabIndex = 2;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTime.Location = new System.Drawing.Point(307, 155);
            lblTime.Name = "lblTime";
            lblTime.Size = new System.Drawing.Size(392, 46);
            lblTime.TabIndex = 2;
            lblTime.Text = "Kalan Zaman: 00.00:00:00";
            // 
            // panel9
            // 
            panel9.AutoScroll = true;
            panel9.BackColor = System.Drawing.Color.Gainsboro;
            panel9.Controls.Add(btn_yeniMesaj);
            panel9.Controls.Add(mesajTablePanel);
            panel9.Controls.Add(lblsonmesajlar);
            panel9.Location = new System.Drawing.Point(830, 0);
            panel9.Name = "panel9";
            panel9.Size = new System.Drawing.Size(317, 611);
            panel9.TabIndex = 1;
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
            btn_yeniMesaj.Click += btn_yeniMesaj_Click_1;
            // 
            // mesajTablePanel
            // 
            mesajTablePanel.ColumnCount = 1;
            mesajTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mesajTablePanel.Location = new System.Drawing.Point(0, 23);
            mesajTablePanel.Name = "mesajTablePanel";
            mesajTablePanel.RowCount = 8;
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mesajTablePanel.Size = new System.Drawing.Size(300, 800);
            mesajTablePanel.TabIndex = 1;
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
            // label1
            // 
            label1.Font = new Font("Segoe UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(158, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(761, 160);
            label1.TabIndex = 0;
            label1.Text = "HOŞ GELDİN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new System.Drawing.Size(1151, 610);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.RosyBrown;
            panel1.Controls.Add(dersbilgisiNumara);
            panel1.Controls.Add(dersBilgisiIsım);
            panel1.Controls.Add(dataGridView4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1145, 604);
            panel1.TabIndex = 1;
            // 
            // dersbilgisiNumara
            // 
            dersbilgisiNumara.AutoSize = true;
            dersbilgisiNumara.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dersbilgisiNumara.Location = new System.Drawing.Point(704, 63);
            dersbilgisiNumara.Name = "dersbilgisiNumara";
            dersbilgisiNumara.Size = new System.Drawing.Size(0, 32);
            dersbilgisiNumara.TabIndex = 2;
            // 
            // dersBilgisiIsım
            // 
            dersBilgisiIsım.AutoSize = true;
            dersBilgisiIsım.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dersBilgisiIsım.Location = new System.Drawing.Point(74, 63);
            dersBilgisiIsım.Name = "dersBilgisiIsım";
            dersBilgisiIsım.Size = new System.Drawing.Size(0, 32);
            dersBilgisiIsım.TabIndex = 1;
            dersBilgisiIsım.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new System.Drawing.Point(0, 111);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new System.Drawing.Size(1145, 490);
            dataGridView4.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(transkriptPanel);
            tabPage3.Location = new System.Drawing.Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new System.Drawing.Size(1151, 610);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dersSecDataGrid);
            tabPage4.Controls.Add(panel7);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new System.Drawing.Size(1151, 610);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dersSecDataGrid
            // 
            dersSecDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dersSecDataGrid.Location = new System.Drawing.Point(0, 128);
            dersSecDataGrid.Name = "dersSecDataGrid";
            dersSecDataGrid.Size = new System.Drawing.Size(1151, 486);
            dersSecDataGrid.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = System.Drawing.Color.BlanchedAlmond;
            panel7.Controls.Add(button1);
            panel7.Controls.Add(dersSecmeButton);
            panel7.Controls.Add(ilgialanibox);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(dersSecComboBox);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new System.Drawing.Point(3, 3);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(1145, 604);
            panel7.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(900, 75);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(109, 34);
            button1.TabIndex = 5;
            button1.Text = "FİLTRELE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // dersSecmeButton
            // 
            dersSecmeButton.Location = new System.Drawing.Point(198, 75);
            dersSecmeButton.Name = "dersSecmeButton";
            dersSecmeButton.Size = new System.Drawing.Size(113, 34);
            dersSecmeButton.TabIndex = 4;
            dersSecmeButton.Text = "BİLGİLERİ GETİR";
            dersSecmeButton.UseVisualStyleBackColor = true;
            dersSecmeButton.Click += dersSecmeButton_Click;
            // 
            // ilgialanibox
            // 
            ilgialanibox.FormattingEnabled = true;
            ilgialanibox.Location = new System.Drawing.Point(900, 32);
            ilgialanibox.Name = "ilgialanibox";
            ilgialanibox.Size = new System.Drawing.Size(121, 23);
            ilgialanibox.TabIndex = 3;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(766, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(100, 23);
            label4.TabIndex = 2;
            label4.Text = "İLGİ ALANI SEÇ";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(57, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "DERS SEÇ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dersSecComboBox
            // 
            dersSecComboBox.FormattingEnabled = true;
            dersSecComboBox.Location = new System.Drawing.Point(198, 34);
            dersSecComboBox.Name = "dersSecComboBox";
            dersSecComboBox.Size = new System.Drawing.Size(121, 23);
            dersSecComboBox.TabIndex = 0;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(panel8);
            tabPage5.Location = new System.Drawing.Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new System.Drawing.Size(1151, 610);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BackColor = System.Drawing.Color.RosyBrown;
            panel8.Controls.Add(label5);
            panel8.Controls.Add(label6);
            panel8.Controls.Add(GridAlinanDersler);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new System.Drawing.Point(3, 3);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(1145, 604);
            panel8.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(704, 63);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(0, 32);
            label5.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(74, 63);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(0, 32);
            label6.TabIndex = 1;
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GridAlinanDersler
            // 
            GridAlinanDersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridAlinanDersler.Location = new System.Drawing.Point(0, 111);
            GridAlinanDersler.Name = "GridAlinanDersler";
            GridAlinanDersler.Size = new System.Drawing.Size(1145, 490);
            GridAlinanDersler.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // ogrenciSinifBindingSource
            // 
            ogrenciSinifBindingSource.DataSource = typeof(ogrenciSinif);
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick_1;
            // 
            // ogrenciEkran
            // 
            AllowDrop = true;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1450, 650);
            Controls.Add(tabControl1);
            Controls.Add(ogrenciSolPanel);
            Cursor = Cursors.WaitCursor;
            Name = "ogrenciEkran";
            Text = "ogrenciEkran";
            Load += ogrenciEkran_Load;
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ogrenciSolPanel.ResumeLayout(false);
            transkriptPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            anaMenuPanel.ResumeLayout(false);
            anaMenuPanel.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dersSecDataGrid).EndInit();
            panel7.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridAlinanDersler).EndInit();
            ((System.ComponentModel.ISupportInitialize)ogrenciSinifBindingSource).EndInit();
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }







        // Form sınıfının içinde bir değişken tanımlayın


        private void yukleButton_Click(object sender, EventArgs e)
        {

        }




        #endregion

        private Label ogrHosgeldinLabel;
        private Label anaPanelIsım;
        private Label label1;
        private Panel anaPanel;
        private Panel anaMenuPanel;
        private TableLayoutPanel ogrenciSolPanel;
        private Panel panel2;
        private PictureBox pictureBox4;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Panel panel5;
        private PictureBox pictureBox3;
        private Panel panel6;
        private Panel transkriptPanel;
        private Button BtnTranskriptYükle;
        private PictureBox pictureBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox6;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        public DataGridView dataGridView1;
        private BindingSource ogrenciSinifBindingSource;
        private Panel dersPanel;
        private Panel dPanel;
        private Button dersSecButton;
        private Button dersBilgileriButton;
        private Button ogrTranskript;
        private Button anaMenuDon;
        //  private Panel dersSecPanel;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dataGridView4;
        private Label dersbilgisiNumara;
        private Label dersBilgisiIsım;
        private TabPage tabPage4;
        private DataGridView dataGridView2;
        private Panel panel7;
        private Label label4;
        private Label label2;
        private ComboBox dersSecComboBox;
        private ComboBox ilgialanibox;
        private DataGridView dersSecDataGrid;
        private Button dersSecmeButton;
        private TabPage tabPage5;
        private Panel panel8;
        private Label label5;
        private Label label6;
        private DataGridView GridAlinanDersler;
        private Button button2;
        private Button button1;
        private PictureBox pictureBox7;
        private Panel panel9;
        private Label lblsonmesajlar;
        private TableLayoutPanel mesajTablePanel;
        private Button btn_yeniMesaj;
        private System.Windows.Forms.Timer timer1;
        private Label lblTime;
    }
}