using AutoMapper;
using CheckSkillsASP.Entity;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace CheckSkillsASP.Data
{
    public class Seed
    {

        public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            try
            {

                string jsonUsers = File.ReadAllText("Data/UsersSeed.json");
                var seedUsers = JsonSerializer.Deserialize<List<AppUser>>(jsonUsers);
                 

                var roles = new List<AppRole>
                {
                    new AppRole {Name = "Member"},
                    new AppRole {Name = "Admin"},
                    new AppRole {Name = "Moderator"}
                };

                foreach (var role in roles)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role.Name);
                    if (!roleExists)
                        await roleManager.CreateAsync(role);
                }

                foreach (var user in seedUsers)
                {
                    var existingUser = await userManager.FindByNameAsync(user.UserName);
                    if (existingUser == null)
                    {
                        user.UserName = user.UserName.ToLower();
                        var result = await userManager.CreateAsync(user, "Pass_1234");
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Member");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                Console.WriteLine($"Error creating user: {error.Description}");
                            }
                        }
                    }
                }

                Console.WriteLine("User seeding completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during user seeding: {ex.Message}");
                throw;
            }
        }

    }
}
