using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public record Email 
    {
        public string Value { get; init; }
        private Email(string value, IEmailValidation validation)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), "Email must be specified");
            if (!validation.IsValid(value))
                throw new ArgumentException("Email isn't valid");
            Value = value;
        }
        private Email() { }

        public static Email FromString(string value, IEmailValidation validation)
        {
            return new Email(value, validation);
        }

        public static implicit operator string(Email email) =>
           email.Value;

    }
}
