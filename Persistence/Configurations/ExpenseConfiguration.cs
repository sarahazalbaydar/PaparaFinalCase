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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.AttachmentFilePath).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(ExpenseStatus.Pending);
            builder.Property(x => x.ExpensedDate).IsRequired();
            builder.Property(x => x.DecisionUserId).IsRequired(false);
            builder.Property(x => x.DecisionDate).IsRequired(false);
            builder.Property(x => x.RejectionReason).IsRequired(false).HasMaxLength(200);

            builder.HasOne(e => e.User)
           .WithMany(u => u.Expenses)
           .HasForeignKey(e => e.UserId)
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Category)
            .WithMany(c => c.Expenses)
            .HasForeignKey(e => e.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Payment)
            .WithOne(p => p.Expense)
            .HasForeignKey<Payment>(p => p.ExpenseId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
