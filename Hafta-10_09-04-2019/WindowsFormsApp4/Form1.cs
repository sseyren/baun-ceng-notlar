using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics Daire = this.CreateGraphics();
            Daire.Clear(this.BackColor);
            Pen Kalem = new Pen(Color.Blue, 3);
            Daire.DrawEllipse(Kalem, e.X - 50, e.Y - 50, 100, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics Daire = this.CreateGraphics();
            Daire.Clear(this.BackColor);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics Daire;
            Daire = this.CreateGraphics();
            Daire.Clear(this.BackColor);
            int Genislik = this.ClientSize.Width;
            int Yukseklik = this.ClientSize.Height;

            Random Rastgele = new Random();
            int X = Rastgele.Next(Genislik - 100);
            int Y = Rastgele.Next(Yukseklik - 100);
            /*
            Pen Kalem = new Pen(Color.Blue, 3);
            Daire.DrawEllipse(Kalem, X, Y, 100, 100);
            */
            SolidBrush Firca = new SolidBrush(Color.Green);
            Daire.FillEllipse(Firca, X, Y, 100, 100);
        }
    }
}
