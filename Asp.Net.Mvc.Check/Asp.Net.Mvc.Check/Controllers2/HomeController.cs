using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Controllers2
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Name = "Home.Controllers2";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}