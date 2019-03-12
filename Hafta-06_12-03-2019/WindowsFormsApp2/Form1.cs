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

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (checkedListBox1.CheckedItems.Count > 0)
                checkedListBox1.Items.Remove(checkedListBox1.CheckedItems[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                string secimler = string.Empty;
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    secimler += (i + 1).ToString() + ". " + checkedListBox1.CheckedItems[i].ToString() + "\n";
                MessageBox.Show(secimler);
            }
            else
                MessageBox.Show("Hiç seçim yapılmadı.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool tumunuSec = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                checkedListBox1.SetItemChecked(i, tumunuSec);
        }
    }
}
