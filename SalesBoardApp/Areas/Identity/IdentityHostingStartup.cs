using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesBoardApp.Areas.Identity.Data;
using SalesBoardApp.Models;

[assembly: HostingStartup(typeof(SalesBoardApp.Areas.Identity.IdentityHostingStartup))]
namespace SalesBoardApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<SalesBoardAppContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("SalesBoardAppContextConnection")));

            //    services.AddDefaultIdentity<SalesBoardAppUser>()
            //        .AddEntityFrameworkStores<SalesBoardAppContext>();
            //});
        }
    }
}