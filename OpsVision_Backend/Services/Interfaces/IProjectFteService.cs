using Model.DTO;

namespace OpsVision_Backend.Services.Interfaces
{
    public interface IProjectFteService
    {
        Task<List<ProjectDetailsDto>> GetAllProjectsAsync(string email, string role);
        Task<float> AddOrUpdateProjectFteAsync(ProjectFteAllocationDto dto);
        Task<bool> DeleteProjectFteAsync(int projectId);
    }
}
