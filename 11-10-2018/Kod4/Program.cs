using System;

namespace Kod4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Console.WriteLine(DateTime.MaxValue);
			Console.WriteLine(DateTime.MinValue);
			Console.WriteLine(DateTime.Now);
			Console.WriteLine(DateTime.Today + "\n");

			DateTime bugün = new DateTime();
			bugün = DateTime.Now;
			Console.WriteLine(bugün.Date);
			Console.WriteLine(bugün.Day);
			Console.WriteLine(bugün.Month);
			Console.WriteLine(bugün.Year);
			Console.WriteLine(bugün.DayOfYear);
			Console.WriteLine(bugün.DayOfWeek);
			Console.WriteLine(bugün.TimeOfDay);
			Console.WriteLine(bugün.Hour);
			Console.WriteLine(bugün.Minute);
			Console.WriteLine(bugün.Second);
			Console.WriteLine(bugün.Millisecond);
			Console.WriteLine(bugün.Ticks);
        }
    }
}
