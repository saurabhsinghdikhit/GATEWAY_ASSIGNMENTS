using CS.PMA.BE.ViewModels;
using CS.PMA.DAL.Database;
using CS.PMA.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.PMA.DAL.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly PMDbContext _context;
        public ProductRepository()
        {
            _context = new PMDbContext();
        }

        public bool DeleteMultipleProducts(string[] ids)
        {
            try
            {
                foreach (var item in ids)
                {
                    if (!DeleteProduct(Convert.ToInt32(item)))
                        return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteProduct(int id)
        {
            try
            {
                Product product = _context.Products.Find(id);
                if (product == null)
                {
                    return false;
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductChartViewModel GetCategory()
        {
            try
            {
                IEnumerable<ProductChart> data = _context.Products.GroupBy(c => c.Category)
                 .Select(c => new ProductChart
                 {
                     categoryName = c.Key,
                     total = c.Count()
                 }).OrderByDescending(c => c.total)
                 .ToList();

                return new ProductChartViewModel { values = data };
            }
            catch (Exception) { return null; }
        }

        public ProductVM GetProduct(int id)
        {
            try
            {
                using(var context=new PMDbContext())
                {
                    Product product = context.Products.Find(id);
                    if (product != null)
                    {
                        return AutoMapper.Mapper.Map<ProductVM>(product);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<ProductVM> GetProducts()
        {
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<ProductVM>>(_context.Products);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertProduct(ProductVM product)
        {
            try
            {
                _context.Products.Add(AutoMapper.Mapper.Map<Product>(product));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProduct(ProductVM product)
        {
            try
            {
                var record = GetProduct(product.Id);
                product.CreatedBy = record.CreatedBy;
                product.CreatedAt = record.CreatedAt;
                _context.Entry(AutoMapper.Mapper.Map<Product>(product)).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
