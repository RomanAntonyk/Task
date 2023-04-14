using System.ComponentModel.DataAnnotations;

namespace WebAPI.Contract
{
    public class CreateIncident
    {
        [Required]
        public string AccountName { get; set; }
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactLastName { get; set; } = string.Empty;
        [Required]
        public string ContactEmail { get; set; }
        [Required]
        [MinLength(10)]
        public string InsidentDesctiption { get; set; }
        
    }
}
