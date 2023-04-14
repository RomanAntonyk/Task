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
    public class AccountRepository : IAccountRepository
    {
        private AppDbContext _context;

        public AccountRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IUnitOfWork unitOfWork => _context;

        public Account Add(Account account)
        {
            return _context.Add(account).Entity;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Accounts
                .Include(a=>a.Contacts)
                .Include(a =>a.Incidents)
                .ToListAsync();
        }

        public async Task<Account?> GetById(int id)
        {
            return  await _context.Accounts
                .Include(a=>a.Contacts)
                .Include(a=>a.Incidents)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Account?> GetByName(string name)
        {
            return await _context.Accounts
                .Include(a=>a.Contacts)
                .Include(a=>a.Incidents)
                .FirstOrDefaultAsync(a => a.Name == name);
        }

    }
}
