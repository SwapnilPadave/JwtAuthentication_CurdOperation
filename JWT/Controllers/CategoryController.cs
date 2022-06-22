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
    public class CategoryController : ControllerBase
    {
        private readonly ICategories _ICategory;
        public CategoryController(ICategories ICategory)
        {
            _ICategory = ICategory;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await Task.FromResult(_ICategory.GetCategoryDetails());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var categories = await Task.FromResult(_ICategory.GetCategoryDetails(id));
            if (categories == null)
            {
                return NotFound();
            }
            return categories;
        }
        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            _ICategory.AddCategory(category);
            return await Task.FromResult(category);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Put(int id, Category category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            try
            {
                _ICategory.UpdateCategory(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExsist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(category);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(int id)
        {
            var category = _ICategory.DeleteCategory(id);
            return await Task.FromResult(category);
        }

        private bool CategoryExsist(int id)
        {
            return _ICategory.CheckCategory(id);
        }
    }
}
