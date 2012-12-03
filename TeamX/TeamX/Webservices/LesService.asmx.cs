using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using TeamX.Models;

namespace WebApplication2
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByID(int id = -1)
        {
            Les l = new Les();
            if (id == 1)
            {
                l.les_id = 1;
                // l.tijd = new TimeSpan(2, 0, 0);
                l.lokaal = "TestLokaal";
                l.dag = 1;
                l.week = 2;   
            } else if (id == 2)
            {
                l.les_id = 2;
                l.tijd = new TimeSpan(2, 0, 0);
                l.lokaal = "B04";
                l.dag = 2;
                l.week = 2; 
            }
            else
            {
                l.les_id = -1;
                l.lokaal = ""; 
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(l);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLesByLokaal(string lokaal)
        {
            Les l = new Les();
            if (lokaal.ToUpper().Equals("TESTLOKAAL"))
            {
                l.les_id = 1;
                // l.tijd = new TimeSpan(2, 0, 0);
                l.lokaal = "TestLokaal";
                l.dag = 1;
                l.week = 2;
            }
            else if (lokaal.ToUpper().Equals("B04"))
            {
                l.les_id = 2;
                l.tijd = new TimeSpan(2, 0, 0);
                l.lokaal = "B04";
                l.dag = 2;
                l.week = 2;
            }
            else
            {
                l.les_id = -1;
                l.lokaal = "";
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(l);
        }
    }
}
