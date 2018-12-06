using System;

namespace Kod5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int index;
            int[] a = new int[5];

            try
            {
                Console.Write("Dizinin hangi indeksine veri girilecek: ");
                index = Convert.ToInt32(Console.ReadLine());
                a[index] = 50;
            }
            catch (IndexOutOfRangeException msj)
            {
                Console.WriteLine("Hata mesjaı: " + msj.Message);
            }
            catch
            {
                Console.WriteLine("İstisna oluştu");
            }
            finally
            {
                Console.WriteLine("Finally bloğu");
            }
        }
    }
}
