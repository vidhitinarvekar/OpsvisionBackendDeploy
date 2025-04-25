using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ProjectDetailsDto
    {
        public int ProjectId { get; set; }
        public string PrimeCode { get; set; }
        public string? ProjectName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float AllocatedFte { get; set; }         
        public float AllocatedHours { get; set; }

        public string? Status { get; set; }
        public string? OwnerName { get; set; }
    }
}
