using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interfaces
{
    public interface IHotelManager
    {
        Hotel getHotel(int id);
        List<Hotel> getAllHolels();
        string createHotel(Hotel model);
    }
}
