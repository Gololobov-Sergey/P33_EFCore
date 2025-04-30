﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookGenres
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public int Percent { get; set; }

    }
}
