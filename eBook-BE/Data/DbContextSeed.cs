using eBook_BE.Enum;
using eBook_BE.Models;
using Microsoft.AspNetCore.Identity;

namespace eBook_BE.Data
{
    public class DbContextSeed
    {
        public static async Task SeedDatabaseAsync(UserManager<UserApplication> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var hasher = new PasswordHasher<UserApplication>();

            if (!roleManager.Roles.Any())
            {
                ApplicationRole adminRole = new ApplicationRole
                {
                    Name = Roles.Admin
                };
                ApplicationRole userRole = new ApplicationRole
                {
                    Name = Roles.User
                };

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);
            }
            if (!userManager.Users.Any())
            {
                var adminUser = new UserApplication
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin",
                    FullName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                };


                var user = new UserApplication
                {
                    Id = Guid.NewGuid(),
                    UserName = "user",
                    FullName = "user",
                    Email = "user@gmail.com",
                    EmailConfirmed = true,
                };


                await userManager.CreateAsync(adminUser, "Password123!"); 
                await userManager.AddToRoleAsync(adminUser, Roles.Admin);

                await userManager.CreateAsync(user, "Password123!");
                await userManager.AddToRoleAsync(user, Roles.User);
            }

        }
    }
}

