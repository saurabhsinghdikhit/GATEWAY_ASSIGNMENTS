using HRM.BAL.Interfaces;
using HRM.BE;
using HRM.BE.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HRM.API.Controllers
{
    /// <summary>
    /// Using JWT authorization
    /// </summary>
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        /// <summary>
        /// Fetch employee list
        /// </summary>
        /// <returns>Return list of employees</returns>
        [HttpGet, Route("Employee/List")]
        public IList<Employee> Index()
        {
            return _employeeManager.AllEmployee();
        }
        /// <summary>
        /// Fetch Departments
        /// </summary>
        /// <returns>Return list of departments for dropdown</returns>
        [HttpGet, Route("Department/List")]
        public IList<DropdownVM> Departments()
        {
            return _employeeManager.Departments();
        }
        /// <summary>
        /// Fetch Manager
        /// </summary>
        /// <returns>Return list of managers for dropdown</returns>
        [HttpGet, Route("Managers/List")]
        public IList<String> GetManagers()
        {
            return _employeeManager.GetManagers();
        }
        /// <summary>
        /// Fetch single employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return employee details</returns>
        [HttpGet, Route("Employee/{id}")]
        public Employee Employee(int id)
        {
            return _employeeManager.GetEmployee(id);
        }
        /// <summary>
        /// Save data of an employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean value</returns>
        [HttpPost, Route("Employee/Add")]
        public bool Insert([FromBody]Employee employee)
        {
            return _employeeManager.CreateEmployee(employee);
        }
        /// <summary>
        /// Update employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return boolean value</returns>
        [HttpPut, Route("Employee/update")]
        public bool Update([FromBody] Employee employee)
        {
            return _employeeManager.UpdateEmployee(employee);
        }
        /// <summary>
        /// Remove employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return boolean value</returns>
        [HttpDelete, Route("Employee/{id}")]
        public bool Remove(int id)
        {
            return _employeeManager.DeleteEmployee(id);
        }
    }
}
