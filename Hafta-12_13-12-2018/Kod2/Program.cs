using System;

namespace Kod2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                int a = 50, b;
                Console.Write("Bölen değeri giriniz: ");
                b = Convert.ToInt32(Console.ReadLine());
                if (b == 0)
                    throw new DivideByZeroException("Sıfıra bölünme hatası yakalandı.");
                Console.WriteLine("Sonuç = {0}", a / b);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message + "\n");
                Console.WriteLine(e.Source + "\n");
                Console.WriteLine(e.TargetSite + "\n");
                Console.WriteLine(e.ToString() + "\n");
                Console.WriteLine("StackTrace: {0}\n", e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Program sonlandı.");
            }
        }
    }
}
