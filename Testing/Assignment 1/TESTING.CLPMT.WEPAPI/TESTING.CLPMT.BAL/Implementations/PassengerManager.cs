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
        private readonly PassengerRepository _passengerRepository;
        public PassengerManager()
        {
            _passengerRepository = new PassengerRepository(new TestingDBContext());
        }
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
            return _passengerRepository.AddPassenger(CreatePassengerWithId(passenger));
        }

        public BE.Passenger GetPassenger(Guid passengerId)
        {
            return _passengerRepository.GetPassengerById(passengerId);
        }

        public IList<BE.Passenger> GetPassengersList()
        {
            return _passengerRepository.GetPassengers();
        }

        public bool RemovePassenger(Guid passengerId)
        {
            return _passengerRepository.DeletePassenger(passengerId);
        }

        public BE.Passenger UpdatePassenger(BE.Passenger passenger)
        {
            return _passengerRepository.UpdatePassenger(passenger);
        }
    }
}
