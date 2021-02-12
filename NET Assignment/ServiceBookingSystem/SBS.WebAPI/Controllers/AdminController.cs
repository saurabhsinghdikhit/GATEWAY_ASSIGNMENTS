using SBS.BAL.Interfaces;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBS.WebAPI.Controllers
{
    /// <summary>
    /// Admin Controller Class
    /// </summary>
    /// <returns></returns>
    public class AdminController : ApiController
    {
        private readonly IAdminManager _adminManager;
        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <returns></returns>
        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }
        /// <summary>
        /// Get All Dealers
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Admin/GetDealer")]
        public IEnumerable<DealerVM> getDealers()
        {
            return _adminManager.getDealers();
        }
        /// <summary>
        /// Create a dealer
        /// </summary>
        /// <returns></returns>
        [HttpPost,Route("Admin/insert")]
        public string CreateDealer(DealerVM dealerVM)
        {
            return _adminManager.createDealer(dealerVM);
        }
        /// <summary>
        /// Update a dealer
        /// </summary>
        /// <returns></returns>
        [HttpPost,Route("Admin/updateDealer")]
        public bool UpdateDealer(DealerVM dealerVM)
        {
            return _adminManager.updateDealer(dealerVM);
        }
        /// <summary>
        /// Delete a dealer
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("Admin/deleteDealer/{Id}")]
        public bool DeleteDealer(int Id)
        {
            return _adminManager.deleteDealer(Id);
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Admin/GetCustomers")]
        public IEnumerable<CustomerVM> getCustomers()
        {
            return _adminManager.getCustomers();
        }
        /// <summary>
        /// Create a customer
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/insertCustomer")]
        public string CreateCustomer(CustomerVM customerVM)
        {
            return _adminManager.createCustomer(customerVM);
        }
        /// <summary>
        /// Update a customer
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/updateCustomer")]
        public bool UpdateCustomer(CustomerVM customerVM)
        {
            return _adminManager.updateCustomer(customerVM);
        }
        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("Admin/deleteCustomer/{Id}")]
        public bool DeleteCustomer(int Id)
        {
            return _adminManager.deleteCustomer(Id);
        }
        /// <summary>
        /// Get All Mechanics
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Admin/GetMechanics")]
        public IEnumerable<MechanicVM> getMechanic()
        {
            return _adminManager.getMechanics();
        }
        /// <summary>
        /// Create a Mechanic
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/insertMechanic")]
        public string CreateMechanic(MechanicVM mechanicVM)
        {
            return _adminManager.createMechanic(mechanicVM);
        }
        /// <summary>
        /// Update a Mechanic
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/updateMechanic")]
        public bool UpdateMechanic(MechanicVM mechanicVM)
        {
            return _adminManager.updateMechanic(mechanicVM);
        }
        /// <summary>
        /// Delete a Mechanic
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("Admin/deleteMechanic/{Id}")]
        public bool DeleteMechanic(int Id)
        {
            return _adminManager.deleteMechanic(Id);
        }
        /// <summary>
        /// Get All services
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("Admin/Services")]
        public IEnumerable<ServiceVM> getServices()
        {
            return _adminManager.getServices();
        }
        /// <summary>
        /// Create a service
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/insertService")]
        public string CreateService(ServiceVM serviceVM)
        {
            return _adminManager.createServices(serviceVM);
        }
        /// <summary>
        /// Update a service
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/updateService")]
        public bool UpdateService(ServiceVM serviceVM)
        {
            return _adminManager.updateServices(serviceVM);
        }
        /// <summary>
        /// Delete a service
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("Admin/deleteService/{Id}")]
        public bool DeleteService(int Id)
        {
            return _adminManager.deleteServices(Id);
        }
        /// <summary>
        /// Get All Appointments
        /// </summary>
        /// <returns></returns>
        [Route("Admin/GetAppointments")]
        public IEnumerable<AppointBookingVM> GetAppointments()
        {
            return _adminManager.getAppointments();
        }
        /// <summary>
        /// Get All Approved Appointments
        /// </summary>
        /// <returns></returns>
        [Route("Admin/GetApprovedAppointments")]
        public IEnumerable<AppointBookingVM> GetApprovedAppointments()
        {
            return _adminManager.getApprovedAppointments();
        }
        /// <summary>
        /// Insert a appointment from admin side
        /// </summary>
        /// <returns></returns>
        [Route("Admin/insertAppointment")]
        public string insertAppointment(AppointBookingVM model)
        {
            return _adminManager.createAdminAppointment(model);
        }
        /// <summary>
        /// Get Dropdown value for customer
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Admin/GetDropdownCustomers")]
        public IEnumerable<CustomerDropdownModel> CustomerDropdown()
        {
            return _adminManager.CustomerDropdown();
        }
        /// <summary>
        /// Get Dropdown value for vehicle by customer Id
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Admin/VehicleDropdown/{id}")]
        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            return _adminManager.VehicleDropdown(id);
        }
        /// <summary>
        /// Get appointment by id
        /// </summary>
        /// <returns></returns>
        [Route("Admin/getAppointment/{Id}")]
        public AppointBookingVM getAppoiment(int Id)
        {
            return _adminManager.getAppointment(Id);
        }
        /// <summary>
        /// Update an appointment
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("Admin/updateAppointment")]
        public bool UpdateAppointment(AppointBookingVM model)
        {
            return _adminManager.updateAppointment(model);
        }
        /// <summary>
        /// Approve an appointment
        /// </summary>
        /// <returns></returns>
        [HttpPost,Route("Admin/ApproveAppointment")]
        public bool ApproveAppointment(AppointBookingVM model)
        {
            return _adminManager.ApproveAppointment(model);
        }
        /// <summary>
        /// Get Mechanic by search of brands
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Admin/getMechanicFromBrand/{searchText}")]
        public MechanicVM getMechanics(string searchText)
        {
            return _adminManager.getMechanics(searchText);
        }
        /// <summary>
        /// Get vehicle brand by vehicle id
        /// </summary>
        /// <returns></returns>
        [Route("Admin/getVehicleBrandMake/{id}")]
        public string getVehicleBrandMake(int id)
        {
            return _adminManager.getBrandByVehicle(id);
        }
    }
}
