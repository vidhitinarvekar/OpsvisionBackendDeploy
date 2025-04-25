using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transaction
{
    public class FteAllocation

    {

        [Key]

        public int FteAllocationId { get; set; }


        [Required]
        public int StaffId { get; set; }
        [Required]

        public int ProjectId { get; set; }

        [Required]

        public int ProjectFteId { get; set; }

        [Required]

        public float AllocatedHours { get; set; }

        [Required]

        public float FteCalculated { get; set; }

        [Required]

        public bool IsShiftWorker { get; set; }



        public decimal? CommittedHours { get; set; }



        public DateTime? CommittedDate { get; set; }



        public string? Remarks { get; set; }
        public float? RemainingHours { get; set; }



        [ForeignKey("StaffId")]

        public Staff Staff { get; set; }



        [ForeignKey("ProjectFteId")]

        public ProjectFteAllocation ProjectFteAllocation { get; set; }

        [ForeignKey("ProjectId")]

        public Projects Project { get; set; }

        public int? DelegatedBy { get; set; }  // New nullable column

        [ForeignKey("DelegatedBy")]
        public Staff Delegator { get; set; }  // Navigation property to Staff for the delegator


        public ICollection<FteCommittedLog> CommittedLogs { get; set; } = new List<FteCommittedLog>();



    }
}
