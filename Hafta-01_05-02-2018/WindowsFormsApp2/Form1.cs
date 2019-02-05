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

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                this.Text = "Sonsuz Döngü";
                // Aşağıdaki satır olmadan sonsuz döngüden çıkılamaz.
                Application.DoEvents();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Çalışma Durduruldu";
            MessageBox.Show("Buton aktif");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sayi = 0, sonuc = 1;
            while(sayi < sonuc)
            {
                sonuc += 1;
                this.Text = sonuc.ToString();
                Application.DoEvents();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
