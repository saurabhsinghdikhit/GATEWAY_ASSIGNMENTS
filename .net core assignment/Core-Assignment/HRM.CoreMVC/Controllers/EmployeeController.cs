using HRM.BE;
using HRM.BE.ViewModels;
using HRM.Common.WebClient;
using HRM.CoreMVC.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRM.CoreMVC.Controllers
{
    [AdminSessionManagement]
    public class EmployeeController : Controller
    {
        private readonly ILogger _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Showing dashboard to admin
        /// </summary>
        /// <returns></returns>
        public IActionResult Dashboard()
        {
            return View();
        }
        /// <summary>
        /// Get all employee data to display
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 1)]
        public async Task<IActionResult> All()
        {
            // notification loading machenishm
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            var employees = await GetEmployees();
            return View(employees);
        }
        /// <summary>
        /// Private method to call api for all employees
        /// </summary>
        /// <returns></returns>
        private async Task<List<Employee>> GetEmployees()
        {
            try
            {
                _logger.LogInformation("Calling GetEmployees() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer",HttpContext.Session.GetString("token"));
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Employee/List").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
                else
                {
                    _logger.LogError("Api not found");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at GetEmployees"+ ex.Message.ToString());
                return null;
            }
            
        }
        /// <summary>
        /// Private method to call api for all departments
        /// </summary>
        /// <returns></returns>
        private async Task<List<DropdownVM>> GetDepartments()
        {
            try
            {
                _logger.LogInformation("Calling GetDepartments() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Department/List").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DropdownVM>>(apiResponse);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at GetDepartments" + ex.Message.ToString());
                return null;
            }

        }
        /// <summary>
        /// Display employee creation page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            // loading department list and manager list to fill dropdown
            ViewBag.Departments = new SelectList(await GetDepartments(), "Id", "Name");
            ViewBag.Managers = await GetManagers();
            return View();
        }
        /// <summary>
        /// Saving employee details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (SaveEmployeeDetails(employee))
                {

                    TempData["message"] = employee.Name + " added successfully";
                    return RedirectToAction("All");
                }
                else
                {
                    return RedirectToAction("Create", employee);
                }
            }
            else
            {
                ModelState.AddModelError("Failure", "Validation Error");
                return RedirectToAction("Create", employee);
            }
        }
        /// <summary>
        /// Private method to call save employee api
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private bool SaveEmployeeDetails(Employee employee)
        {
            try
            {
                _logger.LogInformation("Calling SaveEmployeeDetails() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var model = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                var record = WebHttpClient.webAPIClient.PostAsync("Employee/Add", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at SaveEmployeeDetails" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Showing single employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Employee employee = await GetEmployee(id);
            return View(employee);
        }
        /// <summary>
        /// Private method to get single employee record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Employee> GetEmployee(int id)
        {
            try
            {
                _logger.LogInformation("Calling GetEmployee() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Employee/"+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at GetEmployee" + ex.Message.ToString());
                return null;
            }
        }
        /// <summary>
        /// Private method to call API to get all managers
        /// </summary>
        /// <returns></returns>
        private async Task<List<String>> GetManagers()
        {
            try
            {
                _logger.LogInformation("Calling GetManagers() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Managers/List").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<String>>(apiResponse);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at GetManagers" + ex.Message.ToString());
                return null;
            }

        }
        /// <summary>
        /// Showing edit page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await GetEmployee(id);
            ViewBag.Departments = new SelectList(await GetDepartments(), "Id", "Name");
            ViewBag.Managers = await GetManagers();
            return View(employee);
        }
        /// <summary>
        /// Updating employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (UpdateEmployee(employee))
                {

                    TempData["message"] = employee.Name + " updated successfully";
                    return RedirectToAction("All");
                }
                else
                {
                    return RedirectToAction("Edit", employee);
                }
            }
            else
            {
                ModelState.AddModelError("Failure", "Validation Error");
                return RedirectToAction("Edit", employee);
            }
        }
        /// <summary>
        /// Private method to call api to update employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private bool UpdateEmployee(Employee employee)
        {
            try
            {
                _logger.LogInformation("Calling UpdateEmployee() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var model = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                var record = WebHttpClient.webAPIClient.PutAsync("Employee/update", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at UpdateEmployee" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Delete record of employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("Calling Delete() method");
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                HttpResponseMessage deleteResponse = WebHttpClient.webAPIClient.DeleteAsync("Employee/" + id).Result;
                TempData["message"] =  "Record deleted successfully";
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at Delete" + ex.Message.ToString());
                TempData["message"] = "Some Error occured!!";
                return RedirectToAction("All");
            }
        }
    }
}
