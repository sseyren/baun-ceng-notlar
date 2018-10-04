using System;

namespace Kod4
{
    class MainClass
    {
		class ManagedType
        {
            public int x;

            // Yapıcı bir metod tanımlandı.
            public ManagedType(int x)
            {
                this.x = x;
            }
        }
        unsafe public static void Main(string[] args)
        {
			ManagedType mt = new ManagedType(5);
            fixed (int* ptr1 = &(mt.x))
            {
                // x'in adresi bu blokta değişmez
                uint Adres = (uint)ptr1;

                Console.WriteLine("{0:X}", Adres);

                // Bu kod hata verir (adres değişmez): ptr1 += 2
                // Değeri ise güncelleyebiliriz
                *ptr1 += 2;

                Console.WriteLine("{0}", *ptr1);
            }
        }
    }
}
