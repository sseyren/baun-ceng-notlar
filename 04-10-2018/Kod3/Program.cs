using System;
// Farklı dosyalarda bulunan aynı isimli namespaceleri bu şekilde kullanırız.

namespace Application
{
    public class Kod3_AnaSınıf
    {
		public static void Main(string[] args)
        {
            Csharp.Class1 d1 = new Csharp.Class1(5, 6);
            Console.WriteLine(d1.x);
            Csharp.Class2 d2 = new Csharp.Class2(9, 12);
            Console.WriteLine(d2.x);
        }
    }
}
