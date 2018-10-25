using System;

namespace Kod8
{
	class Hayvanlar
	{
		public double Boy;
		public double Ağırlık;
		public void ÖzellikGöster()
		{
			Console.WriteLine("Boy = {0}", Boy);
			Console.WriteLine("Ağırlık = {0}", Ağırlık);
		}
	}
	class Kedi:Hayvanlar
	{
		public string Türü;
		public void TürGöster()
		{
			Console.WriteLine("{0} kedisi", Türü);
		}
	}
    class MainClass
    {
        public static void Main(string[] args)
        {
			Kedi kedi1 = new Kedi();
			kedi1.Ağırlık = 5;
			kedi1.Boy = 10;
			kedi1.Türü = "Van";

			kedi1.ÖzellikGöster();
			kedi1.TürGöster();

			Console.WriteLine("\n");

			Kedi kedi2 = new Kedi();
			kedi2.Ağırlık = 8;
			kedi2.Boy = 12;
			kedi2.Türü = "İran";

			kedi2.ÖzellikGöster();
			kedi2.TürGöster();

			Console.WriteLine("\n");

			Hayvanlar hayvan = new Hayvanlar();
			hayvan.Ağırlık = 10;
			hayvan.Boy = 15;
			hayvan.ÖzellikGöster();

			// Bu metod çalışmaz: hayvan.TürGöster();
			// TürGöster() kedi sınıfı içerisinde bir fonksiyondur. Bu nedenle
			//   hayvan nesnesi üzerinden kedi sınıfı içerisindeki TürGöster()
            //   metoduna erişemeyiz.
            // Yani temel sınıf olan Hayvanlar sınıfının kendisinden türeyen
            //   Kedi sınıfındaki üye elemanlardan haberi yoktur. Ancak tersi
            //   doğrudur.
        }
    }
}
