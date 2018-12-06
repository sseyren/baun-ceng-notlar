using System;

namespace Kod3
{
    interface IArayüz
    {
        int Metod1();
        void Metod2();
    }
    class Sınıf : IArayüz
    {
        int IArayüz.Metod1()
        {
            Console.WriteLine("Metod1");
            return 0;
        }
        public void Metod2()
        {
            Console.WriteLine("Metod2");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Sınıf s1 = new Sınıf();
            IArayüz a1;
            a1 = s1;
            a1.Metod1();
            s1.Metod2();
        }
    }
}
