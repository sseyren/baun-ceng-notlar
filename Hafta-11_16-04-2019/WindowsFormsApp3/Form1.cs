using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool Ciz;
        int X1, Y1;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Ciz = true;
            X1 = e.X;
            Y1 = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen Kalem = new Pen(Color.Blue, 3);
            Point Nokta1 = new Point(X1, Y1);
            Point Nokta2 = new Point(e.X, e.Y);
            Graphics Cizgi = this.CreateGraphics();
            if (Ciz)
            {
                Cizgi.DrawLine(Kalem, Nokta1, Nokta2);
                X1 = e.X;
                Y1 = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Ciz = false;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Graphics Cizgi = this.CreateGraphics();
            Cizgi.Clear(this.BackColor);
        }
    }
}
