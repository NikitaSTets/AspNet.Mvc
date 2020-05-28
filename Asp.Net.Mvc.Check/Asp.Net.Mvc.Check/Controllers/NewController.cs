using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Controllers
{
    [RoutePrefix("Users")]
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index()
        {
            return View();
        }

        [Route("NewAbout")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("~/TestL")]
        public ActionResult Test()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}