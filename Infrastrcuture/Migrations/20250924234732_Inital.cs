using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    displayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseLitigantRole",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CaseLitigantRole", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CasesTopics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    topicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CasesTopics", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CasesTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_CasesTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CourtsGrades",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_CourtsGrades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Litigants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isOrganisation = table.Column<bool>(type: "bit", nullable: false),
                    firstNameAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastNameAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstNameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastNameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationalIdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationalIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Litigants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lawyers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    numberOfPendingCases = table.Column<int>(type: "int", nullable: false),
                    numberOfCurrentCases = table.Column<int>(type: "int", nullable: false),
                    numberOfEndedCases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lawyers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameAR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameEN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    courtGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Courts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Courts_CourtsGrades_courtGradeId",
                        column: x => x.courtGradeId,
                        principalTable: "CourtsGrades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    caseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caseNumberInCourt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caseNumberInCourtComputer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caseNumberInClaim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    governate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    village = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    caseTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    courtGradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Cases", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cases_CasesTopics_caseTopicId",
                        column: x => x.caseTopicId,
                        principalTable: "CasesTopics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_CasesTypes_caseTypeId",
                        column: x => x.caseTypeId,
                        principalTable: "CasesTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_CourtsGrades_courtGradeId",
                        column: x => x.courtGradeId,
                        principalTable: "CourtsGrades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cases_Courts_courtId",
                        column: x => x.courtId,
                        principalTable: "Courts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CaseLitigant",
                columns: table => new
                {
                    caseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    litigantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CaseLitigant", x => new { x.caseId, x.litigantId, x.roleId });
                    table.ForeignKey(
                        name: "FK_CaseLitigant_CaseLitigantRole_roleId",
                        column: x => x.roleId,
                        principalTable: "CaseLitigantRole",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseLitigant_Cases_caseId",
                        column: x => x.caseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseLitigant_Litigants_litigantId",
                        column: x => x.litigantId,
                        principalTable: "Litigants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasesAssignments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    assignedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    assignerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isCurrent = table.Column<bool>(type: "bit", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CasesAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_CasesAssignments_AspNetUsers_assignerId",
                        column: x => x.assignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesAssignments_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CasesAssignments_Lawyers_assignedUserId",
                        column: x => x.assignedUserId,
                        principalTable: "Lawyers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CasesDocuments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    docType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docCategoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uniqueNo = table.Column<int>(type: "int", nullable: false),
                    VsId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CasesDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_CasesDocuments_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasesEvents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    eventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CasesEvents", x => x.id);
                    table.ForeignKey(
                        name: "FK_CasesEvents_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hearings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    currentHearingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nextHearingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Hearings", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hearings_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalClaims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    claimType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    legalBasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_LegalClaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_LegalClaims_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    assignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dueTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_TaskItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Judgements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    verdictText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verdictDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    hearingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Judgements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Judgements_Hearings_hearingId",
                        column: x => x.hearingId,
                        principalTable: "Hearings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JudgementsOrders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isInternal = table.Column<bool>(type: "bit", nullable: false),
                    approvalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    judgementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_JudgementsOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_JudgementsOrders_Judgements_judgementId",
                        column: x => x.judgementId,
                        principalTable: "Judgements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLitigant_litigantId",
                table: "CaseLitigant",
                column: "litigantId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLitigant_roleId",
                table: "CaseLitigant",
                column: "roleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_caseTopicId",
                table: "Cases",
                column: "caseTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_caseTypeId",
                table: "Cases",
                column: "caseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_courtGradeId",
                table: "Cases",
                column: "courtGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_courtId",
                table: "Cases",
                column: "courtId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesAssignments_assignedUserId",
                table: "CasesAssignments",
                column: "assignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesAssignments_assignerId",
                table: "CasesAssignments",
                column: "assignerId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesAssignments_CaseId",
                table: "CasesAssignments",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesDocuments_CaseId",
                table: "CasesDocuments",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasesEvents_CaseId",
                table: "CasesEvents",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_courtGradeId",
                table: "Courts",
                column: "courtGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hearings_CaseId",
                table: "Hearings",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Judgements_hearingId",
                table: "Judgements",
                column: "hearingId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgementsOrders_judgementId",
                table: "JudgementsOrders",
                column: "judgementId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalClaims_CaseId",
                table: "LegalClaims",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CaseId",
                table: "TaskItems",
                column: "CaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaseLitigant");

            migrationBuilder.DropTable(
                name: "CasesAssignments");

            migrationBuilder.DropTable(
                name: "CasesDocuments");

            migrationBuilder.DropTable(
                name: "CasesEvents");

            migrationBuilder.DropTable(
                name: "JudgementsOrders");

            migrationBuilder.DropTable(
                name: "LegalClaims");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CaseLitigantRole");

            migrationBuilder.DropTable(
                name: "Litigants");

            migrationBuilder.DropTable(
                name: "Lawyers");

            migrationBuilder.DropTable(
                name: "Judgements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hearings");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CasesTopics");

            migrationBuilder.DropTable(
                name: "CasesTypes");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "CourtsGrades");
        }
    }
}
