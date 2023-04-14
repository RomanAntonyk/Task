using Domain.Model;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository
    {
        public Account Add(Account account);
        public Task<Account?> GetById(int id);
        public Task<Account?> GetByName(string name);
        public Task<List<Account>> GetAll();
    }
}
