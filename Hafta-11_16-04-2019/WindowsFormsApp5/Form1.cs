using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font Yazi_tipi = new Font("Tahoma", 12, FontStyle.Bold);
            e.Graphics.DrawString(label1.Text + " : " + textBox1.Text, Yazi_tipi, Brushes.Black, 100, 50);
            e.Graphics.DrawString(label2.Text + " : " + textBox2.Text, Yazi_tipi, Brushes.Blue, 100, 100);
            e.Graphics.DrawString(label3.Text + " : " + textBox3.Text, Yazi_tipi, Brushes.Red, 100, 150);
            e.Graphics.DrawString(label4.Text + " : " + textBox4.Text, Yazi_tipi, Brushes.YellowGreen, 100, 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument1.Print();
        }

        static int i = 0;

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int c = 52; // Kaç defa yazılacak
            int top = 50; // Üst boşluk
            Font fn = new Font("Arial", 10, FontStyle.Regular);
            // int W = printDocument2.DefaultPageSettings.PaperSize.Width;
            int H = printDocument2.DefaultPageSettings.PaperSize.Height;
            while (i < c)
            {
                e.Graphics.DrawString((i + 1) + ". işlem ", fn, Brushes.OrangeRed, 100, top);
                top += fn.Height;
                e.Graphics.DrawString(label1.Text + " : " + textBox1.Text, fn, Brushes.Black, 100, top);
                top += fn.Height;
                e.Graphics.DrawString(label2.Text + " : " + textBox2.Text, fn, Brushes.Blue, 100, top);
                top += fn.Height;
                e.Graphics.DrawString(label3.Text + " : " + textBox3.Text, fn, Brushes.Red, 100, top);
                top += fn.Height;
                e.Graphics.DrawString(label4.Text + " : " + textBox4.Text, fn, Brushes.YellowGreen, 100, top);
                top += fn.Height * 2;

                i++;
                H = H - (6 * fn.Height);
                if (H < 150)
                {
                    H = printDocument2.DefaultPageSettings.PaperSize.Height;
                    top = 50;
                    break;
                } // sayfa dolunca diğer sayfaya geçirir
            }

            // Çok sayfa kontrolü
            if (i < c)
                e.HasMorePages = true;
            else
            {
                e.HasMorePages = false;
                i = 0;
            }
        }

        private void printDocument2_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show("Yazdırma işlemi tamamlandı.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument2.Print();
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int X = printDocument3.DefaultPageSettings.Margins.Left;
            int Y = printDocument3.DefaultPageSettings.Margins.Top;

            int Genislik = pictureBox1.Width * 2;
            int Yukseklik = pictureBox1.Height * 2;

            e.Graphics.DrawImage(pictureBox1.Image, X, Y, Genislik, Yukseklik);

            // Resmin üzerine yazı yazdırabiliriz
            e.Graphics.DrawString("Üniversitenin Logosu", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, 200, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument3.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Önizleme
            printPreviewDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Sayfa yapısı
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
                printDocument2.DefaultPageSettings = pageSetupDialog1.PageSettings;
        }
    }
}
