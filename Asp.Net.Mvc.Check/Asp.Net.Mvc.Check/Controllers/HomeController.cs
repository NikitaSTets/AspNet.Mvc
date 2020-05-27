using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Controllers
{
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}