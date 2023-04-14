using Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Attributes
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            if(!context.Contacts.Any(c => c.Email.Value == value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email exists");
        }
    }
}
