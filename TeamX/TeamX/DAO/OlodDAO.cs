using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class OlodDAO : IOlodDAO
    {
        private static TimetableContext ctx = new TimetableContext();

        public void Add(Olod o)
        {
            ctx.Olods.Add(o);
            Update();
        }

        public void Remove(Olod o)
        {
            ctx.Olods.Remove(o);
            Update();
        }

        public void Update()
        {
            ctx.SaveChanges();
        }

        public IEnumerable<object> GetAllOlods()
        {
            var result = from olod in ctx.Olods
                         select new { olod.olod_id, olod.naam };
            return result;
        }

        public Object GetOlodById(int id = -1)
        {
            var result = from olod in ctx.Olods
                         where olod.olod_id == id
                         select new
                         {
                             olod.naam,
                             olod.olod_id,
                             olod.omschrijving,
                             olod.studiepunten,                               
                         };
            return result;
        }
    }
}