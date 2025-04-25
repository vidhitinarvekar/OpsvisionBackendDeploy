using System;
using Model.Transaction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class CompletedHoursLog
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FteAllocationId is required.")]
        public int FteAllocationId { get; set; }  // Foreign key to FteAllocations
        [Required]
        public decimal CompletedHours { get; set; }
        [Required]
        public DateTime DateLogged { get; set; }
        public string? TaskNote { get; set; }

        // 🔗 Foreign Key to FteAllocation
        [ForeignKey("FteAllocationId")]
        public FteAllocation FteAllocation { get; set; }
    }
}

