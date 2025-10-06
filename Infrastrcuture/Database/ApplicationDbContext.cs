using Domain.Entites;
using Domain.Enums;
using Infrastrcuture.Auth;
using Infrastrcuture.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcuture.Database
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);

            #region Converting Enums at different attributes to string to store the leteral value at database


            builder.Entity<Case>()
                   .Property(a => a.status)
                   .HasConversion<string>();


            builder.Entity<Hearing>()
                    .Property(a=>a.scheduledBy)
                    .HasConversion<string>();

            builder.Entity<CaseAssignment>()
                    .Property(a => a.assignedUserRole)
                    .HasConversion<string>();

            
            #endregion

            #region Configuring Case and Litigant Many - to - Many Relationship


            builder.Entity<CaseLitigant>()
            .HasKey(cl => new { cl.caseId, cl.litigantId, cl.roleId });

            builder.Entity<CaseLitigant>()
                .HasOne(cl => cl.Case)
                .WithMany(c => c.CaseLitigants)
                .HasForeignKey(cl => cl.caseId);

            builder.Entity<CaseLitigant>()
                .HasOne(cl => cl.Litigant)
                .WithMany(l => l.CaseLitigants)
                .HasForeignKey(cl => cl.litigantId);

            builder.Entity<CaseLitigant>()
                .HasOne(cl => cl.Role)
                .WithMany(r => r.CaseLitigants)
                .HasForeignKey(cl => cl.roleId);

            #endregion

            #region Configuring Case and Lawyer one - to - many relationship

            builder.Entity<CaseAssignment>()
                            .HasOne<Lawyer>()
                            .WithMany()
                            .HasForeignKey(c => c.assignedUserId)
                            .OnDelete(DeleteBehavior.NoAction);


            #endregion

            #region Configuring Case and Case registration officer one - to - many relationship

            builder.Entity<CaseAssignment>()
                        .HasOne<ApplicationUser>()
                        .WithMany()
                        .HasForeignKey(a => a.assignerId);

            #endregion

            #region Configuring Case Deletion Action 

            builder.Entity<Case>()
                .HasOne(a=>a.court)
                .WithMany(a=>a.Cases)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Configuring TBT in lawyer table

            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            builder.Entity<Lawyer>().ToTable("Lawyers");


            #endregion

            #region Roles Data Seeding

            builder.Entity<ApplicationUserRole>().HasData(
              new ApplicationUserRole
              {
                  Id = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001",
                  Name = "Admin",
                  NormalizedName = "ADMIN",
                  ConcurrencyStamp = "9b1b1a9a-4b46-4b2f-9a0e-111111111111"
              },
              new ApplicationUserRole
              {
                  Id = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002",
                  Name = "Lawyer",
                  NormalizedName = "LAWYER",
                  ConcurrencyStamp = "9b1b1a9a-4b46-4b2f-9a0e-222222222222"
              },
              new ApplicationUserRole
              {
                  Id = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003",
                  Name = "Registration Officer",
                  NormalizedName = "REGISTRATION OFFICER",
                  ConcurrencyStamp = "9b1b1a9a-4b46-4b2f-9a0e-333333333333"
              }
          );





            #endregion

            #region Adding Users and Assign Them to roles Data Seeding

            builder.Entity<ApplicationUser>().HasData(
    new ApplicationUser
    {
        Id = "7a6a2d33-5d69-4d1e-9ef3-000000000001",
        UserName = "AhmedHisham@gmail.com",
        NormalizedUserName = "AHMEDHISHAM@GMAIL.COM",
        Email = "AhmedHisham@gmail.com",
        NormalizedEmail = "AHMEDHISHAM@GMAIL.COM",
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==",
        SecurityStamp = "6d7c0db6-89af-4e38-bc2e-111111111111",
        ConcurrencyStamp = "b6f994c7-3b9c-45d9-8f3e-222222222222",
        PhoneNumberConfirmed = false,
        TwoFactorEnabled = false,
        LockoutEnabled = true,
        AccessFailedCount = 0,
        displayName = "Ahmed Hisham",
        isActive = true,
        CreatedAt = new DateTime(2025 , 09 , 26),
        CreateedBy = "Seed",
        isDeleted = false
    },
    new ApplicationUser
    {
        Id = "7a6a2d33-5d69-4d1e-9ef3-000000000003",
        UserName = "hejab99099@hiepth.com",
        NormalizedUserName = "HEJAB99099@HIEPTH.COM",
        Email = "hejab99099@hiepth.com",
        NormalizedEmail = "HEJAB99099@HIEPTH.COM",
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==",
        SecurityStamp = "6d7c0db6-89af-4e38-bc2e-333333333333",
        ConcurrencyStamp = "b6f994c7-3b9c-45d9-8f3e-444444444444",
        PhoneNumberConfirmed = false,
        TwoFactorEnabled = false,
        LockoutEnabled = true,
        AccessFailedCount = 0,
        displayName = "Ahmed Ayman",
        isActive = true,
        CreatedAt = new DateTime(2025, 09, 26),
        CreateedBy = "Seed",
        isDeleted = false
    }
);

           
            builder.Entity<Lawyer>().HasData(
                new Lawyer
                {
                    Id = "7a6a2d33-5d69-4d1e-9ef3-000000000002",
                    UserName = "abuehab1510@gmail.com",
                    NormalizedUserName = "ABUEHAB1510@GMAIL.COM",
                    Email = "abuehab1510@gmail.com",
                    NormalizedEmail = "ABUEHAB1510@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEGtb0i72XFlbS89FQQKfSVnqluD7460Y6sHBWpYwOE97OBwoCL4WDlVr1r8jjCgezw==",
                    SecurityStamp = "6d7c0db6-89af-4e38-bc2e-555555555555",
                    ConcurrencyStamp = "b6f994c7-3b9c-45d9-8f3e-666666666666",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    displayName = "Ahmed Ehab",
                    isActive = true,
                    CreatedAt = new DateTime(2025, 09, 26),
                    CreateedBy = "Seed",
                    isDeleted = false,
                    numberOfPendingCases = 0,
                    numberOfCurrentCases = 0,
                    numberOfEndedCases = 0
                }
            );

            
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "7a6a2d33-5d69-4d1e-9ef3-000000000001", RoleId = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0001" }, // Admin
                new IdentityUserRole<string> { UserId = "7a6a2d33-5d69-4d1e-9ef3-000000000002", RoleId = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0002" }, // Lawyer
                new IdentityUserRole<string> { UserId = "7a6a2d33-5d69-4d1e-9ef3-000000000003", RoleId = "f5a0a1f3-5f7c-4a35-9b0e-0a9c4f0b0003" }  // Registration Officer
            );

            #endregion

            #region Cases Data Seeding
            // ======================= Court Grades =======================
            builder.Entity<CourtGrade>().HasData(
                new CourtGrade
                {
                    id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    nameAR = "محكمة النقض",
                    nameEN = "Court of Cassation",
                    order = "1",
                    isActive = true,
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 01),
                    isDeleted = false,
                    versionNo = 1
                },
                new CourtGrade
                {
                    id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    nameAR = "محكمة الاستئناف",
                    nameEN = "Court of Appeal",
                    order = "2",
                    isActive = true,
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 01),
                    isDeleted = false,
                    versionNo = 1
                },
                new CourtGrade
                {
                    id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    nameAR = "المحكمة الابتدائية",
                    nameEN = "Primary Court",
                    order = "3",
                    isActive = true,
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 01),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // ======================= Courts =======================
            builder.Entity<Court>().HasData(
                new Court
                {
                    id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    nameAR = "محكمة القاهرة الابتدائية",
                    nameEN = "Cairo Primary Court",
                    city = "القاهرة",
                    isActive = true,
                    courtGradeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 02),
                    isDeleted = false,
                    versionNo = 1
                },
                new Court
                {
                    id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    nameAR = "محكمة الإسكندرية الابتدائية",
                    nameEN = "Alexandria Primary Court",
                    city = "الإسكندرية",
                    isActive = true,
                    courtGradeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 02),
                    isDeleted = false,
                    versionNo = 1
                },
                new Court
                {
                    id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                    nameAR = "محكمة القاهرة الاستئنافية",
                    nameEN = "Cairo Court of Appeal",
                    city = "القاهرة",
                    isActive = true,
                    courtGradeId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 02),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // ======================= Case Types =======================
            builder.Entity<CaseType>().HasData(
                new CaseType
                {
                    id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    typeName = "قضية مدنية",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 03),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseType
                {
                    id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    typeName = "قضية جنائية",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 03),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseType
                {
                    id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                    typeName = "قضية تجارية",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 03),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseType
                {
                    id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    typeName = "قضية عمالية",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 03),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // ======================= Case Topics =======================
            builder.Entity<CaseTopic>().HasData(
                new CaseTopic
                {
                    id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    topicName = "تعويضات",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 04),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseTopic
                {
                    id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    topicName = "طلاق",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 04),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseTopic
                {
                    id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    topicName = "نفقة",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 04),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseTopic
                {
                    id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                    topicName = "عقد عمل",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 04),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseTopic
                {
                    id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                    topicName = "ميراث",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 04),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // ======================= Litigants =======================
            builder.Entity<Litigant>().HasData(
                new Litigant
                {
                    id = Guid.Parse("50505050-5050-5050-5050-505050505050"),
                    isOrganisation = false,
                    firstNameAR = "أحمد",
                    lastNameAR = "محمد",
                    firstNameEN = "Ahmed",
                    lastNameEN = "Mohamed",
                    nationalIdNumber = "12345678901234",
                    nationalIdType = "رقم قومي",
                    phoneNumber = "01234567890",
                    address = "شارع التحرير، القاهرة",
                    email = "ahmed.mohamed@email.com",
                    country = "مصر",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 05),
                    isDeleted = false,
                    versionNo = 1
                },
                new Litigant
                {
                    id = Guid.Parse("60606060-6060-6060-6060-606060606060"),
                    isOrganisation = false,
                    firstNameAR = "فاطمة",
                    lastNameAR = "علي",
                    firstNameEN = "Fatma",
                    lastNameEN = "Ali",
                    nationalIdNumber = "98765432109876",
                    nationalIdType = "رقم قومي",
                    phoneNumber = "01987654321",
                    address = "شارع الهرم، الجيزة",
                    email = "fatma.ali@email.com",
                    country = "مصر",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 05),
                    isDeleted = false,
                    versionNo = 1
                },
                new Litigant
                {
                    id = Guid.Parse("70707070-7070-7070-7070-707070707070"),
                    isOrganisation = true,
                    firstNameAR = "شركة الاخوة المتحدون للتوريدات",
                    lastNameAR = "ش.م.م",
                    firstNameEN = "United Pros",
                    lastNameEN = "A.R.E",
                    nationalIdNumber = "12345678901234",
                    nationalIdType = "سجل تجاري",
                    phoneNumber = "02234567890",
                    address = "ميدان التحرير، القاهرة",
                    email = "company@email.com",
                    country = "مصر",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 05),
                    isDeleted = false,
                    versionNo = 1
                },
                new Litigant
                {
                    id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                    isOrganisation = true,
                    firstNameAR = "شركة النصر للسيارات",
                    lastNameAR = "ش.م.م",
                    firstNameEN = "Nasr Auto",
                    lastNameEN = "A.R.E",
                    nationalIdNumber = "12348756901234",
                    nationalIdType = "رقم قومي",
                    phoneNumber = "02234567890",
                    address = "ميدان التحرير، القاهرة",
                    email = "company2@email.com",
                    country = "مصر",
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 05),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            builder.Entity<CaseLitigantRole>().HasData(
               new CaseLitigantRole
               {
                   id = Guid.Parse("10101010-1010-1010-1010-101010101010"),
                   roleName = "مدعى",
                   createdBy = "System",
                   createdAt = new DateTime(2024, 01, 05),
                   isDeleted = false,
                   versionNo = 1
               },
               
               new CaseLitigantRole
               {
                   id = Guid.Parse("20202020-2020-2020-2020-202020202020"),
                   roleName = "مدعى عليه",
                   createdBy = "System",
                   createdAt = new DateTime(2024, 01, 05),
                   isDeleted = false,
                   versionNo = 1
               }
               );
           // ======================= Cases =======================
           builder.Entity<Case>().HasData(
                new Case
                {
                    id = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    caseDate = new DateOnly(2024, 01, 15),
                    caseNumber = "2024/001",
                    caseNumberInCourt = "12345/2024",
                    caseNumberInCourtComputer = "2024001234",
                    caseNumberInClaim = "CLAIM-2024-001",
                    status = CaseStatus.Registered,
                    approved = true,
                    governate = "القاهرة",
                    state = "مصر",
                    village = "وسط البلد",
                    description = "قضية تعويض عن ضرر مادي ومعنوي",
                    courtId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    caseTypeId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    caseTopicId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    courtGradeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 15),
                    isDeleted = false,
                    versionNo = 1
                },
                new Case
                {
                    id = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    caseDate = new DateOnly(2024, 02, 20),
                    caseNumber = "2024/002",
                    caseNumberInCourt = "54321/2024",
                    caseNumberInCourtComputer = "2024002345",
                    caseNumberInClaim = "CLAIM-2024-002",
                    status = CaseStatus.UnderStudy,
                    approved = false,
                    governate = "الإسكندرية",
                    state = "مصر",
                    village = "سيدي بشر",
                    description = "قضية طلاق ونفقة",
                    courtId = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    caseTypeId = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                    caseTopicId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    courtGradeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 02, 20),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Case Litigants
            builder.Entity<CaseLitigant>().HasData(
                new CaseLitigant
                {
                    caseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    litigantId = Guid.Parse("50505050-5050-5050-5050-505050505050"),
                    roleId = Guid.Parse("10101010-1010-1010-1010-101010101010"),
                    createdAt = new DateTime(2024 , 01 , 15),
                    createdBy = "System"
                },
                new CaseLitigant
                {
                    caseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    litigantId = Guid.Parse("70707070-7070-7070-7070-707070707070"),
                    roleId = Guid.Parse("20202020-2020-2020-2020-202020202020"),
                    createdAt = new DateTime(2024, 01, 15),
                    createdBy = "System"
                },
                new CaseLitigant
                {
                    caseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    litigantId = Guid.Parse("60606060-6060-6060-6060-606060606060"),
                    roleId = Guid.Parse("10101010-1010-1010-1010-101010101010"),
                    createdAt = new DateTime(2024, 02, 20),
                    createdBy = "System"
                },
                                new CaseLitigant
                                {
                                    caseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                                    litigantId = Guid.Parse("60606060-6060-6060-6060-606060606060"),
                                    roleId = Guid.Parse("20202020-2020-2020-2020-202020202020"),
                                    createdAt = new DateTime(2024, 02, 20),
                                    createdBy = "System"
                                }
            );

            // Legal Claims
            builder.Entity<LegalClaim>().HasData(
                new LegalClaim
                {
                    id = Guid.Parse("d4d4d4d4-d4d4-d4d4-d4d4-d4d4d4d4d4d4"),
                    amount = 50000.00,
                    currency = "جنيه مصري",
                    claimType = "تعويض مادي",
                    legalBasis = "المادة 163 من القانون المدني",
                    notes = "تعويض عن الأضرار المادية والمعنوية",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 16),
                    isDeleted = false,
                    versionNo = 1
                },
                new LegalClaim
                {
                    id = Guid.Parse("e5e5e5e5-e5e5-e5e5-e5e5-e5e5e5e5e5e5"),
                    amount = 2000.00,
                    currency = "جنيه مصري",
                    claimType = "نفقة شهرية",
                    legalBasis = "قانون الأحوال الشخصية",
                    notes = "نفقة شهرية للأطفال",
                    CaseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 02, 21),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Case Events
            builder.Entity<CaseEvent>().HasData(
                new CaseEvent
                {
                    id = Guid.Parse("f6f6f6f6-f6f6-4f6f-a6f6-f6f6f6f6f6f6"),
                    eventType = "تسجيل القضية",
                    details = "تم تسجيل القضية في المحكمة الابتدائية",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 17),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseEvent
                {
                    id = Guid.Parse("a17f7c85-8b64-4a6d-9f59-4f3d8f18d3d3"),
                    eventType = "إيداع مذكرة دفاع",
                    details = "تم إيداع مذكرة الدفاع الأولى",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 18),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseEvent
                {
                    id = Guid.Parse("c1f4de2a-0d94-45ff-8f42-32e6b6d7b6d7"),
                    eventType = "تسجيل القضية",
                    details = "تم تسجيل قضية الطلاق والنفقة",
                    CaseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 02, 22),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Case Documents
            builder.Entity<CaseDocument>().HasData(
                new CaseDocument
                {
                    id = Guid.Parse("1f6c9b63-9e45-421f-915c-f45c7b65c7c7"),
                    docType = "مذكرة دفاع",
                    docCategoryCode = "DEFENSE",
                    uniqueNo = 2,
                    VsId = "VS002",
                    description = "مذكرة الدفاع الأولى",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 19),
                    isDeleted = false,
                    versionNo = 1
                },
                new CaseDocument
                {
                    id = Guid.Parse("2d2f1a45-bd6e-4c2c-aea1-7c37c68b68b6"),
                    docType = "طلب طلاق",
                    docCategoryCode = "DIVORCE",
                    uniqueNo = 1,
                    VsId = "VS003",
                    description = "طلب طلاق ونفقة",
                    CaseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 02, 23),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Hearings
            builder.Entity<Hearing>().HasData(
                new Hearing
                {
                    id = Guid.Parse("3a42d6d5-bc3f-4b85-bc1c-dc24a8d24a8d"),
                    number = 1,
                    currentHearingDate = new DateTime(2024, 3, 15, 10, 0, 0),
                    nextHearingDate = new DateTime(2024, 4, 15, 10, 0, 0),
                    scheduledBy = HearingScheduler.Lawyer,
                    location = "قاعة المحكمة رقم 1",
                    notes = "جلسة استماع أولى",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"),
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 20),
                    isDeleted = false,
                    versionNo = 1
                },
                 new Hearing
                 {
                     id = Guid.Parse("4c56f3f7-78b6-4f9f-8e3d-4f68b3f68b3f"),
                     number = 1,
                     currentHearingDate = new DateTime(2024, 3, 20, 11, 0, 0),
                     nextHearingDate = new DateTime(2024, 4, 20, 11, 0, 0),
                     scheduledBy = HearingScheduler.Lawyer,
                     location = "قاعة المحكمة رقم 2",
                     notes = "جلسة أولى لقضية الطلاق والنفقة",
                     CaseId = Guid.Parse("90909090-9090-9090-9090-909090909090"),
                     createdBy = "System",
                     createdAt = new DateTime(2024, 02, 24),
                     isDeleted = false,
                     versionNo = 1
                 }
            );

            // Judgements
            builder.Entity<Judgement>().HasData(
                new Judgement
                {
                    id = Guid.Parse("5b12e4e4-2f91-40c3-8d93-63e56f56f56f"),
                    verdictText = "حكمت المحكمة بالتعويض عن الضرر المادي والمعنوي",
                    verdictDate = new DateTime(2024, 5, 15),
                    isApproved = true,
                    hearingId = Guid.Parse("3a42d6d5-bc3f-4b85-bc1c-dc24a8d24a8d"), // FK → Hearing
                    createdBy = "System",
                    createdAt = new DateTime(2024, 05, 16),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Judgement Orders
            builder.Entity<JudgementOrder>().HasData(
                new JudgementOrder
                {
                    id = Guid.Parse("7e41c2c2-89f7-4b92-b9c3-32f6d9f6d9f6"),
                    orderType = "تعويض مالي",
                    isInternal = false,
                    approvalStatus = "موافق عليه",
                    judgementId = Guid.Parse("5b12e4e4-2f91-40c3-8d93-63e56f56f56f"), // FK → Judgement
                    createdBy = "System",
                    createdAt = new DateTime(2024, 05, 17),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            // Tasks
            builder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    id = Guid.Parse("9a42e5e5-1b67-4f93-8a23-12f6a7f6a7f6"),
                    title = "إعداد مذكرة الدفاع",
                    assignedTo = "محامي",
                    dueTo = new DateTime(2024, 3, 10),
                    status = "مكتمل",
                    CaseId = Guid.Parse("80808080-8080-8080-8080-808080808080"), // FK → Case
                    createdBy = "System",
                    createdAt = new DateTime(2024, 01, 21),
                    isDeleted = false,
                    versionNo = 1
                },
                new TaskItem
                {
                    id = Guid.Parse("af31b6b6-27f3-4c42-9c73-22c6c8c6c8c6"),
                    title = "جمع المستندات المطلوبة",
                    assignedTo = "باحث قانوني",
                    dueTo = new DateTime(2024, 3, 25),
                    status = "قيد التنفيذ",
                    CaseId = Guid.Parse("90909090-9090-9090-9090-909090909090"), // FK → Case
                    createdBy = "System",
                    createdAt = new DateTime(2024, 02, 25),
                    isDeleted = false,
                    versionNo = 1
                }
            );

            #endregion
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseAssignment> CasesAssignments { get; set; }
        public DbSet<CaseDocument> CasesDocuments { get; set; }
        public DbSet<CaseEvent> CasesEvents { get; set; }
        public DbSet<CaseLitigant> CasesLitigants { get; set; }
        public DbSet<CaseLitigant> CasesLitigantRoles { get; set; }
        public DbSet<CaseTopic> CasesTopics { get; set; }
        public DbSet<CaseType> CasesTypes { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<CourtGrade> CourtsGrades { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<Judgement> Judgements { get; set; }
        public DbSet<JudgementOrder> JudgementsOrders { get; set; }
        public DbSet<LegalClaim> LegalClaims { get; set; }
        public DbSet<Litigant> Litigants { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
    }
}
