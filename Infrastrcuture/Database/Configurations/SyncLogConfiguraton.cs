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
    public class SyncLogConfiguraton : IEntityTypeConfiguration<SyncLog>
    {
        public void Configure(EntityTypeBuilder<SyncLog> builder)
        {

            builder.Property(a => a.Result)
                    .HasConversion<string>();

        }

    }
    
    }

