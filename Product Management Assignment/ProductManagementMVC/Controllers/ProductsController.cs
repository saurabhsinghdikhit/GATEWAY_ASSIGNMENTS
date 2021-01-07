using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductManagementMVC.GlobalClasses;
using ProductManagementWebAPI.ViewModels;
using ProductManagementWebAPI.Models;
using PagedList;
using NLog;
using System.IO;
using System.Net;

namespace ProductManagementMVC.Controllers
{
    public class ProductsController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        // GET: Products
        public ActionResult Home()
        {
            try
            {
                Logger.Trace("Loading chart for " + Session["userEmail"]);
                // This method is used for filling the chart view which is used for displaying categories.
                ProductChartViewModel CategoryList;
                HttpResponseMessage response = GlobalVariables.webAPIClient.GetAsync("GetCategory").Result;
                CategoryList = response.Content.ReadAsAsync<ProductChartViewModel>().Result;
                return View(CategoryList);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of populating chart");
                return RedirectToAction("Login", "Authentication");
            }
        }
        private void fillNotification()
        {
            // This method is used for fill the notification popup with message and color
            try
            {
                Logger.Trace("Checking notification for " + Session["userEmail"]);
                var loadMessage = TempData["message"];
                var createMessage = (createMessageNotificationModel)loadMessage;
                if (createMessage != null)
                {
                    ViewBag.Message = createMessage.message;
                    ViewBag.Color = createMessage.color;
                }
            }catch(Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of getting notification");
            }
        }
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            try
            {
                Logger.Trace("Index page is loading for " + Session["userEmail"]);
                //Check for notification
                fillNotification();
                // check for sorting order    
                ViewBag.CurrentSort = sortOrder;
                ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "product_desc" : "";
                ViewBag.CategoryNameSortParm = sortOrder == "Category" ? "category_desc" : "Category";
                //check for search string 
                if (searchString != null)
                    page = 1;
                else
                    searchString = currentFilter;
                ViewBag.CurrentFilter = searchString;
                HttpResponseMessage response = GlobalVariables.webAPIClient.GetAsync("Products").Result;
                var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                // custom search
                if (!String.IsNullOrEmpty(custom))
                {
                    if (custom == "nocustom")
                        products = products.Where(p => p.Name.Contains(searchString) || p.Category.Contains(searchString));
                    else if (custom == "name")
                        products = products.Where(p => p.Name.Contains(searchString));
                    else if (custom == "category")
                        products = products.Where(p => p.Category.Contains(searchString));
                    else if (custom == "Sdescription")
                        products = products.Where(p => p.ShortDescription.Contains(searchString));
                    else if (custom == "Ldescription")
                        products = products.Where(p => p.LongDescription.Contains(searchString));
                }
                // re-ordering the data
                switch (sortOrder)
                {
                    case "product_desc":
                        products = products.OrderByDescending(p => p.Name);
                        break;
                    case "Category":
                        products = products.OrderBy(p => p.Category);
                        break;
                    case "category_desc":
                        products = products.OrderByDescending(p => p.Category);
                        break;
                    default:  // Product Name ascending 
                        products = products.OrderBy(p => p.Name);
                        break;
                }
                return View(products.ToList().ToPagedList(page ?? 1, 8));
            }catch(Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of displaying index page");
                return RedirectToAction("Login", "Authentication");
            }
        }

        // GET: Products/Details/5
        [HandleError]
        private Product getProduct(int id)
        {
            Logger.Trace("getting product for id " + id);
            try
            {
                HttpResponseMessage response = GlobalVariables.webAPIClient.GetAsync("Products/" + id).Result;
                return response.Content.ReadAsAsync<Product>().Result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of getting product of id "+id);
                return null;
            }
           
        }
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of getting details of product id " + id);
                return RedirectToAction("Login", "Authentication");
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult SaveProductDetails(HttpPostedFileBase SmallImageUrl, HttpPostedFileBase LargeImageUrl, Product productDetails)
        {
            Logger.Trace("Saving the product details");
            // Check if all the validations are performed or not
            if (ModelState.IsValid)
            {
                // Creating a path for image upload
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    //Creating directory if not existed
                    Directory.CreateDirectory(path);
                }
                // Checking if image is not null
                try
                {
                    if (SmallImageUrl != null)
                    {
                        Product product = new Product();
                        string dateTime = DateTime.Now.ToString().Replace(@"-", "").Replace(@":", "").Trim();
                        string smallfileName = "small" + dateTime + ".jpg";
                        SmallImageUrl.SaveAs(path + smallfileName);
                        Logger.Trace("Small Image saved");
                        if (LargeImageUrl != null)
                        {
                            string largefileName = "large" + dateTime + ".jpg";
                            LargeImageUrl.SaveAs(path + largefileName);
                            Logger.Trace("large Image saved");
                            product.LargeImageUrl = largefileName;
                        }
                        else
                            product.LargeImageUrl = null;
                        product.Name = productDetails.Name;
                        product.Category = productDetails.Category;
                        product.Price = productDetails.Price;
                        product.Quantity = productDetails.Quantity;
                        product.ShortDescription = productDetails.ShortDescription;
                        product.LongDescription = productDetails.LongDescription;
                        product.CreatedBy = Convert.ToInt32(Session["userID"].ToString());
                        product.CreatedAt = DateTime.Now;
                        product.ModifiedAt = null;
                        product.ModifiedBy = null;
                        product.SmallImageUrl = smallfileName;
                        HttpResponseMessage response = GlobalVariables.webAPIClient.PostAsJsonAsync("Products", product).Result;
                        Logger.Trace("Data inserted into database");
                        createNotification("green", productDetails.Name + " Inserted Successfully");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error occured at the time of inserting product");
                }
                return RedirectToAction("Index", "Products");
            }
            else
            {
                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("Create", productDetails);
            }
        }
        
        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of getting edit details of product id " + id);
                return RedirectToAction("Login", "Authentication");
            }
        }

        [HandleError]
        public ActionResult EditProductDetails(HttpPostedFileBase SmallImageUrl, HttpPostedFileBase LargeImageUrl, Product productDetails)
        {
            // Check if all the validations are performed or not
            if (ModelState.IsValid)
            {
                // Creating a path for image upload
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    //Creating directory if not existed
                    Directory.CreateDirectory(path);
                }
                // Checking if image is not null
                try
                {
                    if (SmallImageUrl != null)
                    {
                        Product record = getProduct(productDetails.Id);
                        if (record != null)
                        {
                            // Save image file
                            string dateTime = DateTime.Now.ToString().Replace(@"-", "").Replace(@":", "").Trim();
                            string smallfileName = "small" + dateTime + ".jpg";
                            SmallImageUrl.SaveAs(path + smallfileName);
                            Logger.Trace("Small Image saved");
                            if (LargeImageUrl != null)
                            {
                                string largefileName = "large" + dateTime + ".jpg";
                                LargeImageUrl.SaveAs(path + largefileName);
                                record.LargeImageUrl = largefileName;
                                Logger.Trace("large Image saved");
                            }
                            else
                            {
                                record.LargeImageUrl = null;
                            }
                            // Save data   
                            record.Name = productDetails.Name;
                            record.Category = productDetails.Category;
                            record.Price = productDetails.Price;
                            record.Quantity = productDetails.Quantity;
                            record.ShortDescription = productDetails.ShortDescription;
                            record.LongDescription = productDetails.LongDescription;
                            record.ModifiedAt = DateTime.Now;
                            record.ModifiedBy = Convert.ToInt32(Session["userID"].ToString());
                            record.SmallImageUrl = smallfileName;
                            //Calling the SaveDetails method which saves the details.
                            HttpResponseMessage updateResponse = GlobalVariables.webAPIClient.PutAsJsonAsync("Products/"+record.Id, record).Result;
                            Logger.Trace("Data updated into database");
                            createNotification("blue", productDetails.Name + " updated successfully");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error occured at the time of product insertion");
                }
                return RedirectToAction("Index", "Products");
            }
            else
            {
                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                Product product = getProduct(productDetails.Id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View("Edit", product);
            }
        }


        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Product product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of getting delete details of product id " + id);
                return RedirectToAction("Login", "Authentication");
            }
        }

        // POST: Products/Delete/5
        [HandleError]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Product product=getProduct(id);
                if (product != null)
                {
                    HttpResponseMessage deleteResponse = GlobalVariables.webAPIClient.DeleteAsync("Products/" + id).Result;
                    createNotification("red", product.Name + " deleted successfully");
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
                
            }
            catch
            {
                return View();
            }
        }

        [HandleError]
        public ActionResult DeleteMultipleProducts(FormCollection formCollection)
        {
            try
            {
                foreach (var item in formCollection["deleteCheckBox"].ToString().Split(','))
                {
                    HttpResponseMessage deleteResponse = GlobalVariables.webAPIClient.DeleteAsync("Products/" + Convert.ToInt32(item)).Result;
                    Logger.Trace("product deleted for id "+ Convert.ToInt32(item));
                }
                createNotification("red", "multiple products deleted successfully");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured at the time of deleting of multiple products");
                return RedirectToAction("Login", "Authentication");
            }
        }
        [HandleError]
        private void createNotification(string color,string message)
        {
            // This method is used for creating notifications
            createMessageNotificationModel createMessageNotificationModel = new createMessageNotificationModel();
            createMessageNotificationModel.message = message;
            createMessageNotificationModel.color = color;
            TempData["message"] = createMessageNotificationModel;
        }
    }
}
