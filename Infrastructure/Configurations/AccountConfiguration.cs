using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany(a => a.Contacts)
                .WithOne()
                .HasForeignKey(c => c.AccountId);

            builder.HasMany(a => a.Incidents)
                .WithOne()
                .HasForeignKey(i => i.AccountId);

            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
