using CS.PMA.BE.ViewModels;
using CS.PMA.Common.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CS.PMA.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET : Show register page
        [HandleError,HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // POST : Save User details
        [HandleError, HttpPost]
        public ActionResult Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                if (doRegister(user))
                {
                    TempData["message"] = "User Registered! Please login now";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Email is already exist");
                    ViewBag.EmailError = "Email is already exist";
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Failure","Validation failed");
                return View(user);
            }
        }

        // Private method called from action method to save details
        private bool doRegister(UserVM user)
        {
            try
            {
                var record = WebClient.webAPIClient.PostAsJsonAsync<UserVM>("user/register", user);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // GET : Show Login page
        [HandleError, HttpGet]
        public ActionResult Login()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            return View();
        }

        // POST : Login the user
        [HandleError,HttpPost]
        public ActionResult Login(LoginVM user)
        {
            if (ModelState.IsValid)
            {
                if (doLogin(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Dashboard", "Product");
                }
                else
                {
                    ViewBag.Invalid = "Invalid Credientials!";
                    return View();
                }
                
            }
            else
            {
                ViewBag.Invalid = "Validation error!!";
                return View();
            }
        }

        // Private Method for login
        private bool doLogin(LoginVM _user)
        {
            try
            {
                var record = WebClient.webAPIClient.PostAsJsonAsync<LoginVM>("user/login",_user);
                record.Wait();
                if (record.Result.IsSuccessStatusCode)
                {
                    UserVM user = record.Result.Content.ReadAsAsync<UserVM>().Result;
                    Session["userEmail"] = user.Email;
                    Session["userName"] = user.Name;
                    Session["userID"] = user.Id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // GET : User Logout
        [HandleError]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","User");
        }
    }
}