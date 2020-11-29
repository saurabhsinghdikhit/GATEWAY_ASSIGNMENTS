using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;
namespace SourceControlAssignment1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult employeeDetails(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.status = "Employee Registration Successfull";
                return View("Registration");
            }
            else
            {
                ViewBag.status = "Failed!! Some validation voilated";
                return View("Registration");
            }
        }
    }
}