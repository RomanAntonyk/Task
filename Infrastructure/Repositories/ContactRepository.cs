using Domain.Model;
using Domain.Repositories;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork unitOfWork => _context;

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public async Task<Contact?> GetByEmail(string email)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Email.Value == email);
        }

        public async Task<Contact?> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}
