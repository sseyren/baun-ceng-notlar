using System;

/*
 *  Arayüz uygulama yöntemi ile istenirse türeyen sınıflarda arayüzde bulunan
 * üye elemanlar açık bir şekilde nesneler tarafından erişilemez hale
 * getirilebilir. İlgili üye elemanlarına sadece arayüz referansları ile
 * erişilmesi sağlanabilir.
 * 
 *  Birden fazla arayüz uygulandığı durumlarda eğer aynı isimli üye elemanlar
 * varsa isim çakışmasının önüne bu yöntemle geçilebilir.
*/

namespace Kod4
{
    interface IHayvan
    {
        void Konuş();
    }
    class Kedi : IHayvan
    {
        void IHayvan.Konuş()
        {
            Console.WriteLine("Miyav!");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Kedi k = new Kedi();
            ((IHayvan)k).Konuş();
            // Aşağıdaki satır çalışmaz:
            // k.konus();

            /*
             *  Konuş() metodunun çağrılabilmesi için IHayvan arayüzü
             * referansına çevrilmesi gerekir. Doğrudan Kedi nesnesi üzerinden
             * Konuş() metodu çağrılamayacaktır. Sınıf nesneleri için arayüz
             * üye elemanları private gibi davranmaktadır.            
             */

            IHayvan h1 = new Kedi();
            h1.Konuş();
        }
    }
}
