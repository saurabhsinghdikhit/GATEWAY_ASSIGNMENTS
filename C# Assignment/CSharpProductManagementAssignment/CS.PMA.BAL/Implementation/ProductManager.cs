using CS.PMA.BAL.Interfaces;
using CS.PMA.BE.ViewModels;
using CS.PMA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.BAL.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool DeleteMultipleProducts(string[] ids)
        {
            return _productRepository.DeleteMultipleProducts(ids);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public ProductChartViewModel GetCategory()
        {
            return _productRepository.GetCategory();
        }

        public ProductVM GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public IEnumerable<ProductVM> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public bool InsertProduct(ProductVM product)
        {
            return _productRepository.InsertProduct(product);
        }

        public bool UpdateProduct(ProductVM product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
