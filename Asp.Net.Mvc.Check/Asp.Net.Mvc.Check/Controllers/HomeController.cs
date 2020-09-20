using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Asp.Net.Mvc.Check.Filters;
using Asp.Net.Mvc.Check.Infrastructure;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Controllers
{
    [CustomAuth]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Name = "Home.Controllers";

            return View();
        }

        public ActionResult CustomVariable(string id, string catchall)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = RouteData.Values["id"];
            ViewBag.CatchAll = catchall;

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HandleError]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return $"The id value is: {id}";
            }
            else
            {
                throw new ArgumentException();
            }
        }

        [CustomAction]
        public string CustomActionFilterTest()
        {
            return "This is the FilterTest action";
        }

        [ResultFilter]
        public ActionResult Contact()
        {
            var testModel = new PersonModel()
            {
                Name = "Test",
                Addresses = new List<string>() { "St.Greenwood, Wate avenue"}
            };

            ViewBag.Message = "Your contact page.";

            return View(testModel);
        }

        [ChildActionOnly]
        public ActionResult Time(DateTime time)
        {
            return PartialView(time);
        }
    }
}