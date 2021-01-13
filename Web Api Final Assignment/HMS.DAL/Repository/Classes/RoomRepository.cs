using HMS.DAL.Repository.Interfaces;
using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HMS.DAL.Repository.Classes
{
    public class RoomRepository : IRoomRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly Database.HotelManagementSystemEntities _dbContext;
        public RoomRepository()
        {
            _dbContext = new Database.HotelManagementSystemEntities();
        }

        public string bookRoom(Booking model)
        {
            try
            {
                if (model!=null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.RoomId == model.RoomId && DbFunctions.TruncateTime(m.BookingDate) == model.BookingDate).FirstOrDefault();
                    if (bookingRecord == null)
                    {
                        Database.Booking booking = new Database.Booking();
                        booking.RoomId = model.RoomId;
                        booking.BookingStatus = BookingsStatus.Optional.ToString();
                        booking.BookingDate = model.BookingDate;
                        _dbContext.Bookings.Add(booking);
                        _dbContext.SaveChanges();
                        return "Booking of room no " + model.RoomId + " has been confirmed on " + model.BookingDate + " with optional status";
                    }
                    else
                    {
                        return "Room is already booked on "+ model.BookingDate;
                    }
                }
                return "ID and date can are required";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool checkRoomAvailability(int id, DateTime date)
        {
            try
            {
                if (id != null && date != null)
                {
                    var bookingRecord=_dbContext.Bookings.Where(m => m.RoomId==id && DbFunctions.TruncateTime(m.BookingDate)==date).FirstOrDefault();
                    if (bookingRecord == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string createRoom(Room entity)
        {
            try
            {
                if (entity != null)
                {
                    Mapper.CreateMap<Room, Database.Room>();
                    Database.Room room = Mapper.Map<Database.Room>(entity);
                    _dbContext.Rooms.Add(room);
                    _dbContext.SaveChanges();

                    return "Room Successfully Added!!";
                }
                return "Model is null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Room> sortRoom(string sortBy)
        {
            List<Database.Room> entities=new List<Database.Room>();
            switch (sortBy.ToLower())
            {
                case "city":
                    entities = _dbContext.Hotels.Include(h => h.Rooms).SelectMany(h => h.Rooms).OrderBy(r=>r.Hotel.City).ToList();
                    break;
                case "pincode":
                    entities = _dbContext.Hotels.Include(h => h.Rooms).SelectMany(h => h.Rooms).OrderBy(r => r.Hotel.Pincode).ToList();
                    break;
                case "category":
                    entities = _dbContext.Rooms.OrderBy(r=>r.RoomCategory).ToList();
                    break;
                default:
                    entities = _dbContext.Rooms.OrderBy(r => r.RoomPrice).ToList();
                    break;
            }

           // var entities = _dbContext.Hotels.Where(h => h.City == city).Include(h => h.Rooms).SelectMany(h => h.Rooms).ToList();
            List<Room> list = new List<Room>();
            if (entities != null)
            {
                Mapper.CreateMap<Database.Room, Room>();
                foreach (var item in entities)
                {
                    Room room = Mapper.Map<Room>(item);
                    list.Add(room);
                }
            }
            return list;
            
        }

    }
}
