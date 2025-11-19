using Domain.Entites.Permissions;
using Infrastrcuture.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Database.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermissions");

            builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });

            builder.HasOne(rp => rp.Permission)
                   .WithMany(p => p.RolePermissions)
                   .HasForeignKey(rp => rp.PermissionId);

            builder.HasOne<ApplicationUserRole>()
                   .WithMany(r => r.RolePermissions)
                   .HasForeignKey(rp => rp.RoleId);

            var roleId = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001";
            var fixedDate = new DateTime(2024, 01, 01);

            builder.HasData(
                // Users (11111111)
                new RolePermission
                {
                    id = Guid.Parse("aaaaaaa1-0000-0000-0000-000000000001"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("11111111-0000-0000-0000-000000000001"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("aaaaaaa2-0000-0000-0000-000000000002"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("11111111-0000-0000-0000-000000000002"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("aaaaaaa3-0000-0000-0000-000000000003"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("11111111-0000-0000-0000-000000000003"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("aaaaaaa4-0000-0000-0000-000000000004"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("11111111-0000-0000-0000-000000000004"),
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Roles (22222222)
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb1-0000-0000-0000-000000000001"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000001"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb2-0000-0000-0000-000000000002"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000002"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb3-0000-0000-0000-000000000003"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000003"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb4-0000-0000-0000-000000000004"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000004"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb5-0000-0000-0000-000000000005"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000005"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("bbbbbbb6-0000-0000-0000-000000000006"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("22222222-0000-0000-0000-000000000006"),
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Cases (33333333)
                new RolePermission
                {
                    id = Guid.Parse("ccccccc1-0000-0000-0000-000000000001"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("33333333-0000-0000-0000-000000000001"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ccccccc2-0000-0000-0000-000000000002"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("33333333-0000-0000-0000-000000000002"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ccccccc3-0000-0000-0000-000000000003"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("33333333-0000-0000-0000-000000000003"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ccccccc4-0000-0000-0000-000000000004"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("33333333-0000-0000-0000-000000000004"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ccccccc5-0000-0000-0000-000000000005"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("33333333-0000-0000-0000-000000000005"),
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Files (44444444)
                new RolePermission
                {
                    id = Guid.Parse("ddddddd1-0000-0000-0000-000000000001"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("44444444-0000-0000-0000-000000000001"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ddddddd2-0000-0000-0000-000000000002"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("44444444-0000-0000-0000-000000000002"),
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new RolePermission
                {
                    id = Guid.Parse("ddddddd3-0000-0000-0000-000000000003"),
                    RoleId = roleId,
                    PermissionId = Guid.Parse("44444444-0000-0000-0000-000000000003"),
                    createdBy = "System",
                    createdAt = fixedDate
                }
            );
        }
    }
}
