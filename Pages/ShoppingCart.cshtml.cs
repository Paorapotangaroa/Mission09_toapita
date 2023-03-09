using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_toapita.Infrastructure;
using Mission09_toapita.Models;

namespace Mission09_toapita.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private IBookRepository repo { get; set; }
        public Cart ShoppingCart { get; set; }
        public string ReturnUrl { get; set; }

        public ShoppingCartModel(IBookRepository temp)
        {
            repo = temp;

        }
        public void OnGet(string returnUrl)
        {
            //Render the page using the shopping cart
            ReturnUrl = returnUrl ?? "/";
            ShoppingCart = HttpContext.Session.GetJson<Cart>("cart")??new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            //Get a book using the repo based on book id, either initialize a cart or use JSON to create it
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            ShoppingCart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            //Add the item and update the JSON
            ShoppingCart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", ShoppingCart);

            //Redirect
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
