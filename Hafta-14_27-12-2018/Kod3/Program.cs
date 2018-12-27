using System;

/*  Bazen olay yöneticisine eklenecek metodlar ile ilgili kısıtlamamız
 * olabilir. Örneğin bir olay için sadece belirli sayıda metodun çalıştırılması
 * istenebilir.
 *  Olay yöneticisine += ile metod eklendiğinde add bloğu, -= operatörü ile
 * metod çıkarıldığı zaman remove bloğu çalışır.
 *  Aşağıdaki örnekte ButonKlik olayı, olay yöneticisi tarafından en fazla
 * iki adet metod çalıştırılacak şekilde düzenlenmiştir.
 */

/* add ve remove blokları ayrı ayrı bulunmaz. Her iki blokta mutlaka aynı anda
 * kullanılmalıdır.
 */

namespace Kod3
{
    delegate void OlayYöneticisi();
    class Buton
    {
        OlayYöneticisi[] olay = new OlayYöneticisi[2];
        public event OlayYöneticisi ButonKlik
        {
            add
            {
                int i;
                for (i = 0; i < 2; i++)
                {
                    if(olay[i] == null)
                    {
                        olay[i] = value;
                        break;
                    }
                }
                if (i == 2)
                    Console.WriteLine("Olay yöneticisine en fazla 2 metod eklenebilir.");
            }
            remove
            {
                int i;
                for (i = 0; i < 2; i++)
                {
                    if(olay[i] == value)
                    {
                        olay[i] = null;
                        break;
                    }
                }
                if(i == 2)
                {
                    Console.WriteLine("Metod bulunamadı.");
                }
            }
        }
        public void Kliklendi()
        {
            for(int i = 0; i < 2; i++)
            {
                if (olay[i] != null)
                    olay[i]();
            }
        }
    }
    class Pencere
    {
        int PencereNo;
        public Pencere(int no)
        {
            PencereNo = no;
        }
        public void Butonİşlemi()
        {
            Console.WriteLine("{0} nolu pencere olayı algıladı.", PencereNo);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Buton buton = new Buton();
            Pencere p1 = new Pencere(1);
            Pencere p2 = new Pencere(2);

            // Geçerli ekleme
            buton.ButonKlik += new OlayYöneticisi(Butonİşlemi);
            buton.Kliklendi();
            Console.WriteLine();

            // Geçerli ekleme
            buton.ButonKlik += new OlayYöneticisi(p1.Butonİşlemi);
            buton.Kliklendi();
            Console.WriteLine();

            // Geçersiz ekleme (Olay yöneticisi dolu)
            buton.ButonKlik += new OlayYöneticisi(p2.Butonİşlemi);
            buton.Kliklendi();
            Console.WriteLine();

            buton.ButonKlik -= new OlayYöneticisi(p1.Butonİşlemi);
            buton.Kliklendi();
            Console.WriteLine();

            buton.ButonKlik -= new OlayYöneticisi(Butonİşlemi);
            buton.Kliklendi();
            Console.WriteLine();
        }
        public static void Butonİşlemi() => Console.WriteLine("Statik metod olayı algıladı.");
    }
}
