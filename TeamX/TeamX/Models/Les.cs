using System;
using System.Collections.Generic;

namespace TeamX.Models
{
    public class Les
    {
        public int les_id { get; set; }
        public Nullable<System.TimeSpan> tijd { get; set; }
        public Nullable<int> olod_id { get; set; }
        public Nullable<int> duur_in_minuten { get; set; }
        public string lokaal { get; set; }
        public Nullable<int> dag { get; set; }
        public Nullable<int> week { get; set; }
        public virtual Olod Olod { get; set; }
    }
}
