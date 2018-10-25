using System;
using System.IO;

namespace Kod1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// Executable dosyaları <proje dizini>/bin/Debug dizininde olduğu varsayıldı.
			string yol = @"../../Program.cs";

			FileStream fs = new FileStream(yol, FileMode.Open);

			int okunanByte;
			while ((okunanByte = fs.ReadByte()) != -1)
				Console.Write((char)okunanByte);
		}
    }
}
