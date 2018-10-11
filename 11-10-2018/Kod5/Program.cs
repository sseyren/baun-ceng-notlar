using System;

namespace Kod5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int yıl, ay, gün;
			Console.Write("Doğum yılınız: ");
			yıl = Convert.ToInt32(Console.ReadLine());

			Console.Write("Doğum ayınız: ");
			ay = Convert.ToInt32(Console.ReadLine());

			Console.Write("Doğum gününüz: ");
			gün = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();

			DateTime bugün = DateTime.Today;
			DateTime doğumTarihi = new DateTime(yıl, ay, gün);

			TimeSpan fark = bugün - doğumTarihi;

			Console.WriteLine("Doğduğunuz gün: {0}", doğumTarihi.DayOfWeek);
			Console.WriteLine("Geçen gün sayısı: {0}", fark.Days);
        }
    }
}
