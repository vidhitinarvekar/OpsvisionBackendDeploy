using Model.DTO;

namespace OpsVision_Backend.Services.Interfaces
{
    public interface IProjectFteEmployeeService
    {
        Task<ProjectFteEmployeeDto> GetAssignedEmployeesAsync(int projectId); // Fetch assigned employees for a project
        Task<string> AssignFteToEmployeeAsync(ProjectFteEmployeeAssignmentDto dto, int assignedByStaffId); // Assign hours to an employee
        Task<string> UpdateFteForEmployeeAsync(ProjectFteEmployeeAssignmentDto dto, int assignedByStaffId); // Update allocated hours for an employee
        Task<string> DeleteEmployeeAllocationAsync(int projectId, int staffId); // Delete employee allocation
        Task<IEnumerable<EmployeeDto>> SearchEmployeesAsync(string searchTerm);
    }
}
