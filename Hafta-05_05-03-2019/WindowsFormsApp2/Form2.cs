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
    public partial class Form2 : Form
    {
        string uyari, uyari2;
        public Form2(string veri)
        {
            InitializeComponent();
            this.uyari = veri;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox1.ForeColor = Color.Green;
            else
                checkBox1.ForeColor = Color.Red;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox2.ForeColor = Color.Green;
            else
                checkBox2.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                uyari2 += checkBox1.Text + "\n";
            if (checkBox2.Checked == true)
                uyari2 += checkBox2.Text + "\n";
            if (checkBox3.Checked == true)
                uyari2 += checkBox3.Text + "\n";
            if (checkBox4.Checked == true)
                uyari2 += checkBox4.Text + "\n";
            if (checkBox5.Checked == true)
                uyari2 += checkBox5.Text + "\n";
            if (checkBox6.Checked == true)
                uyari2 += checkBox6.Text + "\n";
            if (checkBox7.Checked == true)
                uyari2 += checkBox7.Text + "\n";
            if (checkBox8.Checked == true)
                uyari2 += checkBox8.Text + "\n";

            MessageBox.Show(uyari + "\n\nHobiler = \n" + uyari2);
        }
    }
}
