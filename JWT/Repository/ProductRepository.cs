using JWT.Interface;
using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Repository
{
    public class ProductRepository : IProducts
    {
        readonly DatabaseContext _dbContext = new();
        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProduct(int id)
        {
            return _dbContext.Products.Any(c => c.ProductID == id);
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                Product product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetProductDetails()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductDetails(int id)
        {
            try
            {
                Product product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
