﻿using System;
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
    /// Summary description for DocentService
    /// </summary>
    [WebService(Namespace = "http://teamX.org/Services/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class DocentService : System.Web.Services.WebService
    {
        private static TimetableContext ctx = new TimetableContext();
        private static JsonSerializerSettings serSettings = new JsonSerializerSettings() { 
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }; 

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentById(int id = -1)
        {            
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from doc in ctx.Docents
                         where doc.docent_id == id
                         select doc;
                        
           
            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByVoornaam(string voornaam)
        {           
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from doc in ctx.Docents
                         where doc.voornaam == voornaam
                         select doc;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByNaam(string naam)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from doc in ctx.Docents
                         where doc.naam == naam
                         select doc;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;    
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocentByEmail(string email)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from doc in ctx.Docents
                         where doc.email == email
                         select doc;

            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDocenten()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = from doc in ctx.Docents                         
                         select doc.naam;


            string json = JsonConvert.SerializeObject(result, Formatting.Indented, serSettings);
            return json;
        }

    }
}

//Oude manier
/*select new
                            {
                                docent_id = doc.docent_id,
                                naam = doc.naam,
                                voornaam = doc.voornaam,
                                email = doc.email,
                                olodcount = doc.Olods.Count()
                            };*/
//string json = JsonConvert.SerializeObject(result);
//return json;
//  return js.Serialize(result);