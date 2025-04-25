using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transaction
{
    public class ProjectAssignment

    {

        [Key]

        public int AssignmentId { get; set; }


        [Required]
        public int ProjectId { get; set; }


        [Required]
        public int AssignedByStaffId { get; set; }

        [Required]

        public int AssigneeStaffId { get; set; }


        [Required]
        public DateTime AssignmentDate { get; set; }

        [Required]

        public string RoleAssigned { get; set; }



        [ForeignKey("ProjectId")]

        public Projects Project { get; set; }



        [ForeignKey("AssignedByStaffId")]

        public Staff AssignedBy { get; set; }



        [ForeignKey("AssigneeStaffId")]

        public Staff Assignee { get; set; }

        public int? DelegatedBy { get; set; }  // New nullable column

        [ForeignKey("DelegatedBy")]
        public Staff DelegatedByStaff { get; set; }  // Navigation property to Staff for the delegator

    }
}
