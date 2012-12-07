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
    /// Summary description for OlodService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class OlodService : System.Web.Services.WebService
    {
        private static TimetableContext ctx = new TimetableContext();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetOlodById(int id = -1)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from olodVar in ctx.Olods
                         where olodVar.olod_id == id
                         select olodVar;
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }
    }
}
