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
        Rectangle Alan;
        Bitmap Resim;
        Graphics Grafik;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Rectangle nesnesinin başlangıç koordinatlarını, genişlik ve yüksekliği 0 yaptık.
            Alan = new Rectangle(0, 0, 0, 0);
            Grafik = pictureBox2.CreateGraphics();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseButtons Dugme;
            Dugme = MouseButtons.Left;
            if( e.Button == Dugme)
            {
                Alan.X = e.X;
                Alan.Y = e.Y;
                Alan.Width = 0;
                Alan.Height = 0;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseButtons Dugme;
            Dugme = MouseButtons.Left;
            if( e.Button == Dugme)
            {
                Alan.Width = Math.Abs(Alan.Left - e.X);
                Alan.Height = Math.Abs(Alan.Top - e.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen Kalem;
            Kalem = new Pen(Color.Red, 2);
            e.Graphics.DrawRectangle(Kalem, Alan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resim = new Bitmap(Alan.Width, Alan.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Refresh();
            Grafik.DrawImage(pictureBox1.Image, 0, 0, Alan, GraphicsUnit.Pixel);
        }
    }
}
