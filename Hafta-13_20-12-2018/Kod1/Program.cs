using System;

namespace Kod1
{
    class MainClass
    {
        public delegate void MetodTemsilcisi();
        public static void Bilgisayar()
        {
            Console.WriteLine("Bilgisayar Mühendisliği");
        }
        public static void Elektronik()
        {
            Console.WriteLine("Elektronik Mühendisliği");
        }
        public static void Main(string[] args)
        {
            MetodTemsilcisi nesne = new MetodTemsilcisi(Bilgisayar);
            nesne();
            nesne = new MetodTemsilcisi(Elektronik);
            nesne();
        }
    }
}
