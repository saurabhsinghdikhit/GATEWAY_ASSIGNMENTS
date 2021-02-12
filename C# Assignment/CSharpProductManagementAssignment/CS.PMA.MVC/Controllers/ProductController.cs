using CS.PMA.BE.ViewModels;
using CS.PMA.Common.WebClient;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CS.PMA.MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET : Show Dashboard page with graphs
        public ActionResult Dashboard()
        {
            return View(GetChart());
        }

        // GET : Show Create Product page
        public ActionResult Create()
        {
            return View();
        }

        // GET : Show Edit page
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductVM product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {
                
                return RedirectToAction("Login", "User");
            }
        }

        // POST : Post the product data for insertion
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase SmallImageUrl, HttpPostedFileBase LargeImageUrl, ProductVM productDetails)
        {
            if (ModelState.IsValid)
            {
                if(EditProduct(SaveImages(SmallImageUrl, LargeImageUrl), productDetails))
                {
                    createNotification("blue", productDetails.Name + " updated Successfully");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some problem occured");
                    var product = getProduct(productDetails.Id);
                    return View(product);
                }

            }
            else
            {
                ModelState.AddModelError("Failure", "Validation Error!!");
                var product=getProduct(productDetails.Id);
                return View(product);
            }
        }

        // GET : Show Delete page
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductVM product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "User");
            }
        }

        // POST : Delete the product
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int? id,FormCollection formCollection)
        {
            try
            {
                if (id != null)
                {
                    HttpResponseMessage deleteResponse = Common.WebClient.WebClient.webAPIClient.DeleteAsync("products/delete/" + id).Result;
                    createNotification("red", "Product deleted successfully");
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

        // GET : Delete multiple products
        public ActionResult DeleteMultipleProducts(FormCollection formCollection)
        {
            var ids = formCollection["deleteCheckBox"].ToString().Split(',');
            try
            {
                HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.PostAsJsonAsync("product/deleteMultiple", ids).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }

        // GET : Show Detail page
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProductVM product = getProduct(id ?? 1);
                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product);
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "User");
            }
        }

        // Private method to edit the product details
        private bool EditProduct(List<string> files, ProductVM productDetails)
        {
            if (files.Count == 2)
            {
                productDetails.SmallImageUrl = files.ElementAt(0);
                productDetails.LargeImageUrl = files.ElementAt(1);
            }
            else if (files.Count == 1)
            {
                productDetails.SmallImageUrl = files.ElementAt(0);
                productDetails.LargeImageUrl = null;
            }
            productDetails.ModifiedBy = Convert.ToInt32(Session["userID"].ToString());
            productDetails.ModifiedAt = DateTime.Now;
            HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.PostAsJsonAsync("products/update", productDetails).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // get single product details
        private ProductVM getProduct(int id)
        {
            try
            {
                HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.GetAsync("products/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ProductVM>().Result;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception)
            {
                return null;
            }
        }


        // POST : Create a product
        [HttpPost,HandleError,ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase SmallImageUrl, HttpPostedFileBase LargeImageUrl, ProductVM productDetails)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = SaveDetails(SaveImages(SmallImageUrl, LargeImageUrl),productDetails);
                if (isSaved)
                {
                    createNotification("green", productDetails.Name + " Inserted Successfully");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Some problem occured");
                    return View(productDetails);
                } 
            }
            else
            {
                ModelState.AddModelError("Failure", "Validation error");
                return View(productDetails);
            }
        }
        
        // Private method to insert product details
        private bool SaveDetails(List<string> files, ProductVM productDetails)
        {
            if (files.Count == 2)
            {
                productDetails.SmallImageUrl = files.ElementAt(0);
                productDetails.LargeImageUrl = files.ElementAt(1);
            }
            else if (files.Count == 1)
            {
                productDetails.SmallImageUrl = files.ElementAt(0);
                productDetails.LargeImageUrl = null;
            }
            productDetails.CreatedBy = Convert.ToInt32(Session["userID"].ToString());
            productDetails.CreatedAt = DateTime.Now;
            HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.PostAsJsonAsync("product/save", productDetails).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Private method to save images
        private List<string> SaveImages(HttpPostedFileBase SmallImageUrl, HttpPostedFileBase LargeImageUrl)
        {
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string dateTime = DateTime.Now.ToString().Replace(@"-", "").Replace(@":", "").Trim();
            string smallfileName = "small" + dateTime + ".jpg";
            SmallImageUrl.SaveAs(path + smallfileName);
            List<string> files = new List<string>();
            files.Add(smallfileName);
            if (LargeImageUrl != null)
            {
                string largefileName = "large" + dateTime + ".jpg";
                LargeImageUrl.SaveAs(path + largefileName);
                files.Add(largefileName);
            }
            return files;
        }

        // GET : Show index page with all products with sorting,searching,pagination
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            var products = GetProducts();
            fillNotification();
            // Checking for sorting order
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "product_desc" : "";
            ViewBag.CategoryNameSortParm = sortOrder == "Category" ? "category_desc" : "Category";
            //check for search string 
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            // custom search
            if (!String.IsNullOrEmpty(custom))
               products= CustomSerach(products, custom, searchString);
            products = Sort(products, sortOrder);
            return View(products.ToList().ToPagedList(page ?? 1, 8));
        }

        // Private method to get all products
        private IEnumerable<ProductVM> GetProducts()
        {
            try
            {
                HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.GetAsync("product/all").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<ProductVM>>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
            
            
        }

        //Private method to perform search operation on listed products
        private IEnumerable<ProductVM> CustomSerach(IEnumerable<ProductVM> products,string custom,string searchString)
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
            return products;
        }

        // Private method to perfrom sort operation on listed products
        private IEnumerable<ProductVM> Sort(IEnumerable<ProductVM> products, string sortOrder)
        {
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
            return products;
        }
        
        // Render the chart in Dashboard page
        private ProductChartViewModel GetChart()
        {
            try
            {
                ProductChartViewModel categoryList;
                HttpResponseMessage response = Common.WebClient.WebClient.webAPIClient.GetAsync("products/GetCategory").Result;
                if (response.IsSuccessStatusCode)
                {
                    categoryList = response.Content.ReadAsAsync<ProductChartViewModel>().Result;
                    return categoryList;
                }
                else
                {
                    return null;
                }
                   
            }
            catch ( Exception)
            {
                return null;
            }
        }

        // Fill the alert notification
        private void fillNotification()
        {
            try
            {
                var loadMessage = TempData["message"];
                var createMessage = (CreateMessageNotificationModel)loadMessage;
                if (createMessage != null)
                {
                    ViewBag.Message = createMessage.message;
                    ViewBag.Color = createMessage.color;
                }
            }
            catch (Exception)
            {
                
            }
        }

        // Create the alert notification
        private void createNotification(string color, string message)
        {
            CreateMessageNotificationModel createMessageNotificationModel = new CreateMessageNotificationModel();
            createMessageNotificationModel.message = message;
            createMessageNotificationModel.color = color;
            TempData["message"] = createMessageNotificationModel;
        }
    }
}