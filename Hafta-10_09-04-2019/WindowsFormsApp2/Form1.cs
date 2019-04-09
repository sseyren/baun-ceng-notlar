using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap Resim;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string Dosya = openFileDialog1.FileName;
            Resim = new Bitmap(Dosya);
            pictureBox1.Image = Resim;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bitmap nesnesinin her biti üzerinde işlem yaparken GraphicsUnit nesnesine ihtiyaç vardır.
            GraphicsUnit grafik = GraphicsUnit.Pixel;
            // Resmin bit haritası için RectangleF nesnesi gerekli.
            RectangleF Harita = Resim.GetBounds(ref grafik);
            int Genislik = (int)Harita.Width;
            int Yükseklik = (int)Harita.Height;
            // GetPixel() metodu ile sözkonusu pixelin renk özelliklerini okuyup Color nesnesine aktaralım.
            for (int i = 0; i < Genislik; i++)
            {
                for (int j = 0; j < Yükseklik; j++)
                {
                    Color piksel = Resim.GetPixel(i, j);
                    // Resimdeki mavi rengi %50 azaltalım.
                    Resim.SetPixel(i, j, Color.FromArgb(piksel.R, piksel.G, piksel.B / 2));
                }
            }
            pictureBox2.Image = Resim;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GraphicsUnit grafik = GraphicsUnit.Pixel;
            RectangleF Harita = Resim.GetBounds(ref grafik);
            int Genislik = (int)Harita.Width;
            int Yükseklik = (int)Harita.Height;
            for (int i = 0; i < Genislik; i++)
            {
                for (int j = 0; j < Yükseklik; j++)
                {
                    Color piksel = Resim.GetPixel(i, j);
                    int Renk = (piksel.R + piksel.G + piksel.B) / 3;
                    Resim.SetPixel(i, j, Color.FromArgb(Renk, Renk, Renk));
                }
            }
            pictureBox2.Image = Resim;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }
    }
}
