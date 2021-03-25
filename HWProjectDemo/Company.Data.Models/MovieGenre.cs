using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Data.Models
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        //Nav Property
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}
