using System;

namespace linkedlistcsharp
{
    // Her bir düğümü ifade eden Node sınıfımız...
    public class Node
    {
        // ...veri olarak sadece bir tane int...
        public int data;

        // ...ve kendisinden sonrakini işaret edecek bir işaretçiye sahip.
        public Node next = null;

        // Birbirlerini aşırı yükleyen yapıcı metodlar, bazıları gereksiz.
        public Node(int value)
        {
            this.data = value;
        }

        public Node(int value, Node next)
        {
            this.data = value;
            this.next = next;
        }

        public Node(Node next)
        {
            this.next = next;
        }
    }

    // Bağlı liste işlemlerini tutan sınıfmız...
    public class LinkedList
    {
        // ...listenin ilk elemanını tutmakta, diğer elemanlar birbirlerini
        //  işaret etmekte zaten.
        Node root;

        // Listeye ekleme
        public void Add(int value)
        {
            // Listenin ilk elemanı null'sa (yoksa) yeni root'u yeni
            //  oluşturulan node yap.
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            // iter, iteration kelimesinin kısaltılmışıdır. Liste üzerinde
            //  gezinirken ara bir değişkene ihtiyaç duyulabiliyor.
            Node iter = root;

            // Listenin sonuna git ve...
            while (iter.next != null)
                iter = iter.next;

            // ...son elemanın sonrasına yeni düğümü ekle.
            iter.next = new Node(value);
        }

        public void Remove(int value)
        {
            // Liste boşsa bir şey yapma.
            if (root == null)
                return;

            // Listenin ilk elemanı aradığımız değerse...
            else if (root.data == value)
            {
                // ...yeni root, root'tan bir sonraki düğüm olsun.
                root = root.next;
                return;
            }

            // Silme, aradan çıkarma işlemi için silinecek düğüme değil, ondan
            //  bir önceki düğüme ihtiyaç duyarız. Çünkü silinecek düğümün bir
            //  sonraki düğümü; silinecek düğümün bir sonraki düğümünü işaret
            //  ederse silme işlemi gerçekleşmiş olur.

            Node iter = root;

            // iter ile silinecek düğümden bir önceki düğümü yakalıyoruz.
            while (iter.next != null && iter.next.data != value)
                iter = iter.next;

            // iter.next bu noktada hala null ise demek ki listenin sonuna
            //  kadar geldiğimiz halde aradığımız değeri buılamadık. Eğer
            //  değilse listeden çıkarmamız gereken düğüm iter.next'tir.
            if (iter.next != null)
                iter.next = iter.next.next;
        }

        // Listedeki düğümleri gösteren basit bir metod.
        public void Show()
        {
            if(root == null)
            {
                Console.WriteLine("NULL");
                return;
            }

            Node iter = root;

            for (int i = 0; iter != null; i++)
            {
                Console.WriteLine("{0} -> {1}", i, iter.data);
                iter = iter.next;
            }
        }
    }
}
