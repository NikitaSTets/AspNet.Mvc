using System.Web.Mvc;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Controllers
{
    [RoutePrefix("Users")]
    public class NewController : Controller
    {
        // GET: New
        public ActionResult Index(PersonModel testClass)
        {
            return RedirectToAction("Test");
        }

        [Route("NewAbout")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("~/TestL")]
        public ActionResult Test(TestEnum b = default)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}