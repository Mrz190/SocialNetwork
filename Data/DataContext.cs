using CheckSkillsASP.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CheckSkillsASP.Data
{
    public class DataContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public DataContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var jsonUsers = File.ReadAllText("Data/UsersSeed.json");
            var seedUsers = JsonSerializer.Deserialize<List<AppUser>>(jsonUsers);

            foreach (var user in seedUsers)
            {
                modelBuilder.Entity<AppUser>().Property(u => u.NickName).HasMaxLength(15).IsRequired();
                modelBuilder.Entity<AppUser>().Property(u => u.Country).HasMaxLength(256).IsRequired();
                modelBuilder.Entity<AppUser>().Property(u => u.City).HasMaxLength(256).IsRequired();
                modelBuilder.Entity<AppUser>().Property(u => u.WasCreated).IsRequired();
                modelBuilder.Entity<AppUser>().HasData(user);
            }

        }
    }
}
