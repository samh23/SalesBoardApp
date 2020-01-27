using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesBoardApp.Areas.Identity.Data;
using SalesBoardApp.Models;
using SalesBoardApp.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace SalesBoardApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SalesBoardAppContext _context;
        private readonly UserManager<SalesBoardAppUser> _userManager;

        public HomeController(SalesBoardAppContext context, SignInManager<SalesBoardAppUser> signInManager, UserManager<SalesBoardAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //find all of the current users products
            var products = _context.Product
                            .Where(p => p.UserId == _userManager.GetUserId(User));
            //find all purchases of the current users products
            var purchases = await _context.Purchase
                            .Where(p => p.SellerId == _userManager.GetUserId(User))
                            .Include(p => p.Customer).ToListAsync();

            //find all distinct customers in the purchases list
            var distinctCustomers = purchases.Select(x => x.CustomerId).Distinct();

            List<Purchase> customerPurchases = new List<Purchase>();

            //for each customer in the distinct list, check it against the purchases list. If the customers match, add to the total amount variable
            //the customerPurchases list at the end will contain 1 entry for each customer with total amount that customer has spent
            foreach (var customer in distinctCustomers)
            {
                double amount = 0;
                foreach (var purchase in purchases)
                {
                    if (customer == purchase.CustomerId)
                    {
                        amount += purchase.Amount;
                    }
                }
                customerPurchases.Add(new Purchase
                {
                    SellerId = _userManager.GetUserId(User),
                    CustomerId = customer,
                    Amount = amount,
                    Customer = await _context.SalesBoardAppUser
                               .Where(u => u.Id == customer)
                               .FirstOrDefaultAsync()
                });
                amount = 0;
            }

            //create a new UserInfoViewModel set the Products and Purchases fields
            var UserInfo = new UserInfoViewModel
            {
                Products = await products.ToListAsync(),
                Purchases = customerPurchases
            };

            return View(UserInfo);
        }
    }
}
