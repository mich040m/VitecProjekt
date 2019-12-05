using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecProjekt.Areas.Identity.Data;

namespace VitecProjekt.Data
{
    public static class SeedDB
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<VitecUser>>();

            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            //Tilføjer roles til DB
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1  
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Tilføjer en admin user til DB
            VitecUser user = await userManager.FindByEmailAsync("Admin@gmail.com");

            if (user == null)
            {
                user = new VitecUser()
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com",
                };
                await userManager.CreateAsync(user, "Admin!123");
            }
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
