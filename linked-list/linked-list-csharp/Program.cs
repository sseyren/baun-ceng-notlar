using System;

namespace linkedlistcsharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.Show();
            Console.WriteLine();

            // Listeye ekleme.
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(40);

            list.Show();
            Console.WriteLine();

            // Ortadan düğüm silme.
            list.Remove(20);
            list.Show();
            Console.WriteLine();

            // Olmayan düğümü silme.
            list.Remove(-10);
            list.Show();
            Console.WriteLine();

            // Baştaki düğümü silme.
            list.Remove(10);
            list.Show();
            Console.WriteLine();

            // Sondan düğüm silme.
            list.Remove(40);
            // Listedeki tek düğümü silme.
            list.Remove(30);
            list.Show();
            Console.WriteLine();

            // Tamamen boşalmış bir listeye tekrar düğüm ekleme.
            list.Add(100);
            list.Add(200);
            list.Show();
        }
    }
}
