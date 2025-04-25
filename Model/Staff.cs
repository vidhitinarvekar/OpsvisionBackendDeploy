using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.History;
using Model.Transaction;


namespace Model
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StaffId  { get; set; }

        public int? StaffNumber { get; set; }
        [MaxLength(15)]
        public string? CUID { get; set; }



        [Required]
        [MaxLength(35)]

        public string FirstName { get; set; }
        [MaxLength(35)]
        public string? LastName { get; set; }


        [MaxLength(35)]
        public string? Email { get; set; }



        public int? JobTitleId { get; set; }

        public int? DepartmentId { get; set; }

        public int? LocationId { get; set; }

        public int? ShiftId { get; set; }

        public int? StatusId { get; set; }
        [Required]
        public bool IsShiftWorker   { get; set; } = false;


        public int? EmploymentTypeId { get; set; }

        public int? StaffClassId { get; set; }

        public int? VendorId { get; set; }

        public int? MgtCodeId { get; set; }

        public int? ReportsToStaffId { get; set; }

        public int? RelationshipId { get; set; }



        [ForeignKey("JobTitleId")]

        public JobTitles? JobTitle { get; set; }



        [ForeignKey("DepartmentId")]

        public Departments? Department { get; set; }



        [ForeignKey("LocationId")]

        public Locations? Location { get; set; }



        [ForeignKey("ShiftId")]

        public Shifts? Shift { get; set; }



        [ForeignKey("StatusId")]

        public StaffStatus? Status { get; set; }



        [ForeignKey("EmploymentTypeId")]

        public EmploymentType? EmploymentType { get; set; }



        [ForeignKey("StaffClassId")]

        public StaffClasses? StaffClass { get; set; }



        [ForeignKey("VendorId")]

        public Vendors? Vendor { get; set; }



        [ForeignKey("MgtCodeId")]

        public ManagementCodes? ManagementCode { get; set; }

        // One employee reports to one manager
        [ForeignKey("ReportsToStaffId")]
        [InverseProperty("DirectReports")]
        public Staff? ReportsTo { get; set; }
        [InverseProperty("OldManager")]
        public ICollection<ReportingHistory> ReportingHistoriesAsOldManager { get; set; }

        [InverseProperty("NewManager")]
        public ICollection<ReportingHistory> ReportingHistoriesAsNewManager { get; set; }



        [ForeignKey("RelationshipId")]

        public OrgRelationships? Relationship { get; set; }

        public bool IsLdapUser { get; set; } = false;

        // Navigation Collections (Plural for one-to-many)
        public ICollection<ProjectFteAllocation>? ProjectFteAllocations { get; set; }
        public ICollection<FteAllocation>? FteAllocations { get; set; }
        public ICollection<ProjectAssignment>? ProjectsAssignedByThisStaff { get; set; }
        public ICollection<ProjectAssignment>? ProjectsThisStaffIsAssignedTo { get; set; }
        public ICollection<AuditTrail>? ModifiedAuditTrails { get; set; }
        public ICollection<TerminationLog>? TerminationLogs { get; set; }
        public ICollection<ReportingHistory>? ReportingHistories { get; set; }
        // One manager has many direct reports
        [InverseProperty("ReportsTo")]
        public ICollection<Staff>? DirectReports { get; set; }


    }
}
