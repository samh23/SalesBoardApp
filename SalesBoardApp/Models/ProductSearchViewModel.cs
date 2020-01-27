using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Models
{
    public class ProductSearchViewModel
    {
        public List<Product> Products;
        public string SearchString { get; set; }
    }
}
