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
        public DbSet<Brand> Brand { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //User with brands
            modelBuilder.Entity<UserBrand>()
            .HasKey(x => new {
                x.UserId,x.BrandId
            });

            modelBuilder.Entity<UserBrand>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserBrands)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserBrand>()
                .HasOne(x => x.Brand)
                .WithMany(x=>x.UserBrands)
                .HasForeignKey(x=>x.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
