using System;

namespace Kod2
{
    interface IArayuz
    {
        int Metod1();
        void Metod2();
        int Sayi { get; set; }
    }
    class Sınıf : IArayuz
    {
        // private int sayi;
        public int Metod1()
        {
            return 0;
        }
        public void Metod2()
        {
            Console.WriteLine("Metot 2");
        }
        public int Sayi
        {
            get { return Sayi; }
            set { Sayi = value; }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Sınıf s1 = new Sınıf();
            s1.Sayi = 80;
            Console.WriteLine(s1.Sayi);
            s1.Metod2();
        }
    }
}
