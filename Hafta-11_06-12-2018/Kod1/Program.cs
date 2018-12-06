using System;

namespace Kod1
{
    interface CSharp
    {
        void Metod1();
    }
    class Sinif1 : CSharp
    {
        public void Metod1()
        {
            Console.WriteLine("Sinif1.Metod1()");
        }
    }
    class Sinif2 : CSharp
    {
        public void Metod1()
        {
            Console.WriteLine("Sinif2.Metod1()");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            CSharp a;
            Sinif1 s1 = new Sinif1();
            Sinif2 s2 = new Sinif2();
            a = s1;
            a.Metod1();
            s1.Metod1();
            a = s2;
            a.Metod1();
        }
    }
}
