using System;

// Türetilen sınıftan bir obje oluşturulurken önce ana sınıfın yapıcı metodu
//   sonra da türetilen sınıfın yapıcı metodu çalışır.

namespace Kod3
{
    class Hayvanlar
    {
        protected double Boy, Ağırlık;
        public Hayvanlar(){
            Console.WriteLine("Hayvanlar alemi");
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
        public Kedi(){
            Console.WriteLine("Kedi oluşturuldu");
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
            Kedi kedi1 = new Kedi();
            Hayvanlar hayvan1 = new Hayvanlar();
        }
    }
}
