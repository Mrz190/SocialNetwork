using CheckSkillsASP.Entity;
using CheckSkillsASP.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CheckSkillsASP.Data
{
    public class Seed
    {

        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var jsonUsers = File.ReadAllText("Data/UsersSeed.json");
            var seedUsers = JsonSerializer.Deserialize<List<AppUser>>(jsonUsers);

            var roles = new List<AppRole>
            {
                new AppRole {Name = "Member"},
                new AppRole {Name = "Admin"},
                new AppRole {Name = "Moderator"}

            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in seedUsers)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pass1234");
                await userManager.CreateAsync(user, "Member");
            }
        }
    }
}
