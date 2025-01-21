namespace EasyOrder.Infrastructure.Data.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static EasyOrder.Infrastructure.Data.Configurations.Identity.IdentityUserConfiguration;

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
            roles.Clear();
            roles.Add(new IdentityRole()
            {
                Name = "SupperAdmin",
                NormalizedName = "SupperAdmin".ToUpper(),
                ConcurrencyStamp = users[0].Id
            });
        }
    }
}
