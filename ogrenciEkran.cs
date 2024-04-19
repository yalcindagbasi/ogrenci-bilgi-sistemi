using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using Org.BouncyCastle.Asn1.Cms;
using SautinSoft;
using Spire.Pdf;
using System.Timers;
using Timer = System.Timers.Timer;

namespace YazLab1
{
    public partial class ogrenciEkran : Form
    {

        ComboBox cbxKime = new ComboBox();
        private ogrenciSinif ogrenci;
        public string ogrenciKimligi;
        string baglantiString = "server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123";
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123");
        static List<string> dersAdlari = new List<string>();
        string pdf;
        public ogrenciEkran(ogrenciSinif ogrenci, string ogrenciKimligi)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ogrenci = ogrenci;
            this.ogrenciKimligi = ogrenciKimligi;
            dersBilgileriBoxEkle(dersSecComboBox);
            ilgiAlanlariComboBoxEkle(ilgialanibox);
            tabControl1.Visible = true;
            tabPage1.Text = "ANA MENÜ";
            tabPage2.Text = "TRANSKRİPT BİLGİLERİNİ GÖSTER";
            tabPage3.Text = "TRANSKRİPT YÜKLE";

            if (!YoneticiEkran.sureBittiMi)
                timer1.Start();

            mesajPanelOlustur();
        }



        private void ogrenciEkran_Load(object sender, EventArgs e)
        {

        }

        private void BtnTranskriptYukle_Click(object sender, EventArgs e)

