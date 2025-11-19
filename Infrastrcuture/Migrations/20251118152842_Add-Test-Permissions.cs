using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class AddTestPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "id", "Description", "Name", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), "عرض المستخدمين", "Users.View", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000002"), "إنشاء مستخدم جديد", "Users.Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000003"), "تعديل بيانات المستخدم", "Users.Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000004"), "حذف مستخدم", "Users.Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000001"), "عرض الأدوار والصلاحيات", "Roles.View", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000002"), "إنشاء دور جديد", "Roles.Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000003"), "تعديل بيانات دور", "Roles.Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000004"), "حذف دور", "Roles.Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000005"), "عرض جميع الصلاحيات", "Permissions.View", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000006"), "تعيين الصلاحيات للأدوار والمستخدمين", "Permissions.Assign", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000001"), "عرض القضايا", "Cases.View", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000002"), "إنشاء قضية جديدة", "Cases.Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000003"), "تعديل بيانات القضية", "Cases.Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000004"), "إغلاق القضية", "Cases.Close", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000005"), "حذف قضية", "Cases.Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000001"), "رفع ملف", "Files.Upload", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000002"), "عرض الملفات", "Files.View", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000003"), "حذف ملف", "Files.Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("11111111-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("33333333-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "id",
                keyValue: new Guid("44444444-0000-0000-0000-000000000003"));
        }
    }
}
