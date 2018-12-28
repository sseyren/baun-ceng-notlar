using System;

namespace Kod3
{
    /*
     Abstract Class (özet sınıflar)
     hiyerarşinin en tepesindeki sınıfın kendisinden türetilecek diğer sınıflar için ortak özellikleri bir arada toplayan
     bir arayüz gibi davranması istenebilir.
     özet sınıf ya da metotlar abstract anahtar sözcüğü ile bildirilir. temel sınıf içinde bildirilen 
     özet metotların temel sınıf içinde gövdesi olmaz. ancak bu temel sınıftan türeyen bütün sınıflar 
     bu metodu devredışı bırakmalıdır.
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

    }
    class Kedi : Hayvanlar
    {
        public string turu;
        public Kedi(string turu, double boy, double agirlik) : base(boy, agirlik)
        {
            this.turu = turu;
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
        }
    }
}
