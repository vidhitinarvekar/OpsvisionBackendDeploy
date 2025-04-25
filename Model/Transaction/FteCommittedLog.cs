using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transaction
{
    public class FteCommittedLog

    {

        [Key]

        public int LogId { get; set; }


        [Required]
        public int FteAllocationId { get; set; }


        [Required]
        public decimal HoursCommitted { get; set; }


        [Required]
        public DateTime DateCommitted { get; set; }
        [Required]
        public int StaffId { get; set; }
        [Required]
        public float? EmpRemainingHours { get; set; }

       

        public string? Remarks { get; set; }



        [ForeignKey("FteAllocationId")]

        public FteAllocation FteAllocation { get; set; }
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }

    }
}
