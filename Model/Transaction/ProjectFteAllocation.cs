using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Transaction
{
    public class ProjectFteAllocation
    {
        [Key]

        public int ProjectFteId { get; set; }



        [Required]

        public int ProjectId { get; set; } 

        
        [Required]
        public float AllocatedFte { get; set; }

        [Required]

        public float AllocatedHours { get; set; }

        [Required]

        public int Month { get; set; }

        [Required]

        public int Year { get; set; }



        [ForeignKey("ProjectId")]

        public Projects Project { get; set; }



        public ICollection<FteAllocation> FteAllocations { get; set; } = new List<FteAllocation>();
    }
}
