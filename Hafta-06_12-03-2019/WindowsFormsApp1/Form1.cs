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
            // Aynı elemanı tekrar etmek istemiyorsak
            bool sonuc = listBox1.Items.Contains(textBox1.Text);
            if(textBox1.Text != "")
            {
                if (sonuc == false)
                    listBox1.Items.Add(textBox1.Text);
                else
                    MessageBox.Show("Bu eleman mevcut");
            }
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Seçimlerin hepsini bir defada silmek için while döngüsü gereklidir.
            while (listBox1.SelectedItems.Count > 0)
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sayi = listBox1.SelectedItems.Count;
            for (int i = 0; i < sayi; i++)
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);
            }

            // Seçimleri temizlemek için aşağıdaki bölüm uygulanır.
            int sayi2 = listBox1.Items.Count;
            for (int i = 0; i < sayi2; i++)
                listBox1.SetSelected(i, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private int sonuc = -1;
        private void button5_Click(object sender, EventArgs e)
        {
            sonuc = listBox1.FindStringExact(textBox2.Text, sonuc + 1);
            if (sonuc < 0)
                MessageBox.Show("Bu eleman mevcut değil");
            else
            {
                listBox1.SelectedIndex = sonuc;
                MessageBox.Show(sonuc.ToString() + ". eleman");
            }
        }
    }
}
