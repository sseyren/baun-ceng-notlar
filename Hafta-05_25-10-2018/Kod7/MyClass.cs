using System;
namespace nesne
{
    public class RastgeleSayi
    {
		private Random rnd = new Random();
		private int mSayi;
		public int Sayi
		{
			get
			{
				return mSayi;
			}
		}
		public RastgeleSayi()
        {
			mSayi = rnd.Next(0, 100);
        }
		public void Değiştir()
		{
			mSayi = rnd.Next(0, 100);
		}
    }
}
