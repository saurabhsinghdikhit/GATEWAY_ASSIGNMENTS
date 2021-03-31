using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.CLPMT.BAL.Interfaces;
using TESTING.CLPMT.BE;
using TESTING.CLPMT.WEPAPI.Controllers;
using Xunit;
using TESTING.CLPMT.BAL.Implementations;
using Newtonsoft.Json;
using System.IO;
using System.Web.Http.Results;
using System.Net;

namespace TESTING.CLPMT.TEST
{
    public class PassengerControllerTest
    {
        private readonly Mock<IPassengerManager> mockDataRepository = new Mock<IPassengerManager>();
        private readonly PassengerController _passengerController;
        private PassengerManager _pm;
        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
            _pm=new PassengerManager();
        }
        [Fact]
        public void Test_AddPassenger()
        {

            // Arrange
            var newPassenger = new Passenger();
            newPassenger.FirstName= "saurabh";
            newPassenger.LastName = "singh";
            newPassenger.ContactNo = "9621221615";

            var addedPassenger = _pm.AddPassenger(newPassenger);

            // Act
            var response = mockDataRepository.Setup(
                x => x.AddPassenger(newPassenger)).Returns(addedPassenger);
            var result = _passengerController.Post(newPassenger);

            // Assert
            NegotiatedContentResult<Passenger> negResult = Assert.IsType<NegotiatedContentResult<Passenger>>(response);
            Assert.NotNull(negResult.Content);
        }
        [Fact]
        public void Test_GetPassenger()
        {

            // Arrange
            var resultobj = mockDataRepository.Setup(x => x.GetPassengersList()).Returns(GetPassengers());
            
            //Act
            var response = _passengerController.Get();

            //Assert
            NegotiatedContentResult<Passenger> negResult = Assert.IsType<NegotiatedContentResult<Passenger>>(response);
            Assert.Equal(HttpStatusCode.Accepted, negResult.StatusCode);
        }

        [Fact]
        public void Test_UpdatePassenger()
        {

            // Arrange
            IList<Passenger> passengers = _pm.GetPassengersList();
            var passenger1 = passengers.First<Passenger>();
            passenger1.FirstName = "updated first name";
            passenger1.LastName= "updated last name";
            passenger1.ContactNo = "1234";
            var updatedPassenger = _pm.UpdatePassenger(passenger1);

            // Act
            var resultObj = mockDataRepository.Setup(x => x.UpdatePassenger(passenger1)).Returns(updatedPassenger);
            var response = _passengerController.Put(passenger1);
            
            //Assert
            NegotiatedContentResult<Passenger> negResult = Assert.IsType<NegotiatedContentResult<Passenger>>(response);
            Assert.Equal(HttpStatusCode.Accepted, negResult.StatusCode);
        }
        [Fact]
        public void Test_DeletePassenger()
        {

            // Arrange
            IList<Passenger> passengers = _pm.GetPassengersList();
            var passenger1 = passengers.First<Passenger>();
            
            // Act
            var isDeleted = _pm.RemovePassenger(passenger1.Number);

            // Assert
            Assert.True(isDeleted);
        }

        private static IList<Passenger> GetPassengers()
        {
            IList<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){ Number=Guid.NewGuid(),FirstName="ram1",LastName="singh1",ContactNo="12324"},
                new Passenger(){ Number=Guid.NewGuid(),FirstName="ram2",LastName="singh2",ContactNo="12324"},
                new Passenger(){ Number=Guid.NewGuid(),FirstName="ram3",LastName="singh3",ContactNo="12324"}
            };
            return passengers;
        }
    }
}
