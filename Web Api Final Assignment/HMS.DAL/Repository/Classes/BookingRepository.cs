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
    public class BookingRepository : IBookingRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly Database.HotelManagementSystemEntities _dbContext;
        public BookingRepository()
        {
            _dbContext = new Database.HotelManagementSystemEntities();
        }

        public string deleteBooking(Booking model)
        {
            try
            {
                if (model.Id != null)
                {
                    Database.Booking booking = _dbContext.Bookings.Find(model.Id);
                    if (booking != null)
                    {
                        booking.BookingStatus = BookingsStatus.Deleted.ToString();
                        _dbContext.SaveChanges();
                        return "Status of Booking id " + model.Id + " has been changed to deleted";
                     }
                    else
                    {
                        return "Booking No "+ model.Id + " is not there nothing to delete";
                    }
                }
                return "Booking id is empty";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Booking> getAllBooking()
        {
            var entities = _dbContext.Bookings.ToList();
            List<Booking> list = new List<Booking>();
            if (entities != null)
            {
                Mapper.CreateMap<Database.Booking, Booking>();
                foreach (var item in entities)
                {
                    Booking booking = Mapper.Map<Booking>(item);
                    list.Add(booking);
                }
            }
            return list;
        }

        public string updateBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.RoomId == model.RoomId).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if(bookingRecord.BookingStatus== BookingsStatus.Optional.ToString() || bookingRecord.BookingStatus == BookingsStatus.Definitive.ToString())
                        {
                            var oldBookingDate = bookingRecord.BookingDate;
                            bookingRecord.BookingDate = model.BookingDate;
                            _dbContext.SaveChanges();
                            return "Booking of room no " + model.RoomId + " has been changed from "+ oldBookingDate+" to " + model.BookingDate + " with optional status";
                        }
                        return "Booking of room no " + model.RoomId + " has been " + bookingRecord.BookingStatus + ". So the booking date cannot be modified";
                    }
                    else
                    {
                        return "Room no. "+model.RoomId+ " is not booked! please book first to update your booking";
                    }
                }
                return "Model is empty";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string updateBookingStatus(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var bookingRecord = _dbContext.Bookings.Where(m => m.Id == model.Id).FirstOrDefault();
                    if (bookingRecord != null)
                    {
                        if (bookingRecord.BookingStatus == BookingsStatus.Optional.ToString() || bookingRecord.BookingStatus == BookingsStatus.Definitive.ToString())
                        {
                            bookingRecord.BookingStatus = model.BookingStatus;
                            _dbContext.SaveChanges();
                            return "Status of Booking no " + model.Id + " has been changed to " + model.BookingStatus;
                        }
                        return "Booking of room no " + model.Id + " has been " + bookingRecord.BookingStatus + ". So the booking status cannot be modified";
                    }
                    else
                    {
                        return "Booking no. " + model.Id + " is not there! please book first to update your booking";
                    }
                }
                return "Model is empty";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
