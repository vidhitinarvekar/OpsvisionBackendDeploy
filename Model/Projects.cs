using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

using System.Threading.Tasks;
using Model.Transaction;

namespace Model
{
    public class Projects
    {
        [Key]

        public int ProjectId { get; set; }

        [Required]
       
        public string PrimeCode { get; set; }



        public string? ProjectName { get; set; }


        [Required]
        public DateTime ExpiryDate { get; set; }


        // 🔹 Project Manager (as name only)
        public string? ProjectManager { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }                 // 🔹 New

        
        public string? Status { get; set; }                      // 🔹 New (e.g., Active, Completed, On Hold)

        public string? ClassCategory { get; set; }               // 🔹 New

        public string? ClassCode { get; set; }                   // 🔹 New

        public string? CustomerName { get; set; }



        [ForeignKey("OwnerId")]

        public Staff Owner { get; set; }

        public ICollection<ProjectFteAllocation>? FteAllocations { get; set; }
        public ICollection<ProjectAssignment>? ProjectAssignments { get; set; }
    }
}
