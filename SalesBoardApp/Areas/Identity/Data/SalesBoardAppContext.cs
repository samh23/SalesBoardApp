using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesBoardApp.Areas.Identity.Data;
using SalesBoardApp.Models;

namespace SalesBoardApp.Models
{
    public class SalesBoardAppContext : IdentityDbContext<SalesBoardAppUser>
    {
        public SalesBoardAppContext(DbContextOptions<SalesBoardAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasOne(p => p.SalesBoardAppUser)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Purchase>()
                .HasKey(p => new { p.PurchaseId });

            builder.Entity<Purchase>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.PurchaseSellers)
                .HasForeignKey(p => p.SellerId);

            builder.Entity<Purchase>()
                .HasOne(p => p.Customer)
                .WithMany(s=> s.PurchaseCustomers)
                .HasForeignKey(p => p.CustomerId);
        }

        public DbSet<SalesBoardApp.Models.Product> Product { get; set; }
        public DbSet<SalesBoardApp.Models.Purchase> Purchase { get; set; }
        public DbSet<SalesBoardApp.Areas.Identity.Data.SalesBoardAppUser> SalesBoardAppUser { get; set; }
    }
}
