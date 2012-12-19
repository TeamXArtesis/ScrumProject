using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class KlasDAO
    {
        private static TimetableContext ctx = new TimetableContext();

        public static void Add(Klas k)
        {
            ctx.Klas.Add(k);
            Update();
        }

        public static void Remove(Klas k)
        {
            ctx.Klas.Remove(k);
            Update();
        }

        public static void Update()
        {
            ctx.SaveChanges();
        }

        public static Klas GetKlasById(int id = -1)
        {
            return ctx.Klas.Find(id);
        }

        public List<Klas> GetKlasByAfkorting(string afkorting)
        {
            var result = from klas in ctx.Klas
                         where klas.afkorting == afkorting
                         select klas;
            var col = new List<Klas>(result);
            return col;
        }

        public List<Klas> GetKlasByNaam(string naam)
        {
            var result = from klas in ctx.Klas
                         where klas.naam == naam
                         select klas;
            var col = new List<Klas>(result);
            return col;
        }
    }
}