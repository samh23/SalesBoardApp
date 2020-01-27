using SalesBoardApp.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string SellerId { get; set; }
        public SalesBoardAppUser Seller { get; set; }
        public string CustomerId { get; set; }
        public SalesBoardAppUser Customer { get; set; }

        public double Amount { get; set; }
    }
}
