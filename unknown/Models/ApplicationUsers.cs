using Microsoft.AspNetCore.Identity;

namespace unknown.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string Address { get; set; } = string.Empty;
    }
}
