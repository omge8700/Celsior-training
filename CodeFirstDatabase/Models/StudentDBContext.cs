using Microsoft.EntityFrameworkCore;

namespace CodeFirstDatabase.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {



        }

        public DbSet<Student> Students { get; set; }
    
        
    }
}
