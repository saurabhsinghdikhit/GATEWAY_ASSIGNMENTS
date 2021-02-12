using CS.PMA.BAL.Interfaces;
using CS.PMA.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CS.PMA.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductManager _ProductManager;

        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <returns></returns>
        public ProductController(IProductManager ProductManager)
        {
            _ProductManager = ProductManager;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("product/all")]
        public IHttpActionResult GetProducts()
        {
            var records= _ProductManager.GetProducts();
            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Get Category
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("products/GetCategory")]
        public IHttpActionResult GetCategory()
        {
            var records = _ProductManager.GetCategory();
            if (records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Insert a product
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("product/save")]
        public IHttpActionResult InsertProduct(ProductVM product)
        {
            if (_ProductManager.InsertProduct(product))
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("products/{id}")]
        public IHttpActionResult GetProduct(int id)
        {
            var record = _ProductManager.GetProduct(id);
            if (record!=null)
                return Ok(record);
            else
                return NotFound();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <returns></returns>
        [HttpDelete, Route("products/delete/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            var isDeleted = _ProductManager.DeleteProduct(id);
            if (isDeleted)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("products/update")]
        public IHttpActionResult UpdateProduct(ProductVM product)
        {
            var isUpdated = _ProductManager.UpdateProduct(product);
            if (isUpdated)
                return Ok();
            else
                return NotFound();
        }

        /// <summary>
        /// Delete multiple products
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("product/deleteMultiple")]
        public IHttpActionResult DeleteMultipleProduct(string[] ids)
        {
            var isAllDeleted = _ProductManager.DeleteMultipleProducts(ids);
            if (isAllDeleted)
                return Ok();
            else
                return NotFound();
        }
    }
}
