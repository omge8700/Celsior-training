using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Context
{
    public class AuthDBContext : IdentityDbContext

    {
        public AuthDBContext(DbContextOptions options) : base(options)
        {

            
        }


    }
}
