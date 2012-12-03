using System;
using System.Collections.Generic;

namespace TeamX.Models
{
    public class Klas
    {
        public Klas()
        {
            this.Olods = new List<Olod>();
        }

        public int klas_id { get; set; }
        public string afkorting { get; set; }
        public string naam { get; set; }
        public virtual ICollection<Olod> Olods { get; set; }
    }
}
