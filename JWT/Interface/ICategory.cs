using JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Interface
{
    public  interface ICategories
    {
        public List<Category> GetCategoryDetails();   
        public Category GetCategoryDetails(int id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
        public Category DeleteCategory(int id);
        public bool CheckCategory(int id);
    }
}
