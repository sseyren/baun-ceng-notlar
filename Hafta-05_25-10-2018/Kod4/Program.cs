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

			FileStream fs = new FileStream(yol, FileMode.Append, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);
            
			while (true){
				string satır = Console.ReadLine();
				if (satır.ToLower() == "q") break;
				sw.WriteLine(satır);
			}

			sw.Flush(); 
            sw.Close();
        }
    }
}
