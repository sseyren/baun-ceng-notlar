using System;

using Grafik3D;
using Grafik2D;

// using ile takma isim (alias) belirtmek.
// Aynı isimli sınıfların aynı metodları namespaceler ile ayrılabiliyor.
// Fakat her iki namespace'i de using ile ekledik. Sistem, Nokta sınıfına erişmek istediğimde
// hangisine erişmek istediğimi anlamayacaktır. Takma isimlerle (alias) bu sorunu çözebiliriz.

using Nokta3D=Grafik3D.Nokta;
using Nokta2D=Grafik2D.Nokta;

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
            Console.WriteLine("3D nokta?");
        }
    }
}

namespace Kod5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Nokta2D a = new Nokta2D();
			Nokta3D b = new Nokta3D();

            // Bu satır hata verecektir.
			//  Nokta asd = new Nokta();
        }
    }
}
