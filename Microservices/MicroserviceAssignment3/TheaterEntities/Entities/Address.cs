using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterEntities.Entities
{
    public class Address
    {
        public Address()
        {
        }
        public long Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string FullAddress => $"{Number}, {Street}, {City}, {State}, {Country}, {Zip}";
    }
}
