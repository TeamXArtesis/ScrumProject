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
    /// Summary description for LesService
    /// </summary>
    [WebService(Namespace = "http://teamX.org/Services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LesService : System.Web.Services.WebService
    {
        private static ILesDAO lessenDao = new LesDAO();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }; 

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesById(int id = -1)
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = lessenDao.GetLesById(id);

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);          
        }     

      
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLessen()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = lessenDao.GetAllLessen();

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLokalen()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = lessenDao.GetAllLokalen();

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByDocentId(int docentId, int week, int dag)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = lessenDao.GetLesByDocentId(docentId, week, dag);

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByKlasId(int klasId, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = lessenDao.GetLesByKlasId(klasId, dag, week);

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByOlodId(int olodid, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = lessenDao.GetLesByOlodId(olodid, dag, week);

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getlesbylokaal(string lokaal, int dag, int week)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var result = lessenDao.getlesbylokaal(lokaal, dag, week);

            return JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
        }

    }
}
