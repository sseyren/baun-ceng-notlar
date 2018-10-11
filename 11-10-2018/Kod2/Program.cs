using System;

namespace Kod2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string a = "9:30'da bana 5 milyon getirdi.";
			for (int i = 0; i < a.Length; i++)
			{
				if (Char.IsDigit(a[i]))
					Console.Write(a[i]);
			}
			Console.WriteLine("\n");

			Console.Write("Yazıyı girin: ");
			string yazi = Console.ReadLine();
			string buyukYazi = "";
			for (int i = 0; i < yazi.Length; i++)
			{
				buyukYazi += Char.ToUpper(yazi[i]);
			}
			Console.WriteLine("Büyük yazı: " + buyukYazi);
		}
    }
}
