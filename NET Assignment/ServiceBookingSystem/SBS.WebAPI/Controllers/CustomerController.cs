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
    /// Customer Controller Class
    /// </summary>
    /// <returns></returns>
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;
        /// <summary>
        /// Constructor Dependency injection
        /// </summary>
        /// <returns></returns>
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        /// <summary>
        /// Register customer
        /// </summary>
        /// <returns></returns>
        [Route("Customer/insert")]
        public string Insert(CustomerVM model)
        {
            return _customerManager.createCustomer(model);
        }
        /// <summary>
        /// Customer Login
        /// </summary>
        /// <returns></returns>
        [Route("Customer/Login")]
        [HttpPost]
        public CustomerVM customerLogin(CustomerVM _user)
        {
            return _customerManager.validateCustomer(_user);
        }
        /// <summary>
        /// Forget password
        /// </summary>
        /// <returns></returns>
        [Route("Customer/ForgotPassword")]
        public CustomerVM forgotPassword(CustomerVM _user)
        {
            return _customerManager.forgotPassword(_user);
        }
        /// <summary>
        /// Reset password
        /// </summary>
        /// <returns></returns>
        [Route("Customer/resetPassword")]
        public string resetPassword(CustomerVM _user)
        {
            return _customerManager.resetPassword(_user);
        }
        /// <summary>
        /// Insert vehicle details
        /// </summary>
        /// <returns></returns>
        [Route("Customer/insertVehicle")]
        public string insertVehicle(VehicleVM vehicle)
        {
            return _customerManager.createVehicle(vehicle);
        }
        /// <summary>
        /// Get Dealer dropdown
        /// </summary>
        /// <returns></returns>
        [Route("Customer/DealerDropdown")]
        [HttpGet]
        public IEnumerable<DealerDropdownModel> DealerDropdown()
        {
            return _customerManager.DealerDropdown();
        }
        /// <summary>
        /// Get Service dropdown
        /// </summary>
        /// <returns></returns>
        [Route("Customer/ServiceDropdown")]
        [HttpGet]
        public IEnumerable<ServiceDropdownModel> ServiceDropdown()
        {
            return _customerManager.ServiceDropdown();
        }
        /// <summary>
        /// Get Vehicle dropdown by Customer ID
        /// </summary>
        /// <returns></returns>
        [Route("Customer/VehicleDropdown/{id}")]
        [HttpGet]
        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            return _customerManager.VehicleDropdown(id);
        }
        /// <summary>
        /// Insert Appointment
        /// </summary>
        /// <returns></returns>
        [Route("Customer/addAppointment")]
        public string insertAppointment(AppointBookingVM appointBookingVM)
        {
            return _customerManager.createAppointment(appointBookingVM);
        }
    }
}
