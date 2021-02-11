using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterEntities.Entities
{
    public class Show
    {
        public Show()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Theater Theater { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
    }
}
