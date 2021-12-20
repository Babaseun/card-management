using CardManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace CardManagement.Data.EntityConfigurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Balance);
            builder.Property(a => a.Type).IsRequired();
            builder.HasData(this.Seed());
        }

        private IEnumerable<Account> Seed()
        {
            yield return new Account()
            {
                Id = 1,
                Balance = 20000,
                Type = "current",
                UserId = "69bd4fa4-0d49-4825-85df-f6bc1b4522c0"
            };
            yield return new Account()
            {
                Id = 2,
                Balance = 1000,
                Type = "current",
                UserId = "69bd4fa4-0d49-4825-85df-f6bc1b4522c0"
            };
            yield return new Account()
            {
                Id = 3,
                Balance = 0,
                Type = "current",
                UserId = "69bd4fa4-0d49-4825-85df-f6bc1b4522c0"
            };

      }
    }
}