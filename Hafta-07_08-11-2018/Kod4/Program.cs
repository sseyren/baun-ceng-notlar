using System;

// Tek bir metod ile birçok sınıfa ait farklı versiyondaki metodlar
//  çağırılabilir. Üstelik bu işlem aynı nesne üzerinden olmaktadır. Bir
//  nesnenin bu şekilde çoklu özellik göstermesine çok biçimlilik
//  (polymorphism) denir.

namespace Kod4
{
    class Şekil
    {
        public double Boy, En;
        public Şekil(double boy, double en)
        {
            this.Boy = boy;
            this.En = en;
        }
        virtual public double Alan()
        {
            return 0;
        }
    }
    class Dörtgen : Şekil
    {
        public Dörtgen(int en, int boy) : base(boy, en){}
        public override double Alan()
        {
            return En * Boy;
        }
    }
    class Üçgen : Şekil
    {
        public Üçgen(int en, int boy) : base(boy, en){}
        public override double Alan()
        {
            return En * Boy / 2;
        }
    }
    class MainClass
    {
        public static void AlanBul(Şekil şekil)
        {
            Console.WriteLine("Şeklin alanı: " + şekil.Alan());
        }
        public static void Main(string[] args)
        {
            Üçgen üçgen1 = new Üçgen(10, 50);
            AlanBul(üçgen1);

            Dörtgen dörtgen1 = new Dörtgen(10, 50);
            AlanBul(dörtgen1);

            Şekil şekil1 = new Şekil(10, 50);
            AlanBul(şekil1);
        }
    }
}
