using JWT.Interface;
using JWT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Repository
{
    public class CategoryRepository : ICategories
    {
        readonly DatabaseContext _dbContext = new();    
        public CategoryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetCategoryDetails()
        {
            try
            {
                return _dbContext.Categories.ToList();
            }
            catch
            {
                throw;
            }
        }
        public Category GetCategoryDetails(int id)
        {
            try
            {
                Category category = _dbContext.Categories.Find(id);
                if (category != null)
                {
                    return category;
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
        public void AddCategory(Category category)
        {
            try
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void UpdateCategory(Category category)
        {
            try
            {
                _dbContext.Entry(category).State=EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public Category DeleteCategory(int id)
        {
            try
            {
                Category category = _dbContext.Categories.Find(id);
                if (category != null)
                {
                    _dbContext.Categories.Remove(category);
                    _dbContext.SaveChanges();
                    return category;
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

        public bool CheckCategory(int id)
        {
            return _dbContext.Categories.Any(c => c.CategoryID == id);
        }            
    }
}
