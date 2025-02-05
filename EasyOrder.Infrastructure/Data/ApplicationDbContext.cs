﻿namespace EasyOrder.Infrastructure.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using EasyOrder.Infrastructure.Data.Models;
    using EasyOrder.Infrastructure.Data.Configurations.Identity;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // data seeds
            builder.ApplyConfiguration(new IdentityUserConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Site> Sites { get; set; } = null!;

        public DbSet<Table> Tables { get; set; } = null!;

        public DbSet<MenuCategory> MenuCategories { get; set; } = null!;

        public DbSet<MenuItem> MenuItems { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderItem> OrdersItems { get; set; } = null!;
    }
}
