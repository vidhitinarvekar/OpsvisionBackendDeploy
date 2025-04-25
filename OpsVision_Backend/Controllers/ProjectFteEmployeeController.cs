using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using OpsVision_Backend.Services.Interfaces;

namespace OpsVision_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectFteEmployeeController : ControllerBase
    {
        private readonly IProjectFteEmployeeService _projectFteEmployeeService;

        public ProjectFteEmployeeController(IProjectFteEmployeeService projectFteEmployeeService)
        {
            _projectFteEmployeeService = projectFteEmployeeService;
        }

        // Get assigned employees for a given project
        [HttpGet("{projectId}")]
        [Authorize(Roles = "ProjectOwner,VerticalLead")]
        public async Task<IActionResult> GetAssignedEmployees(int projectId)
        {
            var result = await _projectFteEmployeeService.GetAssignedEmployeesAsync(projectId);
            return Ok(result);
        }

        // Search for employees by name, email, or staff ID
        [HttpGet("search")]
        [Authorize(Roles = "ProjectOwner,VerticalLead")]
        public async Task<IActionResult> SearchEmployees([FromQuery] string searchTerm = "")
        {
            var employees = await _projectFteEmployeeService.SearchEmployeesAsync(searchTerm);
            return Ok(employees);
        }

        // Allocate FTE to an employee
        [HttpPost("allocate")]
        [Authorize(Roles = "ProjectOwner,VerticalLead")]
        public async Task<IActionResult> AllocateFte([FromBody] ProjectFteEmployeeAssignmentDto dto)

        {
            var staffIdClaim = User.FindFirstValue("staffId");

            if (string.IsNullOrEmpty(staffIdClaim))
            {
                return Unauthorized("AssignedByStaffId not found in token claims.");
            }

            var assignedByStaffId = int.Parse(staffIdClaim);
            var response = await _projectFteEmployeeService.AssignFteToEmployeeAsync(dto, assignedByStaffId);
            return Ok(new { Message = response });
        }

        // Update allocated FTE for an employee
        [HttpPut("update")]
        [Authorize(Roles = "ProjectOwner,VerticalLead")]
        public async Task<IActionResult> UpdateFte([FromBody] ProjectFteEmployeeAssignmentDto dto)
        {
            var staffIdClaim = User.FindFirstValue("staffId");

            if (string.IsNullOrEmpty(staffIdClaim))
            {
                return Unauthorized("AssignedByStaffId not found in token claims.");
            }

            var assignedByStaffId = int.Parse(staffIdClaim); 
            var response = await _projectFteEmployeeService.UpdateFteForEmployeeAsync(dto, assignedByStaffId);
            return Ok(new { Message = response });
        }

        // Delete employee allocation for a project
        [HttpDelete("delete/{projectId}/{staffId}")]
        [Authorize(Roles = "ProjectOwner,VerticalLead")]
        public async Task<IActionResult> DeleteFteAllocation(int projectId, int staffId)
        {
            var response = await _projectFteEmployeeService.DeleteEmployeeAllocationAsync(projectId, staffId);
            return Ok(new { Message = response });
        }
    }
    }
