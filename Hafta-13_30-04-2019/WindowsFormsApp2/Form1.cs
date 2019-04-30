using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Örnek için özel başvurular:
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        StreamReader okuyucu;

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                okuyucu = new StreamReader(openFileDialog1.FileName);
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int satir_no = 0;
            float sol_bosluk = 30;
            float ust_bosluk = 30;
            float konum = 0;
            Font Yazi_tipi = new Font("Tahoma", 11, FontStyle.Regular);
            string satir = null;
            float sayfadaki_satir = e.MarginBounds.Height / Yazi_tipi.GetHeight();
            while((satir = okuyucu.ReadLine()) != null && satir_no < sayfadaki_satir)
            {
                konum = ust_bosluk + (satir_no * Yazi_tipi.GetHeight(e.Graphics));
                e.Graphics.DrawString(satir, Yazi_tipi, Brushes.Black, sol_bosluk, konum);
                satir_no++;
            }
            if (satir == null)
                e.HasMorePages = false;
            else
                e.HasMorePages = true;
        }

        // Formu yazdırmak için
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr Ptr1, IntPtr Ptr2, uint Sayi);

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap Resim = new Bitmap(1024, 768);
            Graphics g = Graphics.FromImage(Resim);
            IntPtr Ptr = g.GetHdc();
            PrintWindow(this.Handle, Ptr, 0);
            g.ReleaseHdc(Ptr);
            e.Graphics.DrawImage(Resim, 0, 0, Resim.Width, Resim.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument2.Print();
        }
    }
}
