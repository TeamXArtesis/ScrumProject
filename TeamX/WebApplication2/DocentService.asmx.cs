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
    /// Summary description for DocentService
    /// </summary>
    [WebService(Namespace = "http://teamX.org/Services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DocentService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByID(int id = -1)
        {
            TimetableContext ctx = new TimetableContext();

            var result = from doc in ctx.Docents
                         where doc.docent_id == id
                         select doc;
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(result);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByVoornaam(string naam)
        {
            Docent d = new Docent();
            if (naam.ToUpper().Equals("JAN"))
            {
                d.docent_id = 1;
                d.naam = "Janssens";
                d.email = "jan.janssens@artesis.be";
                d.voornaam = "Jan";
            }
            else if (naam.ToUpper().Equals("PHILIPPE"))
            {
                d.docent_id = 2;
                d.naam = "Possemiers";
                d.voornaam = "Philippe";
                d.email = "philippe.possemiers@artesis.be";
            }
            else
            {
                d.docent_id = -1;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(d);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByNaam(string naam)
        {
            Docent d = new Docent();
            if (naam.ToUpper().Equals("JANSSENS"))
            {
                d.docent_id = 1;
                d.naam = "Janssens";
                d.email = "jan.janssens@artesis.be";
                d.voornaam = "Jan";
            }
            else if (naam.ToUpper().Equals("POSSEMIERS"))
            {
                d.docent_id = 2;
                d.naam = "Possemiers";
                d.voornaam = "Philippe";
                d.email = "philippe.possemiers@artesis.be";
            }
            else
            {
                d.docent_id = -1;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(d);
        }
    }
}
