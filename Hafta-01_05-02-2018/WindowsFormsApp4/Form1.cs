using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Sayilar = { 10, 40, -8, 81, 6, 21 };
            MessageBox.Show(Sayilar[rnd.Next(Sayilar.Length)].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] isimler = { "Ahmet", "Mehmet", "Ayşe", "Mustafa", "Fatma" };
            MessageBox.Show(isimler[rnd.Next(isimler.Length)]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[,] Dizi = new string[3, 2] { { "A", "B" }, { "C", "D" }, { "E", "F" } };
            MessageBox.Show(Dizi[rnd.Next(3), rnd.Next(2)]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[][] DuzensizDizi = new string[3][];
            DuzensizDizi[0] = new string[4];
            DuzensizDizi[1] = new string[2];
            DuzensizDizi[2] = new string[1];

            DuzensizDizi[0][0] = "Ahmet";
            DuzensizDizi[0][1] = "Mehmet";
            DuzensizDizi[0][2] = "Fatih";
            DuzensizDizi[0][3] = "Murat0";

            DuzensizDizi[1][0] = "Ali";
            DuzensizDizi[1][1] = "Ömer";

            DuzensizDizi[2][0] = "Ayşe";

            MessageBox.Show(DuzensizDizi[rnd.Next(3)][0]);
        }
    }
}
