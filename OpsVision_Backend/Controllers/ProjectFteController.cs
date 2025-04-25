using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model;
using OpsVision_Backend.Services.Interfaces;
using System.Security.Claims;
namespace OpsVision_Backend.Controllers
{

    [Authorize]
    [ApiController]
        [Route("api/[controller]")]
        public class ProjectFteController : ControllerBase
        {
            private readonly IProjectFteService _projectFteService;

            public ProjectFteController(IProjectFteService projectFteService)
            {
                _projectFteService = projectFteService;
            }

        // Get all projects based on role
        [HttpGet("all")]
        [Authorize(Roles = "ProjectOwner,VerticalLead,ProjecManager")]
        public async Task<IActionResult> GetProjects()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            // Optionally: log or validate email/role here
            var result = await _projectFteService.GetAllProjectsAsync(email, role);
            return Ok(result);
        }

        [HttpPost("allocate")]
            [Authorize(Roles = "ProjectOwner,VerticalLead,ProjectManager")]
            public async Task<IActionResult> AllocateFte([FromBody] ProjectFteAllocationDto dto)
            {
                var hours = await _projectFteService.AddOrUpdateProjectFteAsync(dto);
                return Ok(new { AllocatedHours = hours });
            }

            [HttpPut("update")]
            [Authorize(Roles = "ProjectOwner,VerticalLead,ProjectManager")]
            public async Task<IActionResult> UpdateFte([FromBody] ProjectFteAllocationDto dto)
            {
                var hours = await _projectFteService.AddOrUpdateProjectFteAsync(dto);
                return Ok(new { AllocatedHours = hours });
            }

            [HttpDelete("delete/{projectId}")]
            [Authorize(Roles = "ProjectOwner,VerticalLead,ProjectManager")]
            public async Task<IActionResult> Delete(int projectId)
            {
                var success = await _projectFteService.DeleteProjectFteAsync(projectId);
                return success ? Ok("Deleted") : NotFound("Not found");
            }
        }
}
