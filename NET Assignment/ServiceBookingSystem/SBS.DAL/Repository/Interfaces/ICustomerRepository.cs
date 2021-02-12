using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        string createCustomer(CustomerVM customer);
        CustomerVM validatCustomer(CustomerVM customer);
        CustomerVM forgotPassword(CustomerVM customer);
        string resetPassword(CustomerVM customer);
        string createVehicle(VehicleVM vehicle);
        IEnumerable<DealerDropdownModel> DealerDropdown();
        IEnumerable<ServiceDropdownModel> ServiceDropdown();
        IEnumerable<VehicleDropdownModel> VehicleDropdown(int id);
        string createAppointment(AppointBookingVM appointBookingVM);
    }
}

