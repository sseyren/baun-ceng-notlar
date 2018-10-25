using System;
using System.IO;

namespace Kod3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// Executable dosyaları <proje dizini>/bin/Debug dizininde olduğu varsayıldı.
			string yol = @"../../dosya.txt";

			FileStream fs = new FileStream(yol, FileMode.Open);
			StreamReader sr = new StreamReader(fs);

			string satır;
			while ((satır = sr.ReadLine()) != null)
				Console.WriteLine(satır);

			fs.Close();
        }
    }
}
