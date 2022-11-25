using System.Collections.Immutable;

namespace SayisalLotoTahminleyici
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secim = "";

            do
            {
                MenuYaz();

                Console.Write("Seçiminiz : ");
                secim = Console.ReadLine();
                Console.Clear();

                switch (secim)
                {
                    case "1":

                        //Random random = new Random();
                        //random.Next(1, 50);

                        TahminleriUret(8);

                        break;

                    case "2":

                        Console.Write("Lütfen bölüm adedini belirtiniz : ");
                        int adet = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();

                        TahminleriUret(adet);
                        break;

                    default:
                        break;
                }

            } while (secim != "0");

            Console.WriteLine("Çıkış yapmak için bir tuşa basınız.");
            Console.ReadKey();

        }

        private static void TahminleriUret(int bolumSayisi)
        {
            for (int i = 0; i < bolumSayisi; i++)
            {
                int[] sayilar = RastgeleTahminUret(6);
                Array.Sort(sayilar);
                EkranaYaz(sayilar);

                Console.WriteLine();
            }

            Console.WriteLine();
            //Console.WriteLine(bolumSayisi + " adet tahmin üretilmiştir.");
            Console.WriteLine($"{bolumSayisi} adet tahmin üretilmiştir.");
            Console.ReadKey();
        }

        private static int[] RastgeleTahminUret(int adet)
        {
            int[] sayilar = new int[adet];

            for (int k = 0; k < adet; k++)
            {
                int sayi = Random.Shared.Next(1, 50);   // 12, 25, 36, 45, 48, ?

                while (Array.IndexOf(sayilar, sayi) > -1)
                {
                    sayi = Random.Shared.Next(1, 50);
                }

                sayilar[k] = sayi;
            }

            return sayilar;
        }

        private static void EkranaYaz(int[] sayilar)
        {
            //for (int j = 0; j < sayilar.Length; j++)
            //{
            //    if (j < 5) // j < sayilar.length-1
            //    {
            //        Console.Write(sayilar[j] + "-");
            //    }
            //    else
            //    {
            //        Console.Write(sayilar[j]);
            //    }
            //}

            string satir = string.Join('-', sayilar);
            Console.Write(satir);
        }

        private static void MenuYaz()
        {
            Console.Clear();

            Console.WriteLine("Menü");
            Console.WriteLine("====");
            Console.WriteLine();

            Console.WriteLine("[1] - 8 bölüm otomatik oyna");
            Console.WriteLine("[2] - Seçilen adette bölüm otomatik oyna");
            Console.WriteLine("[0] - Çıkış");
        }
    }
}