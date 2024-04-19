using System.Windows.Forms;
using Npgsql;
using SixLabors.ImageSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;
using Button = System.Windows.Forms.Button;

namespace YazLab1
{
    public partial class HocaEkran : Form
    {
        ComboBox cbxKime = new ComboBox();
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123");
        private HocaSinif hoca;
        System.Windows.Forms.Button buton = new System.Windows.Forms.Button();
        public List<string> kriterDersler = new List<string>();
        public List<int> kriterDersAgirlik = new List<int>();

        public HocaEkran(HocaSinif hoca)
        {
            InitializeComponent();
            kriterDersler.Clear();
            kriterDersAgirlik.Clear();
            this.hoca = hoca;
            dersBilgileriBoxEkle();
            kriterDersBilgileriBox(kriterdersComboBox);
            tumDersleriBoxEkle();
            tabPage1.Text = "ANA EKRAN";
            tabPage2.Text = "ÖĞRENCİLERİN TALEPLERİNİ GÖR";
            tabPage3.Text = "ÖĞRENCİLERİ LİSTELE";
            if (!YoneticiEkran.sureBittiMi)
                timer1.Start();

            mesajPanelHocaOlustur();
        }





        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void derslerimButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            DerslerimPanel.Visible = true;
            dersGetir(hoca);
        }


