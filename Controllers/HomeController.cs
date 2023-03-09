using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_toapita.Models;
using Mission09_toapita.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Controllers
{
    public class HomeController : Controller
    {
        //initialize the repo
        private IBookRepository repo; 
        
        // assign book Repo to our repo
        public HomeController(IBookRepository bookRepository) => repo = bookRepository;

        public IActionResult Index(string category, int pageNum = 1)
        {
            // Set page length
            int pageLen = 10;

            //Create view Model
            var x = new BookViewModel
            {
                //Get books using repo
                Books = repo.Books
                .Where(p => p.Category == category || category == null)
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageLen)
                .Take(pageLen),

                //Set up page details
                PageDetails = new PageDetails
                {
                    TotalBooks = (category == null ? repo.Books.Count()
                    :repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageLen,
                    CurrentPage = pageNum
                }

            };
            
            //Pass the view model to the view
            return View(x);
        }

        
    }
}
