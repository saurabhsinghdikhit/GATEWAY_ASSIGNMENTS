using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterEntities.Entities
{
    public class Theater
    {
        public Theater()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double Ratings { get; set; }
        public Address Address { get; set; }
    }
}
