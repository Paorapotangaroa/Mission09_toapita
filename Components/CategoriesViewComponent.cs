using Microsoft.AspNetCore.Mvc;
using Mission09_toapita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Components
{
    public class CategoriesViewComponent: ViewComponent
    {
        //Create the view component repo
        private IBookRepository repo { get; set; }

        //create a repo when I use the constructor
        public CategoriesViewComponent(IBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            //Set the categories in the view bag
            ViewBag.BookCategory = RouteData?.Values["category"];
            //Get the distinct book categories and pass it to the view
            var booksCat = repo.Books.Select(x => x.Category)
                .Distinct().OrderBy(x => x);
            return View(booksCat);
        }
    }
}
