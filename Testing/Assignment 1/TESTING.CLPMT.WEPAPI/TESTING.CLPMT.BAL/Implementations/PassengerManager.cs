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
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        private Passenger CreatePassengerWithId(Passenger passenger)
        {
            Guid guid1 = Guid.NewGuid();
            passenger.Number = guid1;
            _passenger.Add(guid1, passenger);
            return passenger;
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            return PassengerRepository.AddPassenger(CreatePassengerWithId(passenger));
        }

        public Passenger GetPassenger(Guid passengerId)
        {
            return PassengerRepository.GetPassengerById(passengerId);
        }

        public IList<Passenger> GetPassengersList()
        {
            return PassengerRepository.GetPassengers();
        }

        public bool RemovePassenger(Guid passengerId)
        {
            return PassengerRepository.DeletePassenger(passengerId);
        }

        public Passenger UpdatePassenger(Passenger passenger)
        {
            return PassengerRepository.UpdatePassenger(passenger);
        }
    }
}
