using Microsoft.EntityFrameworkCore;
using MyPractice5.Model;

namespace MyPractice5.Data
{
    public class APIDbContext:DbContext
    {

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { 
        
        }

        public DbSet<Users> Users { get; set; }
    }
}
