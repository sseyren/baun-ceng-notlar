using System;
using System.IO;

namespace Kod4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string yol = @"C:/deneme.txt";
			FileInfo dosya = new FileInfo(yol);

			Console.WriteLine("Dosya var mı?: " + dosya.Exists);
			Console.WriteLine("Özellikleri: " + dosya.Attributes);
			Console.WriteLine("Oluşturma zamanı: " + dosya.CreationTime);
			Console.WriteLine("Uzantısı: " + dosya.Extension);
			Console.WriteLine("Dosya tam adı :" + dosya.FullName);
			Console.WriteLine("Son erişim zamanı: " + dosya.LastAccessTime);
			Console.WriteLine("Son yazma zamanı: " + dosya.LastWriteTime);
			Console.WriteLine("Boyut : " + dosya.Length);
			Console.WriteLine("Dosya adı: " + dosya.Name);
			Console.WriteLine("Bulunduğu klasör: " + dosya.DirectoryName);
        }
    }
}
