using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamX.Models;

namespace TeamX.DAO
{
    interface IDocentDAO
    {
        void Add(Docent d);
        void Remove(Docent d);
        void Update();

        Object GetDocentById(int id = -1);
        IEnumerable<Object> GetAllDocenten();
    }
}
