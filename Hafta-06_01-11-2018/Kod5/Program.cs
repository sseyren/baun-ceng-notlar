using System;

// Kalıtımda yapıcı metod hiyerarşisi.

namespace Kod5
{
    class A
    {
        public int a;
        public A()
        {
            Console.WriteLine("A sınıfının yapıcı metodu");
        }
    }
    class B : A
    {
        public int b;
        public B()
        {
            Console.WriteLine("B sınıfının yapıcı metodu");
        }
    }
    class C : B
    {
        public int c;
        public C()
        {
            Console.WriteLine("C sınıfının yapıcı metodu");
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            C c = new C();
            B b = new B();
        }
    }
}
