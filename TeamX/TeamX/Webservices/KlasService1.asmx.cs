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
    /// Summary description for KlasService1
    /// </summary>
    [WebService(Namespace = "http://teamX.org/Services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class KlasService1 : System.Web.Services.WebService
    {
        private static TimetableContext ctx = new TimetableContext();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getKlasById(int id = -1)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from klasVar in ctx.Klas
                         where klasVar.klas_id == id
                         select klasVar;
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;           
          
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getKlasByAfk(string afk = null)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from klasVarAfk in ctx.Klas
                         where klasVarAfk.afkorting == afk
                         select klasVarAfk;
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;     
        }

        [WebMethod]
        public string getKlasByNaam(string naam = null)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from klasVarNaam in ctx.Klas
                         where klasVarNaam.naam == naam
                         select klasVarNaam;
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        } 
    }
}



//oude methode
// TimetableContext ctx = new TimetableContext();
// JavaScriptSerializer js = new JavaScriptSerializer();
// var result = from klasVar in ctx.Klas
// where klasVar.klas_id == id
// select new
//  {
//    klas_id = klasVar.klas_id,
//  afkorting = klasVar.afkorting,
// naam = klasVar.naam
//string json = JsonConvert.SerializeObject(result);
//return js.Serialize(result);
//  }; 
