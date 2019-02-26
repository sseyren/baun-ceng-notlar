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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private float Islem(float sayi1, float sayi2, char islem)
        {
            float sonuc = 0;
            switch (islem)
            {
                case '+':
                    sonuc = sayi1 + sayi2;
                    break;
                case '-':
                    sonuc = sayi1 - sayi2;
                    break;
                case '*':
                    sonuc = sayi1 * sayi2;
                    break;
                case '/':
                    sonuc = sayi1 / sayi2;
                    break;
            }
            return sonuc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float sayi1 = Convert.ToSingle(textBox1.Text);
            float sayi2 = System.Single.Parse(textBox2.Text);
            MessageBox.Show(Islem(sayi1, sayi2, '+').ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float sayi1 = Convert.ToSingle(textBox1.Text);
            float sayi2 = System.Single.Parse(textBox2.Text);
            MessageBox.Show(Islem(sayi1, sayi2, '-').ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            float sayi1 = Convert.ToSingle(textBox1.Text);
            float sayi2 = System.Single.Parse(textBox2.Text);
            MessageBox.Show(Islem(sayi1, sayi2, '*').ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float sayi1 = Convert.ToSingle(textBox1.Text);
            float sayi2 = System.Single.Parse(textBox2.Text);
            MessageBox.Show(Islem(sayi1, sayi2, '/').ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
