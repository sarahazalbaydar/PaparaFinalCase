using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(250);

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.MiddleName).IsRequired(false).HasMaxLength(50);

            builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(25);

            builder.Property(u => u.IBAN).IsRequired().HasMaxLength(34);

            builder.Property(u => u.Role).IsRequired().HasMaxLength(35);



            builder.HasMany(u => u.Expenses)
                   .WithOne(e => e.User)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);



        }

    }
}
