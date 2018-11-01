using System;

// `base` sözcüğü ile ana sınıfın yapıcı metoduna parametreler geçirebiliriz.

namespace Kod4
{
    class Hayvanlar
    {
        protected double Boy, Ağırlık;
        public Hayvanlar(double boy, double ağırlık)
        {
            this.Boy = boy;
            this.Ağırlık = ağırlık;
        }
        public void ÖzellikGöster()
        {
            Console.WriteLine("Boy = " + Boy);
            Console.WriteLine("Ağırlık = " + Ağırlık);
        }
    }
    class Kedi : Hayvanlar
    {
        public string Türü;
        public Kedi(string türü, int boy, int ağırlık) : base(boy, ağırlık)
        {
            this.Türü = türü;
        }
        public void TürGöster()
        {
            Console.WriteLine(Türü + " Kedisi");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Kedi kedi1 = new Kedi("Van", 5, 10);
            kedi1.ÖzellikGöster();
            kedi1.TürGöster();
            Console.WriteLine("-----------------");
            Hayvanlar hayvan1 = new Hayvanlar(6, 11);
            hayvan1.ÖzellikGöster();
        }
    }
}
