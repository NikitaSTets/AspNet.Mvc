using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class BindingController : Controller
    {
        private readonly PersonModel[] _personData;

        public BindingController()
        {
            _personData = new[]
            {
                new PersonModel
                {
                    PersonId = 1,
                    FirstName = "Adam",
                    LastName = "Freeman",
                    Role = Role.Admin
                },
                new PersonModel
                {
                    PersonId = 2,
                    FirstName = "Jacqui",
                    LastName = "Griffyth",
                    Role = Role.User
                },
                new PersonModel
                {
                    PersonId = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    Role = Role.User
                },
                new PersonModel
                {
                    PersonId = 4,
                    FirstName = "Anne",
                    LastName = "Jones",
                    Role = Role.Guest
                }
            };
        }

        public ActionResult Index(int? id = 1)
        {
            var a = TempData["test"];
            var dataItem = _personData.First(p => p.PersonId == id);

            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            var newCultureName = "fr-FR";
            var cookie = new HttpCookie("_culture", newCultureName);
            cookie.Expires = DateTime.Today.AddYears(1);
            Response.SetCookie(cookie);

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(newCultureName);

            return View(new PersonModel());
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonModel model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")] AddressSummaryModel summary)
        {
            return View(summary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];

            return View(names);
        }

        public ActionResult Address(FormCollection formData)
        {
            var addresses = new List<AddressSummaryModel>();
            UpdateModel(addresses, formData);

            //if (TryUpdateModel(addresses, formData))
            //{
            //    // proceed as normal
            //}
            //else
            //{
            //    // provide feedback to user
            //}

            return View(addresses);
        }

        public ActionResult Address(IList<AddressSummaryModel> addresses)
        {

            addresses = addresses ?? new List<AddressSummaryModel>();

            return View(addresses);
        }
    }
}