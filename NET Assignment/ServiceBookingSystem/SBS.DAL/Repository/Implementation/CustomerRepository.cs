using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.DAL.Database;
using SBS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.SBSDbContext _dbContext;
        public CustomerRepository()
        {
            _dbContext = new Database.SBSDbContext();
        }

        public string createAppointment(AppointBookingVM appointBookingVM)
        {
            AppointBooking appointBooking = AutoMapper.Mapper.Map<AppointBooking>(appointBookingVM);
            _dbContext.AppointBookings.Add(appointBooking);
            _dbContext.SaveChanges();
            return "Customer Added";
        }

        public string createCustomer(CustomerVM model)
        {
            Customer customer=AutoMapper.Mapper.Map<Customer>(model);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return "Customer Added";
        }

        public string createVehicle(VehicleVM _vehicle)
        {
            Vehicle vehicle = AutoMapper.Mapper.Map<Vehicle>(_vehicle);
            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
            return "Vehicle Added";
        }

        public IEnumerable<DealerDropdownModel> DealerDropdown()
        {
            var dealer = _dbContext.Dealers;
            IEnumerable<DealerDropdownModel> dealers = AutoMapper.Mapper.Map<IEnumerable<DealerDropdownModel>>(dealer);
            return dealers;
        }

        public CustomerVM forgotPassword(CustomerVM customer)
        {
            var userRecord = _dbContext.Customers.Where(x => x.Email.Equals(customer.Email) && x.Question.Equals(customer.Question) && x.Answer.Equals(customer.Answer)).FirstOrDefault();
            CustomerVM customerVM = AutoMapper.Mapper.Map<CustomerVM>(userRecord);
            if (userRecord == null)
            {
                return null;
            }
            else
            {
                return customerVM;
            }
        }

        public string resetPassword(CustomerVM customer)
        {
            try
            {
                var bookingRecord = _dbContext.Customers.Where(m => m.Id == customer.Id).FirstOrDefault();
                if (bookingRecord != null)
                {
                        bookingRecord.Password = customer.Password;
                        _dbContext.SaveChanges();
                        return "changed";
                }
                else
                {
                    return "password does not changed";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<ServiceDropdownModel> ServiceDropdown()
        {
            var dealer = _dbContext.Services;
            IEnumerable<ServiceDropdownModel> dealers = AutoMapper.Mapper.Map<IEnumerable<ServiceDropdownModel>>(dealer);
            return dealers;
        }

        public CustomerVM validatCustomer(CustomerVM customer)
        {
            var userRecord = _dbContext.Customers.Where(x => x.Email.Equals(customer.Email) && x.Password.Equals(customer.Password)).FirstOrDefault();
            CustomerVM customerVM = AutoMapper.Mapper.Map<CustomerVM>(userRecord);
            if (userRecord == null)
            {
                return null;
            }
            else
            {
                return customerVM;
            }
        }

        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            var vehicle = _dbContext.Vehicles.Where(x=>x.Customer.Id==id).ToList();
            IEnumerable<VehicleDropdownModel> vehicles = AutoMapper.Mapper.Map<IEnumerable<VehicleDropdownModel>>(vehicle);
            return vehicles;
        }
    }
}
