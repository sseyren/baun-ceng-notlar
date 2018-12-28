using System;

namespace Kod4
{
    abstract class Sekil
    {
        protected int mBoy;
        protected int mEn;
        public Sekil(int boy, int en)
        {
            this.Boy = boy;
            this.En = en;
        }
        abstract public int Boy { get; set; }
        abstract public int En { get; set; }
        abstract public int Alan();
        abstract public void EkranaYaz();

    }
    class Dortgen : Sekil
    {
        private bool mKaremi;
        public Dortgen(int boy, int en) : base(boy, en)
        {
            kareKontrol();
        }
        public bool Karemi
        {
            get { return mKaremi; }
        }
        override public int Boy
        {
            get { return mBoy; }
            set
            {
                mBoy = value;
                kareKontrol();
            }
        }
        override public int En
        {
            get { return mEn; }
            set { mEn = value; kareKontrol(); }
        }
        public void kareKontrol()
        {
            if (mEn == mBoy)
                mKaremi = true;
            else
                mKaremi = false;
        }
        public override int Alan()
        {
            return mEn * mBoy;
        }
        public override void EkranaYaz()
        {
            Console.WriteLine("\nDikdörtgenin eni  : " + mEn);
            Console.WriteLine("\nDikdörtgenin boyu : " + mBoy);
            Console.WriteLine("\nKaremi            : " + (mKaremi ? "evet" : "hayır"));
            Console.WriteLine("\nDikdörtgenin alanı: " + Alan());
        }
    }
    class Ucgen : Sekil
    {
        private string UcgenTipi;
        public Ucgen(string Tur, int boy, int en) : base(boy, en)
        {
            UcgenTipi = Tur;
        }
        override public int Boy
        {
            get { return mBoy; }
            set
            {
                mBoy = value;
            }
        }
        override public int En
        {
            get { return mEn; }
            set { mEn = value; }
        }
        public override int Alan()
        {
            return mEn * mBoy / 2;
        }
        public override void EkranaYaz()
        {
            Console.WriteLine("\nÜçgenin tabanı     : " + mEn);
            Console.WriteLine("\nÜçgenin yüksekliği : " + mBoy);
            Console.WriteLine("\nÜçgenin tipi       : " + UcgenTipi);
            Console.WriteLine("\nÜçgenin alanı      : " + Alan());
        }
    }
    class Program
    {
        /*
         * Sekil sınıfı özet sınıf olduğu için Sekil sınıfı türünden
         * new operatörü kullanarak bir nesne oluşturulmaz.
         * burada kullanılan new anahtar sözcüğü s1 dizi nesnesinin
         * oluşturulması içindir.Bu dizi içinde 3 tane null değere
         * atanmış Sekil referansı bulunmaktadır.
         * 
         * Sekil s1=new Dortgen(5,6); kullanılabilir.
         * 
         * yukarıda dinamik bir nesne yaratılmıyor, sadece Sekil referansı
         * oluşturuluyor.Programdaki s1 diziside hem Ucgen hem de Dortgen
         * sınıfının ortak metotlarını çokbiçimlilikten faydalanarak
         * kullanmak için tanımlanmıştır.
         */

        static void Main(string[] args)
        {
            Sekil s2 = new Dortgen(5, 6);
            s2.EkranaYaz();
            Console.ReadLine();
            Sekil[] s1 = new Sekil[3];
            s1[0] = new Ucgen("eşkenar", 6, 6);
            s1[1] = new Dortgen(5, 5);
            /*Dortgen sınıfnda get-set bloklarında KareKontrol()
             metodunun çağrılmasının nedeni aşağodaki gibi
             doğrudan kullanımlarda doğru sonucu elde etmektir.
             */
            s1[1].Boy = 7;
            s1[2] = new Dortgen(4, 4);
            foreach (Sekil s in s1)
            {
                s.EkranaYaz();
            }


        }
    }
}
