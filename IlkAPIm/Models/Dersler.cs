using System;
using System.Collections.Generic;

#nullable disable

namespace IlkAPIm.Models
{
    public partial class Dersler
    {
        public Dersler()
        {
            DersOgrencis = new HashSet<DersOgrenci>();
        }

        public int Id { get; set; }
        public string DersKodu { get; set; }
        public string Ad { get; set; }
        public int Kontenjan { get; set; }
        public int? DHocaid { get; set; }

        public virtual Hocalar DHoca { get; set; }
        public virtual ICollection<DersOgrenci> DersOgrencis { get; set; }
    }
}
