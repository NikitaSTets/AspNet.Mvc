using System.ComponentModel.DataAnnotations;

namespace Asp.Net.Mvc.Check.Models
{
    public class ClientModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}