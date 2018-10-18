using System;
using System.IO;

namespace Kod2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string yol = @"C:/";
			DirectoryInfo d = new DirectoryInfo(yol);

			Console.WriteLine("Dizinin tam yolu: " + d.FullName);
			Console.WriteLine("Özellikler: " + d.Attributes);
			Console.WriteLine("Oluşturulma Tarihi: " + d.CreationTime);
			Console.WriteLine("Klasör var mı?: " + d.Exists);
			Console.WriteLine("Uzantısı: " + d.Extension);
			Console.WriteLine("Tam yol: " + d.FullName);
			Console.WriteLine("Son erişim zamanı: " + d.LastAccessTime);
			Console.WriteLine("Son yazma zamanı: " + d.LastWriteTime);
			Console.WriteLine("Klasör adı: " + d.Name);
			Console.WriteLine("Bir üst klasör: " + d.Parent);
			Console.WriteLine("Kök dizin: " + d.Root);
		}
    }
}
