using HRM.BE;
using HRM.BE.ViewModels;
using HRM.DAL.DatabaseContext;
using HRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace HRM.DAL.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        /// <summary>
        /// Method to get all employees details
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> AllEmployee()
        {
            try
            {
                var employees = _employeeContext.Employees.Include(x => x.Department).ToList(); 
                foreach (Employee employee in employees)
                {
                    employee.Department.Employees = null;
                }
                return employees;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Save employees data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean</returns>
        public bool CreateEmployee(Employee employee)
        {
            try
            {
                if (employee.IsManager)
                    employee.Manager = null;
                _employeeContext.Add(employee);
                _employeeContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Delete data of an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return boolean</returns>
        public bool DeleteEmployee(int id)
        {
            try
            {
                _employeeContext.Employees.Remove(_employeeContext.Employees.Find(id));
                _employeeContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// Fetch all departments
        /// </summary>
        /// <returns>List of departments</returns>
        public List<DropdownVM> Departments()
        {
            try
            {
                List<DropdownVM> departments = new List<DropdownVM>();
                foreach (var item in _employeeContext.Departments.ToList())
                {
                    departments.Add(new DropdownVM { Id = item.Id, Name = item.Name });
                }
                return departments;
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// Get single record of an employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return Employee</returns>
        public Employee GetEmployee(int id)
        {
            try
            {
               var employee= _employeeContext.Employees.Include("Department").Where(x=>x.Id==id).FirstOrDefault();
                employee.Department.Employees = null;
                return employee;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Get list of managers
        /// </summary>
        /// <returns>Return string list of managers names</returns>
        public List<string> GetManagers()
        {
            var managers = _employeeContext.Employees.Where(x => x.IsManager == true).Select(x => x.Name).ToList();
            return managers;
        }
        /// <summary>
        /// Update employee details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean</returns>
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee.IsManager)
                    employee.Manager = null;
                _employeeContext.Employees.Add(employee);
                _employeeContext.Entry(employee).State = EntityState.Modified;
                _employeeContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }
    }
}
