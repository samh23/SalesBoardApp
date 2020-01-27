using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesBoardApp.Models;
using SalesBoardApp.Extensions;
using Microsoft.AspNetCore.Identity;
using SalesBoardApp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using SalesBoardApp.Extensions.Alerts;

namespace SalesBoardApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly SalesBoardAppContext _context;
        private readonly UserManager<SalesBoardAppUser> _userManager;

        public CartController(SalesBoardAppContext context, UserManager<SalesBoardAppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //If session is null set a new session with key 'cart' holding an empty List
            CheckNullSession();

            //get the cart list from the session
            var itemList = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            //if itemList is not empty find the total price of the cart
            double sum = 0;
            if(itemList.Count > 0)
            {
                sum = itemList.Sum(item => item.Product.Price * item.Quantity);
            }

            var cart = new ShoppingCartViewModel
            {
                Items = itemList,
                TotalPrice = sum
            };

            return View(cart);
        }

        public async Task<IActionResult> Buy(int id)
        {
            //First make sure the current user can't add any of their products to cart. Note: views will also disable the buttons
            var pId = await (from p in _context.Product
                             where p.UserId == _userManager.GetUserId(User)
                             select p.ProductId).FirstOrDefaultAsync();
            if (id == pId)
            {
                return RedirectToAction("Index").WithDanger("Sorry!", "You can't purchase your own products.");
            }

            //If user clicks add to cart and there is no cart session created, create a cart session
            CheckNullSession();

            //if the session contains an empty list
            if (SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart").Count() == 0)
            {
                var itemList = new List<Item>();

                //get product from the database, check its availability. If available add to the session list, else disallow adding to cart
                Product product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);
                if (product.Available > 0)
                {
                    itemList.Add(new Item { Product = product, Quantity = 1});
                    //set the session with the updated list
                    SessionExtensions.SetObjectAsJson<List<Item>>(HttpContext.Session, "cart", itemList);
                }
                else
                {
                    return RedirectToAction("Index").WithDanger("Sorry!", "Item is currently unavailable.");
                }
            }
            //if session contains an unempty list
            else
            {
                var itemList = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                //find the index for the product in the list
                int index = IsInCart(id);
                //if not -1, item is in the list
                if (index != -1)
                {
                    //check that the number of products available is greater than the quantity of products added to the cart. If so increase the quantity of the item in the list
                    if(itemList[index].Product.Available > itemList[index].Quantity)
                    {
                        itemList[index].Quantity++;
                    }
                    else
                    {
                        return RedirectToAction("Index", "Products").WithDanger("Sorry!", "You can not purchase more of this item.");
                    }
                    
                }
                //if -1, item is not in the list. Get product from the database and add it to the list if available
                else
                {
                    Product product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);
                    if (product.Available > 0)
                    {
                        itemList.Add(new Item { Product = product, Quantity = 1 });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Products").WithDanger("Sorry!", "Item is currently unavailable.");
                    }

                }
                SessionExtensions.SetObjectAsJson<List<Item>>(HttpContext.Session, "cart", itemList);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            CheckNullSession();

            var itemList = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = IsInCart(id);
            // if product is in the list, reduce quantity if greater than 1, otherwise remove the product from the list
            if (index != -1)
            {
                if (itemList[index].Quantity > 1)
                {
                    itemList[index].Quantity--;
                }
                else
                {
                    itemList.RemoveAt(index);
                }
            }
            SessionExtensions.SetObjectAsJson<List<Item>>(HttpContext.Session, "cart", itemList);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(string items, double totalPrice ) //items parameter is a list converted to JSON in the view (therefore sent as a string)
        {
            //create a new ShoppingCartViewModel with list of items the user has in the shopping cart
            ShoppingCartViewModel allPurchases = new ShoppingCartViewModel
            {
                Items = JsonConvert.DeserializeObject<List<Item>>(items), //deserialize items parameter
                TotalPrice = totalPrice
            };

            List<Purchase> purchaseList = new List<Purchase>();
            double amount;
            string seller;
            int available;

            //foreach item in allPurchases, add to the purchaseList (total price for a purchase is quantity times price)
            foreach (var item in allPurchases.Items)
            {
                amount = item.Product.Price * item.Quantity;
                seller = item.Product.UserId;

                purchaseList.Add(new Purchase
                {
                    SellerId = seller,
                    CustomerId = _userManager.GetUserId(User),
                    Amount = amount
                });

                //after adding item to purchaseList, update the Product table in the database by decreasing the Available field
                available = item.Product.Available - item.Quantity;
                Product product = new Product { ProductId = item.Product.ProductId, Available = available };
                try
                {
                    _context.Attach(product);
                    _context.Entry(product).Property(p => p.Available).IsModified = true;
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
            }

            //Create new purchases in the database from the purchaseList
            _context.AddRange(purchaseList);
            await _context.SaveChangesAsync();

            //clear the shopping cart
            var itemList = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            itemList.Clear();
            SessionExtensions.SetObjectAsJson<List<Item>>(HttpContext.Session, "cart", itemList);


            return RedirectToAction(nameof(Index));
        }

        private int IsInCart(int id)
        {
            List<Item> itemList = SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i = 0; i < itemList.Count; i++)
            {
                if(itemList[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        private void CheckNullSession()
        {
            if (SessionExtensions.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                SessionExtensions.SetObjectAsJson<List<Item>>(HttpContext.Session, "cart", new List<Item>() { });
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}