using System;
using System.IO;

namespace Kod6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string Dizin = Directory.GetCurrentDirectory();
			while(true){
				Console.Write("q | pwd | dir | clear | <dizin adı>: ");
				string yeniDizin = Console.ReadLine().Trim();
				if (yeniDizin.ToLower() == "q")
					break;
				else if (yeniDizin.ToLower() == "dir")
					Listele(Dizin);
				else if (yeniDizin.ToLower() == "pwd")
					Console.WriteLine("Mevcut dizin: " + Dizin);
				else if (yeniDizin.ToLower() == "clear")
					Console.Clear();
				else if (!Directory.Exists(yeniDizin))
					Console.WriteLine("Böyle bir dizin yok.");
				else
					Dizin = yeniDizin;            
			}
        }

		public static void Listele(string Dizin){
			string[] Dosyalar = Directory.GetFiles(Dizin);
			string[] Dizinler = Directory.GetDirectories(Dizin);
			int dosyaSayisi = 0, dizinSayisi = 0;
			foreach (string dosyaAdi in Dosyalar)
			{
				FileInfo file = new FileInfo(dosyaAdi);
				Console.WriteLine("{0,-30} {1,-30}", file.Name, file.CreationTime);
				dosyaSayisi++;
			}
			foreach (string dizinAdi in Dizinler){
				DirectoryInfo di = new DirectoryInfo(dizinAdi);
				Console.WriteLine("{0,-30} {1,-30}", di.Name, di.CreationTime);
				dizinSayisi++;
			}
			Console.WriteLine("{0} Dizininde, {1} dizin, {2} dosya bulundu", Dizin, dizinSayisi, dosyaSayisi);
		}
    }
}
