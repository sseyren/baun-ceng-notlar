using System;
using System.IO;

namespace Kod5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string yol = @"C:/deneme/deneme.txt";

			Console.WriteLine("Eski uzantı: " + Path.GetExtension(yol));
			string yeniYol = Path.ChangeExtension(yol, "jpg");

			Console.WriteLine("Yeni Uzantı: " + Path.GetExtension(yol));

			string yol2 = @"C:/deneme2";

			Console.WriteLine("Yeni yol: " + Path.Combine(yol, yol2));

			Console.WriteLine("Dosya adı: " + Path.GetFileName(yol));
			Console.WriteLine("uzantısısz dosya adı" + Path.GetFileNameWithoutExtension(yol));
			Console.WriteLine("Tam yol: " + Path.GetFullPath(yol));
			Console.WriteLine("Kök dizin: " + Path.GetPathRoot(yol));
			Console.WriteLine("Geçici dosya adı " + Path.GetTempPath());
			Console.WriteLine("Geçici dosya dizini " + Path.GetTempPath());
			Console.WriteLine("dosya uzantısı var mı " + Path.HasExtension(yol));
			Console.WriteLine("Alt dizin ayıracı : " + Path.AltDirectorySeparatorChar);
			Console.WriteLine("Dizin ayıracı" + Path.DirectorySeparatorChar);
			Console.WriteLine("yol ayırıcı karakter" + Path.PathSeparator);
			Console.WriteLine("Kök dizin ayıracı" + Path.VolumeSeparatorChar);
        }
    }
}
