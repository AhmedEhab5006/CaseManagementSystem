using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class PhaseOneCreatingAllCaseRelatedEntitesAndUsersTablesAndAlsoApplingDataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "scheduledBy",
                table: "Hearings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "assignedUserRole",
                table: "CasesAssignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deletedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deletionReason",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", "9b1b1a9a-4b46-4b2f-9a0e-111111111111", "ApplicationUserRole", "Admin", "ADMIN" },
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002", "9b1b1a9a-4b46-4b2f-9a0e-222222222222", "ApplicationUserRole", "Lawyer", "LAWYER" },
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003", "9b1b1a9a-4b46-4b2f-9a0e-333333333333", "ApplicationUserRole", "Registration Officer", "REGISTRATION OFFICER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "CreateedBy", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "ModifiedAt", "ModifiedBy", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "deletedAt", "deletedBy", "deletionReason", "displayName", "isActive", "isDeleted" },
                values: new object[,]
                {
                    { "7a6a2d33-5d69-4d1e-9ef3-000000000001", 0, "b6f994c7-3b9c-45d9-8f3e-222222222222", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed", "AhmedHisham@gmail.com", true, true, null, null, null, "AHMEDHISHAM@GMAIL.COM", "AHMEDHISHAM@GMAIL.COM", "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==", null, false, "6d7c0db6-89af-4e38-bc2e-111111111111", false, "AhmedHisham@gmail.com", null, null, null, "Ahmed Hisham", true, false },
                    { "7a6a2d33-5d69-4d1e-9ef3-000000000002", 0, "b6f994c7-3b9c-45d9-8f3e-666666666666", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed", "abuehab1510@gmail.com", true, true, null, null, null, "ABUEHAB1510@GMAIL.COM", "ABUEHAB1510@GMAIL.COM", "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==", null, false, "6d7c0db6-89af-4e38-bc2e-555555555555", false, "abuehab1510@gmail.com", null, null, null, "Ahmed Ehab", true, false },
                    { "7a6a2d33-5d69-4d1e-9ef3-000000000003", 0, "b6f994c7-3b9c-45d9-8f3e-444444444444", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seed", "hejab99099@hiepth.com", true, true, null, null, null, "HEJAB99099@HIEPTH.COM", "HEJAB99099@HIEPTH.COM", "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==", null, false, "6d7c0db6-89af-4e38-bc2e-333333333333", false, "hejab99099@hiepth.com", null, null, null, "Ahmed Ayman", true, false }
                });

            migrationBuilder.InsertData(
                table: "CaseLitigantRole",
                columns: new[] { "id", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "roleName", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("10101010-1010-1010-1010-101010101010"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, "مدعى", null, null, null, 1 },
                    { new Guid("20202020-2020-2020-2020-202020202020"), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, "مدعى عليه", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CasesTopics",
                columns: new[] { "id", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "topicName", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "تعويضات", null, null, 1 },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "طلاق", null, null, 1 },
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "نفقة", null, null, 1 },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "عقد عمل", null, null, 1 },
                    { new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"), new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "ميراث", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CasesTypes",
                columns: new[] { "id", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "rowVersion", "typeName", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "قضية مدنية", null, null, 1 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "قضية جنائية", null, null, 1 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "قضية تجارية", null, null, 1 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, null, "قضية عمالية", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourtsGrades",
                columns: new[] { "id", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isActive", "isDeleted", "nameAR", "nameEN", "order", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "محكمة النقض", "Court of Cassation", "1", null, null, null, 1 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "محكمة الاستئناف", "Court of Appeal", "2", null, null, null, 1 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "المحكمة الابتدائية", "Primary Court", "3", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Litigants",
                columns: new[] { "id", "address", "country", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "email", "firstNameAR", "firstNameEN", "isDeleted", "isOrganisation", "lastNameAR", "lastNameEN", "nationalIdNumber", "nationalIdType", "phoneNumber", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("50505050-5050-5050-5050-505050505050"), "شارع التحرير، القاهرة", "مصر", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "ahmed.mohamed@email.com", "أحمد", "Ahmed", false, false, "محمد", "Mohamed", "12345678901234", "رقم قومي", "01234567890", null, null, null, 1 },
                    { new Guid("60606060-6060-6060-6060-606060606060"), "شارع الهرم، الجيزة", "مصر", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "fatma.ali@email.com", "فاطمة", "Fatma", false, false, "علي", "Ali", "98765432109876", "رقم قومي", "01987654321", null, null, null, 1 },
                    { new Guid("70707070-7070-7070-7070-707070707070"), "ميدان التحرير، القاهرة", "مصر", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "company@email.com", "شركة الاخوة المتحدون للتوريدات", "United Pros", false, true, "ش.م.م", "A.R.E", "12345678901234", "سجل تجاري", "02234567890", null, null, null, 1 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "ميدان التحرير، القاهرة", "مصر", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "company2@email.com", "شركة النصر للسيارات", "Nasr Auto", false, true, "ش.م.م", "A.R.E", "12348756901234", "رقم قومي", "02234567890", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", "7a6a2d33-5d69-4d1e-9ef3-000000000001" },
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002", "7a6a2d33-5d69-4d1e-9ef3-000000000002" },
                    { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003", "7a6a2d33-5d69-4d1e-9ef3-000000000003" }
                });

            migrationBuilder.InsertData(
                table: "Courts",
                columns: new[] { "id", "city", "courtGradeId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isActive", "isDeleted", "nameAR", "nameEN", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "القاهرة", new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "محكمة القاهرة الابتدائية", "Cairo Primary Court", null, null, null, 1 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "الإسكندرية", new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "محكمة الإسكندرية الابتدائية", "Alexandria Primary Court", null, null, null, 1 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "القاهرة", new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, true, false, "محكمة القاهرة الاستئنافية", "Cairo Court of Appeal", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Lawyers",
                columns: new[] { "Id", "numberOfCurrentCases", "numberOfEndedCases", "numberOfPendingCases" },
                values: new object[] { "7a6a2d33-5d69-4d1e-9ef3-000000000002", 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "id", "approved", "caseDate", "caseNumber", "caseNumberInClaim", "caseNumberInCourt", "caseNumberInCourtComputer", "caseTopicId", "caseTypeId", "courtGradeId", "courtId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "description", "governate", "isDeleted", "rowVersion", "state", "status", "updatedAt", "updatedBy", "versionNo", "village" },
                values: new object[,]
                {
                    { new Guid("80808080-8080-8080-8080-808080808080"), true, new DateOnly(2024, 1, 15), "2024/001", "CLAIM-2024-001", "12345/2024", "2024001234", new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("77777777-7777-7777-7777-777777777777"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "قضية تعويض عن ضرر مادي ومعنوي", "القاهرة", false, null, "مصر", "Registered", null, null, 1, "وسط البلد" },
                    { new Guid("90909090-9090-9090-9090-909090909090"), false, new DateOnly(2024, 2, 20), "2024/002", "CLAIM-2024-002", "54321/2024", "2024002345", new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("77777777-7777-7777-7777-777777777777"), new Guid("33333333-3333-3333-3333-333333333333"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "قضية طلاق ونفقة", "الإسكندرية", false, null, "مصر", "UnderStudy", null, null, 1, "سيدي بشر" }
                });

            migrationBuilder.InsertData(
                table: "CaseLitigant",
                columns: new[] { "caseId", "litigantId", "roleId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "id", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("80808080-8080-8080-8080-808080808080"), new Guid("50505050-5050-5050-5050-505050505050"), new Guid("10101010-1010-1010-1010-101010101010"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, 0 },
                    { new Guid("80808080-8080-8080-8080-808080808080"), new Guid("70707070-7070-7070-7070-707070707070"), new Guid("20202020-2020-2020-2020-202020202020"), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, 0 },
                    { new Guid("90909090-9090-9090-9090-909090909090"), new Guid("60606060-6060-6060-6060-606060606060"), new Guid("10101010-1010-1010-1010-101010101010"), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, 0 },
                    { new Guid("90909090-9090-9090-9090-909090909090"), new Guid("60606060-6060-6060-6060-606060606060"), new Guid("20202020-2020-2020-2020-202020202020"), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "CasesDocuments",
                columns: new[] { "id", "CaseId", "FileAssetId", "VsId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "description", "docCategoryCode", "docType", "isDeleted", "rowVersion", "uniqueNo", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("1f6c9b63-9e45-421f-915c-f45c7b65c7c7"), new Guid("80808080-8080-8080-8080-808080808080"), null, "VS002", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "مذكرة الدفاع الأولى", "DEFENSE", "مذكرة دفاع", false, null, 2, null, null, 1 },
                    { new Guid("2d2f1a45-bd6e-4c2c-aea1-7c37c68b68b6"), new Guid("90909090-9090-9090-9090-909090909090"), null, "VS003", new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "طلب طلاق ونفقة", "DIVORCE", "طلب طلاق", false, null, 1, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "CasesEvents",
                columns: new[] { "id", "CaseId", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "details", "eventType", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("a17f7c85-8b64-4a6d-9f59-4f3d8f18d3d3"), new Guid("80808080-8080-8080-8080-808080808080"), new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "تم إيداع مذكرة الدفاع الأولى", "إيداع مذكرة دفاع", false, null, null, null, 1 },
                    { new Guid("c1f4de2a-0d94-45ff-8f42-32e6b6d7b6d7"), new Guid("90909090-9090-9090-9090-909090909090"), new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "تم تسجيل قضية الطلاق والنفقة", "تسجيل القضية", false, null, null, null, 1 },
                    { new Guid("f6f6f6f6-f6f6-4f6f-a6f6-f6f6f6f6f6f6"), new Guid("80808080-8080-8080-8080-808080808080"), new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, "تم تسجيل القضية في المحكمة الابتدائية", "تسجيل القضية", false, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Hearings",
                columns: new[] { "id", "CaseId", "createdAt", "createdBy", "currentHearingDate", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "location", "nextHearingDate", "notes", "number", "rowVersion", "scheduledBy", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("3a42d6d5-bc3f-4b85-bc1c-dc24a8d24a8d"), new Guid("80808080-8080-8080-8080-808080808080"), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2024, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, "قاعة المحكمة رقم 1", new DateTime(2024, 4, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "جلسة استماع أولى", 1, null, "Lawyer", null, null, 1 },
                    { new Guid("4c56f3f7-78b6-4f9f-8e3d-4f68b3f68b3f"), new Guid("90909090-9090-9090-9090-909090909090"), new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", new DateTime(2024, 3, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, "قاعة المحكمة رقم 2", new DateTime(2024, 4, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), "جلسة أولى لقضية الطلاق والنفقة", 1, null, "Lawyer", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "LegalClaims",
                columns: new[] { "id", "CaseId", "amount", "claimType", "createdAt", "createdBy", "currency", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "legalBasis", "notes", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"), new Guid("80808080-8080-8080-8080-808080808080"), 50000.0, "تعويض مادي", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "جنيه مصري", null, null, null, false, "المادة 163 من القانون المدني", "تعويض عن الأضرار المادية والمعنوية", null, null, null, 1 },
                    { new Guid("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"), new Guid("90909090-9090-9090-9090-909090909090"), 2000.0, "نفقة شهرية", new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "جنيه مصري", null, null, null, false, "قانون الأحوال الشخصية", "نفقة شهرية للأطفال", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "id", "CaseId", "assignedTo", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "dueTo", "isDeleted", "rowVersion", "status", "title", "updatedAt", "updatedBy", "versionNo" },
                values: new object[,]
                {
                    { new Guid("9a42e5e5-1b67-4f93-8a23-12f6a7f6a7f6"), new Guid("80808080-8080-8080-8080-808080808080"), "محامي", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "مكتمل", "إعداد مذكرة الدفاع", null, null, 1 },
                    { new Guid("af31b6b6-27f3-4c42-9c73-22c6c8c6c8c6"), new Guid("90909090-9090-9090-9090-909090909090"), "باحث قانوني", new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "قيد التنفيذ", "جمع المستندات المطلوبة", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Judgements",
                columns: new[] { "id", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "hearingId", "isApproved", "isDeleted", "rowVersion", "updatedAt", "updatedBy", "verdictDate", "verdictText", "versionNo" },
                values: new object[] { new Guid("5b12e4e4-2f91-40c3-8d93-63e56f56f56f"), new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, new Guid("3a42d6d5-bc3f-4b85-bc1c-dc24a8d24a8d"), true, false, null, null, null, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "حكمت المحكمة بالتعويض عن الضرر المادي والمعنوي", 1 });

            migrationBuilder.InsertData(
                table: "JudgementsOrders",
                columns: new[] { "id", "approvalStatus", "createdAt", "createdBy", "deletedAt", "deletedBy", "deletionReason", "isDeleted", "isInternal", "judgementId", "orderType", "rowVersion", "updatedAt", "updatedBy", "versionNo" },
                values: new object[] { new Guid("7e41c2c2-89f7-4b92-b9c3-32f6d9f6d9f6"), "موافق عليه", new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, null, false, false, new Guid("5b12e4e4-2f91-40c3-8d93-63e56f56f56f"), "تعويض مالي", null, null, null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001", "7a6a2d33-5d69-4d1e-9ef3-000000000001" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002", "7a6a2d33-5d69-4d1e-9ef3-000000000002" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003", "7a6a2d33-5d69-4d1e-9ef3-000000000003" });

            migrationBuilder.DeleteData(
                table: "CaseLitigant",
                keyColumns: new[] { "caseId", "litigantId", "roleId" },
                keyValues: new object[] { new Guid("80808080-8080-8080-8080-808080808080"), new Guid("50505050-5050-5050-5050-505050505050"), new Guid("10101010-1010-1010-1010-101010101010") });

            migrationBuilder.DeleteData(
                table: "CaseLitigant",
                keyColumns: new[] { "caseId", "litigantId", "roleId" },
                keyValues: new object[] { new Guid("80808080-8080-8080-8080-808080808080"), new Guid("70707070-7070-7070-7070-707070707070"), new Guid("20202020-2020-2020-2020-202020202020") });

            migrationBuilder.DeleteData(
                table: "CaseLitigant",
                keyColumns: new[] { "caseId", "litigantId", "roleId" },
                keyValues: new object[] { new Guid("90909090-9090-9090-9090-909090909090"), new Guid("60606060-6060-6060-6060-606060606060"), new Guid("10101010-1010-1010-1010-101010101010") });

            migrationBuilder.DeleteData(
                table: "CaseLitigant",
                keyColumns: new[] { "caseId", "litigantId", "roleId" },
                keyValues: new object[] { new Guid("90909090-9090-9090-9090-909090909090"), new Guid("60606060-6060-6060-6060-606060606060"), new Guid("20202020-2020-2020-2020-202020202020") });

            migrationBuilder.DeleteData(
                table: "CasesDocuments",
                keyColumn: "id",
                keyValue: new Guid("1f6c9b63-9e45-421f-915c-f45c7b65c7c7"));

            migrationBuilder.DeleteData(
                table: "CasesDocuments",
                keyColumn: "id",
                keyValue: new Guid("2d2f1a45-bd6e-4c2c-aea1-7c37c68b68b6"));

            migrationBuilder.DeleteData(
                table: "CasesEvents",
                keyColumn: "id",
                keyValue: new Guid("a17f7c85-8b64-4a6d-9f59-4f3d8f18d3d3"));

            migrationBuilder.DeleteData(
                table: "CasesEvents",
                keyColumn: "id",
                keyValue: new Guid("c1f4de2a-0d94-45ff-8f42-32e6b6d7b6d7"));

            migrationBuilder.DeleteData(
                table: "CasesEvents",
                keyColumn: "id",
                keyValue: new Guid("f6f6f6f6-f6f6-4f6f-a6f6-f6f6f6f6f6f6"));

            migrationBuilder.DeleteData(
                table: "CasesTopics",
                keyColumn: "id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "CasesTopics",
                keyColumn: "id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "CasesTopics",
                keyColumn: "id",
                keyValue: new Guid("ffffffff-ffff-ffff-ffff-ffffffffffff"));

            migrationBuilder.DeleteData(
                table: "CasesTypes",
                keyColumn: "id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "CasesTypes",
                keyColumn: "id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "CasesTypes",
                keyColumn: "id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "CourtsGrades",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Hearings",
                keyColumn: "id",
                keyValue: new Guid("4c56f3f7-78b6-4f9f-8e3d-4f68b3f68b3f"));

            migrationBuilder.DeleteData(
                table: "JudgementsOrders",
                keyColumn: "id",
                keyValue: new Guid("7e41c2c2-89f7-4b92-b9c3-32f6d9f6d9f6"));

            migrationBuilder.DeleteData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: "7a6a2d33-5d69-4d1e-9ef3-000000000002");

            migrationBuilder.DeleteData(
                table: "LegalClaims",
                keyColumn: "id",
                keyValue: new Guid("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"));

            migrationBuilder.DeleteData(
                table: "LegalClaims",
                keyColumn: "id",
                keyValue: new Guid("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"));

            migrationBuilder.DeleteData(
                table: "Litigants",
                keyColumn: "id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "id",
                keyValue: new Guid("9a42e5e5-1b67-4f93-8a23-12f6a7f6a7f6"));

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "id",
                keyValue: new Guid("af31b6b6-27f3-4c42-9c73-22c6c8c6c8c6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a6a2d33-5d69-4d1e-9ef3-000000000001");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a6a2d33-5d69-4d1e-9ef3-000000000002");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a6a2d33-5d69-4d1e-9ef3-000000000003");

            migrationBuilder.DeleteData(
                table: "CaseLitigantRole",
                keyColumn: "id",
                keyValue: new Guid("10101010-1010-1010-1010-101010101010"));

            migrationBuilder.DeleteData(
                table: "CaseLitigantRole",
                keyColumn: "id",
                keyValue: new Guid("20202020-2020-2020-2020-202020202020"));

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("90909090-9090-9090-9090-909090909090"));

            migrationBuilder.DeleteData(
                table: "CourtsGrades",
                keyColumn: "id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Judgements",
                keyColumn: "id",
                keyValue: new Guid("5b12e4e4-2f91-40c3-8d93-63e56f56f56f"));

            migrationBuilder.DeleteData(
                table: "Litigants",
                keyColumn: "id",
                keyValue: new Guid("50505050-5050-5050-5050-505050505050"));

            migrationBuilder.DeleteData(
                table: "Litigants",
                keyColumn: "id",
                keyValue: new Guid("60606060-6060-6060-6060-606060606060"));

            migrationBuilder.DeleteData(
                table: "Litigants",
                keyColumn: "id",
                keyValue: new Guid("70707070-7070-7070-7070-707070707070"));

            migrationBuilder.DeleteData(
                table: "CasesTopics",
                keyColumn: "id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Hearings",
                keyColumn: "id",
                keyValue: new Guid("3a42d6d5-bc3f-4b85-bc1c-dc24a8d24a8d"));

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "id",
                keyValue: new Guid("80808080-8080-8080-8080-808080808080"));

            migrationBuilder.DeleteData(
                table: "CasesTopics",
                keyColumn: "id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "CasesTypes",
                keyColumn: "id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Courts",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "CourtsGrades",
                keyColumn: "id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DropColumn(
                name: "scheduledBy",
                table: "Hearings");

            migrationBuilder.DropColumn(
                name: "assignedUserRole",
                table: "CasesAssignments");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deletedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deletedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "deletionReason",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
