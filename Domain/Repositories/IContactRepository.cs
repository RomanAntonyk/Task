using Domain.Model;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IContactRepository : IRepository
    {
       public void Add(Contact contact);

        public Task<Contact?> GetById(int id);
        public Task<Contact?> GetByEmail(string email);
    }
}
