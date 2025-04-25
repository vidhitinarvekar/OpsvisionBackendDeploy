using System;

namespace Model.DTO
{
    public class EmployeeAllocationDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public float FteAllocated { get; set; }
        public float AllocatedHours { get; set; }
        public string AssignedBy { get; set; }
        public decimal CommittedHours { get; set; }
        public decimal RemainingHrs { get; set; }
        
    }
}
