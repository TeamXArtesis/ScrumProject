using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamX.Models;

namespace TeamX.Webservices
{
    /// <summary>
    /// Summary description for LesService
    /// </summary>
    [WebService(Namespace = "http://teamX.org/Services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LesService : System.Web.Services.WebService
    {
        private static TimetableContext ctx = new TimetableContext();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }; 

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesById(int id = -1)
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from les in ctx.Les
                            where les.les_id == id
                         select new
                         {
                             id = les.les_id,
                             les.dag,
                             les.duur_in_minuten,
                             les.les_id,
                             les.lokaal,
                             les.tijd,
                             les.week,                                                          
                             Olods = from ol in ctx.Olods
                                     where ol.Les.Contains(les)
                                     select new
                                     {
                                         id = ol.olod_id,
                                         naam = ol.naam,
                                         studiepunten = ol.studiepunten
                                     }
                         };

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;            
        }     

      
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLessen()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from les in ctx.Les
                         select new { les.lokaal, les.les_id, les.Olod.naam};


            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLokalen()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = (from les in ctx.Les
                         select les.lokaal).Distinct();


            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByDocentId(int docentId, int week, int dag)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = from les in ctx.Les
                         from doc in les.Olod.Docents
                         where les.week == week && (dag == -1 || dag == les.dag) && doc.docent_id == docentId
                         select new
                             {
                                 les.les_id,
                                 les.dag,
                                 les.week,
                                 doc.docent_id,
                                 les.lokaal,                                 
                                 les.Olod.naam,                                 
                                 les.Olod.studiepunten,
                                 les.duur_in_minuten,
                                 les.tijd
                             };

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByKlasId(int klasId, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            var result = from les in ctx.Les
                         from klas in ctx.Klas
                         where les.week == week && (dag == -1 || dag == les.dag) && klas.klas_id == klasId
                         select new
                             {
                                 les.les_id,
                                 les.dag,
                                 les.week,
                                 klasnaam = klas.naam,
                                 klas.afkorting,
                                 les.lokaal,                                 
                                 les.Olod.naam,                                 
                                 les.Olod.studiepunten,
                                 les.duur_in_minuten,
                                 les.tijd
                             };;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByOlodId(int olodid, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = from les in ctx.Les
                         from olod in ctx.Olods
                         where les.week == week && (dag == -1 || dag == les.dag) && olod.olod_id == olodid
                         select new
                         {
                             les.les_id,
                             les.dag,
                             les.week,
                             olod.naam,
                             olod.omschrijving,
                             olod.studiepunten,
                             les.lokaal,                             
                             les.duur_in_minuten,
                             les.tijd
                         }; ;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getlesbylokaal(string lokaal, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = from les in ctx.Les
                         where les.week == week && (dag == -1 || dag == les.dag) && les.lokaal == lokaal
                         select new
                             {
                                 les.les_id,
                                 les.dag,
                                 les.week,
                                 les.Olod.naam,
                                 les.Olod.studiepunten,
                                 les.duur_in_minuten,
                                 les.tijd                                  
                             };
            ;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

    }
}
