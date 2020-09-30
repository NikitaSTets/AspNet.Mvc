using System;
using System.Web.Mvc;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Controllers
{
    public class ModelValidationController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new AppointmentModel { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(AppointmentModel appt)
        {
            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }

            return View();
        }

        public JsonResult ValidateDate(string Date)
        {
            if (!DateTime.TryParse(Date, out var parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)",
                    JsonRequestBehavior.AllowGet);
            }

            if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }

    //[HttpPost]
    //public ViewResult MakeBooking(AppointmentModel appt)
    //{
    //    if (string.IsNullOrEmpty(appt.ClientName))
    //    {
    //        ModelState.AddModelError("ClientName", "Please enter your name");
    //    }
    //    if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
    //    {
    //        ModelState.AddModelError("Date", "Please enter a date in the future");
    //    }
    //    if (!appt.TermsAccepted)
    //    {
    //        ModelState.AddModelError("TermsAccepted", "You must accept the terms");
    //    }
    //    if (ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
    //                                              && appt.ClientName == "Joe" && appt.Date.DayOfWeek == DayOfWeek.Monday)
    //    {
    //        ModelState.AddModelError("", "Joe cannot book appointments on Mondays");
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        return View("Completed", appt);
    //    }

    //    return View();
    //}
}