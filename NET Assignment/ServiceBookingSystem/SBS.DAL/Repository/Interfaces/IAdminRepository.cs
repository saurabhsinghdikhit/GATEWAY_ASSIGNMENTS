using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<DealerVM> getDealers();
        string createDealer(DealerVM dealerVM);
        bool updateDealer(DealerVM dealerVM);
        bool deleteDealer(int Id);
        IEnumerable<CustomerVM> getCustomers();
        string createCustomer(CustomerVM customerVM);
        bool updateCustomer(CustomerVM customerVM);
        bool deleteCustomer(int Id);
        IEnumerable<MechanicVM> getMechanics();
        string createMechanic(MechanicVM mechanicVM);
        bool updateMechanic(MechanicVM mechanicVM);
        bool deleteMechanic(int Id);
        IEnumerable<ServiceVM> getServices();
        string createServices(ServiceVM serviceVM);
        bool updateServices(ServiceVM serviceVM);
        bool deleteServices(int Id);
        IEnumerable<AppointBookingVM> getAppointments();
        IEnumerable<AppointBookingVM> getApprovedAppointments();
        AppointBookingVM getAppointment(int Id);
        string createAdminAppointment(AppointBookingVM model);
        bool updateAppointment(AppointBookingVM model);
        bool ApproveAppointment(AppointBookingVM model);
        IEnumerable<CustomerDropdownModel> CustomerDropdown();
        IEnumerable<VehicleDropdownModel> VehicleDropdown(int id);
        MechanicVM getMechanics(string searchText);
        string getBrandByVehicle(int id);
    }
}
