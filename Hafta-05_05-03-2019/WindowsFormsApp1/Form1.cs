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

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            richTextBox2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox2.SelectionFont = fontDialog1.Font;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox2.SelectionColor = colorDialog1.Color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox2.SelectionBackColor = colorDialog1.Color;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string Dosya = openFileDialog1.FileName;
            Bitmap resim = new Bitmap(Dosya);
            Clipboard.SetDataObject(resim);
            richTextBox2.Paste();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string Dosya = saveFileDialog1.FileName;
            richTextBox2.SaveFile(Dosya, RichTextBoxStreamType.PlainText);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            string aranan = textBox1.Text;
            int sonuc = richTextBox1.Text.IndexOf(aranan, 0);
            if (sonuc == -1)
                MessageBox.Show("Aranan kelime bulunamadı.");
            else
            {
                richTextBox1.Focus();
                richTextBox1.Select(sonuc, aranan.Length);
            }*/

            // RichTextBoxFinds.WholeWord kullanılırsa aranan tam kelime bulunur.
            // RichTextBoxFinds.MatchCase kullanılırsa aramada büyük küçük harf ayrımı yapılır.

            richTextBox1.Focus();
            int sonuc = richTextBox1.Find(textBox1.Text, RichTextBoxFinds.WholeWord);
            if (sonuc == -1)
                MessageBox.Show("Aranan kelime bulunamadı.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            int konum = richTextBox1.Find(textBox1.Text, richTextBox1.SelectionStart + 1, RichTextBoxFinds.WholeWord);
            if (konum == -1)
                MessageBox.Show("Başka bulunamadı.");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Find() metodu ile aranıp bulunan metin, RichTextBox aktif kontrol
            // değilken seçilip ters renge boyanmasını istersek
            // HideSelection özelliğini false yapmalısınız.

            // ya da bunun yerine richTextBox1.Focus(); ile aktif nesne belirlenmelidir.
            richTextBox1.HideSelection = false;
            int sonuc = richTextBox1.Find(textBox1.Text, RichTextBoxFinds.WholeWord);
            if (sonuc == -1)
                MessageBox.Show("Aranan kelime bulunamadı.");

            int konum;
            string aranan = textBox1.Text;
            if (richTextBox1.SelectedText == textBox1.Text)
            {
                richTextBox1.SelectedText = textBox2.Text;
                konum = richTextBox1.Find(aranan, 0, RichTextBoxFinds.WholeWord);
                if (konum == -1)
                    MessageBox.Show("Başka bulunamadı.");
            }
        }
    }
}
