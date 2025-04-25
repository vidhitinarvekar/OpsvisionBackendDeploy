using Model.DTO;
using Model.Transaction;
using OpsVision_Backend.Services.Interfaces;
using System;
using OpsVision_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Model;


namespace OpsVision_Backend.Services
{
    public class ProjectFteService : IProjectFteService
    {
        private readonly FteDbContext _context;

        public ProjectFteService(FteDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProjectDetailsDto>> GetAllProjectsAsync(string email, string role)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            IQueryable<Projects> query = _context.Projects.Include(p => p.Owner);

            if (role == "ProjectManager")
            {
                // PM can only see projects where they are the owner
                var pm = await _context.Staff.FirstOrDefaultAsync(s => s.Email == email);
                if (pm == null)
                    throw new UnauthorizedAccessException("Staff not found for email.");

                query = query.Where(p => p.OwnerId == pm.StaffId);
            }


            var result = await query
                
                .Select(p => new ProjectDetailsDto
                {
                    ProjectId = p.ProjectId,
                    PrimeCode = p.PrimeCode,
                    ProjectName = p.ProjectName,
                    Status = p.Status,
                    ExpiryDate = p.ExpiryDate,
                    OwnerName = p.Owner.FirstName + " " + p.Owner.LastName,
                    AllocatedFte = _context.ProjectFteAllocations
                        .Where(fte => fte.ProjectId == p.ProjectId && fte.Month == currentMonth && fte.Year == currentYear)
                        .Select(fte => fte.AllocatedFte)
                        .FirstOrDefault(),

                    AllocatedHours = _context.ProjectFteAllocations
                        .Where(fte => fte.ProjectId == p.ProjectId && fte.Month == currentMonth && fte.Year == currentYear)
                        .Select(fte => fte.AllocatedHours)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return result;
        }


        public async Task<float> AddOrUpdateProjectFteAsync(ProjectFteAllocationDto dto)
        {
            if (dto.AllocatedFte <= 0)
                throw new ArgumentException("FTE must be greater than 0.");
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var existing = await _context.ProjectFteAllocations
                .FirstOrDefaultAsync(p => p.ProjectId == dto.ProjectId && p.Month == DateTime.Now.Month && p.Year == DateTime.Now.Year);

            int workingDays = GetWorkingDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            float allocatedHours = dto.AllocatedFte * workingDays * 8;

            if (existing != null)
            {
                existing.AllocatedFte = dto.AllocatedFte;
                existing.AllocatedHours = allocatedHours;
            }
            else
            {
                var project = await _context.Projects.FindAsync(dto.ProjectId);
                if (project == null) throw new Exception("Project not found");

                _context.ProjectFteAllocations.Add(new ProjectFteAllocation
                {
                    ProjectId = dto.ProjectId,
                    
                    AllocatedFte = dto.AllocatedFte,
                    AllocatedHours = allocatedHours,
                    Month = DateTime.Now.Month,
                    Year = DateTime.Now.Year
                });
            }

            await _context.SaveChangesAsync();
            return allocatedHours;
        }

        public async Task<bool> DeleteProjectFteAsync(int projectId)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var record = await _context.ProjectFteAllocations
                .FirstOrDefaultAsync(p => p.ProjectId == projectId && p.Month == DateTime.Now.Month && p.Year == DateTime.Now.Year);

            if (record != null)
            {
                _context.ProjectFteAllocations.Remove(record);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        private int GetWorkingDaysInMonth(int year, int month)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);
            int workingDays = 0;

            for (var day = 1; day <= daysInMonth; day++)
            {
                var date = new DateTime(year, month, day);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    workingDays++;
            }

            return workingDays;
        }
    }

}
