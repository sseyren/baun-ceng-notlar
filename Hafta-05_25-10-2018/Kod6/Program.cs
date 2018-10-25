using System;
using System.IO;

namespace Kod6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// Executable dosyaları <proje dizini>/bin/Debug dizininde olduğu varsayıldı.
			string dosyaYolu = @"../../veri.txt";

			StreamWriter sw = new StreamWriter(dosyaYolu);
			string dosyayaYaz = "Bu bir deneme cümlesidir.";
			sw.WriteLine(dosyayaYaz);
			sw.Flush();
			sw.Close();

			StreamReader sr = new StreamReader(dosyaYolu);
			string yazi = sr.ReadLine();
			Console.WriteLine(yazi);
			sr.Close();
        }
    }
}
