using System;

namespace Kod1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			unsafe
            {
				// bir double ifade tanımlandı
                double a = 5;
				// "double işaretçisi (pointerı)" tipinde ptr1 tanımlandı
                double* ptr1;
				// a'nın bellekteki adresi ptr1'e atandı
                ptr1 = &a;
				// ptr1'in olduğu yerdeki ifadenin (yani a'nın) değeri 10 yapıldı.
                *ptr1 = 10;
                Console.WriteLine(a);

                char c = 'A';
                char* ptr2;
                ptr2 = &c;
                *ptr2 = 'S';
                Console.WriteLine(c);
                Console.WriteLine(*ptr2);
                Console.WriteLine();

                char d = 'A';
                int i = 80;
                char* ptr3 = &d;
                int* ptr4 = &i;
                ptr3 = (char*)ptr4;
                Console.WriteLine(*ptr3);
                Console.WriteLine((int)*ptr3);

            }
        }
    }
}
