using HMS.BAL.Interfaces;
using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Classes
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string createHotel(Hotel model)
        {
            return _hotelRepository.createHotel(model);
        }

        public List<Hotel> getAllHolels()
        {
            return _hotelRepository.getAllHolels();
        }

    

        public Hotel getHotel(int id)
        {
            return _hotelRepository.getHotel(id);
        }
    }
}
