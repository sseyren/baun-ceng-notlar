using System;

// Farklı bir namespace örneği.
// using anahtar sözcüğüyle kendi oluşturduğumuz namespacelere doğrudan ulaşabiliriz.

using Grafik3D;

// Böylece sınıf içerisinden bir nesneye erişmek istersek namespace'i yazmamıza gerek kalmamış olur.

namespace Grafik3D
{
    public class Nokta
    {
        public Nokta()
        {
            Console.WriteLine("3D nokta?");
        }
    }
}
namespace Grafik2D
{
    public class Nokta
    {
        public Nokta()
        {
            Console.WriteLine("2D nokta?");
        }
    }
}

namespace Application
{
    class AnaSınıf
    {
		public static void Main(string[] args)
        {
            Grafik2D.Nokta a = new Grafik2D.Nokta();

            // using ile namespace belirttiğimiz için doğrudan eriştik.
            Nokta b = new Nokta();

            // using ile namespace belirtmemiş olsaydık bu şekilde erişebilirdik:
            //  Grafik3D.Nokta b = new Grafik3D.Nokta();
        }
    }
}