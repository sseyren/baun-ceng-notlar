using System;
using System.IO;

namespace Kod3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string yol1 = @"C:";
			DirectoryInfo d1 = new DirectoryInfo(yol1);

			DirectoryInfo alt = d1.CreateSubdirectory("deneme");
			alt.CreateSubdirectory("deneme2");

			string yol2 = @"C:";
			DirectoryInfo d2 = new DirectoryInfo(yol2);
			DirectoryInfo[] dizinler = d1.GetDirectories();

			foreach (DirectoryInfo i in dizinler)
				Console.WriteLine(i.Name);
        }
    }
}
