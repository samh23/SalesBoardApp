using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesBoardApp.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesBoardApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Image { get; set; }

        [Range(1, 10000)]
        [Required]
        public double Price { get; set; }

        [Range(0, 10)]
        [Required]
        public int Available { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Posted { get; set; }
        
        public string UserId { get; set; }
        public SalesBoardAppUser SalesBoardAppUser { get; set; }

    }
}
