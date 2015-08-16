namespace MVCPetAdoption.DataContexts.WunderpetIdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCPetAdoption.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPetAdoption.DataContexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\WunderpetIdentityMigrations";
        }

        protected override void Seed(MVCPetAdoption.DataContexts.IdentityDb context)
        {
            //  This method will be called after migrating to the latest version.

            // Check if "Admin" role exists, if not, create one
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // Check if admin user "admin@petadoption.com" exists, if not, create him
            if (!context.Users.Any(u => u.UserName == "admin@petadoption.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var adminUser = new ApplicationUser { UserName = "admin@petadoption.com", PasswordHash = new PasswordHasher().HashPassword("admin") };

                context.Users.Add(adminUser);
                manager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