        private void dersGetir(HocaSinif hoca)
        {
            using (NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                baglanti.Open();

                // Dersleri alalım
                string sorguDers = "SELECT DISTINCT d.ders_adi, h.hoca_ad\r\nFROM tbl_dershoca hc\r\nJOIN tbl_dersler d ON hc.ders = d.ders_id\r\nJOIN tbl_hoca h ON hc.hoca = h.hoca_sicilno\r\nWHERE hc.hoca = @HocaNumarasi\r\n";
                using (NpgsqlCommand command = new NpgsqlCommand(sorguDers, baglanti))
                {
                    command.Parameters.AddWithValue("HocaNumarasi", hoca.sicil);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
                    DataTable dersTable = new DataTable();
                    adapter.Fill(dersTable);
                    hocaDerslerimDataView.DataSource = dersTable;
                }
            }
        }
        private bool ogrenciKriterTablosundaVarMi(string ogrenciNo)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {

                conn.Open();
                string komut = "SELECT COUNT (*) FROM tbl_hocakriterogrenci WHERE ogr_no = @ogrenciNo AND hoca_id = @hoca";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    command.Parameters.AddWithValue("ogrenciNo", ogrenciNo);
                    command.Parameters.AddWithValue("hoca", hoca.sicil);
                    int rowCount = Convert.ToInt32(command.ExecuteScalar()); // Sorgunun sonucunu al ve integer olarak dönüştür.

                    return rowCount > 0;


                }



            }
            return false;
        }

        private double harfNotuSayisal(string harfnotu)
        {
            switch (harfnotu)
            {
                case "AA":
                    return 4.0;
                case "BA":
                    return 3.5;
                case "BB":
                    return 3.0;
                case "CB":
                    return 2.5;
                case "CC":
                    return 2.0;
                default:
                    return -1;

            }



        }


        private double ogrenciKriterOncekiDeger(string ogrenciNo, string sorgu)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();

                using (NpgsqlCommand comm = new NpgsqlCommand(sorgu, conn))
                {
                    comm.Parameters.AddWithValue("ogrenci", ogrenciNo);
                    comm.Parameters.AddWithValue("hoca", hoca.sicil);

                    object result = comm.ExecuteScalar(); // Sorgunun sonucunu al
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDouble(result);
                    }
                    else
                    {
                        // Sonuç bulunamadı veya null ise bir hata kodu döndürebilirsiniz.
                        return -1; // veya başka bir hata değeri
                    }
                }
            }
        }

        private void ogrenciKriterTablosuGuncelle(string ogrenciNo, double harfnotu, int dersagirlik, int katsayi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();
                if (ogrenciKriterTablosundaVarMi(ogrenciNo))
                {
                    string puanGuncelleKomut = "SELECT puan FROM tbl_hocakriterogrenci WHERE ogr_no = @ogrenci AND hoca_id = @hoca";
                    string hesapedilenDersKomut = "SELECT hesapedilenders FROM tbl_hocakriterogrenci WHERE ogr_no = @ogrenci AND hoca_id = @hoca";

                    string komut2 = "UPDATE tbl_hocakriterogrenci SET puan = @p4, hesapedilenders = @p5 WHERE ogr_no = @ogrenci AND hoca_id = @hoca";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(komut2, conn))
                    {
                        cmd.Parameters.AddWithValue("ogrenci", ogrenciNo);
                        cmd.Parameters.AddWithValue("hoca", hoca.sicil);

                        double toplam = ogrenciKriterOncekiDeger(ogrenciNo, puanGuncelleKomut);
                        double yeniPuan = toplam + ((dersagirlik * harfnotu) / katsayi);
                        cmd.Parameters.AddWithValue("p4", yeniPuan);

                        int hesapEdilenDers = Convert.ToInt32(ogrenciKriterOncekiDeger(ogrenciNo, hesapedilenDersKomut));
                        int yeniHesapEdilenDers = hesapEdilenDers + 1;
                        cmd.Parameters.AddWithValue("p5", yeniHesapEdilenDers);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string komut = "INSERT INTO tbl_hocakriterogrenci (hoca_id, ogr_no, puan, hesapedilenders) VALUES (@p1, @p2, @p3, @p4)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                    {
                        cmd.Parameters.AddWithValue("p1", hoca.sicil);
                        cmd.Parameters.AddWithValue("p2", ogrenciNo);
                        double yeniPuan = (harfnotu * dersagirlik) / katsayi;
                        cmd.Parameters.AddWithValue("p3", yeniPuan);
                        cmd.Parameters.AddWithValue("p4", 1);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void kriterDersBilgileriAl(int dersSayisi, int katsayi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();
                string komut = "SELECT ogrenci_id, harfnotu from tbl_notlar " +
                    "INNER JOIN tbl_dersler ON tbl_notlar.ders_adi = tbl_dersler.ders_id " +
                    "INNER JOIN tbl_ogr ON tbl_notlar.ogrenci_id = tbl_ogr.ogr_no " +
                    "WHERE tbl_dersler.ders_adi = @dersAdi";

                for (int i = 0; i < dersSayisi; i++)
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                    {

                        command.Parameters.AddWithValue("dersAdi", kriterDersler.ElementAt(i));
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                string ogrenciNo = reader.GetString(0);
                                string harfNotu = reader.GetString(1);
                                if (!ogrencininKriterDersBilgileriEklendiMi(dersSayisi, ogrenciNo))
                                {
                                    ogrenciKriterTablosuGuncelle(ogrenciNo, harfNotuSayisal(harfNotu), kriterDersAgirlik.ElementAt(i), katsayi);
                                }



                            }

                        }
                    }

                }
            }

        }

        private bool ogrencininKriterDersBilgileriEklendiMi(int dersSayisi, string ogrenciNo)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();
                string sorgu = "SELECT hesapedilenders from tbl_hocakriterogrenci WHERE ogr_no = @ogrenci AND hoca_id = @hoca";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("ogrenci", ogrenciNo);
                    command.Parameters.AddWithValue("hoca", hoca.sicil);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader.GetInt32(0) == dersSayisi)
                            {
                                return true;
                            }

                        }


                    }

                }

            }


            return false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            ogrencilerinListesi("SELECT ogr_no,ogr_ad,ogr_soyad FROM tbl_ogr");
        }




        private int kriterDersToplamAkts(ref int dersSayisi)
        {
            int katsayi = 0;
            int ders = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "SELECT ders_katsayi,tbl_dersler.ders_adi,tbl_kriterders.ders_katsayi from tbl_kriterders " +
                    "INNER JOIN tbl_dersler ON tbl_kriterders.ders_id = tbl_dersler.ders_id WHERE hoca_id = @hocaSicilNo";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("hocaSicilNo", hoca.sicil);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ders++;
                            katsayi += reader.GetInt32(0);
                            kriterDersler.Add(reader.GetString(1));
                            kriterDersAgirlik.Add(reader.GetInt32(2));

                        }
                    }

                }

            }
            dersSayisi = ders;
            return katsayi;


        }

        private void kriterDersAl(string dersAdi, int katsayi)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "INSERT INTO tbl_kriterders (hoca_id,ders_id,ders_katsayi) values (@p1,@p2,@p3)";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    command.Parameters.AddWithValue("p1", hoca.sicil);
                    command.Parameters.AddWithValue("p2", ogrenciEkran.dersIDbul(dersAdi));
                    command.Parameters.AddWithValue("p3", katsayi);
                    command.ExecuteNonQuery();
                    MessageBox.Show("EKLEME BAŞARILI");

                }

            }
        }




        public static void kriterDersBilgileriBox(System.Windows.Forms.ComboBox dersSecComboBox)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ders_adi FROM tbl_dersler where ders_kodu is NOT NULL";

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



        public void ilgiEkle(HocaSinif hoca)
        {
            string ilgi = ilgiBox.Text;
            int id;

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                baglanti.Open();

                string sorgu = "SELECT COUNT(*) FROM tbl_ilgialani WHERE ilgi_isim = @isim";
                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("isim", ilgi);
                    int eskiVeriSayisi = Convert.ToInt32(komut.ExecuteScalar());

                    if (eskiVeriSayisi == 0)
                    {
                        string sorgu2 = "INSERT INTO tbl_ilgialani (ilgi_isim) values (@ilgiAlani)";
                        //string sorgu3 = "UPDATE INTO tbl_dershoca (ilgialani) values(@ilgiAlanş)"
                        using (NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti))
                        {
                            komut2.Parameters.AddWithValue("ilgiAlani", ilgi);
                            komut2.ExecuteNonQuery();
                            MessageBox.Show("Başarıyla Eklendi");
                        }

                    }
                    else
                    {
                        MessageBox.Show("EKLENDİ");
                    }
                }

                id = idBul(ilgi);
                string yeniSorgu = "INSERT INTO tbl_hocailgi (ilgi_id, hoca_id) values (@ilgiNumara, @hocaNumara)";
                using (NpgsqlCommand ekle = new NpgsqlCommand(yeniSorgu, baglanti))
                {
                    ekle.Parameters.AddWithValue("ilgiNumara", id);
                    ekle.Parameters.AddWithValue("hocaNumara", Convert.ToInt32(hoca.sicil));
                    ekle.ExecuteNonQuery();
                }

                baglanti.Close();
            }
        }
        private int idBul(string ilgiİsim)
        {
            using (NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                baglanti.Open();

                string sorgu = "SELECT ilgi_id FROM tbl_ilgialani WHERE ilgi_isim = @ilgiIsmi";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("ilgiIsmi", ilgiİsim);

                    using (NpgsqlDataReader reader = komut.ExecuteReader())
                    {
                        if (reader.Read()) // Eğer bir satır bulunursa
                        {
                            int id = reader.GetInt32(0); // Sütunu oku
                            return id;
                        }
                    }
                }
            }

            return -1; // Hiçbir veri bulunamazsa -1 döndür
        }
        private void tumDersleriBoxEkle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ders_adi\r\nFROM tbl_dersler\r\n WHERE ders_kodu IS NULL";

                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    command.Parameters.AddWithValue("hocaNo", hoca.sicil);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string ders = reader.GetString(0);

                            if (!tumderslerbox.Items.Contains(ders))
                            {
                                tumderslerbox.Items.Add(ders);
                            }


                        }

                    }

                }


            }




        }




        private void dersBilgileriBoxEkle()
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port = 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT tbl_dersler.ders_adi\r\nFROM tbl_dershoca\r\nINNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id\r\n WHERE hoca = @hocaNo";

                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    command.Parameters.AddWithValue("hocaNo", hoca.sicil);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string ders = reader.GetString(0);

                            if (!dersSecenOgrencilerComboBox.Items.Contains(ders))
                            {
                                dersSecenOgrencilerComboBox.Items.Add(ders);
                            }


                        }

                    }

                }


            }


        }


        private bool buttonColumnsAdded = false;

        private void dersAlanOgrenciListele_Click_1(object sender, EventArgs e)
        {
            // DataGridView'i temizle
            dataGridViewDersiAlanlar.DataSource = null;

            string secilenDers = dersSecenOgrencilerComboBox.SelectedItem.ToString();

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT tbl_ogr.ogr_no, tbl_ogr.ogr_ad, tbl_ogr.ogr_soyad, tbl_dersler.ders_adi " +
                    "FROM tbl_talep " +
                    "INNER JOIN tbl_ogr ON tbl_talep.ogrenciid = tbl_ogr.ogr_no " +
                    "INNER JOIN tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id " +
                    "INNER JOIN tbl_hoca ON tbl_talep.hocaid = tbl_hoca.hoca_sicilno " +
                    "WHERE tbl_dersler.ders_adi = @dersAdi AND tbl_talep.hocaid = @hocaId AND durum = @durum";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("hocaId", hoca.sicil);
                    komut.Parameters.AddWithValue("dersAdi", secilenDers);
                    komut.Parameters.AddWithValue("durum", "CEVAP BEKLENİYOR");

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(komut);
                    DataTable dersTable = new DataTable();

                    // Verileri çek ve DataTable'e doldur
                    adapter.Fill(dersTable);

                    // DataGridView'e DataTable'i bağla
                    dataGridViewDersiAlanlar.DataSource = dersTable;

                    if (!buttonColumnsAdded)
                    {
                        dataGridViewDersiAlanlar.CellContentClick -= DataGridView_CellContentClick;
                        DataGridViewButtonColumn buttonColumnKabul = new DataGridViewButtonColumn();
                        buttonColumnKabul.HeaderText = "KABUL ET";
                        buttonColumnKabul.Text = "KABUL ET";
                        buttonColumnKabul.UseColumnTextForButtonValue = true;

                        DataGridViewButtonColumn buttonColumnReddet = new DataGridViewButtonColumn();
                        buttonColumnReddet.HeaderText = "REDDET";
                        buttonColumnReddet.Text = "REDDET";
                        buttonColumnReddet.UseColumnTextForButtonValue = true;
                        dataGridViewDersiAlanlar.CellContentClick += DataGridView_CellContentClick;
                        dataGridViewDersiAlanlar.Columns.Add(buttonColumnKabul);
                        dataGridViewDersiAlanlar.Columns.Add(buttonColumnReddet);
                        buttonColumnsAdded = true;
                    }
                }
            }
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
        private void talepDurumu(bool durum)
        {
            // using NpgsqlConnection conn = new NpgsqlConnection()


        }
        private void digerDersTalebiniSil(string ogrenciNo, string dersAdi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=YazLab1;User Id=postgres;Password=123"))
            {
                conn.Open();
                string sorgu = "DELETE FROM tbl_talep " +
                    "WHERE ogrenciid = @ogrenciNo " +
                    "AND durum = 'CEVAP BEKLENİYOR' " +
                    "AND dersid = (SELECT ders_id FROM tbl_dersler WHERE ders_adi = @dersAdi) " +
                    "AND EXISTS (SELECT 1 FROM tbl_talep WHERE ogrenciid = @ogrenciNo AND dersid = (SELECT ders_id FROM tbl_dersler WHERE ders_adi = @dersAdi))";

                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("ogrenciNo", ogrenciNo);
                    komut.Parameters.AddWithValue("dersAdi", dersAdi);
                    int rowsAffected = komut.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("DİĞER DERS TALEBİ SİLİNDİ");
                    }
                    else
                    {
                        MessageBox.Show("Silinecek ders talebi bulunamadı.");
                    }
                }
            }
        }

        private void talepTablosuGuncelle(string ogrenciNo, string dersAdi, string onayDurumu)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "UPDATE tbl_talep \r\n SET durum = @durum \r\n FROM tbl_dersler, tbl_hoca \r\nWHERE tbl_talep.dersid = tbl_dersler.ders_id \r\nAND tbl_talep.hocaid = tbl_hoca.hoca_sicilno \r\nAND tbl_talep.ogrenciid = @ogrenciNo \r\nAND tbl_dersler.ders_adi = @dersAdi \r\nAND tbl_talep.hocaid = @hocaİd;";

                {

                    using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                    {
                        komut.Parameters.AddWithValue("durum", onayDurumu);
                        komut.Parameters.AddWithValue("ogrenciNo", ogrenciNo);
                        komut.Parameters.AddWithValue("dersAdi", dersAdi);
                        komut.Parameters.AddWithValue("hocaİd", hoca.sicil);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("TALEP TABLOSU GÜNCELLENDİ");

                    }
                }

            }



        }

        public void dersiEkle(string ogrenciNo, string dersAdi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "INSERT INTO tbl_dershoca (ders,hoca,ogrenci) values (@p1,@p2,@p3)";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("p1", dersIDbul(dersAdi));
                    command.Parameters.AddWithValue("p2", hoca.sicil);
                    command.Parameters.AddWithValue("p3", ogrenciNo);
                    command.ExecuteNonQuery();
                    onayTablosu(ogrenciNo, dersAdi);
                    MessageBox.Show("Ders Başarıyla Eklendi");
                    talepTablosuGuncelle(ogrenciNo, dersAdi, "ONAYLANDI");
                }

            }


        }


        private int TalepIdBul(string ogrenciNo, string dersAdi)
        {

            int idNo;

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();

                string sorgu = "SELECT talepid from tbl_talep " +
                    "INNER JOIN tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id " +
                    "where ders_adi =@dersAdi AND ogrenciid = @ogrenciNo AND hocaid = @hocasicil";


                {

                    using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                    {

                        komut.Parameters.AddWithValue("dersAdi", dersAdi);
                        komut.Parameters.AddWithValue("ogrenciNo", ogrenciNo);
                        komut.Parameters.AddWithValue("hocasicil", hoca.sicil);
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
        private void onayTablosu(string ogrenciNo, string dersAdi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123 "))
            {
                conn.Open();

                string komut = "INSERT INTO tbl_onay (talepid,onaylayanhoca,onaytarihi,durum) values (@p1,@p2,@p3,@p4)";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {

                    command.Parameters.AddWithValue("p1", TalepIdBul(ogrenciNo, dersAdi));
                    MessageBox.Show(TalepIdBul(ogrenciNo, dersAdi).ToString());
                    command.Parameters.AddWithValue("p2", hoca.sicil);
                    command.Parameters.AddWithValue("p3", DateTime.Now);
                    command.Parameters.AddWithValue("p4", "ONAYLANDI");
                    command.ExecuteNonQuery();

                }
            }

        }
        public void hocaKontenjanDusur(int kontenjan)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=YazLab1;User Id=postgres;Password=123"))
            {

                conn.Open();
                string yeniSorgu = "UPDATE tbl_hoca SET hoca_kontenjan = @kontenjan WHERE hoca_sicilno = @hocaNo";
                using (NpgsqlCommand comm2 = new NpgsqlCommand(yeniSorgu, conn))
                {
                    comm2.Parameters.AddWithValue("kontenjan", --kontenjan);
                    comm2.Parameters.AddWithValue("hocaNo", hoca.sicil);
                    int rowsAffected = comm2.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("KONTENJAN GÜNCELLENDİ");
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız.");
                    }
                }
            }







        }
        private int hocaKontenjanBul()
        {
            int kontenjan = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=YazLab1;User Id=postgres;Password=123"))
            {
                conn.Open();
                string sorgu = "SELECT hoca_kontenjan FROM tbl_hoca WHERE hoca_sicilno = @hocaNo";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("hocaNo", hoca.sicil);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kontenjan = reader.GetInt32(0);
                            return kontenjan;
                        }
                        else
                        {
                            MessageBox.Show("Hoca bulunamadı veya kayıtlı bir kontenjan yok.");
                            return -1;
                        }
                    }
                }


            }
        }


        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer kabul et veya reddet butonuna tıklandıysa
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string buttonText = dataGridViewDersiAlanlar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string ogrenciNo = dataGridViewDersiAlanlar.Rows[e.RowIndex].Cells["ogr_no"].Value.ToString();
                string dersAdi = dataGridViewDersiAlanlar.Rows[e.RowIndex].Cells["ders_adi"].Value.ToString();
                int kontenjan = hocaKontenjanBul();

                if (buttonText == "KABUL ET")
                {
                    if (kontenjan < 1)
                    {
                        MessageBox.Show("YETERLİ KONTENJAN SAYINIZ YOK BU İSTEGİ KABUL EDEMEZSİNİZ");
                        talepTablosuGuncelle(ogrenciNo, dersAdi, "REDDEDİLDİ");


                    }
                    else
                    {
                        int hocaNo = hoca.sicil;
                        dersiEkle(ogrenciNo, dersAdi);
                        digerDersTalebiniSil(ogrenciNo, dersAdi);
                        hocaKontenjanDusur(kontenjan);
                    }
                }
                else if (buttonText == "REDDET")
                {
                    string ad = dataGridViewDersiAlanlar.Rows[e.RowIndex].Cells["ogr_ad"].Value.ToString();
                    talepTablosuGuncelle(ogrenciNo, dersAdi, "REDDEDİLDİ");
                    MessageBox.Show("DERS TALEBİ REDDEDİLDİ. İLGİLİ ÖGRENCİ DAHA SONRA TEKRAR İSTEK YOLLAYABİLİR");

                }
            }
        }
        private void ilgiEkleButton_Click_1(object sender, EventArgs e)
        {
            ilgiEkle(hoca);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123 "))
            {
                conn.Open();
                string sorgu = "SELECT tbl_ogr.ogr_no, tbl_ogr.ogr_ad, tbl_ogr.ogr_soyad, tbl_dersler.ders_adi, durum " +
        "FROM tbl_talep " +
    "INNER JOIN tbl_ogr ON tbl_talep.ogrenciid = tbl_ogr.ogr_no " +
    "INNER JOIN tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id " +
    "WHERE tbl_dersler.ders_adi = @dersAdi AND durum = @onay";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("dersAdi", tumderslerbox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("onay", "CEVAP BEKLENİYOR");
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataTable dersTable = new DataTable();
                    adapter.Fill(dersTable);
                    ogrenciDurumlarıDataGrid.DataSource = dersTable;

                }


            }
        }
        private void ogrencilerinListesi(string komut)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                {
                    if (komut.Contains("hoca"))
                    {

                        cmd.Parameters.AddWithValue("hoca", hoca.sicil);

                    }

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataTable dersTable = new DataTable();

                    // Verileri çek ve DataTable'e doldur
                    adapter.Fill(dersTable);

                    // DataGridView'e DataTable'i bağla
                    ogrencininAldigiDerslerDataGrid.DataSource = dersTable;
                    if (!buttonColumnsAdded)
                    {
                        ogrencininAldigiDerslerDataGrid.CellContentClick -= DataGridView_CellContentClick;
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

                        buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.Text = "SEÇ";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        ogrencininAldigiDerslerDataGrid.Columns.Add(buttonColumn);
                        ogrencininAldigiDerslerDataGrid.CellContentClick += OgrencininAldigiDerslerDataGrid_CellContentClick;

                        buttonColumnsAdded = true;
                    }



                }
            }
        }
        private void ogrencininAldigiDersler(string ogrenci)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT tbl_dersler.ders_adi,tbl_hoca.hoca_ad,tbl_hoca.hoca_soyad FROM tbl_dershoca " +
                "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                "INNER JOIN tbl_ogr ON tbl_dershoca.ogrenci = tbl_ogr.ogr_no " +
                "INNER JOIN tbl_hoca ON tbl_dershoca.hoca = tbl_hoca.hoca_sicilno " +
                "WHERE tbl_ogr.ogr_no = @ogrenciNo";


                using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                {
                    cmd.Parameters.AddWithValue("ogrenciNo", ogrenci);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {

                            string s = reader.GetString(0);

                            MessageBox.Show(i + 1 + ".DERS  " + s + "\n" + "HOCA : " + reader.GetString(1) + " " + reader.GetString(2));
                            i++;


                        }

                    }

                }

            }

        }

        private void OgrencininAldigiDerslerDataGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string ogrenciNo = ogrencininAldigiDerslerDataGrid.Rows[e.RowIndex].Cells["ogr_no"].Value.ToString();
                string buttonText = ogrencininAldigiDerslerDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (buttonText == "SEÇ")
                {
                    ogrencininAldigiDersler(ogrenciNo);

                }

            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dersAdi = kriterdersComboBox.Text.ToString();
            int katsayi = Convert.ToInt32(kriterdersTextBox.Text);
            kriterDersAl(dersAdi, katsayi);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ogrencininAldigiDerslerDataGrid.DataSource = null;
            kriterDersler.Clear();
            kriterDersAgirlik.Clear();
            int dersSayisi = 0;
            int katsayi = kriterDersToplamAkts(ref dersSayisi);
            kriterDersBilgileriAl(dersSayisi, katsayi);
            string sorgu = "SELECT tbl_ogr.ogr_no,tbl_ogr.ogr_ad,tbl_ogr.ogr_soyad,tbl_hocakriterogrenci.puan FROM tbl_hocakriterogrenci " +
                "INNER JOIN tbl_ogr ON tbl_hocakriterogrenci.ogr_no = tbl_ogr.ogr_no WHERE hoca_id = @hoca ORDER BY puan DESC ";
            ogrencilerinListesi(sorgu);
        }

        private void mesajAl()
        {
            Console.WriteLine("1");
            string connString = "Host=localhost;Username=postgres;Password=123;Database=YazLab1";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                Console.WriteLine("2");
                string sql = "SELECT * FROM tbl_mesaj WHERE hoca_id = @hoca_id ORDER BY mesaj_id DESC LIMIT 10";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("hoca_id", Convert.ToString(hoca.sicil)); // Öğrenci ID'sini burada belirtmelisiniz.
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
                            mesajTablePanelHoca.Controls.Add(pnl, 0, i);
                            Label lbl = new Label();
                            lbl.SetBounds(0, 0, 317, 50);
                            using (var conn2 = new NpgsqlConnection(connString))
                            {
                                conn2.Open();
                                using (var cmd2 = new NpgsqlCommand("SELECT * FROM tbl_ogr WHERE ogr_no= @ogrenci_id", conn2))
                                {
                                    cmd2.Parameters.AddWithValue("ogrenci_id", Convert.ToString(ogr_id));
                                    using (var reader2 = cmd2.ExecuteReader())
                                    {
                                        if (reader2.Read())
                                        {
                                            string ogr_ad = Convert.ToString(reader2["ogr_ad"]);
                                            string ogr_soyad = Convert.ToString(reader2["ogr_soyad"]);
                                            if (Convert.ToString(hoca.sicil).Equals(alici_id))
                                            {
                                                lbl.Text = $"Gönderen: {ogr_ad} {ogr_soyad}\n Mesaj: {mesaj}\n Alici: Siz";
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
                                                        mesajGonder(ogr_id, cevaplaalani.Text);
                                                        mesajPanelHocaOlustur();


                                                    }

                                                };
                                            }
                                            else
                                            {
                                                pnl.BackColor = System.Drawing.Color.LavenderBlush;
                                                lbl.Text = $"Gönderen: Siz\n Mesaj: {mesaj}\n Alici: {ogr_ad} {ogr_soyad}";

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
        private void mesajGonder(int ogr_id, string mesaj)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {


                conn.Open();
                {

                    string sorgu = "INSERT INTO tbl_mesaj(ogr_id,hoca_id,alici_id,mesaj) values(@ogrenci_id,@hoca_id,@alici_id,@mesaj)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                    {
                        MessageBox.Show("Başarılı!");
                        cmd.Parameters.AddWithValue("ogrenci_id", ogr_id); // Öğrenci ID'sini burada belirtmelisiniz.
                        cmd.Parameters.AddWithValue("hoca_id", Convert.ToString(hoca.sicil));
                        cmd.Parameters.AddWithValue("alici_id", ogr_id);
                        cmd.Parameters.AddWithValue("mesaj", mesaj);
                        cmd.ExecuteNonQuery();

                    }
                }






            }
        }

        private void mesajPanelHocaOlustur()
        {

            mesajTablePanelHoca.Controls.Clear();
            mesajAl();
        }
        private void ogrListesiAl()
        {

            string[][] ogradsoyadid = new string[10][];
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT ogr_ad,ogr_soyad,ogr_no FROM tbl_ogr";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            ogradsoyadid[i] = new string[2];
                            string ogr_adi = Convert.ToString(reader["ogr_ad"]);
                            string ogr_soyad = Convert.ToString(reader["ogr_soyad"]);
                            string ogr_id = Convert.ToString(reader["ogr_no"]);
                            ogradsoyadid[i][0] = ogr_adi + " " + ogr_soyad;
                            ogradsoyadid[i][1] = ogr_id;
                            cbxKime.Items.Add(ogradsoyadid[i][0]);

                        }


                    }

                }

            }

        }




        private string ogrIDBul(String adisoyadi)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; username=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "SELECT ogr_no FROM tbl_ogr WHERE ogr_ad= @p1";


                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("@p1", adisoyadi.Substring(0, adisoyadi.IndexOf(" ")));
                    MessageBox.Show(adisoyadi.Substring(0, adisoyadi.IndexOf(" ")));
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ogr_id = Convert.ToString(reader["ogr_no"]);
                            MessageBox.Show("ogr_no:" + ogr_id);
                            return ogr_id;
                        }



                    }

                }

            }
            return null;
        }



        private void btnyeniMesaj_Click(object sender, EventArgs e)
        {
            Form mesajOlustur = new Form();
            Label lblKime = new Label();
            lblKime.Text = "Kime";

            ogrListesiAl();
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
                MessageBox.Show("başarlılı");
                string ogr_id = ogrIDBul(cbxKime.SelectedItem.ToString());
                mesajGonder(Convert.ToInt32(ogr_id), tbxMesaj.Text);
                mesajPanelHocaOlustur();
                mesajOlustur.Close();
            };
            mesajOlustur.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan geriSayim = YoneticiEkran.hedefTarih - DateTime.Now;
            lblKalanZaman.Text = "Kalan Zaman:\n" + geriSayim.ToString(@"dd\.hh\:mm\:ss");
            if (geriSayim.TotalSeconds == 0)
            {
                timer1.Stop();
                YoneticiEkran.sureBittiMi = true;
                MessageBox.Show("süre bitti");

            }
        }
    }
}
