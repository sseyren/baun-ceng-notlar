using System;

namespace Kod6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int a = 10, b = 0, c;
            try
            {
                c = a / b;
            }
            catch(IndexOutOfRangeException msj)
            {
                Console.WriteLine("Hata mesajı: " + msj.Message);
            }
            catch(DivideByZeroException msj)
            {
                Console.WriteLine("Hata mesajı: " + msj.Message);
            }
            catch
            {
                Console.WriteLine("Bir hata var uzakta, o bizim hatamızdır.");
            }
        }
    }
}
