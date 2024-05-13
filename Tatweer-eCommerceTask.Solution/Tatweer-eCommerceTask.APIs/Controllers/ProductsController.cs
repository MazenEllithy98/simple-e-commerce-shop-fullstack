using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatweer_eCommerceTask.Core.Entities;
using Tatweer_eCommerceTask.Core.Repositories.Contract;

namespace Tatweer_eCommerceTask.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        // /api/products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
            var products = await _productRepo.GetAllAsync();
            return Ok(products);
        }

        // /api/product/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var productById = await _productRepo.GetAsync(id);
            if (productById == null)
            {
                return NotFound(new { Message = "NotFound", StatusCode = 404 });
            }
            return Ok(productById);
        }

        // POST /api/products
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productRepo.Add(product);

            await _productRepo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT /api/products/2
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(new { Message = "Id mismatch", StatusCode = 400 });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productRepo.Update(product);

            await _productRepo.SaveChangesAsync();

            return Ok(product);
        }

        // DELETE /api/products/2
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound(new { Message = "NotFound", StatusCode = 404 });
            }

            _productRepo.Delete(product);

            await _productRepo.SaveChangesAsync();

            return NoContent();
        }
    }
}