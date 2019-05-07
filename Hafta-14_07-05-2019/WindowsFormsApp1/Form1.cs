using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Formun üzerine sürüklediğimiz bir dosyayı seçeceğimiz yere kayıt etme
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Panoya ilk dosyanın adını alıyoruz
            Array dizi = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (dizi != null)
            {
                string ilk_dosya = dizi.GetValue(0).ToString();
                saveFileDialog1.FileName = ilk_dosya;
                saveFileDialog1.ShowDialog();
                System.IO.File.Copy(ilk_dosya, saveFileDialog1.FileName);
            }
        }
    }
}
