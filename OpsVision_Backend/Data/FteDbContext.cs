using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;


using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Model;
using Model.Transaction;
using Model.History;

namespace OpsVision_Backend.Data
{
    public class FteDbContext : DbContext

    {

        public FteDbContext(DbContextOptions<FteDbContext> options)

            : base(options)

        {

        }



        // Master Tables

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<JobTitles> JobTitles { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<Locations> Locations { get; set; }

        public DbSet<Shifts> Shifts { get; set; }

        public DbSet<StaffStatus> StaffStatuses { get; set; }

        public DbSet<EmploymentType> EmploymentTypes { get; set; }

        public DbSet<StaffClasses> StaffClasses { get; set; }

        public DbSet<Vendors> Vendors { get; set; }

        public DbSet<ManagementCodes> ManagementCodes { get; set; }

        public DbSet<OrgRelationships> OrganizationalRelationships { get; set; }

        public DbSet<Projects> Projects { get; set; }
        public DbSet<HolidayCalender> HolidayCalenders { get; set; }

        //Transaction Tables
        public DbSet<ProjectFteAllocation> ProjectFteAllocations { get; set; }

        public DbSet<FteAllocation> FteAllocations { get; set; }

        public DbSet<FteCommittedLog> FteCommittedLogs { get; set; }

        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        public DbSet<EmployeeAllocation> EmployeeAllocations { get; set; }
        public DbSet<CompletedHoursLog> CompletedHoursLogs { get; set; }

        //History Tables
        public DbSet<EmploymentHistory> EmploymentHistories { get; set; }

        public DbSet<ReportingHistory> ReportingHistories { get; set; }

        public DbSet<TerminationLog> TerminationLogs { get; set; }

        public DbSet<AuditTrail> AuditTrails { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            
            modelBuilder.Entity<Staff>()
                .HasIndex(s  => s.StaffNumber)
                .IsUnique();

            // Role to User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);


            // Project->Owner(Staff)
            modelBuilder.Entity<Projects>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId);

            // PrimeCode mapping in ProjectFteAllocation
            modelBuilder.Entity<ProjectFteAllocation>()
                .HasOne(pfa => pfa.Project)
                .WithMany(p => p.FteAllocations)
                .HasForeignKey(pfa => pfa.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // FteAllocation to FteCommittedLogs
            modelBuilder.Entity<FteCommittedLog>()
                .HasOne(cl => cl.FteAllocation)
                .WithMany(fa => fa.CommittedLogs)
                .HasForeignKey(cl => cl.FteAllocationId);

            // Staff reports to another Staff
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.ReportsTo)
                .WithMany(m => m.DirectReports)
                .HasForeignKey(s => s.ReportsToStaffId)
                .OnDelete(DeleteBehavior.Restrict);

                        
            // ReportingHistory Relationships
            modelBuilder.Entity<ReportingHistory>()
                .HasOne(r => r.Staff)
                .WithMany(s => s.ReportingHistories)
                .HasForeignKey(r => r.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportingHistory>()
                .HasOne(r => r.OldManager)
                .WithMany(s => s.ReportingHistoriesAsOldManager)
                .HasForeignKey(r => r.OldManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportingHistory>()
                .HasOne(r => r.NewManager)
                .WithMany(s => s.ReportingHistoriesAsNewManager)
                .HasForeignKey(r => r.NewManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReportingHistory>()
                .HasOne(r => r.ChangedByUser)
                .WithMany()
                .HasForeignKey(r => r.ChangedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.AssignedBy)
                .WithMany(s => s.ProjectsAssignedByThisStaff)
                .HasForeignKey(pa => pa.AssignedByStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.Assignee)
                .WithMany(s => s.ProjectsThisStaffIsAssignedTo)
                .HasForeignKey(pa => pa.AssigneeStaffId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FteAllocation>()
                .HasOne(fa => fa.Staff) // FteAllocation has one Staff (assigned to)
                .WithMany(s => s.FteAllocations) // Staff has many FteAllocations
                .HasForeignKey(fa => fa.StaffId) // Foreign key in FteAllocation
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectAssignments)
                .HasForeignKey(pa => pa.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeAllocation>()
                .HasOne(ea => ea.Project)
                .WithMany()
                .HasForeignKey(ea => ea.ProjectId)
                
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);

        }

    }

}