using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Interface
{
    public interface IProducts
    {
        public List<Product> GetProductDetails();
        public Product GetProductDetails(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public Product DeleteProduct(int id);
        public bool CheckProduct(int id);
    }
}
