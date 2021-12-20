using CardManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace CardManagement.Data.EntityConfigurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: nameof(User));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Firstname).HasMaxLength(Restrictions.User.FirstNameLength).IsRequired();
            builder.Property(p => p.Lastname).HasMaxLength(Restrictions.User.LastNameLength).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(Restrictions.User.EmailLength).IsRequired();
            builder.Property(p => p.CreatedDate);
            builder.Property(p => p.LastLoginTime);
            builder.Property(p => p.LastPasswordChangeDate);
            builder.HasMany(p => p.Accounts).WithOne().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            // builder.HasIndex(p => p.NormalizedEmail).IsUnique();

         
        }

    }
}