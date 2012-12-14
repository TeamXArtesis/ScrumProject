using System;
using System.Collections.Generic;

namespace TeamX.Models
{
    public class Docent
    {
        public Docent()
        {
            this.Olods = new List<Olod>();
        }

        public int docent_id { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string email { get; set; }
        public virtual ICollection<Olod> Olods { get; set; }
    }
}
