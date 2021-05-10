using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Repository
{
    public class EmployeeRepository
    {
        List<Employee> employees = new List<Employee>()
        {
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
        };
        public virtual List<Employee> GetEmployees()
        {
            return employees;
        }
        public virtual Employee GetEmployee(int id)
        {
            return employees.Where(x=>x.Id==id).FirstOrDefault();
        }
    }
}
