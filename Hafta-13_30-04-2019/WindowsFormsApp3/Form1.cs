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

        int sira;

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point nokta = new Point(e.X, e.Y);
            // ListBox içinde tıklanan elemanın sıra numarası için
            sira = listBox1.IndexFromPoint(nokta);
            // Boş bir yer seçilmemesi için
            if(sira == -1)
            {
                MessageBox.Show("Eleman olmayan bir yeri seçemezsiniz.");
                return;
            }
            if (e.Button == MouseButtons.Left)
                listBox1.DoDragDrop(listBox1.Items[sira].ToString(), DragDropEffects.All);
        }

        // Elemanın ilk ListBox'tan 2. ListBox'ın üzerine gitmesi
        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            /* KeyState değerlerinin anlamları:
             * 1 - Sol tık basılı
             * 2 - Sağ tık basılı
             * 5 - Shift tuşu ile birlikte basılı (1+4)
             * 9 - Ctrl tuşu ile birlikte basılı (1+8)
             */
            if (e.KeyState == 1)
                e.Effect = DragDropEffects.All;
        }

        // Sol tık'ın 2. ListBox'ın üzerinde iken serbest bırakılması
        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.ClearSelected();
            listBox2.Items.Add(listBox1.Items[sira]);

            // Sürüklediğimizin 1. ListBox içinden silinmesi için:
            listBox1.Items.Remove(listBox1.Items[sira]);
        }
    }
}
