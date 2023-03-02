﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_toapita.Models.ViewModels
{
    public class PageDetails
    {
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(((double)TotalBooks / BooksPerPage));
    }
}