using HRM.BE.BussinessEntities;
using HRM.BE.ViewModels;
using HRM.Common.WebClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HRM.CoreMVC.Controllers
{
    public class Authentication : Controller
    {
        private readonly ILogger _logger;
        public Authentication(ILogger<Authentication> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get method to display login page
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("user") != null) {
                TempData["message"] = "You are already logged in";
                return RedirectToAction("All", "Employee");
            }
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            return View();
        }
        /// <summary>
        /// Post method to get employee data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM model)
        {
            if (ModelState.IsValid)
            {
                if(await DoAdminLogin(new Admin { Email = model.Email, Password = model.Password }))
                {
                    return RedirectToAction("Dashboard", "Employee");
                }
                else
                {
                    TempData["message"] = "Invalid Credientials";
                    return RedirectToAction("Login");
                }     
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        /// <summary>
        /// Private method to send post request to api to save employee data
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        private async Task<bool> DoAdminLogin(Admin admin)
        {
            try
            {
                _logger.LogInformation("Calling DoAdminLogin() method");
                var model = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                var record = WebHttpClient.webAPIClient.PostAsync("Authentication", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    string apiResponse = await saveRecord.Content.ReadAsStringAsync();
                    admin=JsonConvert.DeserializeObject<Admin>(apiResponse);
                    HttpContext.Session.SetString("token", admin.Token);
                    HttpContext.Session.SetString("user", admin.Email);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Got error at DoAdminLogin" + ex.Message.ToString());
                return false;
            }
        }
        /// <summary>
        /// Logout action
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = "No user found to logout";
                return RedirectToAction("Login");
            }
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("token");
            return RedirectToAction("Login");
        }
    }
}
