using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentAll.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.EntityConfigurations
{
    public class LeaseConfiguration : IEntityTypeConfiguration<Lease>
    {
        public void Configure(EntityTypeBuilder<Lease> builder)
        {
			builder.HasMany(l => l.Units)
					.WithMany(u => u.Leases)
					.UsingEntity<Dictionary<string, object>>(
					   "LeaseUnit",
					   j => j
						 .HasOne<Unit>()
						 .WithMany()
						 .HasForeignKey("UnitId")
						 .OnDelete(DeleteBehavior.Restrict),
					   j => j
						 .HasOne<Lease>()
						 .WithMany()
						 .HasForeignKey("LeaseId")
						 .OnDelete(DeleteBehavior.Restrict));




			

			
		}
    }
}
