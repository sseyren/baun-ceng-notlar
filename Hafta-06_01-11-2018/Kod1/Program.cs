using System;

namespace Kod1
{
    class Hayvanlar{
        private double Boy, Ağırlık;
        public double Boy_Değeri{
            get{
                return Boy;
            }
            set{
                Boy = value;
            }
        }
        public double Ağırlık_Değeri{
            get{
                return Ağırlık;
            }
            set{
                Ağırlık = value;
            }
        }
        public void ÖzellikGöster(){
            Console.WriteLine("Boy = " + Boy);
            Console.WriteLine("Ağırlık = " + Ağırlık);
        }
    }
    class Kedi : Hayvanlar{
        public string Türü;
        public void TürGöster(){
            Console.WriteLine(Türü + " Kedisi");
            Console.WriteLine("Boy = " + Boy_Değeri);
            Console.WriteLine("Ağırlık = " + Ağırlık_Değeri);
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Kedi kedi1 = new Kedi();
            kedi1.Ağırlık_Değeri = 5;
            kedi1.Boy_Değeri = 10;
            kedi1.Türü = "Van";

            kedi1.ÖzellikGöster();
            kedi1.TürGöster();
        }
    }
}
