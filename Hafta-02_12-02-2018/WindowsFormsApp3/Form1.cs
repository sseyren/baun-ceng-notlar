using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncapsulationUygulama sinif = new EncapsulationUygulama();
            MessageBox.Show(sinif.universite + '\n' + sinif.Sehir);
            // Aşağıdaki gibi doğrudan erişim sağlanamaz:
            //  MessageBox.Show(sinif.m_sehir);
        }

        class Kenar
        {
            protected int kkenar, ukenar;
            public void kenarlar(int a, int b)
            {
                kkenar = a;
                ukenar = b;
            }
            private string k;
            public string kenarlarGoster()
            {
                k = "a = " + kkenar.ToString() + " ve " + "b = " + ukenar.ToString();
                return k;
            }
        }

        class Dikdortgen : Kenar
        {
            public int alanHesapla() { return ukenar * kkenar; }
            public int cevreHesapla() { return 2 * (ukenar + kkenar); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dikdortgen d = new Dikdortgen();
            d.kenarlar(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            MessageBox.Show("Kenarlar:\t" + d.kenarlarGoster()
                + "\nAlan:\t" + d.alanHesapla().ToString()
                + "\nÇevre:\t" + d.cevreHesapla().ToString());
        }

        class Yapici
        {
            protected int kkenar, ukenar;
            public Yapici(int a, int b)
            {
                kkenar = a;
                ukenar = b;
            }
            private string k;
            public string kenarlarGoster()
            {
                k = "a = " + kkenar.ToString() + " ve " + "b = " + ukenar.ToString();
                return k;
            }
            ~Yapici()
            {
                // Formu kapattığımızda çalışır.
                // Formu bir buton içinde this.Clone() yaparak kapatabilirdik.
                MessageBox.Show("Bellekten siliniyor...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yapici y = new Yapici(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            MessageBox.Show("Kenarlar:\t" + y.kenarlarGoster());
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // static metodu nesne üretmeden çağırıyoruz
            staticMethod.isimYaz(textBox1.Text, textBox2.Text);
        }
        class staticMethod
        {
            public static void isimYaz(string s1, string s2)
            {
                MessageBox.Show(s1 + ' ' + s2);
            }
        }

        interface IBildirim
        {
            float y_cap
            {
                get; set;
            }
            double Alan();
            double Cevre();
            void EkrandaGoster();
        }

        public class Cevap : IBildirim
        {
            float yaricap;
            public float y_cap
            {
                get { return yaricap; }
                set { yaricap = value; }
            }
            public double Alan()
            {
                return Math.PI * Math.Pow(y_cap, 2);
            }
            public double Cevre()
            {
                return Math.PI * 2 * y_cap;
            }
            public void EkrandaGoster()
            {
                MessageBox.Show("Çevre:\t" + Cevre() + "\nAlan:\t" + Alan());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cevap c = new Cevap();
            c.y_cap = float.Parse(textBox1.Text);
            c.EkrandaGoster();
        }
    }
}
