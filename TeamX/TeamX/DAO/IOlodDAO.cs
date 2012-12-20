using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamX.Models;

namespace TeamX.DAO
{
    interface IOlodDAO
    {
        void Add(Olod o);
        void Remove(Olod o);
        void Update();

        IEnumerable<Object> GetAllOlods();
        Object GetOlodById(int id = -1);
    }
}
