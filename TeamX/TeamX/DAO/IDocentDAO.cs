using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamX.DAO
{
    interface IDocentDAO
    {
        public static void Add(Docent d);
        public static void Remove(Docent d);
        public static void Update();
    }
}
