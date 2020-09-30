using System.Web.Mvc;
using System.Web.Security;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class AccountController : Controller
    {
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

            ModelState.AddModelError("", "Incorrect username or password");

            return View();
        }
    }
}