namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dirListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.dirListBox2 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.fileListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.fileListBox2 = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.SuspendLayout();
            // 
            // dirListBox1
            // 
            this.dirListBox1.AllowDrop = true;
            this.dirListBox1.FormattingEnabled = true;
            this.dirListBox1.IntegralHeight = false;
            this.dirListBox1.Location = new System.Drawing.Point(12, 12);
            this.dirListBox1.Name = "dirListBox1";
            this.dirListBox1.Size = new System.Drawing.Size(212, 146);
            this.dirListBox1.TabIndex = 0;
            this.dirListBox1.Change += new System.EventHandler(this.dirListBox1_Change);
            // 
            // dirListBox2
            // 
            this.dirListBox2.AllowDrop = true;
            this.dirListBox2.FormattingEnabled = true;
            this.dirListBox2.IntegralHeight = false;
            this.dirListBox2.Location = new System.Drawing.Point(230, 12);
            this.dirListBox2.Name = "dirListBox2";
            this.dirListBox2.Size = new System.Drawing.Size(212, 146);
            this.dirListBox2.TabIndex = 1;
            this.dirListBox2.Change += new System.EventHandler(this.dirListBox2_Change);
            // 
            // fileListBox1
            // 
            this.fileListBox1.AllowDrop = true;
            this.fileListBox1.FormattingEnabled = true;
            this.fileListBox1.Location = new System.Drawing.Point(12, 164);
            this.fileListBox1.Name = "fileListBox1";
            this.fileListBox1.Pattern = "*.*";
            this.fileListBox1.Size = new System.Drawing.Size(212, 134);
            this.fileListBox1.TabIndex = 2;
            this.fileListBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileListBox1_MouseDown);
            // 
            // fileListBox2
            // 
            this.fileListBox2.AllowDrop = true;
            this.fileListBox2.FormattingEnabled = true;
            this.fileListBox2.Location = new System.Drawing.Point(230, 164);
            this.fileListBox2.Name = "fileListBox2";
            this.fileListBox2.Pattern = "*.*";
            this.fileListBox2.Size = new System.Drawing.Size(212, 134);
            this.fileListBox2.TabIndex = 3;
            this.fileListBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileListBox2_DragDrop);
            this.fileListBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.fileListBox2_DragOver);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 310);
            this.Controls.Add(this.fileListBox2);
            this.Controls.Add(this.fileListBox1);
            this.Controls.Add(this.dirListBox2);
            this.Controls.Add(this.dirListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox2;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.FileListBox fileListBox2;
    }
}

