using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class KlasDAO : IKlasDAO
    {
        private static TimetableContext ctx = new TimetableContext();

        public void Add(Klas k)
        {
            ctx.Klas.Add(k);
            Update();
        }

        public void Remove(Klas k)
        {
            ctx.Klas.Remove(k);
            Update();
        }

        public void Update()
        {
            ctx.SaveChanges();
        }

        public Object GetKlasById(int id = -1)
        {
            var result = from klasVar in ctx.Klas
                         where klasVar.klas_id == id
                         select new
                         {
                             id = klasVar.klas_id,
                             klasVar.naam,
                             klasVar.afkorting,
                             Olods = from ol in ctx.Olods
                                     where ol.Klas.Contains(klasVar)
                                     select new
                                     {
                                         id = ol.olod_id,
                                         naam = ol.naam,
                                         studiepunten = ol.studiepunten
                                     }
                         };
            return result;
        }

        public IEnumerable<Object> GetAllKlassen()
        {
            var result = from klas in ctx.Klas
                         select new { klas.naam, klas.klas_id };
            return result;
        }
    }
}