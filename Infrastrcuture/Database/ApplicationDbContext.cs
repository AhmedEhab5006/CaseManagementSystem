using Domain.Entites;
using Infrastrcuture.Auth;
using Infrastrcuture.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

            #region data seeding



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
    }
}
