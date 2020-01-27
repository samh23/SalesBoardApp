using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesBoardApp.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Models
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SalesBoardAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SalesBoardAppContext>>()))
            {
                //Create Admin User
                var adminID = await EnsureUser(serviceProvider, "P@ssword1", "dave_smith@live.com.au", "Dave", "Smith");
                await EnsureRole(serviceProvider, adminID, "Administrator");

                //Create User
                var user1ID = await EnsureUser(serviceProvider, "P@ssword1", "sam_hood@live.com.au", "Sam", "Hood");
                var user2ID = await EnsureUser(serviceProvider, "P@ssword1", "john_johnson@live.com.au", "John", "Johnson");
                var user3ID = await EnsureUser(serviceProvider, "P@ssword1", "emma_taylor@live.com.au", "Emma", "Taylor");

                SeedDB(context, user1ID, user2ID, user3ID, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPw, string userName, string firstName, string lastName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<SalesBoardAppUser>>();
            var user = await userManager.FindByEmailAsync(userName);

            if (user == null)
            {
                user = new SalesBoardAppUser { UserName = userName, Email = userName, FirstName = firstName, LastName = lastName };
                var result = await userManager.CreateAsync(user, testUserPw);
            }
            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string userId, string role)
        {
            IdentityResult result = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if(!await roleManager.RoleExistsAsync(role))
            {
                result = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<SalesBoardAppUser>>();

            var user = await userManager.FindByIdAsync(userId);

            result = await userManager.AddToRoleAsync(user, role);

            return result;
        }

        public static void SeedDB(SalesBoardAppContext context, string user1Id, string user2Id, string user3Id, string adminId)
        {
            if (context.Product.Any())
            {
                return;
            }

            context.AddRange(
                new Product
                {
                    Name = "Bike",
                    Description = "Bike as new. Purchased recently but not used. Negotiations welcome",
                    Price = 300,
                    Available = 1,
                    Posted = DateTime.Parse("2019-02-16"),
                    UserId = user1Id,
                    Image = "https://images.unsplash.com/photo-1507609752873-44646188a77d?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "GTX1070 Graphics Card",
                    Description = "Brand new Asus gtx1070. There are 2 for sale. Price is fixed",
                    Price = 300,
                    Available = 2,
                    Posted = DateTime.Parse("2019-1-24"),
                    UserId = adminId,
                    Image = "https://images.unsplash.com/photo-1512756290469-ec264b7fbf87?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Laptop",
                    Description = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Quaerat saepe nostrum illum hic adipisci repellendus facere impedit officia " +
                                    "delectus voluptatum, dicta iusto numquam minus nam necessitatibus quibusdam vero excepturi doloribus.",
                    Price = 500,
                    Available = 3,
                    Posted = DateTime.Parse("2019-3-04"),
                    UserId = user2Id,
                    Image = "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Garden Set",
                    Description = "A handy set of gardening tools. Tools will not be sold seperately, only as a set.",
                    Price = 55,
                    Available = 1,
                    Posted = DateTime.Parse("2019-3-10"),
                    UserId = user3Id,
                    Image = "https://images.unsplash.com/photo-1515697615578-810b69ac287a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Gibson Les Paul",
                    Description = "2008 Gibson Les Paul. Excellent condition. Comes with case and lead. Open to negotiation, but please be respectable with your offers",
                    Price = 3000,
                    Available = 1,
                    Posted = DateTime.Parse("2019-2-19"),
                    UserId = user3Id,
                    Image = "https://images.unsplash.com/photo-1516924962500-2b4b3b99ea02?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Sony a7s + Lense",
                    Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Quos voluptate iusto, quibusdam natus error velit reiciendis voluptatibus expedita?" +
                                  " Aspernatur sit dolore neque laudantium eligendi vitae mollitia. Ducimus, adipisci consectetur deserunt laudantium, atque recusandae amet alias perspiciatis.",
                    Available = 4,
                    Posted = DateTime.Parse("2019-2-28"),
                    UserId = user1Id,
                    Image = "https://images.unsplash.com/photo-1517444861450-19fc0d046630?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Art",
                    Description = "Some nice cheap art",
                    Price = 15,
                    Available = 1,
                    Posted = DateTime.Parse("2019-2-11"),
                    UserId = user2Id,
                    Image = "https://images.unsplash.com/photo-1452457005517-a0dd81caca2a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Dining Set",
                    Description = "Dining set, suitable for 4 people. Condition as new.",
                    Price = 2515,
                    Available = 1,
                    Posted = DateTime.Parse("2019-3-09"),
                    UserId = user2Id,
                    Image = "https://images.unsplash.com/photo-1544207240-4193795530ee?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Product
                {
                    Name = "Headphones",
                    Description = "Lorem ipsum dolor, sit amet consectetur adipisicing elit. Est aperiam temporibus aliquam consectetur harum exercitationem adipisci, expedita error repellendus quo hic, " +
                                  "nihil tempora amet optio sint voluptas veniam sequi iure.",
                    Price = 195,
                    Available = 2,
                    Posted = DateTime.Parse("2019-3-01"),
                    UserId = user1Id,
                    Image = "https://images.unsplash.com/photo-1420161900862-9a86fa1f5c79?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60"
                },
                new Purchase
                {
                    CustomerId = adminId,
                    SellerId = user1Id,
                    Amount = 300
                },
                new Purchase
                {
                    CustomerId = adminId,
                    SellerId = user1Id,
                    Amount = 208
                },
                new Purchase
                {
                    CustomerId = user3Id,
                    SellerId = user1Id,
                    Amount = 800
                },
                new Purchase
                {
                    CustomerId = adminId,
                    SellerId = user2Id,
                    Amount = 197
                },
                new Purchase
                {
                    CustomerId = adminId,
                    SellerId = user2Id,
                    Amount = 200
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = user2Id,
                    Amount = 800
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = user2Id,
                    Amount = 200
                },
                new Purchase
                {
                    CustomerId = user3Id,
                    SellerId = user2Id,
                    Amount = 561
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = user3Id,
                    Amount = 14
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = user3Id,
                    Amount = 8
                },
                new Purchase
                {
                    CustomerId = user2Id,
                    SellerId = user3Id,
                    Amount = 3659
                },
                new Purchase
                {
                    CustomerId = user2Id,
                    SellerId = user3Id,
                    Amount = 148
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = adminId,
                    Amount = 777
                },
                new Purchase
                {
                    CustomerId = user2Id,
                    SellerId = adminId,
                    Amount = 98
                },
                new Purchase
                {
                    CustomerId = user1Id,
                    SellerId = adminId,
                    Amount = 144
                });
            context.SaveChanges();
        }
    }
}
