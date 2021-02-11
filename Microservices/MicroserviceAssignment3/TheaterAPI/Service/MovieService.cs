using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterEntities.Entities;

namespace TheaterAPI.Service
{
    public class MovieService
    {
        public List<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            for (int i = 1; i <= 10; i++)
            {
                movies.Add(new Movie
                {
                    Id = i,
                    Name = $"Movie_{i}",
                    Casts = $"Cast_{i}",
                    Genre=$"Genre_{i}",
                    ReleaseDate = DateTime.ParseExact($"01/01/2020", "dd/MM/yyyy", null),
                    IMDB = i,
                    Language = $"Language_{i}"
                });
            }
            return movies;
        }
        public Movie GetMovie(int Id)
        {
            return GetMovies().Find(r => r.Id == Id);
        }
    }
}
