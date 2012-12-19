using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamX.Models;

namespace TeamX.DAO
{
    interface IKlasDAO
    {
        void Add(Klas k);
        void Remove(Klas k);
        void Update();

        Object GetKlasById(int id = -1);
        IEnumerable<Object> GetAllKlassen();
    }
}
