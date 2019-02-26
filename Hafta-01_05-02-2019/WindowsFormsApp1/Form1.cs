using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string veri = textBox1.Text;
            if (veri != "")
                MessageBox.Show("Merhaba " + veri);
            else
                MessageBox.Show("İçi boş :/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string veri = textBox1.Text;
            switch (veri)
            {
                case "Makine":
                    MessageBox.Show("Mühendislik Fakültesi");
                    break;
                case "İşletme":
                    MessageBox.Show("İktisadi ve İdari Bilimler Fakültesi");
                    break;
                case "Matematik":
                    MessageBox.Show("Fen-Edebiyat Fakültesi");
                    break;
                default:
                    MessageBox.Show("Fakülte anlaşılmadı...");
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 9; i>4; i--)
            {
                label1.Text += i.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string veri = "";
            int[] Dizi = { 0, 5, 7, 2, 9, 4, 6, 48 };
            foreach(int i in Dizi)
            {
                veri += i.ToString();
                veri += " ";
            }
            MessageBox.Show(veri);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            i = 0;
        }
        int[] Dizi = { 2, 9, 4, 6, 48, 0, 5, 7 };
        int i = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            if(i < Dizi.Length)
            {
                label1.Text += Dizi[i].ToString() + " ";
                i++;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach(char karakter in textBox2.Text)
            {
                listBox1.Items.Add(karakter);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "BAUN")
                listBox1.Items.Add("İsim doğru!");
            else
                listBox1.Items.Add("HATALI");
        }
    }
}
