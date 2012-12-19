using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamX.Models;

namespace TeamX.DAO
{
    public class LesDAO
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

        public Les GetLesById(int id = -1)
        {
            return ctx.Les.Find(id);
        }

        public List<Les> GetLesByTijd(TimeSpan tijd)
        {
            var result = from les in ctx.Les
                         where les.tijd == tijd
                         select les;
            var col = new List<Les>(result);
            return col;
        }

        public List<Les> GetLesByOlod_id(int olod_id)
        {
            var result = from les in ctx.Les
                         where les.olod_id == olod_id
                         select les;

            var col = new List<Les>(result);
            return col;
        }

        public List<Les> GetLesByDuur_in_minuten(int duur_in_minuten)
        {
            var result = from les in ctx.Les
                         where les.duur_in_minuten == duur_in_minuten           
                         select les;

            var col = new List<Les>(result);
            return col;
        }

        public List<Les> GetLesByLokaal(string lokaal)
        {            
            var result = from les in ctx.Les
                         where les.lokaal == lokaal
                         select les;

            var col = new List<Les>(result);
            return col;
        }

        public List<Les> GetLesByOlodNaam(string olod_naam)
        {            
            var result = from les in ctx.Les
                         where les.Olod.naam == olod_naam
                         select les;

            var col = new List<Les>(result);
            return col;
        }


        public List<Les> GetLesByDag(int dag)
        {            
            var result = from les in ctx.Les
                         where les.dag == dag
                         select les;

            var col = new List<Les>(result);
            return col;
        }

        public List<Les> GetLesByWeek(int week)
        {
            var result = from les in ctx.Les
                         where les.week == week
                         select les;

            var col = new List<Les>(result);
            return col;
        }
       
    }
}