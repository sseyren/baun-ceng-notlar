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

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni dosya açılıyor");
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kaydet");
        }

        private void pencere1ToolStripMenuItem_Click(object sender, EventArgs e) => 
            pencere1ToolStripMenuItem.Checked = (pencere1ToolStripMenuItem.Checked) ? false : true;

        private void pencere2ToolStripMenuItem_Click(object sender, EventArgs e) =>
            pencere2ToolStripMenuItem.Checked = (pencere2ToolStripMenuItem.Checked) ? false : true;

        private void pencere3ToolStripMenuItem_Click(object sender, EventArgs e) =>
            pencere3ToolStripMenuItem.Checked = (pencere3ToolStripMenuItem.Checked) ? false : true;

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Add("Dikey");
            toolStripComboBox1.Items.Add("Yatay");

            toolStripComboBox2.Items.Add("İtalik");
            toolStripComboBox2.Items.Add("Altı Çizili");

            toolStripComboBox3.Items.Add("Mühendislik Fakültesi");
            toolStripComboBox3.Items.Add("Veterinerlik Fakültesi");
            toolStripComboBox3.Items.Add("Turizm Fakültesi");
            toolStripComboBox3.Items.Add("Edebiyat Fakültesi");

            // ComboBox
            /*
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection veri = new AutoCompleteStringCollection();

            veri.Add("Bilgisayar Mühendisliği");
            veri.Add("Elektrik-Elektronik Mühendisliği");
            veri.Add("Makine Mühendisliği");
            veri.Add("İnşaat Mühendisliği");
            comboBox1.AutoCompleteCustomSource = veri;
            */

            // Belirli bir tarih aralığı vermek için
            dateTimePicker1.MinDate = Convert.ToDateTime("01.01.2010");
            dateTimePicker1.MaxDate = Convert.ToDateTime("31.12.2020");

            label2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem.ToString());   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int deger = comboBox1.SelectedIndex;
            MessageBox.Show(deger.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int deger = comboBox1.FindString(textBox1.Text);
            MessageBox.Show(deger.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            label1.Text = time.ToLongTimeString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = dateTimePicker1.Text;
        }
    }
}
