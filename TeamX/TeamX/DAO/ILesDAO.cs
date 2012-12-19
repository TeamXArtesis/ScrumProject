using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamX.Models;

namespace TeamX.DAO
{
    interface ILesDAO
    {
        void Add(Les l);
        void Remove(Les l);
        void Update();

        Object GetLesById(int id = -1);
        IEnumerable<Object> GetAllLessen();
        IEnumerable<Object> GetAllLokalen();
        IEnumerable<Object> GetLesByDocentId(int docentId, int week, int dag);
        IEnumerable<Object> GetLesByKlasId(int klasId, int dag, int week);
        IEnumerable<Object> GetLesByOlodId(int olodid, int dag, int week);
        IEnumerable<Object> getlesbylokaal(string lokaal, int dag, int week);


    }
}
