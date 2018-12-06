using System;

namespace Kod9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Console.Write("Lütfen çıkmak için 0 veya 1 girin: ");
                    int a = Int32.Parse(Console.ReadLine());
                    int[] dizi = new int[2];
                    Console.WriteLine(dizi[a]);
                    break;
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
