namespace EasyOrder.Infrastructure.Data.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public static readonly IList<IdentityRole> roles = new List<IdentityRole>();

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            SeedRoles();
            builder.HasData(roles);
        }

        private void SeedRoles()
        {
            roles.Add(new IdentityRole()
            {
                Name = "SupperAdmin",
                NormalizedName = "SupperAdmin".ToUpper(),
            });
        }
    }
}
