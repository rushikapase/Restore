using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(StoreContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == id);

            if (product is null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!await context.Products.AnyAsync(existingProduct => existingProduct.Id == id))
            {
                return NotFound();
            }

            context.Entry(product).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
