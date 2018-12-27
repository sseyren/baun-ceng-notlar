using System;

namespace Kod1
{
    // Olay yöneticisi bildirimi
    delegate void OlayYöneticisi();

    // Olay sınıfı bildirimi
    class Buton
    {
        // Olayın bildirimi
        public event OlayYöneticisi ButonKlik;

        // Olayı meydana getirecek metod
        public void Kliklendi()
        {
            if (ButonKlik != null)
                ButonKlik();
        }
    }

    public class OlayTest
    {
        public static void Main(string[] args)
        {
            Buton buton = new Buton();

            // Olay sonrası işletilecek metodların eklenmesi
            buton.ButonKlik += new OlayYöneticisi(ButonIslemi1);
            buton.ButonKlik += new OlayYöneticisi(ButonIslemi2);

            // Olayların meydana getirilmesi
            buton.Kliklendi();
        }
        // Olay sonrası işletilecek metod (Event handler)
        public static void ButonIslemi1() => Console.WriteLine("Buton 1 kliklendi");
        public static void ButonIslemi2() => Console.WriteLine("Buton 1 kliklendi");
    }
}
