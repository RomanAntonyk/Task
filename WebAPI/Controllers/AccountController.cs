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
    public class AccountController : ControllerBase
    {
        private IAccountRepository _accountRepository;
        private IContactRepository _contactRepository;

        public AccountController(IAccountRepository accountRepository, IContactRepository contactRepository)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(CreateAccount accountData)
        {
            var contact = await _contactRepository.GetById(accountData.ContactId);
            if(contact == null)
            {
                return NotFound($"Contact with {accountData.ContactId} id doesn't exist");
            }
            var account = new Account(accountData.AccountName, contact);
            _accountRepository.Add(account);
            await _accountRepository.unitOfWork.SaveChangesAsync();
            return Ok(account);
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAll()
        {
           return await _accountRepository.GetAll();
        }
    }
}
