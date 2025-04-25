using Microsoft.AspNetCore.Mvc;
using Model;
using OpsVision_Backend.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using OpsVision_Backend.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using OpsVision_Backend.Services.Auth;
using System.Security.Cryptography;
using System.Text;

namespace OpsVision_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly FteDbContext _context;
        private readonly IJwtTokenService _jwtService;

        public AuthController(FteDbContext context, IJwtTokenService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // Local DB Login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            // Try LDAP first
            if (LdapHelper.ValidateUser(request.Username, request.Password))
            {
                var adUser = LdapHelper.GetUserDetails(request.Username);

                var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Email == adUser.Email);
                if (staff == null)
                {
                    staff = new Staff
                    {
                        FirstName = adUser.FullName?.Split(' ')[0],
                        LastName = adUser.FullName?.Split(' ').Length > 1 ? adUser.FullName?.Split(' ')[1] : "",
                        Email = adUser.Email,
                        CUID = request.Username,
                        IsLdapUser = true
                    };

                    _context.Staff.Add(staff);
                    await _context.SaveChangesAsync();
                }

                var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == adUser.Email);
                var role = user?.Role?.RoleName ?? "Employee";

                var token = _jwtService.GenerateToken(staff, role);

                return Ok(new LoginResponse
                {
                    StaffId = staff.StaffId,
                    Name = adUser.FullName,
                    Email = adUser.Email,
                    Role = role,
                    Token = token,
                    CUID = request.Username
                });
            }

            // Fallback to local DB if LDAP fails
            var userDb = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == request.Username);
            if (userDb == null || string.IsNullOrEmpty(userDb.PasswordHash))
                return Unauthorized("Invalid credentials");

            if (!VerifyPassword(request.Password, userDb.PasswordHash))
                return Unauthorized("Invalid credentials");

            var staffDb = await _context.Staff.FirstOrDefaultAsync(s => s.Email == userDb.Email);
            if (staffDb == null)
                return Unauthorized("Staff not found");

            var dbRole = userDb.Role?.RoleName ?? "Employee";
            var dbToken = _jwtService.GenerateToken(staffDb, dbRole);

            return Ok(new LoginResponse
            {
                StaffId = staffDb.StaffId,
                Name = $"{staffDb.FirstName} {staffDb.LastName}".Trim(),
                Email = userDb.Email,
                Role = dbRole,
                Token = dbToken,
                CUID = staffDb.CUID
            });
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using var sha = SHA256.Create();
            var inputHash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(inputPassword)));
            return inputHash == storedHash;
        }

        // Azure AD Login (still available if needed)
        [HttpPost("azure-login")]
        [Authorize]
        public async Task<IActionResult> AzureLogin()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                return Unauthorized("Email not found in token");

            var staff = await _context.Staff.FirstOrDefaultAsync(s => s.Email == email);
            if (staff == null)
                return Unauthorized("User not found in local database");

            var role = User.FindFirst(ClaimTypes.Role)?.Value ?? "Employee";

            var response = new LoginResponse
            {
                StaffId = staff.StaffId,
                Name = $"{staff.FirstName ?? ""} {staff.LastName ?? ""}".Trim(),
                Email = staff.Email ?? "",
                Role = role,
                Token = null,
                CUID = staff.CUID ?? ""
            };

            return Ok(response);
        }
    }
}

