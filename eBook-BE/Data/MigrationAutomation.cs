using eBook_BE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Data
{
    public static class MigrationAutomation
    {
        public static async Task ApplyMigration(WebApplication app) // apply new pending migration
        {
            using (var scope = app.Services.CreateScope()) // Get the services 
            {

                var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0) // apply all the pending migration
                {
                    _db.Database.Migrate();
                }
                //await SeedingDb.InitUser(context);
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserApplication>>();

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await DbContextSeed.SeedDatabaseAsync(userManager, roleManager);
            }
        }
    }
}
