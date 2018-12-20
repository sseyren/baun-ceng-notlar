using System;

namespace Kod6
{
    class MainClass
    {
        delegate void temsilci();
        static void Metod1()
        {
            Console.WriteLine("Burası Metod1()");
        }
        static void Metod2()
        {
            Console.WriteLine("Burası Metod2()");
        }
        public static void Main(string[] args)
        {
            temsilci nesne = null;
            nesne += new temsilci(Metod1);
            nesne += new temsilci(Metod2);
            Delegate[] dizi = nesne.GetInvocationList();
            dizi[0].DynamicInvoke();
            dizi[1].DynamicInvoke();
            nesne -= new temsilci(Metod2);
            dizi = nesne.GetInvocationList();
            Console.WriteLine(" ----- ");
            Delegate nesne2 = Delegate.Combine(dizi);
            nesne2.DynamicInvoke();
            Console.WriteLine(" ----- ");
            Delegate nesne3 = Delegate.Combine(nesne, nesne2);
            nesne3.DynamicInvoke();
        }
    }
}
