using System;

namespace Kod2
{
    class MainClass
    {
        public delegate void KomutMetodu();
        public struct KomutYapisi
        {
            public KomutMetodu k_Metod;
            public string Komut;
        }
        public static void Dir()
        {
            Console.WriteLine("dir komutu çalıştı");
        }
        public static void Edit()
        {
            Console.WriteLine("edit komutu çalıştı");
        }
        public static void Copy()
        {
            Console.WriteLine("copy komutu çalıştı");
        }
        public static void Rename()
        {
            Console.WriteLine("rename komutu çalıştı");
        }
        public static void Main(string[] args)
        {
            KomutYapisi[] komutlar = new KomutYapisi[4];

            komutlar[0].Komut = "dir";
            komutlar[0].k_Metod = new KomutMetodu(Dir);

            komutlar[1].Komut = "edit";
            komutlar[1].k_Metod = new KomutMetodu(Edit);

            komutlar[2].Komut = "copy";
            komutlar[2].k_Metod = new KomutMetodu(Copy);

            komutlar[3].Komut = "rename";
            komutlar[3].k_Metod = new KomutMetodu(Rename);

            string GirilenKomut = null;

            while(GirilenKomut != "ç")
            {
                Console.Write("DOS :> ");
                GirilenKomut = Console.ReadLine();
                for (int i = 0; i < komutlar.Length; i++)
                {
                    if (GirilenKomut == komutlar[i].Komut)
                        komutlar[i].k_Metod();
                }
            }
        }
    }
}
