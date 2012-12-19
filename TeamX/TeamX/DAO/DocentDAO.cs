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

        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }; 

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

        public static Object GetDocentById(int id = -1)
        {
            var result = from doc in ctx.Docents
                         where doc.docent_id == id
                         select new
                         {
                             docent_id = doc.docent_id,
                             naam = doc.naam,
                             voornaam = doc.voornaam,
                             email = doc.email,
                             Olods = from ol in ctx.Olods
                                     where ol.Docents.Contains(doc)
                                     select new
                                     {
                                         id = ol.olod_id,
                                         naam = ol.naam,
                                         studiepunten = ol.studiepunten
                                     }
                         };
            return result;
        }

        public static IEnumerable<Object> GetAllDocenten()
        {
            var result = from doc in ctx.Docents
                         select new { doc.docent_id, naam = doc.naam + " " + doc.voornaam };
            return result;
        }
        
    }
}