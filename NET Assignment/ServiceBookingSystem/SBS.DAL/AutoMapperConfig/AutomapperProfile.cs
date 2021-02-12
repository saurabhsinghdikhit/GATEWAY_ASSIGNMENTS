using AutoMapper;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DAL.AutoMapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CustomerVM,Customer>();
            CreateMap<Customer,CustomerVM>();
            CreateMap<Customer, CustomerDropdownModel>();
            CreateMap<VehicleVM, Vehicle>();
            CreateMap<Vehicle, VehicleVM>();
            CreateMap<Dealer, DealerVM>();
            CreateMap<DealerVM,Dealer>();
            CreateMap<Mechanic, MechanicVM>();
            CreateMap<MechanicVM, Mechanic>();
            CreateMap<Service, ServiceVM>();
            CreateMap<ServiceVM, Service>();
            CreateMap<Dealer, DealerDropdownModel>();
            CreateMap<Service, ServiceDropdownModel>();
            CreateMap<Vehicle, VehicleDropdownModel>();
            CreateMap<AppointBookingVM, AppointBooking>();
            CreateMap<AppointBooking, AppointBookingVM>();
        }
    }
}
