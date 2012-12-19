using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamX.DAO
{
    interface IOlodDAO
    {
        public static void Add(Olod o);
        public static void Remove(Olod o);
        public static void Update();
    }
}
