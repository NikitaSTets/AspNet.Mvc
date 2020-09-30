using System;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net.Mvc.Check.Model_Validation_Attributes
{
    public class FutureDateAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && (DateTime)value > DateTime.Now;
        }
    }
}