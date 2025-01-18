using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace EasyOrder.Infrastructure.Data
{
    using EasyOrder.Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }

        public DbSet<Site> Sites { get; set; } = null!;

        public DbSet<Table> Tables { get; set; } = null!;

        public DbSet<MenuCategory> MenuCategories { get; set; } = null!;

        public DbSet<MenuItem> MenuItems { get; set; } = null!;
    }
}
