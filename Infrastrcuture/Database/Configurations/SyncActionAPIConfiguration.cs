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
    public class SyncActionAPIConfiguration : IEntityTypeConfiguration<SyncActionAPI>
    {
        public void Configure(EntityTypeBuilder<SyncActionAPI> builder)
        {

            builder.Property(a => a.Operation)
                    .HasConversion<string>();

        }

    }

}
