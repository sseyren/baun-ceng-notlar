using System;

namespace Kod5
{
    class MainClass
    {
        delegate void temsilci();
        static void Metod1()
        {
            Console.WriteLine("Metod1");
        }
        static void Metod2()
        {
            Console.WriteLine("Metod2");
        }
        public static void Main(string[] args)
        {
            temsilci t = new temsilci(Metod1);
            t += new temsilci(Metod2);
            t();
            Console.WriteLine(" ----- ");
            Delegate d = t;
            temsilci c = (temsilci)d; // tür dönüşümü yapılmakta
            c();
        }
    }
}