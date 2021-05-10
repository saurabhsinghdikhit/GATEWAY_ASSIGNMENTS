using ConsoleApp.Models;
using ConsoleApp.Repository;
using Moq;
using NUnit.Framework;
using System.Reflection;
using ConsoleApp.Test.CustomConstraints;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp.Test
{
    class Tests
    {
        private EmployeeRepository employeeRepository;

        [SetUp]
        public void Setup()
        {
            // Creation of Mock object
            var employeeRepositoryMock = new Mock<EmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetEmployees()).Returns(
                new List<Employee>() {
                    new Employee
                    {
                        Id=1,Name="Saurabh Singh",Department="IT",
                        Address="Navsari",Phone="9621221615",Salary=10000
                    },
                    new Employee
                    {
                        Id=1,Name="Ram Singh",Department="HR",
                        Address="Surat",Phone="9621221615",Salary=20000
                    },
                    new Employee
                    {
                        Id=1,Name="Raju Singh",Department="Legal",
                        Address="Vadodara",Phone="9621221615",Salary=30000
                    }
                });
            employeeRepository = employeeRepositoryMock.Object;
        }

        // Test Cases for custom constraints

        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Spaces_Positive()
        {
            // Act
            string value = " Saurabh Singh ";

            // Assert
            Assert.That("Saurabh Singh", CustomConstraints.Is.RemoveFirstAndLastCharacter(value));
        }
        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Both_Characters_Positive()
        {
            // Act
            string value = "Saurabh Singh";

            // Assert
            Assert.That("aurabh Sing", CustomConstraints.Is.RemoveFirstAndLastCharacter(value));
        }
        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_First_Character_Negative()
        {
            // Act
            string value = "Saurabh Singh";

            // Assert
            Assert.AreNotEqual("Saurabh Sing", CustomConstraints.Is.RemoveFirstAndLastCharacter(value));
        }
        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Last_Character_Negative()
        {
            // Act
            string value = "Saurabh Singh";

            // Assert
            Assert.AreNotEqual("aurabh Singh", CustomConstraints.Is.RemoveFirstAndLastCharacter(value));
        }
        [Test]
        public void RemoveFirstAndLastCharacter_Test_Remove_Both_Characters_Negative()
        {
            // Act
            string value = "Saurabh Singh";

            // Assert
            Assert.AreNotEqual("Saurabh Singh", CustomConstraints.Is.RemoveFirstAndLastCharacter(value));
        }

        // Test cases using Mock

        [Test]
        public void Employee_Count_Test_Positive()
        {
            //Assert 
            Assert.True(employeeRepository.GetEmployees().Count == 3);
        }

        [Test]
        public void Employee_Count_Test__Negative()
        {
            //Assert 
            Assert.False(employeeRepository.GetEmployees().Count == 2);
        }
        [Test]
        public void Employee_Department_By_id()
        {
            // Arrange
            var result = employeeRepository.GetEmployees().Where(x=>x.Id==1).FirstOrDefault();
            //Assert 
            Assert.AreEqual("IT", result.Department);
        }
        [Test]
        public void Employee_Name_By_Id_Test()
        {
            // Arrange
            var result = employeeRepository.GetEmployees().Where(x => x.Id == 2).FirstOrDefault();
            //Assert 
            Assert.AreEqual("Ram Singh", result.Name);
        }
        [Test]
        public void Employee_Salary_By_Id_Test()
        {
            // Arrange
            var result = employeeRepository.GetEmployees().Where(x => x.Id == 3).FirstOrDefault();
            //Assert 
            Assert.AreEqual(30000, result.Salary);
        }
    }
}
