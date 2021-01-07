using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagementWebAPI.Models;
using ProductManagementWebAPI.ViewModels;

namespace ProductManagementWebAPI.Controllers
{
    public class GetCategoryController : ApiController
    {
        ProductManagementProductEntities db = new ProductManagementProductEntities();
        public ProductChartViewModel getCategories()
        {
            IEnumerable<ProductChart> data = db.Products.GroupBy(c => c.Category)
                 .Select(c => new ProductChart
                 {
                     categoryName = c.Key,
                     total = c.Count()
                 }).OrderByDescending(c => c.total)
                 .ToList();

            ProductChartViewModel productChartViewModel = new ProductChartViewModel { values = data };
            return productChartViewModel;
        }
    }
}
