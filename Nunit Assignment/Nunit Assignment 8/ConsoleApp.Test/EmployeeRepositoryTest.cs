using ConsoleApp.Models;
using ConsoleApp.Repository;
using ConsoleApp.Test.CustomAttribute;
using ConsoleApp.Test.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp.Test
{
    [TestFixture]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository _employeeRepository;
        [SetUp]
        public void Setup()
        {
            //Arrange
            _employeeRepository = new EmployeeRepository();
        }

        //---------- Fluent Assertion --------------

        // Test for Exactly one record having name Saurabh Singh
        [Test]
        public void GetEmployees_Test_NameIsSaurabh()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(3)
                .And.Exactly(1).Property("Name").EqualTo("Saurabh Singh"));
        }

        // Test for Exactly one record having name Saurabh Singh and having salary 30000
        [Test]
        public void GetEmployees_Test_NameIsSaurabhAndSalaryIs30000()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(3)
                .And.Exactly(1).Property("Name").EqualTo("Saurabh Singh")
                .And.Property("Salary").EqualTo(30000));
        }

        // Testfor Exactly 3 record having name Salary 30000 and having exactly one record having city Navsari
        [Test]
        public void GetEmployees_Test_SalaryIs30000AndCityIsNavsari()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(3)
                .And.Exactly(3).Property("Salary").EqualTo(30000)
                .And.Exactly(1).Property("City").EqualTo("Navsari"));
        }

        // Testfor Exactly 3 record having name Salary 30000 and having exactly one record having city Navsari and Department IT
        [Test]
        public void GetEmployees_Test_SalaryIs30000AndCityIsNavsariAndDepartmentIsIT()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(3)
                .And.Exactly(3).Property("Salary").EqualTo(30000)
                .And.Exactly(1).Property("City").EqualTo("Navsari")
                .And.Exactly(1).Property("Department").EqualTo("IT"));
        }

        // Testfor Exactly 3 record having Salary less than 30000
        [Test]
        public void GetEmployees_Test_SalaryLessEqualTo30000()
        {
            //Act
            var result = _employeeRepository.GetEmployees();

            //Assert
            Assert.That(result, Has
                .Count.EqualTo(3)
                .And.Exactly(3).Property("Salary").LessThanOrEqualTo(30000));
        }


        //--------------- Sequencial Execution ------------

        [TestOrder(2)]
        public void Test1InputEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees();
            result.Add(new Employee { Id = 4, Name = "Ramesh", Department = "IT", City = "Navsari", Salary = 30000 });
            
            //Assert
            Assert.That(result, Has
                .Count.EqualTo(4)
                .And.Exactly(4).Property("Salary").LessThanOrEqualTo(30000));
        }
        [TestOrder(1)]
        public void Test2SelectEmployees()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees();
            
            //Assert
            Assert.That(result, Has 
                .Count.EqualTo(3));
        }
        [TestOrder(4)]
        public void Test3UpdateEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees().Where(x=>x.Id==1).FirstOrDefault();
            result.Name = "Subhu Singh";

            //Assert
            Assert.That(result, Has 
                .Property("Name").EqualTo("Subhu Singh"));
        }
        [TestOrder(3)]
        public void Test4DeleteEmployee()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees().Remove(new EmployeeRepository().GetEmployees().Where(x=>x.Id==1).FirstOrDefault());

            //Assert
            Assert.AreEqual(result, false);
        }
        [TestOrder(5)]
        public void Test5RemoveAllEmployees()
        {
            //Act
            var result = new EmployeeRepository().GetEmployees().RemoveAll(x=>x.Salary==30000);

            //Assert
            Assert.AreEqual(result, 3);
        }

        [TestCaseSource(sourceName: "TestSource")]
        public void MyTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                    .GetTypes()
                    .SelectMany(x => x.GetMethods())
                    .Where(y => y.GetCustomAttributes().OfType<TestOrderAttribute>().Any())
                    .GroupBy(z => z.GetCustomAttribute<TestOrderAttribute>().Sequence)
                    .ToDictionary(gdc => gdc.Key, gdc => gdc.ToList());

                foreach (var order in methods.Keys.OrderBy(x => x))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                            new TestStructure
                            {
                                Test = () =>
                                {
                                    object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                    info.Invoke(classInstance, null);
                                }
                            }).SetName(methodInfo.Name);
                    }
                }

            }
        }
    }
}