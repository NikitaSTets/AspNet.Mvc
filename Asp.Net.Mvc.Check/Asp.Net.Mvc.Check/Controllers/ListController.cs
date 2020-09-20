using System.Globalization;
using System.Web.Mvc;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Fruits = new string[] { "Apple", "Orange", "Pear" };
            ViewBag.Cities = new string[] { "New York", "London", "Paris" };
            var message = "This is an HTML element: <input>";

            return View((object)message);
        }

        public ActionResult CreatePerson()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonModel person)
        {
            var result = ViewData.ModelState.Remove("PersonId");

            ViewData.ModelState.Add("PersonId", new ModelState { Value = new ValueProviderResult("10", "10", CultureInfo.CurrentCulture) });
            ViewBag.PersonId = 145;

            return View(person);
        }
    }
}