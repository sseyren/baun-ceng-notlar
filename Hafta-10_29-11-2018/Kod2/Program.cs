using System;

namespace Kod2
{
    /*
    Abstract metotlar
    (1)- Türeyen sınıflarda temel sınıfta bulunan bütün
         Özet metotların devredışı bırakılması gerekir.
         Eğer devredışı bırakılmayan bir metot varsa
         program derlenmez.
    (2)- Özet sınıflar içinde özet olmayan metotlar
         bildirilebilir.ancak bir sınıf içinde özet metot
         bildirilmişse sınıfın mutlaka özet olması gerekir.
    (3)- Özet metotlar private olarak bildirilemez.
         private olursa kendisinden türeyen sınıflar
         bu özet metodu devre dışı bırakamaz.
         Public ya da protected olarak bildirilmelidir.
         */
    abstract class Hayvanlar
    {
        public double boy;
        public double agirlik;
        public Hayvanlar(double boy, double agirlik)
        {
            this.boy = boy;
            this.agirlik = agirlik;
        }
        abstract public void Konus();//özet metotların gövdesi olmaz


    }
    class Kedi : Hayvanlar
    {
        public string turu;
        public Kedi(string turu, double boy, double agirlik) : base(boy, agirlik)
        {
            this.turu = turu;
        }
        override public void Konus()
        {
            Console.WriteLine("miyav");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Hatalı kullanım çünkü özet sınıflar türünden nesne tanımlanamaz
            //Hayvanlar h1 = new Hayvanlar(5,15);
            Kedi k1 = new Kedi("Van", 5, 15);
            Console.WriteLine("Kedinin Boyu: " + k1.boy);
            Console.WriteLine("Kedinin Ağırlığı: " + k1.agirlik);
            Console.WriteLine("Kedinin Türü:" + k1.turu);
            k1.Konus();
        }
    }
}
