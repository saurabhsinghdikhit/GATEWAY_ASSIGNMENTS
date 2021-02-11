using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterEntities.Entities;

namespace TheaterAPI.Service
{
    public class ShowService
    {
        public List<Show> getShows()
        {
            var show = new List<Show>();
            for (int i = 1; i <= 10; i++)
            {
                var theater = new TheaterService().GetTheaters().Find(r => r.Id == i);
                var movie = new MovieService().GetMovies().Find(r => r.Id == i);
                show.Add(new Show
                {
                    Id = i,
                    Name=$"Deluxe_{i}",
                    TheaterId = theater.Id,
                    MovieId = movie.Id,
                    StartTime = Convert.ToDateTime($"{i}:00"),
                    EndTime = Convert.ToDateTime($"{i+3}:00"),
                    Price=i*1000,
                    Theater=theater,
                    Movie=movie
                });
            }
            return show;
        }
        public Show GetShow(int Id)
        {
            return getShows().Find(r => r.Id == Id);
        }
    }
}
