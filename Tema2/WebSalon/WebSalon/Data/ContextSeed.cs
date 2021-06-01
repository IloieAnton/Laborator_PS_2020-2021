using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebSalon.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.Supervizor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Models.Enums.Roles.User.ToString()));
        }

        public static async Task SeedSupervizorAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "supervizor@yahoo.com",
                Email = "supervizor@yahoo.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Ana are 4 mere.");
                    await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.Supervizor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Models.Enums.Roles.User.ToString());
                }

            }

        }
    }
}
