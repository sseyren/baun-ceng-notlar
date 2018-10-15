using System;

namespace Kod7
{
    class MainClass
    {
		unsafe public static void Main(string[] args)
        {
			// Bu sefer `int[10]` dizisini doğrudan tanımlamak yerine programlama
            // dilinin bize ayıracağı alanı biz kendimiz alıyoruz. Bunu da
            // 'stackalloc` ile yapabiliyoruz. Stack alanından bize `int[10]`
            // kadar yer ayırıyor.

            int* dizi = stackalloc int[10];

            for (int i = 0; i < 10; i++)
            {
				// Bu aldığımız dizinin içine i*i leri dolduruyoruz.
				dizi[i] = i * i;

				// Üstteki satır yerine bunu da kullanabilirdik:
				//  (diziden sonra i kadar git ve oraya i*i değerini koy)
				// *(dizi + i) = i * i;  

                // `dizi` işaretçisinden i kadar ileri gidip o noktadaki
                // elemanın değerini ekrana gönderiyoruz.
                Console.WriteLine("*(dizi+{0}) = {1}", i, dizi[i]);
            }
        }
    }
}
