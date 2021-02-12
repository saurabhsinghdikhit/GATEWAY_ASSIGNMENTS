using SBS.BAL.Interfaces;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Implementation
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public bool ApproveAppointment(AppointBookingVM model)
        {
            return _adminRepository.ApproveAppointment(model);
        }

        public string createAdminAppointment(AppointBookingVM model)
        {
            return _adminRepository.createAdminAppointment(model);
        }

        public string createCustomer(CustomerVM customerVM)
        {
            return _adminRepository.createCustomer(customerVM);
        }

        public string createDealer(DealerVM dealerVM)
        {
            return _adminRepository.createDealer(dealerVM);
        }

        public string createMechanic(MechanicVM mechanicVM)
        {
            return _adminRepository.createMechanic(mechanicVM);
        }

        public string createServices(ServiceVM serviceVM)
        {
            return _adminRepository.createServices(serviceVM);
        }

        public IEnumerable<CustomerDropdownModel> CustomerDropdown()
        {
            return _adminRepository.CustomerDropdown();
        }

        public bool deleteCustomer(int Id)
        {
            return _adminRepository.deleteCustomer(Id);
        }

        public bool deleteDealer(int Id)
        {
            return _adminRepository.deleteDealer(Id);
        }

        public bool deleteMechanic(int Id)
        {
            return _adminRepository.deleteMechanic(Id);
        }

        public bool deleteServices(int Id)
        {
            return _adminRepository.deleteServices(Id);
        }

        public AppointBookingVM getAppointment(int Id)
        {
            return _adminRepository.getAppointment(Id);
        }

        public IEnumerable<AppointBookingVM> getAppointments()
        {
            return _adminRepository.getAppointments();
        }

        public IEnumerable<AppointBookingVM> getApprovedAppointments()
        {
            return _adminRepository.getApprovedAppointments();
        }

        public string getBrandByVehicle(int id)
        {
            return _adminRepository.getBrandByVehicle(id);
        }

        public IEnumerable<CustomerVM> getCustomers()
        {
            return _adminRepository.getCustomers();
        }

        public IEnumerable<DealerVM> getDealers()
        {
            return _adminRepository.getDealers();
        }

        public IEnumerable<MechanicVM> getMechanics()
        {
            return _adminRepository.getMechanics();
        }

        public MechanicVM getMechanics(string searchText)
        {
            return _adminRepository.getMechanics(searchText);
        }

        public IEnumerable<ServiceVM> getServices()
        {
            return _adminRepository.getServices();
        }

        public bool updateAppointment(AppointBookingVM model)
        {
            return _adminRepository.updateAppointment(model);
        }

        public bool updateCustomer(CustomerVM customerVM)
        {
            return _adminRepository.updateCustomer(customerVM);
        }

        public bool updateDealer(DealerVM dealerVM)
        {
            return _adminRepository.updateDealer(dealerVM);
        }

        public bool updateMechanic(MechanicVM mechanicVM)
        {
            return _adminRepository.updateMechanic(mechanicVM);
        }

        public bool updateServices(ServiceVM serviceVM)
        {
            return _adminRepository.updateServices(serviceVM);
        }

        public IEnumerable<VehicleDropdownModel> VehicleDropdown(int id)
        {
            return _adminRepository.VehicleDropdown(id);
        }
    }
}
