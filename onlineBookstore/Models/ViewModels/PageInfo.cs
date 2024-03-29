﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // E: Figure out how many pages needed
        public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}
