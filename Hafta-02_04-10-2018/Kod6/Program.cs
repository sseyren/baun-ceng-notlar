using System;

// İç içe isim alanları (Nested Namespaces)

using Alan1;
using Alan1.Alan2;

namespace Alan1
{
	class A
	{
		public A()
		{
			Console.WriteLine("Alan1 isim uzayı");
		}
	}
	namespace Alan2
	{
		class B
		{
			public B()
			{
				Console.WriteLine("Alan2 isim uzayı");
			}
		}
	}
}

// Bu şekilde de aynı namespace'e gidebiliyoruz.
namespace Alan1.Alan2
{
	class C
	{
		public C()
		{
			Console.WriteLine("Yine Alan2 isim uzayı");
		}

	}
}

namespace Kod6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			A a = new A();
			B b = new B();
			C c = new C();
        }
    }
}
