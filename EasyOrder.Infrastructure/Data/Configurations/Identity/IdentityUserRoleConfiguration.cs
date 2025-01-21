namespace EasyOrder.Infrastructure.Data.Configurations.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using IdentitySeedOption = EasyOrder.Infrastructure.Data.Configurations.Identity;

    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(SeedUsersInRoles());
        }

        private ICollection<IdentityUserRole<string>> SeedUsersInRoles()
        {
            return new HashSet<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = IdentitySeedOption.IdentityUserConfiguration.users[0].Id,
                    RoleId = IdentitySeedOption.IdentityRoleConfiguration.roles[0].Id
                },
            };
        }
    }
}
