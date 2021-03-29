using HRM.BAL.Interfaces;
using HRM.BE;
using HRM.BE.ViewModels;
using HRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Implementation
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Method to get all employees details
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> AllEmployee()
        {
            return _employeeRepository.AllEmployee();
        }
        /// <summary>
        /// Save employees data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean</returns>
        public bool CreateEmployee(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }
        /// <summary>
        /// Delete data of an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return boolean</returns>
        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }
        /// <summary>
        /// Fetch all departments
        /// </summary>
        /// <returns>List of departments</returns>
        public List<DropdownVM> Departments()
        {
            return _employeeRepository.Departments();
        }
        /// <summary>
        /// Get single record of an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return Employee</returns>
        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }
        /// <summary>
        /// Get list of managers
        /// </summary>
        /// <returns>Return string list of managers names</returns>
        public List<string> GetManagers()
        {
            return _employeeRepository.GetManagers();
        }
        /// <summary>
        /// Update employee details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean</returns>
        public bool UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
