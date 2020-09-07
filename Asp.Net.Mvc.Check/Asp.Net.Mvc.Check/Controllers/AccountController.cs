using System.Web.Mvc;
using System.Web.Security;
using Asp.Net.Mvc.Check.Filters;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class AccountController : Controller
    {
        [CustomAuth]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string returnUrl)
        {
            var result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);

                return Redirect(returnUrl ?? Url.Action("Index", "Home"));
            }

            //что за key параметр?
            ModelState.AddModelError("", "Incorrect username or password");

            return View();
        }
    }
}