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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = textBox2.Text;
            textBox2.Text = textBox1.Text;
            textBox1.Text = tmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sonuc.Text=(int.Parse(sayi1.Text) + int.Parse(sayi2.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sonuc.Text = (int.Parse(sayi1.Text) - int.Parse(sayi2.Text)).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sonuc.Text = (int.Parse(sayi1.Text) * int.Parse(sayi2.Text)).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sonuc.Text = (int.Parse(sayi1.Text) / int.Parse(sayi2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(textBox4.Text); i++)
            {
                textBox7.AppendText(textBox3.Text + "\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = (Math.Pow(int.Parse(textBox5.Text), 2) * Math.PI).ToString();
        }
    }
}
