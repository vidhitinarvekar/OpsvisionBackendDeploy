using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.History
{
    public class ReportingHistory

    {

        [Key]

        public int ReportHistoryId { get; set; }

        [Required]

        public int StaffId { get; set; }



        public int? OldManagerId { get; set; }



        public int? NewManagerId { get; set; }

        [Required]

        public DateTime ChangeDate { get; set; }


        [Required]
        public int ChangedByUserId { get; set; }



        [ForeignKey("StaffId")]
        [InverseProperty("ReportingHistories")]

        public Staff Staff { get; set; }



        [ForeignKey("OldManagerId")]
        [InverseProperty("ReportingHistoriesAsOldManager")]

        public Staff OldManager { get; set; }



        [ForeignKey("NewManagerId")]
        [InverseProperty("ReportingHistoriesAsNewManager")]

        public Staff NewManager { get; set; }



        [ForeignKey("ChangedByUserId")]

        public User ChangedByUser { get; set; }

    }
}
