using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterEntities.Entities
{
    public class Movie
    {
        public Movie()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Casts { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double IMDB { get; set; }
        public string Language { get; set; }
    }
}
