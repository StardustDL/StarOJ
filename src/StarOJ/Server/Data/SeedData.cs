using StarOJ.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace StarOJ.Server.Data
{
    public static class SeedData
    {
        public static async Task InitializeIdentityDb(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IdentityDbContext>();
            await context.Database.EnsureCreatedAsync();
            if (!await context.Users.AnyAsync())
            {
                var userStore = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var user = new ApplicationUser
                {
                    UserName = "admin@staroj",
                    Email = "admin@staroj",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                var result = await userStore.CreateAsync(user, "123P$d");

                if (!result.Succeeded)
                {
                    throw new Exception("Create default user failed.");
                }
            }

            await context.SaveChangesAsync();
        }

        public static async Task InitializeDb(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDataContext>();
            await context.Database.EnsureCreatedAsync();
            await context.SaveChangesAsync();
        }
    }
}
