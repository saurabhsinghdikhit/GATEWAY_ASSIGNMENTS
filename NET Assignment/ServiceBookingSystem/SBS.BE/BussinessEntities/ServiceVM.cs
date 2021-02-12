using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.BussinessEntities
{
    public class ServiceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public bool Active { get; set; }
    }
}
