using System;
using nesne;

namespace Kod7Main
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RastgeleSayi r = new RastgeleSayi();

			//   `using nesne;` olmadan da bu sınıfa ulaşabiliriz:
			// nesne.RastgeleSayi r = new nesne.RastgeleSayi();

			Console.WriteLine(r.Sayi);

			r.Değiştir();
			Console.WriteLine(r.Sayi);         
        }
    }
}
