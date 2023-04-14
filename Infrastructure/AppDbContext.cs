using Domain.Model;
using Domain.SeedWork;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IUnitOfWork
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}