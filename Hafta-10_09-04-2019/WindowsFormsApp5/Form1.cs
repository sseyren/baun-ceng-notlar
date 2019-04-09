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

        bool Ciz;
        int x1, x2, y1, y2;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Ciz = true;
            x1 = e.X;
            y1 = e.Y;
            x2 = 0;
            y2 = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(Ciz == true)
            {
                x2 = e.X;
                y2 = e.Y;
            }
            else
                x1 = x2 = y1 = y2 = 0;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics Cizim = this.CreateGraphics();
            Pen Kalem = new Pen(Color.Red, 2);
            Rectangle Kare = new Rectangle(x1, y1, x2 - x1, y2 - y1);
            Cizim.Clear(this.BackColor);
            Cizim.DrawRectangle(Kalem, Kare);
            x1 = x2 = y1 = y2 = 0;
            Ciz = false;
        }
    }
}
