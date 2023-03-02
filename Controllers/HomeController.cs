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
        private IBookRepository repo; 
        

        public HomeController(IBookRepository bookRepository) => repo = bookRepository;

        public IActionResult Index(int pageNum = 1)
        {
            // Set page length
            int pageLen = 10;

            //Create view Model
            var x = new BookViewModel
            {
                //Get books using repo
                Books = repo.Books
                .OrderBy(p => p.Title)
                .Skip((pageNum - 1) * pageLen)
                .Take(pageLen),

                //Set up page details
                PageDetails = new PageDetails
                {
                    TotalBooks = repo.Books.Count(),
                    BooksPerPage = pageLen,
                    CurrentPage = pageNum
                }

            };
            
            //Pass the view model to the view
            return View(x);
        }

        
    }
}
