using System;

namespace Kod3
{
    class Hayvanlar
    {
        public double Boy, Ağırlık;
        public Hayvanlar(double boy, double ağırlık)
        {
            this.Boy = boy;
            this.Ağırlık = ağırlık;
        }
        // Sanal metodlar türeyen sınıflar içinde de tekrar tanımlanabilen
        //   metodlardır. Sanal metodlar late-binding destekler. Late-binding
        //   metodların çalışma anında belirlenmesi anlamına gelir.
        // `virtual` anahtar kelimesiyle tanımlanırlar ve türeyen sınıflar
        //   içinde `override` sözcüğü ile üstüne yazılır.
        virtual public void Konuş()
        {
            Console.WriteLine("Konuşmam...");
        }
    }
    class Kedi : Hayvanlar
    {
        public string Türü;
        public Kedi(string türü, int boy, int ağırlık) : base(boy, ağırlık)
        {
            this.Türü = türü;
        }
        public override void Konuş()
        {
            Console.WriteLine("Ben bir kediyim!");
        }
    }
    class Koyun : Hayvanlar
    {
        public string Türü;
        public Koyun(string türü, int boy, int ağırlık) : base(boy, ağırlık)
        {
            this.Türü = türü;
        }
        public override void Konuş()
        {
            Console.WriteLine("Ben bir koyunum!");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hayvanlar hayvan1 = new Hayvanlar(10, 35);
            Kedi kedi1 = new Kedi("Van", 5, 10);
            Koyun koyun1 = new Koyun("Ankara", 50, 65);

            hayvan1.Konuş();

            hayvan1 = kedi1;
            hayvan1.Konuş();

            hayvan1 = koyun1;
            hayvan1.Konuş();
        }
    }
}
