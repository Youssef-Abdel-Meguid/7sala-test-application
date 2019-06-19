using System.Collections.Generic;
using System.Threading.Tasks;
using _7sala_test_application.Models;
using _7sala_test_application.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _7sala_test_application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MoneyBoxDbContext context;

        public ProductsController(MoneyBoxDbContext context)
        {
            this.context = context;
        }

        //List all produts
        [HttpGet("api/products")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.Include(c => c.Category).ToListAsync();
        }

        //Get product by Id
        [HttpGet("api/product/{id}")]
        public async Task<ActionResult<Product>> GetProdcut(int id)
        {
            var product = await context.Products.FindAsync(id);

            if(product == null)
                return NotFound();

            return product;
        }

        //Get products by category ID
        [HttpGet("api/products/{categoryId}")]
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await context.Products.Include(c => c.Category)
                                         .Where(p => p.CategoryId == categoryId)
                                         .ToListAsync();
        }

        //Add new product
        [HttpPost("api/addProduct")]
        public async Task<ActionResult<Product>> AddProduct([FromBody]Product product)
        {
            if(product == null)
                return NotFound();

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return product;
        }

        //Update product
        [HttpPut("api/updateProduct/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody]Product newProduct)
        {
            
            var product = await context.Products.FindAsync(id);

            if(product == null)
                return NotFound();

            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Description = newProduct.Description;
            product.Image = newProduct.Image;
            product.Category = newProduct.Category;
            product.CategoryId = newProduct.CategoryId;

            await context.SaveChangesAsync();

            return product;
        }

        //Delete product
        [HttpDelete("api/deleteProduct/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);

            if(product == null)
                return NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return true;
        }
    }
}