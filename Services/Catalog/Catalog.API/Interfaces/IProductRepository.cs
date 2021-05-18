using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Models;

namespace Catalog.API.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(string id);
        Task<Product> CreateProductAsync(ProductInput input);
        Task<Product> SetProductAsync(string id, ProductInput input);
        Task RemoveProductAsync(string id);
    }
}