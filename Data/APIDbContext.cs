using Microsoft.EntityFrameworkCore;
using MyPractice5.Model;
using static System.Net.Mime.MediaTypeNames;

namespace MyPractice5.Data
{
    public class APIDbContext:DbContext
    {

        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { 
        
        }

//Install-Package Microsoft.EntityFrameworkCore.SqlServer
//Install-Package Microsoft.EntityFrameworkCore.Tools
//Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
//Install-Package BCrypt.Net-Next

        public DbSet<Users> Users { get; set; }
    }
}
