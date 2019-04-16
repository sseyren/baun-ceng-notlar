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

        int i = 0;
        Graphics Cizim;
        Image Resim;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (i == 0)
            {
                // Image nesnesinin içeriğini Graphics nesnesi üzerinde görüntülemek için DrawImage metodu kullanılır.
                openFileDialog1.ShowDialog();
                Cizim = this.CreateGraphics();
                Cizim.Clear(this.BackColor);
                Resim = Image.FromFile(openFileDialog1.FileName);
            }
            if (i % 2 == 0)
            {
                Cizim.Clear(this.BackColor);
                Point Nokta = new Point(e.X, e.Y);
                Cizim.DrawImage(Resim, Nokta);
                // DrawImage metodu Image nesnesini ve Image nesnesinin görüntüleneceği yerin sol üst noktasını parametre olarak alır.
            }
            else
            {
                Cizim.Clear(this.BackColor);
                Rectangle kare = new Rectangle(e.X, e.Y, 50, 50);
                Cizim.DrawImage(Resim, kare);
                /*
                 * DrawImage metoduna Rectangle nesnesi parametre olarak verilirse
                 * Image nesnesinin içeriği Rectangle nesnesi ile sınırlanan alanda görüntülenir.
                 */
            }
            i++;
        }
    }
}
