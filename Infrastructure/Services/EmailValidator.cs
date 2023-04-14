using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailValidator : IEmailValidation
    {
        public bool IsValid(string email)
        {
            return true;
        }
    }
}
