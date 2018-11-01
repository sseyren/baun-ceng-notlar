using System;

namespace Kod6
{
    class A
    {
        public int a;
        public A(int a)
        {
            this.a = a;
        }
    }
    class B : A {
        public int b;
        public B(int a, int b):base(a)
        {
            this.b = b;
        }
    }
    class C : B{
        public int c;
        public C(int a, int b, int c) : base(a, b)
        {
            this.c = c;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            C c = new C(5, 6, 7);
            Console.WriteLine("C nesnesi:");
            Console.WriteLine("a = " + c.a);
            Console.WriteLine("b = " + c.b);
            Console.WriteLine("c = " + c.c);

            B b = new B(8, 9);
            Console.WriteLine("a = " + b.a);
            Console.WriteLine("b = " + b.a);

            A a = new A(10);
            Console.WriteLine("a = " + a.a);
        }
    }
}
