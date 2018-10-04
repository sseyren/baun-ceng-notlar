using System;

namespace Kod3
{
    class MainClass
    {
		unsafe public static void Main(string[] args)
        {
            int* ptr1 = (int*)500;
            char* ptr2 = (char*)500;
            double* ptr3 = (double*)500;
            byte* ptr4 = (byte*)500;
            int* ptr5 = (int*)500;
            char* ptr6 = (char*)500;

            // Pointer tipleriyle aritmetik yapabilmek tabii ki mümkün
            // fakat pointer hangi veri tipinin pointerıysa, tek seferde o veri
            // tipinin boyutu kadar artar.

			// Örneğin; buradaki ptr1 -2 azaltılmış, yani bu da
			// 2 int boyutu (4 bayt * 2 = 8 bayt) kadar gerisini yani 482'yi
			// işaret edeceğini gösterecektir. 2 int boyutu dememizin sebebi
			// onun bir int pointer'ı olmasıydı.

			// Başka bir örnek: char, bellekte 2 byte yer kaplar. Bu örnekte
            // ptr2 5 arttırılmış, bu da demek oluyor ki pointer 2 byte * 5
			// = 10 byte ileriyi yani 510'u işaret edecek.

            ptr1 -= 2;
            ptr2 += 5;
            ptr3 += 2;
            ptr4 += 6;
			ptr6 += 1;

            Console.WriteLine((uint)ptr1);
            Console.WriteLine((uint)ptr2);
            Console.WriteLine((uint)ptr3);
            Console.WriteLine((uint)ptr4);
			Console.WriteLine((uint)ptr5);
            Console.WriteLine((uint)ptr6);
        }
    }
}
