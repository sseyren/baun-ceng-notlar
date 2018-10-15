using System;

namespace Kod6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int günSayısı;
			Console.Write("Gün sayısı: ");
			günSayısı = Convert.ToInt32(Console.ReadLine());

			TimeSpan fark = new TimeSpan(günSayısı, 0, 0, 0);
			DateTime dt = DateTime.Today + fark;

			Console.WriteLine(dt.DayOfWeek);
        }
    }
}
