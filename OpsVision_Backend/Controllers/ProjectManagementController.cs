using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpsVision_Backend.Data;
using Model.DTO;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectManagementController.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementController : ControllerBase
    {
        private readonly FteDbContext _context;

        public ProjectManagementController(FteDbContext context)
        {
            _context = context;
        }

        [HttpGet("user-projects")]
        public async Task<IActionResult> GetUserProjects()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email)) return BadRequest(new { message = "User email is missing in the token." });

            var employee = await _context.Staff.FirstOrDefaultAsync(e => e.Email == email);
            if (employee == null) return NotFound(new { message = "User not found." });

            var allocations = await _context.FteAllocations
                .Where(f => f.StaffId == employee.StaffId)
                .ToListAsync();

            var projectIds = allocations.Select(f => f.ProjectId).Distinct().ToList();

            var projects = await _context.Projects
                .Where(p => projectIds.Contains(p.ProjectId))
                .ToDictionaryAsync(p => p.ProjectId, p => p.ProjectName);

            var projectAssignments = await _context.ProjectAssignments
                .Where(pa => projectIds.Contains(pa.ProjectId))
                .ToListAsync();

            var userProjects = allocations
                .Where(f => projects.ContainsKey(f.ProjectId))
                .Select(f =>
                {
                    var assignment = projectAssignments
                        .FirstOrDefault(pa => pa.ProjectId == f.ProjectId && pa.AssigneeStaffId == f.StaffId);

                    return new EmployeeAllocationDto
                    {
                        ProjectId = f.ProjectId,
                        ProjectName = projects[f.ProjectId],
                        FteAllocated = f.FteCalculated,
                        AllocatedHours = f.AllocatedHours,
                        AssignedBy = assignment?.AssignedByStaffId.ToString() ?? "Not Assigned",
                        CommittedHours = f.CommittedHours ?? 0,
                        RemainingHrs = (decimal)f.AllocatedHours - (f.CommittedHours ?? 0)
                    };
                })
                .ToList();

            return Ok(userProjects);
        }

        [HttpPut("update-committed-hours")]
        public async Task<IActionResult> UpdateCommittedHours([FromBody] CommittedHoursRequest request)
        {
            if (request?.CommittedHoursDto == null)
                return BadRequest(new { message = "Request body cannot be null." });

            var dto = request.CommittedHoursDto;

            if (dto.ProjectId <= 0 || dto.StaffId <= 0 || dto.CommittedHours < 0)
                return BadRequest(new { message = "Invalid data provided." });

            var fteAllocation = await _context.FteAllocations
                .FirstOrDefaultAsync(f => f.ProjectId == dto.ProjectId && f.StaffId == dto.StaffId);

            if (fteAllocation == null)
                return NotFound(new { message = "FTE allocation not found for the provided project and staff." });

            fteAllocation.CommittedHours = dto.CommittedHours;
            fteAllocation.CommittedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Committed hours updated successfully.",
                updatedFteAllocation = new
                {
                    ProjectId = fteAllocation.ProjectId,
                    fteAllocation.StaffId,
                    fteAllocation.CommittedHours,
                    RemainingHrs = (decimal)fteAllocation.AllocatedHours - (fteAllocation.CommittedHours ?? 0)
                }
            });
        }

        [HttpPost("store-committed-hours")]
        public async Task<IActionResult> StoreCommittedHours([FromBody] CommittedHoursRequest request)
        {
            if (request?.CommittedHoursDto == null)
                return BadRequest(new { message = "Request body cannot be null." });

            var dto = request.CommittedHoursDto;

            if (dto.ProjectId <= 0 || dto.StaffId <= 0 || dto.CommittedHours < 0)
                return BadRequest(new { message = "Invalid data provided." });

            var fteAllocation = await _context.FteAllocations
                .FirstOrDefaultAsync(f => f.ProjectId == dto.ProjectId && f.StaffId == dto.StaffId);

            if (fteAllocation == null)
                return NotFound(new { message = "FTE allocation not found for the provided project and staff." });

            fteAllocation.CommittedHours = dto.CommittedHours;
            fteAllocation.CommittedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Committed hours successfully stored.",
                updatedFteAllocation = new
                {
                    ProjectId = fteAllocation.ProjectId,
                    fteAllocation.StaffId,
                    fteAllocation.CommittedHours,
                    RemainingHrs = (decimal)fteAllocation.AllocatedHours - (fteAllocation.CommittedHours ?? 0)
                }
            });
        }
    }
}