using System;
using System.IO;

namespace Kod1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Directory.CreateDirectory("C:/CSYeniKlasor");

			string[] klasorler = Directory.GetDirectories("C:/");
			foreach (string i in klasorler)
			{
				Console.WriteLine(i);
			}

			string mevcutKlasor = Environment.CurrentDirectory;
			Console.WriteLine(mevcutKlasor);

			DateTime dt = Directory.GetCreationTime(mevcutKlasor);
			Console.WriteLine(dt);
         
			string[] dizi = Directory.GetFileSystemEntries("C:/");
            foreach (string i in dizi)
                Console.WriteLine("{0} --> {1}", i, File.GetAttributes(i));
		}
    }
}
