using System;

namespace Kod9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			// 00000001 00000010 00000011 00000010 00000001
			byte[] kaynak = { 1, 2, 3, 2, 1 };

			// 0000000000000000 0000000000000000 0000000000000000 0000000000000000
			short[] hedef = new short[4];

			// 0000001000000001 0000001000000011 0000000000000000 0000000000000000
			Buffer.BlockCopy(kaynak, 0, hedef, 0, 4);
			foreach (short i in hedef)
			{
				Console.Write("{0} ", i);
			}

			Console.WriteLine("\n\n");

			short[] dizi1 = new short[4];
			Console.WriteLine(Buffer.ByteLength(dizi1));

			byte[] dizi2 = { 0, 1, 2, 3, 4, 5, 6 };
			Console.WriteLine(Buffer.GetByte(dizi2, 5));

			Buffer.SetByte(dizi2, 2, 112);
			Console.WriteLine(dizi2[2]);
		}
    }
}
