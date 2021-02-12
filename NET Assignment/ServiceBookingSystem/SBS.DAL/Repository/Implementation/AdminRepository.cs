using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.DAL.Database;
using SBS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly Database.SBSDbContext _dbContext;
        public AdminRepository()
        {
            _dbContext = new Database.SBSDbContext();
        }

        public string createAdminAppointment(AppointBookingVM model)
        {
            _dbContext.AppointBookings.Add(AutoMapper.Mapper.Map<AppointBooking>(model));
            _dbContext.SaveChanges();
            return "Appointment Added";
        }

        public string createCustomer(CustomerVM customerVM)
        {
            _dbContext.Customers.Add(AutoMapper.Mapper.Map<Customer>(customerVM));
            _dbContext.SaveChanges();
            return "Customer Added";
        }

        public string createDealer(DealerVM dealerVM)
        {
            _dbContext.Dealers.Add(AutoMapper.Mapper.Map<Dealer>(dealerVM));
            _dbContext.SaveChanges();
            return "Dealer Added";
        }

        public string createMechanic(MechanicVM mechanicVM)
        {
            _dbContext.Mechanics.Add(AutoMapper.Mapper.Map<Mechanic>(mechanicVM));
            _dbContext.SaveChanges();
            return "Mechanic Added";
        }

        public string createServices(ServiceVM serviceVM)
        {
            _dbContext.Services.Add(AutoMapper.Mapper.Map<Service>(serviceVM));
            _dbContext.SaveChanges();
            return "Customer Added";
        }

        public IEnumerable<CustomerDropdownModel> CustomerDropdown()
        {
            var customers = _dbContext.Customers;
            IEnumerable<CustomerDropdownModel> customerDropdowns = AutoMapper.Mapper.Map<IEnumerable<CustomerDropdownModel>>(customers);
            return customerDropdowns;
        }

        public bool deleteCustomer(int Id)
        {
            Customer list = _dbContext.Customers.Find(Id);
            _dbContext.Customers.Remove(list);
            _dbContext.SaveChanges();
            return true;
        }

        public bool deleteDealer(int Id)
        {
            Dealer list = _dbContext.Dealers.Find(Id);
            _dbContext.Dealers.Remove(list);
            _dbContext.SaveChanges();
            return true;
        }

        public bool deleteMechanic(int Id)
        {
            Mechanic list = _dbContext.Mechanics.Find(Id);
            _dbContext.Mechanics.Remove(list);
            _dbContext.SaveChanges();
            return true;
        }

        public bool deleteServices(int Id)
        {
            Service list = _dbContext.Services.Find(Id);
            _dbContext.Services.Remove(list);
            _dbContext.SaveChanges();
            return true;
        }

        public AppointBookingVM getAppointment(int Id)
        {
            return AutoMapper.Mapper.Map<AppointBookingVM>(_dbContext.AppointBookings.FirstOrDefault(x=>x.Id==Id));
        }

        public IEnumerable<AppointBookingVM> getAppointments()
        {
            return AutoMapper.Mapper.Map<IEnumerable<AppointBookingVM>>(_dbContext.AppointBookings.Where(x=>x.Status==false));
        }

        public IEnumerable<AppointBookingVM> getApprovedAppointments()
        {
            return AutoMapper.Mapper.Map<IEnumerable<AppointBookingVM>>(_dbContext.AppointBookings.Where(x => x.Status == true).OrderBy(x=>x.StartTime));
        }

        public string getBrandByVehicle(int id)
        {
            return _dbContext.Vehicles.FirstOrDefault(x=>x.Id==id).Make.ToString();
        }

        public IEnumerable<CustomerVM> getCustomers()
        {
            return AutoMapper.Mapper.Map<IEnumerable<CustomerVM>>(_dbContext.Customers);
        }

        public IEnumerable<DealerVM> getDealers()
        {
            return AutoMapper.Mapper.Map<IEnumerable<DealerVM>>(_dbContext.Dealers); 
        }

        public IEnumerable<MechanicVM> getMechanics()
        {
            return AutoMapper.Mapper.Map<IEnumerable<MechanicVM>>(_dbContext.Mechanics);
        }

        public MechanicVM getMechanics(string searchText)
        {
            return AutoMapper.Mapper.Map<MechanicVM>(_dbContext.Mechanics.Where(x=>x.Make==searchText.ToLower()).FirstOrDefault());
        }

        public IEnumerable<ServiceVM> getServices()
        {
            return AutoMapper.Mapper.Map<IEnumerable<ServiceVM>>(_dbContext.Services);
        }

        public bool updateAppointment(AppointBookingVM model)
        {
            _dbContext.Entry(AutoMapper.Mapper.Map<AppointBooking>(model)).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        public bool ApproveAppointment(AppointBookingVM model)
        {
            AppointBooking appointment = _dbContext.AppointBookings.Find(model.Id);
            appointment.Status = model.Status;
            appointment.MechanicId = model.MechanicId;
            appointment.StartTime = model.StartTime;
            appointment.EndTime = model.EndTime;
            _dbContext.Entry(appointment).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool updateCustomer(CustomerVM customerVM)
        {
            Customer customer = AutoMapper.Mapper.Map<Customer>(customerVM);
            _dbContext.Entry(customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool updateDealer(DealerVM dealerVM)
        {
            Dealer dealer = AutoMapper.Mapper.Map<Dealer>(dealerVM);
            _dbContext.Entry(dealer).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool updateMechanic(MechanicVM mechanicVM)
        {
            Mechanic mechanic = AutoMapper.Mapper.Map<Mechanic>(mechanicVM);
            _dbContext.Entry(mechanic).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool updateServices(ServiceVM serviceVM)
        {
            Service service = AutoMapper.Mapper.Map<Service>(serviceVM);
            _dbContext.Entry(service).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            var vehicle = _dbContext.Vehicles.Where(x => x.Customer.Id == id).ToList();
            IEnumerable<VehicleDropdownModel> vehicles = AutoMapper.Mapper.Map<IEnumerable<VehicleDropdownModel>>(vehicle);
            return vehicles;
        }
    }
}
