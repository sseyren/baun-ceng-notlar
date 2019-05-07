using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            FileStream akis;
            openFileDialog1.ShowDialog();
            string metin = null, satir = null, yol = openFileDialog1.FileName;
            akis = new FileStream(yol, FileMode.Open, FileAccess.Read);
            StreamReader okuma = new StreamReader(akis);
            while (true)
            {
                satir = okuma.ReadLine();
                metin = metin + " " + satir;
                if (satir == null)
                    break;
            }
            MessageBox.Show(metin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream akis;
            saveFileDialog1.ShowDialog();
            string yol = saveFileDialog1.FileName;
            akis = new FileStream(yol, FileMode.Append, FileAccess.Write);
            StreamWriter yazma = new StreamWriter(akis);

            yazma.WriteLine("Ad-Soyad: " + textBox1.Text);
            yazma.WriteLine("Firma: " + textBox2.Text);
            yazma.WriteLine("Adres: " + textBox3.Text);
            yazma.WriteLine("Telefon No: " + textBox4.Text + "\n\n");
            yazma.Close();

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = null;
        }
    }
}
