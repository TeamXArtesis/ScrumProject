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
                            select les;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByLokaal(string lokaal)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from les in ctx.Les
                         where les.lokaal == lokaal
                         select les;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByOlodNaam(string olod_naam)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from les in ctx.Les
                         where les.Olod.naam == olod_naam
                         select les;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByDag(int dag)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from les in ctx.Les
                         where les.dag == dag
                         select les;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }
    }
}
