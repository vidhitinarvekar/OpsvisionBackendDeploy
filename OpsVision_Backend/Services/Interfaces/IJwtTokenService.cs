using Model;

namespace OpsVision_Backend.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Staff staff, string role);
    }
    }
