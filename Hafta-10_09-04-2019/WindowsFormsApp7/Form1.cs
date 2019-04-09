using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Pen Kalem = new Pen(Color.Blue, 3);
            SolidBrush Firca = new SolidBrush(Color.Red);
            Graphics Daire = this.CreateGraphics();
            Daire.Clear(this.BackColor);
            if(e.Button == MouseButtons.Left)
            {
                Daire.DrawPie(Kalem, e.X, e.Y,
                    Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text), 
                    Convert.ToInt32(textBox3.Text), 
                    Convert.ToInt32(textBox4.Text));
            }
            else if(e.Button == MouseButtons.Right)
            {
                Daire.FillPie(Firca, e.X, e.Y,
                    Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text),
                    Convert.ToInt32(textBox4.Text));
            }
            else if(e.Button == MouseButtons.Middle)
            {
                Kalem.Color = Color.Turquoise;
                Daire.DrawArc(Kalem, e.X, e.Y,
                    Convert.ToInt32(textBox1.Text),
                    Convert.ToInt32(textBox2.Text),
                    Convert.ToInt32(textBox3.Text),
                    Convert.ToInt32(textBox4.Text));
            }
        }
    }
}
