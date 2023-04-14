using Domain.Model;
using Domain.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContact contact, [FromServices] IEmailValidation validation)
        {
            var newContact = new Contact(contact.FirstName,
                contact.LastName,
                Email.FromString(contact.Email, validation));
            
            _contactRepository.Add(newContact);
            await _contactRepository.unitOfWork.SaveChangesAsync();
            return Ok(newContact);
        }
    }
}
