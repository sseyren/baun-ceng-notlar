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

        private string veri;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                veri += "Tercih = " + radioButton1.Text;
            if (radioButton2.Checked == true)
                veri += "Tercih = " + radioButton2.Text;
            if (radioButton3.Checked == true)
                veri += "Tercih = " + radioButton3.Text;
            veri += "\n";
            if (radioButton4.Checked == true)
                veri += "Cinsiyet = " + radioButton4.Text;
            if (radioButton5.Checked == true)
                veri += "Cinsiyet = " + radioButton5.Text;
            veri += "\n";
            if (radioButton6.Checked == true)
                veri += "Medeni Durum = " + radioButton6.Text;
            if (radioButton7.Checked == true)
                veri += "Medeni Durum = " + radioButton7.Text;

            Form2 f2 = new Form2(veri);
            f2.Visible = true;

            // Eğer Form1'in kapanmasını istiyorsak
            // this.Hide();
        }
    }
}
