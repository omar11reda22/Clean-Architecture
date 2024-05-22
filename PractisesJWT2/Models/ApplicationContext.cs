using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PractisesJWT2.Models
{
    public class ApplicationContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
        {
            
        }
        public ApplicationContext(DbContextOptions options):base(options)
        {
            
        }

    }
}
