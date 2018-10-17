namespace MapWorld.Migrations
{
    using MapWorld.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MapWorld.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MapWorld.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Manager" });
            }

            if (!context.Roles.Any(r => r.Name == "Employee"))
            {
                roleManager.Create(new IdentityRole { Name = "Employee" });
            }

            if (!context.stores.Any(t => t.Location == "1101 N Main St, Kernersville, NC 27284"))
            {
                context.stores.AddOrUpdate(
                    new Stores
                    {
                        Id = 1,
                        Location = "1101 N Main St, Kernersville, NC 27284",
                        StoreName = "Map World on North Main St.",
                        PictureUrl = "/img/MapWorldStores.jpg"
                    },
                    new Stores
                    {
                        Id = 2,
                        Location = "129 Fulton St, New York, NY 10038",
                        StoreName = "Map World on Fulton St.",
                        PictureUrl = "/img/MapWorldStores.jpg"
                    },
                    new Stores
                    {
                        Id = 3,
                        Location = "1123 S California Blvd, Walnut Creek, CA 94596",
                        StoreName = "Map World on South California Blvd.",
                        PictureUrl = "/img/MapWorldStores.jpg"
                    },
                    new Stores
                    {
                        Id = 4,
                        Location = "3801 Tennessee Ave, Chattanooga, TN 37409",
                        StoreName = "Map World on Tennessee Ave.",
                        PictureUrl = "/img/MapWorldStores.jpg"
                    },
                    new Stores
                    {
                        Id = 5,
                        Location = "2902 Palmer Hwy, Texas City, TX 77590",
                        StoreName = "Map World on Palmer Hwy.",
                        PictureUrl = "/img/MapWorldStores.jpg"
                    }
                );
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(r => r.Email == "jmahoney2261@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jmahoney2261@yahoo.com",
                    Email = "jmahoney2261@yahoo.com",
                    FirstName = "John",
                    LastName = "Mahoney"
                }, "password");
            }

            var userId = userManager.FindByEmail("jmahoney2261@yahoo.com").Id;
            userManager.AddToRole(userId, "Manager");

            if (!context.Users.Any(r => r.Email == "john.lopez@davey.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "john.lopez@davey.com",
                    Email = "john.lopez@davey.com",
                    FirstName = "John",
                    LastName = "Lopez"
                }, "password");
            }

            userId = userManager.FindByEmail("john.lopez@davey.com").Id;
            userManager.AddToRole(userId, "Manager");

            if (!context.Users.Any(r => r.Email == "cap@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "cap@mailinator.com",
                    Email = "cap@mailinator.com",
                    FirstName = "Steve",
                    LastName = "Rogers",
                    StoreId = 1,
                    PictureUrl = "/uploads/cap.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("cap@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "buck@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "buck@mailinator.com",
                    Email = "buck@mailinator.com",
                    FirstName = "Bucky",
                    LastName = "Barnes",
                    StoreId = 1,
                    PictureUrl = "/uploads/buck.png"
                }, "password");
            }

            userId = userManager.FindByEmail("cap@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "iron@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "iron@mailinator.com",
                    Email = "iron@mailinator.com",
                    FirstName = "Tony",
                    LastName = "Stark",
                    StoreId = 2,
                    PictureUrl = "/uploads/tony.jpeg"
                }, "password");
            }

            userId = userManager.FindByEmail("iron@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "spidey@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "spidey@mailinator.com",
                    Email = "spidey@mailinator.com",
                    FirstName = "Peter",
                    LastName = "Parker",
                    StoreId = 2,
                    PictureUrl = "/uploads/peter.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("spidey@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "rome@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rome@mailinator.com",
                    Email = "rome@mailinator.com",
                    FirstName = "Julius",
                    LastName = "Caesar",
                    StoreId = 3,
                    PictureUrl = "/uploads/julius.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("rome@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "stab@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "stab@mailinator.com",
                    Email = "stab@mailinator.com",
                    FirstName = "Marcus",
                    LastName = "Brutus",
                    StoreId = 3,
                    PictureUrl = "/uploads/brutus.jpeg"
                }, "password");
            }

            userId = userManager.FindByEmail("stab@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "freedom@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "freedom@mailinator.com",
                    Email = "freedom@mailinator.com",
                    FirstName = "George",
                    LastName = "Washington",
                    StoreId = 4,
                    PictureUrl = "/uploads/george.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("freedom@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "freedom2.0@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "freedom2.0@mailinator.com",
                    Email = "freedom2.0@mailinator.com",
                    FirstName = "Abraham",
                    LastName = "Lincoln",
                    StoreId = 4,
                    PictureUrl = "/uploads/lincoln.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("freedom2.0@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "apple@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "apple@mailinator.com",
                    Email = "apple@mailinator.com",
                    FirstName = "Steve",
                    LastName = "Jobs",
                    StoreId = 5,
                    PictureUrl = "/uploads/jobs.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("apple@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");

            if (!context.Users.Any(r => r.Email == "msft@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "msft@mailinator.com",
                    Email = "msft@mailinator.com",
                    FirstName = "Bill",
                    LastName = "Gates",
                    StoreId = 5,
                    PictureUrl = "/uploads/bill.jpg"
                }, "password");
            }

            userId = userManager.FindByEmail("msft@mailinator.com").Id;
            userManager.AddToRole(userId, "Employee");
        }
    }
}
