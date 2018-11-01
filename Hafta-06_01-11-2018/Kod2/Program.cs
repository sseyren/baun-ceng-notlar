using System;

namespace Kod2
{
    //Sayfa 414 
    class Hayvanlar
    {
        protected double Boy = 15;
        protected double Agirlik = 8;
        public void OzellikGoster()
        {
            Console.WriteLine("Boy = " + Boy);
            Console.WriteLine("Agirlik = " + Agirlik);
        }
    }
    class Kedi : Hayvanlar
    {
        public void TurGoster()
        {
            Console.WriteLine("***Boy = " + Boy);
            Console.WriteLine("***Agirlik = " + Agirlik);
            Console.ReadLine();
        }
    }
    class MainMetodu
    {
        static void Main(string[] args)
        {
            Kedi kedi1 = new Kedi();
            kedi1.OzellikGoster();
            kedi1.TurGoster();

            Hayvanlar hayvan1 = new Hayvanlar();
            hayvan1.OzellikGoster();
            Console.ReadLine();
        }
    }
}
