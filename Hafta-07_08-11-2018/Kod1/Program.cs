using System;

namespace Kod1
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
        // Yapıcı metod
        // base(boy,ağırlık) ile çağırılan aslında Hayvanlar sınıfının yapıcı 
        //   metodudur.
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
            Kedi kedi2;

            // normal atama
            kedi2 = kedi1;

            kedi2.ÖzellikGöster();
            kedi2.TürGöster();
            Console.WriteLine();

            Hayvanlar hayvan1 = new Hayvanlar(6, 11);
            hayvan1.ÖzellikGöster();
            Console.WriteLine();

            // Türeyen sınıfa ilişkin bir referans temel sınıfa ilişkin bir
            //   referansa atanabilir.
            hayvan1 = kedi1;
            hayvan1.ÖzellikGöster();

            // Hatalı kullanım: hayvan1.TürGöster();
        }
    }
}