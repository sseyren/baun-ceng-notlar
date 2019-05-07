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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { progressBar1.Value = textBox1.TextLength; }
            catch
            {
                MessageBox.Show("Yükleme tamamlanmıştır.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar2.Maximum = 100;
            progressBar2.Minimum = 0;
            label1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0;
            progressBar2.Step = 1;
            int i;
            for (i = 0; i < progressBar2.Maximum; i++)
            {
                label1.Text = "%" + i.ToString();
                progressBar2.PerformStep();
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
            if (progressBar2.Value == 100)
            {
                MessageBox.Show("Yükleme tamamlandı.");
                progressBar2.Value = 0;
                i = 0;
                label1.Text = "%" + i.ToString();
            }
        }
    }
}
