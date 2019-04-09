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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics Cizim = this.CreateGraphics();
            // Eğer formun üzerinde çizim yerini pictureBox istersek `picturebox1.CreateGraphics()` yazmalıyız.

            // Bir çizim nesnesi hazırlayalım.
            Pen Kalem = new Pen(Color.Blue, 3);
            Cizim.DrawRectangle(Kalem, 20, 20, 80, 80);
            // Cizim.Dispose() -> Yıkıcı metod

            // Graphics nesnesi üretmeden "e" adlı PaintEventArgs parametresi ile çizim gerçekleştirilebilir.
            // e.Graphics.DrawRectangle(Kalem, 20, 20, 80, 80);

            // Şimdide içi dolu bir dikdörtgen çizelim.
            Graphics Cizim2 = this.CreateGraphics();
            SolidBrush Firca = new SolidBrush(Color.Green);
            Cizim2.FillRectangle(Firca, 120, 20, 80, 80);
            // Cizim2.Dispose(); -> Yıkıcı metod

            // Daire veya elips çizmek
            Graphics Daire = this.CreateGraphics();
            Kalem = new Pen(Color.Red, 3);
            // 4. ve 5. parametreler eşit olursa daire çizilir.
            Daire.DrawEllipse(Kalem, 220, 20, 100, 60);
            // Daire.Dispose();
        }
    }
}
