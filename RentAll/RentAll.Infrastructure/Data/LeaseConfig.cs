using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAll.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Data
{
    public class LeaseConfig : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
            builder.Property(l => l.Valid)
                .IsRequired();

            builder.Property(l => l.LeaseNumber)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
