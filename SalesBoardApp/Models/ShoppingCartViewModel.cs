using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Models
{
    public class ShoppingCartViewModel
    {
        public List<Item> Items;

        public double TotalPrice { get; set; }
    }
}
