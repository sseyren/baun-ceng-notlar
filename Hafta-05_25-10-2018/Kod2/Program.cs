using System;
using System.IO;

namespace Kod2
{
    class MainClass
    {
        public static void Main(string[] args)
		{
			string kaynak = args[0], hedef = args[1], parola;
			Console.Write("Parola: ");
			parola = Console.ReadLine();

			int xor = 0;
			for (int i = 0; i < parola.Length; i++)
				xor = xor + (int)(parola[i] * 10);
			
			Console.WriteLine(xor);

			FileStream fsKaynak = new FileStream(kaynak, FileMode.Open);
			FileStream fsHedef = new FileStream(hedef, FileMode.CreateNew, FileAccess.Write);

			int okunanByte;
			byte sifreliByte;

			while ((okunanByte = fsKaynak.ReadByte()) != -1)
			{
				sifreliByte = (byte)((int)okunanByte ^ xor);
				fsHedef.WriteByte(sifreliByte);
			}

			fsKaynak.Close();
			fsHedef.Close();
		}
    }
}