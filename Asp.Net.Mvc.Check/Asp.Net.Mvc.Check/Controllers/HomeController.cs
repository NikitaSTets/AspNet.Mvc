using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult CustomVariable()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable"; 
            ViewBag.CustomVariable = RouteData.Values["id"];

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}