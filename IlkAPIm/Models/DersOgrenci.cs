using System;
using System.Collections.Generic;

#nullable disable

namespace IlkAPIm.Models
{
    public partial class DersOgrenci
    {
        public int AldigiDerslerid { get; set; }
        public int DOgrencilerid { get; set; }

        public virtual Dersler AldigiDersler { get; set; }
        public virtual Ogrenciler DOgrenciler { get; set; }
    }
}
