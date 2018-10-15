using System;

namespace Kod7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			DateTime geçici;
			DateTime tarih1 = new DateTime(2001, 5, 2);
			DateTime tarih2 = new DateTime(2003, 9, 5);

			TimeSpan fark = tarih2 - tarih1;
			
			long haftaSonu = 0;
			for (int i = 0; i < fark.Days; i++)
			{
				geçici = tarih1.AddDays(i);
				if (geçici.DayOfWeek == DayOfWeek.Sunday || geçici.DayOfWeek == DayOfWeek.Saturday)
					haftaSonu++;
			}

			Console.WriteLine("Haftasonu olan gün sayısı: {0}", haftaSonu);
		}
    }
}
