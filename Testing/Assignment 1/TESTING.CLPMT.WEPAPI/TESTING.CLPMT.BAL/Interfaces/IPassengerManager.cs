using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CLPMT.BE;

namespace TESTING.CLPMT.BAL.Interfaces
{
    public interface IPassengerManager
    {
        IList<Passenger> GetPassengersList();
        Passenger AddPassenger(Passenger passenger);
        Passenger UpdatePassenger(Passenger passenger);
        Passenger GetPassenger(Guid passengerId);
        bool RemovePassenger(Guid passengerId);
    }
}
