

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rextester
{
    public class Program
    {
        public static List<ogrenci> OgrenciArr = new List<ogrenci>();

        //public static List<notClass> notlar = new List<notClass>();
        public static void Main(string[] args)
        {

            var lsn = new Lisans();
            var ylsn = new YuksekLisans();
            var Doc = new Doktora();
            //lsn.LisansOgrenciGiris(6, "x", "y");
            lsn.LisansOgrenciGiris(1, "d", "a");
            ////x.LisansOgrenciGiris(7, "d", "a");
            ////x.LisansOgrenciGiris(7, "d", "a");
            ////x.LisansYazdır();
            ////ylsn.YlOgrenciGiris(1, "ahmet", "2", "2", "asd");
            ////ylsn.YLisansYazdır();
            //Doc.DOgrenciGiris(1, "Kaan keles", "bilgisayar bilimleri", "", "d", "asd", "asd");
            //Doc.DOgrenciGiris(7, "d", "a", "d", "d", "asd", "asd");
            //Doc.DLisansYazdır();
            ylsn.YlOgrenciGiris(1, "osman", "İşletme", "Bilişim"," Ege");
            ylsn.YLisansYazdır();
            Doc.DOgrenciGiris(1, "osman", "İşletme", "Bilişim", " Ege", "ingilizce", "Yeditepe");
            Doc.DLisansYazdır();
            lsn.LisansOgrenciGiris(2, "x", "y");
            lsn.LisansYazdır();
            lsn.notGiris(1, "bilgisayar", "2002", 5, 90);
            lsn.notGiris(1, "algoritma", "2003", 5, 80);
            Console.WriteLine(lsn.hesapla(1));



            Console.ReadKey();
        }
    }

    public class Heryerden
    {
        public static int globalSayac = 0;
    }
    public class notClass
    {
        public string dersKod { get; set; }
        public string dersAdı { get; set; }

        public int kredi { get; set; }
        public int basarınotu { get; set; }
    }
    public class ogrenci
    {
        public int no { get; set; }
        public string ad { get; set; }
        public string bolum { get; set; }
        public List<notClass> notlar { get; set; } = new List<notClass>();
        //public static List<notClass> notlar { get; set; }

        public string LBolum { get; set; }

        public string LOkul { get; set; }

        public string YlBolum { get; set; }

        public string YlOkul { get; set; } 
    }
    public class Lisans
    {

        public void LisansOgrenciGiris(int no, string isim, string bolum)
        {
            var newOgrenci = new ogrenci();
            newOgrenci.no = no;
            newOgrenci.ad = isim;
            newOgrenci.bolum = bolum;
            Program.OgrenciArr.Add(newOgrenci);
            Heryerden.globalSayac++;
        }
        public void LisansYazdır()
        {
            foreach (ogrenci item in Program.OgrenciArr)
            {
                Console.WriteLine("No: {0}\nAd Soyad: {1}\nBolum: {2}", item.no, item.ad, item.bolum);
            }
            Console.WriteLine("Sayac: {0}", Heryerden.globalSayac);

        }

        public void notGiris(int ogrNo, string dersadı, string dersKodu, int kredi, int Basarınotu)
        {
            int kontrol = 0;
            foreach (ogrenci item in Program.OgrenciArr)
            {
                if (item.no == ogrNo)
                {
                    var not = new notClass();
                    not.dersKod = dersKodu;
                    not.dersAdı = dersadı;
                    not.kredi = kredi;
                    not.basarınotu = Basarınotu;
                    item.notlar.Add(not);
                    kontrol++;
                }
               
            }
            if(kontrol == 0)
               Console.WriteLine("numara bulunamadı");
        }



        public int hesapla(int notuHesaplanacakOgrenciNo)
        {

            foreach (ogrenci item in Program.OgrenciArr)
            {
                if (item.no == notuHesaplanacakOgrenciNo)
                {
                    var toplamKredi = 0;
                    var toplamBasari = 0;

                    foreach (notClass not in item.notlar)
                    {
                        toplamKredi = toplamKredi + not.kredi;
                        toplamBasari = toplamBasari + (not.kredi * not.basarınotu);

                    }
                    var gdp = toplamBasari / toplamKredi;
                    Console.Write("Geçme Notu=");
                    return gdp;
                    
                }
                else
                {
                    Console.WriteLine("Ogrenci Numarasi Bulunamadi");
                    return 0;

                }
            }
            return 0;
        }

    }
    class YuksekLisans : Lisans
    {
        public void YlOgrenciGiris(int no, string isim, string bolum, string lbolum, string lokul)
        {

            var newOgrenci = new ogrenci();
            newOgrenci.no = no;
            newOgrenci.ad = isim;
            newOgrenci.bolum = bolum;
            newOgrenci.LBolum = lbolum;
            newOgrenci.LOkul = lokul;


            Program.OgrenciArr.Add(newOgrenci);
            Heryerden.globalSayac++;
        }
        public void YLisansYazdır()
        {
            foreach (ogrenci item in Program.OgrenciArr)
            {
                Console.WriteLine("No: {0}\nAd Soyad: {1}\nBolum: {2} \n Mezun Oldugu Lisans: {3}({4})", item.no, item.ad, item.bolum, item.LOkul, item.LBolum);
            }
            //Console.WriteLine("Sayac: {0}", Heryerden.globalSayac);

        }

    }
    class Doktora : YuksekLisans
    {
        public void DOgrenciGiris(int no, string isim, string bolum, string lbolum, string lokul, string YLbolum, string Ylokul)
        {

            var newOgrenci = new ogrenci();
            newOgrenci.no = no;
            newOgrenci.ad = isim;
            newOgrenci.bolum = bolum;
            newOgrenci.LBolum = lbolum;
            newOgrenci.LOkul = lokul;
            newOgrenci.YlOkul = Ylokul;
            newOgrenci.YlBolum = YLbolum;



            Program.OgrenciArr.Add(newOgrenci);
            Heryerden.globalSayac++;
        }
        public void DLisansYazdır()
        {
            foreach (ogrenci item in Program.OgrenciArr)
            {
                Console.WriteLine("No: {0}\nAd Soyad: {1}\nBolum: {2} \n Mezun Oldugu Lisans: {3}({4}) \n Mezun Oldugu yüksek Lisans: {5}({6})", item.no, item.ad, item.bolum, item.LOkul, item.LBolum, item.YlOkul, item.YlOkul);

            }
            //Console.WriteLine("Sayac: {0}", Heryerden.globalSayac);

        }

    }
}