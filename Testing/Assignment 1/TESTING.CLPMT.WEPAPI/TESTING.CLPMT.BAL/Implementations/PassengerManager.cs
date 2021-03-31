using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CLPMT.BAL.Database;
using TESTING.CLPMT.BAL.Interfaces;
using TESTING.CLPMT.BE;

namespace TESTING.CLPMT.BAL.Implementations
{
    public class PassengerManager : IPassengerManager
    {
        readonly Dictionary<Guid, BE.Passenger> _passenger = new Dictionary<Guid, BE.Passenger>();
        private BE.Passenger CreatePassengerWithId(BE.Passenger passenger)
        {
            Guid guid1 = Guid.NewGuid();
            passenger.Number = guid1;
            _passenger.Add(guid1, passenger);
            return passenger;
        }
        public BE.Passenger AddPassenger(BE.Passenger passenger)
        {
            return PassengerRepository.AddPassenger(CreatePassengerWithId(passenger));
        }

        public BE.Passenger GetPassenger(Guid passengerId)
        {
            return PassengerRepository.GetPassengerById(passengerId);
        }

        public IList<BE.Passenger> GetPassengersList()
        {
            return PassengerRepository.GetPassengers();
        }

        public bool RemovePassenger(Guid passengerId)
        {
            return PassengerRepository.DeletePassenger(passengerId);
        }

        public BE.Passenger UpdatePassenger(Passenger passenger)
        {
            return PassengerRepository.UpdatePassenger(passenger);
        }
    }
}
