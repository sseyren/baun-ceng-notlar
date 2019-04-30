using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Path için gerekli:
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // textBox1'in MultiLine ve AllowDrop özelliklerini true yaparız.
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            // Panoda (sürüklenen) herhangi bir şey var mo diye kontrol ediliyor.
            // Eğer panoda dosyalarla ilgili bilgi varsa aşağıdaki metod true döner.

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            Array dizi = (Array)e.Data.GetData(DataFormats.FileDrop);
            if(dizi != null)
            {
                string ilk_dosya = dizi.GetValue(0).ToString();
                string uzanti = Path.GetExtension(ilk_dosya);
                if (uzanti == ".txt")
                {
                    StreamReader okuma = new StreamReader(ilk_dosya);
                    textBox1.Text = okuma.ReadToEnd();
                    okuma.Close();
                }
                else
                    MessageBox.Show("Dosya tipi uygun değil");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.AllowDrop = true;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Array dizi = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (dizi != null)
            {
                string resim = dizi.GetValue(0).ToString();
                string uzanti = Path.GetExtension(resim);
                if (uzanti == ".jpg")
                    pictureBox1.Load(resim);
                else
                    MessageBox.Show("Resim formatı uygun değil.");
            }
        }
    }
}
