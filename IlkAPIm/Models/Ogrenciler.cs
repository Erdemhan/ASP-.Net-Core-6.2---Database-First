using System;
using System.Collections.Generic;

#nullable disable

namespace IlkAPIm.Models
{
    public partial class Ogrenciler
    {
        public Ogrenciler()
        {
            DersOgrencis = new HashSet<DersOgrenci>();
        }

        public int Id { get; set; }
        public int OgrNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DTarihi { get; set; }

        public virtual ICollection<DersOgrenci> DersOgrencis { get; set; }
    }
}
