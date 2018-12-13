using System;

namespace Kod1
{
    class Sayılar
    {
        private int mDeğer;
        public Sayılar(int değer)
        {
            if (değer > 100)
                throw new OverflowException("Değer 100'den büyük olmamalı.");
            else
                mDeğer = değer;
        }
        public int Değer
        {
            get
            {
                return mDeğer;
            }
            set
            {
                if (value > 100)
                    throw new OverflowException("Değer 100'den büyük olamaz.");
                else
                    mDeğer = value;
            }
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Sayılar s = new Sayılar(41);
                s.Değer = 300;
            }
            catch (OverflowException excp)
            {
                Console.WriteLine(excp.Message);
            }
        }
    }
}
