using System;
using System.IO;

namespace Kod5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			int i = 5;
			decimal d = 15.54M;
			char c = 'A';
                
			// Executable dosyaları <proje dizini>/bin/Debug dizininde olduğu varsayıldı.
			string dosya = @"../../dosya.txt";

			FileStream fs1 = new FileStream(dosya, FileMode.OpenOrCreate);
			BinaryWriter bw = new BinaryWriter(fs1);

			bw.Write(i);
			bw.Write(d);
			bw.Write(c);
			bw.Close();

			FileStream fs2 = new FileStream(dosya, FileMode.Open);
			BinaryReader br = new BinaryReader(fs2);
         
			Console.WriteLine(br.ReadInt32());
			Console.WriteLine(br.ReadDecimal());
			Console.WriteLine(br.ReadChar());
        }
    }
}
