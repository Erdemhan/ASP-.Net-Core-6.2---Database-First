using System;
using System.Collections.Generic;

#nullable disable

namespace IlkAPIm.Models
{
    public partial class Hocalar
    {
        public Hocalar()
        {
            Derslers = new HashSet<Dersler>();
        }

        public int Id { get; set; }
        public int PersNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DTarihi { get; set; }

        public virtual ICollection<Dersler> Derslers { get; set; }
    }
}
