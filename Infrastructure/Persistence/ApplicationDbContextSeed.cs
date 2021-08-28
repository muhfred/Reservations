using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new ApplicationUser { UserName = "admin@localhost", Email = "admin@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Trips.Any())
            {
                context.Trips.Add(new Trip
                {
                    TripName = "sample name",
                    CityName = "sharm el sheikh",
                    Price = 100,
                    ImageUrl = "images/trips/A_resort_in_Sharm_El_Sheikh.jpg",
                    Content = "<p>sample content</p>"
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
