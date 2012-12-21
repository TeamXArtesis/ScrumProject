using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id=1;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Maandag";
            return View();
        }

        public ActionResult Dinsdag()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id = 2;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Dinsdag";
            return View("Index");
        }

        public ActionResult Woensdag()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id = 3;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Woensdag";
            return View("Index");
        }

        public ActionResult Donderdag()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id = 4;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Donderdag";
            return View("Index");
        }

        public ActionResult Vrijdag()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id = 5;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Vrijdag";
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ParserForm()
        {
            ViewBag.Message = "Your parser form.";

            return View();
        }
        public ActionResult ResultPage()
        {
            ViewBag.Message = "Your parser result page.";
            ViewBag.Naam = "Resultaten";

            return View();
        }
        public ActionResult Week()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Id = 6;
            ViewBag.Datum = getMonday(ViewBag.Id);
            ViewBag.Naam = "Week";
            return View("Index");
        }
        public DateTime getMonday(int id)
        {
            DateTime input = DateTime.Now;
            int delta = DayOfWeek.Monday - input.DayOfWeek + id - 1;
            DateTime monday = input.AddDays(delta);

            return monday;
        }
    }
}
