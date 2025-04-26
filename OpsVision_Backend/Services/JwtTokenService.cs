using Microsoft.IdentityModel.Tokens;
using Model;
using OpsVision_Backend.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OpsVision_Backend.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Staff staff, string role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryMinutes = Convert.ToInt32(jwtSettings["TokenExpiryInMinutes"]);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Null-safe values
            var staffId = staff?.StaffId.ToString() ?? "unknown";
            var email = string.IsNullOrWhiteSpace(staff?.Email) ? "noemail@fallback.com" : staff.Email;
            var firstName = string.IsNullOrWhiteSpace(staff?.FirstName) ? "Unknown" : staff.FirstName;
            var lastName = string.IsNullOrWhiteSpace(staff?.LastName) ? "User" : staff.LastName;
            var fullName = $"{firstName} {lastName}";
            var safeRole = string.IsNullOrWhiteSpace(role) ? "User" : role;

            // Claims that are guaranteed non-null
            var claims = new[]
            {
                new Claim("staffId", staffId),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, fullName),
                new Claim(ClaimTypes.Role, safeRole)
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
