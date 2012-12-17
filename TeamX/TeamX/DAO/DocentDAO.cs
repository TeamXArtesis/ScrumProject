using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamX.Models;

namespace TeamX.DAO
{
    public class DocentDAO
    {
        private static TimetableContext ctx = new TimetableContext();

        public static void Add(Docent d)
        {
            ctx.Docents.Add(d);
            Update();
        }

        public static void Remove(Docent d)
        {
            ctx.Docents.Remove(d);
            Update();
        }

        public static void Update()
        {
            ctx.SaveChanges();
        }

        public Docent GetDocentById(int id = -1)
        {
            return ctx.Docents.Find(id);
        }

        public List<Docent> GetDocentByVoornaam(string voornaam)
        {
            var result = from doc in ctx.Docents
                         where doc.voornaam == voornaam
                         select doc;
            var col = new List<Docent>(result);
            return col;
        }
        
    }
}