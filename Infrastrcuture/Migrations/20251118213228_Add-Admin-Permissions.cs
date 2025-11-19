using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "id", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("11111111-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("aaaaaaa1-0000-0000-0000-000000000001"), false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("aaaaaaa2-0000-0000-0000-000000000002"), false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("aaaaaaa3-0000-0000-0000-000000000003"), false, null, null, null, 0 },
                    { new Guid("11111111-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("aaaaaaa4-0000-0000-0000-000000000004"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb1-0000-0000-0000-000000000001"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb2-0000-0000-0000-000000000002"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb3-0000-0000-0000-000000000003"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb4-0000-0000-0000-000000000004"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000005"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb5-0000-0000-0000-000000000005"), false, null, null, null, 0 },
                    { new Guid("22222222-0000-0000-0000-000000000006"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("bbbbbbb6-0000-0000-0000-000000000006"), false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ccccccc1-0000-0000-0000-000000000001"), false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ccccccc2-0000-0000-0000-000000000002"), false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ccccccc3-0000-0000-0000-000000000003"), false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ccccccc4-0000-0000-0000-000000000004"), false, null, null, null, 0 },
                    { new Guid("33333333-0000-0000-0000-000000000005"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ccccccc5-0000-0000-0000-000000000005"), false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ddddddd1-0000-0000-0000-000000000001"), false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ddddddd2-0000-0000-0000-000000000002"), false, null, null, null, 0 },
                    { new Guid("44444444-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("ddddddd3-0000-0000-0000-000000000003"), false, null, null, null, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("11111111-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("11111111-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("11111111-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("11111111-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000005"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("22222222-0000-0000-0000-000000000006"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("33333333-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("33333333-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("33333333-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("33333333-0000-0000-0000-000000000004"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("33333333-0000-0000-0000-000000000005"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("44444444-0000-0000-0000-000000000001"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("44444444-0000-0000-0000-000000000002"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { new Guid("44444444-0000-0000-0000-000000000003"), "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" });
        }
    }
}
