using System;

namespace Kod9
{
    class Temel
    {
        public int a;
        public void Göster()
        {
            Console.WriteLine("Temel.a = " + a);
        }
    }
    class Türeyen : Temel
    {
        // Gizlenen eleman için derleyicinin uyarı vermemesi
        //   amacıyla new kullanılır.

        // this referansı kendisini temsil ederken base sözcüğü türemenin
        //   yapıldığı temel sınıfı temsil eder.
        new int a;
        public Türeyen(int aTemel, int aTüreyen)
        {
            a = aTüreyen;
            base.a = aTemel;
        }

        // Aşağıdaki metod public yerine private olarak tanımlanırsa
        //   Temel sınıfın Göster() metodu çağırılır.
        new public void Göster()
        {
            base.Göster();
            Console.WriteLine("Türeyen.a = " + a);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Türeyen nesne1 = new Türeyen(5, 8);
            nesne1.Göster();
            Console.WriteLine("--------------");
            Temel nesne2 = new Temel();
            nesne2.Göster();
        }
    }
}
