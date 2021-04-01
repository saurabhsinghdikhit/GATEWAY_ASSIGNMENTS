using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CLPMT.BE;

namespace TESTING.CLPMT.BAL.Database
{
    public class PassengerRepository
    {
        private readonly TestingDBContext _testingDBContext;
        public PassengerRepository(TestingDBContext testingDBContext)
        {
            _testingDBContext = testingDBContext;
        }
        public BE.Passenger AddPassenger(BE.Passenger passenger)
        {
            Mapper.CreateMap<BE.Passenger, Passenger>();
            Passenger passenger1 = Mapper.Map<Passenger>(passenger);
            _testingDBContext.Passengers.Add(passenger1);
            _testingDBContext.SaveChanges();
            return passenger;
        }
        public  IList<BE.Passenger> GetPassengers()
        {
            Mapper.CreateMap<Passenger, BE.Passenger>();
            return Mapper.Map<List<BE.Passenger>>(_testingDBContext.Passengers.ToList());
              
        }
        public  BE.Passenger GetPassengerById(Guid Id)
        {
            Mapper.CreateMap<Passenger, BE.Passenger>();
            return Mapper.Map<BE.Passenger>(_testingDBContext.Passengers.FirstOrDefault(x => x.Number == Id));
        }
        public  bool DeletePassenger(Guid passengerId)
        {
            Mapper.CreateMap<BE.Passenger, Passenger>();
            if (_testingDBContext.Passengers.Remove(Mapper.Map<Passenger>(GetPassengerById(passengerId))) != null)
                return true;
            else
                return false;
        }
        public BE.Passenger UpdatePassenger(BE.Passenger passenger)
        {
            Mapper.CreateMap<BE.Passenger, Passenger>();
            BE.Passenger passengerToUpdate = Mapper.Map<BE.Passenger>(GetPassengerById(passenger.Number));
            if (passengerToUpdate == null)
                return null;
            passengerToUpdate.ContactNo = passenger.ContactNo;
            passengerToUpdate.FirstName = passenger.FirstName;
            passengerToUpdate.LastName = passenger.LastName;
            _testingDBContext.SaveChanges();
            return passengerToUpdate;
        }
        
    }
}
