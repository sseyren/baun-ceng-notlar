using System;

namespace Kod7
{
    class A {
        public int ÖzellikA;
        public A(int a)
        {
            ÖzellikA = a;
        }
        /* Parametre almayan yapıcı metod: 
        public A()
        {
            ÖzellikA = 123;
        }
        */
    }
    class B : A
    {
        public int ÖzellikB;
        // `base` sözcüğü olmadan hata alırız. `base` sözcüğü olmadan sorunu
        //   çözmek istersek A sınıfına parametre almayan bir yapıcı metod
        //   eklememiz gerekir. Yukarıdaki gibi.
        public B(int b):base(b)
        {
            ÖzellikB = b;
        }
    }
    class C : B
    {
        public int ÖzellikC;
        public C(int c, int b):base(b)
        {
            ÖzellikC = c;
        }
        public static void Main()
        {
            C nesne = new C(12, 56);
            Console.WriteLine(nesne.ÖzellikA + " " + nesne.ÖzellikB + " " + nesne.ÖzellikC);
        }
    }
}
