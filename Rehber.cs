using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE_1__Telefon_Rehberi_Uygulaması
{
    internal class Rehber
    {
        public string Isim  { get; set; }
        public string Soyisim { get; set; }

        public int TelNo { get; set; }

        public Rehber()
        {

        }

        public Rehber(string isim, string soyisim, int no)
        {
            this.Isim = isim;
            this.Soyisim = soyisim;
            this.TelNo = no;
            
            
        }
    }
}
