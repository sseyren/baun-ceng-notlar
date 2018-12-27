using System;

// Olaylar ile nesneler arası mesajlaşma

namespace Kod4
{
    public delegate void BardakDolunca();
    class MainClass
    {
        public static void Main(string[] args)
        {
            Bardak b = new Bardak();
            Makine m = new Makine(b);
            m.Doldur(3, b);
        }
    }
    class Bardak
    {
        int Kapasite = 20, miktar = 0;
        public event BardakDolunca BardakDoldu;
        public void BardağıDoldur(int debi)
        {
            for(int i = 0; i < Kapasite; i++)
            {
                if (miktar + debi < Kapasite && debi > 0)
                {
                    miktar += debi;
                    Console.WriteLine(miktar.ToString());
                }
                else
                {
                    Console.WriteLine("Bardak doldu.");
                    BardakDoldu();
                    return;
                }
            }
        }
    }
    class Makine
    {
        int debi;
        public void Doldur(int Debi, Bardak b)
        {
            debi = Debi;
            b.BardağıDoldur(debi);
        }
        void MusluğuKapa()
        {
            debi = 0;
            Console.WriteLine("Musluk kapandı.");
        }
        public Makine(Bardak b)
        {
            b.BardakDoldu += new BardakDolunca(MusluğuKapa);
        }
    }
}
