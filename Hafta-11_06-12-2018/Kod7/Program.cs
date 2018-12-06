using System;

namespace Kod7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Metot1();
            }
            catch(IndexOutOfRangeException excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
        public static void Metot1()
        {
            try
            {
                int index;
                int[] a = new int[5];
                Console.Write("Kaçıncı indise değer atansın?: ");
                index = Convert.ToInt32(Console.ReadLine());
                a[index] = 500;
                Console.WriteLine("a[{0}]={1}", index, a[index]);
            }
            catch
            {
                Console.WriteLine("Metot gövdesi");
            }
        }
    }
}
