using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class AddLitigantCrime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContractTemplates",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_ContractTemplates", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContractTemplates_RefernecesData_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RefernecesData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LitigantsCrimes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LitigantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PenaltyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_LitigantsCrimes", x => x.id);
                    table.ForeignKey(
                        name: "FK_LitigantsCrimes_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LitigantsCrimes_Litigants_LitigantId",
                        column: x => x.LitigantId,
                        principalTable: "Litigants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LitigantsCrimes_RefernecesData_CrimeId",
                        column: x => x.CrimeId,
                        principalTable: "RefernecesData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LitigantsCrimes_RefernecesData_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "RefernecesData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RefernecesData",
                columns: new[] { "id", "IsActive", "Key", "Order", "Type", "ValueAr", "ValueEn", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), true, "THEFT", 1, "Crime", "سرقة", "Theft", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), true, "ASSAULT", 2, "Crime", "اعتداء", "Assault", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), true, "FRAUD", 3, "Crime", "احتيال", "Fraud", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("11111111-1111-1111-1111-111111111111"), true, "CONTRACT", 1, "TemplateForCaseContract", "عقد", "Contract", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("20000000-0000-0000-0000-000000000001"), true, "FINE", 1, "CrimePenalty", "غرامة مالية", "Fine", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), true, "IMPRISONMENT", 2, "CrimePenalty", "سجن", "Imprisonment", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), true, "COMMUNITY_SERVICE", 3, "CrimePenalty", "خدمة المجتمع", "Community Service", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), true, "INVOICE", 2, "TemplateForCaseContract", "فاتورة", "Invoice", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), true, "REPORT", 3, "TemplateForCaseContract", "تقرير", "Report", new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "ContractTemplates",
                columns: new[] { "id", "Content", "Name", "TypeId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "<html>\r\n<body>\r\n<h1>عقد إيجار</h1>\r\n<p>تم الاتفاق بين السيد/السيدة ______________________ بتاريخ ______________________</p>\r\n<p>مدة العقد: ______________________ أيام</p>\r\n<p>القيمة: ______________________ جنيه</p>\r\n<p>تفاصيل إضافية: ______________________</p>\r\n</body>\r\n</html>", "عقد إيجار", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "<html>\r\n<body>\r\n<h1>فاتورة مبيعات</h1>\r\n<p>تم إصدار الفاتورة للعميل: ______________________</p>\r\n<p>تاريخ الفاتورة: ______________________</p>\r\n<p>المبلغ: ______________________ جنيه</p>\r\n<p>ملاحظات: ______________________</p>\r\n</body>\r\n</html>", "فاتورة مبيعات", new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "<html>\r\n<body>\r\n<h1>تقرير متابعة</h1>\r\n<p>تم إعداد التقرير للعميل: ______________________</p>\r\n<p>تاريخ التقرير: ______________________</p>\r\n<p>ملاحظات: ______________________</p>\r\n<p>إجراء لاحق: ______________________</p>\r\n</body>\r\n</html>", "تقرير متابعة", new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc), "SystemSeed", null, null, null, false, null, null, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractTemplates_TypeId",
                table: "ContractTemplates",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LitigantsCrimes_CaseId",
                table: "LitigantsCrimes",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LitigantsCrimes_CrimeId",
                table: "LitigantsCrimes",
                column: "CrimeId");

            migrationBuilder.CreateIndex(
                name: "IX_LitigantsCrimes_LitigantId",
                table: "LitigantsCrimes",
                column: "LitigantId");

            migrationBuilder.CreateIndex(
                name: "IX_LitigantsCrimes_PenaltyId",
                table: "LitigantsCrimes",
                column: "PenaltyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractTemplates");

            migrationBuilder.DropTable(
                name: "LitigantsCrimes");

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RefernecesData",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
