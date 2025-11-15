using Domain.Entites;
using Domain.Enums;
using Infrastrcuture.AuditingAndIntegration;
using Infrastrcuture.HelperEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastrcuture.Database.Configurations
{
    public class RefernceDataConfiguration : IEntityTypeConfiguration<RefernceData>
    {
        public void Configure(EntityTypeBuilder<RefernceData> builder)
        {
            builder.Property(a => a.Type)
                .HasConversion<string>();

            builder.HasMany<ContractTemplate>()
                   .WithOne()
                   .HasForeignKey(a => a.TypeId);

            builder.HasData(
                // Template Types
                new RefernceData
                {
                    id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Type = ReferenceDataTypes.TemplateForCaseContract,
                    Key = "CONTRACT",
                    ValueAr = "عقد",
                    ValueEn = "Contract",
                    Order = 1,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Type = ReferenceDataTypes.TemplateForCaseContract,
                    Key = "INVOICE",
                    ValueAr = "فاتورة",
                    ValueEn = "Invoice",
                    Order = 2,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Type = ReferenceDataTypes.TemplateForCaseContract,
                    Key = "REPORT",
                    ValueAr = "تقرير",
                    ValueEn = "Report",
                    Order = 3,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },

                // Crimes
                new RefernceData
                {
                    id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Type = ReferenceDataTypes.Crime,
                    Key = "THEFT",
                    ValueAr = "سرقة",
                    ValueEn = "Theft",
                    Order = 1,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Type = ReferenceDataTypes.Crime,
                    Key = "ASSAULT",
                    ValueAr = "اعتداء",
                    ValueEn = "Assault",
                    Order = 2,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Type = ReferenceDataTypes.Crime,
                    Key = "FRAUD",
                    ValueAr = "احتيال",
                    ValueEn = "Fraud",
                    Order = 3,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },

                // Penalties
                new RefernceData
                {
                    id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    Type = ReferenceDataTypes.CrimePenalty,
                    Key = "FINE",
                    ValueAr = "غرامة مالية",
                    ValueEn = "Fine",
                    Order = 1,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    Type = ReferenceDataTypes.CrimePenalty,
                    Key = "IMPRISONMENT",
                    ValueAr = "سجن",
                    ValueEn = "Imprisonment",
                    Order = 2,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
                new RefernceData
                {
                    id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    Type = ReferenceDataTypes.CrimePenalty,
                    Key = "COMMUNITY_SERVICE",
                    ValueAr = "خدمة المجتمع",
                    ValueEn = "Community Service",
                    Order = 3,
                    IsActive = true,
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                }
            );
        }
    }
}
