using BookingEntities.BookingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Service
{
    public class ShowService
    {
        public List<Show> getShows()
        {
            var show = new List<Show>();
            for (int i = 1; i <= 10; i++)
            {
                show.Add(new Show
                {
                    Id = i,
                    Name = $"Deluxe_{i}",
                    TheaterId = i,
                    MovieId = i,
                    StartTime = Convert.ToDateTime($"{i}:00"),
                    EndTime = Convert.ToDateTime($"{i + 3}:00"),
                    Price = i * 1000,
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
