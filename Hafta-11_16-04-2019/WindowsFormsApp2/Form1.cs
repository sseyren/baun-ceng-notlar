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

        int i = 0;
        Font Yazi_tipi;
        SolidBrush Renk;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics Yazi = this.CreateGraphics();
            Yazi.Clear(this.BackColor);

            /*
             * Bellir bir formatta istiyorsak aşağıdaki gibi kullanılabilir:
             * Font Yazi_tipi = new Font("Arial", 12, FontStyle.Bold);
             * SolidBrush Renk = new SolidBrush(Color.Blue);
             * 
             * Eğer yazının belirli bir açı ile yazılmasını istiyorsak
             * Yazi.RotateTransform(45);
             */

            if (i == 0)
            {
                fontDialog1.ShowDialog();
                Yazi_tipi = new Font(fontDialog1.Font.Name, fontDialog1.Font.Size, fontDialog1.Font.Style);
                colorDialog1.ShowDialog();
                Renk = new SolidBrush(colorDialog1.Color);
            }

            Point Koordinat = new Point(e.X, e.Y);
            Yazi.DrawString(textBox1.Text, Yazi_tipi, Renk, Koordinat);
            i++;
        }
    }
}
