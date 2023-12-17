using Microsoft.AspNetCore.Identity;
using SpeakAndRead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Data
{
    public class MyIdentityDataInitializer
    {
        public static void SeedData(UserManager<User> userManager,
                  RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        // name - correct email
        // password - min 8 charcters, small and capital letter, digit and special char
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Teacher").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Teacher",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Director").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Director",
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedOneUser(UserManager<User> userManager,
                                        string name, string password, string role = null)
        {
            if (userManager.FindByNameAsync(name).Result == null)
            {
                User user = new User
                {
                    UserName = name, // the same like the email
                    Email = name
                };
                IdentityResult result = userManager.CreateAsync(user, password).Result;
                if (result.Succeeded && role != null)
                {
                    userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
        public static void SeedUsers(UserManager<User> userManager)
        {
            SeedOneUser(userManager, "normaluser@localhost", "nUpass1!");
            SeedOneUser(userManager, "normaluse2r@localhost", "nUpass1!");
            SeedOneUser(userManager, "adminuser@localhost", "aUpass1!", "Admin");
            SeedOneUser(userManager, "directoruser@localhost", "dUpass1!", "Director");
            SeedOneUser(userManager, "teacheruser@localhost", "tUpass1!", "Teacher");
        }
    }
}

