using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Asp.Net.Mvc.Check.Model_Validation_Attributes;

namespace Asp.Net.Mvc.Check.Models
{
    [NoJoeOnMondays]
    public class AppointmentModel
    {
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[FutureDate(ErrorMessage = "Please enter a date in the future")]
        [Remote("ValidateDate", "ModelValidation")]
        public DateTime Date { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}