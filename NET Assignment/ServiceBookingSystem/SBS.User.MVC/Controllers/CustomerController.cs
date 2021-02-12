using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using SBS.BE.BussinessEntities;
using SBS.Common.WebAPI.GlobalHttpClient;
using System.Net;
using SBS.BE.ViewModels;
using System.Web.Security;

namespace SBS.User.MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Display Login page for customer
        [HandleError,HttpGet]
        public ActionResult Login()
        {
            alertBox();
            return View();
        }

        // POST: Submit details of customer of login page
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLogin model)
        {
            if (ModelState.IsValid)
            {
                if (doLogin(model))
                {
                    return RedirectToAction("Dashboard", "Customer");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Email or password does not matched!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Display Register page for customer
        [HttpGet,HandleError]
        public ActionResult Register()
        {
            ViewData["SecurityQuestions"] = fillDropdown();
            return View();
        }

        // POST: Submit details of customer of register page
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(CustomerVM model)
        {
            if (ModelState.IsValid)
            {
                if (saveCustomer(model))
                {
                    return RedirectToAction("Login", "Customer");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some error occured!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Display forgot password page
        [HttpGet,HandleError]
        public ActionResult ForgotPassword()
        {
            ViewData["SecurityQuestions"] = fillDropdown();
            return View();
        }

        // POST: Insert details of forgot password page
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(CustomerForgetPassword model)
        {
            if (ModelState.IsValid)
            {
                if (doForgotPassword(model))
                {
                    return View("ResetPassword");
                }
                else
                {
                    ViewData["SecurityQuestions"] = fillDropdown();
                    ModelState.AddModelError("Failure", "Email and security question,answer does not matched!!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        
        // GET: Display Reset Password page
        [HttpGet,HandleError]
        public ActionResult ResetPassword()
        {
            if(ViewBag.Id!=null)
                return View();
            else
                return RedirectToAction("ForgotPassword", "Customer");
        }

        // POST: Reset the password
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int id,CustomerResetPassword model)
        {
            if (ModelState.IsValid)
            {
                CustomerVM customerVM = new CustomerVM();
                customerVM.Id = id;
                customerVM.Password = model.Password;
                if (doResetPassword(customerVM))
                {
                    return RedirectToAction("Login", "Customer");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        
        // GET: Dispaly dashboard page
        [HttpGet,HandleError]
        public ActionResult Dashboard()
        {
            fillNotification();
            return View();
        }
        
        // GET: Display AddVehicle Page
        [HttpGet,HandleError]
        public ActionResult addVehicle()
        {
            return View();
        }

        // POST: Insert the vehicle details
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult addVehicle(VehicleVM vehicleVM)
        {
            if (ModelState.IsValid)
            {
                if (saveVehicle(vehicleVM))
                {
                    createNotification("green", vehicleVM.LicensePlate + " Inserted Successfully");
                    return RedirectToAction("Dashboard", "Customer");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some error occured!");
                    return View(vehicleVM);
                }
            }
            else
            {
                return View(vehicleVM);
            }
        }

        // GET: Display book appointment page
        [HttpGet,HandleError]
        public ActionResult bookAppointment()
        {
            fillAppointmentDropdown();
            return View();
        }

        // POST: Insert an appointment
        [HandleError, HttpPost, ValidateAntiForgeryToken]
        public ActionResult bookAppointment(AppointBookingVM appointBookingVM)
        {
            if (ModelState.IsValid)
            {
                if (saveAppointment(appointBookingVM))
                {
                    createNotification("blue", "Appointment booked Successfully at "+appointBookingVM.StartTime);
                    return RedirectToAction("Dashboard", "Customer");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some error occured!");
                    return RedirectToAction("bookAppointment");
                }
            }
            else
            {
                return RedirectToAction("bookAppointment");
            }
        }

        // Private method to save appointment details called from action method
        private bool saveAppointment(AppointBookingVM appointBookingVM)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<AppointBookingVM>("Customer/addAppointment", appointBookingVM);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        // Private method to save vehicle details called from action method
        private bool saveVehicle(VehicleVM vehicleVM)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<VehicleVM>("Customer/insertVehicle", vehicleVM);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        // Private method to reset password called from action method
        private bool doResetPassword(CustomerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<CustomerVM>("Customer/resetPassword", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Password changed! Please login now";
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        // Private method to foget password details called from action method
        private bool doForgotPassword(CustomerForgetPassword _customer)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<CustomerVM>("Customer/ForgotPassword",
                    new CustomerVM()
                    {
                        Question = _customer.Question,
                        Email = _customer.Email,
                        Answer =_customer.Answer
                    });
                record.Wait();
                CustomerVM user = record.Result.Content.ReadAsAsync<CustomerVM>().Result;
                if (user != null)
                {
                    ViewBag.Email = user.Email;
                    ViewBag.Id = user.Id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Load the alert message after insert,update,delete
        private void alertBox()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
        }

        // Private method to login customer called from action method
        private bool doLogin(CustomerLogin _customer)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<CustomerVM>("Customer/Login",
                    new CustomerVM()
                    {
                        Password = _customer.Password,
                        Email = _customer.Email
                    });
                record.Wait();
                CustomerVM user = record.Result.Content.ReadAsAsync<CustomerVM>().Result;
                if (user != null)
                {
                    Session["userEmail"] = user.Email;
                    Session["userName"] = user.Name;
                    Session["userID"] = user.Id;
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Private method to save customer details called from action method
        private bool saveCustomer(CustomerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync<CustomerVM>("Customer/insert", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Customer Registered! Please login now";
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        // Private method to fill dropdown called from action method
        private List<SelectListItem> fillDropdown()
        {
            List<SelectListItem> securityQuestions = new List<SelectListItem>();
            securityQuestions.Add(new SelectListItem
            {
                Text = "first pet name?",
                Value = "first pet name?"
            });
            securityQuestions.Add(new SelectListItem
            {
                Text = "first School?",
                Value = "first School?"
            });
            securityQuestions.Add(new SelectListItem
            {
                Text = "Where parent meet?",
                Value = "Where parent meet?"
            });
            return securityQuestions;
        }

        // GET: Logout the customer
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Login");
        }

        // Private method to fill alert notifications
        private void fillNotification()
        {
            // This method is used for fill the notification popup with message and color
            try
            {
                var loadMessage = TempData["message"];
                var createMessage = (createMessageNotificationModel)loadMessage;
                if (createMessage != null)
                {
                    ViewBag.Message = createMessage.message;
                    ViewBag.Color = createMessage.color;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        // Private method to create notification
        private void createNotification(string color, string message)
        {
            // This method is used for creating notifications
            createMessageNotificationModel createMessageNotificationModel = new createMessageNotificationModel();
            createMessageNotificationModel.message = message;
            createMessageNotificationModel.color = color;
            TempData["message"] = createMessageNotificationModel;
        }

        // Private method to fill dealers dropdown
        private IEnumerable<DealerDropdownModel> fillDealerDropdown()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Customer/DealerDropdown").Result;
                
                var dealer = response.Content.ReadAsAsync<IEnumerable<DealerDropdownModel>>().Result;
                return dealer;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        // Private method to fill service dropdown
        private IEnumerable<ServiceDropdownModel> fillServiceDropdown()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Customer/ServiceDropdown").Result;

                var service = response.Content.ReadAsAsync<IEnumerable<ServiceDropdownModel>>().Result;
                return service;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Private method to fill vehicke dropdown by customer id
        private IEnumerable<VehicleDropdownModel> fillVehicleDropdown(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Customer/VehicleDropdown/" + id).Result;
                return response.Content.ReadAsAsync< IEnumerable<VehicleDropdownModel>>().Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Private method to fill dropdowns in appointment creation page
        private void fillAppointmentDropdown()
        {
            try
            {
                ViewBag.DealerId = new SelectList(fillDealerDropdown(), "Id", "Name");
                ViewBag.ServiceId = new SelectList(fillServiceDropdown(), "Id", "Name");
                ViewBag.VehicleId = new SelectList(fillVehicleDropdown(Convert.ToInt32(Session["UserId"].ToString())), "Id", "Model");
            }
            catch (Exception ex)
            {

            }
            
        }


    }
}