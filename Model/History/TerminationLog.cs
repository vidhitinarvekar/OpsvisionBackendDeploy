using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.History
{
    public class TerminationLog

    {

        [Key]

        public int TerminationId { get; set; }


        [Required]
        public int StaffId { get; set; }


        [Required]
        public DateTime TerminationDate { get; set; }

        [Required]

        public string Reason { get; set; }

        [Required]

        public int ApprovedByUserId { get; set; }



        [ForeignKey("StaffId")]

        public Staff Staff { get; set; }



        [ForeignKey("ApprovedByUserId")]

        public User ApprovedByUser { get; set; }

    }


}
