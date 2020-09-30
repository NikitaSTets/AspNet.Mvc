using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Asp.Net.Mvc.Check.Models
{
    [DisplayName("New Person")]
    public class PersonModel
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        public IList<string> Addresses { get; set; }

        public string LastName { get; set; }

        public AddressModel HomeAddress { get; set; }

        public Role Role { get; set; }
    }
}