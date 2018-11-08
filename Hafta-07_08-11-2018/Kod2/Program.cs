using System;

namespace Kod2
{
    class Hayvanlar
    {
        protected double mBoy, mAğırlık;
        public Hayvanlar(double boy, double ağırlık)
        {
            this.mBoy = boy;
            this.mAğırlık = ağırlık;
        }
        public void ÖzellikGöster()
        {
            Console.WriteLine("Boy = " + mBoy);
            Console.WriteLine("Ağırlık = " + mAğırlık);
        }
        public double Boy
        {
            get { return mBoy; }
            set { mBoy = value; }
        }
        public double Ağırlık
        {
            get { return mAğırlık; }
            set { mAğırlık = value; }
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
    class Koyun : Hayvanlar
    {
        public string Türü;
        public Koyun(string türü, int boy, int ağırlık) : base(boy, ağırlık)
        {
            this.Türü = türü;
        }
        public void TürGöster()
        {
            Console.WriteLine(Türü + " Koyunu");
        }
    }
    class MainClass
    {
        public static void Göster(Hayvanlar hayvan)
        {
            Console.WriteLine("Boy = " + hayvan.Boy);
            Console.WriteLine("Ağırlık = " + hayvan.Ağırlık);
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Hayvanlar hayvan1 = new Hayvanlar(10, 35);
            Göster(hayvan1);

            Kedi kedi1 = new Kedi("Van", 5, 10);
            Göster(kedi1);

            Koyun koyun1 = new Koyun("Ankara", 52, 80);
            Göster(koyun1);
        }
    }
}
