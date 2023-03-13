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
        //In the constructor create the repo and shopping cart.
        public ShoppingCartModel(IBookRepository temp, Cart c)
        {
            repo = temp;
            ShoppingCart = c;

        }

        //This is how you get to the page and how it knows what page to return you to.
        public void OnGet(string returnUrl)
        {
            //Render the page using the shopping cart
            ReturnUrl = returnUrl ?? "/";
            
        }

        //When the page posts add an item.

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            //Get a book using the repo based on book id, either initialize a cart or use JSON to create it
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //Add the item and update the JSON
            ShoppingCart.AddItem(b, 1);

            //Redirect
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        //Allow the user to remove items
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            ShoppingCart.RemoveItem(ShoppingCart.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
