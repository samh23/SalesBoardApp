using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SalesBoardApp.Models;

namespace SalesBoardApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the SalesBoardAppUser class
    public class SalesBoardAppUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }

        public List<Product> Products { get; set; }

        public List<Purchase> PurchaseSellers { get; set; }
        public List<Purchase> PurchaseCustomers { get; set; }
    }
}
