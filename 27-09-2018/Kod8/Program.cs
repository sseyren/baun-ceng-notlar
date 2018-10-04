using System;

namespace Kod8
{
    class MainClass
    {
		unsafe static public void Main(string[] args)
        {
			// Stack alanından `int[10]` kadar yer alıyoruz.
            int* dizi = stackalloc int[10];

            // Bu dizinin içine `i*2` leri dolduruyoruz.
            for (int i = 0; i < 10; i++)
                *(dizi + i) = i * 2;

            // Dizinin tüm elemanlarını ekrana basıyoruz.
			for (int i = 0; i < 10; i++)
				Console.Write("{0} ", *(dizi + i));

			// `\n` `new line` yani satır atlama karakteridir. (0x0a)
			Console.WriteLine("\n");

			// Burada ise dizinin bulunduğu yerden `i*4` sonraki konumda
            // bulunan değeri ekrana basıyoruz. Farklı ve anlamsız veriler
            // görmek mümkün.
            for (int i = 0; i < 10; i++)
                Console.WriteLine(*(dizi + (i * 4)));

			Console.WriteLine();

			// Bu satırda ise `dizi` konumundan 8 sonraki int'in değeri getiriliyor.
            Console.WriteLine(*(dizi + 8));

            // Bu satırda ise `dizi` konumundaki değerin 8 fazlası getiriliyor.
            Console.WriteLine((*dizi + 8));

            // Bu satırda ise `dizi` konumundan 1 sonraki int'in 8 fazlası getiriliyor.
            Console.WriteLine(*(dizi + 1) + 8);
        }
    }
}
