using System.Collections;
using System.Collections.Generic;

namespace Asp.Net.Mvc.Check.Models
{
    public class PersonModel
    {
        public string Name { get; set; }

        public IList<string> Addresses { get; set; }
    }
}