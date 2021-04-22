using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Repository
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee{Id=1,Name="Saurabh Singh",Department="Sales",City="Navsari",Salary=30000},
                new Employee{Id=2,Name="Ram Singh",Department="IT",City="Ahmedabad",Salary=30000},
                new Employee{Id=3,Name="Raju Singh",Department="HR",City="Vapi",Salary=30000}
            };
            return employees;
        }

    }
}
