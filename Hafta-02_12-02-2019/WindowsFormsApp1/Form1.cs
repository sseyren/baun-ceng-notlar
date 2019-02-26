using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Sayi = new int[] { 10, 22, 33, 44 };
            int[] Sayi2 = new int[] { 3, 5, 8, 11 };
            string[] a = new string[] { "Ahmet", "Mehmet" };
            ArrayList liste = new ArrayList();

            liste.Add(Sayi);
            liste.Add(Sayi2);
            liste.Add(a);
            liste.Add(55);
            liste.Add("Balikesir");

            MessageBox.Show( ( (int[])liste[0] )[1].ToString() );
            MessageBox.Show( ( (int[])liste[1] )[2].ToString() );
            MessageBox.Show( ( (string[])liste[2] )[0].ToString() );
            MessageBox.Show(liste[3].ToString());
            MessageBox.Show(liste[4].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox Bilgi = new ListBox();
            Bilgi.Items.Add("Ankara");
            Bilgi.Items.Add("İstanbul");
            Bilgi.Items.Add("Bursa");
            Bilgi.Items.Add("İzmir");
            Bilgi.Items.Add("Balıkesir");

            MessageBox.Show(Bilgi.Items[1].ToString());

            ArrayList liste = new ArrayList();
            liste.AddRange(Bilgi.Items);
            MessageBox.Show(liste[2].ToString());

            int y = liste.Capacity;
            MessageBox.Show(y.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListBox Bilgi = new ListBox();
            Bilgi.Items.Add("Ankara");
            Bilgi.Items.Add("İstanbul");
            Bilgi.Items.Add("Bursa");
            Bilgi.Items.Add("İzmir");
            Bilgi.Items.Add("Balıkesir");

            string icerik = textBox1.Text;
            if (Bilgi.Items.Contains(icerik) == true)
                MessageBox.Show("Kayıt var!");
            else
                MessageBox.Show("Kayıt yok...");
        }
        private string YeniDeger(string Deger)
        {
            string yazi = "Merhaba " + Deger;
            return yazi;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(YeniDeger(textBox2.Text));
        }
        private void Parametre(int s1, int s2)
        {
            int sonuc = s1 + s2;
            MessageBox.Show(sonuc.ToString());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Parametre(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }
        private void Degerlerimiz(out int s1, out int s2)
        {
            s1 = Convert.ToInt32(textBox1.Text);
            s2 = Convert.ToInt32(textBox2.Text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Degerlerimiz(out int sayi1, out int sayi2);
            MessageBox.Show("Sayı1: " + sayi1 + "\nSayı2: " + sayi2);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
