using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;

namespace Model.DTO
{
    public class ProjectFteEmployeeDto
    {
        public int ProjectId { get; set; }
        public string PrimeCode { get; set; }
        public string ProjectName { get; set; }
        public List <EmployeeDto> AssignedEmployees { get; set; }
        public float RemainingHours { get; set; }

    }
}
