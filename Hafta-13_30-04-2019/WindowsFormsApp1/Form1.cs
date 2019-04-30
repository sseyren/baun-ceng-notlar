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

        int satir_no = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font yazi_tipi = new Font("Tahoma", 11, FontStyle.Regular);
            int satir_sayisi, sayfadaki_satir, sayac = 1;
            string satir_metni;
            satir_sayisi = richTextBox1.Lines.Length;
            sayfadaki_satir = e.MarginBounds.Height / yazi_tipi.Height;

            while(satir_sayisi > satir_no)
            {
                satir_metni = richTextBox1.Lines[satir_no];
                sayac++;
                e.Graphics.DrawString(satir_metni, yazi_tipi, Brushes.Black, 50, 20 * sayac);
                satir_no++;
                if (sayac >= sayfadaki_satir)
                    break;
            }

            if (satir_no >= satir_sayisi)
                e.HasMorePages = false;
            else
            {
                sayac++;
                e.HasMorePages = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            printDocument1.Print();
        }
    }
}
