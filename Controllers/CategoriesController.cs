using System.Collections.Generic;
using System.Threading.Tasks;
using _7sala_test_application.Models;
using _7sala_test_application.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _7sala_test_application.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MoneyBoxDbContext context;

        public CategoriesController(MoneyBoxDbContext context)
        {
            this.context = context;    
        }

        //List all categories
        [HttpGet("api/categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        //Get category by Id
        [HttpGet("api/category/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if(category == null)
                return NotFound();
            
            return category;
        }

        //Create category
        [HttpPost("api/addCategory")]
        public async Task<ActionResult<Category>> AddCategory([FromBody]Category category)
        {
            if(category == null)
                return BadRequest();

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return category;
        }

        //Update category
        [HttpPut("api/updateCategory/{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody]Category newCategory)
        {

            var category = await context.Categories.FindAsync(id);

            if(category == null)
                return NotFound();

            category.Name = newCategory.Name;
            await context.SaveChangesAsync();

            return category;
        }

        //Delete category
        [HttpDelete("api/deleteCategory/{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            var category = await context.Categories.FindAsync(id);

            if(category == null)
                return NotFound();

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return true;
        }

    }
}