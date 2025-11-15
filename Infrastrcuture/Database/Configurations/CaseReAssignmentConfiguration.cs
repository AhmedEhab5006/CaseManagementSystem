using Domain.Entites;
using Domain.Entites.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Database.Configurations
{
    public class CaseReAssignmentConfiguration : IEntityTypeConfiguration<CaseReAssignmentRequest>
    {
        public void Configure(EntityTypeBuilder<CaseReAssignmentRequest> builder)
        {
            builder.ToTable("CaseReAssignmentRequests");

            builder.Property(a => a.RequestStatus)
                    .HasConversion<string>();

        }

    }
}

