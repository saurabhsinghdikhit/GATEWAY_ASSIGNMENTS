using CS.PMA.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BAL.Interfaces
{
    public interface IProductManager
    {
        IEnumerable<ProductVM> GetProducts();
        ProductChartViewModel GetCategory();
        bool InsertProduct(ProductVM product);
        ProductVM GetProduct(int id);
        bool DeleteProduct(int id);
        bool UpdateProduct(ProductVM product);
        bool DeleteMultipleProducts(string[] ids);
    }
}
