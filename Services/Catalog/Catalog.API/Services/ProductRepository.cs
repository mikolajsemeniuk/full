using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Interfaces;
using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Find(filterBuilder.Empty).ToListAsync();
        }
        public async Task<Product> GetProductAsync(string id)
        {
            return await _context.Products.Find(filterBuilder.Eq(product => product.Id, id)).FirstOrDefaultAsync();
        }
        public async Task<Product> CreateProductAsync(ProductInput input)
        {
            var product = new Product
            {
                Name = input.Name,
                Category = input.Category,
                Summary = input.Summary,
                Description = input.Description,
                ImageFile = input.ImageFile,
                Price = input.Price
            };
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<Product> SetProductAsync(string id, ProductInput input)
        {
            var product = await _context.Products.Find(filterBuilder.Eq(todo => todo.Id, id)).FirstOrDefaultAsync();
            product.Category = input.Category;
            product.Summary = input.Summary;
            product.Description = input.Description;
            product.ImageFile = input.ImageFile;
            product.Price = input.Price;
            product.Name = input.Name;
            await _context.Products.ReplaceOneAsync(filterBuilder.Eq(todo => todo.Id, id), product);
            return product;
        }

        public async Task RemoveProductAsync(string id)
        {
            await _context.Products.DeleteOneAsync(filterBuilder.Eq(todo => todo.Id, id));
        }
    }
}