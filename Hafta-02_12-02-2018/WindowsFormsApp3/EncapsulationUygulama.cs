using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class EncapsulationUygulama
    {
        public string universite = "Balıkesir Üniversitesi";
        private string m_sehir = "Balıkesir";
        protected string bolum = "Bilgisayar Mühendisliği";
        public string Sehir
        {
            get { return m_sehir; }
            set { m_sehir = value; }
        }
    }
}
