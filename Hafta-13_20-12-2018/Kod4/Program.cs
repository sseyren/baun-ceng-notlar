using System;

namespace Kod4
{
    class MainClass
    {
        public delegate void MetodTemsilcisi(int a, int b);
        public static void Toplama(int a, int b)
        {
            Console.WriteLine("{0}+{1} = {2}", a, b, a + b);
        }
        public static void Çıkarma(int a, int b)
        {
            Console.WriteLine("{0}-{1} = {2}", a, b, a - b);
        }
        public static void Çarpma(int a, int b)
        {
            Console.WriteLine("{0}*{1} = {2}", a, b, a * b);
        }
        public static void Bölme(int a, int b)
        {
            Console.WriteLine("{0}/{1} = {2}", a, b, a / b);
        }
        public static void Main(string[] args)
        {
            MetodTemsilcisi temsilcisi = null;
            temsilcisi += new MetodTemsilcisi(Toplama);
            temsilcisi += new MetodTemsilcisi(Çıkarma);
            temsilcisi += new MetodTemsilcisi(Çarpma);
            temsilcisi(5, 3);
            Console.WriteLine("\n ----- \n");
            temsilcisi -= new MetodTemsilcisi(Çıkarma);
            temsilcisi(9, 4);
            /* GetInvocationList(): Bu metod ile çoklu temsilci yapısında
             * bulunan bütün metodlar System.Delegate türünden bir diziye
             * aktarılır.
             * 
             * DynamicInvoke(): Bir temsilcinin temsil ettiği metodu çağırmak
             * için kullanılır. Özellikkle GetInvocationList() metodu ile çoklu
             * bir temsilcinin metodları Delegate dizisine aktarıldığı zaman
             * her bir metodu ayrı ayrı çağırmak için DynamicInvoke() metodu
             * kullanılabilir.
             */
            Console.WriteLine("\n ----- \n");
            Delegate[] t = temsilcisi.GetInvocationList();
            object[] parametreler = { 12, 20 };
            t[0].DynamicInvoke(parametreler);
            t[1].DynamicInvoke(parametreler);
            t[1].DynamicInvoke(8, 14);
        }
    }
}
