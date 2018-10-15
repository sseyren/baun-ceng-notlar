using System;

namespace Kod8
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			if (BitConverter.IsLittleEndian)
				Console.WriteLine("Little Endian - düşük anlamlı byte ilk sırada");
			else
				Console.WriteLine("Big Endian - yüksek anlamlı byte ilk sırada");

			int a = 19785;
			// 00000000 00000000 01001101 01001001

			byte[] aByte = BitConverter.GetBytes(a);
			foreach (byte i in aByte)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine("\n" + BitConverter.ToInt32(aByte, 0));
		}
    }
}
