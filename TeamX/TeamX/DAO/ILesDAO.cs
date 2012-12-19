using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamX.DAO
{
    interface ILesDAO
    {
        public static void Add(Les l);
        public static void Remove(Les l);
        public static void Update();
    }
}
