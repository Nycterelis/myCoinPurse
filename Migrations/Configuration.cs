namespace myCoinPurse.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using myCoinPurse.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<myCoinPurse.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(myCoinPurse.Models.ApplicationDbContext context)
        {
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);
            var role = new IdentityRole();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "HeadOfHouse"))
            {
                role = new IdentityRole { Name = "HeadOfHouse" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "HouseMember"))
            {
                role = new IdentityRole { Name = "HouseMember" };
                manager.Create(role);
            }
            if (context.Users.Any(u => u.Email == "toomuchyang@gmail.com"))
            {
                userManager.AddToRoles(context.Users.FirstOrDefault(u => u.Email == "toomuchyang@gmail.com").Id, new string[] { "Admin" });
            }

            context.Households.AddOrUpdate(
              h => h.Name,
              new Household { Name = "House of Seeds" },
              new Household { Name = "House of the Rising Sun" },
              new Household { Name = "Animal House" }
            );

            context.Budgets.AddOrUpdate(
              h => h.Name,
              new Budget { Name = "Budget for Seeds", HouseholdId = 7 },
              new Budget { Name = "Rising Budget", HouseholdId = 8 },
              new Budget { Name = "Animal Budgets", HouseholdId = 9 }
            );

            //context.Categories.AddOrUpdate(
            //    c => c.Name,
            //    new Category { Name = "Car", Households = }
            //    );
        }
    }
}
