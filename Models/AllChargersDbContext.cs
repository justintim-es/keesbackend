using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace backend.Models
{
    public class AllChargersDbContext : IdentityDbContext {
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public AllChargersDbContext( DbContextOptions<AllChargersDbContext> options): base(options) {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { 
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper() 
                }
            );
        }
    }
}