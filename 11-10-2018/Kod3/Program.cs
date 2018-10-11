using System;

namespace Kod3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// Decimal 128 bit ile ifade edilir.
			// 96 biti sayının tamsayı kısmını, diğer kısım ondalık kısmı belirler.
			// Aşağıdaki metoda birinci parametre 96 bitlik sayının ilk 32 biti,
			// ikinci parametre ortadaki 32 biti,
			// üçüncü parametre son 32 biti temsil eder.
			// Dördüncü parametre false ise sayı pozitif, true ise negatiftir.
			// Son parametre virgülden sonra kaç hane yazılacağını gösterir.

			Decimal d1 = new Decimal(986574, 0, 0, false, 3);
			Console.WriteLine(d1);

			Decimal d2 = new Decimal(986574, 1, 1, false, 2);
			Console.WriteLine(d2);
        }
    }
}
