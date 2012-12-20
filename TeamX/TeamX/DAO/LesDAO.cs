using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class LesDAO : ILesDAO
    {
        private static TimetableContext ctx = new TimetableContext();

        public void Add(Les l)
        {
            ctx.Les.Add(l);
            Update();
        }

        public void Remove(Les l)
        {
            ctx.Les.Remove(l);
            Update();
        }

        public void Update()
        {
            ctx.SaveChanges();
        }



        public object GetLesById(int id = -1)
        {
            var result = from les in ctx.Les
                         where les.les_id == id
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             docenten = from doc2 in les.Olod.Docents
                                        select new
                                        {
                                            naam = doc2.naam + " " + doc2.voornaam
                                        },
                             klassen = from klas in les.Olod.Klas
                                       select new
                                       {
                                           afkorting = klas.naam
                                       },
                             les.lokaal,
                             olod_naam = les.Olod.naam,
                             les.Olod.studiepunten,
                             les.duur_in_minuten,
                             les.tijd
                         };
            return result;
        }

        public IEnumerable<object> GetAllLessen()
        {
            var result = from les in ctx.Les
                         select new { les.lokaal, les.les_id, les.Olod.naam };
            return result;
        }

        public IEnumerable<object> GetAllLokalen()
        {
            var result = (from les in ctx.Les
                          select les.lokaal).Distinct();
            return result;
        }

        public IEnumerable<object> GetLesByDocentId(int docentId, int week, int dag)
        {
            var result = from les in ctx.Les
                         from doc in les.Olod.Docents
                         where les.week == week && (dag == -1 || dag == les.dag) && doc.docent_id == docentId
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             docenten = from doc2 in les.Olod.Docents
                                        select new
                                        {
                                            naam = doc2.naam + " " + doc2.voornaam
                                        },
                             klassen = from klas in les.Olod.Klas
                                       select new
                                       {
                                           afkorting = klas.naam
                                       },
                             les.lokaal,
                             olod_naam = les.Olod.naam,
                             les.Olod.studiepunten,
                             les.duur_in_minuten,
                             les.tijd
                         };
            return result.OrderBy(d => d.dag).ThenBy(t => t.tijd);
        }

        public IEnumerable<object> GetLesByKlasId(int klasId, int dag, int week)
        {
            var result = from les in ctx.Les
                         from klas in les.Olod.Klas
                         where les.week == week && (dag == -1 || dag == les.dag) && klas.klas_id == klasId
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             docenten = from doc2 in les.Olod.Docents
                                        select new
                                        {
                                            naam = doc2.naam + " " + doc2.voornaam
                                        },
                             klassen = from klas2 in les.Olod.Klas
                                       select new
                                       {
                                           afkorting = klas2.naam
                                       },
                             les.lokaal,
                             les.Olod.naam,
                             les.Olod.studiepunten,
                             les.duur_in_minuten,
                             les.tijd
                         };
            return result.OrderBy(d => d.dag).ThenBy(t => t.tijd);
        }

        public IEnumerable<object> GetLesByOlodId(int olodid, int dag, int week)
        {
            var result = from les in ctx.Les
                         where les.week == week && (dag == -1 || dag == les.dag) && les.Olod.olod_id == olodid
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             docenten = from doc2 in les.Olod.Docents
                                        select new
                                        {
                                            naam = doc2.naam + " " + doc2.voornaam
                                        },
                             klassen = from klas in les.Olod.Klas
                                       select new
                                       {
                                           afkorting = klas.naam
                                       },
                             les.Olod.naam,
                             les.Olod.omschrijving,
                             les.Olod.studiepunten,
                             les.lokaal,
                             les.duur_in_minuten,
                             les.tijd
                         };
            return result.OrderBy(d => d.dag).ThenBy(t => t.tijd);
        }

        public IEnumerable<object> getlesbylokaal(string lokaal, int dag, int week)
        {
            var result = from les in ctx.Les
                         where les.week == week && (dag == -1 || dag == les.dag) && les.lokaal == lokaal
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             docenten = from doc2 in les.Olod.Docents
                                        select new
                                        {
                                            naam = doc2.naam + " " + doc2.voornaam
                                        },
                             klassen = from klas in les.Olod.Klas
                                       select new
                                       {
                                           afkorting = klas.naam
                                       },
                             les.Olod.naam,
                             les.Olod.studiepunten,
                             les.duur_in_minuten,
                             les.tijd
                         };
            return result.OrderBy(d => d.dag).ThenBy(t => t.tijd);
        }
    }
}