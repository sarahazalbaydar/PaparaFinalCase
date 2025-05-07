using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);

            builder.Property(x => x.ExpenseId).IsRequired();
            builder.Property(x => x.PaidAmount).IsRequired().HasPrecision(18, 2);
            builder.Property(x => x.PaymentDate).IsRequired();


            builder.HasOne(p => p.Expense)
                .WithOne(e => e.Payment)
                .HasForeignKey<Payment>(p => p.ExpenseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
