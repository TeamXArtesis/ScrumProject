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
using TeamX.DAO;

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
        private IKlasDAO klassenDao = new KlasDAO();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetKlasById(int id = -1)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = klassenDao.GetKlasById(id);
            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);          
        }
        

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetKlassen()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = klassenDao.GetAllKlassen();

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }
    }
}