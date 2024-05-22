using Microsoft.AspNetCore.Identity;

namespace PractisesJWT2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
