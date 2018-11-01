using System;

namespace Kod8
{

    class X
    {
        protected int a;
        public X(int a)
        {
            this.a = a;
        }
        public X()
        {
            Console.WriteLine("X Class");
        }
        public int A
        {
            get
            {
                Console.WriteLine("X sınıfındaki değer");
                return a;
            }
        }
    }
    class Y : X
    {
        protected int b;
        public Y(int a)
        {
            this.b = a;
        }
        public Y()
        {
            Console.WriteLine("Y class");
        }
        public int A
        {
            get
            {
                Console.WriteLine("Y sınıfındaki değer");
                return b;
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Y y = new Y(5);
            int deneme1 = y.A;
            // Burada y.A elemanı x.A elemanını gizlemiştir.
            Console.WriteLine(deneme1 + "\n");
            X x = new X(8);
            int deneme2 = x.A;
            Console.WriteLine(deneme2);
        }
    }
}
