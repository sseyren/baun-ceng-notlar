using System;

namespace Kod6
{
    class MainClass
    {
		unsafe public static void Main(string[] args)
        {
            int[] a = { 2, 6, 4, 5 };

			// Dizi isimleri aslında ilk elemanın adresini temsil eder.
            // Bu nedenle `int* ptr1 = a` yazarken bir hata almadık. a dediğimiz
			// şey zaten bir adres :) .
            fixed (int* ptr1 = a, ptr2 = &a[0])
            {
				// Alttaki iki satırın çıktıları aynı olacaktır, çünkü aynı şeyler.
				Console.WriteLine((uint)ptr1);
                Console.WriteLine((uint)ptr2);

                // Alttaki üç satır da aynı şeyi ifade etmektedirler. Dizinin ilk elemanını.
                Console.WriteLine(a[0]);
                Console.WriteLine(*ptr1);
                Console.WriteLine(*ptr2);

                // Bunlar da dizinin ilk elemanı.
                Console.WriteLine(*(ptr1 + 1));
                Console.WriteLine(*(ptr2 + 1));
            }
        }
    }
}
