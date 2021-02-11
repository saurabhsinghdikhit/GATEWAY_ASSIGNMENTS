using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterEntities.Entities;

namespace TheaterAPI.Service
{
    public class TheaterService
    {
        public List<Theater> GetTheaters()
        {
            var theaters = new List<Theater>();
            for (int i = 1; i <= 10; i++)
            {
                theaters.Add(new Theater
                {
                    Id = i,
                    Name = $"Theater_{i}",
                    OwnerName = $"Owner_{i}",
                    RegistrationDate = DateTime.ParseExact("22/11/2009", "dd/MM/yyyy", null),
                    Ratings = i,
                    Address = new Address
                    {
                        Id = i,
                        Street = $"Street_{i}",
                        Number = i,
                        City = $"City_{i}",
                        State = $"State_{i}",
                        Zip = $"Zip_{i}",
                        Country = $"Country_{i}"
                    }
                });
            }
            return theaters;
        }
        public Theater GetTheater(int Id)
        {
            return GetTheaters().Find(r => r.Id == Id);
        }
    }
}
