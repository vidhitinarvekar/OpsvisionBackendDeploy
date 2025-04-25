using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.History
{
    public class AuditTrail

    {

        [Key]

        public int AuditId { get; set; }


        [Required]
        public string TableName { get; set; }

        [Required]

        public int RecordId { get; set; }


        [Required]
        public string Action { get; set; } // Insert, Update, Delete

        [Required]

        public int ModifiedByUserId { get; set; }

        [Required]

        public DateTime ModifiedDate { get; set; }


        [Required]
        public string ChangeSummary { get; set; }



        [ForeignKey("ModifiedByUserId")]

        public User ModifiedByUser { get; set; }

    }
}
