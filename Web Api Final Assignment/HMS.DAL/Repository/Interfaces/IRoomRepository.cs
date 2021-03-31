using HMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> sortRoom(string sortBy);
        string createRoom(Room model);
        bool checkRoomAvailability(int id, DateTime date);
        List<Room> filterRooms(string city, decimal pincode, decimal price, string category);
        string bookRoom(Booking model);
    }
}
