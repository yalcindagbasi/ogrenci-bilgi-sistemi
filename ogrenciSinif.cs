using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IronOcr;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Npgsql;
using SautinSoft;
using Spire.Pdf;
using static System.Net.Mime.MediaTypeNames;

namespace YazLab1
{
    

    public class ogrenciSinif

    {
        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port= 5432; Database = YazLab1; username = postgres; password = 123");
        public string ad = string.Empty;
        public string soyad = string.Empty;
        public string ogrenciNo = string.Empty;
        public static string pdfYolu;
        public string[] ilgiAlani;
        public int anlasmaSayisi;
        public bool anlasmaDurumu;
        public bool pdfDurumu;
        public int farkliHoca;
        public List<string> dersKodları = new List<string>();
        public  List<string> dersAdlari = new List<string>();
        public  List<string> harfNotlari = new List<string>();
        public  List <string> aktsNotlari =  new List<string>();

        public ogrenciSinif(string ogrenciNumarasi)
        {
            baglanti.Open();
            ogrenciNo = ogrenciNumarasi;
            anlasmaSayisi = 0;
                farkliHoca = 0;   
        }

        public  string pdfOku(string fileName)
        {
            PdfDocument pdfDocument = new PdfDocument();
            pdfDocument.LoadFromFile(fileName);

            StringBuilder text = new StringBuilder();

            foreach (PdfPageBase page in pdfDocument.Pages)
            {
                text.Append(page.ExtractText());
            }
            Console.WriteLine(text.ToString());
            pdfDocument.Close();

            return text.ToString();
        }
        public void dersOku(string filePdf)
        {
            string pattern = @"([A-Z]{3}\d{3})\s+(.+?)\s+[A-Z]+\s+\w+\s+\d+\s+\d+\s+\d+\s+(\d+)\s+([A-Z]{2})\s+\d+\s+\w";


            MatchCollection matches = Regex.Matches(filePdf, pattern);

            foreach (Match match in matches)
            {
                string dersKodu = match.Groups[1].Value.Trim();
                dersKodları.Add(dersKodu);
                string dersAdi = match.Groups[2].Value.Trim();
                dersAdlari.Add(dersAdi);
                string akts = match.Groups[3].Value;
                aktsNotlari.Add(akts);
                string harfNotu = match.Groups[4].Value;
                harfNotlari.Add(harfNotu);

                Console.WriteLine("Ders Kodu: " + dersKodu);
                Console.WriteLine("Ders Adı: " + dersAdi);
                Console.WriteLine("Not Türü: " + harfNotu);
                Console.WriteLine("Akts : " + akts);

            }
        }
        public string numaraAl(string text)
        {
            string numara;
            string noRegex = @"Öğrenci No \(Student ID\)\s*:\s*(\d{9})";
            Match match = Regex.Match(text, noRegex);

            if (match.Success)
            {
                numara = match.Groups[1].Value;
               // Console.WriteLine("Çekilen Numara: " + numara);
                return numara;
            }
            else
            {
                Console.WriteLine("Numara bulunamadı.");
            }
            return null;
        }
        public string soyadAl(string text)
        {
            string surname = string.Empty;
            string pattern = @"Soyadı \(Surname\)\s*:\s*(\w+)";
            Match match = Regex.Match(text, pattern);

            if (match.Success)
            {
                surname = match.Groups[1].Value;
               // Console.WriteLine("Çekilen Soyad: " + surname);
                return surname;
            }
            else
            {
                Console.WriteLine("Soyad bulunamadı.");
            }
            return null;
        }

        public string adAl(string text)
        {
            string name = string.Empty;
            string pattern = @"Adı \(Given Name\)\s*:\s*(\w+)";
            Match match = Regex.Match(text, pattern);

            if (match.Success)
            {
                name = match.Groups[1].Value;
              //  Console.WriteLine("Çekilen İsim: " + name);
                return name;
            }
            else
            {
                Console.WriteLine("İsim bulunamadı.");
            }
            return null;
        }

        
        }
   
}
