using System;

namespace Kod2
{
    delegate void OlayYöneticisi();
    class Buton
    {
        public event OlayYöneticisi ButonKlik;
        public void Kliklendi()
        {
            if (ButonKlik != null)
                ButonKlik();
        }
    }
    class Pencere
    {
        int PencereNo;
        public Pencere(int no) => PencereNo = no;
        public void Butonİşlemi() => Console.WriteLine("{0} nolu pencere olayı algıladı.", PencereNo);
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Buton buton = new Buton();
            Pencere p1 = new Pencere(1);
            Pencere p2 = new Pencere(2);

            buton.ButonKlik += new OlayYöneticisi(Butonİşlemi);
            buton.ButonKlik += new OlayYöneticisi(p1.Butonİşlemi);
            buton.ButonKlik += new OlayYöneticisi(p2.Butonİşlemi);

            buton.Kliklendi();
        }
        public static void Butonİşlemi() => Console.WriteLine("Statik metod olayı algıladı.");
    }
}
