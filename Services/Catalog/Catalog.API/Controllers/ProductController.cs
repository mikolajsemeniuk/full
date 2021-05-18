using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Interfaces;
using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository) =>
            _repository = repository;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync() =>
            Ok(await _repository.GetProductsAsync());
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync([FromRoute] string id) =>
            Ok(await _repository.GetProductAsync(id));

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProductAsync([FromBody] ProductInput input) =>
            Ok(await _repository.CreateProductAsync(input));

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> SetProductAsync([FromRoute] string id, [FromBody] ProductInput input) =>
            Ok(await _repository.SetProductAsync(id, input));

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> CreateProductAsync([FromRoute] string id)
        {
            await _repository.RemoveProductAsync(id); 
            return NoContent();
        }
    }
}