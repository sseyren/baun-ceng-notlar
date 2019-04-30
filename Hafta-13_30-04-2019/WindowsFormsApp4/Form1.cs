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

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            /*
            if (e.KeyState == 1)
                e.Effect = DragDropEffects.Move;
            */
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point nokta = new Point(e.X, e.Y);
            int sira = listBox1.IndexFromPoint(nokta);
            if(sira == -1)
            {
                MessageBox.Show("Eleman olmayan bir yeri seçemezsiniz.");
                return;
            }
            if (e.Button == MouseButtons.Left)
                listBox1.DoDragDrop(listBox1.Items[sira].ToString(), DragDropEffects.All);
        }

        private void listBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
                e.Effect = DragDropEffects.All;
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string eleman = Convert.ToString(e.Data.GetData(DataFormats.Text));
            listBox2.Items.Add(eleman);

            // Seçilen elemanı silmek istiyorsak:
            listBox1.Items.Remove(eleman);
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
                e.Effect = DragDropEffects.Move;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string eleman = Convert.ToString(e.Data.GetData(DataFormats.Text));
            textBox1.Text = eleman;

            // Seçilen elemanı silmek istiyorsak:
            listBox1.Items.Remove(eleman);
        }
    }
}
