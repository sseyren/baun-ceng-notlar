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

        private void Form1_Load(object sender, EventArgs e)
        {
            fileListBox1.Path = dirListBox1.Path;
            fileListBox2.Path = dirListBox2.Path;
        }

        private void dirListBox1_Change(object sender, EventArgs e)
        {
            fileListBox1.Path = dirListBox1.Path;
        }

        private void dirListBox2_Change(object sender, EventArgs e)
        {
            fileListBox2.Path = dirListBox2.Path;
        }

        private void fileListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point kor_nokta = new Point(e.X, e.Y);
            int sira = fileListBox1.IndexFromPoint(kor_nokta);
            if (sira == -1)
            {
                MessageBox.Show("Dosya olmayan yeri tıkladınız.");
                return;
            }
            if (e.Button == MouseButtons.Left)
                fileListBox1.DoDragDrop(fileListBox1.FileName, DragDropEffects.All);
        }

        private void fileListBox2_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
                e.Effect = DragDropEffects.All;
        }

        private void fileListBox2_DragDrop(object sender, DragEventArgs e)
        {
            string kaynak = dirListBox1.Path + "\\" + fileListBox1.FileName;
            string hedef = dirListBox2.Path + "\\" + fileListBox1.FileName;
            System.IO.File.Copy(kaynak, hedef);
            fileListBox2.Refresh();
        }
    }
}
