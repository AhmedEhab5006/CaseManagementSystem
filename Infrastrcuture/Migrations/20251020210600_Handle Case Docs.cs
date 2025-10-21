using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class HandleCaseDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CasesDocuments",
                keyColumn: "id",
                keyValue: new Guid("1f6c9b63-9e45-421f-915c-f45c7b65c7c7"));

            migrationBuilder.DeleteData(
                table: "CasesDocuments",
                keyColumn: "id",
                keyValue: new Guid("2d2f1a45-bd6e-4c2c-aea1-7c37c68b68b6"));

            migrationBuilder.DropColumn(
                name: "docCategoryCode",
                table: "CasesDocuments");

            migrationBuilder.DropColumn(
                name: "docType",
                table: "CasesDocuments");

            migrationBuilder.AlterColumn<string>(
                name: "uniqueNo",
                table: "CasesDocuments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "DocTypeId",
                table: "CasesDocuments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DocumentsTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    rowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    deletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    versionNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsTypes", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "DocumentsTypes",
                columns: new[] { "id", "CategoryCode", "Type", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("a3d2f9e0-8c57-4a93-bb3b-f5f3f0cbe1ad"), "LGL01", "عريضة دعوى", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("b1e2c7a9-3e5f-47a9-9183-9d6e5dbfa502"), "LGL02", "مذكرة دفاع", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("c1f8b2b0-91d4-4e8a-b6c9-8123f58a8b6f"), "ORD01", "أمر قضائي", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("e3b1f8d5-9a54-4fd9-a9d5-8e6b9c44de77"), "CNT01", "عقد", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 },
                    { new Guid("f4c3a9e1-22bb-4c4e-bb5c-12a9e38de2cb"), "EVD01", "مستند إثبات", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, null, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasesDocuments_DocTypeId",
                table: "CasesDocuments",
                column: "DocTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesDocuments_FileAssetId",
                table: "CasesDocuments",
                column: "FileAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesDocuments_DocumentsTypes_DocTypeId",
                table: "CasesDocuments",
                column: "DocTypeId",
                principalTable: "DocumentsTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesDocuments_Files_FileAssetId",
                table: "CasesDocuments",
                column: "FileAssetId",
                principalTable: "Files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesDocuments_DocumentsTypes_DocTypeId",
                table: "CasesDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_CasesDocuments_Files_FileAssetId",
                table: "CasesDocuments");

            migrationBuilder.DropTable(
                name: "DocumentsTypes");

            migrationBuilder.DropIndex(
                name: "IX_CasesDocuments_DocTypeId",
                table: "CasesDocuments");

            migrationBuilder.DropIndex(
                name: "IX_CasesDocuments_FileAssetId",
                table: "CasesDocuments");

            migrationBuilder.DropColumn(
                name: "DocTypeId",
                table: "CasesDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "uniqueNo",
                table: "CasesDocuments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "docCategoryCode",
                table: "CasesDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "docType",
                table: "CasesDocuments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "CasesDocuments",
                columns: new[] { "id", "CaseId", "FileAssetId", "VsId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "description", "docCategoryCode", "docType", "isDeleted", "rowVersion", "uniqueNo", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("1f6c9b63-9e45-421f-915c-f45c7b65c7c7"), new Guid("80808080-8080-8080-8080-808080808080"), null, "VS002", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "مذكرة الدفاع الأولى", "DEFENSE", "مذكرة دفاع", false, null, 2, null, null, 1 },
                    { new Guid("2d2f1a45-bd6e-4c2c-aea1-7c37c68b68b6"), new Guid("90909090-9090-9090-9090-909090909090"), null, "VS003", new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "طلب طلاق ونفقة", "DIVORCE", "طلب طلاق", false, null, 1, null, null, 1 }
                });
        }
    }
}
