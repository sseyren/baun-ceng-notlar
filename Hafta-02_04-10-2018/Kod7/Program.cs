// Dışarıdaki bir kitaplığı kullanmak için `extern alias` kullanılabilir.
// Tabii bunu yapabilmeniz için projeye derste anlatıldığı gibi kitaplığı
// eklemeniz ve ona bir `alias` (takma isim) atamalısınız.

// (Bu projede ayarlar kendiliğinden yapılmıştır sadece kütüphaneleri tek bir
// kereliğine derlemeniz gerekmektedir.)

extern alias GR2D;
extern alias GR3D;

// Kolaylık olması açısından daha önce gördüğümüz takma isimleri, dışarıdan
// gelen kütüphaneler için de kullanabiliriz.

using Nokta3D = GR3D.GraphicsObjects.Nokta;
using Nokta2D = GR2D.GraphicsObjects.Nokta;

using System;

namespace Kod7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			Nokta2D n1 = new Nokta2D();
			Nokta3D n2 = new Nokta3D();

			// aliaslar olmadan da çağırabilmek mümkün:
			GR2D.GraphicsObjects.Dikdörtgen d1 = new GR2D.GraphicsObjects.Dikdörtgen();
			GR3D.GraphicsObjects.Dikdörtgen d2 = new GR3D.GraphicsObjects.Dikdörtgen();
        }
    }
}
