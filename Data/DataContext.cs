﻿using CheckSkillsASP.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CheckSkillsASP.Data
{
    public class DataContext : IdentityDbContext<AppUser,
                                                 AppRole,
                                                 int,
                                                 IdentityUserClaim<int>,
                                                 AppUserRole,
                                                 IdentityUserLogin<int>,
                                                 IdentityRoleClaim<int>,
                                                 IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<AppUser>()
            .HasIndex(u => u.NickName)
            .IsUnique();


            modelBuilder.Entity<AppUser>()
            .Property(p => p.NickName).IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

        }
    }
}
