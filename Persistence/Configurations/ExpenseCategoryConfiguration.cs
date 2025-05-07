using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ExpenseCategoryConfiguration:IEntityTypeConfiguration<ExpenseCategory>
    {

        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);


            builder.HasMany(c => c.Expenses)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
