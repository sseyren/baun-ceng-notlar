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

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Yellow;
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToUpper();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bu alanı boş geçemezsiniz.");
                e.Cancel = true;
            }
            // Rakam girilemez
            string str = "0123456789";
            string str2 = textBox2.Text;
            foreach(char c1 in str)
                foreach(char c2 in str2)
                    if(c1 == c2)
                    {
                        MessageBox.Show("Bu alana rakam girilemez.");
                        textBox2.Text = "";
                        e.Cancel = true;
                        return;
                    }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

            string tus = e.KeyChar.ToString();
            textBox4.Text += tus;
            if (e.KeyChar == 27)
                MessageBox.Show("ESC tuşuna bastınız.");
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Space)
            {
                MessageBox.Show("Boşluk girmeyiniz");
                textBox5.Text = textBox5.Text.Trim();
                textBox5.SelectionStart = textBox5.Text.Length;
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ControlKey && e.Alt == true)
            {
                MessageBox.Show("Ctrl+Alt tuşuna bastınız.");
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("KeyValue\t= " + e.KeyValue.ToString() + "\n" + "KeyCode\t= " + e.KeyCode.ToString() + "\n" + "KeyData\t=" + e.KeyData.ToString());
        }
    }
}
