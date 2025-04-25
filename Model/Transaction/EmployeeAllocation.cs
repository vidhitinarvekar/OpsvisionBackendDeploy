using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class EmployeeAllocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment ID
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; } // 
        [Required]

        public int StaffId { get; set; } // References

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Employee Email

        [NotMapped]
        public string Name => $"{Staff?.FirstName} {Staff?.LastName}"; // Calculated property for Employee Name

        [Required]
        public double TotalAllocatedHours { get; set; } // Total allocated hours for employee

        [Required]
        public double AllocatedHours { get; set; } // Hours allocated for a specific task

        [Required]
        public string AssignedBy { get; set; } // Who assigned the allocation
        public decimal? CommitedHours { get; set; }

        // Foreign key references (optional, but useful for relationships)
        [ForeignKey("ProjectId")]
        public Projects Project { get; set; }

        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }
    }
}
