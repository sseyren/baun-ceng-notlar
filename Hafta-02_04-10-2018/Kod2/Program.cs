using System;

// Namespace dışından bir namespace içindeki metoda/elemana ulaşmak için
// namespace adı belirtilir.

namespace isimAlani
{
    class Deneme
    {
        public int x;
        public int y;
        public Deneme(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static int Topla(int a, int b)
        {
            return a + b;
        }
    }
}

class AnaSınıf
{
	public static void Main(string[] args)
    {
        isimAlani.Deneme d = new isimAlani.Deneme(5, 6);
        Console.WriteLine(d.x);
        Console.WriteLine(isimAlani.Deneme.Topla(8, 11));
    }
}