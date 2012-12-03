using System;
using System.Collections.Generic;

namespace TeamX.Models
{
    public class Olod
    {
        public Olod()
        {
            this.Les = new List<Les>();
            this.Docents = new List<Docent>();
            this.Klas = new List<Klas>();
        }

        public int olod_id { get; set; }
        public string naam { get; set; }
        public Nullable<int> studiepunten { get; set; }
        public string omschrijving { get; set; }
        public virtual ICollection<Les> Les { get; set; }
        public virtual ICollection<Docent> Docents { get; set; }
        public virtual ICollection<Klas> Klas { get; set; }
    }
}
