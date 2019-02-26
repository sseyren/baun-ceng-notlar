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
        int s1, s2;
        float sonuc;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // int s1, s2;
                s1 = Convert.ToInt32(textBox1.Text);
                s2 = Convert.ToInt32(textBox2.Text);
                sonuc = s1 + s2;
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = Convert.ToInt32(textBox1.Text);
                s2 = Convert.ToInt32(textBox2.Text);
                sonuc = s1 - s2;
                MessageBox.Show("Çıkarma sonucu = " + sonuc.ToString());
            }
            catch(FormatException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("Hatalı türde veri girişi!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = Convert.ToInt32(textBox1.Text);
                s2 = Convert.ToInt32(textBox2.Text);
                sonuc = s1 * s2;
                MessageBox.Show("Çarpma sonucu = " + sonuc.ToString());
            }
            catch(FormatException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("Hatalı türde veri girişi!");
            }
            catch(OverflowException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("Veri-tipi aşma durumu!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = Convert.ToInt32(textBox1.Text);
                s2 = Convert.ToInt32(textBox2.Text);
                sonuc = (float)s1 / s2;
                MessageBox.Show("Bölme sonucu = " + sonuc.ToString());
            }
            catch (FormatException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("Hatalı türde veri girişi!");
            }
            catch (OverflowException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("Veri-tipi aşma durumu!");
            }
            catch (DivideByZeroException hata)
            {
                MessageBox.Show(hata.ToString());
                MessageBox.Show("0'a bölünme durumu!");
            }
            finally
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }
}
