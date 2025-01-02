using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InveonFinal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InveonFinal.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            // builder.Property(x => x.OrderId).IsRequired();

            builder.Property(x => x.PaymentType).HasMaxLength(50);
            builder.Property(x => x.PaymentStatus).HasMaxLength(50);
            builder.Property(x => x.PaymentDate).IsRequired();
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Payment)
                .HasForeignKey(x => x.PaymentId);

        }
    }
}
