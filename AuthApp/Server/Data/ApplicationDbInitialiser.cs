namespace AuthApp.Server.Data
{
    using System;
    using System.Linq;
    using AuthApp.Server.Models;
    using AuthApp.Shared.Models;
    using Microsoft.AspNetCore.Identity;

    public static class ApplicationDbInitialiser
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            AddRoleIfNotExists(roleManager, Roles.Administrator);
            AddRoleIfNotExists(roleManager, Roles.Moderator);
            AddRoleIfNotExists(roleManager, Roles.TenantAdmin);
        }
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            (string name, string password, string role)[] demoUsers = new[]
            {
                (name: "sally@sally.com", password: "Passw0rd!", role: Roles.Administrator),
                (name: "bob@bob.com", password: "Passw0rd!", role: Roles.Moderator),
                (name: "abi@abi.com", password: "Passw0rd!", role: Roles.TenantAdmin + "," + Roles.Moderator),
                (name: "fred@fred.com", password: "Passw0rd!", role: string.Empty)
            };

            foreach ((string name, string password, string role) user in demoUsers)
            {
                AddUserIfNotExists(userManager, user);
            }
        }

        private static void AddUserIfNotExists(UserManager<ApplicationUser> userManager, (string name, string password, string role) demoUser)
        {
            ApplicationUser user = userManager.FindByNameAsync(demoUser.name).Result;
            if (user == default)
            {
                var newAppUser = new ApplicationUser
                {
                    UserName = demoUser.name,
                    Email = demoUser.name,
                    EmailConfirmed = true
                };
                _ = userManager.CreateAsync(newAppUser, demoUser.password).Result;
                if (!string.IsNullOrWhiteSpace(demoUser.role))
                {
                    var roles = demoUser.role.Split(',').Select(a => a.Trim()).ToArray();
                    Console.WriteLine($"{roles.Length}");
                    foreach (var role in roles)
                    {
                        _ = userManager.AddToRoleAsync(newAppUser, role).Result;
                    }
                }
            }
        }

        private static void AddRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (roleManager.FindByNameAsync(roleName).Result is null)
            {
                roleManager.CreateAsync(new IdentityRole { Name = roleName }).Wait();
            }
        }
    }
}
