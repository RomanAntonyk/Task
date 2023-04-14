
using System.ComponentModel.DataAnnotations;
using WebAPI.Attributes;

namespace WebAPI.Contract
{
    public class CreateAccount
    {
        [Required]
        [UniqueName]
        public string AccountName { get; set; }
        [Required]
        public int ContactId { get; set; }
    }
}
