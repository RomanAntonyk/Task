using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using WebAPI.Attributes;

namespace WebAPI.Contract
{
    public class CreateContact
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string Email { get; set; } = string.Empty;

    }
}
