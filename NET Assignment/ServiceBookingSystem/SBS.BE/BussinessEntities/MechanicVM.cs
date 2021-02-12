using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BE.BussinessEntities
{
    public class MechanicVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Make { get; set; }
        public string Email { get; set; }
        public int DealerId { get; set; }
    }
}
