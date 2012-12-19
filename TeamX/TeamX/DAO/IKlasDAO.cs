using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamX.DAO
{
    interface IKlasDAO
    {
        public static void Add(Klas k);
        public static void Remove(Klas k);
        public static void Update();
    }
}
