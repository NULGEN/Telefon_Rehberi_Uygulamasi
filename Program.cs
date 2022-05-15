using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE_1__Telefon_Rehberi_Uygulaması
{
    internal class Program
    {
        static List<Rehber> rehbers = new List<Rehber>();
        static void Main(string[] args)
        {
            Uygulama();
        }

        static void Uygulama()
        {
            DummyVeri();
            Menu();

            while (true)
            {
                int giris = SecimAl();
                Console.WriteLine();

                switch (giris)
                {
                    case 1:
                        NumaraKaydet();
                        break;
                    case 2:
                        NumaraSil();
                        break;
                    case 3:
                        NumaraGuncelle();
                        break;
                    case 4:
                        RehberiListele();
                        break;
                    case 5:
                        RehberdeAra();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

            }

        }
        public static void NumaraKaydet()
        {
            Rehber r = new Rehber();
            Console.WriteLine(" Yeni Numara Kaydet ");
            Console.WriteLine();
            Console.Write("Lütfen isim giriniz       :");
            r.Isim = IlkHarfiBuyut(Console.ReadLine());
            Console.Write("Lütfen soyisim giriniz    :");
            r.Soyisim = IlkHarfiBuyut(Console.ReadLine());
            Console.Write("Lütfen telefon numarası giriniz    :");
            r.TelNo = int.Parse(Console.ReadLine());

            rehbers.Add(r);
            Console.WriteLine("Kayıt başarılı şekilde gerçekleşti..");

        }

        public static void NumaraSil()
        {
            Console.WriteLine();
            Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz :  ");
            string giris = IlkHarfiBuyut(Console.ReadLine());
            İsimBul(giris);
            
            Rehber rbr = null;

            foreach (var item in rehbers)
            {
                if (giris == item.Isim || giris == item.Soyisim)
                {
                    rbr = item;
                    break;
                }
            }

            if (rbr != null)
            {
                Console.WriteLine(rbr.Isim + " " + rbr.Soyisim + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                string onay = Console.ReadLine().ToLower();
                if (onay == "y")
                {
                    rehbers.Remove(rbr);
                    Console.WriteLine("Kişi başarılı şekilde silindi");
                    return;
                }
                return;
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için        : (2)");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        break;
                    case 2:
                        NumaraSil();
                        break;

                }

            }

        }
        public static void NumaraGuncelle()
        {
            Console.WriteLine();

            Console.Write ("Lütfen numarasını guncellemek istediğiniz kişinin adını ya da soyadını giriniz : ");
            string txt = IlkHarfiBuyut(Console.ReadLine());
            İsimBul(txt);

            Rehber rbr = null;

            foreach (var item in rehbers)
            {
                if (item.Isim == txt || item.Soyisim == txt)
                {
                    rbr = item;
                    break;
                }
            }
            if (rbr != null)
            {
                Console.Write("Lütfen yeni numarayı giriniz: ");
                int yeniNo = int.Parse(Console.ReadLine());
                rbr.TelNo = yeniNo;
                
                Console.WriteLine("Güncelleme başarılı şekilde tamamlandı.");
            }
            else
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Güncellemeyi sonlandırmak için    : (1)");
                Console.WriteLine(" * Yeniden denemek için              : (2)");
                int sayi = int.Parse(Console.ReadLine());
                switch (sayi)
                {
                    case 1:
                        break;
                    case 2:
                        NumaraGuncelle();
                        break;
                }

            }

        }
        public static void RehberiListele()
        {
            Console.WriteLine();
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");
            Console.WriteLine();

            RehberiYazdır();
        }
        public static void RehberdeAra()
        {
            Console.WriteLine();
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine(" **********************************************");
            Console.WriteLine();

            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            int sayi = int.Parse(Console.ReadLine());

            Console.WriteLine();
                       
            if (sayi == 1)
            {
                RehberYazdirmaİsmeGore();
            }                    
            else if (sayi == 2)
            {
                RehberYazdirmaNumarayaGore();
            }

        }
        public static void RehberYazdirmaİsmeGore()
        {
            Console.Write("İsim veya soyisim giriniz: ");
            string giris = IlkHarfiBuyut(Console.ReadLine());
            İsimBul(giris);
            string isim = null;
            string soyisim = null;
            int no = 0;
            foreach (var item in rehbers)
            {
                if (item.Isim == giris || item.Soyisim == giris)
                {
                    isim = item.Isim;
                    soyisim = item.Soyisim;
                    no = item.TelNo;
                }

            }
            
            Console.WriteLine();
            Console.WriteLine(" Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");
            
            Console.WriteLine("isim: " + isim);
            Console.WriteLine("Soyisim: " + soyisim);
            Console.WriteLine("Telefon Numarası: " + no);
            Console.WriteLine(" - ");

        }

        public static void RehberYazdirmaNumarayaGore()
        {
            Console.Write("Telefon numarası giriniz: ");
            int no = int.Parse(Console.ReadLine());
            NumaraBul(no);
            string isim = null;
            string soyisim = null;
            int numara = 0;
            foreach (var item in rehbers)
            {
                if (item.TelNo == no)
                {
                    isim = item.Isim;
                    soyisim = item.Soyisim;
                    numara = item.TelNo;
                }

            }

            Console.WriteLine();
            Console.WriteLine(" Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");

            Console.WriteLine("isim: " + isim);
            Console.WriteLine("Soyisim: " + soyisim);
            Console.WriteLine("Telefon Numarası: " + numara);
            Console.WriteLine(" - ");
        }
        public static void RehberiYazdır()
        {
            foreach (var item in rehbers)
            {
                Console.WriteLine("isim: " + item.Isim);
                Console.WriteLine("Soyisim: " + item.Soyisim);
                Console.WriteLine("Telefon Numarası: " + item.TelNo);
                Console.WriteLine(" - ");
            }
        }

        public static Rehber İsimBul( string giris)
        {           

            return rehbers.Where(t => t.Isim == giris || t.Soyisim==giris).FirstOrDefault();
        }
        public static Rehber NumaraBul(int no)
        {           
            no = int.Parse(Console.ReadLine());

            return rehbers.Where(t => t.TelNo == no).FirstOrDefault();
        }



        

       


        

        static void Menu()
        {
            Console.WriteLine(" Lütfen yapmak istediğiniz işlemi seçiniz  :) ");
            Console.WriteLine("********************************************* ");
            Console.WriteLine();
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine();

        }

        static int SecimAl()
        {
            Console.WriteLine();
            Console.Write("Seçiminiz: ");
            int secim = int.Parse(Console.ReadLine());

            return secim;
        }

        static void DummyVeri()
        {
            Rehber r1 = new Rehber("Ali", "Yılmaz", 533875);
            Rehber r2 = new Rehber("Ayşe", "Atılgan", 534975);
            Rehber r3 = new Rehber("Mehmet", "Korkmaz", 554444);
            Rehber r4 = new Rehber("Nejat", "Ulu", 777788);
            Rehber r5 = new Rehber("Selim", "Sert", 995522);
            rehbers.Add(r1);
            rehbers.Add(r2);
            rehbers.Add(r3);
            rehbers.Add(r4);
            rehbers.Add(r5);

        }
        static string IlkHarfiBuyut(string veri)
        {
            return veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
        }

    }
}
