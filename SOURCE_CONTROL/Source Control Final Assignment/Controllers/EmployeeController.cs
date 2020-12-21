using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoginRegistrationInMVCWithDatabase.ViewModel;
using Source_Control_Final_Assignment.Models;
using Source_Control_Final_Assignment.ViewModel;
using NLog;

namespace Source_Control_Final_Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        // Return Home page.
        [HandleError]
        public ActionResult Index()
        {
            try
            {
                if (Session["userEmail"] != null)
                {
                    using (var databaseContext = new SourceControlFinalAssignmentDatabaseEntities())
                    {
                        Logger.Trace("Getting data of "+ Session["userEmail"]);
                        string email = Session["userEmail"].ToString();
                        Employee user = databaseContext.Employees.Where(query => query.Email.Equals(email)).SingleOrDefault();
                        Logger.Trace("Data got fetched of " + Session["userEmail"]);
                        return View(user);
                    }
                }
            }catch(Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of displaying data");
                return View("Error");
            }
            
            return View();
        }

        //Return Register view
        [HandleError]
        public ActionResult Register()
        {
            return View();
        }

        [HandleError]
        [HttpPost]
        public ActionResult SaveRegisterDetails(HttpPostedFileBase employeeImage, Employee registerDetails)
        {
            // Check if all the validations are performed or not
            if (ModelState.IsValid)
            {
                // Creating a path for image upload
                string path = Server.MapPath("~/Uploads/");
                //Checking if path exist or not
                if (!Directory.Exists(path))
                {
                    //Creating directory if not existed
                    Directory.CreateDirectory(path);
                }
                // Checking if image is not null
                try
                {
                    if (employeeImage != null)
                    {

                        using (var databaseContext = new SourceControlFinalAssignmentDatabaseEntities())
                        {
                            // Checking if entered email is not already there in the table
                            Employee user = databaseContext.Employees.Where(query => query.Email.Equals(registerDetails.Email)).SingleOrDefault();
                            Logger.Trace("Checking for email " + registerDetails.Email);
                            if (user == null)
                            {
                                Logger.Trace("Email not found in the database going to make new entry");
                                // Save image file if email is new
                                string fileName = Path.GetFileName(employeeImage.FileName);
                                employeeImage.SaveAs(path + fileName);
                                Logger.Trace("Image saved");
                                // Save data if email is new
                                Employee reglog = new Employee();
                                reglog.FirstName = registerDetails.FirstName;
                                reglog.LastName = registerDetails.LastName;
                                reglog.Email = registerDetails.Email;
                                reglog.Password = registerDetails.Password;
                                reglog.Mobile = registerDetails.Mobile;
                                reglog.Salary = registerDetails.Salary;
                                reglog.empDoj = registerDetails.empDoj;
                                reglog.employeeImage = employeeImage.FileName;
                                //Calling the SaveDetails method which saves the details.
                                databaseContext.Employees.Add(reglog);
                                databaseContext.SaveChanges();
                                Logger.Trace("Data inserted into database");
                                ViewBag.Message = "Employee Registered! Please login now";
                            }
                            else
                            {
                                Logger.Trace("Email found in the database showing warning!!");
                                // Displaying the message if email is already there
                                ViewBag.EmailError = "Email is already registered";
                            }


                        }
                    }
                }catch(Exception ex)
                {
                    Logger.Error(ex, "Error occured at the time of registering user");
                }
                return View("Register");

            }
            else
            {
                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("Register", registerDetails);
            }
        }

        [HandleError]
        public ActionResult Login()
        {
            return View();
        }

        //The login form is posted to this method.
        [HttpPost]
        [HandleError]
        public ActionResult Login(LoginViewModel model)
        {
            Logger.Trace("User is trying to login");
            //Checking the state of model passed as parameter.
            if (ModelState.IsValid)
            {
                Logger.Trace("Validation performed");
                //Validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(model);

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isValidUser != null)
                {
                    Logger.Trace("User have entered right credientials");
                    Session["userEmail"] = model.Email;
                    Logger.Trace("User found in the database of " + Session["userEmail"]);
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    Logger.Trace("Redirecting to index page");
                    return RedirectToAction("Index");
                }
                else
                {
                    Logger.Trace("User have entered wrong credientials");
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }

        //function to check if User is valid or not
        [HandleError]
        public Employee IsValidUser(LoginViewModel model)
        {
            Logger.Trace("Checking user credientials");
            using (var dataContext = new SourceControlFinalAssignmentDatabaseEntities())
            {
                //Retireving the user details from DB based on username and password enetered by user.
                Employee user = dataContext.Employees.Where(query => query.Email.Equals(model.Email) && query.Password.Equals(model.Password)).SingleOrDefault();
                //If user is present, then true is returned.
                if (user == null)
                    return null;
                //If user is not present false is returned.
                else
                    return user;
            }
        }

        [HandleError]
        public ActionResult Logout()
        {
            Logger.Trace("User have logged out "+ Session["userEmail"]);
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index");
        }
    }
}