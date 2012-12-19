using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class OlodDAO
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

        public Olod GetOlodById(int id = -1)
        {
            return ctx.Olods.Find(id);
        }

        public List<Olod> GetOlodByNaam(string naam)
        {
            var result = from olod in ctx.Olods
                         where olod.naam == naam
                         select olod;
            var col = new List<Olod>(result);
            return col;
        }

        public List<Olod> GetOlodByStudiepunten(int studiepunten)
        {
            var result = from olod in ctx.Olods
                         where olod.studiepunten == studiepunten
                         select olod;
            var col = new List<Olod>(result);
            return col;
        }

        public List<Olod> GetOlodByOmschrijving(string omschrijving)
        {
            var result = from olod in ctx.Olods
                         where olod.omschrijving == omschrijving
                         select olod;
            var col = new List<Olod>(result);
            return col;
        }
    }
}