using ClosedXML.Excel;
using SBS.BE.BussinessEntities;
using SBS.BE.ViewModels;
using SBS.Common.WebAPI.GlobalHttpClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SBS.Admin.MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Display Dashboard page
        [HandleError,HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }

        // GET: Display Dealer page
        [HandleError, HttpGet]
        public ActionResult Dealer()
        {
            return View();
        }

        // GET: Display Customer page
        [HandleError, HttpGet]
        public ActionResult Customer()
        {
            return View();
        }

        // GET: Display Service page
        [HandleError, HttpGet]
        public ActionResult Service()
        {
            return View();
        }

        // GET: Display Mechanic page
        [HandleError, HttpGet]
        public ActionResult Mechanic()
        {
            return View();
        }

        // GET: Display Appointment page with filling all the appointment
        [HandleError, HttpGet]
        public ActionResult Appointments()
        {
            return View(fillAppointments());
        }

        // GET: Display all booked appointment order by date ascending
        public ActionResult Report()
        {
            return View(fillApprovedAppointments());
        }

        // GET: Display Edit appointment page with id 
        [Route("Admin/EditAppointment/{id}")]
        public ActionResult EditAppointment(int id)
        {
            return View(getAppointment(id));
        }

        // GET: Display approve appointment page with id
        [HttpGet,Route("Admin/Approve/{id}")]
        public ActionResult Approve(int id)
        {
            return View("ApproveAppointment",getAppointment(id));
        }

        // POST: Approve appointment of customer
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Approve(AppointBookingVM model,int searchmechanicId)
        {
            try
            {
                model.MechanicId = searchmechanicId;
                model.Status=true;
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/ApproveAppointment", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return RedirectToAction("Appointments");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Appointments");
            }
            return RedirectToAction("Appointments");
        }

        // GET: Get json record of 1st mechanic matched with brand name
        [HttpGet,Route("Admin/getMechanicFromBrand")]
        public JsonResult getMechanicFromBrand()
        {
            try
            {
                var search=Request.QueryString["search"];
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/getMechanicFromBrand/" + search).Result;
                var result = response.Content.ReadAsAsync<MechanicVM>().Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // Private Method for get appointment action method
        private AppointBookingVM getAppointment(int Id)
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/getAppointment/" + Id).Result;
                return response.Content.ReadAsAsync<AppointBookingVM>().Result;
            }
            catch (Exception ex) {
                return null;
            }
        }

        // GET: Get json record of vehicle brand name by vehicle id
        [Route("Admin/getVehicleBrandMake/{id}")]
        public JsonResult getVehicleBrandMake(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/getVehicleBrandMake/" + id).Result;
                var result = response.Content.ReadAsAsync<string>().Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Update an appointment
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult EditAppointment(AppointBookingVM model)
        {
            if (ModelState.IsValid)
            {
                if (updateAppointment(model))
                {
                    return RedirectToAction("Appointments", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some error occured!");
                    return RedirectToAction("Appointments");
                }
            }
            else
            {
                return RedirectToAction("Appointments");
            }
        }

        // GET: Display appointment page with filled dropdown
        [HandleError, HttpGet]
        public ActionResult CreateAppointment()
        {
            ViewBag.CreatedBy= new SelectList(fillCustomersDropdown(), "Id", "Name");
            ViewBag.DealerId = new SelectList(fillDealerDropdown(), "Id", "Name");
            ViewBag.ServiceId = new SelectList(fillServiceDropdown(), "Id", "Name");
            return View();
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

        // Private method to fill Dealer dropdown
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

        // Private method to fill Customer dropdown
        private IEnumerable<CustomerDropdownModel> fillCustomersDropdown()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetDropdownCustomers").Result;
                return response.Content.ReadAsAsync<IEnumerable<CustomerDropdownModel>>().Result;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Get Json result vehicle by id to fill vehicle dropdown
        [Route("Admin/VehicleDropdown/{id}")]
        public JsonResult VehicleDropdown(int id)
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/VehicleDropdown/" + id).Result;
                var result= response.Content.ReadAsAsync<IEnumerable<VehicleDropdownModel>>().Result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Insert an appointment by admin
        [HandleError, HttpPost,ValidateAntiForgeryToken]
        public ActionResult CreateAppointment(AppointBookingVM model)
        {
            if (ModelState.IsValid)
            {
                if (saveAppointment(model))
                {
                    return RedirectToAction("Appointments", "Admin");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some error occured!");
                    return RedirectToAction("CreateAppointment");
                }
            }
            else
            {
                return RedirectToAction("CreateAppointment");
            }
        }

        // GET: Get all appointments to display
        private IEnumerable<AppointBookingVM> fillAppointments()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetAppointments").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<AppointBookingVM>>().Result;
                return service;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Get all approved appointments to display
        private IEnumerable<AppointBookingVM> fillApprovedAppointments()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetApprovedAppointments").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<AppointBookingVM>>().Result;
                return service;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: Get json result of dealers to sort,paging searching for JQGRID
        public JsonResult getDealers(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = FillDealerGrid();
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
 
        }

        // Private method to fill dealer details on dealers page
        private IEnumerable<DealerVM> FillDealerGrid()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetDealer").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<DealerVM>>().Result;
                return service;
                 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Insert a dealer
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] DealerVM dealerVM)
        {
            string msg="";
            try
            {
                if (ModelState.IsValid)
                {
                    if (saveDealer(dealerVM))
                    {
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Edit a dealer
        public string Edit(DealerVM dealerVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateDealer(dealerVM))
                    {
                        msg = "Updated Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // GET: Delete a dealer
        public string Delete(int Id)
        {
            deleteDealer(Id);
            return "Deleted successfully";
        }

        // Private method to insert dealer called from create action method
        private bool saveDealer(DealerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/insert", model);
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

        // Private method to update dealer called from Edit action method
        private bool updateDealer(DealerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/updateDealer", model);
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

        // Private method to delete dealer called from Delete action method
        private bool deleteDealer(int Id)
        {
            try
            {
                HttpResponseMessage deleteResponse = GlobalHttpClient.webAPIClient.DeleteAsync("Admin/deleteDealer/" + Id).Result;
                
                if (deleteResponse.IsSuccessStatusCode)
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

        // GET: Get json result of customers to sort,paging searching for JQGRID
        public JsonResult getCustomers(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = FillCustomerGrid();
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        
        // private method to Get customers details to fill customer page
        private IEnumerable<CustomerVM> FillCustomerGrid()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetCustomers").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<CustomerVM>>().Result;
                return service;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Insert a customer from admin side
        [HttpPost]
        public string CreateCustomer([Bind(Exclude = "Id")] CustomerVM customerVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (saveCustomer(customerVM))
                    {
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Edit a customer from admin side
        public string EditCustomer(CustomerVM customerVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateCustomer(customerVM))
                    {
                        msg = "Updated Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Delete a customer from admin side
        public string DeleteCustomer(int Id)
        {
            deleteCustomer(Id);
            return "Deleted successfully";
        }

        // Private method called to save customer details from createCustomer action method
        private bool saveCustomer(CustomerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/insertCustomer", model);
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

        // Private method called to update customer details from EditCustomer action method
        private bool updateCustomer(CustomerVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/updateCustomer", model);
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

        // Private method called to delete customer details from DeleteCustomer action method
        private bool deleteCustomer(int Id)
        {
            try
            {
                HttpResponseMessage deleteResponse = GlobalHttpClient.webAPIClient.DeleteAsync("Admin/deleteCustomer/" + Id).Result;

                if (deleteResponse.IsSuccessStatusCode)
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

        // GET: Get json result of Mechanics to sort,paging searching for JQGRID
        public JsonResult getMechanics(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = FillMechanicGrid();
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        // GET: Get Mechanics records
        private IEnumerable<MechanicVM> FillMechanicGrid()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/GetMechanics").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<MechanicVM>>().Result;
                return service;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Insert a mechanic
        [HttpPost]
        public string CreateMechanic([Bind(Exclude = "Id")] MechanicVM mechanicVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (saveMechanic(mechanicVM))
                    {
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Edit a mechanic
        public string EditMechanic(MechanicVM mechanicVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateMechanic(mechanicVM))
                    {
                        msg = "Updated Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Delete a mechanic
        public string DeleteMechanic(int Id)
        {
            deleteMechanic(Id);
            return "Deleted successfully";
        }

        // Private method called to save mechanic details from CreateMechanic action method
        private bool saveMechanic(MechanicVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/insertMechanic", model);
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

        // Private method called to update mechanic details from EditMechanic action method
        private bool updateMechanic(MechanicVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/updateMechanic", model);
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

        // Private method called to delete mechanic details from DeleteMechanic action method
        private bool deleteMechanic(int Id)
        {
            try
            {
                HttpResponseMessage deleteResponse = GlobalHttpClient.webAPIClient.DeleteAsync("Admin/deleteMechanic/" + Id).Result;

                if (deleteResponse.IsSuccessStatusCode)
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

        // GET: Get json result of Services to sort,paging searching for JQGRID
        public JsonResult getServices(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = FillServiceGrid();
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }

        // GET: Get all services
        private IEnumerable<ServiceVM> FillServiceGrid()
        {
            try
            {
                HttpResponseMessage response = GlobalHttpClient.webAPIClient.GetAsync("Admin/Services").Result;
                var service = response.Content.ReadAsAsync<IEnumerable<ServiceVM>>().Result;
                return service;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST: Insert a service
        [HttpPost]
        public string CreateService([Bind(Exclude = "Id")] ServiceVM serviceVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (saveService(serviceVM))
                    {
                        msg = "Saved Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Edit a service
        public string EditService(ServiceVM serviceVM)
        {
            string msg = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (updateService(serviceVM))
                    {
                        msg = "Updated Successfully";
                    }
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }

        // POST: Delete a service
        public string DeleteService(int Id)
        {
            deleteService(Id);
            return "Deleted successfully";
        }

        // Private method called to save services details from CreateService action method
        private bool saveService(ServiceVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/insertService", model);
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

        // Private method called to update services details from UpdateService action method
        private bool updateService(ServiceVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/updateService", model);
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

        // Private method called to delete services details from DeleteService action method
        private bool deleteService(int Id)
        {
            try
            {
                HttpResponseMessage deleteResponse = GlobalHttpClient.webAPIClient.DeleteAsync("Admin/deleteService/" + Id).Result;

                if (deleteResponse.IsSuccessStatusCode)
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

        // Private method to save appointment details from admin side
        private bool saveAppointment(AppointBookingVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/insertAppointment", model);
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

        // Private method to update appointment details from admin side
        private bool updateAppointment(AppointBookingVM model)
        {
            try
            {
                var record = GlobalHttpClient.webAPIClient.PostAsJsonAsync("Admin/updateAppointment", model);
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

        // POST: Return booked appointment excel file from data order by start date
        [HttpPost]
        public FileResult ExportToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[10] 
            { new DataColumn("ID"),
            new DataColumn("StartDate"),
            new DataColumn("EndDate"),
            new DataColumn("VehicleId"),
            new DataColumn("DealerId"),
            new DataColumn("MechanicId"),
            new DataColumn("ServiceId"),
            new DataColumn("CreatedBy"),
            new DataColumn("UpdatedBy"),
            new DataColumn("Status"),
            });

            var appointBookings = fillApprovedAppointments();

            foreach (var booking in appointBookings)
            {
                dt.Rows.Add(booking.Id, booking.StartTime, booking.EndTime, booking.VehicleId,
                    booking.DealerId, booking.MechanicId, booking.ServiceId, booking.CreatedBy,
                    booking.UpdatedBy,booking.Status);
            }

            using (XLWorkbook wb = new XLWorkbook()) 
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())  
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BookedAppointments.xlsx");
                }
            }
        }
    }
}