using JWT.Interface;
using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _IProduct;
        public ProductController(IProducts IProduct)
        {
            _IProduct = IProduct;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await Task.FromResult(_IProduct.GetProductDetails());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var products = await Task.FromResult(_IProduct.GetProductDetails(id));
            if (products == null)
            {
                return NotFound();
            }
            return products;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            _IProduct.AddProduct(product);
            
            return await Task.FromResult(product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }
            try
            {
                _IProduct.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExsist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = _IProduct.DeleteProduct(id);
            return await Task.FromResult(product);
        }

        private bool ProductExsist(int id)
        {
            return _IProduct.CheckProduct(id);
        }
    }
}
