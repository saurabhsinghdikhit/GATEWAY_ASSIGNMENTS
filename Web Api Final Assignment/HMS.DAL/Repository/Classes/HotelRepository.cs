using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL.Repository.Classes
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Database.HotelManagementSystemEntities _dbContext;
        public HotelRepository()
        {
            _dbContext = new Database.HotelManagementSystemEntities();
        }
        public string createHotel(Hotel entity)
        {
            try
            {
                if (entity != null)
                {
                    Mapper.CreateMap<Hotel, Database.Hotel>();
                    Database.Hotel hotel = Mapper.Map<Database.Hotel>(entity);
                    _dbContext.Hotels.Add(hotel);
                    _dbContext.SaveChanges();

                    return "Successfully Added!!";
                }
                return "Model is null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> getAllHolels()
        {
            var entities = _dbContext.Hotels.OrderBy(c => c.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();
            if (entities != null)
            {
                Mapper.CreateMap<Database.Hotel, Hotel>();
                foreach (var item in entities)
                {
                    Hotel hotel = Mapper.Map<Hotel>(item);
                    list.Add(hotel);
                }
            }
            return list;
        }


        public Hotel getHotel(int id)
        {
            var entity = _dbContext.Hotels.Where(c=>c.Id==id).FirstOrDefault();
            Hotel hotel = new Hotel();
            if (entity != null)
            {
                Mapper.CreateMap<Database.Hotel, Hotel>();
                hotel = Mapper.Map<Hotel>(entity);
            }
            
            return hotel;
        }
    }
}
