using Domain.Entites.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Database.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permissions");

            builder.HasKey(p => p.id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);


            var fixedDate = new DateTime(2024, 01, 01);

            builder.HasData(

                // Users
                new Permission
                {
                    id = new Guid("11111111-0000-0000-0000-000000000001"),
                    Name = "Users.View",
                    Description = "عرض المستخدمين",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("11111111-0000-0000-0000-000000000002"),
                    Name = "Users.Create",
                    Description = "إنشاء مستخدم جديد",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("11111111-0000-0000-0000-000000000003"),
                    Name = "Users.Update",
                    Description = "تعديل بيانات المستخدم",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("11111111-0000-0000-0000-000000000004"),
                    Name = "Users.Delete",
                    Description = "حذف مستخدم",
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Roles
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000001"),
                    Name = "Roles.View",
                    Description = "عرض الأدوار والصلاحيات",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000002"),
                    Name = "Roles.Create",
                    Description = "إنشاء دور جديد",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000003"),
                    Name = "Roles.Update",
                    Description = "تعديل بيانات دور",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000004"),
                    Name = "Roles.Delete",
                    Description = "حذف دور",
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Permissions Management
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000005"),
                    Name = "Permissions.View",
                    Description = "عرض جميع الصلاحيات",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("22222222-0000-0000-0000-000000000006"),
                    Name = "Permissions.Assign",
                    Description = "تعيين الصلاحيات للأدوار والمستخدمين",
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Cases
                new Permission
                {
                    id = new Guid("33333333-0000-0000-0000-000000000001"),
                    Name = "Cases.View",
                    Description = "عرض القضايا",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("33333333-0000-0000-0000-000000000002"),
                    Name = "Cases.Create",
                    Description = "إنشاء قضية جديدة",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("33333333-0000-0000-0000-000000000003"),
                    Name = "Cases.Update",
                    Description = "تعديل بيانات القضية",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("33333333-0000-0000-0000-000000000004"),
                    Name = "Cases.Close",
                    Description = "إغلاق القضية",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("33333333-0000-0000-0000-000000000005"),
                    Name = "Cases.Delete",
                    Description = "حذف قضية",
                    createdBy = "System",
                    createdAt = fixedDate
                },

                // Files
                new Permission
                {
                    id = new Guid("44444444-0000-0000-0000-000000000001"),
                    Name = "Files.Upload",
                    Description = "رفع ملف",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("44444444-0000-0000-0000-000000000002"),
                    Name = "Files.View",
                    Description = "عرض الملفات",
                    createdBy = "System",
                    createdAt = fixedDate
                },
                new Permission
                {
                    id = new Guid("44444444-0000-0000-0000-000000000003"),
                    Name = "Files.Delete",
                    Description = "حذف ملف",
                    createdBy = "System",
                    createdAt = fixedDate
                }
            );
        }
    }
    }

