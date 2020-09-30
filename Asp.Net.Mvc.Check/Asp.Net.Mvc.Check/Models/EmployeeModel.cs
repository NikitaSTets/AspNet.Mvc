using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asp.Net.Mvc.Check.Models
{
    public class EmployeeModel: IValidatableObject
    {
        public string Name { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }

            return errors;
        }
    }
}