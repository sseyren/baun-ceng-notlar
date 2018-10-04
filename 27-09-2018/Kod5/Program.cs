using System;

namespace Kod5
{
    class MainClass
    {
		unsafe public static void Main(string[] args)
        {
            int[] dizi = new int[4];
            int[] a = { 2, 4, 7, 3 };

            // Dizinin ilk elemanının bulunduğu yeri ptr olarak aldık.
            fixed (int* ptr = &a[0])
            {
				// Dizinin elemanlarını ekrana dökerken pointerları kullanabiliriz.
				// Şu şekilde yapmak mümkün örneğin:
                for (int i = 0; i < a.Length; i++)
                    Console.WriteLine(*(ptr + i));

                Console.WriteLine();

				// Pointer'a bir dizi gibi yaklaşmak da mümkün:
				for (int i = 0; i < a.Length; i++)
					Console.Write(ptr[i] + " ");
				
                Console.WriteLine("\n");

				// Aşağıdaki kullanım da olabilir, adres içeriğini bir nesneye doğrudan atabiliriz.
                for (int i = 0; i < a.Length; i++)
                {
                    dizi[i] = *(ptr + i);
                    Console.WriteLine(dizi[i] + " ");
                }
            }
        }
    }
}
