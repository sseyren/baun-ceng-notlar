using System;

namespace Kod4
{
    class Notlar
    {
        private int mNot;
        public int Not
        {
            get
            {
                return mNot;
            }
            set
            {
                if (value > 100)
                    throw new FazlaNotHatası();
                else if (value < 0)
                    throw new DüşükNotHatası();
                else
                    mNot = value;
            }
        }
        public class FazlaNotHatası : ApplicationException
        {
            override public string Message
            {
                get
                {
                    return "Not 100'den büyük olamaz.";
                }
            }
        }
        public class DüşükNotHatası : ApplicationException
        {
            override public string Message
            {
                get
                {
                    return "Not 0'dan küçük olamaz.";
                }
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Notlar a = new Notlar();
                Console.Write("Not girin: ");
                int b = Int32.Parse(Console.ReadLine());
                a.Not = b;
                Console.WriteLine("Not başarıyla eklendi.");
            }
            catch (Exception nesne)
            {
                Console.WriteLine(nesne.Message);
            }
        }
    }
}
