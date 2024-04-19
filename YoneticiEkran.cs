using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab1

{

    public partial class YoneticiEkran : Form
    {

        NpgsqlConnection baglanti = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123");
        public List<string> isimler;
        public List<string> soyisimler;
        public static List<int> dersler = new List<int>();
        public List<int> hocalar = new List<int>();
        public List<string> ogrenciNo = new List<string>();
        public List<string> dersAdlari = new List<string>();
        public List<int> akts = new List<int>();
        public List<ogrenciSinif> ogrenciList = new List<ogrenciSinif>();
        Random rand = new Random();
        public static int ogrenciNumarasi = 12345;
        System.Timers.Timer timer = new System.Timers.Timer();
        public static DateTime hedefTarih = new DateTime(2023, 11, 8);
        public static Boolean sureBittiMi = false;
        public DateTime gethedefTarih()
        {
            return hedefTarih;
        }
        public YoneticiEkran()
        {
            ogrenciNo.Clear();
            dersler.Clear();
            InitializeComponent();
            dersAdlari.Clear();
            akts.Clear();
            dersCek();
            ogrencilerBoxEkle();

            tabPage2.Text = "OGRENCİ BİLGİLERİ GÖSTER";
            tabPage1.Text = "ANA EKRAN";
            tabPage3.Text = "İLGİ ALANI DÜZENLE";
            tabPage4.Text = "TALEP GEÇMİŞİ GÖSTER";
            if (!sureBittiMi)
                timer1.Start();


        }
        private void ogrencilerBoxEkle()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string komut = "SELECT ogr_no from tbl_ogr";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            dersekleogrencibox.Items.Add(reader.GetString(0));

                        }


                    }


                }
            }

        }
        
        public void dersDataGetir()
        {

            try
            {
                baglanti.Open();
                string sorguDers = "SELECT ders_id,ders_kodu,ders_adi,ders_akts FROM tbl_dersler WHERE ders_kodu IS NULL";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sorguDers, baglanti);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                derslerdatanew.DataSource = dataset.Tables[0];
                derslerdatanew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

        }
        public void hocaDataGetir()
        {
            try
            {
                baglanti.Open();
                string sorguDers = "SELECT hoca_sicilno,hoca_ad,hoca_soyad,hoca_kontenjan FROM tbl_hoca";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sorguDers, baglanti);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                hocalarDataNew.DataSource = dataset.Tables[0];
                hocalarDataNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

        }





        private void dersAtamasiYapBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabPage1.Text = "ANA EKRAN";
            dersDataGetir();
            hocaDataGetir();
        }

        private void dersAtamaButton_Click(object sender, EventArgs e)
        {

        }

        public void dersList()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT ders_id FROM tbl_dersler WHERE ders_kodu IS NULL";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ders = Convert.ToInt32(reader["ders_id"]);
                            dersler.Add(ders);

                        }


                    }
                }
            }

        }
        public void hocaList()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                conn.Open();
                string komut = "SELECT hoca_sicilno FROM tbl_hoca";
                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int hoca = Convert.ToInt32(reader["hoca_sicilno"]);
                            hocalar.Add(hoca);

                        }
                    }

                }

            }

        }




        private void rastgeleButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("RASTGELE BUTONUNA BASILDI");
            int[] kontrolDizi = new int[3];
            dersList();
            hocaList();
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123"))
            {
                int hocaSayac = 0;
                conn.Open();
                string sorgu = "INSERT INTO tbl_dershoca (ders,hoca) values (@dersAdi,@hocaAdi)";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {

                    for (int i = 0; i < dersler.Count; i++)
                    {


                        if (hocalar.Count > 0)
                        {
                            int rastgeleHoca = hocalar.ElementAt(hocaSayac);
                            hocalar.RemoveAt(hocaSayac);
                            Array.Clear(kontrolDizi, 0, kontrolDizi.Length);
                            for (int j = 0; j < 3; j++)
                            {
                                int a = dersler.ElementAt(j);

                                command.Parameters.AddWithValue("dersAdi", a);
                                command.Parameters.AddWithValue("hocaAdi", rastgeleHoca);
                                command.ExecuteNonQuery();
                            }

                        }
                        else
                        {

                            MessageBox.Show("DERS ATAMASI YAPILDI");
                            break;
                        }

                        // hocaSayac++;
                    }



                }

            }

        }
        private void ogrencilerinListesi()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "SELECT ogr_no,ogr_ad,ogr_soyad FROM tbl_ogr";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    DataTable dersTable = new DataTable();

                    // Verileri çek ve DataTable'e doldur
                    adapter.Fill(dersTable);

                    // DataGridView'e DataTable'i bağla
                    yoneticiEkraniOgrencilerDataGrid.DataSource = dersTable;

                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();


                }
            }
        }
        private void ogrencileriVeriTabanınaEkle(ogrenciSinif ogrenci)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {

                conn.Open();
                string sorgu = "INSERT INTO tbl_ogr (ogr_no,ogr_ad,ogr_soyad) values (@numara,@ad,@soyad)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {

                    cmd.Parameters.AddWithValue("numara", ogrenci.ogrenciNo);
                    cmd.Parameters.AddWithValue("ad", ogrenci.ad);
                    cmd.Parameters.AddWithValue("soyad", ogrenci.soyad);
                    cmd.ExecuteNonQuery();

                }
                string update = "UPDATE tbl_ogrencinumaralari set ogr_numara= @numara ";
                using (NpgsqlCommand cmd2 = new NpgsqlCommand(update, conn))
                {
                    cmd2.Parameters.AddWithValue("numara", ogrenci.ogrenciNo);
                    cmd2.ExecuteNonQuery();

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            // ogrencilercombobox.Items.Clear();
            ogrencilerinListesi();
            ogrencilerBoxEkle();
            

        }

        public int GetSonOgrenciNo()
        {
            int sonOgrenciNo;

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {

                conn.Open();
                string sorgu = "SELECT ogr_numara FROM tbl_ogrencinumaralari";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {


                    if (cmd.ExecuteScalar() == null)
                    {
                        sonOgrenciNo = 113;
                        return ++sonOgrenciNo;

                    }
                    else
                    {
                        sonOgrenciNo = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }




            }

            return ++sonOgrenciNo;
        }
        private void ogrenciKullaniciEkle(ogrenciSinif ogrenci)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {
                conn.Open();
                string komut = "INSERT INTO ogrencikullanici (ogrenci_no,ogr_sifre) values (@p1,@p2)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                {
                    cmd.Parameters.AddWithValue("p1", ogrenci.ogrenciNo);
                    cmd.Parameters.AddWithValue("p2", 1);
                    cmd.ExecuteNonQuery();


                }

            }
        }

        public static string harfNotu(int sayi)
        {
            switch (sayi)
            {
                case 1: return "AA";
                case 2: return "BA";
                case 3: return "BB";
                case 4: return "CB";
                case 5: return "CC";
                default: return null;

            }



        }

        private void dersCek()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {
                conn.Open();
                string komut = "SELECT ders_adi, ders_akts FROM tbl_dersler WHERE ders_kodu IS NOT NULL ";


                using (NpgsqlCommand command = new NpgsqlCommand(komut, conn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string dersAdi = reader.GetString(0);
                            int a = reader.GetInt32(1);
                            dersAdlari.Add(dersAdi);
                            akts.Add(a);
                        }
                    }

                }
            }
        }

        private void veritabanındanDersCek(ogrenciSinif ogrenci)
        {
            string harfnotu = string.Empty;

            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {
                conn.Open();
                string komut2 = "INSERT INTO tbl_notlar(ogrenci_id, ders_adi, harfnotu) values (@p1, @p2, @p3)";
                for (int i = 0; i < dersAdlari.Count; i++)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(komut2, conn))
                    {

                        // Her ders için yeni bir harf notu oluşturun
                        int sayi = rand.Next(1, 6);
                        harfnotu = harfNotu(sayi);

                        cmd.Parameters.AddWithValue("p1", ogrenci.ogrenciNo);
                        cmd.Parameters.AddWithValue("p2", ogrenciEkran.dersIDbul(dersAdlari[i])); // Ders adını doğrudan kullanın
                        cmd.Parameters.AddWithValue("p3", harfnotu);
                        cmd.ExecuteNonQuery();
                    }
                }
            }


        }


        private void hocaGirisiEkle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {
                conn.Open();
                string sorgu = "INSERT INTO tbl_hocakullanici (hoca_no,hoca_sifre) values (@hocano,@hocasifre)";
                using (NpgsqlCommand comm = new NpgsqlCommand(sorgu, conn))
                {

                    comm.Parameters.AddWithValue("hocano", Convert.ToInt32(sicilBox.Text));
                    comm.Parameters.AddWithValue("hocasifre", 1);
                    comm.ExecuteNonQuery();

                }
                MessageBox.Show("ÖGRETMEN GİRİŞİ EKLENDİ");



            }





        }
        private void hocaekle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server=localhost; port=5432; Database=YazLab1; user ID=postgres; password=123"))
            {
                conn.Open();
                string komut = "INSERT INTO tbl_hoca(hoca_sicilno,hoca_ad,hoca_soyad,hoca_kontenjan) values (@sicil,@ad,@soyad,@kontenjan)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                {
                    cmd.Parameters.AddWithValue("sicil", Convert.ToInt32(sicilBox.Text));
                    cmd.Parameters.AddWithValue("ad", adBox.Text);
                    cmd.Parameters.AddWithValue("soyad", soyadBox.Text);
                    cmd.Parameters.AddWithValue("kontenjan", Convert.ToInt32(kontenjan.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hoca Bilgileri Eklendi");

                }





            }





        }





        private void ogrenciUretButton_Click(object sender, EventArgs e)
        {
            isimler = new List<string>
    {
        "Ahmet", "Mehmet", "Ayşe", "Fatma", "Can", "Ebru", "Mustafa", "Emine", "Ali", "Zeynep"
    };
            soyisimler = new List<string>
    {
        "Yılmaz", "Demir", "Kara", "Öztürk", "Güneş", "Aydın", "Koç", "Turan", "Taş", "Çelik", "Çınar" , "Toksöz" , "Altın" ,"Kartal", "Milli" , "Karaca"

            };


            if (Convert.ToInt32(ogrenciSayisiTextBox.Text) > 50)
            {
                MessageBox.Show("ÜRETİLECEK OGRENCİ SAYISI MAX 50 OLABİLİR !");


            }
            else
            {
                for (int i = 0; i < Convert.ToInt32(ogrenciSayisiTextBox.Text); i++)
                {

                    ogrenciSinif ogrenci = new ogrenciSinif(GetSonOgrenciNo().ToString());
                    ogrenci.ad = isimler.ElementAt(rand.Next(0, isimler.Count));
                    ogrenci.soyad = soyisimler.ElementAt(rand.Next(0, soyisimler.Count));

                    ogrenciList.Add(ogrenci);


                    ogrencileriVeriTabanınaEkle(ogrenci);
                    ogrenciKullaniciEkle(ogrenci);
                    veritabanındanDersCek(ogrenci);

                }


                MessageBox.Show("ÖĞRENCİ EKLEMESİ BAŞARILI");

            }


        }

        private void ogretmenEkleButton_Click(object sender, EventArgs e)
        {

        }

        private void dersAtamaButton_Click_1(object sender, EventArgs e)
        {


        }
        public void ogrencileriCek()
        {

            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "SELECT ogr_no FROM tbl_ogr";
                using (NpgsqlCommand comm = new NpgsqlCommand(sorgu, connection))
                {
                    using (NpgsqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ogrenciNo.Add(reader.GetString(0));
                        }
                    }
                }
            }

        }

        private bool dersSecmisMi(int ders, string ogrenciNo)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();
                string komut = "SELECT COUNT (*) FROM tbl_dershoca " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "INNER JOIN tbl_ogr ON tbl_dershoca.ogrenci = tbl_ogr.ogr_no " +
                    "WHERE tbl_dershoca.ders = @dersno AND tbl_dershoca.ogrenci = @ogrenciNo";
                using (NpgsqlCommand cmd = new NpgsqlCommand(komut, conn))
                {
                    cmd.Parameters.AddWithValue("dersno", ders);
                    cmd.Parameters.AddWithValue("ogrenciNo", ogrenciNo);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        return true;
                    }

                }


            }

            return false;

        }
        private void dersiEkle(string ogrenciNo, int hocaId, int ders)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port = 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "INSERT INTO tbl_dershoca (ders,hoca,ogrenci) values (@p1,@p2,@p3)";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("p1", ders);
                    command.Parameters.AddWithValue("p2", hocaId);
                    command.Parameters.AddWithValue("p3", ogrenciNo);
                    hocaKontenjanDusur(hocaKontenjanBul(hocaId), hocaId);
                    command.ExecuteNonQuery();



                }

            }
        }
        public void hocaKontenjanDusur(int kontenjan, int hocaNo)
        {

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=YazLab1;User Id=postgres;Password=123"))
            {

                conn.Open();
                string yeniSorgu = "UPDATE tbl_hoca SET hoca_kontenjan = @kontenjan WHERE hoca_sicilno = @hocaNo";
                using (NpgsqlCommand comm2 = new NpgsqlCommand(yeniSorgu, conn))
                {
                    comm2.Parameters.AddWithValue("kontenjan", --kontenjan);
                    comm2.Parameters.AddWithValue("hocaNo", hocaNo);
                    int rowsAffected = comm2.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işlemi başarısız.");
                    }
                }
            }


        }
        private int hocaKontenjanBul(int hocaNo)
        {
            int kontenjan = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=YazLab1;User Id=postgres;Password=123"))
            {
                conn.Open();
                string sorgu = "SELECT hoca_kontenjan FROM tbl_hoca WHERE hoca_sicilno = @hocaNo";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, conn))
                {
                    command.Parameters.AddWithValue("hocaNo", hocaNo);
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




        private void dersinOgretmeniniSec(string ogrenciNo, int dersNo)
        {
            List<int> hocaId = new List<int>();
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                conn.Open();
                string sorgu = "SELECT tbl_dershoca.hoca FROM tbl_dershoca \r\n" +
                    "                    INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id\r\n" +
                    "                    INNER JOIN tbl_hoca on tbl_dershoca.hoca = tbl_hoca.hoca_sicilno \r\n " +
                    "                   WHERE tbl_dershoca.ders = @dersNo AND tbl_hoca.hoca_kontenjan > 0";


                using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, conn))
                {
                    cmd.Parameters.AddWithValue("dersNo", dersNo);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hocaId.Add(reader.GetInt32(0));

                        }
                        int rastgele = rand.Next(0, hocaId.Count);
                        int c = hocaKontenjanBul(hocaId.ElementAt(rastgele));
                        if (hocaKontenjanBul(hocaId.ElementAt(rastgele)) < 1)
                        {
                            while (hocaKontenjanBul(hocaId.ElementAt(rastgele)) < 1)
                            {
                                rastgele = rand.Next(0, hocaId.Count);
                                hocaKontenjanBul(hocaId.ElementAt(rastgele));

                            }

                        }
                        dersiEkle(ogrenciNo, hocaId.ElementAt(rastgele), dersNo);
                    }

                }


            }
        }



        private void ogrenciAtamasi()
        {
            for (int i = 0; i < ogrenciNo.Count; i++)
            {
                for (int j = 0; j < dersler.Count; j++)
                {
                    if (!dersSecmisMi(dersler.ElementAt(j), ogrenciNo.ElementAt(i)))
                    {

                        dersinOgretmeniniSec(ogrenciNo.ElementAt(i), dersler.ElementAt(j));

                    }
                }



            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dersAdlari.Clear();
            ogrenciNo.Clear();
            dersList();
            ogrencileriCek();
            ogrenciAtamasi();
            MessageBox.Show("RASTGELE ATAMA GERÇEKLEŞTİ");

        }
        public void ilgiEkle()
        {
            string ilgi = yeniIlgiAlani.Text;
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

                //id = idBul(ilgi);
                //string yeniSorgu = "INSERT INTO tbl_hocailgi (ilgi_id, hoca_id) values (@ilgiNumara, @hocaNumara)";
                //using (NpgsqlCommand ekle = new NpgsqlCommand(yeniSorgu, baglanti))
                //{
                //    ekle.Parameters.AddWithValue("ilgiNumara", id);
                //    ekle.Parameters.AddWithValue("hocaNumara", Convert.ToInt32(hoca.sicil));
                //    ekle.ExecuteNonQuery();
                //}

                //baglanti.Close();
            }
        }

        private void hocayaIlgiEkle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "INSERT INTO tbl_hocailgi(hoca_id,ilgi_id) values (@hoca,@ilgi)";
                using (NpgsqlCommand komut = new NpgsqlCommand(sorgu, conn))
                {
                    komut.Parameters.AddWithValue("hoca", hocaIDBul(hocaComboBox.SelectedItem.ToString()));
                    komut.Parameters.AddWithValue("ilgi", idBul(ilgialanibox.SelectedItem.ToString()));
                    komut.ExecuteNonQuery();
                    MessageBox.Show("İŞLEM BAŞARILI");

                }

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
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ilgiEkle();

        }

        private void ilgiAlanıBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogrenciEkran.ilgiAlanlariComboBoxEkle(ilgiAlanıBox);
        }

        private int hocaIDBul(string isim)
        {

            string[] kelimeler = isim.Split(' ');

            string sonKelime = kelimeler[kelimeler.Length - 1];
            string digerKelimeler = string.Join(" ", kelimeler, 0, kelimeler.Length - 1);

            string soru = "SELECT hoca_sicilno from tbl_hoca WHERE hoca_ad = @ad AND hoca_soyad = @soyad";

            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();

                using (NpgsqlCommand komut = new NpgsqlCommand(soru, conn))
                {
                    komut.Parameters.AddWithValue("ad", digerKelimeler);
                    komut.Parameters.AddWithValue("soyad", sonKelime);
                    using (NpgsqlDataReader read = komut.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            return read.GetInt32(0);
                        }

                    }


                }

            }


            return -1;

        }
        private void hocalariBoxaEkle()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {

                conn.Open();
                string sorgu = "SELECT hoca_ad,hoca_soyad from tbl_hoca";
                using (NpgsqlCommand comm = new NpgsqlCommand(sorgu, conn))
                {
                    using (NpgsqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hocaComboBox.Items.Add(reader.GetString(0) + " " + reader.GetString(1));

                        }

                    }

                }
            }


        }
        private void ilgiAlaniSil()
        {


            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string komut = "DELETE FROM tbl_ilgialani WHERE ilgi_isim = @isim";
                using (NpgsqlCommand comm = new NpgsqlCommand(komut, conn))
                {
                    comm.Parameters.AddWithValue("isim", ilgiAlaniSilBox.SelectedItem.ToString());
                    comm.ExecuteNonQuery();
                    MessageBox.Show("BAŞARIYLA SİLİNDİ");

                }




            }


        }
        private void button6_Click(object sender, EventArgs e)
        {
            hocayaIlgiEkle();

        }


        private void ilgiGuncelle(string text)
        {

            int id = idBul(text);
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string komut = "UPDATE tbl_ilgialani SET ilgi_isim = @ilgi WHERE ilgi_id = @id";
                using (NpgsqlCommand comm = new NpgsqlCommand(komut, conn))
                {
                    comm.Parameters.AddWithValue("ilgi", ilgiAlaniGuncelleYeni.Text);
                    comm.Parameters.AddWithValue("id", id);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("GÜNCELLEME BAŞARILI");


                }
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            ilgiGuncelle(ilgiAlanıBox.SelectedItem.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ilgiAlaniSil();
        }
        public void talepGecmisiGoruntule()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123"))
            {
                conn.Open();
                string sorgu = "SELECT tbl_ogr.ogr_no,tbl_ogr.ogr_ad,tbl_ogr.ogr_soyad,tbl_dersler.ders_adi,tbl_hoca.hoca_ad,tbl_hoca.hoca_soyad,taleptarihi,durum FROM tbl_talep " +
                    "INNER JOIN tbl_ogr ON tbl_talep.ogrenciid = tbl_ogr.ogr_no " +
                    "INNER JOIN tbl_dersler ON tbl_talep.dersid = tbl_dersler.ders_id " +
                    "INNER JOIN tbl_hoca ON tbl_talep.hocaid = tbl_hoca.hoca_sicilno ";

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                talepGecmisiDataGrid.DataSource = dataset.Tables[0];
                talepGecmisiDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            }




        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            talepGecmisiGoruntule();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage3;
            ilgiAlanıBox.Items.Clear();
            ilgialanibox.Items.Clear();
            ilgiAlaniSilBox.Items.Clear();

            hocalariBoxaEkle();
            ogrenciEkran.ilgiAlanlariComboBoxEkle(ilgialanibox);
            ogrenciEkran.ilgiAlanlariComboBoxEkle(ilgiAlanıBox);
            ogrenciEkran.ilgiAlanlariComboBoxEkle(ilgiAlaniSilBox);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ogrekle_Click(object sender, EventArgs e)
        {
            hocaekle();
            hocaGirisiEkle();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (int.TryParse(hocaidalinanbox.Text, out int hocaId) && int.TryParse(dersidalinanbox.Text, out int dersId))
            {
                string connString = "Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connString))
                {
                    connection.Open();

                    string query = "INSERT INTO tbl_dershoca (ders,hoca) values (@yeniDeger1,@yenideger2)";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("yeniDeger1", dersId);
                        command.Parameters.AddWithValue("yeniDeger2", hocaId);
                        try
                        {
                            int rowsAffected = command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("HATALI GİRİŞ,TEKRAR DENEYİNİZ");
                            throw;
                        }

                        MessageBox.Show(" DERS EKLEMESİ BAŞARILI ! ");


                    }
                }
            }
            else
            {
                MessageBox.Show("Hoca ID ve Ders ID geçerli sayılar değil.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan geriSayim = hedefTarih - DateTime.Now;
            lblKalanZamanYonetici.Text = "Kalan Zaman:\n" + geriSayim.ToString(@"dd\.hh\:mm\:ss");
            if (geriSayim.Seconds == 0)
            {
                timer1.Stop();
                sureBittiMi = true;
                MessageBox.Show("süre bitti");
            }
        }

        private void btnZamanBitir_Click(object sender, EventArgs e)
        {

            hedefTarih = DateTime.Now.AddSeconds(15);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dersAtamasiYap();
        }
        public void dersAtamasiYap()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "INSERT INTO tbl_dershoca (ders,hoca,ogrenci) values(@ders1,@hoca1,@ogrenci1)";
                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("ders1", ogrenciEkran.dersIDbul(derseklebox.SelectedItem.ToString()));
                    command.Parameters.AddWithValue("hoca1", hocaIDBul(ogretmenbox.SelectedItem.ToString()));
                    command.Parameters.AddWithValue("ogrenci1", Convert.ToInt32(dersekleogrencibox.SelectedItem.ToString()));
                    command.ExecuteNonQuery();
                    MessageBox.Show("EKLEME BAŞARILI");
                    int k = hocaKontenjanBul(hocaIDBul(ogretmenbox.SelectedItem.ToString()));
                    hocaKontenjanDusur(k, hocaIDBul(ogretmenbox.SelectedItem.ToString()));

                }
            }

        }
        private void dersekleogrencibox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            derseklebox.Items.Clear();


            string seciliOgrenci = dersekleogrencibox.SelectedItem.ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "SELECT DISTINCT tbl_dersler.ders_adi FROM tbl_dershoca " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "WHERE ogrenci <> @ogrNo";

                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("ogrNo", seciliOgrenci);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            derseklebox.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void derseklebox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ogretmenbox.Items.Clear();


            string seciliDers = derseklebox.SelectedItem.ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "SELECT DISTINCT tbl_hoca.hoca_ad, tbl_hoca.hoca_soyad FROM tbl_dershoca " +
                    "INNER JOIN tbl_hoca ON tbl_dershoca.hoca = tbl_hoca.hoca_sicilno " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "WHERE tbl_dersler.ders_adi = @dersAdi AND tbl_hoca.hoca_kontenjan > 0";

                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("dersAdi", seciliDers);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ogretmenbox.Items.Add(reader.GetString(0) + " " + reader.GetString(1));
                        }
                    }
                }
            }
        }
        private void dersSil()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "DELETE from tbl_dershoca where ders= @ders1 AND ogrenci = @ogr ";

                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("ders1", Convert.ToInt32(silmeislemidersbox.Text));
                    command.Parameters.AddWithValue("ogr", silmeislemiogrencibox.Text.ToString());
                    command.ExecuteNonQuery();
                    MessageBox.Show("SİLME İŞLEMİ BAŞARILI");


                }
            }

        }


        private void button12_Click(object sender, EventArgs e)
        {
            dersSil();
        }

        private void dersekleogrencibox_SelectedIndexChanged(object sender, EventArgs e)
        {
            derseklebox.Items.Clear();


            string seciliOgrenci = dersekleogrencibox.SelectedItem.ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "SELECT DISTINCT tbl_dersler.ders_adi FROM tbl_dershoca " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "WHERE ogrenci <> @ogrNo";

                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("ogrNo", seciliOgrenci);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            derseklebox.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void derseklebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogretmenbox.Items.Clear();


            string seciliDers = derseklebox.SelectedItem.ToString();
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; Port=5432; Database=YazLab1; User ID=postgres; Password=123;"))
            {
                connection.Open();
                string sorgu = "SELECT DISTINCT tbl_hoca.hoca_ad, tbl_hoca.hoca_soyad FROM tbl_dershoca " +
                    "INNER JOIN tbl_hoca ON tbl_dershoca.hoca = tbl_hoca.hoca_sicilno " +
                    "INNER JOIN tbl_dersler ON tbl_dershoca.ders = tbl_dersler.ders_id " +
                    "WHERE tbl_dersler.ders_adi = @dersAdi AND tbl_hoca.hoca_kontenjan > 0";

                using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                {
                    command.Parameters.AddWithValue("dersAdi", seciliDers);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ogretmenbox.Items.Add(reader.GetString(0) + " " + reader.GetString(1));
                        }
                    }
                }
            }
        }

        private void ogretmenbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
