using System;

namespace Kod3
{
    class MainClass
    {
        public delegate void MetodTemsilcisi();
        public static void Metod1()
        {
            Console.WriteLine("Metod-1");
        }
        public static void Metod2()
        {
            Console.WriteLine("Metod-2");
        }

        // Bir metodun parametresi temsilci türünden olabilir.
        public static void Metod3(MetodTemsilcisi mt)
        {
            mt();
        }
        public static void Main(string[] args)
        {
            MetodTemsilcisi temsilci = new MetodTemsilcisi(Metod1);
            temsilci();
            Metod3(temsilci);
            Console.WriteLine();
            temsilci = new MetodTemsilcisi(Metod2);
            Metod3(temsilci);
        }
    }
}
