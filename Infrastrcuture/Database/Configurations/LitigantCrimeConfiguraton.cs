using Domain.Entites;
using Infrastrcuture.AuditingAndIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Database.Configurations
{
    public class LitigantCrimeConfiguraton : IEntityTypeConfiguration<LitigantCrime>
    {
        public void Configure(EntityTypeBuilder<LitigantCrime> builder)
        {
            builder.HasKey(lc => lc.id);

            builder.HasOne<RefernceData>()
                   .WithMany()
                   .HasForeignKey(lc => lc.CrimeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<RefernceData>()
                   .WithMany()
                   .HasForeignKey(lc => lc.PenaltyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
