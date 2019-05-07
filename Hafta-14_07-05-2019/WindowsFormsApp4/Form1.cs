using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firma = textBox1.Text;
            string telNo = textBox2.Text;
            for (int i = firma.Length; i < 50; i++)
                firma = firma.Insert(i, " ");
            for (int i = telNo.Length; i < 15; i++)
                telNo = telNo.Insert(i, " ");

            FileStream akis;
            saveFileDialog1.ShowDialog();
            string yol = saveFileDialog1.FileName;
            akis = new FileStream(yol, FileMode.Append, FileAccess.Write);
            StreamWriter yazma = new StreamWriter(akis);

            yazma.Write(firma); yazma.WriteLine();
            yazma.Write(telNo); yazma.WriteLine("\n");
            yazma.Close();
            textBox1.Text = textBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string yol = openFileDialog1.FileName;
            FileStream akis = new FileStream(yol, FileMode.Open, FileAccess.Read);
            StreamReader okuma = new StreamReader(yol);

            char karakter;
            int kod;
            string str = string.Empty;
            for (int i = 0; i < 50; i++)
            {
                //Read karakter olarak okuyup int döner
                kod = okuma.Read();
                karakter = (char)kod;
                str = str + karakter.ToString();
            }
            textBox1.Text = str.Trim();
            str = string.Empty;
            for (int i = 0; i < 15; i++)
            {
                kod = okuma.Read();
                karakter = (char)kod;
                str = str + karakter.ToString();
            }
            textBox2.Text = str.Trim();
            str = string.Empty;
        }
    }
}
