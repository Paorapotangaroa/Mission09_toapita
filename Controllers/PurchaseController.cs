using Microsoft.AspNetCore.Mvc;
using Mission09_toapita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private Cart ShoppingCart { get; set; }
        public PurchaseController(IPurchaseRepository temp, Cart cart)
        {
            repo = temp;
            ShoppingCart = cart;
        }
        [HttpGet]
        public IActionResult Checkout()
        {

            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if(ShoppingCart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry! You shopping cart was empty");
               
            }
            if (ModelState.IsValid)
            {
                purchase.Books = ShoppingCart.Items.ToArray();
                repo.SavePurchase(purchase);
                ShoppingCart.ClearCart();
                return RedirectToPage("/PurchaseDone");
            }
            else
            {
                return View();
            }
        }
    }
}
