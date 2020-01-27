using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesBoardApp.Areas.Identity.Data;
using SalesBoardApp.Extensions.Alerts;
using SalesBoardApp.Models;

namespace SalesBoardApp.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly SalesBoardAppContext _context;
        private readonly UserManager<SalesBoardAppUser> _userManager;

        public ProductsController(IAuthorizationService authorizationService, SalesBoardAppContext context, UserManager<SalesBoardAppUser> userManager)
        {
            _authorizationService = authorizationService;
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index(string searchString)
        {
            //get all products from the Products table
            var products = from p in _context.Product
                           select p;

            // if the user did a search, set products equal to all products that contain the searchString in their title
            if(!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            //create a new ProductSearchViewModel
            var productSearchVM = new ProductSearchViewModel
            {
                Products = await products.Include(p => p.SalesBoardAppUser).ToListAsync()
            };

            return View(productSearchVM);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //find the product with parameter id
            var product = await _context.Product
                .Include(p => p.SalesBoardAppUser)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            //if no product with parameter id return not found
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Price,Available,Posted,Image,UserId")] Product product)
        {

            //check that the UserId sent from the form matches the current logged in user
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, product, "AccessPolicy");

            //if authorization failed return ChallengeResult
            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            //if model state is valid, add the product to the database and return to Home with a success message
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home").WithSuccess("New Product!", "Other users can now purchase this item");
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            //find product with parameter id
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //check that current user is authorized to edit product
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, product, "AccessPolicy");

            //if not authorized return ChallengeResult with an unauthorized message
            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult().WithDanger("Unauthorized!", "You are not authorized to edit this item. Please log in as the owner of this item"); ;
            }
     
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Price,Available,Posted,Image,UserId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            //check that current user is authorized to edit product
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, product, "AccessPolicy");

            //if not authorized return ChallengResult with unauthorized message
            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult().WithDanger("Unauthorized!", "You are not authorized to edit this item. Please log in as the owner of this item");
            }

            //check that the edited model is valid, update the product. 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Home").WithSuccess("Updated!", "Product details successfully updated.");
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // find product with parameter id
            var product = await _context.Product
                .Include(p => p.SalesBoardAppUser)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            //check current user is authorized to delete product
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, product, "AccessPolicy");

            //if not authorized return new ChallengeResult with unauthorized message
            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult().WithDanger("Unauthorized!", "You are not authorized to delete this item. Please log in as the owner of this item"); ;
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //find product with parameter id
            var product = await _context.Product.FindAsync(id);

            //check current user is authorized to delete product
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, product, "AccessPolicy");

            if(!isAuthorized.Succeeded)
            {
                return new ChallengeResult().WithDanger("Unauthorized!", "You are not authorized to delete this item. Please log in as the owner of this item");
            }

            //remove product from the database
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home").WithInfo("Deleted.", "Item succesfully deleted");
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
