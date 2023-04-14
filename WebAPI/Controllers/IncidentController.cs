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
    public class IncidentController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        private IContactRepository _contactRepository;
        private IEmailValidation _validation;

        public IncidentController(IAccountRepository accountRepository,
            IContactRepository contactRepository,
            IEmailValidation validation)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _validation = validation;
        }

        [HttpPost]
        public async Task<ActionResult<Incident>> Create(CreateIncident incidentData)
        {
            var account =  await _accountRepository.GetByName(incidentData.AccountName);
            if (account == null)
                return NotFound($"Account with {incidentData.AccountName} name doesn't exist");
            var contact = await _contactRepository.GetByEmail(incidentData.ContactEmail);
            if(contact != null)
            {
              if(!contact.IsLinked())
                {
                    account.LinkContact(contact);
                }

                if(contact.IsLinked() && !account.IsContactBelongsToAccount(contact))
                {
                    return BadRequest("Contact belong to another account");
                }
  
                    
            }
            else
            {
                var newContact = new Contact(incidentData.ContactFirstName,
                    incidentData.ContactLastName,
                    Email.FromString(incidentData.ContactEmail, _validation));

                account.LinkContact(newContact);
            }

            var insident = new Incident(new Guid(), incidentData.InsidentDesctiption);
            account.AddIncident(insident);
            await _accountRepository.unitOfWork.SaveChangesAsync();

            return Ok(insident);
        }
    }
}
