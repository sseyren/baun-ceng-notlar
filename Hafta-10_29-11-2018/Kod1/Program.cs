using System;

namespace Kod1
{
    //Abstract özellikler
    //metot ve sınıflar ibi özlliklerde özet olarak bildirilebilir.
    abstract class A
    {
        abstract public int ozellik { set; get; }
    }
    class B : A
    {
        override public int ozellik
        {
            get { return 100; }
            set { Console.WriteLine("Bu bir Denemedir"); }
        }



        static void Main(string[] args)
        {
            B nesne = new B();
            Console.WriteLine(nesne.ozellik);
            nesne.ozellik = 250;
            Console.WriteLine(nesne.ozellik);
        }
    }
}
