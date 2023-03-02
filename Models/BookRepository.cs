using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models
{
    public class BookRepository : IBookRepository
    {
        private BookstoreContext context { get; set; }
        public BookRepository(BookstoreContext bc) => context = bc;
        public IQueryable<Book> Books => context.Books;

    }
}
