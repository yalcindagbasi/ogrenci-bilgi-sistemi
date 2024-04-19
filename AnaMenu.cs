using Npgsql;

namespace YazLab1
{
    public partial class AnaMenu : Form
    {
        private ogrenciEkran ogr = null;
        private string ogrenciKimligi;
        private Dictionary<string, ogrenciEkran> ogrenciEkranlar = new Dictionary<string, ogrenciEkran>();



        public AnaMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public int girisKontrol(out string ogrenciNumarasi)
        {
            string connString = "server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123";

            string ogrenciNo = ogrencýID.Text;
            string ogrencipass = ogrencýSifre.Text;

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                string query = "SELECT ogr_sifre FROM ogrencikullanici WHERE ogrenci_no = @ogrenci_no";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("ogrenci_no", ogrenciNo);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string veritabaniSifre = reader.GetString(0);
                            if (veritabaniSifre == ogrencipass)
                            {
                                Console.WriteLine("Giriþ baþarýlý.");
                                string kullaniciKimligi = ogrenciNo;
                                KullaniciOturumAc(kullaniciKimligi);
                                string kullaniciKlasorYolu = Path.Combine("Kullanicilar", kullaniciKimligi);
                                if (!Directory.Exists(kullaniciKlasorYolu))
                                {
                                    Directory.CreateDirectory(kullaniciKlasorYolu);
                                }
                                else
                                {
                                    // Kullanýcýnýn önceki oturum verilerini temizleyin
                                    TemizleKlasorIcerigi(kullaniciKlasorYolu);
                                }
                                ogrenciNumarasi = ogrenciNo;
                                return 1;
                            }
                            else
                            {
                                Console.WriteLine("Þifre yanlýþ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Öðrenci numarasý bulunamadý.");
                        }
                    }
                }
            }
            ogrenciNumarasi = ogrenciNo;
            return -1;
        }

        private void TemizleKlasorIcerigi(string klasorYolu)
        {
            DirectoryInfo klasor = new DirectoryInfo(klasorYolu);
            foreach (FileInfo dosya in klasor.GetFiles())
            {
                dosya.Delete();
            }

        }
        private void ogrenciGirisYap_Click(object sender, EventArgs e)
        {
            string ogrenciNumarasi;
            int p = girisKontrol(out ogrenciNumarasi);
            if (p == 1)
            {
                // Kullanýcý oturumu açýldýðýnda oturum kimliði (örneðin, öðrenci numarasý) oluþturun
                string ogrenciKimligi = ogrencýID.Text;
                // Eðer bu kimlikle daha önce bir form oluþturulmadýysa, yeni bir form oluþturun
                if (!ogrenciEkranlar.ContainsKey(ogrenciKimligi))
                {
                    ogrenciEkran ekran = new ogrenciEkran(new ogrenciSinif(ogrenciNumarasi), ogrenciKimligi);
                    ekran.ShowDialog();
                }

                // Oluþturulan formu gösterin
                
            }
        }


        private void KullaniciOturumAc(string kullaniciKimligi)
        {
            ogrenciKimligi = kullaniciKimligi;
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void yöneticipass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiEkran yonetici = new YoneticiEkran();
            yonetici.ShowDialog();

        }
        private int hocaGirisKontrol()
        {
            string connString = "server = localHost; port= 5432; Database = YazLab1; user ID = postgres; password = 123";

            string hocaNumara = hocaId.Text;
            string hocaPass = hocaSifre.Text;

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                string query = "SELECT hoca_sifre FROM tbl_hocakullanici WHERE hoca_no = @hoca_no";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("hoca_no", hocaNumara);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string veritabaniSifre = reader.GetString(0);
                            if (veritabaniSifre == hocaPass)
                            {
                                Console.WriteLine("Giriþ baþarýlý.");
                                string kullaniciKimligi = hocaNumara;
                                KullaniciOturumAc(kullaniciKimligi);
                                string kullaniciKlasorYolu = Path.Combine("Kullanicilar", kullaniciKimligi);
                                if (!Directory.Exists(kullaniciKlasorYolu))
                                {
                                    Directory.CreateDirectory(kullaniciKlasorYolu);
                                }
                                else
                                {
                                    // Kullanýcýnýn önceki oturum verilerini temizleyin
                                    TemizleKlasorIcerigi(kullaniciKlasorYolu);
                                }
                                return Convert.ToInt32(hocaNumara);
                               
                            }
                            else
                            {
                                Console.WriteLine("Þifre yanlýþ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Öðrenci numarasý bulunamadý.");
                        }
                    }
                }
            }
            return -1;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int kontrol = hocaGirisKontrol();
            if(kontrol != -1 )
            {
                HocaEkran hocaEkran = new HocaEkran(new HocaSinif(kontrol));
               hocaEkran.ShowDialog();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
