using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;

namespace Model.DTO
{
    public class EmployeeDto
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }  // Add this
        public string LastName { get; set; }
        public string Email { get; set; }
        public float AllocatedHours { get; set; }
    }
}
