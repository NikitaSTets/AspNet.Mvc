using System;
using System.ComponentModel.DataAnnotations;
using Asp.Net.Mvc.Check.Models;

namespace Asp.Net.Mvc.Check.Model_Validation_Attributes
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Mondays";
        }


        public override bool IsValid(object value)
        {
            var app = value as AppointmentModel;
            if (app == null || string.IsNullOrEmpty(app.ClientName))
            {
                return true;
            }

            return !(app.ClientName == "Joe" &&
                     app.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}