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

        private void Uyari()
        {
            MessageBox.Show("Bu alanı boş geçemesiniz.");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                Uyari();
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = "0123456789";
            if (str.IndexOf(e.KeyChar) != -1)
                e.KeyChar = '\0';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
            // veya
            //  e.KeyChar = '\0';
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                Uyari();
                textBox3.Focus();
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.Green;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.Magenta;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && (e.KeyChar < '0' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 31 && (e.KeyChar < '0' || e.KeyChar > '9'))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text + "\n" + textBox2.Text + "\n" + textBox3.Text + "\n" + textBox4.Text + "\n" + textBox5.Text + "\n" + maskedTextBox1.Text + "\n" + textBox6.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program TextBox kullanımına bir örnektir.");
            Application.Idle += new EventHandler(TextBox_Select);
        }
        
        private void TextBox_Select(object sender, EventArgs e)
        {
            int counter = this.Controls.Count;
            for (int i = 0; i < counter; i++)
            {
                if (this.ActiveControl == this.Controls[i])
                    this.Controls[i].BackColor = Color.Yellow;
                else
                    this.Controls[i].BackColor = Color.White;
            }
        }
    }
}
