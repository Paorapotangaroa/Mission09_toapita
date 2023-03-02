using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models
{
    public interface IBookRepository
    {
        //Creating an interface that forces Repositories to have IQueryables.
        IQueryable<Book> Books { get; }

    }
}
