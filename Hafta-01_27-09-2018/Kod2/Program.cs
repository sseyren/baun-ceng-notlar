using System;

namespace Kod2
{
    class MainClass
    {
		// unsafe sözcüğünü metodların önüne de ekleyebiliriz
		unsafe public static void Main(string[] args)
        {
            char a = 'A';
            int b = 10;

            char* ptr1 = &a;
            int* ptr2 = &b;

			uint[] uintAdres = { (uint)ptr1, (uint)ptr2 };
			long[] longAdres = { (long)ptr1, (long)ptr2 };

			Console.WriteLine("a'nın adresi: {0:X} {1:X}", uintAdres[0], longAdres[0]);
			Console.WriteLine("b'nin adresi: {0:X} {1:X}", uintAdres[1], longAdres[1]);
        }
    }
}
