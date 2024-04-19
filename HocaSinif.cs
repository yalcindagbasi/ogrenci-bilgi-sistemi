using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab1
{
    public class HocaSinif
    {
        public string ad;
        public string soyad;
        public int kontenjan;
        public int sicil;
        List<HocaSinif> hocalar = new List<HocaSinif>();
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123");
        public static int satirSayisi;
        public HocaSinif(int no) {
            this.kontenjan = 50;
            sicil = no;
        }
    public static int satirAl()
        {
            int rowCount;
            string connect = "server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123";
            using (NpgsqlConnection connection = new NpgsqlConnection(connect))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"SELECT COUNT(*) FROM tbl_hoca", connection))
                {
                    rowCount = (int)command.ExecuteScalar();
                    Console.WriteLine($"Toplam satır sayısı: {rowCount}");
                }
            }
            return rowCount;
            
        }

        public static void verileriAl()
        {
            int satirSayisi = satirAl();
            string connString = "server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123";
            string tableName = "tbl_hoca";
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                string query = $"SELECT * FROM tbl_hoca";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    
                        // Verileri satır satır işleme
                        int id = reader.GetInt32(0);
                        string isim = reader.GetString(1);
                        // Diğer sütunları işleyebilirsiniz

                        Console.WriteLine($"ID: {id}, İsim: {isim}");
                   
                }
            }





        }


    
    }
}
