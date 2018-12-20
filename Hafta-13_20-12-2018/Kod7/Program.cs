using System;

namespace Kod7
{
    class MainClass
    {
        public delegate double temsilci(double a, double b);
        public static void Main(string[] args)
        {
            // temsilci nesnesine bir kod bloğu bağlanıyor.
            temsilci t = delegate (double pi, double r) {
                return pi * Math.Pow(r, 2);
            };
            // temsilci nesnesi ile kodlar çalıştırılıyor.
            double alan = t(Math.PI, 6);
            Console.WriteLine(alan);
            // Bir temsilci nesnesine bit metod yerine doğrudan kodlar atandı.
        }
    }
}
