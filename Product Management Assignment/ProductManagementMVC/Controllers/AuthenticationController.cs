using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductManagementWebAPI.Models;
using NLog;
using ProductManagementMVC.ViewModels;
using System.Web.Security;
using ProductManagementMVC.GlobalClasses;
namespace ProductManagementMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        // GET: Authentication
        [HandleError]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [HandleError]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var record = GlobalVariables.webAPIClient.PostAsJsonAsync<User>("UserRegistration", _user);
                    record.Wait();
                    var saveRecord = record.Result;
                    if (saveRecord.IsSuccessStatusCode)
                    {
                        Logger.Trace("Data inserted into database");
                        TempData["message"] = "User Registered! Please login now";
                        return RedirectToAction("Login", "Authentication");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error occured at the time of registering user");
                }
                ModelState.AddModelError("Failure", "Email is already exist");
                return View("Register");
            }
            else
            {
                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("Register", _user);
            }
        }

        [HandleError]
        public ActionResult Login()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Login(LoginViewModel _user)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    var record = GlobalVariables.webAPIClient.PostAsJsonAsync<User>("UserLogin",
                        new User() { 
                            Password = _user.Password,
                            Email = _user.Email  
                        });
                    record.Wait();
                    User user = record.Result.Content.ReadAsAsync<User>().Result;
                    if (user != null)
                    {
                        Logger.Trace("User have entered right credientials");
                        Session["userEmail"] = user.Email;
                        Session["userName"] = user.Name;
                        Session["userID"] = user.Id;
                        Logger.Trace("User found in the database of " + Session["userEmail"]);
                        FormsAuthentication.SetAuthCookie(user.Email, false);
                        Logger.Trace("Redirecting to index page");
                        return RedirectToAction("Home", "Products");
                    }
                    else
                    {
                        Logger.Trace("User have entered wrong credientials");
                        ModelState.AddModelError("Failure", "Invalid Credientials");
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error occured at the time of Login user");
                }
                
                return View();
            }
            else
            {
                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("Login", _user);
            }
        }
        [HandleError]
        public ActionResult Logout()
        {
            Logger.Trace("User have logged out " + Session["userEmail"]);
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login");
        }

    }
}