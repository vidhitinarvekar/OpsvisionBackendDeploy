using System.DirectoryServices;
//using System.Reflection.PortableExecutable;

namespace OpsVision_Backend.Services.Auth
{
    public static class LdapHelper
    {
        private const string LdapPath = "LDAP://prd.integrator-orange.com";
        //private static readonly bool UseMock = true; // Set to false for production

        public static bool ValidateUser(string username, string password)
        {
           
            try
            {
                Console.WriteLine($"Attempting bind for: {username}");
                using var entry = new DirectoryEntry("LDAP://prd.integrator-orange.com", username, password);
                var native = entry.NativeObject; // Will throw if invalid
                Console.WriteLine("LDAP bind successfull");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LDAP bind failed: {ex.Message}");
                return false;
            }
        }

        public static LdapUser GetUserDetails(string username)
        {
            var userId = username.Contains("@") ? username.Split('@')[0] : username;

            var searcher = new DirectorySearcher(new DirectoryEntry(LdapPath))
            {
                Filter = $"(sAMAccountName={userId})"
            };

            searcher.PropertiesToLoad.AddRange(new[] { "mail", "displayName", "department", "title", "memberof" });

            var result = searcher.FindOne();
            if (result == null) throw new Exception("LDAP user not found");

            var entry = result.GetDirectoryEntry();

            return new LdapUser
            {
                FullName = entry.Properties["displayName"]?.Value?.ToString(),
                Email = entry.Properties["mail"]?.Value?.ToString(),
                Department = entry.Properties["department"]?.Value?.ToString(),
                Role = entry.Properties["memberof"]?[0]?.ToString() ?? "Employee"
            };
        }
    }

    public class LdapUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
    }
}
