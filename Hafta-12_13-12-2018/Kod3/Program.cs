using System;

namespace Kod3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int i; string str;
            try
            {
                Console.Write("1-100 arası bir sayı giriniz: ");
                str = Console.ReadLine();
                i = Int32.Parse(str);
                if (i > 100 || i < 1)
                {
                    // Bu iki satırın sıraları önem arz etmekte.
                    throw new Exception();
                    throw new OverflowException("Yanlış değer girildi.");
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Belirlenemeyen bir istisna oluştu.");
            }
        }
    }
}
