using System;
using CardManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardManagement.Data
{
    public static class PreSeeder
    {
        public static async Task Seeder(AppDbContext ctx,
                                        RoleManager<IdentityRole> roleManager,
                                        UserManager<User> userManager)
        {
            await ctx.Database.EnsureCreatedAsync();

            if (!roleManager.Roles.Any())
            {
                var listOfRoles = new List<IdentityRole>
                {
                    new IdentityRole("User"),
                    new IdentityRole("Admin")
                };

                foreach (var role in listOfRoles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            if (!userManager.Users.Any())
            {
                var listOfUsers = new List<User>
                {
                    new User
                    {
                        Id = "d3bb7c62-3eb8-41a7-8b0b-d8cce15a2924",
                        UserName = "adeyemi@example.com",
                        NormalizedUserName = "adeyemi@EXAMPLE.COM",
                        Email = "adeyemi@example.com",
                        NormalizedEmail = "adeyemi@EXAMPLE.COM",
                        PhoneNumber = "198987928962",
                        Firstname = "Adeyemi",
                        Lastname = "Onibokun",
                        CreatedDate = DateTime.Now
                    },

                    new User
                    {
                        Id = "69bd4fa4-0d49-4825-85df-f6bc1b4522c0",
                        UserName = "admin@example.com",
                        NormalizedUserName = "ADMIN@EXAMPLE.COM",
                        Email = "admin@example.com",
                        PhoneNumber = "901980189089",
                        Firstname = "Admin",
                        Lastname = "Admin",
                        CreatedDate = DateTime.Now
                    }
                };

                int counter = 0;

                foreach (var user in listOfUsers)
                {
                    var result = await userManager.CreateAsync(user, "P@$$word1");

                    if (result.Succeeded)
                    {
                        if (counter == 0)
                        {
                            await userManager.AddToRoleAsync(user, "User");
                        }

                        else
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                    }

                    counter++;
                }
            }
        }
    }
}