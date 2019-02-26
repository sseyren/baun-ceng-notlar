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

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private static void revertMethod(Button button1, Button button2)
        {
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button1, button2);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button2, button3);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button3, button4);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button4, button5);
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button5, button6);
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button6, button7);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button7, button8);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button8, button9);
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            revertMethod(button9, button1);
        }
    }
}
