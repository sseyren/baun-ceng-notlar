using System;

namespace Kod8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] dizi = new int[6];
            Random rnd = new Random();
            int sayi;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    sayi = rnd.Next(10);
                    dizi[sayi] = i;
                    Console.WriteLine("dizi[{0}] = {1}", sayi, i);
                }
                catch (IndexOutOfRangeException excp)
                {
                    Console.WriteLine(excp.Message);
                }
            }
        }
    }
}
