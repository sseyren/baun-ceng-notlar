using System;

namespace Kod5
{
    class Metrik
    {
        private int mMetre, mSantim;
        public Metrik(int metre, int santim)
        {
            if (santim > 99)
                throw new HatalıMetrikİstisnası(santim, "Yapıcı metod");
            mMetre = metre;
            mSantim = santim;
        }
        public void DeğerVer(int metre, int santim)
        {
            if (santim > 99)
                throw new HatalıMetrikİstisnası(santim, "DeğerVer metodu");
            mMetre = metre;
            mSantim = santim;
        }
        public int Metre
        {
            get { return mMetre; }
            set { mMetre = value; }
        }
        public int Santim
        {
            get { return mSantim; }
            set
            {
                if (value > 99)
                    throw new HatalıMetrikİstisnası(value, "Santim özelliği");
                mSantim = value;
            }
        }
    }
    public class HatalıMetrikİstisnası : ApplicationException
    {
        private int mHatalıSantim;
        private string mHataKaynağı;
        public HatalıMetrikİstisnası(int hataSantim, string kaynak)
        {
            mHatalıSantim = hataSantim;
            mHataKaynağı = kaynak;
        }
        public int HatalıSantim
        {
            get { return mHatalıSantim; }
        }
        public string HataKaynağı
        {
            get { return mHataKaynağı; }
        }
        public override string ToString()
        {
            string str1 = "Hata kaynağı: " + mHataKaynağı + ", ";
            string str2 = "Hata değeri: " + mHatalıSantim;
            return str1 + str2;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Metrik m = new Metrik(10, 52);
                m.Santim = 650;
            }
            catch (HatalıMetrikİstisnası msj)
            {
                Console.WriteLine(msj.ToString());
            }
        }
    }
}
