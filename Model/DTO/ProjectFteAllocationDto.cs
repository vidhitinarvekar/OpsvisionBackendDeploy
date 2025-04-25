using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ProjectFteAllocationDto
    {
        public int ProjectId { get; set; }
        public float AllocatedFte { get; set; }

        public string? PrimeCode { get; set; }
    }
}
