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
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(255).IsRequired();
            builder.OwnsOne(c => c.Email, emailBuilder =>
            {
                emailBuilder.HasIndex(e => e.Value).IsUnique();
            });

        }
    }
}
