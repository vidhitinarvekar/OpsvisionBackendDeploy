using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ProjectFteEmployeeAssignmentDto
    {
        public int ProjectId { get; set; }
        public string? PrimeCode { get; set; }     
        public int StaffId { get; set; }          
        public float AllocatedHours { get; set; }
        public List<DelegateeDto> Delegatees { get; set; }

    }
}
