using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CLPMT.BE;

namespace TESTING.CLPMT.BAL.Database
{
    public static class PassengerRepository
    {
        private static List<Passenger> passengers=new List<Passenger>();
        static PassengerRepository()
        {
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "ram1", LastName = "singh1", ContactNo = "123245" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "ram2", LastName = "singh2", ContactNo = "123245" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "ram3", LastName = "singh3", ContactNo = "123245" });
        }
        public static Passenger AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            return passenger;
        }
        public static IList<Passenger> GetPassengers()
        {
            return passengers;
        }
        public static Passenger GetPassengerById(Guid Id)
        {
            return passengers.FirstOrDefault(x=>x.Number==Id);
        }
        public static bool DeletePassenger(Guid passengerId)
        {
            return passengers.Remove(GetPassengerById(passengerId));
        }
        public static Passenger UpdatePassenger(Passenger passenger)
        {
            Passenger passengerToUpdate = GetPassengerById(passenger.Number);
            if (passengerToUpdate == null)
                return null;
            passengerToUpdate.ContactNo = passenger.ContactNo;
            passengerToUpdate.FirstName = passenger.FirstName;
            passengerToUpdate.LastName = passenger.LastName;
            return passengerToUpdate;
        }
    }
}
