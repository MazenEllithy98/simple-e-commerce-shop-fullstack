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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.GetAllAsync();
            return Ok(products);
        }

        //// /api/product/2
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
    }
}
