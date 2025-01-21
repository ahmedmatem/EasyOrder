namespace EasyOrder.Infrastructure.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using EasyOrder.Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class IdentityUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public static readonly IList<ApplicationUser> users = new List<ApplicationUser>();

        private PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            SeedUsers();
            builder.HasData(users);
        }

        private void SeedUsers() 
        {
            users.Clear();
            users.Add(NewUser("ahmed@gmal.com", "Ахмед Матем Ахмед"));
        }

        private ApplicationUser NewUser(string email, string fullName)
        {
            var userName = email[..email.IndexOf('@')];
            var password = userName + "Pass";

            var newUser = new ApplicationUser()
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                FullName = fullName,
                EmailConfirmed = true,
            };

            passwordHasher.HashPassword(newUser, password);

            return newUser;
        }
    }
}
