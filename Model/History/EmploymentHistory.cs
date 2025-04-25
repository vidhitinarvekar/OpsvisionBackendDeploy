using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.History
{
    public class EmploymentHistory

    {

        [Key]

        public int HistoryId { get; set; }


        [Required(ErrorMessage = "StaffId is required.")]
        public int StaffId { get; set; }


        [Required(ErrorMessage = "FieldChanged is required.")]
        public string FieldChanged { get; set; }



        public string? OldValue { get; set; }


        // These values can be null in some cases (e.g., new fields or blank clears)

        public string? NewValue { get; set; }


        [Required]
        public DateTime ChangeDate { get; set; }


        [Required(ErrorMessage = "ChangedByUserId is required.")]
        public int ChangedByUserId { get; set; }



        [ForeignKey("StaffId")]

        public Staff Staff { get; set; }



        [ForeignKey("ChangedByUserId")]

        public User ChangedByUser { get; set; }

    }

    

}
