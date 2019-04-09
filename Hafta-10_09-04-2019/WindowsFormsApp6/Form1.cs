using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool Ciz;
        int x1, y1;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Ciz = true;
            x1 = e.X;
            y1 = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Ciz)
            {
                Graphics Cizim = this.CreateGraphics();
                Pen Kalem = new Pen(Color.Red, 2);
                Rectangle Kare = new Rectangle(x1, y1, e.X - x1, e.Y - y1);
                Cizim.Clear(this.BackColor);
                Cizim.DrawRectangle(Kalem, Kare);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Ciz = false;
        }
    }
}
