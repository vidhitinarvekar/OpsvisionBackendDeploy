using Model.DTO;
using Model.Transaction;
using OpsVision_Backend.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using OpsVision_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Model;

namespace OpsVision_Backend.Services
{
    public class ProjectFteEmployeeService : IProjectFteEmployeeService
    {
        private readonly FteDbContext _context;
        private readonly ILogger<ProjectFteEmployeeService> _logger;

        public ProjectFteEmployeeService(FteDbContext context, ILogger<ProjectFteEmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get assigned employees for the given project (prime code)
        public async Task<ProjectFteEmployeeDto> GetAssignedEmployeesAsync(int projectId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
            if (project == null) throw new Exception("Project not found");

            var projectFteAssignments = await _context.FteAllocations
                .Where(f => f.ProjectId == projectId)
                .Include(f => f.Staff)
                .ToListAsync();

            var assignedEmployees = projectFteAssignments.Select(f => new EmployeeDto
            {
                StaffId = f.StaffId,
                AllocatedHours = f.AllocatedHours,
                FirstName = f.Staff.FirstName,
                LastName = f.Staff.LastName,
                Email = f.Staff.Email
            }).ToList();

            return new ProjectFteEmployeeDto
            {
                ProjectId = projectId,
                PrimeCode = project.PrimeCode,
                AssignedEmployees = assignedEmployees,
                RemainingHours = CalculateRemainingHours(projectId)
            };
        }

        // Assign FTE to an employee
        public async Task<string> AssignFteToEmployeeAsync(ProjectFteEmployeeAssignmentDto dto, int assignedByStaffId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            { 
                var project = await _context.Projects.FindAsync(dto.ProjectId);
                if (project == null) return "Project not found.";

            var projectFte = await _context.ProjectFteAllocations
                .FirstOrDefaultAsync(p => p.ProjectId == dto.ProjectId);

            if (projectFte == null)
                return "FteAllocation not found.";

            float workingHours = GetWorkingDaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 8;
            float fte = dto.AllocatedHours / workingHours;

            var allocated = new FteAllocation
            {
                ProjectId = dto.ProjectId,

                StaffId = dto.StaffId,
                AllocatedHours = dto.AllocatedHours,
                FteCalculated = fte,
                IsShiftWorker = false, // Update if needed
                ProjectFteId = projectFte.ProjectFteId,
                //RemainingHours = projectFte.AllocatedHours - _context.FteAllocations
                  //  .Where(f => f.ProjectId == dto.ProjectId)
                    //.Sum(f => f.AllocatedHours) - dto.AllocatedHours
            };

            _context.FteAllocations.Add(allocated);

            // Allocate FTE to the delegates
            if (dto.Delegatees != null && dto.Delegatees.Any())
            {
                foreach (var delegatee in dto.Delegatees)
                {
                    // Allocate FTE for the delegate
                    var delegateeFte = new FteAllocation
                    {
                        ProjectId = dto.ProjectId,
                        StaffId = delegatee.StaffId,
                        AllocatedHours = delegatee.AllocatedHours,
                        FteCalculated = delegatee.AllocatedHours / workingHours,
                        IsShiftWorker = false, // Update if needed
                        ProjectFteId = projectFte.ProjectFteId
                       // RemainingHours = projectFte.AllocatedHours - _context.FteAllocations
                           // .Where(f => f.ProjectId == dto.ProjectId)
                            //.Sum(f => f.AllocatedHours) - delegatee.AllocatedHours
                    };

                    _context.FteAllocations.Add(delegateeFte);
                }
            }
            await EnsureProjectAssignmentExistsAsync(dto.ProjectId, dto.StaffId, assignedByStaffId);
            await UpdateRemainingHoursForProjectAsync(dto.ProjectId);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

                return "FTE allocated successfully.";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }



        }

        // Update FTE for an employee
        public async Task<string> UpdateFteForEmployeeAsync(ProjectFteEmployeeAssignmentDto dto, int assignedByStaffId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var allocation = await _context.FteAllocations
                .FirstOrDefaultAsync(f => f.ProjectId == dto.ProjectId && f.StaffId == dto.StaffId);

            if (allocation == null)
                return "FTE allocation not found.";

            var projectFte = await _context.ProjectFteAllocations
                .FirstOrDefaultAsync(p => p.ProjectId == dto.ProjectId);

            if (projectFte == null)
                return "Project not found.";
            float workingHours = GetWorkingDaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 8;
            float fte = dto.AllocatedHours / workingHours;

            allocation.AllocatedHours = dto.AllocatedHours;
            allocation.FteCalculated = fte;

            // Update delegatees if there are any
            if (dto.Delegatees != null && dto.Delegatees.Any())
            {
                foreach (var delegatee in dto.Delegatees)
                {
                    var delegateeAllocation = await _context.FteAllocations
                        .FirstOrDefaultAsync(f => f.ProjectId == dto.ProjectId && f.StaffId == delegatee.StaffId);

                    if (delegateeAllocation != null)
                    {
                        delegateeAllocation.AllocatedHours = delegatee.AllocatedHours;
                        delegateeAllocation.FteCalculated = delegatee.AllocatedHours / workingHours;
                    }
                    else
                    {
                        // If no allocation found for the delegatee, create one
                        var delegateeFte = new FteAllocation
                        {
                            ProjectId = dto.ProjectId,
                            StaffId = delegatee.StaffId,
                            AllocatedHours = delegatee.AllocatedHours,
                            FteCalculated = delegatee.AllocatedHours / workingHours,
                            IsShiftWorker = false, // Update if needed
                            ProjectFteId = projectFte.ProjectFteId
                            //RemainingHours = projectFte.AllocatedHours - _context.FteAllocations
                              //  .Where(f => f.ProjectId == dto.ProjectId)
                                //.Sum(f => f.AllocatedHours) - delegatee.AllocatedHours
                        };

                        _context.FteAllocations.Add(delegateeFte);
                    }
                }
            }

            //float assignedSum = _context.FteAllocations
              //  .Where(f => f.ProjectId == dto.ProjectId && f.StaffId != dto.StaffId)
                //.Sum(f => f.AllocatedHours);

            //allocation.RemainingHours = projectFte.AllocatedHours - assignedSum - dto.AllocatedHours;

            //var project = await _context.Projects.FindAsync(dto.ProjectId);
            //if (project != null)
            //{
                await EnsureProjectAssignmentExistsAsync(dto.ProjectId, dto.StaffId, assignedByStaffId);
                await UpdateRemainingHoursForProjectAsync(dto.ProjectId);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return "FTE updated successfully.";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            
        }

        // Delete employee allocation for a project
        public async Task<string> DeleteEmployeeAllocationAsync(int projectId, int staffId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var allocation = await _context.FteAllocations
                .FirstOrDefaultAsync(f => f.ProjectId == projectId && f.StaffId == staffId);

                if (allocation == null)
                    return "Allocation not found.";

                _context.FteAllocations.Remove(allocation);
                await UpdateRemainingHoursForProjectAsync(projectId);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return "Employee allocation deleted successfully.";
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        // Search for employees based on name, email, or ID
        public async Task<IEnumerable<EmployeeDto>> SearchEmployeesAsync(string searchTerm)
        {
            return await _context.Staff
                .Where(s => s.FirstName.Contains(searchTerm) ||
                            s.LastName.Contains(searchTerm) ||
                            s.Email.Contains(searchTerm) ||
                            s.CUID.Contains(searchTerm) ||
                            s.StaffNumber.ToString().Contains(searchTerm) ||
                            s.StaffId.ToString() == searchTerm)
                .Select(s => new EmployeeDto
                {
                    StaffId = s.StaffId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email
                })
                .ToListAsync();
        }

        // Helper method to calculate remaining hours for the project
        private float CalculateRemainingHours(int projectId)
        {
            var totalAllocated = _context.ProjectFteAllocations
                .Where(p => p.ProjectId == projectId)
                .Select(p => p.AllocatedHours)
                .FirstOrDefault();

            var assignedHours = _context.FteAllocations
                .Where(f => f.ProjectId == projectId)
                .Sum(f => f.AllocatedHours);

            return totalAllocated - assignedHours;


        }

        private async Task UpdateRemainingHoursForProjectAsync(int projectId)
        {
            var projectFte = await _context.ProjectFteAllocations.FirstOrDefaultAsync(p => p.ProjectId == projectId);
            if (projectFte == null) return;

            var allocations = await _context.FteAllocations
                .Where(f => f.ProjectId == projectId)
                .ToListAsync();

            float remaining = projectFte.AllocatedHours - allocations.Sum(f => f.AllocatedHours);

            foreach (var allocation in allocations)
            {
                allocation.RemainingHours = remaining;
            }
        }

        // 🔧 Helper method to auto-assign employee to a project
        private async Task EnsureProjectAssignmentExistsAsync(int projectId, int assigneeStaffId, int assignedByStaffId, string role = "TeamMember")
        {


            var exists = await _context.ProjectAssignments.AnyAsync(pa =>
                pa.ProjectId == projectId &&
                pa.AssigneeStaffId == assigneeStaffId);

            if (!exists)
            {
                var assignment = new ProjectAssignment
                {
                    ProjectId = projectId,

                    AssigneeStaffId = assigneeStaffId,
                    AssignedByStaffId = assignedByStaffId,
                    AssignmentDate = DateTime.UtcNow,
                    RoleAssigned = role
                };

                _context.ProjectAssignments.Add(assignment);
            }
        
        }

        private int GetWorkingDaysInMonth(int year, int month)
        {
            int totalDays = DateTime.DaysInMonth(year, month);
            int workingDays = 0;

            for (int day = 1; day <= totalDays; day++)
            {
                var date = new DateTime(year, month, day);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    workingDays++;
            }

            return workingDays;
        }
    }
}
