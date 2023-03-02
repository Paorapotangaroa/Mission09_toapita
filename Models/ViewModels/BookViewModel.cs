using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models.ViewModels
{
    public class BookViewModel
    {
        //We want the model to have both books and page details
        public IQueryable<Book> Books { get; set; }
        public PageDetails PageDetails { get; set; }
    }
}
