using HRM.BE;
using HRM.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Interfaces
{
    public interface IEmployeeManager
    {
        bool CreateEmployee(Employee employee);
        Employee GetEmployee(int id);
        List<Employee> AllEmployee();
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        List<DropdownVM> Departments();
        List<String> GetManagers();
    }
}