        {
            string secilenPdfYolu = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Dosyaları|*.pdf"; // Sadece PDF dosyalarını göstermek için bir filtre ekleyin

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen PDF dosyasının yolunu alın
                    secilenPdfYolu = openFileDialog.FileName;

                    // Öğrencinin kimliği ile PDF yükleme işlemi
                    PDFYukle(ogrenciKimligi, secilenPdfYolu);
                }
            }

            // PDF'den bilgileri al
            pdf = ogrenci.pdfOku(secilenPdfYolu);

            this.ogrenci.ad = this.ogrenci.adAl(pdf);
            this.ogrenci.soyad = this.ogrenci.soyadAl(pdf);
            this.ogrenci.ogrenciNo = this.ogrenci.numaraAl(pdf);
            this.ogrenci.dersOku(pdf);
            if (ogrenciMevcutMu(ogrenci) == false)
            {
                ogrenciBilgiEkle(this.ogrenci);
                dersBilgileriEkle(this.ogrenci);

                dersBilgileriButton.Enabled = true;
                dersSecButton.Enabled = true;
                ogrenci.pdfDurumu = true;

                // Veritabanında öğrenci PDF durumunu güncelleyin



                using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
                    try
                    {

                        conn.Open();
                        NpgsqlCommand pdfDegistir = new NpgsqlCommand("UPDATE tbl_ogr SET ogr_pdfdurumu = @p1 WHERE ogr_no = @p2", conn);
                        pdfDegistir.Parameters.AddWithValue("@p1", true);
                        pdfDegistir.Parameters.AddWithValue("@p2", ogrenci.ogrenciNo);
                        pdfDegistir.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata:3123 " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

            }





        }
        public bool ogrenciMevcutMu(ogrenciSinif ogrenci)
        {
            bool mevcut = false;


            using (NpgsqlConnection connection = new NpgsqlConnection(baglantiString))
            {
                connection.Open();


                string query = "SELECT ogr_no FROM tbl_ogr WHERE ogr_no = @ogrenciNo";


                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ogrenciNo", ogrenci.ogrenciNo);

                    try
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mevcut = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda burada işlem yapabilirsiniz.
                        Console.WriteLine("Hata:41241 " + ex.Message);
                    }
                }
            }

            return mevcut;
        }
        public bool dersMevcutMu(string dersAdi)
        {
            bool mevcut = false;

            using (NpgsqlConnection conn = new NpgsqlConnection(baglantiString))
            {
                conn.Open();

                string query = "SELECT ders_adi FROM tbl_dersler WHERE ders_adi = @dersAdi";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@dersAdi", dersAdi);

                    using (NpgsqlDataReader oku = command.ExecuteReader())
                    {
                        if (oku.Read())
                        {
                            mevcut = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return mevcut;
        }



        public void PDFYukle(string ogrenciKimligi, string pdfYolu)
        {
            if (!string.IsNullOrEmpty(ogrenciKimligi))
            {
                // PDF'yi öğrencinin kimliği ile kaydedin
                string hedefKlasorYolu = Path.Combine("C:\\Users\\Emir\\Desktop", ogrenciKimligi);
                if (!Directory.Exists(hedefKlasorYolu))
                {
                    Directory.CreateDirectory(hedefKlasorYolu);
                }

                //string hedefDosyaYolu = Path.Combine(hedefKlasorYolu, Path.GetFileName(pdfYolu));
                //File.Copy(pdfYolu, hedefDosyaYolu);
            }
        }

        private void dersSecPanel()
        {
            tabControl1.SelectedTab = tabPage4;

        }

        private void anaEkranGoster()
        {

            tabControl1.SelectedTab = tabPage1;

        }
        private void dersBilgileri()
        {
            //anaMenuPanel.Visible = false; transkriptPanel.Visible = false; //dersBilgileriPaneli.Visible = true;
            //tabControl1.Visible = true;
            tabControl1.SelectedTab = tabPage2;
        }

        private void transkriptEkranGoster()
        {
            tabControl1.SelectedTab = tabPage3;

            //anaMenuPanel.Visible = true;
            //transkriptPanel.Visible = true;
            //tabControl1.Visible = false;
            //// dersBilgileriPaneli.Visible = false;
            ////dersSecPanel.Visible = false;
            //transkriptPanel.BringToFront();



        }
        public void dersBilgiEkraniDoldur(ogrenciSinif ogrenci)
        {
            dersBilgisiIsım.Text = "Ad Soyad : " + ogrenci.ad + " " + ogrenci.soyad;
            dersBilgisiIsım.Font = new Font("Arial", 15, FontStyle.Bold);
            dersbilgisiNumara.Text = "Numara : " + ogrenci.ogrenciNo.ToString();
            dersbilgisiNumara.Font = new Font("Arial", 20, FontStyle.Bold);



        }


        private void ogrDersBilgileri_Click(object sender, EventArgs e)
        {


        }


        private void transkriptPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public void dersBilgileriEkle(ogrenciSinif ogrenci)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))

            {
                NpgsqlCommand komut1 = new NpgsqlCommand("insert into tbl_dersler (ders_kodu, ders_adi,ders_akts) values (@p1, @p2, @p3)", conn);
                NpgsqlCommand komut2 = new NpgsqlCommand("insert into tbl_notlar (ogrenci_id,ders_adi,harfnotu) values (@p4,@p5,@p6)", conn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                for (int i = 0; i < ogrenci.dersAdlari.Count; i++)
                {
                    // Dersi ekleyin
                    if (dersMevcutMu(ogrenci.dersAdlari[i]) == false)
                    {
                        komut1.Parameters.Clear(); // Parametreleri temizle
                        komut1.Parameters.AddWithValue("@p1", ogrenci.dersKodları[i]);
                        komut1.Parameters.AddWithValue("@p2", ogrenci.dersAdlari[i]);
                        komut1.Parameters.AddWithValue("@p3", Convert.ToInt32(ogrenci.aktsNotlari[i])); // Ders AKTS
                        komut1.ExecuteNonQuery(); // Dersi ekleyin

                    }

                    // Dersi ekledikten sonra ders_id'yi alın
                    NpgsqlCommand getIdCommand = new NpgsqlCommand("SELECT ders_id FROM tbl_dersler WHERE ders_kodu = @ders_kodu", conn);
                    getIdCommand.Parameters.AddWithValue("@ders_kodu", ogrenci.dersKodları[i]);
                    int dersID = (int)getIdCommand.ExecuteScalar(); // Eklenen dersin ders_id'sini alın



                    // Notu ekleyin
                    komut2.Parameters.Clear(); // Parametreleri temizle
                    komut2.Parameters.AddWithValue("@p4", ogrenci.ogrenciNo); // Öğrenci ID
                    komut2.Parameters.AddWithValue("@p5", dersID); // Ders ID
                    komut2.Parameters.AddWithValue("@p6", ogrenci.harfNotlari[i]);
                    komut2.ExecuteNonQuery(); // Notu ekleyin
                }



                MessageBox.Show("EKLEME BAŞARIYLA YAPILDI");
                MessageBox.Show("ANA MENÜYE YÖNLENDİRİLİYORSUNUZ");


                tabControl1.SelectedTab = tabPage1;



            }

        }
        public void ogrenciBilgiEkle(ogrenciSinif ogrenci)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into tbl_ogr (ogr_no,ogr_ad,ogr_soyad,ogr_anlasmasayisi,ogr_anlasmadurumu,ogr_pdfdurumu) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);
                komut1.Parameters.AddWithValue("@p1", ogrenci.ogrenciNo);
                komut1.Parameters.AddWithValue("@p2", ogrenci.ad);
                komut1.Parameters.AddWithValue("@p3", ogrenci.soyad);
                komut1.Parameters.AddWithValue("@p4", ogrenci.anlasmaSayisi);
                komut1.Parameters.AddWithValue("@p5", ogrenci.anlasmaDurumu);
                komut1.Parameters.AddWithValue("@p6", ogrenci.pdfDurumu);

                try
                {
                    komut1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }




        }

        public static void dersBilgileriBoxEkle(ComboBox dersSecComboBox)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ders_adi FROM tbl_dersler where ders_kodu is NULL";

                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string ders = reader.GetString(0);
                            dersSecComboBox.Items.Add(ders);

                        }
                    }
                }
            }

        }
        public static void ilgiAlanlariComboBoxEkle(ComboBox ilgiBox)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ilgi_isim FROM tbl_ilgialani";

                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string ders = reader.GetString(0);
                            ilgiBox.Items.Add(ders);

                        }
                    }
                }
            }

        }

        private void dersSecComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void dersBilgileriButton_Click(object sender, EventArgs e)
        {
            //dersBilgileriGoster();
            dersBilgileri();

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                try
                {
                    conn.Open();
                    // PostgreSQL sorgusu
                    string sorgu = "SELECT tbl_ogr.ogr_no, tbl_dersler.ders_adi, tbl_notlar.harfnotu " +
                   "FROM tbl_notlar " +
                   "JOIN tbl_ogr ON tbl_notlar.ogrenci_id = tbl_ogr.ogr_no " +
                   "JOIN tbl_dersler ON tbl_notlar.ders_adi = tbl_dersler.ders_id " +
                   "WHERE tbl_ogr.ogr_no = @ogrenciNo";

                    NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn);
                    komut.Parameters.AddWithValue("@ogrenciNo", ogrenci.ogrenciNo);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut); // Sorguyu komut nesnesi ile belirtin

                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    dataGridView4.DataSource = dataset.Tables[0];
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dersBilgiEkraniDoldur(ogrenci);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:sad asasdasdsa " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }



            }
        }



        private void ogrenciSolPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ogrTranskript_Click_1(object sender, EventArgs e)
        {
            bool durum = true;
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ogr_pdfDurumu FROM tbl_ogr WHERE ogr_no =@ogrenciNumarasi ";

                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    command.Parameters.AddWithValue("ogrenciNumarasi", ogrenci.ogrenciNo.ToString());
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() == false)
                        {
                            durum = false;
                        }
                        else
                        {
                            MessageBox.Show("BU KULLANICI ZATEN PDF BİLGİLERİNİ YÜKLEMİŞ");
                            tabControl1.SelectedTab = tabPage1;
                            ogrTranskript.Enabled = false;


                        }
                    }

                }
            }
            if (durum == false)
            {
                transkriptEkranGoster();
            }

        }

        private void anaMenuDon_Click(object sender, EventArgs e)
        {
            anaEkranGoster();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dersSecButton_Click(object sender, EventArgs e)
        {
            dersSecPanel();
        }

        private bool buttonColumnAdded = false; // Bir defadan fazla buton eklenmemesi için bayrak

        private void dersSecmeButton_Click(object sender, EventArgs e)
        {
            // DataGridView'i temizle
            dersSecDataGrid.DataSource = null;

            string secilenDers = dersSecComboBox.SelectedItem.ToString();
            // string ilgiAdi = ilgialanibox.SelectedItem.ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();

                string sorgu = "SELECT DISTINCT hoca.hoca_sicilno, hoca.hoca_ad, hoca.hoca_soyad, ders.ders_adi " +
                "FROM tbl_dershoca AS dh " +
                "INNER JOIN tbl_hoca AS hoca ON dh.hoca = hoca.hoca_sicilno " +
                "" +
                "" +
                "INNER JOIN tbl_dersler AS ders ON dh.ders = ders.ders_id " +
                "WHERE ders.ders_adi = @dersAdi";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("dersAdi", secilenDers);
                    // komut.Parameters.AddWithValue("ilgiadi", ilgiAdi);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut);
                    DataTable dersTable = new DataTable();

                    // Verileri çek ve DataTable'e doldur
                    adapter.Fill(dersTable);

                    // DataGridView'e DataTable'i bağla
                    dersSecDataGrid.DataSource = dersTable;

                    if (!buttonColumnAdded)
                    {

                        dersSecDataGrid.CellContentClick -= DataGridView_CellContentClick;


                        DataGridViewButtonColumn[] buttonColumn = new DataGridViewButtonColumn[2];

                        buttonColumn[0] = new DataGridViewButtonColumn();
                        buttonColumn[0].Text = "TALEP ET";
                        buttonColumn[0].UseColumnTextForButtonValue = true;
                        dersSecDataGrid.Columns.Add(buttonColumn[0]);

                        buttonColumn[1] = new DataGridViewButtonColumn();
                        buttonColumn[1].Text = "GERİ ÇEK";
                        buttonColumn[1].UseColumnTextForButtonValue = true;
                        dersSecDataGrid.Columns.Add(buttonColumn[1]);

                        dersSecDataGrid.CellContentClick += DataGridView_CellContentClick;

                        buttonColumnAdded = true; // Bayrağı güncelle, bir daha eklenmemesi için
                    }
                }
            }
        }
        private bool ogrenciDerseSahipMi(ogrenciSinif ogrenci, string dersAdi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT tbl_ogr.ogr_ad,tbl_dersler.ders_adi FROM tbl_dershoca " +
                    "INNER JOIN tbl_ogr ON tbl_dershoca.ogrenci = tbl_ogr.ogr_no " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "WHERE tbl_dershoca.ogrenci = @ogrenciNumara AND tbl_dersler.ders_adi = @ders";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("ogrenciNumara", ogrenci.ogrenciNo);
                    cmd.Parameters.AddWithValue("ders", dersAdi);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            return true;

                        }

                    }

                }

            }
            return false;


        }

        public static int dersIDbul(string ders)
        {
            int idNo;
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();

                string sorgu = "SELECT ders_id from tbl_dersler where ders_adi = @ders";

                {

                    using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                    {
                        komut.Parameters.AddWithValue("ders", ders);
                        idNo = Convert.ToInt32(komut.ExecuteScalar());
                        if (idNo > 0)
                        {
                            return idNo;

                        }


                    }
                }

            }

            return -1;

        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string buttonText = dersSecDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                int hocaSicilNo = Convert.ToInt32(dersSecDataGrid.Rows[e.RowIndex].Cells["hoca_sicilno"].Value);
                string hocaAd = dersSecDataGrid.Rows[e.RowIndex].Cells["hoca_ad"].Value.ToString();
                string hocaSoyad = dersSecDataGrid.Rows[e.RowIndex].Cells["hoca_soyad"].Value.ToString();
                string dersAdi = dersSecDataGrid.Rows[e.RowIndex].Cells["ders_adi"].Value.ToString();

                int row = e.RowIndex;
                int column = e.ColumnIndex;


                if (buttonText.Equals("TALEP ET"))
                {
                    // Tıklanan satırın verilerini alın


                    // dersSecDataGrid.Rows[row].Cells[column].ReadOnly = true;

                    if (!ogrenciDerseSahipMi(ogrenci, dersAdi))
                    {
                        if (!baskaHocadanTalepVarMi(ogrenci, dersAdi, hocaSicilNo))
                        {
                            if (!dersTalebiOlumluMu(ogrenci, dersAdi, hocaSicilNo))
                            {
                                if (!dersTalebiVarMi(ogrenci, dersAdi, hocaSicilNo))
                                {
                                    dersTalebindeBulun(ogrenci, dersAdi, hocaSicilNo);
                                    MessageBox.Show($"DERS TALEP İSTEGİ GÖNDERİLDİ. Hoca Adı: {hocaAd} {hocaSoyad}, Ders Adı: {dersAdi}");
                                }
                                else
                                {
                                    MessageBox.Show("BU DERSE TALEP OLUŞTURDUNUZ LÜTFEN CEVABI BEKLEYİN");
                                }

                            }
                            else
                            {

                                MessageBox.Show("BU DERSİ ZATEN LİSTENİZE EKLEDİNİZ");

                            }


                        }
                        else
                        {

                            MessageBox.Show("BU DERS İÇİN BAŞKA HOCADAN TALEP OLUŞTURDUNUZ");

                        }


                    }
                    else
                    {
                        MessageBox.Show("BU DERS BAŞKA HOCADAN ALINMIŞ");
                    }




                }
                else if (buttonText.Equals("GERİ ÇEK"))
                {
                    if (dersTalebiVarMi(ogrenci, dersAdi, hocaSicilNo))
                    {
                        dersTalebiniGeriCek(ogrenci, dersAdi, hocaSicilNo);


                    }

                }


            }
        }
        private bool baskaHocadanTalepVarMi(ogrenciSinif ogrenci, string dersAdi, int hocaSicilNo)
        {
            int sayac = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT ogrenciid, dersid, taleptarihi, durum, hocaid  " +
                    "FROM tbl_talep INNER JOIN  tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id" +
                    " WHERE tbl_dersler.ders_adi = @dersAdi AND ogrenciid = @ogrenciNo AND durum = @talepdurum";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {

                    command.Parameters.AddWithValue("dersAdi", dersAdi);
                    command.Parameters.AddWithValue("ogrenciNo", ogrenci.ogrenciNo);
                    command.Parameters.AddWithValue("talepdurum", "CEVAP BEKLENİYOR");
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sayac++;
                            if (sayac > 1)
                            {
                                return true;
                            }

                        }


                    }

                }

            }

            return false;


        }

        private void dersTalebiniGeriCek(ogrenciSinif ogrenci, string dersAdi, int hocaSicilNo)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();

                string soru = "DELETE FROM tbl_talep WHERE ogrenciid = @ogrenciNo AND dersid = @dersId AND hocaid = @hocaSicil";
                using (NpgsqlCommand command = new NpgsqlCommand(soru, conn))
                {
                    command.Parameters.AddWithValue("ogrenciNo", ogrenci.ogrenciNo);
                    command.Parameters.AddWithValue("dersId", dersIDbul(dersAdi));
                    command.Parameters.AddWithValue("hocaSicil", hocaSicilNo);
                    command.ExecuteNonQuery();
                    MessageBox.Show("TALEP BAŞARIYLA GERİ ÇEKİLDİ");


                }

            }


        }
        private bool dersTalebiVarMi(ogrenciSinif ogrenci, string dersAdi, int hocaSicilNo)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT ogrenciid, dersid, taleptarihi, durum, hocaid  " +
                    "FROM tbl_talep INNER JOIN  tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id" +
                    " WHERE tbl_dersler.ders_adi = @dersAdi AND ogrenciid = @ogrenciNo AND durum = @talepdurum AND hocaid = @hocaİd";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {

                    command.Parameters.AddWithValue("dersAdi", dersAdi);
                    command.Parameters.AddWithValue("ogrenciNo", ogrenci.ogrenciNo);
                    command.Parameters.AddWithValue("talepdurum", "CEVAP BEKLENİYOR");
                    command.Parameters.AddWithValue("hocaİd", hocaSicilNo);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {


                            return true;
                        }


                    }

                }

            }

            return false;

        }
        private bool dersTalebiOlumluMu(ogrenciSinif ogrenci, string dersAdi, int hocaSicilNo)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT durum  " +
                    "FROM tbl_talep INNER JOIN  tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id" +
                    " WHERE tbl_dersler.ders_adi = @dersAdi AND ogrenciid = @ogrenciNo AND durum = @talepdurum AND hocaid = @hocaİd";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {

                    command.Parameters.AddWithValue("dersAdi", dersAdi);
                    command.Parameters.AddWithValue("ogrenciNo", ogrenci.ogrenciNo);
                    command.Parameters.AddWithValue("talepdurum", "ONAYLANDI");
                    command.Parameters.AddWithValue("hocaİd", hocaSicilNo);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return true;

                        }

                    }

                }

            }
            return false;
        }
        private void dersTalebindeBulun(ogrenciSinif ogrenci, string dersAdi, int hocaSicilNo)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {


                conn.Open();
                {

                    string sorgu = "INSERT INTO tbl_talep (ogrenciid,dersid,hocaid,taleptarihi,durum) values (@p1,@p2,@p3,@p4,@p5)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                    {
                        MessageBox.Show(dersIDbul(dersAdi).ToString());
                        cmd.Parameters.AddWithValue("p1", ogrenci.ogrenciNo);
                        cmd.Parameters.AddWithValue("p2", dersIDbul(dersAdi));
                        cmd.Parameters.AddWithValue("p3", hocaSicilNo);
                        cmd.Parameters.AddWithValue("p4", DateTime.Now);
                        cmd.Parameters.AddWithValue("p5", "CEVAP BEKLENİYOR");
                        cmd.ExecuteNonQuery();
                    }


                }



            }

        }
        private void alinanDersleriGoster()
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {

                conn.Open();
                string sorgu = "SELECT DISTINCT tbl_dersler.ders_adi,tbl_hoca.hoca_ad,tbl_hoca.hoca_soyad FROM tbl_dershoca " +
                    "INNER JOIN " +
                    "tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "INNER JOIN tbl_hoca ON tbl_dershoca.hoca = tbl_hoca.hoca_sicilno " +
                    "WHERE ogrenci = @ogrenciNo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("ogrenciNo", ogrenci.ogrenciNo);
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {

                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);
                        GridAlinanDersler.DataSource = dataset.Tables[0];
                        GridAlinanDersler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                    }

                }


            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            alinanDersleriGoster();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dersSecDataGrid.DataSource = null;

            string secilenDers = dersSecComboBox.SelectedItem.ToString();
            string ilgiAdi = ilgialanibox.SelectedItem.ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();

                string sorgu = "SELECT DISTINCT hoca.hoca_sicilno, hoca.hoca_ad, hoca.hoca_soyad, ders.ders_adi " +
                "FROM tbl_hocailgi AS hi " +
                "INNER JOIN tbl_hoca AS hoca ON hi.hoca_id = hoca.hoca_sicilno " +
                "INNER JOIN tbl_ilgialani AS ilgi ON hi.ilgi_id = ilgi.ilgi_id " +
                "INNER JOIN tbl_dershoca AS dh ON hoca.hoca_sicilno = dh.hoca " +
                "INNER JOIN tbl_dersler AS ders ON dh.ders = ders.ders_id " +
                "WHERE ilgi.ilgi_isim = @ilgiadi AND ders.ders_adi = @dersAdi";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("dersAdi", secilenDers);
                    komut.Parameters.AddWithValue("ilgiadi", ilgiAdi);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut);
                    DataTable dersTable = new DataTable();

                    // Verileri çek ve DataTable'e doldur
                    adapter.Fill(dersTable);

                    // DataGridView'e DataTable'i bağla
                    dersSecDataGrid.DataSource = dersTable;

                    if (!buttonColumnAdded)
                    {
                        // Mevcut olay dinleyicilerini kaldır
                        dersSecDataGrid.CellContentClick -= DataGridView_CellContentClick;

                        // DataGridView'e yeni bir olay dinleyici ekleyin

                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "";
                        buttonColumn.Text = "TALEP ET";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        dersSecDataGrid.Columns.Add(buttonColumn);
                        dersSecDataGrid.CellContentClick += DataGridView_CellContentClick;

                        buttonColumnAdded = true; // Bayrağı güncelle, bir daha eklenmemesi için
                    }
                }
            }
        }
        private void mesajAl()
        {
            Console.WriteLine("1");
            string connString = "Host=localhost;Username=postgres;Password=123;Database=YazLab1";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                Console.WriteLine("2");
                string sql = "SELECT * FROM tbl_mesaj WHERE ogr_id = @ogrenci_id ORDER BY mesaj_id DESC LIMIT 10";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("ogrenci_id", ogrenci.ogrenciNo); // Öğrenci ID'sini burada belirtmelisiniz.
                    Console.WriteLine("3");
                    using (var reader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            Console.WriteLine("4");
                            string mesaj = reader["mesaj"].ToString();
                            int ogr_id = Convert.ToInt32(reader["ogr_id"]);
                            int hoca_id = Convert.ToInt32(reader["hoca_id"]);
                            string alici_id = Convert.ToString(reader["alici_id"]);
                            int mesaj_id = Convert.ToInt32(reader["mesaj_id"]);
                            Panel pnl = new Panel();
                            pnl.SetBounds(0, 0, 317, 100);
                            mesajTablePanel.Controls.Add(pnl, 0, i);
                            Label lbl = new Label();
                            lbl.SetBounds(0, 0, 317, 50);
                            using (var conn2 = new NpgsqlConnection(connString))
                            {
                                conn2.Open();
                                using (var cmd2 = new NpgsqlCommand("SELECT * FROM tbl_hoca WHERE hoca_sicilno= @hoca_id", conn2))
                                {
                                    cmd2.Parameters.AddWithValue("hoca_id", hoca_id);
                                    using (var reader2 = cmd2.ExecuteReader())
                                    {
                                        if (reader2.Read())
                                        {
                                            string hoca_ad = Convert.ToString(reader2["hoca_ad"]);
                                            string hoca_soyad = Convert.ToString(reader2["hoca_soyad"]);
                                            if (ogrenci.ogrenciNo.Equals(alici_id))
                                            {
                                                lbl.Text = $"Gönderen: {hoca_ad} {hoca_soyad}\n Mesaj: {mesaj}\n Alici: Siz";
                                                TextBox cevaplaalani = new TextBox();
                                                cevaplaalani.SetBounds(0, 60, 217, 30);
                                                Button btn = new Button();
                                                btn.Text = "Cevapla";
                                                btn.SetBounds(217, 60, 100, 30);
                                                pnl.Controls.Add(btn);
                                                pnl.Controls.Add(cevaplaalani);
                                                pnl.BackColor = System.Drawing.Color.AliceBlue;
                                                btn.Click += (sender, args) =>
                                                {
                                                    if (cevaplaalani.Text.Length != 0)
                                                    {
                                                        MessageBox.Show("Cevapla Başarılı");
                                                        mesajGonder(hoca_id, cevaplaalani.Text);
                                                        mesajPanelOlustur();


                                                    }

                                                };
                                            }
                                            else
                                            {
                                                pnl.BackColor = System.Drawing.Color.LavenderBlush;
                                                lbl.Text = $"Gönderen: Siz\n Mesaj: {mesaj}\n Alici: {hoca_ad} {hoca_soyad}";
                                            }


                                        }

                                    }
                                    //lbl.Text = $"Gonderen:Mesaj: {mesaj}, Öğrenci ID: {ogr_id}, Hoca ID: {hoca_id}, Alıcı ID: {alici_id}, Mesaj ID: {mesaj_id}";
                                }
                            }


                            pnl.Controls.Add(lbl);
                            //mesajTablePanel.Controls.Add(lbl, 0, i);


                            //mesajTablePanel.Controls.Add(btn, 0, i);
                            i++;
                        }
                    }
                }

            }


        }
        private void mesajGonder(int hoca_id, string mesaj)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {


                conn.Open();
                {

                    string sorgu = "INSERT INTO tbl_mesaj(ogr_id,hoca_id,alici_id,mesaj) values(@ogrenci_id,@hoca_id,@alici_id,@mesaj)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                    {
                        MessageBox.Show("Başarılı!");
                        cmd.Parameters.AddWithValue("ogrenci_id", ogrenci.ogrenciNo); // Öğrenci ID'sini burada belirtmelisiniz.
                        cmd.Parameters.AddWithValue("hoca_id", hoca_id);
                        cmd.Parameters.AddWithValue("alici_id", hoca_id);
                        cmd.Parameters.AddWithValue("mesaj", mesaj);
                        cmd.ExecuteNonQuery();

                    }
                }






            }
        }

        private void mesajPanelOlustur()
        {

            mesajTablePanel.Controls.Clear();
            mesajAl();
        }
        private void hocaListesiAl()
        {

            string[][] hocaadsoyadid = new string[10][];
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT hoca_ad,hoca_soyad,hoca_sicilno FROM tbl_hoca";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            hocaadsoyadid[i] = new string[2];
                            string hoca_adi = Convert.ToString(reader["hoca_ad"]);
                            string hoca_soyadi = Convert.ToString(reader["hoca_soyad"]);
                            string hoca_id = Convert.ToString(reader["hoca_sicilno"]);
                            hocaadsoyadid[i][0] = hoca_adi + " " + hoca_soyadi;
                            hocaadsoyadid[i][1] = hoca_id;
                            cbxKime.Items.Add(hocaadsoyadid[i][0]);

                        }


                    }

                }

            }

        }



        private string hocaIDBul(String adisoyadi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT hoca_sicilno FROM tbl_hoca WHERE hoca_ad= @p1";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("@p1", adisoyadi.Substring(0, adisoyadi.IndexOf(" ")));
                    MessageBox.Show(adisoyadi.Substring(0, adisoyadi.IndexOf(" ")));
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hoca_id = Convert.ToString(reader["hoca_sicilno"]);
                            MessageBox.Show("hoca_id:" + hoca_id);
                            return hoca_id;
                        }



                    }

                }

            }
            return null;
        }

        private void btn_yeniMesaj_Click_1(object sender, EventArgs e)
        {
            Form mesajOlustur = new Form();
            Label lblKime = new Label();
            lblKime.Text = "Kime";

            hocaListesiAl();
            TextBox tbxMesaj = new TextBox();
            Button btnGonder = new Button()
            {
                Text = "Gönder",
                Location = new System.Drawing.Point(180, 100),
                Size = new System.Drawing.Size(100, 50)
            };
            lblKime.SetBounds(0, 0, 50, 50);
            mesajOlustur.Controls.Add(lblKime);
            cbxKime.SetBounds(60, 0, 100, 50);
            mesajOlustur.Controls.Add(cbxKime);
            tbxMesaj.SetBounds(0, 60, 300, 100);
            mesajOlustur.Controls.Add(tbxMesaj);

            mesajOlustur.Controls.Add(btnGonder);
            mesajOlustur.AutoSize = true;
            mesajOlustur.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGonder.Click += (sender, args) =>
            {
                MessageBox.Show("başarılı");
                string hoca_id = hocaIDBul(cbxKime.SelectedItem.ToString());
                mesajGonder(Convert.ToInt32(hoca_id), tbxMesaj.Text);
                mesajPanelOlustur();
                mesajOlustur.Close();
            };
            mesajOlustur.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            TimeSpan geriSayim = YoneticiEkran.hedefTarih - DateTime.Now;
            lblTime.Text = "Kalan Zaman: " + geriSayim.ToString(@"dd\.hh\:mm\:ss");
            if (geriSayim.Seconds == 0)
            {
                timer1.Stop();
                YoneticiEkran.sureBittiMi = true;
                MessageBox.Show("süre bitti");

            }
        }
    }
}
