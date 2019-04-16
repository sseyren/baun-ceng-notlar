using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        int i = 0, k = 0, s = 0;
        Point[] Cizgi = new Point[5];
        SolidBrush Firca;

        //Belirli bir bölge bir desen ile boyanmak isteniyorsa HatchBrush kullanılır.
        HatchBrush Firca2;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Cizgi[i].X = e.X;
            Cizgi[i].Y = e.Y;
            i++;
            i = i % 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // İçi dolu şekil
            k = k % 3;
            Graphics Grafik = this.CreateGraphics();
            if (k == 0)
                Firca = new SolidBrush(Color.Blue);
            if (k == 1)
                Firca = new SolidBrush(Color.Red);
            if (k == 2)
                Firca = new SolidBrush(Color.Black);
            Grafik.FillClosedCurve(Firca, Cizgi);
            k++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Desenli çizim
            Graphics Grafik = this.CreateGraphics();
            Firca2 = new HatchBrush(HatchStyle.DarkHorizontal, Color.Brown, Color.DarkGray);
            Grafik.FillClosedCurve(Firca2, Cizgi);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // En az 4 nokta seçilmelidir
            Graphics Poligon = this.CreateGraphics();
            Pen Kalem = new Pen(Color.Blue, 3);
            Firca = new SolidBrush(Color.Chartreuse);
            if (s % 2 == 0)
            {
                Poligon.Clear(this.BackColor);
                Poligon.DrawPolygon(Kalem, Cizgi);
            }
            else
            {
                Poligon.Clear(this.BackColor);
                Poligon.FillPolygon(Firca, Cizgi);
            }
            s++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics Grafik = this.CreateGraphics();
            Grafik.Clear(this.BackColor);
        }
    }
}
