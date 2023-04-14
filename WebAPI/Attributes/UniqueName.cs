using Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Attributes
{
    public class UniqueName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
            if (!context.Accounts.Any(a => a.Name == value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("name exists");
        }
    }
}
